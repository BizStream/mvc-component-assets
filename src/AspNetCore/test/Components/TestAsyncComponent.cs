using Microsoft.AspNetCore.Mvc;

namespace BizStream.AspNetCore.ViewComponentAssets.Tests.Components
{
    [ViewComponentScript( "/test-async-component.js" )]
    public class TestAsyncComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync( )
        {
            await Task.CompletedTask;
            return Content( string.Empty );
        }
    }
}
