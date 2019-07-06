using AppAdapter;
using AppComosDBImpl.Implementation;
using AppDBAdapter;
using AppServiceBusAdapter;
using BusinessLogic;
using BusinessLogic.Interfaces;
using CommonModels;
using DomainModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TodoWebAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<GlobalFilter.LogTransactionFilter>();
            services.AddTransient<ILogServiceAdapter, LogServiceTransaction>();

            // Add BusinessLogic related Injections
            ConfigureBLInjections(services);

            // Add CRUD DB related injections
            ConfigureCRUDDBInjections(services);

            // Add our Config object so it can be injected
            services.Configure<CosmosDBConfig>(Configuration.GetSection("CosmosConnectionString"));
        }

        private void ConfigureCRUDDBInjections(IServiceCollection services)
        {
            services.AddTransient<IQueryDB<ToDo>, ToDoDBAdapter>();
        }

        private void ConfigureBLInjections(IServiceCollection services)
        {
            services.AddTransient<ICRUDBL<ToDo>, ToDoBL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
