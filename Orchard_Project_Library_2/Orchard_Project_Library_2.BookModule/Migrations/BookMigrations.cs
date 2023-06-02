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

        public int UpdateFrom1() 
        {
            _contentDefinitionManager.AlterTypeDefinition("BookListPage", type => type
                .Creatable()
                .Listable()
                .WithPart(nameof(BookPart))
                );


            return 2;
        }

        //public int UpdateFrom2()
        //{
        //    _contentDefinitionManager.AlterTypeDefinition("BookListPageWidget", type => type
        //        .Creatable()
        //        .Listable()
        //        .WithWield(Widge)
        //        );

        //    _contentDefinitionManager.AlterTypeDefinition("BookWidget", type => type
        //        .Creatable()
        //        .Listable()
        //        .WithPart(nameof(BookPart))
        //        );


        //    return 3;
        //}
    }
}
