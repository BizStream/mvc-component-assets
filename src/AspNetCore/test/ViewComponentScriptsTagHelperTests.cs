using BizStream.AspNetCore.ViewComponentAssets.Tests.Abstractions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace BizStream.AspNetCore.ViewComponentAssets.Tests
{
    public class ViewComponentScriptsTagHelperTests : IClassFixture<AssetsWebApplicationFactory>
    {
        #region Fields
        private readonly WebApplicationFactory<Startup> factory;
        #endregion

        public ViewComponentScriptsTagHelperTests( AssetsWebApplicationFactory factory )
            => this.factory = factory;

        [Fact]
        public async Task ViewComponentScriptsTagHelper_RendersScriptElements( )
        {
            var client = factory.CreateClient();

            var response = await client.GetAsync( "/" );
            response.EnsureSuccessStatusCode();

            var document = await HtmlHelpers.GetDocumentAsync( response );

            var scripts = document?.QuerySelectorAll( "script" );
            Assert.True( scripts?.Length == 3 );
        }

    }
}
