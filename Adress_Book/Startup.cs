using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Address_Book_Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using AutoMapper;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using Address_Book_Service;
using Address_Book_Service.Interfaces;

namespace Adress_Book
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
            var connectionString = Configuration.GetConnectionString("ContactDatabase");
            services.AddDbContext<AddressBookEntites>(x => x.UseSqlServer(connectionString));
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IContactTypeService, ContactTypeService>();
            services.AddScoped<IContactDetailService, ContactDetailsService>();
            services.AddCors(builder => { builder.AddPolicy("AllowOrigin", x => x.WithOrigins("http://localhost:4200")); });
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Address Book API", Version = "v1" });
               

            }
            );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(options => options.WithOrigins("http://localhost:4200"));
            app.UseAuthorization();
                    app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "My API V1");
            });
          
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
