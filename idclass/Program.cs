using Cronos.Repositorio;
using idclass.Controllers;
using idclass.Data;
using Microsoft.EntityFrameworkCore;

namespace idclass
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<BancoContext>(options =>
                   options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

            builder.Services.AddScoped<IFuncionarioRepositorio, FuncionarioRepositorio>();

            var app = builder.Build();

            IServiceScope scope = app.Services.CreateScope();
            BancoContext funcionarioRepositorio = scope.ServiceProvider.GetRequiredService<BancoContext>();
            funcionarioRepositorio.Database.Migrate();

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
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}