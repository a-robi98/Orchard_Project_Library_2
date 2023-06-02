
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using Orchard_Project_Library_2.BookModule.Models;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Records;
using OrchardCore.DisplayManagement.Notify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesSql;

namespace Orchard_Project_Library_2.BookModule.Controllers
{
    public class BookController : Controller
    {
        private readonly IStringLocalizer T;
        private readonly INotifier _notifier;
        //private readonly IHtmlLocalizer H;
        private readonly ISession _session;
        private readonly IContentManager _contentManager;
        public BookController(IStringLocalizer<BookController> stringLocalizer, INotifier notifier, ISession session, IContentManager contentManager)
        {
            T = stringLocalizer;
            _notifier = notifier;
            //H = htmlLocalizer;
            _session = session;
            _contentManager = contentManager;
        }
        public IActionResult Index() {
            ViewData["Message"] = T["Ady Endre: Verses kötet"];
            //_notifier.Success(H["Success!!!!!"]);

            return View();
        }

        //[Route("bookauthorlist")]
        public async Task<string> List() 
        {
            var bookPages = await _session
                .Query<ContentItem, ContentItemIndex>(index => index.ContentType == "BookPage")
                .ListAsync();



            string books = "";

            foreach (var bookPage in bookPages)
            {
                await _contentManager.LoadAsync(bookPage);
                books += bookPage.As<BookPart>().Author + ": ";
                books += bookPage.As<BookPart>().Title + " / ";
                books += bookPage.As<BookPart>().PublicationYear + " - ";
                books += bookPage.As<BookPart>().ISBN + " ( ";
                books += bookPage.As<BookPart>().Description + " ) ";
            }

            




            return books;
        }

    }
}
