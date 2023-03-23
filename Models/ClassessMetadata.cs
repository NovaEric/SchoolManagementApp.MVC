using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementApp.MVC.Data;

public class SchoolClassMetaData 
{
    [Display(Name = "Lecture")]
    public int? LectureId { get; set; }

    [Display(Name = "Course")]
    public int? CourseId { get; set; }
}

[ModelMetadataType(typeof(SchoolClassMetaData))]
public partial class SchoolClass{}