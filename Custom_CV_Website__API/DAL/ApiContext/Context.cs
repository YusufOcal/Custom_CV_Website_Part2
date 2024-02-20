using Custom_CV_Website__API.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace Custom_CV_Website__API.DAL.ApiContext
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=YUSUFUNKE\\SQLEXPRESS; Database=CVWebsiteDBApi; Integrated Security=True");
        }
        public DbSet<Category> Categories { get; set; }
    }
}
