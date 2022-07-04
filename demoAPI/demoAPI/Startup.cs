using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using demoAPI.Hubs;
using demoAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MySqlConnector;

namespace demoAPI
{

    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name:MyAllowSpecificOrigins,
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod() );
            });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownProxies.Add(IPAddress.Parse("localhost"));
            });
            services.AddSignalR(hubOptions =>
            {
                hubOptions.EnableDetailedErrors = true;
                hubOptions.KeepAliveInterval = TimeSpan.FromMinutes(1);
                hubOptions.HandshakeTimeout = TimeSpan.FromMinutes(5);
            });
            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Alarm Iot Project", Version = "v1"}); });
            services.AddTransient<AppDb>(_ => new AppDb(Configuration["ConnectionStrings:DefaultConnection"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {   
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "demoAPI v1"));
            }
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
           
            // app.UseWebSockets();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseMiddleware<AuthenMiddleWare>();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SendData>("/hubSocket");
            });
            

        }
    }
}
