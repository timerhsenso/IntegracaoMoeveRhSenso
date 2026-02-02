namespace IntegracaoCepsaBrasil.Services.Email;

public interface IEmailService
{
    Task SendErrorEmailAsync(string integrationName, Exception ex);
}
