using Insurify.Application;
using Insurify.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Insurify.MVC;

public class Program
{
    private const string ConnectionStringName = "DefaultConnection";

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
           
        var connectionString =
            builder.Configuration.GetConnectionString(ConnectionStringName) ??
            throw new ArgumentException($"Connection string {ConnectionStringName} is missing");

        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(connectionString);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if(!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
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