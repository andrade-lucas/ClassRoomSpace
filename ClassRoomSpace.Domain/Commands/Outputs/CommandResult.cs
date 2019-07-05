using ClassRoomSpace.Shared.Commands;

namespace ClassRoomSpace.Domain.Commands.Outputs
{
    public class CommandResult : ICommandResult
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        
        public CommandResult(bool status, string message, object data)
        {
            Status = status;
            Message = message;
            Data = data;
        }
    }
}