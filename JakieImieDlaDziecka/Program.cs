using Autofac;
using DataAccess;
using DataAccess.Interfaces;
using StatisticsProcessor;
using StatisticsProcessor.Interfaces;
using StatisticsProcessor.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllersWithViews();
        var autofacbuilder = new ContainerBuilder();
        AutoFac.ConfigureContainer(autofacbuilder);
        autofacbuilder.Build();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();


        app.MapControllerRoute(
            name: "default",
            pattern: "{controller}/{action=Index}/{id?}");

        app.MapFallbackToFile("index.html"); ;

        app.Run();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddSingleton<INameService, NameService>();
        services.AddSingleton<INameRepository, NameRepository>();
        // Other service registrations
    }
}
