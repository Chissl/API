﻿using System.Text.Json;
using Asp.Versioning;
using EliteAPI.Data;
using EliteAPI.Models.DTOs.Outgoing;
using EliteAPI.Models.Entities.Hypixel;
using EliteAPI.Parsers.Farming;
using EliteAPI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EliteAPI.Controllers.Contests; 

[ApiController, ApiVersion(1.0)]
[Route("/graph/medals")]
[Route("/v{version:apiVersion}/graph/medals")]
public class MedalGraphsController(DataContext context) : ControllerBase {
    private static readonly JsonSerializerOptions Options = new() {
        PropertyNameCaseInsensitive = true
    };

    /// <summary>
    /// Get current average medal brackets
    /// </summary>
    /// <param name="months">Amount of previous Skyblock months to include</param>
    /// <returns></returns>
    [HttpGet("now")]
    [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    public async Task<ActionResult<ContestBracketsDetailsDto>> GetMedalBrackets([FromQuery] int months = 2) {
        switch (months) {
            case < 1:
                return BadRequest("Months cannot be less than 1.");
            case > 12:
                return BadRequest("Months cannot be greater than 12.");
        }

        // Exclude the last 3 hours to minimize the chance of inaccurate data from new contests
        var end = new SkyblockDate(DateTimeOffset.UtcNow.AddHours(-3).ToUnixTimeSeconds());
        var start = new SkyblockDate(end.Year - 1, end.Month - months, end.Day).UnixSeconds;
        
        var brackets = await GetAverageMedalBrackets(context, start, end.UnixSeconds);

        return Ok(new ContestBracketsDetailsDto {
            Start = start.ToString(),
            End = end.UnixSeconds.ToString(),
            Brackets = brackets ?? new Dictionary<string, ContestBracketsDto>()
        });
    }
    
    /// <summary>
    /// Get medal brackets for a specific month
    /// </summary>
    /// <param name="sbYear">Skyblock Year</param>
    /// <param name="sbMonth">Skyblock Month</param>
    /// <param name="months">Amount of previous Skyblock months to include</param>
    /// <returns></returns>
    [HttpGet("{sbYear:int}/{sbMonth:int}")]
    [ResponseCache(Duration = 60 * 60, Location = ResponseCacheLocation.Any)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    public async Task<ActionResult<ContestBracketsDetailsDto>> GetMedalBrackets(int sbYear, int sbMonth, [FromQuery] int months = 2) {
        if (sbYear < 1) {
            return BadRequest("Year cannot be less than 1.");
        }
        
        switch (sbMonth) {
            case < 1:
                return BadRequest("Month cannot be less than 1.");
            case > 12:
                return BadRequest("Month cannot be greater than 12.");
        }

        switch (months) {
            case < 1:
                return BadRequest("Months cannot be less than 1.");
            case > 12:
                return BadRequest("Months cannot be greater than 12.");
        }

        var start = new SkyblockDate(sbYear - 1, sbMonth - months, 0).UnixSeconds;
        var end = new SkyblockDate(sbYear - 1, sbMonth, 0).UnixSeconds;
        
        var brackets = await GetAverageMedalBrackets(context, start, end);

        return Ok(new ContestBracketsDetailsDto {
            Start = start.ToString(),
            End = end.ToString(),
            Brackets = brackets ?? new Dictionary<string, ContestBracketsDto>(),
        });
    }
    
    /// <summary>
    /// Get medal brackets for multiple years
    /// </summary>
    /// <param name="sbYear">Starting Skyblock Year</param>
    /// <param name="years">Amount of years to include</param>
    /// <param name="months">Amount of previous Skyblock months to include for each year</param>
    /// <returns></returns>
    [HttpGet("{sbYear:int}")]
    [ResponseCache(Duration = 60 * 60, Location = ResponseCacheLocation.Any)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    public async Task<ActionResult<List<ContestBracketsDetailsDto>>> GetMedalBracketsGraph(int sbYear, [FromQuery] int years = 1, [FromQuery] int months = 2) {
        if (sbYear < 1) {
            return BadRequest("Year cannot be less than 1.");
        }

        switch (years) {
            case < 1:
                return BadRequest("Years cannot be less than 1.");
            case > 5:
                return BadRequest("Years cannot be greater than 5.");
        }
        
        switch (months) {
            case < 1:
                return BadRequest("Months cannot be less than 1.");
            case > 12:
                return BadRequest("Months cannot be greater than 12.");
        }


        var result = new List<ContestBracketsDetailsDto>();
        
        for (var i = years; i > 0; i--) {
            for (var month = 0; month < 12; month++) {
                var start = new SkyblockDate(sbYear - years - 1, month - months, 0).UnixSeconds;
                var end = new SkyblockDate(sbYear - years, month, 0).UnixSeconds;

                result.Add(new ContestBracketsDetailsDto {
                    Start = start.ToString(),
                    End = end.ToString(),
                    Brackets = await GetAverageMedalBrackets(context, start, end) ?? new Dictionary<string, ContestBracketsDto>()
                });
            }
        }

        return Ok(result);
    }

    private static async Task<Dictionary<string, ContestBracketsDto>?> GetAverageMedalBrackets(DbContext context, long start, long end) {
        var medals = await context.Database
            .SqlQuery<string>($@"
                SELECT json_agg(c) AS ""Value""
                FROM (
                    SELECT
                        ""Crop"",
                        AVG(NULLIF(""Diamond"", 0)) AS ""Diamond"",
                        AVG(NULLIF(""Platinum"", 0)) AS ""Platinum"",
                        AVG(NULLIF(""Gold"", 0)) AS ""Gold"",
                        AVG(NULLIF(""Silver"", 0)) AS ""Silver"",
                        AVG(NULLIF(""Bronze"", 0)) AS ""Bronze""
                    FROM ""JacobContests""
                    WHERE ""Timestamp"" >= {start} AND ""Timestamp"" <= {end}
                    GROUP BY ""Crop""
                ) c
            ")
            .ToListAsync();

        try {
            var parsed = JsonSerializer.Deserialize<List<MedalCutoffsDbDto>>(medals.First(), Options);

            var dto = parsed!.ToDictionary(
                m => ((Crop)m.Crop).SimpleName(),
                m => new ContestBracketsDto {
                    Diamond = (int) (m.Diamond ?? 0),
                    Platinum = (int) (m.Platinum ?? 0),
                    Gold = (int) (m.Gold ?? 0),
                    Silver = (int) (m.Silver ?? 0),
                    Bronze = (int) (m.Bronze ?? 0)
                });
            
            // Add missing crops to the dictionary
            if (dto.Count < 9) {
                foreach (var crop in Enum.GetValues<Crop>()) {
                    var name = crop.SimpleName();
                    dto.TryAdd(name, new ContestBracketsDto());
                }
            }
            
            return dto!;
        }
        catch 
        {
            return null;
        }
    }
}