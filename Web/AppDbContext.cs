using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Web
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
         : base(options)
        {
        }

        public DbSet<Watcher> Watchers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);



        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            if (!optionsBuilder.IsConfigured)
            {
                //string AppSettingsFileName = "appsettings.json";



                optionsBuilder.UseSqlServer("Data Source=SQL5106.site4now.net;Initial Catalog=db_a55653_footmoon;User Id=db_a55653_footmoon_admin;Password=Tigrou7030!",
    x => x.MigrationsAssembly("Web"));


            }
        }

    }

    public class Watcher
    {

        public int Id { get; set; }

        public string Email { get; set; }

        public bool EmailSent1 { get; set; }



        public bool EmailSent2 { get; set; }

        public bool EmailSent3 { get; set; }

        public bool EmailSent4 { get; set; }

        public bool EmailSent5 { get; set;}



    }

}
