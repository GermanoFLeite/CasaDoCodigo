using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using web.Negocio;


namespace web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            string nomeEscolhido = Program.NomeEscolhido;

            string nomeArquivo = $"{nomeEscolhido}";           

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {

                    StringReader strReader = new StringReader(
                        File.ReadAllText(nomeArquivo));

                    string linha = "";

                    await context.Response.WriteAsync(@"
                    <!DOCTYPE html>
                    <html>
                    <head>
                    <meta charset='utf-8'>
                        <style>
                            table {
                              border-collapse: collapse;
                              border-spacing: 0;
                              width: 100%;
                              border: 1px solid #ddd;
                            }

                            th, td {
                              text-align: left;
                              padding: 16px;
                            }

                            tr:nth-child(even) {
                              background-color: #f2f2f2;
                        }
                    </style>
                    </head>");

                    await context.Response.WriteAsync(@"
                    <table>
                        <tr><th>Nome</th><th>Camisa</th><th>Posição</th></tr>
                    ");

                    while (linha != null)
                    {
                        linha = strReader.ReadLine();
                        if (linha != null)
                        {
                            Jogador jogador = new Jogador(linha);
                            await context.Response.WriteAsync(@$"
                        <tr><td>{jogador.Nome}</td><td>{jogador.Camisa}</td><td>{jogador.Posicao}</td></tr>");
                        }

                    }
                    await context.Response.WriteAsync("</table>");
                });
            });
        }
    }
}
