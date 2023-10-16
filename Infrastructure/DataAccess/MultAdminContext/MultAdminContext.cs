using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using multitenant.Domain.Entities.MultAdmin;

namespace multitenant.Infrastructure.DataAccess.MultAdminContext;

public partial class MultAdminContext : DbContext
{
    public MultAdminContext()
    {
    }

    public MultAdminContext(DbContextOptions<MultAdminContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Organizations> Organizations { get; set; }

    public virtual DbSet<Users> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MultAdmin;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Organizations>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Table__3214EC078479A232");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07332550BF");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Organization).WithMany(p => p.Users)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FK__Users__Organizat__4AB81AF0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
