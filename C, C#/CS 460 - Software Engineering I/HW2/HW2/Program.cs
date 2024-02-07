using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HW2.Models;
using HW2.DAL.Abstract;
using HW2.DAL.Concrete;

namespace HW2;

// Here is my initial Program.cs, that shows you how to:
//   - register the DBContext subclass into the dependency injection container
//   - enable Lazy Loading of related entities in Entity Framework Core
//   - register a repository into the dependency injection container
//   - enable developer exception pages that only run during development (not when deployed)

public class Program
{
    public static void Main(string[] args)
    {
        // adds the following logging providers: Console, Debug, EventSource, EventLog (https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-6.0)
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        var connectionString = builder.Configuration.GetConnectionString("StreamingDatabaseConnection");
        builder.Services.AddDbContext<StreamingDatabaseDbContext>(options => options
                                    .UseLazyLoadingProxies()    // Will use lazy loading, but not in LINQPad as it doesn't run Program.cs
                                    .UseSqlServer(connectionString));
        //builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        builder.Services.AddScoped<IShowRepository, ShowRepository>();  // Register our types with the dependency injection container
        builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();
        builder.Services.AddScoped<IGenreRepository, GenreRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        else
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}