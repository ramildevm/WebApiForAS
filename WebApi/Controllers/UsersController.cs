﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly UsersDBContext _context;

        public UsersController(UsersDBContext context)
        {
            _context = context;
        }

        // GET: Users
        [HttpGet("list")]
        public IEnumerable<User> GetUsers() => _context.Users;
        // GET: Users by login
        [HttpGet]
        public User GetUserByLogin(string login) => _context.Users.Where(user => user.Login == login).First();

        [HttpPost]
        public User CreateNeUser(User user)
        {
            int result = 0;
            _context.Users.Add(new User() { Login=user.Login,Password = user.Password});
            result = _context.SaveChanges();

            return (result<1)?null:new User();
        }
        
    }
}
