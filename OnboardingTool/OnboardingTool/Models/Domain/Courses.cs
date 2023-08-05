using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OnboardingTool.Models.Domain
{
    [PrimaryKey(nameof(Course_code))]
    public class Courses
    {
        public Guid Course_code { get; set; }
        public string URL { get; set; }
        public ICollection<User_courses> user_courses { get; set; }

    }
}
