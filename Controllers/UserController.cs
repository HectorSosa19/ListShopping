using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShoppingList.Context;
using ShoppingList.Dtos;
using ShoppingList.Entities;
using ShoppingList.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ShoppingList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static User user = new User();
        private readonly IConfiguration _configuration;
        private readonly ContextShop Context;
        private readonly IUserService _userService;
        public UserController(IConfiguration configuration, ContextShop context, IUserService service)
        {
            Context = context;
            _configuration = configuration;
            _userService = service;
        }
        [HttpPost]
        public async Task<ActionResult<User>> RegisterUser(RegisterDto request)
        {
            user.Id = request.Id;
            user.Name = request.Name;
            user.LastName = request.LastName;
            user.UserRoles = request.UserRoles;
            user.Email = request.Email;
            user.Phone = request.Phone;
            user.Gender = request.Gender;
            user.UserName = request.UserName;
            user.Password = request.Password;
            PostUser(user);
            return Ok(user);
        }

        private User PostUser(User user)
        {
            var userFromService = _userService.CreateUser(user);
            return userFromService;
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(await Context.User.ToListAsync());
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<User>> GetId(int Id)
        {
            var user = await Context.User.FindAsync(Id);
            if (user == null)
                return BadRequest("User Not Found");
            return Ok(user);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserDto user)
        {
            var userFind = _userService.GetAllUser().Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
            if (userFind is null)
            {
                return BadRequest("User not Found");
            }
            string token = CreateToken(userFind);

            return Ok(token);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<List<User>>> UpdateUser(int Id, [FromForm] RegisterDto request)
        {
            var user = await Context.User.FindAsync(Id);
            if (user == null)
                return BadRequest("User Not Found");
            user.Id = request.Id;
            user.Name = request.Name;
            user.LastName = request.LastName;
            user.UserRoles = request.UserRoles;
            user.Email = request.Email;
            user.Phone = request.Phone;
            user.Gender = request.Gender;
            user.UserName = request.UserName;
            user.Password = request.Password;
            await Context.SaveChangesAsync();
            return Ok(await Context.User.ToListAsync());
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<User>>> Delete(int Id)
        {
            var user = await Context.User.FindAsync(Id);
            if (user == null)
                return BadRequest("User not Found");
            Context.User.Remove(user);
            await Context.SaveChangesAsync();
            return Ok(await Context.User.ToListAsync());
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim ( ClaimTypes .Name , user .UserName ) ,
                new Claim(ClaimTypes.Role, user.UserRoles.ToString()),
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

    }
}
