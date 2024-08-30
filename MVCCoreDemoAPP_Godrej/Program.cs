using ADOLibrary;
using MVCCoreDemoAPP_Godrej.Models;
using System.ComponentModel.Design;




using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace MVCCoreDemoAPP_Godrej
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //

            builder.Services.AddSession(); //add sesssion service

            builder.Services.AddSingleton<ISingletonService, OperationService>();

            builder.Services.AddScoped<IScopedService, OperationService>();

            builder.Services.AddTransient<ITransientService, OperationService>();

            string connstr = builder.Configuration.GetConnectionString("DBConnection");
           
            builder.Services.AddScoped<EmployeeDataStore>( _ => new EmployeeDataStore(connstr));

            builder.Services.AddDbContext<TrainingDbContext>(options =>
            {
                options.UseSqlServer(connstr);
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseSession();   //add session service in request pipeline

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
