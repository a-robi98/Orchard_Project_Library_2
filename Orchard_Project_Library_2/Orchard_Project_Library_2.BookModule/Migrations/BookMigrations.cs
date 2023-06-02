using Orchard_Project_Library_2.BookModule.Models;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchard_Project_Library_2.BookModule.Migrations
{
    public class BookMigrations : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public BookMigrations(IContentDefinitionManager contentDefinitionManager) 
        {
            _contentDefinitionManager = contentDefinitionManager;
        }
        public int Create()
        {

            _contentDefinitionManager.AlterPartDefinition(nameof(BookPart), part => part
            .Attachable()

            );

            _contentDefinitionManager.AlterTypeDefinition("BookPage", type => type
                .Creatable()
                .Listable()
                .WithPart(nameof(BookPart))
                );


            return 1;
        }
    }
}
