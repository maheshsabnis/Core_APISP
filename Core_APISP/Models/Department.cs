using System;
using System.Collections.Generic;

namespace Core_APISP.Models;

public partial class Department
{
    public int DeptNo { get; set; }

    public string DeptName { get; set; } = null!;

    public string Location { get; set; } = null!;

    public int Capacity { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
