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
    public class CourseService : ICourseService
    {
        public ResponseMessage AddCourse(Course course)
        {
            CreateNewCourse create = new CreateNewCourse();
            var result = create.AddCourseToDb(course);
            return result;
        }
    }
}
