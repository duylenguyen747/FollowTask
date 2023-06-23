namespace FollowTask.DTOs
{
    public class CreateTaskDTO
    {
        public string CreateBy { get; set; }
        public DateTime DateTime { get; set; }
        public string AssignTo { get; set; }
        public int TagIds { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
