namespace TrackerLab.Data.Models
{
    public class Project : AuditableEntitie
    {
        public int Id { get; init; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}