using Microsoft.EntityFrameworkCore;
using RESTApiTestApp.Models;

namespace RESTApiTestApp.Data
{
    public class TestAppDbContext : DbContext
    {
        public TestAppDbContext(DbContextOptions<TestAppDbContext> options)
            : base(options) 
        {
        }

        public DbSet<TestAppModel> TestAppModels { get; set; }
    }
}
