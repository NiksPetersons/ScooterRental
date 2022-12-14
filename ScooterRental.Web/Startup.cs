using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ScooterRental.Core.CalculatorModels;
using ScooterRental.Core.Interfaces;
using ScooterRental.Core.ScooterValidations;
using ScooterRental.DB;
using ScooterRental.Services;
using ScooterRental.Web.AutoMapper;

namespace ScooterRental.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            using (var client = new ScooterDbContext())
            {
                client.Database.EnsureCreated();
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ScooterRental.Web", Version = "v1" });
            });

            services.AddEntityFrameworkSqlite().AddDbContext<ScooterDbContext>();

            services.AddScoped<IScooterDbContext, ScooterDbContext>();
            services.AddScoped<IDbService, DbService>();
            services.AddScoped<IRentalService, RentalService>();
            services.AddScoped<IRentalFeeCalculator, RentalFeeCalculator>();
            services.AddScoped<IIncomeReportCalculator, IncomeReportCalculator>();
            services.AddScoped<IIncomeReportService, IncomeReportService>();
            //mapper
            services.AddSingleton(AutoMapperConfig.CreateMapper());
            //validators
            services.AddScoped<IScooterValidator, ScooterPriceValidator>();
            services.AddScoped<IScooterValidator, ScooterIsRentedValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ScooterRental.Web v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
