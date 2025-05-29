using Microsoft.AspNetCore.Authorization; // Đảm bảo bạn có dòng này ở đầu file
using Microsoft.AspNetCore.Mvc;

namespace BT6.Controllers // Thay thế bằng namespace của bạn nếu khác
{
    // Chỉ cho phép người dùng có vai trò "Admin" truy cập Controller này
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Các Action khác của AdminController (nếu có)
        // public IActionResult ManageUsers() { ... }
        // public IActionResult ViewLogs() { ... }
    }
}