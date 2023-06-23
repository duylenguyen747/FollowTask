using MessagePack;

namespace FollowTask.Data.Entities
{
    public class TaskData
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Data { get; set; }
        public Tasks Task { get; set; }
        public Guid TaskId { get; set; }
        public Comment Comment { get; set; }
        public Guid CommentId { get; set; }

    }
}
