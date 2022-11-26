using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ToyShopAPI.Models
{
  public partial class toyshopapiContext : DbContext
  {
    public toyshopapiContext()
    {
    }

    public toyshopapiContext(DbContextOptions<toyshopapiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseMySql("server=ap-southeast.connect.psdb.cloud;database=toyshopapi;user=cvu22gono5t6c5djk607;password=pscale_pw_Pl8kkYQPEqVEoIF6zE1OYq91t2l8wPouxULOeJdRPaU;sslmode=VerifyFull", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql"));
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
          .HasCharSet("utf8mb4");

      modelBuilder.Entity<User>(entity =>
      {
        entity.Property(e => e.CreatedAt).HasColumnType("timestamp");

        entity.Property(e => e.Email).HasMaxLength(100);

        entity.Property(e => e.FirstName).HasMaxLength(100);

        entity.Property(e => e.LastName).HasMaxLength(100);

        entity.Property(e => e.Password).HasMaxLength(100);

        entity.Property(e => e.UpdatedAt).HasColumnType("timestamp");

        entity.Property(e => e.Username).HasMaxLength(100);
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
