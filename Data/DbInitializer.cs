using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BT6.Models; 
namespace BT6.Data
{
    public static class DbInitializer
    {
        public static async Task SeedRolesAndAdminUser(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>(); // Sử dụng ApplicationUser

           
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            
            if (!await roleManager.RoleExistsAsync("Member"))
            {
                await roleManager.CreateAsync(new IdentityRole("Member"));
            }

            // Tạo tài khoản Admin (nếu chưa có)
            var adminEmail = "admin@example.com";
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new ApplicationUser // Sử dụng ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true, // Xác nhận email luôn
                    FullName = "Admin User", // Thêm FullName
                    Address = "Admin Address" // Thêm Address
                };
                var result = await userManager.CreateAsync(adminUser, "Admin@123"); // Mật khẩu cho Admin
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // Tạo tài khoản Member (nếu chưa có)
            var memberEmail = "member@example.com";
            if (await userManager.FindByEmailAsync(memberEmail) == null)
            {
                var memberUser = new ApplicationUser // Sử dụng ApplicationUser
                {
                    UserName = memberEmail,
                    Email = memberEmail,
                    EmailConfirmed = true, // Xác nhận email luôn
                    FullName = "Member User", // Thêm FullName
                    Address = "Member Address" // Thêm Address
                };
                var result = await userManager.CreateAsync(memberUser, "Member@123"); // Mật khẩu cho Member
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(memberUser, "Member"); // Mặc định là Member
            }
        }
    }
}