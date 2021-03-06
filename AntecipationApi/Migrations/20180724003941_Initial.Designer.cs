﻿// <auto-generated />
using System;
using AntecipationApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AntecipationApi.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20180724003941_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AntecipationApi.Models.Solicitation", b =>
                {
                    b.Property<long>("SolicitationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndDateAnalysis");

                    b.Property<DateTime>("RequestDate");

                    b.Property<bool?>("Result");

                    b.Property<DateTime?>("StartDateAnalysis");

                    b.Property<decimal?>("TotalValueTransactions")
                        .HasColumnType("decimal(9, 2)");

                    b.Property<decimal?>("TotalValueTransfer")
                        .HasColumnType("decimal(9, 2)");

                    b.HasKey("SolicitationId");

                    b.ToTable("Solicitations");
                });

            modelBuilder.Entity("AntecipationApi.Models.Transaction", b =>
                {
                    b.Property<long>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("AcquirerConfirmation");

                    b.Property<DateTime?>("DateTransfer");

                    b.Property<int?>("ParcelNumber");

                    b.Property<long?>("SolicitationId");

                    b.Property<decimal?>("TransactionValue")
                        .HasColumnType("decimal(9, 2)");

                    b.Property<DateTime>("TransctionDate");

                    b.Property<decimal?>("ValueTransfer")
                        .HasColumnType("decimal(9, 2)");

                    b.HasKey("TransactionId");

                    b.HasIndex("SolicitationId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("AntecipationApi.Models.Transaction", b =>
                {
                    b.HasOne("AntecipationApi.Models.Solicitation", "Solicitation")
                        .WithMany("Transactions")
                        .HasForeignKey("SolicitationId");
                });
#pragma warning restore 612, 618
        }
    }
}
