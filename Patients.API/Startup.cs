using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Patients.API.Contexts;
using Patients.API.Services;
using Patients.API.Utilities;

namespace Patients.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<PatientDBContext>(o =>
            {
                o.UseInMemoryDatabase("Patient");
            });
            services.AddScoped<IPatientRepository, PatientRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, PatientDBContext patientDBContext)
        {
            app.UseMvc();
            LoadPatientData.LoadPatientContextData(patientDBContext);
        }
    }
}
