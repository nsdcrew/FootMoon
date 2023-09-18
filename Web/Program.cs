using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using Web;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using Web.Resources;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
builder.Services.AddMvc();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer("Data Source=SQL5106.site4now.net;Initial Catalog=db_a55653_footmoon;User Id=db_a55653_footmoon_admin;Password=Tigrou7030!");
});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<CultureInfo>
    {
        new CultureInfo("en-US"), // English
        new CultureInfo("fr-FR"), // French
        new CultureInfo("es-ES")  // Spanish
    };
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;



});

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowSpecificOrigin",
//               builder => 
//               builder.WithOrigins("https://backaflipa.vhx.tv") // Replace with the actual origin(s) that should be allowed
//               //builder.AllowAnyOrigin()
//                   .AllowAnyMethod()
//                   .AllowAnyHeader()
//                   .AllowCredentials()
//                   )
//    ;
//});

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.SetMinimumLevel(LogLevel.Information); // Adjust the minimum level as needed
    loggingBuilder.AddDebug();

});



builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddTransient<SharedViewLocalizer>();



builder.Services.AddControllersWithViews()
    .AddViewLocalization
    (LanguageViewLocationExpanderFormat.SubFolder)
    .AddDataAnnotationsLocalization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.Use(async (context, next) =>
//{
//    context.Request.Host = new HostString("localhost"); // Replace with your actual host if needed

//    await next();
//});

//app.MapControllers();




app.UseHttpsRedirection();
app.UseStaticFiles();

/*app.UseCors("AllowSpecificOrigin");*/ // Use the policy name defined earlier

// 4. 
var supportedCultures = new[] { "en-US", "fr-FR", "es-ES" };
// 5. 
// Culture from the HttpRequest
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();




app.Run();
