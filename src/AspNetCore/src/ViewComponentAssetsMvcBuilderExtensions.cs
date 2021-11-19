using BizStream.AspNetCore.ViewComponentAssets.Abstractions;
using BizStream.AspNetCore.ViewComponentAssets.Infrastructure;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BizStream.AspNetCore.ViewComponentAssets
{
    /// <summary> Extensions to <see cref="IMvcBuilder"/> allowing configuration of ViewComponent Bundles. </summary>
    public static class ViewComponentAssetsMvcBuilderExtensions
    {
        private static void DecorateViewComponentInvokerFactory( IServiceCollection services )
        {
            var defaultInvokerFactoryType = services.Single( descriptor => descriptor.ServiceType == typeof( IViewComponentInvokerFactory ) )
                .ImplementationType;

            // Add the DefaultViewComponentInvokerFactory (Mvc internal class) as a concrete service
            services.AddSingleton( defaultInvokerFactoryType );

            // Replace default with decorator
            services.Replace(
                ServiceDescriptor.Singleton<IViewComponentInvokerFactory>(
                    serviceProvider => new ViewComponentAssetsInvokerFactory(
                        serviceProvider.GetRequiredService<IViewComponentAssetsDescriptorProvider>(),
                        ( IViewComponentInvokerFactory )serviceProvider.GetRequiredService( defaultInvokerFactoryType )
                    )
                )
            );
        }

        /// <summary> Registers services required to support ViewComponent Assets. </summary>
        /// <exception cref="ArgumentNullException"/>
        public static IMvcBuilder AddViewComponentAssets( this IMvcBuilder builder )
        {
            if( builder is null )
            {
                throw new ArgumentNullException( nameof( builder ) );
            }

            builder.Services.AddSingleton<IViewComponentAssetsDescriptorProvider, ViewComponentAssetsDescriptorProvider>();
            DecorateViewComponentInvokerFactory( builder.Services );

            return builder;
        }
    }
}