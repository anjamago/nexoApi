using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

using Microsoft.OpenApi.Models;
using Nexos.BusinessRules;
using Nexos.Repositories;


namespace nexos.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_localhost";
        public IWebHostEnvironment Env { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc()
               .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
               .AddNewtonsoftJson(opts =>
                   opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                builder =>
                                {
                                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                                });
            });

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Editorial",
                    Version = "v1",
                    Description = "REST API  para la  Aplicacion Editorial",
                    Contact = new OpenApiContact()
                    {
                        Name = "Andy Martinez",
                        Email = "anjamago@gmail.com"
                    }

                });
            });

            services.AddBusiness();
            services.AddRepositories(Configuration, Env.IsDevelopment());

        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

           
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "REST API  para la  Aplicacion Editorial");
            });

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
