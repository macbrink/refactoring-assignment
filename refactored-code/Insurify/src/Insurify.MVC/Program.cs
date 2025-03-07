using Insurify.MVC.Extensions; // leave this if you want to use app.SeedData()
using Insurify.Application;
using Insurify.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Insurify.MVC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if(!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();

        }
        else
        {
            app.UseDeveloperExceptionPage();
            app.ApplyMigrations();

            // Uncomment this to seed the database with some data.
            // app.SeedData();
        }


        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }
}