using System;
using System.Collections.Generic;

namespace FollowTask.Models;

public partial class Comment
{
    public int Id { get; set; }

    public int? TaskId { get; set; }

    public DateTime? CommentTime { get; set; }

    public string? CommentBy { get; set; }

    public string? CommentContent { get; set; }

    public virtual Tasks? Task { get; set; }

    public virtual ICollection<TaskData> TaskData { get; set; } = new List<TaskData>();
}
