using EmsEmployeeManagementSytem.Data;
using EmsEmployeeManagementSytem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmsEmployeeManagementSytem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Authentication : ControllerBase
    {
        private readonly DataContext _context;
        private readonly UserManager<Userdata> _userManager;
        private readonly SignInManager<Userdata> _signInManager;

        public Authentication(DataContext context, UserManager<Userdata> userManager, SignInManager<Userdata> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] ManagerRegistrationRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if the email is already registered
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                return BadRequest("Email is already registered.");
            }

            // Create a new User object
            var newUser = new Userdata
            {
                Email = model.Email,
                Username = model.Email, // You can use email as the username
                Name = model.Name,
                Position = "MANAGER" // Set the position to "MANAGER"
            };

            // Create the user with the provided password
            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (result.Succeeded)
            {
                // User registration successful
                // You can generate a JWT token here and return it if needed
                return Ok("Registration successful");
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}
