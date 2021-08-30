using _1_App.Core.Domain.Abstracts.Context;
using _1_App.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace _3_1_App.Persistent.Dal.DataAccess
{

    public class MyDbContext : BaseDbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        //public IDbConnection Connection => Database.GetDbConnection();
        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<Department> Departments { get; set; }
        //public DbSet<Duty> Duties { get; set; }     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //if (Database.CanConnect()) return;

            modelBuilder.Entity<Employee>().Property(p => p.Id).HasColumnType("decimal(18,0)").UseIdentityColumn();
            modelBuilder.Entity<Employee>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Employee>().Property(p => p.Email).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Employee>().Property(p => p.DepartmentId).IsRequired().HasColumnType("decimal(18,0)");

            modelBuilder.Entity<Employee>()
                .HasMany(r => r.Duties)
                .WithOne(r => r.Employee)
                .HasForeignKey(f => f.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired()
                ;

            modelBuilder.Entity<Department>().Property(p => p.Id).HasColumnType("decimal(18,0)").UseIdentityColumn();
            modelBuilder.Entity<Department>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Department>().Property(p => p.Description).HasMaxLength(200);
            modelBuilder.Entity<Department>().Property(p => p.CreatedAt).HasMaxLength(20);

            modelBuilder.Entity<Department>()
                .HasMany(r => r.Employees)
                .WithOne(r => r.Department)
                .HasForeignKey(f => f.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired()
                ;

            modelBuilder.Entity<Duty>().Property(p => p.Id).HasColumnType("decimal(18,0)").UseIdentityColumn();
            modelBuilder.Entity<Duty>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Duty>().Property(p => p.EmployeeId).IsRequired().HasColumnType("decimal(18,0)");
            modelBuilder.Entity<Duty>().Property(p => p.Description).HasMaxLength(200);
            modelBuilder.Entity<Duty>().Property(p => p.CreatedAt).HasMaxLength(20);
            modelBuilder.Entity<Duty>().Property(p => p.Status).HasColumnType("tinyint").HasMaxLength(1);

        }

    }
}
