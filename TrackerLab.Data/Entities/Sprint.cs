namespace TrackerLab.Data.Models
{
    public class Sprint : AuditableEntitie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public Project? Project { get; private set; }
        public int ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Issue>? Issues { get; set; }
    }
}