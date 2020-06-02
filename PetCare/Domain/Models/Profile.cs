﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public abstract class Profile
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Document { get; set; }

        public Account Account { get; set; }
        public int AccountId { get; set; }
    }
}