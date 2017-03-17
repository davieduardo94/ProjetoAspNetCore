using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication1.Controllers;
using Microsoft.Extensions.Configuration;
using WebApplication1.Services;

namespace WebApplication1
{
    public class Startup
    {
        private IHostingEnvironment env;
        private IConfigurationRoot config; // variavel para armazenar as configurações

        public Startup(IHostingEnvironment env) // <-- construtor da aplicação , (parametros: env)
        {
            this.env = env; //armazenamento do construtor
            var builder = new ConfigurationBuilder() 
                .SetBasePath(env.ContentRootPath) //set diretorio do json file
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true) //adciona o caminho do appsettings, dizendo que é opcional
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true) //adiciona o json para o ambiente de desenvolvimento
                .AddEnvironmentVariables(); //adiciona as variaveis de ambiente no windows

            config = builder.Build(); //config recebe as informações de builder e compila em build
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(config); //serviço de configuração do builder -- sigleton para todas as instancias do app

            if (env.IsDevelopment()) //caso o esteja em ambiente de desenvolvimento o app irá fazer isso
                services.AddScoped<IMailService, DebugMailService>();//ira implementar o debug no servico de desenvolvimento
            else //caso contrario...
                services.AddScoped<IMailService, MailService>();//Ira executar o servico de produção
            services.AddMvc();

        }
               
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); //utiliza a pagina de erro mais detalhada
                app.UseDatabaseErrorPage(); //pagina de erro no banco de dados
                app.UseBrowserLink();//executar a app em mais de um browser
            }
            else
            {
                app.UseExceptionHandler("/Home/Error"); //se houver erro no develop ira mostrar os erros ou o erro do diretorio do Erro
            }
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
        }
    }
}
