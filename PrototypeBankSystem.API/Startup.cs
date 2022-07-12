namespace PrototypeBankSystem.API
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
                var a = services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionDB));
                
                Console.WriteLine("Connection successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            services.AddControllers();
            services.AddScoped<IRepository<Client>, ClientRepository>();
            services.AddScoped<IRepository<ClientCard>, ClientCardRepository>();
            services.AddScoped<IRepository<Credit>, CreditRepository>();
            services.AddScoped<IRepository<Deposit>, DepositRepository>();
            services.AddScoped<IRepository<History>, HistoryRepository>();
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
