﻿using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService
{
    public interface ICourseService
    {
        ResponseMessage AddCourse(Course course);
    }
}
