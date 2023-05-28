﻿// <auto-generated />
using System;
using EliteAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EliteAPI.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230521002442_RemovePlayerDataLink")]
    partial class RemovePlayerDataLink
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EliteAPI.Data.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("DiscordAccountId")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("DiscordAccountId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.DiscordAccount", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("Discriminator")
                        .HasColumnType("text");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Locale")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DiscordAccounts");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProfileMemberId")
                        .HasColumnType("integer");

                    b.Property<int>("Tier")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProfileMemberId");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.ContestParticipation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Collected")
                        .HasColumnType("integer");

                    b.Property<int>("JacobContestId")
                        .HasColumnType("integer");

                    b.Property<int?>("JacobDataId")
                        .HasColumnType("integer");

                    b.Property<int>("MedalEarned")
                        .HasColumnType("integer");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.Property<int>("ProfileMemberId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("JacobContestId");

                    b.HasIndex("JacobDataId");

                    b.HasIndex("ProfileMemberId");

                    b.ToTable("ContestParticipations");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.CraftedMinion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ProfileId")
                        .HasColumnType("text");

                    b.Property<int>("ProfileMemberId")
                        .HasColumnType("integer");

                    b.Property<int>("Tiers")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.HasIndex("ProfileMemberId");

                    b.ToTable("CraftedMinions");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.JacobContest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Crop")
                        .HasColumnType("integer");

                    b.Property<int>("JacobContestEventId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("JacobContestEventId");

                    b.ToTable("JacobContests");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.JacobContestEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("JacobContestEvents");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.JacobData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Participations")
                        .HasColumnType("integer");

                    b.Property<int>("ProfileMemberId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProfileMemberId")
                        .IsUnique();

                    b.ToTable("JacobData");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<short>("CandyUsed")
                        .HasColumnType("smallint");

                    b.Property<double>("Exp")
                        .HasColumnType("double precision");

                    b.Property<string>("HeldItem")
                        .HasColumnType("text");

                    b.Property<int>("ProfileMemberId")
                        .HasColumnType("integer");

                    b.Property<string>("Skin")
                        .HasColumnType("text");

                    b.Property<string>("Tier")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<string>("UUID")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProfileMemberId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.PlayerData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("MonthlyPackageRank")
                        .HasColumnType("text");

                    b.Property<string>("NewPackageRank")
                        .HasColumnType("text");

                    b.Property<string>("Rank")
                        .HasColumnType("text");

                    b.Property<string>("RankPlusColor")
                        .HasColumnType("text");

                    b.Property<string>("SocialMedia")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PlayerData");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.Profile", b =>
                {
                    b.Property<string>("ProfileId")
                        .HasColumnType("text");

                    b.Property<int>("BankingId")
                        .HasColumnType("integer");

                    b.Property<string>("GameMode")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastSave")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("MinecraftAccountId")
                        .HasColumnType("integer");

                    b.Property<string>("ProfileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProfileId");

                    b.HasIndex("BankingId");

                    b.HasIndex("MinecraftAccountId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.ProfileBanking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Balance")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("ProfileBanking");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.ProfileBankingTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Action")
                        .HasColumnType("integer");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<string>("Initiator")
                        .HasColumnType("text");

                    b.Property<int>("ProfileBankingId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ProfileBankingId");

                    b.ToTable("ProfileBankingTransaction");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.ProfileMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsSelected")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("MinecraftAccountId")
                        .HasColumnType("integer");

                    b.Property<string>("PlayerUuid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProfileId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("WasRemoved")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("MinecraftAccountId");

                    b.HasIndex("ProfileId");

                    b.ToTable("ProfileMembers");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<long>("Exp")
                        .HasColumnType("bigint");

                    b.Property<int>("ProfileMemberId")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProfileMemberId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.MinecraftAccount", b =>
                {
                    b.Property<int>("MinecraftAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MinecraftAccountId"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("integer");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PlayerDataId")
                        .HasColumnType("integer");

                    b.HasKey("MinecraftAccountId");

                    b.HasIndex("AccountId");

                    b.HasIndex("PlayerDataId");

                    b.ToTable("MinecraftAccounts");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Premium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("PremiumUsers");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("PremiumId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("PurchaseType")
                        .HasColumnType("integer");

                    b.Property<DateTime>("PurchasedTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("PremiumId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Account", b =>
                {
                    b.HasOne("EliteAPI.Data.Models.DiscordAccount", "DiscordAccount")
                        .WithMany()
                        .HasForeignKey("DiscordAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiscordAccount");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.Collection", b =>
                {
                    b.HasOne("EliteAPI.Data.Models.Hypixel.ProfileMember", "ProfileMember")
                        .WithMany("Collections")
                        .HasForeignKey("ProfileMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProfileMember");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.ContestParticipation", b =>
                {
                    b.HasOne("EliteAPI.Data.Models.Hypixel.JacobContest", "JacobContest")
                        .WithMany("Participations")
                        .HasForeignKey("JacobContestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EliteAPI.Data.Models.Hypixel.JacobData", null)
                        .WithMany("Contests")
                        .HasForeignKey("JacobDataId");

                    b.HasOne("EliteAPI.Data.Models.Hypixel.ProfileMember", "ProfileMember")
                        .WithMany()
                        .HasForeignKey("ProfileMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JacobContest");

                    b.Navigation("ProfileMember");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.CraftedMinion", b =>
                {
                    b.HasOne("EliteAPI.Data.Models.Hypixel.Profile", null)
                        .WithMany("CraftedMinions")
                        .HasForeignKey("ProfileId");

                    b.HasOne("EliteAPI.Data.Models.Hypixel.ProfileMember", "ProfileMember")
                        .WithMany()
                        .HasForeignKey("ProfileMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProfileMember");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.JacobContest", b =>
                {
                    b.HasOne("EliteAPI.Data.Models.Hypixel.JacobContestEvent", "JacobContestEvent")
                        .WithMany("JacobContests")
                        .HasForeignKey("JacobContestEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JacobContestEvent");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.JacobData", b =>
                {
                    b.HasOne("EliteAPI.Data.Models.Hypixel.ProfileMember", "ProfileMember")
                        .WithOne("JacobData")
                        .HasForeignKey("EliteAPI.Data.Models.Hypixel.JacobData", "ProfileMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("EliteAPI.Data.Models.Hypixel.MedalInventory", "EarnedMedals", b1 =>
                        {
                            b1.Property<int>("JacobDataId")
                                .HasColumnType("integer");

                            b1.Property<int>("Bronze")
                                .HasColumnType("integer");

                            b1.Property<int>("Gold")
                                .HasColumnType("integer");

                            b1.Property<int>("Silver")
                                .HasColumnType("integer");

                            b1.HasKey("JacobDataId");

                            b1.ToTable("JacobData");

                            b1.WithOwner()
                                .HasForeignKey("JacobDataId");
                        });

                    b.OwnsOne("EliteAPI.Data.Models.Hypixel.MedalInventory", "Medals", b1 =>
                        {
                            b1.Property<int>("JacobDataId")
                                .HasColumnType("integer");

                            b1.Property<int>("Bronze")
                                .HasColumnType("integer");

                            b1.Property<int>("Gold")
                                .HasColumnType("integer");

                            b1.Property<int>("Silver")
                                .HasColumnType("integer");

                            b1.HasKey("JacobDataId");

                            b1.ToTable("JacobData");

                            b1.WithOwner()
                                .HasForeignKey("JacobDataId");
                        });

                    b.OwnsOne("EliteAPI.Data.Models.Hypixel.JacobPerks", "Perks", b1 =>
                        {
                            b1.Property<int>("JacobDataId")
                                .HasColumnType("integer");

                            b1.Property<int>("DoubleDrops")
                                .HasColumnType("integer");

                            b1.Property<int>("LevelCap")
                                .HasColumnType("integer");

                            b1.HasKey("JacobDataId");

                            b1.ToTable("JacobData");

                            b1.WithOwner()
                                .HasForeignKey("JacobDataId");
                        });

                    b.Navigation("EarnedMedals")
                        .IsRequired();

                    b.Navigation("Medals")
                        .IsRequired();

                    b.Navigation("Perks")
                        .IsRequired();

                    b.Navigation("ProfileMember");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.Pet", b =>
                {
                    b.HasOne("EliteAPI.Data.Models.Hypixel.ProfileMember", "ProfileMember")
                        .WithMany("Pets")
                        .HasForeignKey("ProfileMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProfileMember");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.Profile", b =>
                {
                    b.HasOne("EliteAPI.Data.Models.Hypixel.ProfileBanking", "Banking")
                        .WithMany()
                        .HasForeignKey("BankingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EliteAPI.Data.Models.MinecraftAccount", null)
                        .WithMany("Profiles")
                        .HasForeignKey("MinecraftAccountId");

                    b.Navigation("Banking");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.ProfileBankingTransaction", b =>
                {
                    b.HasOne("EliteAPI.Data.Models.Hypixel.ProfileBanking", "ProfileBanking")
                        .WithMany("Transactions")
                        .HasForeignKey("ProfileBankingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProfileBanking");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.ProfileMember", b =>
                {
                    b.HasOne("EliteAPI.Data.Models.MinecraftAccount", "MinecraftAccount")
                        .WithMany()
                        .HasForeignKey("MinecraftAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EliteAPI.Data.Models.Hypixel.Profile", "Profile")
                        .WithMany("Members")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MinecraftAccount");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.Skill", b =>
                {
                    b.HasOne("EliteAPI.Data.Models.Hypixel.ProfileMember", "ProfileMember")
                        .WithMany("Skills")
                        .HasForeignKey("ProfileMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProfileMember");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.MinecraftAccount", b =>
                {
                    b.HasOne("EliteAPI.Data.Models.Account", null)
                        .WithMany("MinecraftAccounts")
                        .HasForeignKey("AccountId");

                    b.HasOne("EliteAPI.Data.Models.Hypixel.PlayerData", "PlayerData")
                        .WithMany()
                        .HasForeignKey("PlayerDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("EliteAPI.Data.Models.MinecraftAccountProperty", "Properties", b1 =>
                        {
                            b1.Property<int>("MinecraftAccountId")
                                .HasColumnType("integer");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("MinecraftAccountId", "Id");

                            b1.ToTable("MinecraftAccountProperty");

                            b1.WithOwner()
                                .HasForeignKey("MinecraftAccountId");
                        });

                    b.Navigation("PlayerData");

                    b.Navigation("Properties");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Premium", b =>
                {
                    b.HasOne("EliteAPI.Data.Models.Account", "Account")
                        .WithOne("PremiumUser")
                        .HasForeignKey("EliteAPI.Data.Models.Premium", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Purchase", b =>
                {
                    b.HasOne("EliteAPI.Data.Models.Premium", null)
                        .WithMany("Purchases")
                        .HasForeignKey("PremiumId");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Account", b =>
                {
                    b.Navigation("MinecraftAccounts");

                    b.Navigation("PremiumUser");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.JacobContest", b =>
                {
                    b.Navigation("Participations");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.JacobContestEvent", b =>
                {
                    b.Navigation("JacobContests");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.JacobData", b =>
                {
                    b.Navigation("Contests");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.Profile", b =>
                {
                    b.Navigation("CraftedMinions");

                    b.Navigation("Members");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.ProfileBanking", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Hypixel.ProfileMember", b =>
                {
                    b.Navigation("Collections");

                    b.Navigation("JacobData")
                        .IsRequired();

                    b.Navigation("Pets");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.MinecraftAccount", b =>
                {
                    b.Navigation("Profiles");
                });

            modelBuilder.Entity("EliteAPI.Data.Models.Premium", b =>
                {
                    b.Navigation("Purchases");
                });
#pragma warning restore 612, 618
        }
    }
}