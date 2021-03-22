using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExternalConnections;
using IRepositories;
using IServices;
using Manager;
using Manager.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Repositories;
using Services;

namespace BoilerPlateCRUD
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
            //Configure Autofac Services
            ConfigureAutofacServices(services);
            ConfigureRepos(services);
            ConfigureManagers(services);
            ConfigureDBs(services);
            //services.AddScoped<IsAdminFilter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
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
        }
        public void ConfigureAutofacServices(IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IPersonalInfoService, PersonalInfoService>();
            services.AddTransient<ISignOnService, SignOnService>();
        }

        public void ConfigureRepos(IServiceCollection services)
        {
            services.AddTransient<IAccountRepo, AccountRepo>();
            services.AddTransient<IPersonalInfoRepo, PersonalInfoRepo>();
            services.AddTransient<ISignOnRepo,SignOnRepo>();
        }

        public void ConfigureManagers(IServiceCollection services)
        {
            services.AddTransient<ISignManager,SignManager>();
            services.AddTransient<IAccountManager,AccountManager> ();
            services.AddTransient<IPersonalInfoManager, PersonalManager>();
        }

        public void ConfigureDBs(IServiceCollection services)
        {
            services.AddScoped((x) => new SqlServerConnectionProvider(Configuration.GetConnectionString("BoilerplateDB")));
        }
    }
}
