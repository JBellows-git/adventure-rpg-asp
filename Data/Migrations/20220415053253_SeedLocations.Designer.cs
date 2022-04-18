﻿// <auto-generated />
using System;
using AdventureProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdventureProject.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220415053253_SeedLocations")]
    partial class SeedLocations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdventureProject.Models.DataModels.Enemy", b =>
                {
                    b.Property<int>("EnemyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentHitPoints")
                        .HasColumnType("int");

                    b.Property<string>("EnemyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaximumDamage")
                        .HasColumnType("int");

                    b.Property<int>("MaximumHitPoints")
                        .HasColumnType("int");

                    b.Property<int>("MinimumDamage")
                        .HasColumnType("int");

                    b.Property<int>("RewardExperience")
                        .HasColumnType("int");

                    b.Property<int>("RewardGold")
                        .HasColumnType("int");

                    b.HasKey("EnemyID");

                    b.ToTable("Enemies");
                });

            modelBuilder.Entity("AdventureProject.Models.DataModels.Inventory", b =>
                {
                    b.Property<int>("InventoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DetailItemID")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerCharacterID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("InventoryID");

                    b.HasIndex("DetailItemID");

                    b.HasIndex("PlayerCharacterID");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("AdventureProject.Models.DataModels.Item", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PluralName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemID");

                    b.ToTable("Items");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Item");
                });

            modelBuilder.Entity("AdventureProject.Models.DataModels.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EnemyFightHereEnemyID")
                        .HasColumnType("int");

                    b.Property<int?>("ItemRequiredToEnterItemID")
                        .HasColumnType("int");

                    b.Property<string>("LocationDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocationToEast")
                        .HasColumnType("int");

                    b.Property<int?>("LocationToNorth")
                        .HasColumnType("int");

                    b.Property<int?>("LocationToSouth")
                        .HasColumnType("int");

                    b.Property<int?>("LocationToWest")
                        .HasColumnType("int");

                    b.Property<int?>("QuestAvailableHereQuestID")
                        .HasColumnType("int");

                    b.HasKey("LocationID");

                    b.HasIndex("EnemyFightHereEnemyID");

                    b.HasIndex("ItemRequiredToEnterItemID");

                    b.HasIndex("QuestAvailableHereQuestID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("AdventureProject.Models.DataModels.LootItem", b =>
                {
                    b.Property<int>("LootItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DetailsItemID")
                        .HasColumnType("int");

                    b.Property<int>("DropRate")
                        .HasColumnType("int");

                    b.Property<int?>("EnemyID")
                        .HasColumnType("int");

                    b.Property<int>("MaxQuantity")
                        .HasColumnType("int");

                    b.Property<int>("MinQuantity")
                        .HasColumnType("int");

                    b.HasKey("LootItemID");

                    b.HasIndex("DetailsItemID");

                    b.HasIndex("EnemyID");

                    b.ToTable("LootItems");
                });

            modelBuilder.Entity("AdventureProject.Models.DataModels.PlayerCharacter", b =>
                {
                    b.Property<int>("PlayerCharacterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CharacterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CurrentArmorItemID")
                        .HasColumnType("int");

                    b.Property<int>("CurrentHitPoints")
                        .HasColumnType("int");

                    b.Property<int>("CurrentLocationID")
                        .HasColumnType("int");

                    b.Property<int?>("CurrentWeaponItemID")
                        .HasColumnType("int");

                    b.Property<int>("ExpNeededToLevel")
                        .HasColumnType("int");

                    b.Property<int>("ExperiencePoints")
                        .HasColumnType("int");

                    b.Property<int>("Gold")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("MaximumHitPoints")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerCharacterID");

                    b.HasIndex("CurrentArmorItemID");

                    b.HasIndex("CurrentWeaponItemID");

                    b.ToTable("PlayerCharacters");
                });

            modelBuilder.Entity("AdventureProject.Models.DataModels.Quest", b =>
                {
                    b.Property<int>("QuestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("QuestCompletionItemID")
                        .HasColumnType("int");

                    b.Property<string>("QuestDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RewardExperiencePoints")
                        .HasColumnType("int");

                    b.Property<int>("RewardGold")
                        .HasColumnType("int");

                    b.Property<int?>("RewardItemItemID")
                        .HasColumnType("int");

                    b.HasKey("QuestID");

                    b.HasIndex("QuestCompletionItemID");

                    b.HasIndex("RewardItemItemID");

                    b.ToTable("Quests");
                });

            modelBuilder.Entity("AdventureProject.Models.DataModels.QuestCompletionItem", b =>
                {
                    b.Property<int>("QuestCompletionItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("detailsItemID")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("QuestCompletionItemID");

                    b.HasIndex("detailsItemID");

                    b.ToTable("QuestCompletionItems");
                });

            modelBuilder.Entity("AdventureProject.Models.DataModels.QuestLog", b =>
                {
                    b.Property<int>("QuestLogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CollectedQuestQuestID")
                        .HasColumnType("int");

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<int?>("PlayerCharacterID")
                        .HasColumnType("int");

                    b.HasKey("QuestLogID");

                    b.HasIndex("CollectedQuestQuestID");

                    b.HasIndex("PlayerCharacterID");

                    b.ToTable("QuestLogs");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AdventureProject.Models.DataModels.Armor", b =>
                {
                    b.HasBaseType("AdventureProject.Models.DataModels.Item");

                    b.Property<int>("DamageReduction")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Armor");
                });

            modelBuilder.Entity("AdventureProject.Models.DataModels.HealingPotion", b =>
                {
                    b.HasBaseType("AdventureProject.Models.DataModels.Item");

                    b.Property<int>("AmountToHeal")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("HealingPotion");
                });

            modelBuilder.Entity("AdventureProject.Models.DataModels.Weapon", b =>
                {
                    b.HasBaseType("AdventureProject.Models.DataModels.Item");

                    b.Property<int>("MaximumDamage")
                        .HasColumnType("int");

                    b.Property<int>("MinimumDamage")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Weapon");
                });

            modelBuilder.Entity("AdventureProject.Models.DataModels.Inventory", b =>
                {
                    b.HasOne("AdventureProject.Models.DataModels.Item", "Detail")
                        .WithMany()
                        .HasForeignKey("DetailItemID");

                    b.HasOne("AdventureProject.Models.DataModels.PlayerCharacter", "PlayerCharacter")
                        .WithMany()
                        .HasForeignKey("PlayerCharacterID");

                    b.Navigation("Detail");

                    b.Navigation("PlayerCharacter");
                });

            modelBuilder.Entity("AdventureProject.Models.DataModels.Location", b =>
                {
                    b.HasOne("AdventureProject.Models.DataModels.Enemy", "EnemyFightHere")
                        .WithMany()
                        .HasForeignKey("EnemyFightHereEnemyID");

                    b.HasOne("AdventureProject.Models.DataModels.Item", "ItemRequiredToEnter")
                        .WithMany()
                        .HasForeignKey("ItemRequiredToEnterItemID");

                    b.HasOne("AdventureProject.Models.DataModels.Quest", "QuestAvailableHere")
                        .WithMany()
                        .HasForeignKey("QuestAvailableHereQuestID");

                    b.Navigation("EnemyFightHere");

                    b.Navigation("ItemRequiredToEnter");

                    b.Navigation("QuestAvailableHere");
                });

            modelBuilder.Entity("AdventureProject.Models.DataModels.LootItem", b =>
                {
                    b.HasOne("AdventureProject.Models.DataModels.Item", "Details")
                        .WithMany()
                        .HasForeignKey("DetailsItemID");

                    b.HasOne("AdventureProject.Models.DataModels.Enemy", null)
                        .WithMany("LootTable")
                        .HasForeignKey("EnemyID");

                    b.Navigation("Details");
                });

            modelBuilder.Entity("AdventureProject.Models.DataModels.PlayerCharacter", b =>
                {
                    b.HasOne("AdventureProject.Models.DataModels.Armor", "CurrentArmor")
                        .WithMany()
                        .HasForeignKey("CurrentArmorItemID");

                    b.HasOne("AdventureProject.Models.DataModels.Weapon", "CurrentWeapon")
                        .WithMany()
                        .HasForeignKey("CurrentWeaponItemID");

                    b.Navigation("CurrentArmor");

                    b.Navigation("CurrentWeapon");
                });

            modelBuilder.Entity("AdventureProject.Models.DataModels.Quest", b =>
                {
                    b.HasOne("AdventureProject.Models.DataModels.QuestCompletionItem", "QuestCompletionItem")
                        .WithMany()
                        .HasForeignKey("QuestCompletionItemID");

                    b.HasOne("AdventureProject.Models.DataModels.Item", "RewardItem")
                        .WithMany()
                        .HasForeignKey("RewardItemItemID");

                    b.Navigation("QuestCompletionItem");

                    b.Navigation("RewardItem");
                });

            modelBuilder.Entity("AdventureProject.Models.DataModels.QuestCompletionItem", b =>
                {
                    b.HasOne("AdventureProject.Models.DataModels.Item", "details")
                        .WithMany()
                        .HasForeignKey("detailsItemID");

                    b.Navigation("details");
                });

            modelBuilder.Entity("AdventureProject.Models.DataModels.QuestLog", b =>
                {
                    b.HasOne("AdventureProject.Models.DataModels.Quest", "CollectedQuest")
                        .WithMany()
                        .HasForeignKey("CollectedQuestQuestID");

                    b.HasOne("AdventureProject.Models.DataModels.PlayerCharacter", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerCharacterID");

                    b.Navigation("CollectedQuest");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdventureProject.Models.DataModels.Enemy", b =>
                {
                    b.Navigation("LootTable");
                });
#pragma warning restore 612, 618
        }
    }
}
