using Microsoft.EntityFrameworkCore;
using SchoolAPI.Models;

namespace SchoolAPI.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students => Set<Student>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(s =>
            {
                s.HasKey(x => x.Id);
                s.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
                s.Property(x => x.LastName).HasMaxLength(100).IsRequired();
                s.Property(x => x.Email).HasMaxLength(255);
                s.Property(x => x.BirthDate);
            });
            
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FirstName = "Ada",
                    LastName = "Lovelace",
                    Email = "ada.lovelace@example.com",
                    BirthDate = new DateOnly(1815, 12, 10)
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Alan",
                    LastName = "Turing",
                    Email = "alan.turing@example.com",
                    BirthDate = new DateOnly(1912, 6, 23)
                },
                new Student
                {
                    Id = 3,
                    FirstName = "Grace",
                    LastName = "Hopper",
                    Email = "grace.hopper@example.com",
                    BirthDate = new DateOnly(1906, 12, 9)
                }
            );
        }
    }
}
