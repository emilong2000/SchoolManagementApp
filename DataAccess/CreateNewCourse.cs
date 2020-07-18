using DomainModel.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CreateNewCourse
    {
        private  readonly ApplicationDbContext _context;
        private static Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        public CreateNewCourse()
        {
            _context = new ApplicationDbContext();
        }
        public ResponseMessage AddCourseToDb(Course course)
        {
            ResponseMessage response = new ResponseMessage();
            try
            {
                course.CourseEntryDate = DateTime.Now;
                course.status = "Created";
                var checkIfStudentExist = _context.Courses.Where(x => x.CourseCode == course.CourseCode).SingleOrDefault();
                if (checkIfStudentExist != null)
                {
                    response.ErrorMessage = "Record was not inserted";
                    response.Message = "Record already exist";
                    response.StatusCode = "Failed";
                    return response;
                }
                else
                {
                    response.ErrorMessage = null;
                    response.Message = "Record inserted Successfully";
                    response.StatusCode = "Success";
                    _context.Courses.Add(course);
                    _context.SaveChanges();
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.ToString();
                response.Message = "Something Went wrong";
                response.StatusCode = "Failed";
                _logger.Error(ex);
                return response;
            }
        }
    }
}
