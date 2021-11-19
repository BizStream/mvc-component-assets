using BizStream.AspNetCore.ViewComponentAssets.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace BizStream.AspNetCore.ViewComponentAssets.Tests.Components
{
    [ViewComponentScript( "/test-component1.js" )]
    public class TestComponent1 : ViewComponent
    {
        public IViewComponentResult Invoke( )
        {
            return Content( string.Empty );
        }
    }
}
