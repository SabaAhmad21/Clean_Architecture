using System;
using System.Collections.Generic;

namespace DomainModels;

public partial class Gender
{
    public int Id { get; set; }

    public string GenderName { get; set; } = null!;

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
