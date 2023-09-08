using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
builder.Services.AddMvc();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer("Data Source=SQL5106.site4now.net;Initial Catalog=db_a55653_footmoon;User Id=db_a55653_footmoon_admin;Password=Tigrou7030!");
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
               builder => 
               builder.WithOrigins("https://backaflipa.vhx.tv") // Replace with the actual origin(s) that should be allowed
               //builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials()
                   )
    ;
});

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.SetMinimumLevel(LogLevel.Information); // Adjust the minimum level as needed
    loggingBuilder.AddDebug();

});


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

app.UseCors("AllowSpecificOrigin"); // Use the policy name defined earlier


app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
