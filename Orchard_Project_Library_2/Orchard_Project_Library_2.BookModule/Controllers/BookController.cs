using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using OrchardCore.DisplayManagement.Notify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchard_Project_Library_2.BookModule.Controllers
{
    public class BookController : Controller
    {
        private readonly IStringLocalizer T;
        private readonly INotifier _notifier;
        private readonly IHtmlLocalizer H; 
        public BookController(IStringLocalizer<BookController> stringLocalizer, INotifier notifier, IHtmlLocalizer htmlLocalizer)
        {
            T = stringLocalizer;
            _notifier = notifier;
            H = htmlLocalizer;
        }
        public IActionResult Index() {
            ViewData["Message"] = T["Ady Endre: Verses kötet"];
            _notifier.Success(H["Success!!!!!"]);

            return View();
        }
    }
}
