using Microsoft.AspNetCore.Identity;

namespace PortfolioSite.DAL.Context
{
    public class AdminSeeder
    {
        public static async Task EnsureAdminAsync(IServiceProvider services, IConfiguration config)
        {
            var email = config["AdminUser:Email"];
            var password = config["AdminUser:Password"];

            // Bilgi yoksa kullanıcı oluşturma
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return;

            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

            var existing = await userManager.FindByEmailAsync(email);
            if (existing != null) return;

            var user = new IdentityUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user, password);
            if (!result.Succeeded)
                throw new InvalidOperationException(
                    "Admin oluşturulamadı: " + string.Join(", ", result.Errors.Select(e => e.Description)));
        }
    
}
}
