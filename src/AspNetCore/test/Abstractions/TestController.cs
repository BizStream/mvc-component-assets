using Microsoft.AspNetCore.Mvc;

namespace BizStream.AspNetCore.ViewComponentAssets.Tests.Abstractions
{
    public class TestController : Controller
    {
        [HttpGet( "" )]
        public IActionResult Index( ) => View();
    }
}
