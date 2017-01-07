using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Weightlifting.Data.Repository;
using Weightlifting.Data.Service;
using Weightlifting.Models;

namespace Weightlifting
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var con = @"Server=(localdb)\mssqllocaldb;Database=Weightlifting;Trusted_Connection=True;";

            services.AddDbContext<WeightliftingContext>(options => options.UseSqlServer(con));            

            services.AddMvc();
            services.AddAutoMapper();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped(typeof(IWorkoutService), typeof(WorkoutService));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(RouteConfig.RegisterRoutes);
        }
    }
}
