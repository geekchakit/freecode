using freecode.Models;
using Microsoft.EntityFrameworkCore;


namespace freecode.Data;

    public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ): base(options)
    {
    }

     public DbSet<Category> Categorys{ get; set; }
}

