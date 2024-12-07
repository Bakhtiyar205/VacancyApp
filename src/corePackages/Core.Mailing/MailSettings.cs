namespace Core.Mailing;

public class MailSettings
{
    public string Server { get; set; } = default!;
    public int Port { get; set; } = default!;
    public string SenderFullName { get; set; } = default!;
    public string SenderEmail { get; set; } = default!;
    public string? UserName { get; set; }
    public string? Password { get; set; }

    public MailSettings()
    {
    }

    public MailSettings(string server, int port, string senderFullName, string senderEmail, string userName, string password)
    {
        Server = server;
        Port = port;
        SenderFullName = senderFullName;
        SenderEmail = senderEmail;
        UserName = userName;
        Password = password;
    }
}