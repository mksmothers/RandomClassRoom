using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RandomSeats.Models;

namespace RandomSeats.Data;

public partial class RandomSeatsContext : DbContext
{
    public RandomSeatsContext()
    {
    }

    public RandomSeatsContext(DbContextOptions<RandomSeatsContext> options)
        : base(options)
    {
    }
    const string prod = "Data Source=tcp:s30.winhost.com;Initial Catalog=DB_167542_tondamark;User ID=DB_167542_tondamark_user;Password=R3bootme!;Integrated Security=False;TrustServerCertificate=true;";
    const string gamedb = "data source=GAMING;initial catalog=RandomSeats;trusted_connection=true;TrustServerCertificate=True";

    public virtual DbSet<ClassUnit> ClassUnits { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(prod);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClassUnit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Class");

            entity.Property(e => e.Active).HasDefaultValue(true);

            entity.HasOne(d => d.Teacher).WithMany(p => p.ClassUnits)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Class_Teacher");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.Active).HasDefaultValue(true);

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Class");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.Property(e => e.Active).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
