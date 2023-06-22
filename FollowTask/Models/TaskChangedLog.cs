using System;
using System.Collections.Generic;

namespace FollowTask.Models;

public partial class TaskChangedLog
{
    public int Id { get; set; }

    public int? TaskId { get; set; }

    public string? ChangedBy { get; set; }

    public DateTime? ChangedTime { get; set; }

    public string? OldStatus { get; set; }

    public string? NewStatus { get; set; }

    public virtual Tasks? Task { get; set; }
}
