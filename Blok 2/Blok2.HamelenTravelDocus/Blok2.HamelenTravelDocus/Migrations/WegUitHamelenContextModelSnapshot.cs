﻿// <auto-generated />
using System;
using Blok2.HamelenTravelDocus.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Blok2.HamelenTravelDocus.Migrations
{
    [DbContext(typeof(WegUitHamelenContext))]
    partial class WegUitHamelenContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Blok2.HamelenTravelDocus.Model.Afdeling", b =>
                {
                    b.Property<int>("AfdelingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AfdelingID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AfdelingId"));

                    b.Property<string>("Naam")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("AfdelingId")
                        .HasName("PK__Afdeling__81D6EFF146F709A4");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("AfdelingId"), false);

                    b.HasIndex(new[] { "Naam" }, "UQ__Afdeling__7375E70E311329D1")
                        .IsUnique();

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex(new[] { "Naam" }, "UQ__Afdeling__7375E70E311329D1"));

                    b.ToTable("Afdelingen", "Gemeente");
                });

            modelBuilder.Entity("Blok2.HamelenTravelDocus.Model.DocumentStatus", b =>
                {
                    b.Property<int>("DocumentStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DocumentStatusID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentStatusId"));

                    b.Property<string>("DocumentStatusNaam")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("DocumentStatusId")
                        .HasName("PK__Document__AFDCAFBC680B4E5A");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("DocumentStatusId"), false);

                    b.HasIndex(new[] { "DocumentStatusNaam" }, "UQ__Document__CCE1150022D6459A")
                        .IsUnique();

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex(new[] { "DocumentStatusNaam" }, "UQ__Document__CCE1150022D6459A"));

                    b.ToTable("DocumentStatus", "Documenten");
                });

            modelBuilder.Entity("Blok2.HamelenTravelDocus.Model.DocumentType", b =>
                {
                    b.Property<int>("DocumentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DocumentTypeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentTypeId"));

                    b.Property<string>("DocumentTypeNaam")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("GeldigheidsduurInDagen")
                        .HasColumnType("int");

                    b.Property<decimal>("Prijs")
                        .HasColumnType("decimal(5, 2)");

                    b.HasKey("DocumentTypeId")
                        .HasName("PK__Document__DBA390C08322C474");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("DocumentTypeId"), false);

                    b.HasIndex(new[] { "DocumentTypeNaam" }, "UQ__Document__CFE34F3ED427BE44")
                        .IsUnique();

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex(new[] { "DocumentTypeNaam" }, "UQ__Document__CFE34F3ED427BE44"));

                    b.ToTable("DocumentType", "Documenten");
                });

            modelBuilder.Entity("Blok2.HamelenTravelDocus.Model.Medewerker", b =>
                {
                    b.Property<int>("MedewerkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MedewerkerID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedewerkerId"));

                    b.Property<int>("AfdelingId")
                        .HasColumnType("int")
                        .HasColumnName("AfdelingID");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int")
                        .HasColumnName("ManagerID");

                    b.Property<int>("PersoonId")
                        .HasColumnType("int")
                        .HasColumnName("PersoonID");

                    b.HasKey("MedewerkerId")
                        .HasName("PK__Medewerk__4CF73F23C65F8C2D");

                    b.HasIndex("AfdelingId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("PersoonId");

                    b.ToTable("Medewerkers", "Gemeente");
                });

            modelBuilder.Entity("Blok2.HamelenTravelDocus.Model.Persoon", b =>
                {
                    b.Property<int>("PersoonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PersoonID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersoonId"));

                    b.Property<string>("Achternaam")
                        .IsRequired()
                        .HasMaxLength(54)
                        .IsUnicode(false)
                        .HasColumnType("varchar(54)");

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Bsn")
                        .IsRequired()
                        .HasMaxLength(9)
                        .IsUnicode(false)
                        .HasColumnType("varchar(9)")
                        .HasColumnName("BSN");

                    b.Property<string>("Geboorteland")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2)")
                        .HasDefaultValueSql("('NL')");

                    b.Property<string>("Geboorteplaats")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasDefaultValueSql("('Hamelen')");

                    b.Property<string>("OorspronkelijkeNaam")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasMaxLength(7)
                        .IsUnicode(false)
                        .HasColumnType("varchar(7)");

                    b.Property<string>("Tussenvoegsel")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasMaxLength(54)
                        .IsUnicode(false)
                        .HasColumnType("varchar(54)");

                    b.Property<string>("Woonplaats")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("PersoonId")
                        .HasName("PK__Personen__FA091400AA481FE2");

                    b.HasIndex(new[] { "Voornaam", "Tussenvoegsel", "Achternaam", "Bsn" }, "UIX_Personen_Naam_BSN")
                        .IsUnique()
                        .HasFilter("[Tussenvoegsel] IS NOT NULL");

                    b.ToTable("Personen", "Burgers");
                });

            modelBuilder.Entity("Blok2.HamelenTravelDocus.Model.Reisdocument", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DocumentID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentId"));

                    b.Property<DateTime>("AanvraagDatumTijd")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(0)
                        .HasColumnType("datetime2(0)")
                        .HasDefaultValueSql("(sysdatetime())");

                    b.Property<int>("AanvraagMedewerkerId")
                        .HasColumnType("int")
                        .HasColumnName("AanvraagMedewerkerID");

                    b.Property<DateTime>("AfgifteDatum")
                        .HasPrecision(0)
                        .HasColumnType("datetime2(0)");

                    b.Property<string>("AfgiftePlaats")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasDefaultValueSql("('Hamelen')");

                    b.Property<decimal>("BetaaldePrijs")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<string>("DocumentNr")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int?>("DocumentStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("DocumentTypeId")
                        .HasColumnType("int")
                        .HasColumnName("DocumentTypeID");

                    b.Property<int>("PersoonId")
                        .HasColumnType("int")
                        .HasColumnName("PersoonID");

                    b.Property<DateTime?>("VerloopDatum")
                        .HasPrecision(0)
                        .HasColumnType("datetime2(0)");

                    b.HasKey("DocumentId")
                        .HasName("PK__Reisdocu__1ABEEF6F6BB4F6BD");

                    b.HasIndex("AanvraagMedewerkerId");

                    b.HasIndex("DocumentStatusId");

                    b.HasIndex("PersoonId");

                    b.HasIndex(new[] { "DocumentTypeId", "DocumentStatusId", "PersoonId" }, "UIX_Reisdocumenten_DocumentType_DocumentStatus_PersoonID")
                        .IsUnique()
                        .HasFilter("[DocumentStatusId] IS NOT NULL");

                    b.ToTable("Reisdocumenten", "Documenten");
                });

            modelBuilder.Entity("Blok2.HamelenTravelDocus.Model.Medewerker", b =>
                {
                    b.HasOne("Blok2.HamelenTravelDocus.Model.Afdeling", "Afdeling")
                        .WithMany("Medewerkers")
                        .HasForeignKey("AfdelingId")
                        .IsRequired()
                        .HasConstraintName("FK__Medewerke__Afdel__3E52440B");

                    b.HasOne("Blok2.HamelenTravelDocus.Model.Medewerker", "Manager")
                        .WithMany("InverseManager")
                        .HasForeignKey("ManagerId")
                        .HasConstraintName("FK__Medewerke__Manag__3D5E1FD2");

                    b.HasOne("Blok2.HamelenTravelDocus.Model.Persoon", "Persoon")
                        .WithMany("Medewerkers")
                        .HasForeignKey("PersoonId")
                        .IsRequired()
                        .HasConstraintName("FK__Medewerke__Perso__3C69FB99");

                    b.Navigation("Afdeling");

                    b.Navigation("Manager");

                    b.Navigation("Persoon");
                });

            modelBuilder.Entity("Blok2.HamelenTravelDocus.Model.Reisdocument", b =>
                {
                    b.HasOne("Blok2.HamelenTravelDocus.Model.Medewerker", "AanvraagMedewerker")
                        .WithMany("Reisdocumenten")
                        .HasForeignKey("AanvraagMedewerkerId")
                        .IsRequired()
                        .HasConstraintName("FK_Reisdocumenten_Mederwerkers");

                    b.HasOne("Blok2.HamelenTravelDocus.Model.DocumentStatus", "DocumentStatus")
                        .WithMany("Reisdocumenten")
                        .HasForeignKey("DocumentStatusId")
                        .HasConstraintName("FK_Reisdocumenten_DocumentStatus");

                    b.HasOne("Blok2.HamelenTravelDocus.Model.DocumentType", "DocumentType")
                        .WithMany("Reisdocumenten")
                        .HasForeignKey("DocumentTypeId")
                        .IsRequired()
                        .HasConstraintName("FK_Reisdocumenten_DocumentType");

                    b.HasOne("Blok2.HamelenTravelDocus.Model.Persoon", "Persoon")
                        .WithMany("Reisdocumenten")
                        .HasForeignKey("PersoonId")
                        .IsRequired()
                        .HasConstraintName("FK_Reisdocumenten_Personen");

                    b.Navigation("AanvraagMedewerker");

                    b.Navigation("DocumentStatus");

                    b.Navigation("DocumentType");

                    b.Navigation("Persoon");
                });

            modelBuilder.Entity("Blok2.HamelenTravelDocus.Model.Afdeling", b =>
                {
                    b.Navigation("Medewerkers");
                });

            modelBuilder.Entity("Blok2.HamelenTravelDocus.Model.DocumentStatus", b =>
                {
                    b.Navigation("Reisdocumenten");
                });

            modelBuilder.Entity("Blok2.HamelenTravelDocus.Model.DocumentType", b =>
                {
                    b.Navigation("Reisdocumenten");
                });

            modelBuilder.Entity("Blok2.HamelenTravelDocus.Model.Medewerker", b =>
                {
                    b.Navigation("InverseManager");

                    b.Navigation("Reisdocumenten");
                });

            modelBuilder.Entity("Blok2.HamelenTravelDocus.Model.Persoon", b =>
                {
                    b.Navigation("Medewerkers");

                    b.Navigation("Reisdocumenten");
                });
#pragma warning restore 612, 618
        }
    }
}
