//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using OrchardCore.DisplayManagement;
//using OrchardCore.DisplayManagement.Layout;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Orchard_Project_Library_2.BookModule.Filters
//{
//    public class ShapeInjectingFilter : IAsyncResultFilter
//    {
//        private readonly ILayoutAccessor _layoutAccessor;
//        private readonly IShapeFactory _shapeFactory;
//        public ShapeInjectingFilter(ILayoutAccessor layoutAccessor, IShapeFactory shapeFactory)
//        {
//            _layoutAccessor = layoutAccessor;   
//            _shapeFactory = shapeFactory;
//        }
//        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
//        {
//            if (!(context.Result is ViewResult || context.Result is PageResult))
//            {
//                await next();
//                return;
//            }

//            dynamic layout = await _layoutAccessor.GetLayoutAsync();

//            var contentZone = layout.Zones["Content"];
//            contentZone.Add( await _shapeFactory.New.LayoutInjectedShape);

//            await next();
            
//        }
//    }
//}
