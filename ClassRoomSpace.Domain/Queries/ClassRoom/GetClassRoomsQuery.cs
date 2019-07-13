namespace ClassRoomSpace.Domain.Queries.ClassRoom
{
    public class GetClassRoomsQuery
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}