using Mamba.Business.Services.Interfaces;
using Mamba.Core.Models;
using Mamba.Data.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Mamba.Areas.Manage.Controllers
{
    [Area ("Manage")]

    public class TeamController : Controller
    {
		private readonly MambaContext _context;
		private readonly IWebHostEnvironment _env;
		private readonly ITeamService _teamService;
        public TeamController(MambaContext context,IWebHostEnvironment env,ITeamService teamService)
        {
			_context = context;
			_env = env;
			_teamService = teamService;
		}
        public IActionResult Create()
        {
			ViewBag.Professions = _context.Professions.ToList();
			return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Team team)
        {
            ViewBag.Professions=_context.Professions.ToList();
			if (!ModelState.IsValid)
			{
				return View();
			}

			


			return RedirectToAction("Index");
			

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
