using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Logging;

namespace IntegracaoCepsaBrasil.Services.Email;

public class EmailService(EmailConfiguration _emailConfig, ILogger<EmailService> _logger) : IEmailService
{
    public async Task SendErrorEmailAsync(string integrationName, Exception ex)
    {
        if (!_emailConfig.Enabled)
        {
            return;
        }

        if (string.IsNullOrEmpty(_emailConfig.SmtpServer) || string.IsNullOrEmpty(_emailConfig.RecipientEmail))
        {
            _logger.LogWarning("Configuração de e-mail incompleta. O e-mail de alerta não será enviado.");
            return;
        }

        try
        {
            var subject = $"[ERRO] Falha na Integração Cepsa: {integrationName}";
            var body = $@"
                <h2>Falha Detectada na Integração</h2>
                <p><strong>Integração:</strong> {integrationName}</p>
                <p><strong>Data/Hora:</strong> {DateTime.Now:dd/MM/yyyy HH:mm:ss}</p>
                <hr />
                <h3>Detalhes do Erro:</h3>
                <p>{ex.Message}</p>
                <pre>{ex.StackTrace}</pre>
            ";

            using var message = new MailMessage()
            {
                From = new MailAddress(_emailConfig.SenderEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            foreach (var recipient in _emailConfig.RecipientEmail.Split(';'))
            {
                message.To.Add(recipient.Trim());
            }

            using var client = new SmtpClient(_emailConfig.SmtpServer, _emailConfig.Port)
            {
                Credentials = new NetworkCredential(_emailConfig.SenderEmail, _emailConfig.SenderPassword),
                EnableSsl = _emailConfig.EnableSsl
            };

            await client.SendMailAsync(message);
            _logger.LogInformation($"Email de alerta enviado com sucesso para {_emailConfig.RecipientEmail}");
        }
        catch (Exception emailEx)
        {
            _logger.LogError(emailEx, "Falha ao enviar e-mail de alerta.");
        }
    }
}
