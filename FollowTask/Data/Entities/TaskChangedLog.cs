namespace FollowTask.Data.Entities
{
    public class TaskChangedLog
    {
        public Guid Id { get; set; }
        public string ChangedBy { get; set; }
        public DateTime ChangedTime { get; set; }



        public Guid OldStatusId { get; set; }
        public Status OldStatus { get; set; }


        public Guid NewStatusId { get; set; }
        public Status NewStatus { get; set; }


        public Guid TaskId { get; set; }
        public Tasks Task { get; set; }
    }
}
