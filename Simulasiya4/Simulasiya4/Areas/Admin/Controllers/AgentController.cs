using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simulasiya4.DataAccess;
using Simulasiya4.Extentions;
using Simulasiya4.Models;
using Simulasiya4.ViewModels.Agent;

namespace Simulasiya4.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class AgentController(SimulasiyaDbContext _context, IMapper _mapper, IWebHostEnvironment _env) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var datas = await _context.Agents.Include(x=>x.Designation).ToListAsync();
            return View(datas);
        }

        public IActionResult Create()
        {
            ViewBag.Designations = _context.Designations.Where(x=>!x.IsDeleted).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AgentCreateVM vm)
        {
            if (vm is null)
                return BadRequest();

            if(vm.Image!=null && !vm.Image.IsValid("image", 2))
            {
                ModelState.AddModelError("Image", "file type must be image, file size must be less than 2mb");
            }

            if (!ModelState.IsValid) {

                ViewBag.Designations = _context.Designations.Where(x => !x.IsDeleted).ToList();
                return View(vm);
            }

            Agent agent = _mapper.Map<Agent>(vm);
            
            if(vm.Image != null)
            {
                agent.ImageUrl = vm.Image.UploadAsync(_env.WebRootPath, "imgs").Result;
            }

            await _context.Agents.AddAsync(agent);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            var data = await _context.Agents.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null)
                return BadRequest();

            AgentUpdateVM vm = _mapper.Map<AgentUpdateVM>(data);

            ViewBag.Designations = _context.Designations.Where(x => !x.IsDeleted).ToList();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, AgentUpdateVM vm)
        {
            if (vm is null)
                return BadRequest();

            if (vm.Image != null && !vm.Image.IsValid("image", 2))
            {
                ModelState.AddModelError("Image", "file type must be image, file size must be less than 2mb");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Designations = _context.Designations.Where(x => !x.IsDeleted).ToList();
                return View(vm);
            }

            var data = await _context.Agents.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null)
                return BadRequest();

            if (vm.Image == null)
            {
                vm.ImageUrl = data.ImageUrl;
            }
            else
            {
                System.IO.File.Delete(Path.Combine(_env.WebRootPath, "imgs", data.ImageUrl));
            }

            _mapper.Map(vm, data);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var data = await _context.Agents.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null)
                return BadRequest();

            _context.Agents.Remove(data);
            await _context.SaveChangesAsync();

            System.IO.File.Delete(Path.Combine(_env.WebRootPath, "imgs", data.ImageUrl));

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Toggle(int? id)
        {
            var data = await _context.Agents.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null)
                return BadRequest();

            data.IsDeleted = !data.IsDeleted;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
