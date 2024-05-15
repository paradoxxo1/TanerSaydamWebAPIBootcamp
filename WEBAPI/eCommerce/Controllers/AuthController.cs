using eCommerce.Abstractions;
using eCommerce.DTOs;
using eCommerce.Models;
using eCommerce.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public sealed class AuthController : APIController
    {
        private static List<User> Users = new();
        [HttpPost]  // Register Process
        public IActionResult Register(RegisterDto request)
        {
            bool isUserNameExist = Users.Any(p => p.UserName == request.UserName); //Linq Methodu

            if (isUserNameExist)
            {
                return BadRequest(Result.Failed("Username is already exists"));
            }

            User user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Password = request.Password,
            };

            Users.Add(user);

            return Ok(Result.Succed("User create is successful"));

        }

        [HttpPost] // Login Process
        public IActionResult Login(LoginDto request)
        {
            User? user = Users.FirstOrDefault(p => p.UserName == request.UserName);
            if (user is null)
            {
                return BadRequest(Result.Failed("User not found"));
            }

            if (user.Password != request.Password)
            {
                return BadRequest(Result.Failed("Password is wrong"));
            }
            string token = "Token";
            return Ok(Result.Succed(token));
        }
    }
}
