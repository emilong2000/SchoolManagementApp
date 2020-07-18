using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService
{
    public interface IStudentService
    {
        ResponseMessage AddStudent(Student student);
        ResponseMessage AddCourseToStudent(string Courses);
        List<Course> GetCourses();
    }
}
