﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models.Dtos
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string RegNo { get; set; }
        [Required]
        public string Mobile { get; set; }
        public DateTime RegDate { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
        public string ResponseStatus { get; set; }
        public string Status { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
