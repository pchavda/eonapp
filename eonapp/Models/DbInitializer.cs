using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace eonapp.Models
{
    public class DbInitializer
    {
        //Seed database. Create table and add default data.
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            //This is to create users table.
            context.Database.ExecuteSqlCommand("IF(SELECT COUNT(*) FROM SYS.objects WHERE UPPER(type_desc)='USER_TABLE' AND UPPER(NAME)='USERS')=0 BEGIN CREATE TABLE[dbo].[Users]( [Id] INT IDENTITY(1, 1) NOT NULL, [Name]  NVARCHAR(30)  NOT NULL, [Email] NVARCHAR(50)  NULL, [Gender]  NVARCHAR(1) NOT NULL, [DateRegistered] DATETIME2(7) NOT NULL, [Days] NVARCHAR(MAX) NULL, [Request] NVARCHAR(100) NULL ); End");

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
