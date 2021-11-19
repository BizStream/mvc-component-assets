using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BizStream.AspNetCore.ViewComponentAssets
{
    /// <summary> Extensions to <see cref="IMvcBuilder"/> allowing configuration of ViewComponent Bundles. </summary>
    public static class ViewComponentAssetsMvcBuilderExtensions
    {
        /// <summary> Registers services required to support ViewComponent Assets. </summary>
        /// <exception cref="ArgumentNullException"/>
        public static IMvcBuilder AddViewComponentAssets( this IMvcBuilder builder )
        {
            if( builder is null )
            {
                throw new ArgumentNullException( nameof( builder ) );
            }

            var defaultInvokerFactoryType = builder.Services.Single( descriptor => descriptor.ServiceType == typeof( IViewComponentInvokerFactory ) )
                .ImplementationType;

            // Add the DefaultViewComponentInvokerFactory (Mvc internal class) as a concrete service
            builder.Services.AddSingleton( defaultInvokerFactoryType );

            // Replace default with decorator
            builder.Services.Replace(
                ServiceDescriptor.Singleton<IViewComponentInvokerFactory>(
                    serviceProvider => new ViewComponentAssetsInvokerFactory(
                        ( IViewComponentInvokerFactory )serviceProvider.GetRequiredService( defaultInvokerFactoryType )
                    )
                )
            );

            return builder;
        }
    }
}
