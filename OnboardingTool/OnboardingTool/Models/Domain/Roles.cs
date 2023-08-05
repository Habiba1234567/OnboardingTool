using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OnboardingTool.Models.Domain
{
    [PrimaryKey(nameof(type_code))]
    public class Roles
    {
        public string title { get; set; }
        public bool is_buddy { get; set; }
        public bool new_employee { get; set; }
        public int type_code { get; set; }
        public ICollection<User_roles> user_roles { get; } = new List<User_roles>();

    }



}
