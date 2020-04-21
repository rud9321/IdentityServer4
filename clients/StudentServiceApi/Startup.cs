using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace StudentServiceApi
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
            ConfigureIdentityServices4(services);
            services.AddCors(options => setCorsOptions(options));
        }

        private void setCorsOptions(CorsOptions options)
        {
            options.AddPolicy("default", policy => {
                policy.AllowAnyOrigin().//("https://localhost:3801").
                AllowAnyHeader().
                AllowAnyMethod();
            });
        }

        private void ConfigureIdentityServices4(IServiceCollection services)
        {
            var builder = services.AddAuthentication(options => setAuthenticationOptions(options));
            builder.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => setJwtBearerOption(options));
        }

        private void setJwtBearerOption(JwtBearerOptions options)
        {
            options.Authority = "http://localhost:5000";
            options.RequireHttpsMetadata = false;
            options.Audience = "testApi";
        }

        private void setAuthenticationOptions(AuthenticationOptions options)
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
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
            app.UseCors("default");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
