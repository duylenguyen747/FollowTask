using System;
using System.Collections.Generic;

namespace FollowTask.Models;

public partial class Status
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
}
