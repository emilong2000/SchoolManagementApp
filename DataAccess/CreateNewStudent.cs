using DomainModel.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CreateNewStudent
    {
        private readonly ApplicationDbContext _context;
        private static Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        public CreateNewStudent()
        {
            _context = new ApplicationDbContext();
        }
        public ResponseMessage AddStudentToDb(Student student)
        {
            ResponseMessage response = new ResponseMessage();
            try
            {
                student.RegDate = DateTime.Now;
                student.Status = "Created";
                var checkIfStudentExist = _context.Students.Where(x => x.Email == student.Email).SingleOrDefault();
                if (checkIfStudentExist != null)
                {
                    response.ErrorMessage = "Record was not inserted";
                    response.Message = "Record already exist";
                    response.StatusCode = "Failed";
                    return response;
                }
                else
                {
                    response.ErrorMessage = "Record inserted Successfully";
                    response.Message = "";
                    response.StatusCode = "Success";
                    _context.Students.Add(student);
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
