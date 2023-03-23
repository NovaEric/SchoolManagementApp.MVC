using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementApp.MVC.Data;

public class CourseMetadata
{
    [Display(Name = "Course Name")]
    public string CourseName { get; set; } = null!;

    [StringLength(5, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
    public string? Code { get; set; }

}

[ModelMetadataType(typeof(CourseMetadata))]
public partial class Course{}   