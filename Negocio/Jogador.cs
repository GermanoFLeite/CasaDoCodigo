using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Negocio
{
    public class Jogador
    {
        public Jogador(string dadosStr)
        {
            string[] dados = dadosStr.Split(",");
            Nome = dados[0];
            Camisa = dados[1];
            Posicao = dados[2];
        }

        public string Nome { get; set; }
        public string Camisa { get; set; }
        public string Posicao { get; set; }

        override
        public string ToString()
        {
            return $"Jogador: {Nome}, Camisa: {Camisa}, Posição: {Posicao}";
        }



    }
}
