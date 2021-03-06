using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PetShop.Core.ApplicationService;
using PetShop.Core.Domain;
using PetShop.Core.Entity;

namespace PetShop.WebApi
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
            services.AddScoped<IPetShopRepository, PetShopRepository>();
            services.AddScoped<IPetShopService, PetShopService>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IPetTypeRepository, PetTypeRepository>();
            services.AddScoped<IPetTypeService, PetTypeService>();
            services.AddControllers().AddNewtonsoftJson(option =>
            {
                option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var repo = scope.ServiceProvider.GetService<IPetShopRepository>();
                    repo.AddPet(new Pet()
                    {
                        Name = "Rex",
                        Type = new Pettype(){Id = 1},
                        BirthDate = DateTime.Now.AddYears(-3),
                        SoldDate = DateTime.Now.AddYears(-2),
                        Color = "Black",
                        Price = 3000
                    });
                    repo.AddPet(new Pet()
                    {
                        Name = "Rox",
                        Type = new Pettype() { Id = 1 },
                        BirthDate = DateTime.Now.AddYears(-3),
                        SoldDate = DateTime.Now.AddYears(-2),
                        Color = "Black",
                        Price = 3000
                    });
                    repo.AddPet(new Pet()
                    {
                        Name = "Lola",
                        Type = new Pettype() { Id = 2 },
                        BirthDate = DateTime.Now.AddYears(-3),
                        SoldDate = DateTime.Now.AddYears(-2),
                        Color = "Black",
                        Price = 3000
                    });

                    var repo2 = scope.ServiceProvider.GetService<IOwnerRepository>();
                    repo2.AddOwner(new Owner()
                    {
                        Name = "Ben",
                        OwnedPet = new Pet() {Id = 2}

                    });
                    repo2.AddOwner(new Owner()
                    {
                        Name = "Mort",
                        OwnedPet = new Pet(){Id = 1}
                    });
                    var repo3 = scope.ServiceProvider.GetService<IPetTypeRepository>();
                    repo3.AddType(new Pettype()
                    {
                        TypeName = "Dog"
                    });
                    repo3.AddType(new Pettype()
                    {
                        TypeName = "Hamster"
                    });
                }
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
