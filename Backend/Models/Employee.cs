using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? EmpName { get; set; }

    public int? Salary { get; set; }

    public string? City { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }

    public string? Age { get; set; }

    public bool? Status { get; set; }

    public int? DeptId { get; set; }
}
