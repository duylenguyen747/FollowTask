using MessagePack;

namespace FollowTask.Data.Entities
{
    public class TaskData
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Data { get; set; }
        public Tasks Task { get; set; }
        public int TaskId { get; set; }
        public Comment Comment { get; set; }
        public int CommentId { get; set; }

    }
}
