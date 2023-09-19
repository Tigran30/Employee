using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Employee.Database.Entities;

namespace Employee.Database
{
    public partial class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
        {
        }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Database.Entities.Employee> Employees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Database.Entities.Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasIndex(e => e.FirstName, "IX_Employee_FirstName");

                entity.HasIndex(e => e.Gender, "IX_Employee_Gendeer");

                entity.HasIndex(e => e.LastName, "IX_Employee_LastName");

                entity.Property(e => e.Address1).HasMaxLength(200);

                entity.Property(e => e.Address2).HasMaxLength(100);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(30);

                entity.Property(e => e.Postal)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
