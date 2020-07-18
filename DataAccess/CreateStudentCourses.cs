using DomainModel.Models;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.UI;

namespace DataAccess
{
    public class CreateStudentCourses : Page
    {
        private readonly ApplicationDbContext _context;
        private static Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        public CreateStudentCourses()
        {
            _context = new ApplicationDbContext();
        }
        public ResponseMessage AddCourseToStudent(string courses)
        {
            ResponseMessage response = new ResponseMessage();
            try
            {
                string email = User.Identity.Name;
                var student = new Student();
                var course = new Course();
                
                if(email != null)
                {
                    student = _context.Students.Where(x => x.Email == email).FirstOrDefault();
                }

                StudentCourse studentcourse = new StudentCourse();
                string[] splitCourse = courses.Split(' ');
                foreach (var item in splitCourse)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        course = _context.Courses.Where(x => x.CourseCode == item).FirstOrDefault();

                        if (student.StudentId > 0 && course.CourseId > 0)
                        {
                            var checkExist = _context.StudentCourses.Where(x => x.CourseId == course.CourseId && x.StudentId == student.StudentId)
                                .FirstOrDefault();
                            if (checkExist != null)
                            {
                                _logger.Info("Record Already exist");
                                response.ErrorMessage = "Record inserted Successfully";
                                response.Message = "";
                                response.StatusCode = "Success";
                            }
                            else
                            {
                                studentcourse.CourseId = course.CourseId;
                                studentcourse.StudentId = student.StudentId;
                                response.ErrorMessage = "Record inserted Successfully";
                                response.Message = "";
                                response.StatusCode = "Success";
                                _context.StudentCourses.Add(studentcourse);
                                _context.SaveChanges();
                            }


                        }
                        else
                        {
                            response.ErrorMessage = "Record was not inserted";
                            response.Message = "Missing parameter. Please supply all parameters";
                            response.StatusCode = "Failed";

                        }
                    }
                    
                }
                return response;

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
        public List<Course> GetStudentCourses()
        {
            try
            {
                List<Course> list = new List<Course>();
               var couse = (from c in _context.Courses select new { c.CourseId, c.CourseCode }).ToList();
                foreach (var item in couse)
                {
                    list.Add(new Course()
                    {
                    CourseId = item.CourseId,
                    CourseCode = item.CourseCode
                    });
                };

                return list;

            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return null;

            }
        }
    }
}
