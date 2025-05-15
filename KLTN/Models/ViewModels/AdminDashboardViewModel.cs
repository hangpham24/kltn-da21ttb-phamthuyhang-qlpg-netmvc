using KLTN.Models.Database;

namespace KLTN.Models.ViewModels
{
    public class AdminDashboardViewModel
    {
        public int TotalMembers { get; set; }
        public int TotalTrainers { get; set; }
        public int TotalUsers { get; set; }
        public int TotalPackages { get; set; }
        public int TotalClasses { get; set; }
        public int TotalRegistrations { get; set; }
        public decimal TotalRevenue { get; set; }
        
        public List<DangKy> RecentRegistrations { get; set; } = new List<DangKy>();
    }
} 