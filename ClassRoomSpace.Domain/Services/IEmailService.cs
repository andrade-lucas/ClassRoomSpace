namespace ClassRoomSpace.Domain.Services
{
    public interface IEmailService
    {
        void Send(string from, string to, string subject, string body);
    }
}