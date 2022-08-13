using CaseStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Context
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }



        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers{ get; set; }
        public DbSet<ClassRoom> ClassRooms  { get; set; }

    }
}
