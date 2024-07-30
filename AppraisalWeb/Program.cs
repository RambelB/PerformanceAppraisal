using AppraisalDataAccess;
using AppraisalWeb.Configurations;
using Microsoft.AspNetCore.Authentication.Cookies;
namespace AppraisalWeb;

public class Program{
    public static void Main(string[] args){
        var builder = WebApplication.CreateBuilder(args);
        IServiceCollection services = builder.Services;
        services.AddControllersWithViews();
        Dependencies.ConfigureService(builder.Configuration, builder.Services);
        services.AddBussinessService();

        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(option => {
                option.Cookie.Name = "AuthCookie";
                option.LoginPath = "/Login";
                option.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                option.AccessDeniedPath = "/AccessDenied";
            });
        services.AddAuthorization();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

        var app = builder.Build();

        //// Configure the HTTP request pipeline.
        //if (!app.Environment.IsDevelopment())
        //{
        //    app.UseExceptionHandler("/Home/Error");
        //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        //    app.UseHsts();
        //}

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Auth}/{action=Index}"
        );
        app.UseStaticFiles();

        app.Run();
    }
}