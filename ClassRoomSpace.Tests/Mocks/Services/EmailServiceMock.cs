using ClassRoomSpace.Domain.Services;

namespace ClassRoomSpace.Tests.Mocks.Services
{
    public class EmailServiceMock : IEmailService
    {
        public void Send(string from, string to, string subject, string body)
        {
            
        }
    }
}