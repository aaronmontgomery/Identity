using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(options =>
            {
                options.EnableEndpointRouting = true;
            });
            services.AddDbContext<Entities.IdentityContext>(options =>
            {
                options.UseSqlServer("Server=localhost;Database=Identity;Trusted_Connection=True;");
            });
            services.AddIdentity<Entities.ApplicationUser, Entities.ApplicationRole>(options =>
            {

            }).AddEntityFrameworkStores<Entities.IdentityContext>();
            services.AddAuthentication(options =>
            {

            });
            services.AddAuthorization(options =>
            {

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseHealthChecks("/health");
            app.UseExceptionHandler("/error");
            app.UseHttpsRedirection();
            app.UseHsts();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
