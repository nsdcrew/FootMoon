using Microsoft.EntityFrameworkCore;
using System;
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
