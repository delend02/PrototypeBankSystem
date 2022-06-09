using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrototypeBankSystem.Persistence.DataBase;
using PrototypeBankSystem.Persistence.Middleware;

namespace PrototypeBankSystem.Persistenc
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
            try
            {
                var section = Configuration.GetSection("ConnectionString");
                var connectionDB = section.GetSection("DefaultConnectionMSSQLDatabase").Value;
                services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionDB));
                
                Console.WriteLine("Connection successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMiddleware<AuthenticationMiddleware>();
        }

    }
}
