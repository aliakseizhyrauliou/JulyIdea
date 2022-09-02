﻿using JulyIdea.Services.IdeasAPI.DbStuff.Models;
using JulyIdea.Services.IdeasAPI.DbStuff.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace JulyIdea.Services.IdeasAPI.ViewModels
{
    public class IdeaViewModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StackFullString { get; set; }
        public IdeaCategory Category { get; set; }
        public string CategoryString { get; set; }

        public List<string> Stack 
        {
            get { return StackFullString.Split(',').ToList(); }
            set
            {
                StackFullString = String.Join(",", value);
            }
        }
    }
}
