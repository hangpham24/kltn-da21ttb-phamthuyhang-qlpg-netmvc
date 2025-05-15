using KLTN.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace KLTN.Data
{
    public class DbSeeder
    {
        public static async Task SeedRolesAsync(ApplicationDbContext context)
        {
            // Check if roles already exist
            if (await context.Quyens.AnyAsync())
            {
                return; // Database already seeded
            }

            // Create default roles
            var roles = new List<Quyen>
            {
                new Quyen
                {
                    TenQuyen = "Admin",
                    MoTa = "Quyền quản trị hệ thống"
                },
                new Quyen
                {
                    TenQuyen = "Huấn luyện viên",
                    MoTa = "Quyền dành cho huấn luyện viên"
                },
                new Quyen
                {
                    TenQuyen = "Thành viên",
                    MoTa = "Quyền dành cho thành viên tập gym"
                }
            };

            // Add roles to database
            await context.Quyens.AddRangeAsync(roles);
            await context.SaveChangesAsync();
        }
    }
} 