namespace Community.DataAccess.EF.Entities
{
    public class TodoEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool Success { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}