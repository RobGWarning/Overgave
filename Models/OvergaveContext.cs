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
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<Reference> References { get; set; }
        public virtual DbSet<SubATA> SubAta { get; set; }
        public virtual DbSet<TS> Ts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=ROBLAPTOP\\SQLEXPRESS;Initial Catalog=OvergavePre1;Integrated Security=True; ConnectRetryCount=0");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actype>(entity =>
            {
                entity.Property(e => e.Actypes).HasColumnName("ACTypes");

                entity.Property(e => e.SubType).IsFixedLength(true);

                entity.Property(e => e.TypeName).IsFixedLength(true);
            });

            modelBuilder.Entity<Aircraft>(entity =>
            {
                entity.HasKey(x => x.Registration)
                    .HasName("PK_Aircraft_1");

                entity.Property(e => e.Registration).IsFixedLength(true);

                entity.Property(e => e.Actype).HasColumnName("ACType");

                entity.Property(e => e.Effectifity).IsFixedLength(true);

                entity.Property(e => e.Etops).IsFixedLength(true);

                entity.Property(e => e.Status).IsFixedLength(true);

                entity.HasOne(d => d.ActypeNavigation)
                    .WithMany(p => p.Aircraft)
                    .HasForeignKey(x => x.Actype)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Aircraft_ACTypes");
            });

            modelBuilder.Entity<ATA>(entity =>
            {
                entity.HasKey(x => x.Ata)
                    .HasName("PK_ATA_1");

                entity.Property(e => e.Ata)
                    .ValueGeneratedNever()
                    .HasColumnName("ATA");

                entity.Property(e => e.AtaText).IsFixedLength(true);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.ItemId).ValueGeneratedNever();

                entity.Property(e => e.Acreg)
                    .HasColumnName("ACReg")
                    .IsFixedLength(true);

                entity.Property(e => e.Ata).HasColumnName("ATA");

                entity.Property(e => e.Catagorie).IsFixedLength(true);

                entity.Property(e => e.DateTime).HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.Etopsaffected)
                    .HasColumnName("ETOPSAffected")
                    .HasDefaultValueSql("((180))")
                    .IsFixedLength(true);

                entity.Property(e => e.Initiator).IsFixedLength(true);

                entity.Property(e => e.ItemStatus).IsFixedLength(true);

                entity.Property(e => e.OrgId).HasColumnName("orgId");

                entity.Property(e => e.SubAta).IsFixedLength(true);

                entity.Property(e => e.VakGroep).IsFixedLength(true);

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

                entity.HasOne(d => d.SubAtaNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(x => x.SubAta)
                    .HasConstraintName("FK_Items_SubAta");
            });

            modelBuilder.Entity<Part>(entity =>
            {
                entity.Property(e => e.PartId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsFixedLength(true);

                entity.Property(e => e.RaPn).IsFixedLength(true);

                entity.Property(e => e.SnVn).IsFixedLength(true);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Parts)
                    .HasForeignKey(x => x.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parts_Items");
            });

            modelBuilder.Entity<Reference>(entity =>
            {
                entity.Property(e => e.RefId).ValueGeneratedNever();

                entity.Property(e => e.RefType).IsFixedLength(true);

                entity.Property(e => e.Reference1)
                    .HasColumnName("Reference")
                    .IsFixedLength(true);

                entity.Property(e => e.Status).IsFixedLength(true);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.References)
                    .HasForeignKey(x => x.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_References_Items");
            });

            modelBuilder.Entity<SubATA>(entity =>
            {
                entity.Property(e => e.SubAta).IsFixedLength(true);

                entity.Property(e => e.A330).IsFixedLength(true);

                entity.Property(e => e.Ata).HasColumnName("ATA");

                entity.Property(e => e.B737).IsFixedLength(true);

                entity.Property(e => e.B747).IsFixedLength(true);

                entity.Property(e => e.B777).IsFixedLength(true);

                entity.Property(e => e.B787).IsFixedLength(true);

                entity.HasOne(d => d.AtaNavigation)
                    .WithMany(p => p.SubAta)
                    .HasForeignKey(x => x.Ata)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubAta_ATA");
            });

            modelBuilder.Entity<TS>(entity =>
            {
                entity.Property(e => e.Klmid)
                    .HasColumnName("KLMId")
                    .IsFixedLength(true);

                entity.Property(e => e.Initial).IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
