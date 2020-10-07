﻿// <auto-generated />
using System;
using HouseOflaw.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HouseOflaw.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201005152415_roule")]
    partial class roule
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HouseOflaw.API.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("UserCode")
                        .HasColumnType("float");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("HouseOflaw.API.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Acc_Code")
                        .HasColumnType("float");

                    b.Property<double>("Code")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateEntry")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IsVoke")
                        .HasColumnType("int");

                    b.Property<string>("Name_Ar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHashed")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Response")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Switch")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HouseOflaw.API.Models.Photo", b =>
                {
                    b.HasOne("HouseOflaw.API.Models.User", "User")
                        .WithMany("Photos")
                        .HasForeignKey("UserID");
                });
#pragma warning restore 612, 618
        }
    }
}