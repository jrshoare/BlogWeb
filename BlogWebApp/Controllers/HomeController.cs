using BlogWebApp.Models;
using BlogWebApp.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BlogWebApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IBlogRepository blogRepository)
        {
            BlogRepository = blogRepository;
        }

        public async Task<IActionResult> Index()
        {
            var model = await BlogRepository.GetMostRecentAsync();
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private IBlogRepository BlogRepository { get; set; }
    }
}
