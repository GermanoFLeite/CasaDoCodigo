using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace web
{
    public class Program
    {
        public static string NomeEscolhido { get; set; }
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Montando o seu Time Pague Menos!");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(@" Escolha o Nome do seu arquivo!
=== Nome Arquivo===:");

            Console.ForegroundColor = ConsoleColor.Gray;
            string nomeArquivo = $"Repositorio\\{Console.ReadLine()}.csv";
            NomeEscolhido = nomeArquivo;

            Console.Write("Quantos jogadores você deseja escalar: ");
            int qtdJogadores = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            // Criando um arquivo com o StreamWriter através de um fluxo de arquivo.
            using (var fluxoArquivo = new FileStream(nomeArquivo, FileMode.Create))
            using (var str = new StreamWriter(fluxoArquivo, Encoding.UTF8))
            {
                for (int i = 0; i < qtdJogadores; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Escreva as informações do jogador no seguinte formato:" +
                        "{Nome Número Posição}");

                    string infoJogador = Console.ReadLine().Replace(' ', ',');
                    str.WriteLine(infoJogador);
                    Console.Clear();
                }
            }    

            CreateHostBuilder(args).Build().Run();
        } 

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
