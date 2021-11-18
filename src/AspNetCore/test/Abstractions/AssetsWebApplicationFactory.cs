using Microsoft.AspNetCore.Mvc.Testing;

namespace BizStream.AspNetCore.ViewComponentAssets.Tests.Abstractions
{
    public class AssetsWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost( IWebHostBuilder builder )
            => builder.UseContentRoot( AppDomain.CurrentDomain.BaseDirectory )
                .UseEnvironment( Environments.Development );

        protected override IHostBuilder CreateHostBuilder( )
           => Host.CreateDefaultBuilder()
               .ConfigureWebHostDefaults( builder => builder.UseStartup<Startup>() );
    }
}
