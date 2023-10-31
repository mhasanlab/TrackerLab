namespace TrackerLab.Data.Models
{
    public class Comment: AuditableEntitie
    {
        public int Id { get; set; }
        public string? Text { get; set; }
    }
}