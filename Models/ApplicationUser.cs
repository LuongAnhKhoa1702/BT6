﻿using Microsoft.AspNetCore.Identity;

namespace BT6.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
    }
}


