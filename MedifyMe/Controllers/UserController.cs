using MedifyMe.Models;
using MedifyMe.RequestResponseModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace MedifyMe.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MedifydbContext context;

        public UserController(MedifydbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<int> Register(RegisterRequest reg)
        {
            var obj = new User()
            {
                Name = reg.Name,
                Dob = reg.Dob,
                Gender = reg.Gender,
                Email = reg.Email,
                Phone = reg.Phone,
                IsDoctor = reg.IsDoctor,
                Password = reg.Password,

            };
            context.Users.AddAsync(obj);
            var res=await context.SaveChangesAsync();
            return res;


        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginRequest lg)
        {
            var res = await context.Users.Where(x => x.Email == lg.Email && x.Password == lg.Password).FirstOrDefaultAsync();
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);

        }


    }
}
