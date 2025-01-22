using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simulasiya4.DataAccess;
using Simulasiya4.ViewModels.Agent;

namespace Simulasiya4.Controllers;

public class HomeController(SimulasiyaDbContext _context) : Controller
{
    public IActionResult Index()
    {
        var datas = _context.Agents.Include(x=>x.Designation)
            .Where(x => !x.IsDeleted)
            .Select(x =>  new AgentGetVM
            {
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                DesignationName = x.Designation != null ? x.Designation.Name : ""
            }).ToList();
        return View(datas);
    }
}
