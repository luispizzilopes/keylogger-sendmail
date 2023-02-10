using ProjetoKeyloggerConsole.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKeyloggerConsole
{
    internal class Config
    {
        public static string? Pasta { get; private set; }
        public static string? Arquivo { get; private set; }
        public static string? Email { get; private set; }
        public static string? Senha { get; private set; }
        public static int QntChar { get; private set; }


        public static void Configuracoes()
        {
            string[] config = File.ReadAllLines("config.dll");
            Pasta = config[0];
            Arquivo = config[1];
            Email = config[2];
            Senha = config[3];
            QntChar = int.Parse(config[4]);
        }
    }
}
