using Ecommerce.Models;
using System.Net;
using System.Net.Mail;

namespace Ecommerce.Libraries.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoPorEmail(ContatoModel contato)
        {
            // SMTP = Responsável pelo envio da msg
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("aspnetcore.ef@gmail.com", "2020brasil");
            smtp.EnableSsl = true;

            string corpoMsg = string.Format(@"<h2>Contato - Loja Virtual<h2>
                                            <b>Nome: </b> {0} <br />
                                            <b>E-mail: </b> {1} <br />
                                            <b>Texto: </b> {2} <br />
                                            <br />E-mail enviado automaticamente.",
                                            contato.Nome, contato.Email, contato.Texto);

            // MailMessage = Constrói a mensagem
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("aspnetcore.ef@gmail.com");
            msg.To.Add("aspnetcore.ef@gmail.com");
            msg.Subject = "Contato - Loja Virtual - E-mail: " + contato.Email;
            msg.Body = corpoMsg;
            msg.IsBodyHtml = true;


            //Envio da mensagem via SMTP
            smtp.Send(msg);

        }
    }
}
