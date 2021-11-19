using BizStream.AspNetCore.ViewComponentAssets.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace BizStream.AspNetCore.ViewComponentAssets.Tests.Components
{
    [ViewComponentScript( "/test-component2.js" )]
    public class TestComponent2 : ViewComponent
    {
        public IViewComponentResult Invoke( )
        {
            return Content( string.Empty );
        }
    }
}
