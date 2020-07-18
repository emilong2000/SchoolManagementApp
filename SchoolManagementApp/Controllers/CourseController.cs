using BusinessLogic.IService;
using BusinessLogic.Service;
using DomainModel.Models;
using DomainModel.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _service;
        public CourseController(CourseService service)
        {
            _service = service;
        }
        // GET: Course
        public ActionResult Add(string status)
        {
            ViewBag.Status = status;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CourseDto course)
        {
            if(ModelState.IsValid)
            {
                var newCourse = new Course();
                var mapCourse = AutoMapper.Mapper.Map(course, newCourse);
                var addCourseResult = _service.AddCourse(mapCourse);
                return RedirectToAction("Add", new { status = addCourseResult.StatusCode });
            }
            return View();

        }
    }
}