namespace ClassRoomSpace.Domain.Entities
{
    public class ClassRoom : Notifiable
    {
        public string Description { get; set; }
        public bool Status { get; set; }
        public EClassRoomType Type { get; set; }
    }
}