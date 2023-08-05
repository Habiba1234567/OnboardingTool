using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OnboardingTool.Models.Domain
{
    [PrimaryKey(nameof(Course_code))]

    public class User_courses
    {
        public int Course_code { get; set; }
        public int User_Id { get; set; }
        public ICollection<Courses> courses { get; set; }
        public Users Users { get; set; } = null!;

    }



}

