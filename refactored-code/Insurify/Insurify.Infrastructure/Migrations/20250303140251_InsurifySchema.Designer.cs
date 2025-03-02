﻿// <auto-generated />
using System;
using Insurify.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Insurify.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250303140251_InsurifySchema")]
    partial class InsurifySchema
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Insurify.Domain.Customers.Customer", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("FirstName");

                    b.Property<bool>("HasSecurityCertificate")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("LastName");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("t_customers", (string)null);
                });

            modelBuilder.Entity("Insurify.Domain.InsurancePolicies.InsurancePolicy", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InsuranceId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("SubscriberId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InsuranceId");

                    b.HasIndex("SubscriberId");

                    b.ToTable("t_insurancepolicies", (string)null);
                });

            modelBuilder.Entity("Insurify.Domain.Insurances.Insurance", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Description");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("t_insurances", (string)null);
                });

            modelBuilder.Entity("Insurify.Domain.Customers.Customer", b =>
                {
                    b.OwnsOne("Insurify.Domain.Customers.Address", "Address", b1 =>
                        {
                            b1.Property<int>("CustomerId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("ZipCode");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("State");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Street");

                            b1.HasKey("CustomerId");

                            b1.ToTable("t_customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("Insurify.Domain.InsurancePolicies.InsurancePolicy", b =>
                {
                    b.HasOne("Insurify.Domain.Insurances.Insurance", null)
                        .WithMany()
                        .HasForeignKey("InsuranceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Insurify.Domain.Customers.Customer", null)
                        .WithMany()
                        .HasForeignKey("SubscriberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Insurify.Domain.Shared.Money", "Fee", b1 =>
                        {
                            b1.Property<int>("InsurancePolicyId")
                                .HasColumnType("int");

                            b1.Property<decimal>("Amount")
                                .HasPrecision(18, 4)
                                .HasColumnType("decimal(18,4)")
                                .HasColumnName("FeeAmount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("FeeCurrency");

                            b1.HasKey("InsurancePolicyId");

                            b1.ToTable("t_insurancepolicies");

                            b1.WithOwner()
                                .HasForeignKey("InsurancePolicyId");
                        });

                    b.OwnsOne("Insurify.Domain.Shared.Money", "InsuredAmount", b1 =>
                        {
                            b1.Property<int>("InsurancePolicyId")
                                .HasColumnType("int");

                            b1.Property<decimal>("Amount")
                                .HasPrecision(18, 4)
                                .HasColumnType("decimal(18,4)")
                                .HasColumnName("InsuredAmount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("InsuredCurrency");

                            b1.HasKey("InsurancePolicyId");

                            b1.ToTable("t_insurancepolicies");

                            b1.WithOwner()
                                .HasForeignKey("InsurancePolicyId");
                        });

                    b.Navigation("Fee")
                        .IsRequired();

                    b.Navigation("InsuredAmount")
                        .IsRequired();
                });

            modelBuilder.Entity("Insurify.Domain.Insurances.Insurance", b =>
                {
                    b.OwnsOne("Insurify.Domain.Shared.Money", "Price", b1 =>
                        {
                            b1.Property<int>("InsuranceId")
                                .HasColumnType("int");

                            b1.Property<decimal>("Amount")
                                .HasPrecision(18, 4)
                                .HasColumnType("decimal(18,4)")
                                .HasColumnName("PriceAmount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("PriceCurrency");

                            b1.HasKey("InsuranceId");

                            b1.ToTable("t_insurances");

                            b1.WithOwner()
                                .HasForeignKey("InsuranceId");
                        });

                    b.Navigation("Price")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
