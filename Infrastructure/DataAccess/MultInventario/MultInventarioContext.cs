using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using multitenant.Domain.Entities.MultInventario;

namespace multitenant.Infrastructure.DataAccess.MultInventario;

public partial class MultInventarioContext : DbContext
{
    public MultInventarioContext()
    {
    }

    public MultInventarioContext(DbContextOptions<MultInventarioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Products> Products { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MultInventario;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Products>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07304BF872");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
