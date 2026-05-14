using Hms.Repo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Hms.Utility
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly ApplicationDbContext _context;

        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Any())
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }

            // Create Roles

            if (!_roleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole("Admin"))
                    .GetAwaiter()
                    .GetResult();

                _roleManager.CreateAsync(new IdentityRole("Doctor"))
                    .GetAwaiter()
                    .GetResult();

                _roleManager.CreateAsync(new IdentityRole("Patient"))
                    .GetAwaiter()
                    .GetResult();

                // Create Admin User

                var user = new IdentityUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    EmailConfirmed = true
                };

                _userManager.CreateAsync(user, "Admin@123")
                    .GetAwaiter()
                    .GetResult();

                var adminUser = _context.Users
                    .FirstOrDefault(u => u.Email == "admin@gmail.com");

                if (adminUser != null)
                {
                    _userManager.AddToRoleAsync(adminUser, "Admin")
                        .GetAwaiter()
                        .GetResult();
                }
            }
        }

    }
    
}