using BusinessLogic.IService;
using BusinessLogic.Service;
using DataAccess;
using DomainModel.Models;
using DomainModel.Models.Dtos;
using Microsoft.AspNet.Identity.Owin;
using SchoolManagementApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SchoolManagementApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _service;
        public StudentController(StudentService service)
        {
            _service = service;
            
        }
        
        // GET: Student
        public ActionResult AddStudent(string status)
        {
            ViewBag.Status = status;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStudent(StudentDto studentDto)
        {
            var newStudent = new Student();
            if (ModelState.IsValid)
            {
                var hashedPassword = HashUserPassowrd.Hash(studentDto.Password);
                if(hashedPassword != null)
                {
                    studentDto.Password = hashedPassword;
                }
                var mapStudent = AutoMapper.Mapper.Map(studentDto, newStudent);
                var addStudentresult = _service.AddStudent(mapStudent);
                if (addStudentresult.StatusCode.Equals("Success"))
                {
                    return RedirectToAction("AddStudent", new { status = addStudentresult.StatusCode });
                }

            }
            return View(studentDto);
        }
        public JsonResult AddCourses()
        {
            var courseList = _service.GetCourses();
            if (courseList != null)
            {
                // var allowCourse = new MultiSelectList(courseList, "CourseId", "CourseCode");
                // var allowCourse = (fro)
                //Session["Course"] = allowCourse;
                
                return Json(courseList, JsonRequestBehavior.AllowGet);
                
            }
            return null;
        }
        [Authorize]
        public ActionResult CourseRegiser()
        {
            return View();
        }


        [HttpGet]
        //[Authorize]
        public JsonResult PostCourse(string Courses)
        {
            string message = "";
            var addCourseResult = _service.AddCourseToStudent(Courses);
            message = addCourseResult.StatusCode;
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}