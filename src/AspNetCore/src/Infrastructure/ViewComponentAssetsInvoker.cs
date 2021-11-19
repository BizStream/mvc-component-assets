using BizStream.AspNetCore.ViewComponentAssets.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace BizStream.AspNetCore.ViewComponentAssets.Infrastructure
{
    /// <summary> Implementation of an <see cref="IViewComponentInvoker"/> that tracks <see cref="ViewComponent"/> assets to the <see cref="ViewComponentContext.ViewContext"/>. </summary>
    public class ViewComponentAssetsInvoker : IViewComponentInvoker
    {
        #region Fields
        private readonly IViewComponentAssetsDescriptorProvider assetsDescriptorProvider;
        private readonly IViewComponentInvoker defaultInvoker;
        #endregion

        public ViewComponentAssetsInvoker(
            IViewComponentAssetsDescriptorProvider assetsDescriptorProvider,
            IViewComponentInvoker defaultInvoker
        )
        {
            if( assetsDescriptorProvider is null )
            {
                throw new ArgumentNullException( nameof( assetsDescriptorProvider ) );
            }

            if( defaultInvoker is null )
            {
                throw new ArgumentNullException( nameof( defaultInvoker ) );
            }

            this.assetsDescriptorProvider = assetsDescriptorProvider;
            this.defaultInvoker = defaultInvoker;
        }

        private void ExposeViewComponentAssets( ViewComponentContext context )
        {
            var assets = assetsDescriptorProvider.GetAssetsDescriptor( context.ViewComponentDescriptor );
            if( assets is null )
            {

            }

            context.ViewContext.AddViewComponentScripts( assets.Scripts );
        }

        /// <inheritdoc/>
        public async Task InvokeAsync( ViewComponentContext context )
        {
            if( context is null )
            {
                throw new ArgumentNullException( nameof( context ) );
            }

            await defaultInvoker.InvokeAsync( context );
            ExposeViewComponentAssets( context );
        }
    }
}
