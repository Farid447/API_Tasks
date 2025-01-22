using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simulasiya4.DataAccess;
using Simulasiya4.Models;
using Simulasiya4.ViewModels.Designation;

namespace Simulasiya4.Areas.Admin.Controllers;

[Area("Admin")]
public class DesignationController(SimulasiyaDbContext _context) : Controller
{
    public async Task<IActionResult> Index()
    {
        var datas = await _context.Designations.ToListAsync();
        return View(datas);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(DesignationCreateVM vm)
    {
        if(await _context.Designations.FirstOrDefaultAsync(x=> x.Name == vm.Name) is null)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            Designation designation = new Designation()
            {
                Name = vm.Name,
            };

            await _context.Designations.AddAsync(designation);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        var data = await _context.Designations.FirstOrDefaultAsync(x=> x.Id == id);

        if (data == null)
            return BadRequest();

        DesignationUpdateVM vm = new DesignationUpdateVM()
        {
            Name = data.Name
        };

        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Update(int? id, DesignationUpdateVM vm)
    {
        var data = await _context.Designations.FirstOrDefaultAsync(x => x.Id == id);

        if (data == null)
            return BadRequest();

        if (await _context.Designations.FirstOrDefaultAsync(x => x.Name == vm.Name) is null)
        {

            data.Name = vm.Name;
            await _context.SaveChangesAsync();
        }


        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var data = await _context.Designations.FirstOrDefaultAsync(x => x.Id == id);

        if (data == null)
            return BadRequest();

        _context.Designations.Remove(data);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
