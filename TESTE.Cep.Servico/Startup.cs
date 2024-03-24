using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TESTE.PesquisaClima.Aplicacao.Interfaces;
using TESTE.PesquisaClima.Dominio.Interfaces;
using System;
using Microsoft.OpenApi.Models;
using TESTE.PesquisaClima.Infra.Repositorios;
using TESTE.Cep.Aplicacao;

namespace TESTE.PesquisaClima.Servico
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
            services.AddSwaggerGen();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "TESTE WebServices",
                    Description = "API ecosistema para microserviço",
                    TermsOfService = new Uri("https://example.com/terms")
                });
            });

            services.AddTransient<IPesquisaClimaCidade, PesquisaClimaCidadeRepositorio>();
            services.AddTransient<Dominio.Interfaces.IPesquisaClimaAeroporto, PesquisaClimaAeroportoRepositorio>();
            services.AddTransient<IPesquisaClimaCidadeAplicacao, PesquisaClimaCidadeAplicacao>();
            services.AddTransient<Aplicacao.Interfaces.IPesquisaClimaAeroportoAplicacao, PesquisaClimaAeroportoAplicacao>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
   


            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
           
            });

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
