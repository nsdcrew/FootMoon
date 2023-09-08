using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
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
        //public DbSet<VimeoWebhookUser> VimeoWebhookUsers { get; set; }
        //public DbSet<VimeoWebhookVideo> VimeoWebhookVideos { get; set; }
        //public DbSet<VimeoWebhookData> VimeoWebhookDatas { get; set; }

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




    public class VimeoWebhookData
    {
        [Key]
        public int Id { get; set; }

        public string Type { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Action { get; set; }
        public string UserUri { get; set; }

        // Navigation properties
        public VimeoWebhookVideo Video { get; set; }
        public VimeoWebhookUser User { get; set; }

        // Include a dictionary for additional properties not known at compile time
        [NotMapped]
        public Dictionary<string, string> AdditionalData { get; set; }
    }

    public class VimeoWebhookVideo
    {
        [Key]
        public int Id { get; set; }

        public string Uri { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Type { get; set; }

        // Navigation property to related webhook data
        public VimeoWebhookData WebhookData { get; set; }
    }

    public class VimeoWebhookUser
    {
        [Key]
        public int Id { get; set; }

        public string Uri { get; set; }
        public string Name { get; set; }

        // Navigation property to related webhook data
        public VimeoWebhookData WebhookData { get; set; }
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
