using AutoMapper;
using DesafioWebMotors.Application.Interfaces;
using DesafioWebMotors.Application.Servicos;
using DesafioWebMotors.Dominio.Interfaces;
using DesafioWebMotors.Infra.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioWebMotors.Web
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
            services.AddMvc();
            services.AddAutoMapper();

            services.AddScoped<IMapper>(a => new Mapper(a.GetRequiredService<AutoMapper.IConfigurationProvider>(), a.GetService));
            services.AddSingleton(Mapper.Configuration);

            services.AddScoped<IServicoAnuncio, ServicoAnuncio>();
            services.AddScoped<IAnuncioRepositorio, AnuncioRepositorio>();

            services.AddScoped<Contexto>();

            services.AddScoped<IServicoApi>(s => new ServicoApi(Configuration.GetSection("UrlWebApi").Value));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Anuncio}/{action=Index}/{id?}");
            });

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
        }
    }
}
