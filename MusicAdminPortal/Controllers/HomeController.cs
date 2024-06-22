using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicAdminPortal.Models;
using MusicStoreAPI.Data;
using MusicStoreAPI.Models.CMS;
using System.Diagnostics;

namespace MusicAdminPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MusicStoreAPIContext _context;


        public HomeController(MusicStoreAPIContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            // viewbag created for navigation section
            ViewBag.ModelNavigation =
                (
                from strona in _context.WebHeaders
                orderby strona.Position
                select strona
                ).ToList();
            //handling for created nav section
            if (id == null)
                id = _context.WebHeaders.First().Id;
            // viewbag created for Footer section
            ViewBag.ModelAddressFooter =
                (
                    from adresFooter in _context.MusicStoreAddress
                    orderby adresFooter.Position
                    select adresFooter
                 ).First();

            ViewBag.ManagmentPanel =
            (
                from TopPanel in _context.Managment
                orderby TopPanel.Position
                select TopPanel
            ).ToList();

            if (id == null)
                id = _context.WebHeaders.First().Id;

            List<WebHeaders> webHeaders = _context.WebHeaders
                .Include(u => u.ProductCategories)
                .ThenInclude(s => s.ProductSubCategories)
                .OrderBy(o => o.Position).ToList();
            //var item = _context.WebHeaders.Find(id);

            return View(webHeaders);
        }

        public async Task<IActionResult> TermsAndCondition(int id)
        {
            if (id == null)
                id = _context.TermsAndCondition.First().Id;
            var item = _context.TermsAndCondition.ToList();
            return View(item);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}