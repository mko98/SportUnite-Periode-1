using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SportUnite.DAL;

namespace SportUnite.DAL.Migrations.AppEventEntityDb
{
    [DbContext(typeof(AppEventEntityDbContext))]
    [Migration("20171120203139_naam")]
    partial class naam
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SportUnite.Domain.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Availability")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("SportComplexId");

                    b.HasKey("InvoiceId");

                    b.HasIndex("SportComplexId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("SportUnite.Domain.Models.Sport", b =>
                {
                    b.Property<int>("SportId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Availability")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("SportId");

                    b.ToTable("Sport");
                });

            modelBuilder.Entity("SportUnite.Domain.Models.SportAttribute", b =>
                {
                    b.Property<int>("SportAttributeId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Availability")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<bool>("NotUsable");

                    b.HasKey("SportAttributeId");

                    b.ToTable("SportAttribute");
                });

            modelBuilder.Entity("SportUnite.Domain.Models.SportComplex", b =>
                {
                    b.Property<int>("SportComplexId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<bool>("Availability")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("HouseNumber")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PostalCode")
                        .IsRequired();

                    b.HasKey("SportComplexId");

                    b.ToTable("SportComplex");
                });

            modelBuilder.Entity("SportUnite.Domain.Models.SportEvent", b =>
                {
                    b.Property<int>("SportEventId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Availability")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal?>("Price")
                        .IsRequired();

                    b.Property<int?>("SportHallId");

                    b.Property<int?>("SportId");

                    b.HasKey("SportEventId");

                    b.HasIndex("SportHallId");

                    b.HasIndex("SportId");

                    b.ToTable("SportEvent");
                });

            modelBuilder.Entity("SportUnite.Domain.Models.SportHall", b =>
                {
                    b.Property<int>("SportHallId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Availability")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<int?>("MaxPerson")
                        .IsRequired();

                    b.Property<int?>("MinPerson")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("SportComplexId");

                    b.HasKey("SportHallId");

                    b.HasIndex("SportComplexId");

                    b.ToTable("SportHall");
                });

            modelBuilder.Entity("SportUnite.Domain.Models.SportSportAttribute", b =>
                {
                    b.Property<int>("SportId");

                    b.Property<int>("SportAttributeId");

                    b.HasKey("SportId", "SportAttributeId");

                    b.HasIndex("SportAttributeId");

                    b.ToTable("SportSportAttribute");
                });

            modelBuilder.Entity("SportUnite.Domain.Models.Invoice", b =>
                {
                    b.HasOne("SportUnite.Domain.Models.SportComplex", "SportComplex")
                        .WithMany("Invoices")
                        .HasForeignKey("SportComplexId");
                });

            modelBuilder.Entity("SportUnite.Domain.Models.SportEvent", b =>
                {
                    b.HasOne("SportUnite.Domain.Models.SportHall", "SportHall")
                        .WithMany("SportEvents")
                        .HasForeignKey("SportHallId");

                    b.HasOne("SportUnite.Domain.Models.Sport", "Sport")
                        .WithMany("SportEvents")
                        .HasForeignKey("SportId");
                });

            modelBuilder.Entity("SportUnite.Domain.Models.SportHall", b =>
                {
                    b.HasOne("SportUnite.Domain.Models.SportComplex", "SportComplex")
                        .WithMany("SportHalls")
                        .HasForeignKey("SportComplexId");
                });

            modelBuilder.Entity("SportUnite.Domain.Models.SportSportAttribute", b =>
                {
                    b.HasOne("SportUnite.Domain.Models.SportAttribute", "SportAttribute")
                        .WithMany("SportSportAttributes")
                        .HasForeignKey("SportAttributeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportUnite.Domain.Models.Sport", "Sport")
                        .WithMany("SportSportAttributes")
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
