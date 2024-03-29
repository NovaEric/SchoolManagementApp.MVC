﻿namespace SchoolManagementApp.MVC.Data;

public partial class Course
{
    public int Id { get; set; }

    public string CourseName { get; set; } = null!;

    public string? Code { get; set; }

    public int? Credits { get; set; }

    public virtual ICollection<SchoolClass> SchoolClasses { get; } = new List<SchoolClass>();
}
