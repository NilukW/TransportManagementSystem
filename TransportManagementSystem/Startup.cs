using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Data;
using TransportManagementSystem.Services;

namespace TransportManagementSystem
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
            services.AddControllers();
            services.AddSwaggerGen();

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerService, CustomerService>();
            
            services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();

            services.AddTransient<ITokenRepository, TokenRepository>();
            services.AddTransient<ITokenPaymentRepository, TokenPaymentRepository>();
            services.AddTransient<ITokenService, TokenService>();

            services.AddTransient<IBusRepository, BusRepository>();
            services.AddTransient<IBusService, BusService>();

            services.AddSingleton<UserProducer>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IDriverRepository, DriverRepository>();
            services.AddTransient<IDriverService, DriverService>();

            services.AddTransient<IPassengerService, PassengerService>();
            services.AddTransient<IInspectorService, InspectorService>();

            services.AddTransient<IReservationRepository, ReservationRepository>();
            services.AddTransient<IReservationService, ReservationService>();

            services.AddTransient<IRouteRepository, RouteRepository>();
            services.AddTransient<IRouteService, RouteService>();

            services.AddTransient<IScheduleRepository, ScheduleRepository>();
            services.AddTransient<IScheduleService, ScheduleService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Transport Management System V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
