namespace Pustok_Weekend_Task.ExternalServices.Interfaces
{
    public interface IEmailService
    {
        void Send(string toMail, string subject, string content, bool isHtml = true);
    }
}
