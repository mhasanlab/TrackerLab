namespace TrackerLab.Data.Models
{
    public class IssueType :  AuditableEntitie
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? Title { get; set; }
        public string? Color { get; set; }
    }
}