﻿using JulyIdea.Services.AuthAPI.Models.Enums;

namespace JulyIdea.Services.AuthAPI.ViewModels
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public Roles Roles { get; set; }
    }
}
