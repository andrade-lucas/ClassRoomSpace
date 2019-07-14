using ClassRoomSpace.Domain.Repositories;
using ClassRoomSpace.Domain.Services;
using ClassRoomSpace.Infra.Context;
using ClassRoomSpace.Infra.Repositories;
using ClassRoomSpace.Infra.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ClassRoomSpace.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseResponseCompression();
            app.UseMvc();
        }
    }
}
