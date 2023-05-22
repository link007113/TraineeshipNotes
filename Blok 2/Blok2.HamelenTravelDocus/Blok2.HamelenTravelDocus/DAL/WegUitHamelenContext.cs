using Blok2.HamelenTravelDocus.Model;
using Microsoft.EntityFrameworkCore;

namespace Blok2.HamelenTravelDocus.DAL;

public partial class WegUitHamelenContext : DbContext
{
    public WegUitHamelenContext()
    {
    }

    public WegUitHamelenContext(DbContextOptions<WegUitHamelenContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = @"Server=localhost;User=SA;Password=Geheim101!;Database=WegUitHamelen;TrustServerCertificate=true;MultipleActiveResultSets=True";

            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    public virtual DbSet<Medewerker> Medewerkers { get; set; }

    public virtual DbSet<Persoon> Personen { get; set; }

    public virtual DbSet<Reisdocument> Reisdocumenten { get; set; }
    public virtual DbSet<DocumentStatus> DocumentStatussen { get; set; }
    public virtual DbSet<DocumentType> DocumentTypes { get; set; }
    public virtual DbSet<Afdeling> Afdelingen { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Afdeling>(entity =>
        {
            entity.HasKey(e => e.AfdelingId)
                .HasName("PK__Afdeling__81D6EFF146F709A4")
                .IsClustered(false);

            entity.ToTable("Afdelingen", "Gemeente");

            entity.HasIndex(e => e.Naam, "UQ__Afdeling__7375E70E311329D1")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.AfdelingId).HasColumnName("AfdelingID");
            entity.Property(e => e.Naam)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DocumentStatus>(entity =>
        {
            entity.HasKey(e => e.DocumentStatusId)
                .HasName("PK__Document__AFDCAFBC680B4E5A")
                .IsClustered(false);

            entity.ToTable("DocumentStatus", "Documenten");

            entity.HasIndex(e => e.DocumentStatusNaam, "UQ__Document__CCE1150022D6459A")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.DocumentStatusId).HasColumnName("DocumentStatusID");
            entity.Property(e => e.DocumentStatusNaam).HasMaxLength(20);
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.DocumentTypeId)
                .HasName("PK__Document__DBA390C08322C474")
                .IsClustered(false);

            entity.ToTable("DocumentType", "Documenten");

            entity.HasIndex(e => e.DocumentTypeNaam, "UQ__Document__CFE34F3ED427BE44")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");
            entity.Property(e => e.DocumentTypeNaam).HasMaxLength(20);
            entity.Property(e => e.Prijs).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<Medewerker>(entity =>
        {
            entity.HasKey(e => e.MedewerkerId).HasName("PK__Medewerk__4CF73F23C65F8C2D");

            entity.ToTable("Medewerkers", "Gemeente");

            entity.Property(e => e.MedewerkerId).HasColumnName("MedewerkerID");
            entity.Property(e => e.AfdelingId).HasColumnName("AfdelingID");
            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
            entity.Property(e => e.PersoonId).HasColumnName("PersoonID");

            entity.HasOne(d => d.Afdeling).WithMany(p => p.Medewerkers)
                .HasForeignKey(d => d.AfdelingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medewerke__Afdel__3E52440B");

            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK__Medewerke__Manag__3D5E1FD2");

            entity.HasOne(d => d.Persoon).WithMany(p => p.Medewerkers)
                .HasForeignKey(d => d.PersoonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medewerke__Perso__3C69FB99");
        });

        modelBuilder.Entity<Persoon>(entity =>
        {
            entity.HasKey(e => e.PersoonId).HasName("PK__Personen__FA091400AA481FE2");

            entity.ToTable("Personen", "Burgers");

            entity.HasIndex(e => new { e.Voornaam, e.Tussenvoegsel, e.Achternaam, e.Bsn }, "UIX_Personen_Naam_BSN").IsUnique();

            entity.Property(e => e.PersoonId).HasColumnName("PersoonID");
            entity.Property(e => e.Achternaam)
                .HasMaxLength(54)
                .IsUnicode(false);
            entity.Property(e => e.Adres)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Bsn)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("BSN");
            entity.Property(e => e.Geboorteland)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("('NL')");
            entity.Property(e => e.Geboorteplaats)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('Hamelen')");
            entity.Property(e => e.OorspronkelijkeNaam).HasMaxLength(128);
            entity.Property(e => e.Postcode)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.Tussenvoegsel)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Voornaam)
                .HasMaxLength(54)
                .IsUnicode(false);
            entity.Property(e => e.Woonplaats)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Reisdocument>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__Reisdocu__1ABEEF6F6BB4F6BD");

            entity.ToTable("Reisdocumenten", "Documenten");
            entity.HasIndex(e => new { e.DocumentTypeId, e.DocumentStatusId, e.PersoonId }, "UIX_Reisdocumenten_DocumentType_DocumentStatus_PersoonID").IsUnique();

            entity.Property(e => e.DocumentId).HasColumnName("DocumentID");
            entity.Property(e => e.AanvraagDatumTijd)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.AanvraagMedewerkerId).HasColumnName("AanvraagMedewerkerID");
            entity.Property(e => e.AfgifteDatum).HasPrecision(0);
            entity.Property(e => e.AfgiftePlaats)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('Hamelen')");
            entity.Property(e => e.BetaaldePrijs).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.DocumentNr)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DocumentStatusId).HasDefaultValueSql("((1))");
            entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");
            entity.Property(e => e.PersoonId).HasColumnName("PersoonID");
            entity.Property(e => e.VerloopDatum)
                .HasPrecision(0);

            entity.HasOne(d => d.AanvraagMedewerker).WithMany(p => p.Reisdocumenten)
                .HasForeignKey(d => d.AanvraagMedewerkerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reisdocumenten_Mederwerkers");

            entity.HasOne(d => d.DocumentStatus).WithMany(p => p.Reisdocumenten)
                .HasForeignKey(d => d.DocumentStatusId)
                .HasConstraintName("FK_Reisdocumenten_DocumentStatus");

            entity.HasOne(d => d.DocumentType).WithMany(p => p.Reisdocumenten)
                .HasForeignKey(d => d.DocumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reisdocumenten_DocumentType");

            entity.HasOne(d => d.Persoon).WithMany(p => p.Reisdocumenten)
                .HasForeignKey(d => d.PersoonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reisdocumenten_Personen");
        });
    }
}