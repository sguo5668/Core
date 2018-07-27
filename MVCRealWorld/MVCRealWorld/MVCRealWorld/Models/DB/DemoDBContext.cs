using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVCRealWorld.Models.DB
{
    public partial class DemoDBContext : DbContext
    {
        public DemoDBContext()
        {
        }

        public DemoDBContext(DbContextOptions<DemoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Lookuprole> Lookuprole { get; set; }
        public virtual DbSet<Sysuser> Sysuser { get; set; }
        public virtual DbSet<SysuserProfile> SysuserProfile { get; set; }
        public virtual DbSet<SysuserRole> SysuserRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DemoDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lookuprole>(entity =>
            {
                entity.ToTable("LOOKUPRole");

                entity.Property(e => e.LookuproleId).HasColumnName("LOOKUPRoleID");

                entity.Property(e => e.RoleDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RowCreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RowCreatedSysuserId).HasColumnName("RowCreatedSYSUserID");

                entity.Property(e => e.RowModifiedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RowModifiedSysuserId).HasColumnName("RowModifiedSYSUserID");
            });

            modelBuilder.Entity<Sysuser>(entity =>
            {
                entity.ToTable("SYSUser");

                entity.Property(e => e.SysuserId).HasColumnName("SYSUserID");

                entity.Property(e => e.LoginName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordEncryptedText)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RowCreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RowCreatedSysuserId).HasColumnName("RowCreatedSYSUserID");

                entity.Property(e => e.RowModifiedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RowModifiedSysuserId).HasColumnName("RowModifiedSYSUserID");
            });

            modelBuilder.Entity<SysuserProfile>(entity =>
            {
                entity.ToTable("SYSUserProfile");

                entity.Property(e => e.SysuserProfileId).HasColumnName("SYSUserProfileID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RowCreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RowCreatedSysuserId).HasColumnName("RowCreatedSYSUserID");

                entity.Property(e => e.RowModifiedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RowModifiedSysuserId).HasColumnName("RowModifiedSYSUserID");

                entity.Property(e => e.SysuserId).HasColumnName("SYSUserID");

                entity.HasOne(d => d.Sysuser)
                    .WithMany(p => p.SysuserProfile)
                    .HasForeignKey(d => d.SysuserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SYSUserPr__SYSUs__108B795B");
            });

            modelBuilder.Entity<SysuserRole>(entity =>
            {
                entity.ToTable("SYSUserRole");

                entity.Property(e => e.SysuserRoleId).HasColumnName("SYSUserRoleID");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LookuproleId).HasColumnName("LOOKUPRoleID");

                entity.Property(e => e.RowCreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RowCreatedSysuserId).HasColumnName("RowCreatedSYSUserID");

                entity.Property(e => e.RowModifiedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RowModifiedSysuserId).HasColumnName("RowModifiedSYSUserID");

                entity.Property(e => e.SysuserId).HasColumnName("SYSUserID");

                entity.HasOne(d => d.Lookuprole)
                    .WithMany(p => p.SysuserRole)
                    .HasForeignKey(d => d.LookuproleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SYSUserRo__LOOKU__182C9B23");

                entity.HasOne(d => d.Sysuser)
                    .WithMany(p => p.SysuserRole)
                    .HasForeignKey(d => d.SysuserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SYSUserRo__SYSUs__1920BF5C");
            });
        }
    }
}
