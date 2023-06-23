using MessagePack;

namespace FollowTask.Data.Entities
{
    public class Status
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public virtual List<TaskChangedLog> OldStatus { get; set; }
        public virtual List<TaskChangedLog> NewStatus { get; set; }
        public List<Tasks> Tasks { get; set; }
    }
}
