
using Cronos.Data;
using Microsoft.Identity.Client;
using Cronos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FluentAssertions.Common;
using Cronos.Repositorio;
using Microsoft.OpenApi.Models;

namespace Cronos
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //Configura o contexto do banco de dados
           builder.Services.AddDbContext<BancoContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

            //  registra o repositório de funcionários
            builder.Services.AddScoped<IFuncionarioRepositorio, FuncionarioRepositorio>();



            builder.Services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cronos", Version ="v1" });
            });

          var app = builder.Build();



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
          
         
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cronos v1"));
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