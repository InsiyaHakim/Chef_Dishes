using Microsoft.EntityFrameworkCore;
 
namespace Chef_Dishes.Models
{
    public class MyContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        public DbSet<Chef> chef { get; set; }
        public DbSet<Dishes> dishes { get; set; }


    }
}