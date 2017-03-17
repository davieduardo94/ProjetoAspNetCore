using System.Diagnostics;

namespace WebApplication1.Services
{
    public interface IMailService
    {
        void SendMail(string para, string de, string assunto, string corpo);
    }

    public class MailService: IMailService
    {
        public void SendMail(string para, string de, string assunto, string corpo)
        {
            //implementara a infraestruutra de envio de email MailKit
        }

    }
    public class DebugMailService : IMailService
    {
        public void SendMail(string para, string de, string assunto, string corpo)
        {
            Debug.WriteLine($"Enviando email de {de} para {para} com o assunto: {assunto}");
        }
    }
}
