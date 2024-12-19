using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelApp.Models;

namespace TravelApp.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthController(ApplicationDbContext dbContext, IJwtTokenGenerator jwtTokenService)
        {
            _dbContext = dbContext;
            _jwtTokenGenerator = jwtTokenService;
        }

        // 1. Register via Email
        [HttpPost("register-email")]
        public async Task<IActionResult> RegisterWithEmail([FromBody] RegisterEmailRequest request)
        {
            if (await _dbContext.Users.AnyAsync(u => u.Email == request.Email))
                return BadRequest("Email is already in use.");

            var user = new User
            {
                Email = request.Email,
                PasswordHash = HashPassword(request.Password),
                CreatedAt = DateTime.UtcNow
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return Ok("User registered successfully.");
        }

        // 2. Register via Phone
        [HttpPost("register-phone")]
        public async Task<IActionResult> RegisterWithPhone([FromBody] RegisterPhoneRequest request)
        {
            if (await _dbContext.Users.AnyAsync(u => u.Phone == request.Phone))
                return BadRequest("Phone number is already in use.");

            // Verify phone number via external service (omitted for simplicity)

            var user = new User
            {
                Phone = request.Phone,
                PasswordHash = HashPassword(request.Password),
                CreatedAt = DateTime.UtcNow
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return Ok("User registered successfully.");
        }

        // 3. Delete Account
        [HttpPost("delete-account")]
        [Authorize]
        public async Task<IActionResult> DeleteAccount()
        {
            var userId = User.FindFirst("id")?.Value;
            if (userId == null)
                return Unauthorized();

            var user = await _dbContext.Users.FindAsync(int.Parse(userId));
            if (user == null)
                return NotFound("User not found.");

            user.IsActive = false; // Mark as inactive instead of immediate deletion
            await _dbContext.SaveChangesAsync();

            return Ok("Account marked for deletion.");
        }

        // Helper methods
        private static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}