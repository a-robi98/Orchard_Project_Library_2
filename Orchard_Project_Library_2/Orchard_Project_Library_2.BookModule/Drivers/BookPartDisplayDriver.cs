using Orchard_Project_Library_2.BookModule.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orchard_Project_Library_2.BookModule.ViewModels;

namespace Orchard_Project_Library_2.BookModule.Drivers
{
    public class BookPartDisplayDriver : ContentPartDisplayDriver<BookPart>
    {
        public override IDisplayResult Display(BookPart part, BuildPartDisplayContext context) =>
            Initialize<BookPartViewModel>(
                GetDisplayShapeType(context),
                viewModel => PopulateViewModel(part, viewModel))
            .Location("Detail", "Content:5")
            .Location("Summary", "Content:5");

        public override IDisplayResult Edit(BookPart part, BuildPartEditorContext context) =>
            Initialize<BookPartViewModel>(
                GetEditorShapeType(context),
                viewModel => PopulateViewModel(part, viewModel))
            .Location("Content:5");

        public override async Task<IDisplayResult> UpdateAsync(BookPart part, IUpdateModel updater, UpdatePartEditorContext context)
        {
            var viewModel = new BookPartViewModel();

            await updater.TryUpdateModelAsync(viewModel, Prefix);

            part.Author = viewModel.Author;
            part.Title = viewModel.Title;
            part.PublicationYear = viewModel.PublicationYear;
            part.ISBN = viewModel.ISBN;
            part.Description = viewModel.Description;

            return await EditAsync(part, context);
        }


        private static void PopulateViewModel(BookPart part, BookPartViewModel viewModel)
        {
            viewModel.Author = part.Author;
            viewModel.Title = part.Title;
            viewModel.PublicationYear = part.PublicationYear;
            viewModel.ISBN = part.ISBN;
            viewModel.Description = part.Description;
        }
    }
}
