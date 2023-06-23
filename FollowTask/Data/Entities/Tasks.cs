using MessagePack;

namespace FollowTask.Data.Entities
{
    public class Tasks
    {
        public Guid Id { get; set; }
        public string CreateBy { get; set; }
        public DateTime DateTime { get; set; }
        public string AssignTo { get; set; }
        public int TagIds { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Status Status { get; set; }
        public Guid StatusId { get; set; }
        public List<Comment> Comment { get; set; }
        public List<TaskData> TaskData { get; set; }
        public List<TaskChangedLog> TaskChangedLog { get; set; }
    }
}
