//using Orchard_Project_Library_2.BookModule.Models;
//using OrchardCore.ContentManagement;
//using YesSql.Indexes;

//namespace Orchard_Project_Library_2.BookModule.Indexes
//{

//    public class BookPartIndex : MapIndex
//    {
//        public string ContentItemId { get; set; }
//        public int ISBN { get; set; }
//    }


//    public class BookPartIndexProvider : IndexProvider<ContentItem>
//    {
//        public override void Describe(DescribeContext<ContentItem> context) =>
//            context.For<BookPartIndex>().Map(contentItem =>
//            {
//                var bookPart = contentItem.As<BookPart>();

//                return bookPart == null
//                    ? null
//                    : new BookPartIndex
//                    {
//                        ContentItemId = contentItem.ContentItemId,
//                        ISBN = bookPart.ISBN
//                    };
//            });
//    }
//}
