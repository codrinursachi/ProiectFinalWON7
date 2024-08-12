using Microsoft.EntityFrameworkCore;
using ProiectFinalWON7.Models;

namespace ProiectFinalWON7.Data
{
    public class StudentRegistryDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public StudentRegistryDbContext(DbContextOptions<StudentRegistryDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
