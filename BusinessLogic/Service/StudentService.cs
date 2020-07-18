using BusinessLogic.IService;
using DataAccess;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public class StudentService : IStudentService
    {
        CreateNewStudent create = new CreateNewStudent();
        CreateStudentCourses courses = new CreateStudentCourses();
        public ResponseMessage AddCourseToStudent(string course)
        {
            return courses.AddCourseToStudent(course);
        }

        public ResponseMessage AddStudent(Student student)
        {           
            var result = create.AddStudentToDb(student);
            return result;
        }

        public List<Course> GetCourses()
        {
            return courses.GetStudentCourses();
        }
    }
}
