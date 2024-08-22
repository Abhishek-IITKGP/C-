using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace API.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(DataCotext cotext) : ControllerBase
    {

        // This returns the list of users
        [HttpGet]
        public ActionResult<IEnumerable<AppUser>>GetUsers()
        {
            var users = cotext.Users.ToList();

            return users;
        }


        // This only returns a specfic user based on the ID provided in the HTTP request
        [HttpGet("{Id:int}")]
        public ActionResult<AppUser>GetUsers(int Id)
        {
            var user = cotext.Users.Find(Id);

            if(user == null)
            {
                return NotFound();
            }

            return user;
        }
    }
}