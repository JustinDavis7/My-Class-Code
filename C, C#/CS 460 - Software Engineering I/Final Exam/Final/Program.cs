using Microsoft.EntityFrameworkCore;
using Final.Models;
using Final.DAL;
using Microsoft.AspNetCore.StaticFiles;

namespace Final;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        var connectionString = builder.Configuration.GetConnectionString("WorldCupConnection");
        builder.Services.AddDbContext<WCDbContext>(options => options
                                .UseLazyLoadingProxies()
                                .UseSqlServer(connectionString));
        builder.Services.AddScoped<DbContext, WCDbContext>();
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddScoped<ICountryRepository, CountryRepository>();
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        builder.Services.AddSwaggerGen();
        // By default .net core won't serve a .avif image, so enable it with this
        // see: https://stackoverflow.com/questions/61119625/net-core-web-api-static-file-images-not-loading-properly
        builder.Services.Configure<StaticFileOptions>(o =>
        {
            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings.Add(".avif", "image/avif");
            o.ContentTypeProvider = provider;
        });

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
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
        name: "Country",
        pattern: "country/{countryAbbreviation}",
        defaults: new {controller = "Country", action = "Index"});

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}