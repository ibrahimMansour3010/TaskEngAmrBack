using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TaskEngAmr.Models;

namespace TaskEngAmr.Data.Access
{
    public class TaskContext:IdentityDbContext
    {
        public DbSet<Branch> Branch{ get; set; }
        public TaskContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
