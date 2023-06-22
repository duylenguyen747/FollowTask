using System;
using System.Collections.Generic;

namespace FollowTask.Models;

public partial class Tasks
{
    public int Id { get; set; }

    public string? CreateBy { get; set; }

    public DateTime? CreateTime { get; set; }

    public string? AssignTo { get; set; }

    public int? TagIds { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public int StatusId { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Status Status { get; set; } = null!;

    public virtual ICollection<TaskChangedLog> TaskChangedLogs { get; set; } = new List<TaskChangedLog>();

    public virtual ICollection<TaskData> TaskData { get; set; } = new List<TaskData>();
}
