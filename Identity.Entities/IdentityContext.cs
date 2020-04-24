using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Identity.Entities
{
    public partial class IdentityContext : IdentityDbContext<
        ApplicationUser,
        ApplicationRole,
        int,
        ApplicationUserClaim,
        ApplicationUserRole,
        ApplicationUserLogin,
        ApplicationRoleClaim,
        ApplicationUserToken>
    {
        public IdentityContext()
        {
        }

        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationRole> ApplicationRole { get; set; }
        public virtual DbSet<ApplicationRoleClaim> ApplicationRoleClaim { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }
        public virtual DbSet<ApplicationUserClaim> ApplicationUserClaim { get; set; }
        public virtual DbSet<ApplicationUserLogin> ApplicationUserLogin { get; set; }
        public virtual DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }
        public virtual DbSet<ApplicationUserToken> ApplicationUserToken { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Identity;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationRole>(entity =>
            {
                entity.Property(e => e.ConcurrencyStamp).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.NormalizedName).IsRequired();
            });

            modelBuilder.Entity<ApplicationRoleClaim>(entity =>
            {
                entity.Property(e => e.ClaimType).IsRequired();

                entity.Property(e => e.ClaimValue).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.ApplicationRoleClaim)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationRoleClaim_RoleId");
            });

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.ConcurrencyStamp).IsRequired();

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.NormalizedEmail).IsRequired();

                entity.Property(e => e.NormalizedUserName).IsRequired();

                entity.Property(e => e.PasswordHash).IsRequired();

                entity.Property(e => e.PhoneNumber).IsRequired();

                entity.Property(e => e.SecurityStamp).IsRequired();

                entity.Property(e => e.UserName).IsRequired();
            });

            modelBuilder.Entity<ApplicationUserClaim>(entity =>
            {
                entity.Property(e => e.ClaimType).IsRequired();

                entity.Property(e => e.ClaimValue).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ApplicationUserClaim)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationUserClaim_ApplicationUser");
            });

            modelBuilder.Entity<ApplicationUserLogin>(entity =>
            {
                entity.Property(e => e.LoginProvider).IsRequired();

                entity.Property(e => e.ProviderDisplayName).IsRequired();

                entity.Property(e => e.ProviderKey).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ApplicationUserLogin)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationUserLogin_UserId");
            });

            modelBuilder.Entity<ApplicationUserRole>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.ApplicationUserRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationUserRole_ApplicationRole");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ApplicationUserRole)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationUserRole_ApplicationUser");
            });

            modelBuilder.Entity<ApplicationUserToken>(entity =>
            {
                entity.Property(e => e.LoginProvider).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Value).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ApplicationUserToken)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationUserToken_UserId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
