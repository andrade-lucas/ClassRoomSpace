using System;
using ClassRoomSpace.Api.Configurations;
using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Domain.Services;
using ClassRoomSpace.Infra.Context;
using ClassRoomSpace.Infra.Repositories;
using ClassRoomSpace.Infra.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ClassRoomSpace.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddResponseCompression();
            services.AddMvc();

            services.AddScoped<IDB, MsSqlDb>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IBlockRepository, BlockRepository>();
            services.AddTransient<ICollegeRepository, CollegeRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<IProfessorRepository, ProfessorRepository>();
            services.AddTransient<IClassRoomRepository, ClassRoomRepository>();
            services.AddTransient<IEquipmentRepository, EquipmentRepository>();
            
            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);
            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                Configuration.GetSection("TokenConfigurations")
            ).Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);

            services.AddAuthentication(authOptions => {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions => {
                var paramValidations = bearerOptions.TokenValidationParameters;
                paramValidations.IssuerSigningKey = signingConfigurations.Key;
                paramValidations.ValidAudience = tokenConfigurations.Audience;
                paramValidations.ValidIssuer = tokenConfigurations.Issuer;

                // Valida a assinatura de um token recebido.
                paramValidations.ValidateIssuerSigningKey = true;

                paramValidations.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCors(x => {
                x.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .AllowAnyOrigin();
            });
            app.UseResponseCompression();
            app.UseMvc();
        }
    }
}
