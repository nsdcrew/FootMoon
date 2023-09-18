using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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

        public void OnGet(string culture = "")
        {

            if (culture == "")
            {
                var cookieValue = Request.Cookies[CookieRequestCultureProvider.DefaultCookieName];

                if (!string.IsNullOrEmpty(cookieValue))
                {
                    var cookieCulture = CookieRequestCultureProvider.ParseCookieValue(cookieValue);

                    if (cookieCulture != null && CultureInfo.GetCultures(CultureTypes.AllCultures)
                        .Any(c => c.Name == cookieCulture.Cultures[0].Value))
                    {
                        // Set the culture for the current request based on the cookie value
                        CultureInfo.CurrentCulture = new CultureInfo(cookieCulture.Cultures[0].Value);
                        CultureInfo.CurrentUICulture = new CultureInfo(cookieCulture.Cultures[0].Value);
                    }
                }

                // If the culture is not found in the cookie or not supported, set a default culture
                if (CultureInfo.CurrentCulture == null)
                {
                    CultureInfo.CurrentCulture = new CultureInfo("en-US");
                    CultureInfo.CurrentUICulture = new CultureInfo("en-US");
                }
            }
            else
            {

                Response.Cookies.Append(
                  CookieRequestCultureProvider.DefaultCookieName,
                  CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                  new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
              );

                // Set the culture for the current request
                if (CultureInfo.CurrentCulture == null)
                {
                    CultureInfo.CurrentCulture = new CultureInfo("en-US");
                    CultureInfo.CurrentUICulture = new CultureInfo("en-US");
                }

            }
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