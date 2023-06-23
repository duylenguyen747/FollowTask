using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;

namespace FollowTask.Data.Entities
{
    public class Comment
    {
        
        public Guid Id { get; set; }
        public DateTime CommentTime { get; set; }
        public string CommentBy { get; set; }
        public string CommentContent { get; set; }
        public Tasks Task { get; set; }
        public Guid TaskId { get; set; }
        public List<TaskData> TaskData { get; set; }

    }
}
