using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public AppDbContext  _dbCOntext { get; set; }

        public IndexModel(ILogger<IndexModel> logger, AppDbContext dbCOntext)
        {
            _logger = logger;
            _dbCOntext = dbCOntext;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            var emailAddresssq = Request.Form["email"];
            string emailtext = emailAddresssq.ToString().Trim();
            var user = _dbCOntext.Watchers.Where(e => e.Email == emailtext).FirstOrDefault();

            if (user == null)
            {
                _dbCOntext.Watchers.Add(new Watcher() { Email = emailtext });
                _dbCOntext.SaveChanges();
            }


            // do something with emailAddress
        }
    }
}