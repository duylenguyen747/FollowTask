using System.ComponentModel.DataAnnotations.Schema;

namespace FollowTask.Data.Entities
{
    public class TaskChangedLog
    {
        public int Id { get; set; }
        public string ChangedBy { get; set; }
        public DateTime ChangedTime { get; set; }


        public int OldStatusId { get; set; }
        public Status OldStatus { get; set; }

        public int NewStatusId { get; set; }
        public Status NewStatus { get; set; }


        public int TaskId { get; set; }
        public Tasks Task { get; set; }
    }
}
