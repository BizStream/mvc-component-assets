using BizStream.AspNetCore.ViewComponentAssets.Abstractions;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace BizStream.AspNetCore.ViewComponentAssets.Infrastructure
{
    /// <summary> Implementation of an <see cref="IViewComponentInvokerFactory"/> that creates instances of <see cref="ViewComponentAssetsInvoker"/>. </summary>
    public class ViewComponentAssetsInvokerFactory : IViewComponentInvokerFactory
    {
        #region Fields
        private readonly IViewComponentAssetsDescriptorProvider assetsDescriptorProvider;
        private readonly IViewComponentInvokerFactory defaultFactory;
        #endregion

        public ViewComponentAssetsInvokerFactory(
            IViewComponentAssetsDescriptorProvider assetsDescriptorProvider,
            IViewComponentInvokerFactory defaultFactory
        )
        {
            if( assetsDescriptorProvider is null )
            {
                throw new ArgumentNullException( nameof( assetsDescriptorProvider ) );
            }

            if( defaultFactory is null )
            {
                throw new ArgumentNullException( nameof( defaultFactory ) );
            }

            this.assetsDescriptorProvider = assetsDescriptorProvider;
            this.defaultFactory = defaultFactory;
        }

        /// <inheritdoc/>
        public IViewComponentInvoker CreateInstance( ViewComponentContext context )
        {
            if( context is null )
            {
                throw new ArgumentNullException( nameof( context ) );
            }

            return new ViewComponentAssetsInvoker(
                assetsDescriptorProvider,
                defaultFactory.CreateInstance( context )
            );
        }
    }
}
