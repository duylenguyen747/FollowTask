using System;
using System.Collections.Generic;

namespace FollowTask.Models;

public partial class TaskData
{
    public int Id { get; set; }

    public int? TaksId { get; set; }

    public int? CommentId { get; set; }

    public string? FileName { get; set; }

    public string? Data { get; set; }

    public virtual Comment? Comment { get; set; }

    public virtual Tasks? Taks { get; set; }
}
