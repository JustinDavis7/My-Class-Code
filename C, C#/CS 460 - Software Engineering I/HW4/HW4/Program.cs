namespace HW4;
using HW4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HW4.DAL.Abstract;
using HW4.DAL.Concrete;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<ToDoDbContext>(
            options => options
                        .UseLazyLoadingProxies()    // Will use lazy loading, but not in LINQPad as it doesn't run Program.cs
                        .UseSqlServer(builder.Configuration.GetConnectionString("ToDoConnection"))               
        );
        builder.Services.AddScoped<DbContext, ToDoDbContext>(); // Need this line since our generic repository is based on DbContext directly
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));    // Easy way to register all the generic repositories 
        builder.Services.AddScoped<IPersonRepository, PersonRepository>();
        builder.Services.AddScoped<IToDoItemRepository, ToDoRepository>();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "Items",
            pattern: "user/{id}",
            defaults: new {controller = "Home", action = "User"});

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}