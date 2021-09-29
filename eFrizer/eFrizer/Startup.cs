using eFrizer.Database;
using eFrizer.Model;
using eFrizer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


namespace eFrizer
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

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "eFrizer", Version = "v1" });
            });

            services.AddDbContext<eFrizerContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IHairSalonService, Services.HairSalonService>();

            services.AddScoped<ICityService, Services.CityService>();
            services.AddScoped<ICRUDService<Model.HairSalonType, object, HairSalonTypeInsertRequest, object>, Services.HairSalonTypeService>();
            services.AddScoped<ICRUDService<Model.HairSalonHairSalonType, object, HairSalonHairSalonTypeInsertRequest, object>, Services.HairSalonHairSalonTypeService>();
            services.AddScoped<ICRUDService<Model.ApplicationUser, object, ApplicationUserInsertRequest, object>, Services.ApplicationUserService>();
            services.AddScoped<IHairDresserService, Services.HairDresserService>();
            //TODO: create interfaces for each of these scoped ICRUDServices to make Startup clean
            services.AddScoped<ICRUDService<Model.Role, RoleSearchRequest, RoleInsertRequest, RoleUpdateRequest>, Services.RoleService>();
            services.AddScoped<ICRUDService<Model.ApplicationUserRole, object, ApplicationUserRoleInsertRequest, object>, Services.ApplicationUserRoleService>();

            services.AddScoped<IReviewService, Services.ReviewService>();
            services.AddScoped<IServiceService, Services.ServiceService>();
            services.AddScoped<IReservationService, Services.ReservationService>();
            services.AddScoped<ICRUDService<Model.HairSalonService, object, HairSalonServiceInsertRequest, object>, Services.HairSalonServiceService>();

            services.AddScoped<ICRUDService<Model.Picture, object, PictureInsertRequest, PictureUpdateRequest>, Services.PictureService>();
            services.AddScoped<IHairSalonPictureService, Services.HairSalonPictureService>();

            services.AddScoped<SetupService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "eFrizer v1"));
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
