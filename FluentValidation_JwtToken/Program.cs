using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation_JwtToken.Db;
using FluentValidation_JwtToken.Service;
using FluentValidation_JwtToken.Validator;
using Microsoft.EntityFrameworkCore;

namespace FluentValidation_JwtToken
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            builder.Services.AddControllersWithViews();

            builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<FilmeValidator>());
            builder.Services.AddDbContext<ContextDb>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddTransient<FilmeValidator>();
            builder.Services.AddScoped<IFilme, FilmeService>();

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
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
