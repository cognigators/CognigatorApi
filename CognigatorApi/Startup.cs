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
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;

namespace CognigatorApi
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
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder => {
                                      builder.AllowAnyOrigin()
                                              .AllowAnyMethod()
                                              .AllowAnyHeader();
                                  });
            });
            //services.AddControllers()
            //         .AddJsonOptions(options =>
            //         {
            //             options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            //             options.JsonSerializerOptions.PropertyNamingPolicy = null;
            //             options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            //         });
            //services.AddControllers()
            //        .AddNewtonsoftJson(options =>
            //        {
            //            var settings = options.SerializerSettings;

            //            settings.Converters.Add(new StringEnumConverter { NamingStrategy = new CamelCaseNamingStrategy() });
            //            settings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            //            settings.Formatting = Formatting.Indented;
            //            settings.NullValueHandling = NullValueHandling.Ignore;

            //        });
            services.AddMvc()
            .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.WriteIndented = true;
    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


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
