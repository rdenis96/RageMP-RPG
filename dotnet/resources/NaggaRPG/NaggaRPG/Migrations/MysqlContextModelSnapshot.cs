﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NaggaRPG.EntityContexts;

namespace NaggaRPG.Migrations
{
    [DbContext(typeof(MysqlContext))]
    partial class MysqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("NaggaRPG.Models.Accounts.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsLogged")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastActiveDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("NaggaRPG.Models.Factions.Faction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FactionId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<int>("Warns")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("factions");
                });

            modelBuilder.Entity("NaggaRPG.Models.Players.PlayerInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("Armor")
                        .HasColumnType("int");

                    b.Property<long>("BankMoney")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<int>("FactionInfoId")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastActiveDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("Licenses")
                        .HasColumnType("int");

                    b.Property<long>("Money")
                        .HasColumnType("bigint");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<int>("RespectPoints")
                        .HasColumnType("int");

                    b.Property<double>("TimePlayed")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("FactionInfoId");

                    b.ToTable("PlayerInfos");
                });

            modelBuilder.Entity("NaggaRPG.Models.Factions.Faction", b =>
                {
                    b.OwnsOne("NaggaRPG.Models.Common.Mute", "Mute", b1 =>
                        {
                            b1.Property<int>("FactionId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("ExpirationTime")
                                .HasColumnType("datetime");

                            b1.Property<bool>("IsMuted")
                                .HasColumnType("tinyint(1)");

                            b1.Property<string>("Reason")
                                .HasColumnType("longtext");

                            b1.HasKey("FactionId");

                            b1.ToTable("factions");

                            b1.WithOwner()
                                .HasForeignKey("FactionId");
                        });

                    b.Navigation("Mute");
                });

            modelBuilder.Entity("NaggaRPG.Models.Players.PlayerInfo", b =>
                {
                    b.HasOne("NaggaRPG.Models.Accounts.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NaggaRPG.Models.Factions.Faction", "Faction")
                        .WithMany()
                        .HasForeignKey("FactionInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("GTANetworkAPI.Vector3", "Position", b1 =>
                        {
                            b1.Property<int>("PlayerInfoId")
                                .HasColumnType("int");

                            b1.Property<float>("X")
                                .HasColumnType("float");

                            b1.Property<float>("Y")
                                .HasColumnType("float");

                            b1.Property<float>("Z")
                                .HasColumnType("float");

                            b1.HasKey("PlayerInfoId");

                            b1.ToTable("PlayerInfos");

                            b1.WithOwner()
                                .HasForeignKey("PlayerInfoId");
                        });

                    b.OwnsOne("GTANetworkAPI.Vector3", "Rotation", b1 =>
                        {
                            b1.Property<int>("PlayerInfoId")
                                .HasColumnType("int");

                            b1.Property<float>("X")
                                .HasColumnType("float");

                            b1.Property<float>("Y")
                                .HasColumnType("float");

                            b1.Property<float>("Z")
                                .HasColumnType("float");

                            b1.HasKey("PlayerInfoId");

                            b1.ToTable("PlayerInfos");

                            b1.WithOwner()
                                .HasForeignKey("PlayerInfoId");
                        });

                    b.OwnsOne("NaggaRPG.Models.Admins.AdminInfo", "Admin", b1 =>
                        {
                            b1.Property<int>("PlayerInfoId")
                                .HasColumnType("int");

                            b1.Property<int>("AdminLevel")
                                .HasColumnType("int");

                            b1.Property<string>("ChatColor")
                                .HasColumnType("longtext");

                            b1.HasKey("PlayerInfoId");

                            b1.ToTable("PlayerInfos");

                            b1.WithOwner()
                                .HasForeignKey("PlayerInfoId");
                        });

                    b.OwnsOne("NaggaRPG.Models.Common.Mute", "Mute", b1 =>
                        {
                            b1.Property<int>("PlayerInfoId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("ExpirationTime")
                                .HasColumnType("datetime");

                            b1.Property<bool>("IsMuted")
                                .HasColumnType("tinyint(1)");

                            b1.Property<string>("Reason")
                                .HasColumnType("longtext");

                            b1.HasKey("PlayerInfoId");

                            b1.ToTable("PlayerInfos");

                            b1.WithOwner()
                                .HasForeignKey("PlayerInfoId");
                        });

                    b.OwnsOne("NaggaRPG.Models.Players.IdentityCard", "IdCard", b1 =>
                        {
                            b1.Property<int>("PlayerInfoId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("BirthDate")
                                .HasColumnType("datetime(6)");

                            b1.Property<string>("RealName")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<int>("Sex")
                                .HasColumnType("int");

                            b1.HasKey("PlayerInfoId");

                            b1.ToTable("PlayerInfos");

                            b1.WithOwner()
                                .HasForeignKey("PlayerInfoId");
                        });

                    b.Navigation("Account");

                    b.Navigation("Admin");

                    b.Navigation("Faction");

                    b.Navigation("IdCard");

                    b.Navigation("Mute");

                    b.Navigation("Position");

                    b.Navigation("Rotation");
                });
#pragma warning restore 612, 618
        }
    }
}
