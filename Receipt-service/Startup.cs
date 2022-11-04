using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Receipt_service.Core.Interfaces;
using Receipt_service.Core.Models;
using Receipt_service.Core.Validations.Item;
using Receipt_service.Core.Validations.Receipt;
using Receipt_service.Data;
using Receipt_service.Services;

namespace Receipt_service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Receipt_service", Version = "v1" });
            });

            services.AddDbContext<ReceiptServiceDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Receipt-service"));
            });

            services.AddScoped<IReceiptServiceDbContext, ReceiptServiceDbContext>();
            services.AddScoped<IDbService, DbService>();
            services.AddScoped<IEntityService<Receipt>, EntityService<Receipt>>();
            services.AddScoped<IEntityService<Item>, EntityService<Item>>();
            services.AddScoped<IReceiptService, ReceiptService>();
            services.AddScoped<IReceiptValidator, ReceiptItemsValidator>();
            services.AddScoped<IItemValidator, ItemProductNameValidator>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowCredentials().AllowAnyMethod();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Receipt_service v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowCredentials().AllowAnyMethod();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
