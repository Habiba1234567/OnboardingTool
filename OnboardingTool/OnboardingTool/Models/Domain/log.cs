using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace OnboardingTool.Models.Domain
{
    [PrimaryKey(nameof(time_of_occurance))]
    public class log
    {
        public string action { get; set; }
        public string actor { get; set; }
        public DateTime time_of_occurance { get; set; }
        public ICollection<Users> users { get; set; }
    }

}




