using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Persistence
{
    public class TestContext : DbContext
    {
        public TestContext()
        {

        }

        public TestContext(DbContextOptions<TestContext> options) :base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=US0PROD1082VA;Initial Catalog=CwpTest;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<UploadFile>().HasData(new UploadFile
            {
                Id = 1,
                Name = "test1",
                Status = 0
            },
            new UploadFile
            {
                Id = 2,
                Name = "test2",
                Status = 1
            },
            new UploadFile
            {
                Id = 3,
                Name = "test3",
                Status = 0
            });
        } 

        public DbSet<UploadFile> Files { get; set; }
    }
}
