using Microsoft.AspNetCore.Mvc;

namespace Simulasiya4.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
