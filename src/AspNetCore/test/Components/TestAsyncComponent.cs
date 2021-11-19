using BizStream.AspNetCore.ViewComponentAssets.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace BizStream.AspNetCore.ViewComponentAssets.Tests.Components
{
    [ViewComponentScript( "/test-async-component.js" )]
    public class TestAsyncComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync( )
        {
            return Task.FromResult<IViewComponentResult>(
                Content( string.Empty )
            );
        }
    }
}
