using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace eonapp.Models.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "Please enter name.")]
        public string Name { get; set; }

        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Please enter valid email address.")]
        [Required(ErrorMessage = "Please enter email.")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please select gender.")]
        public string Gender { get; set; }
        public Dictionary<string,string> Genders = new Dictionary<string, string>
        {
            { "M","Male"},
            { "F","Female"}

        };

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime),"01/01/2019","06/30/2019",ErrorMessage = "Please select date within range.(01/01/2019 - 06/30/2019)")]
        public DateTime DateRegistered { get; set; }

        public string Days { get; set; }
        [Required(ErrorMessage = "Please select at least one day.")]
        public string[] DayStrings = new[] { "Day 1", "Day 2 ", "Day 3" };

        [Required(ErrorMessage = "Please select at least one day.")]
        public List<string> SelectedDays { get; set; }

        [StringLength(100, ErrorMessage = "Please enter less than 100 characters.")]
        public string Request { get; set; }

    }
}
