using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using eonapp.Models;
using eonapp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eonapp.Controllers
{
    public class UserController : Controller
    {
        private Repository repository;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            UserViewModel model = new UserViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(UserViewModel user)
        {
            repository = new Repository();
            if (ModelState.IsValid)
            {
                repository.AddUser(user);

                return RedirectToAction("GetUsers","User");
            }
          
            return View(user);
           
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
           return View("UserList");

        }
    }
}