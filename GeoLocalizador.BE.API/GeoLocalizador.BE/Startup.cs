using GeoLocalizador.BE.Dao;
using GeoLocalizador.BE.Infra;
using GeoLocalizador.BE.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace GeoLocalizador.BE
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("https://geolocalizador.z15.web.core.windows.net/");
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                });
            });
            #region [Db-Context]
                services.AddDbContext<GeoContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("DB_GeoLocalizador")));
                //Dao AddTransient
                services.AddTransient<GeoPositionDao>();
                services.AddTransient<HarborDao>();
                services.AddTransient<TruckGeoPositionDao>();
                services.AddTransient<TruckInfoDao>();
                services.AddTransient<UserDao>();
                services.AddTransient<VesselGeoPositionDao>();
                services.AddTransient<VesselInfoDao>();
                //Services AddTransient
                services.AddTransient<GeoPositionServices>();
                services.AddTransient<HarborServices>();
                services.AddTransient<TruckGeoPositionServices>();
                services.AddTransient<TruckInfoServices>();
                services.AddTransient<UserServices>();
                services.AddTransient<VesselGeoPositionServices>();
                services.AddTransient<VesselInfoServices>();
            #endregion


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GeoLocalizador.BE", Version = "v1" });
            });
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("Secret").Value);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GeoLocalizador.BE v1"));
            }
            app.UseCors(MyAllowSpecificOrigins);

            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthentication();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            

        }
    }
}
