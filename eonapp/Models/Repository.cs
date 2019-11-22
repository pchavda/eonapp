using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using eonapp.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace eonapp.Models
{
    public class Repository
    {
        private AppDbContext context;
        private IConfiguration Configuration { get; set; }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",true,true);
            return builder.Build();
        }

        public Repository()
        {
            var option = new DbContextOptionsBuilder<AppDbContext>();
            var configuration = GetConfiguration();
            option.UseSqlServer(configuration.GetConnectionString("AppDbContext"));
            context = new AppDbContext(option.Options);
        }

        public void AddUser(UserViewModel model)
        {
            User user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Days = string.Join(',',model.SelectedDays),
                DateRegistered = model.DateRegistered,
                Request = model.Request,
                Gender = Convert.ToChar(model.Gender)
            };

            context.Users.Add(user);
            context.SaveChanges();
        }

        public List<User> GetUsers()
        {
            return context.Users.ToList();
        }

    }
}
