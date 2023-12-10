using Autoservis01.DAL;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Autoservis01.Profiles;
using Microsoft.Extensions.DependencyInjection;
using Autoservis01.Models.DBEntities;

namespace Autoservis01
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
            services.AddMvc();
           

            services.AddAutoMapper(typeof(MappingProfiles));
            
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));

            // Dependency Injection for ProizvodacDbContext
            services.AddDbContext<ProizvodacDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Dependency Injection for ModelDbContext
            services.AddDbContext<ModelDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.Use(next => context =>
            {
                // Dodaj debug ispis zahtjeva
                Console.WriteLine($"Request: {context.Request.Path}");
                return next(context);
            });
          
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
