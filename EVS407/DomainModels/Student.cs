using System;
using System.Collections.Generic;

namespace DomainModels;

public partial class Student
{
    public int Id { get; set; }

    public string StudentName { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string RoleNumber { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public int GenderId { get; set; }

    public virtual Gender Gender { get; set; } = null!;
}
