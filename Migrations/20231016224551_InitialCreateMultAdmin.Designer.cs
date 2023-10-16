﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using multitenant.Infrastructure.DataAccess.MultAdminContext;

#nullable disable

namespace multitenant.Migrations
{
    [DbContext(typeof(MultAdminContext))]
    [Migration("20231016224551_InitialCreateMultAdmin")]
    partial class InitialCreateMultAdmin
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("multitenant.Domain.Entities.MultAdmin.Organizations", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("slugtenant")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK__Table__3214EC078479A232");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("multitenant.Domain.Entities.MultAdmin.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Estado")
                        .HasColumnType("bit");

                    b.Property<Guid?>("OrganizationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK__tmp_ms_x__3214EC07332550BF");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("multitenant.Domain.Entities.MultAdmin.Users", b =>
                {
                    b.HasOne("multitenant.Domain.Entities.MultAdmin.Organizations", "Organization")
                        .WithMany("Users")
                        .HasForeignKey("OrganizationId")
                        .HasConstraintName("FK__Users__Organizat__4AB81AF0");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("multitenant.Domain.Entities.MultAdmin.Organizations", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
