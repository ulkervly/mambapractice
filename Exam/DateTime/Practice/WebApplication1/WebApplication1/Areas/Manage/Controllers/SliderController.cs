using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        public SliderController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           List<Slider>Sliders=_context.Sliders.ToList();
            return View(Sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
