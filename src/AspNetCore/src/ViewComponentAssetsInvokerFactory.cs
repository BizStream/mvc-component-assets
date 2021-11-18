using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace BizStream.AspNetCore.ViewComponentAssets
{
    public class ViewComponentAssetsInvokerFactory : IViewComponentInvokerFactory
    {
        #region Fields
        private readonly IViewComponentInvokerFactory defaultFactory;
        #endregion

        public ViewComponentAssetsInvokerFactory( IViewComponentInvokerFactory defaultFactory )
        {
            if( defaultFactory is null )
            {
                throw new ArgumentNullException( nameof( defaultFactory ) );
            }

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
                defaultFactory.CreateInstance( context )
            );
        }
    }
}
