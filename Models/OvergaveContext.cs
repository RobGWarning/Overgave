using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Overgave.Models
{
    public partial class OvergaveContext : DbContext
    {
        public OvergaveContext()
        {
        }

        public OvergaveContext(DbContextOptions<OvergaveContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actype> Actypes { get; set; }
        public virtual DbSet<Aircraft> Aircraft { get; set; }
        public virtual DbSet<ATA> Ata { get; set; }
        public virtual DbSet<DefaultUserType> DefaultUserTypes { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<Reference> References { get; set; }
        public virtual DbSet<SubAta> SubAta { get; set; }
        public virtual DbSet<SubType> SubTypes { get; set; }
        public virtual DbSet<TS> Ts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=OvergavePre1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actype>(entity =>
            {
                entity.HasKey(x => x.Actypes);

                entity.ToTable("ACTypes");

                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.Property(e => e.Actypes)
                    .HasMaxLength(10)
                    .HasColumnName("ACTypes")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Aircraft>(entity =>
            {
                entity.HasKey(x => x.Registration)
                    .HasName("PK_Aircraft_1");

                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.HasIndex(x => x.Actype, "IX_Aircraft_ACType");

                entity.Property(e => e.Registration)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Actype)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ACType")
                    .IsFixedLength(true);

                entity.Property(e => e.Effectifity)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Etops)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.ActypeNavigation)
                    .WithMany(p => p.Aircraft)
                    .HasForeignKey(x => x.Actype)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Aircraft_ACTypes");

                entity.HasOne(d => d.SubTypeNavigation)
                    .WithMany(p => p.Aircraft)
                    .HasForeignKey(x => x.SubType)
                    .HasConstraintName("FK_Aircraft_SubTypes");
            });

            modelBuilder.Entity<ATA>(entity =>
            {
                entity.HasKey(x => x.Ata)
                    .HasName("PK_ATA_1");

                entity.ToTable("ATA");

                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.Property(e => e.Ata)
                    .ValueGeneratedNever()
                    .HasColumnName("ATA");

                entity.Property(e => e.AtaText)
                    .HasMaxLength(25)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<DefaultUserType>(entity =>
            {
                entity.HasKey(x => new { x.Klmid, x.Actype });

                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.Property(e => e.Klmid)
                    .HasMaxLength(10)
                    .HasColumnName("KLMId")
                    .IsFixedLength(true);

                entity.Property(e => e.Actype)
                    .HasMaxLength(10)
                    .HasColumnName("ACType")
                    .IsFixedLength(true);

                entity.HasOne(d => d.ActypeNavigation)
                    .WithMany(p => p.DefaultUserTypes)
                    .HasForeignKey(x => x.Actype)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DefaultUserTypes_ACTypes");

                entity.HasOne(d => d.Klm)
                    .WithMany(p => p.DefaultUserTypes)
                    .HasForeignKey(x => x.Klmid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DefaultUserTypes_TS");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.HasIndex(x => x.Acreg, "IX_Items_ACReg");

                entity.HasIndex(x => x.Ata, "IX_Items_ATA");

                entity.HasIndex(x => x.Initiator, "IX_Items_Initiator");

                entity.Property(e => e.Acreg)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ACReg")
                    .IsFixedLength(true);

                entity.Property(e => e.Ata).HasColumnName("ATA");

                entity.Property(e => e.Catagorie)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.DateTime)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.Etopsaffected)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ETOPSAffected")
                    .HasDefaultValueSql("((180))")
                    .IsFixedLength(true);

                entity.Property(e => e.Initiator)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.ItemStatus)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.OrgId).HasColumnName("orgId");

                entity.Property(e => e.Said).HasColumnName("SAId");

                entity.Property(e => e.Text).IsRequired();

                entity.Property(e => e.VakGroep)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.AcregNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(x => x.Acreg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Items_Aircraft");

                entity.HasOne(d => d.AtaNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(x => x.Ata)
                    .HasConstraintName("FK_Items_ATA");

                entity.HasOne(d => d.InitiatorNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(x => x.Initiator)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Items_TS");

                entity.HasOne(d => d.Sa)
                    .WithMany(p => p.Items)
                    .HasForeignKey(x => x.Said)
                    .HasConstraintName("FK_Items_SubAta");
            });

            modelBuilder.Entity<Part>(entity =>
            {
                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.HasIndex(x => x.ItemId, "IX_Parts_ItemId");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.RaPn)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.SnVn)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Parts)
                    .HasForeignKey(x => x.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parts_Items");
            });

            modelBuilder.Entity<Reference>(entity =>
            {
                entity.HasKey(x => x.RefId);

                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.HasIndex(x => x.ItemId, "IX_References_ItemId");

                entity.Property(e => e.RefType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Reference1)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Reference")
                    .IsFixedLength(true);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.References)
                    .HasForeignKey(x => x.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_References_Items");
            });

            modelBuilder.Entity<SubAta>(entity =>
            {
                entity.HasKey(x => x.Said);

                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.HasIndex(x => x.Ata, "IX_SubAta_ATA");

                entity.Property(e => e.Said).HasColumnName("SAId");

                entity.Property(e => e.Actype)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ACType")
                    .IsFixedLength(true);

                entity.Property(e => e.Ata).HasColumnName("ATA");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.HasOne(d => d.ActypeNavigation)
                    .WithMany(p => p.SubAta)
                    .HasForeignKey(x => x.Actype)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubAta_ACTypes");

                entity.HasOne(d => d.AtaNavigation)
                    .WithMany(p => p.SubAta)
                    .HasForeignKey(x => x.Ata)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubAta_ATA");
            });

            modelBuilder.Entity<SubType>(entity =>
            {
                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.Property(e => e.Actype)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ACType")
                    .IsFixedLength(true);

                entity.Property(e => e.SubTypeName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.ActypeNavigation)
                    .WithMany(p => p.SubTypes)
                    .HasForeignKey(x => x.Actype)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubTypes_ACTypes");
            });

            modelBuilder.Entity<TS>(entity =>
            {
                entity.HasKey(x => x.Klmid);

                entity.ToTable("TS");

                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.Property(e => e.Klmid)
                    .HasMaxLength(10)
                    .HasColumnName("KLMId")
                    .IsFixedLength(true);

                entity.Property(e => e.Initial)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");

                entity.Property(e => e.IsReadOnly).HasColumnName("isReadOnly");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
