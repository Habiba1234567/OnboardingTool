using System;
using Microsoft.EntityFrameworkCore;

namespace OnboardingTool.Models.Domain
{
    [PrimaryKey(nameof(type_code), nameof(user_id))]
    public class User_roles
    {
        public int type_code { get; set; }
        public int user_id { get; set; }
        public Roles Roles { get; set; } = null!;
        public Users Users { get; set; } = null!;

    }



}
