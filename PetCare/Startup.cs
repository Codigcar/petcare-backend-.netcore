using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PetCare.Domain.Models;
using PetCare.Domain.Repositories;
using PetCare.Domain.Services;
using PetCare.Persistence.Context;
using PetCare.Persistence.Repositories;
using PetCare.Resources;
using PetCare.Services;

namespace PetCare
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

            services.AddDbContext<AppDbContext>(opt =>
            opt.UseMySQL(Configuration.GetConnectionString("DefaultConnection"))
          );

            
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IProviderService, ProviderService>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPetRepository, PetRepository>();


            services.AddScoped<ISuscriptionPlanRepository, SuscriptionPlanRepository>();
            services.AddScoped<ISuscriptionPlanService, SuscriptionPlanService>();

            services.AddScoped<IProviderJoinServiceRepository, ProviderJoinServiceRepository>();
            services.AddScoped<IProviderJoinServiceS, ProviderJoinServiceS>();

            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IServiceS, ServiceS>();

            services.AddScoped<IServiTypeRepository, ServiTypeRepository>();
            services.AddScoped<IServiTypeService, ServiTypeService>();

            services.AddScoped<IProviderRepresentativeRepository, ProviderRepresentativeRepository>();
            services.AddScoped<IProviderRepresentativeService, ProviderRepresentativeService>();

            services.AddScoped<IMedicalProfileService, MedicalProfileService>();
            services.AddScoped<IMedicalProfileRepository, MedicalProfileRepository>();

            services.AddScoped<IUnitOfWork, unitOfWork>();
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

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

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            }
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
