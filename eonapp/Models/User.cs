using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace eonapp.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public string Email { get; set; }

        public char Gender { get; set; }


        public DateTime DateRegistered { get; set; }

        [BindProperty()]
        public string Days { get; set; }


        [StringLength(100)]
        public string Request { get; set; }

        [NotMapped]
        public string ShortRegisteredDate
        {
            get { return DateRegistered.ToString("dd/MM/yyyy"); }
        }



    }

    public class checkboxmodel
    {

    }
}
