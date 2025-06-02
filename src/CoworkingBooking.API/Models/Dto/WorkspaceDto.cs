namespace CoworkingBooking.API.Models.Dto
{
    public class WorkspaceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ZoneId { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
    }
}