﻿// <auto-generated />
using System;
using FXRatesAPI.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FXRatesAPI.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231202050320_RatesAddedAmount")]
    partial class RatesAddedAmount
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FXRatesAPI.Domain.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Australian Dollar",
                            Symbol = "AUD"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Canadian Dollar",
                            Symbol = "CAD"
                        },
                        new
                        {
                            Id = 3,
                            Name = "US Dollar",
                            Symbol = "USD"
                        },
                        new
                        {
                            Id = 4,
                            Name = "British Pound Sterling",
                            Symbol = "GBP"
                        },
                        new
                        {
                            Id = 5,
                            Name = "NZ Dollar",
                            Symbol = "NZD"
                        });
                });

            modelBuilder.Entity("FXRatesAPI.Domain.Rate", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrencyFromId")
                        .HasColumnType("int");

                    b.Property<int>("CurrencyToId")
                        .HasColumnType("int");

                    b.Property<decimal>("ExchangeRate")
                        .HasPrecision(19, 9)
                        .HasColumnType("decimal(19,9)");

                    b.Property<DateTime>("ExpiredOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyFromId");

                    b.HasIndex("CurrencyToId");

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("FXRatesAPI.Domain.Rate", b =>
                {
                    b.HasOne("FXRatesAPI.Domain.Currency", "CurrencyFrom")
                        .WithMany()
                        .HasForeignKey("CurrencyFromId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FXRatesAPI.Domain.Currency", "CurrencyTo")
                        .WithMany()
                        .HasForeignKey("CurrencyToId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CurrencyFrom");

                    b.Navigation("CurrencyTo");
                });
#pragma warning restore 612, 618
        }
    }
}
