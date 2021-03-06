﻿// <auto-generated />
using System;
using MailLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MailLibrary.Migrations
{
    [DbContext(typeof(MailDb))]
    [Migration("20201218094914_Seed-Servers")]
    partial class SeedServers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("MailLibrary.Model.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Emails", "dbo");
                });

            modelBuilder.Entity("MailLibrary.Model.Recipient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Recipients", "dbo");
                });

            modelBuilder.Entity("MailLibrary.Model.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmailId")
                        .HasColumnType("int");

                    b.Property<int?>("RecipientId")
                        .HasColumnType("int");

                    b.Property<int?>("SenderId")
                        .HasColumnType("int");

                    b.Property<int?>("ServerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmailId");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.HasIndex("ServerId");

                    b.ToTable("Schedules", "dbo");
                });

            modelBuilder.Entity("MailLibrary.Model.Sender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Senders", "dbo");
                });

            modelBuilder.Entity("MailLibrary.Model.Server", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Host")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Servers", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Host = "smtp.yandex.ru",
                            Password = "",
                            Port = 565,
                            User = "test"
                        },
                        new
                        {
                            Id = 2,
                            Host = "smtp.mail.ru",
                            Password = "",
                            Port = 25,
                            User = "test"
                        },
                        new
                        {
                            Id = 3,
                            Host = "smtp.gmail.com",
                            Password = "",
                            Port = 467,
                            User = "test"
                        });
                });

            modelBuilder.Entity("MailLibrary.Model.Schedule", b =>
                {
                    b.HasOne("MailLibrary.Model.Email", "Email")
                        .WithMany()
                        .HasForeignKey("EmailId");

                    b.HasOne("MailLibrary.Model.Recipient", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId");

                    b.HasOne("MailLibrary.Model.Sender", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");

                    b.HasOne("MailLibrary.Model.Server", "Server")
                        .WithMany()
                        .HasForeignKey("ServerId");

                    b.Navigation("Email");

                    b.Navigation("Recipient");

                    b.Navigation("Sender");

                    b.Navigation("Server");
                });
#pragma warning restore 612, 618
        }
    }
}
