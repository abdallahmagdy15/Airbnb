using Airbnb.Data;
using Airbnb.Models;
using Airbnb.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication;
using Stripe;


namespace Airbnb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseLazyLoadingProxies()
                    .UseSqlServer(
                        Configuration.GetConnectionString("DefaultConnection"),
                        x => x.UseNetTopologySuite()));
            services.AddMemoryCache();
            services.AddSession();

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<AppUser, IdentityRole>(options =>
           {
               options.SignIn.RequireConfirmedAccount = false;
               options.Password.RequiredLength = 8;
               options.Password.RequireLowercase = false;
               options.Password.RequireUppercase = false;
           }).AddEntityFrameworkStores<ApplicationDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Home/Index";
            });

            services.AddControllersWithViews();
            services.AddRazorPages();


            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = "510487169069-5lklvod6ve9it74tdf48kt6336dbiumt.apps.googleusercontent.com";
                    options.ClientSecret = "ixPPMW0IFZF-aSf8GKM92-Kh";
                })
                .AddFacebook(options =>
                {
                    options.AppId = "1417682328592643";
                    options.AppSecret = "0a46289db8d433907f64d6516882ba94";
                });

            
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<ISearchService, PropertySearchService>();
            services.AddScoped<IAdminServices, AdminServices>();

        }

      
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}