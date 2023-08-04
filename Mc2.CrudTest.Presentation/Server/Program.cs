using Mc2.CrudTest.DomainService;
using Mc2.CrudTest.Persistence;
using Microsoft.AspNetCore.ResponseCompression;

namespace Mc2.CrudTest.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // builder.Services.AddControllersWithViews();
            // builder.Services.AddRazorPages();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();
            ConfigureServices(builder);
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.ConfigurePersistenceServices(builder.Configuration);
            builder.Services.ConfigureDomainServiceServices();
        }

    }
}