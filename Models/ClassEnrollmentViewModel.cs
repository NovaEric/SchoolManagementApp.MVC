using SchoolManagementApp.MVC.Data;

namespace SchoolManagementApp.MVC.Models;

public class ClassEnrollmentViewModel
{
    public SchoolClass? SchoolClass { get; set; }

    public List<StudentEnrollmentViewModel> Enrollments { get; set; } = new List<StudentEnrollmentViewModel>();

}