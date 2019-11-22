using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eonapp.Models
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;   
            }

            var users = new User[]
            {
                new User{Name= "Abc",Email="abc@test.com",Gender='M',DateRegistered = DateTime.Now,Days = "Day1, Day2",Request = "request1"},
                new User{Name= "Xyz",Email="xyz@test.com",Gender='F',DateRegistered = DateTime.Now,Days = "Day1, Day2, Day3",Request = "request1"},
                new User{Name= "Pqr",Email="pqr@test.com",Gender='F',DateRegistered = DateTime.Now,Days = "Day1, Day3",Request = "request1"},
               
            };

            foreach (var u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();
        }

        
    }
}
