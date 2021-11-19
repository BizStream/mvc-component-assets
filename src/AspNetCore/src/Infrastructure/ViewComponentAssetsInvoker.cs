using System.Reflection;
using BizStream.AspNetCore.ViewComponentAssets.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace BizStream.AspNetCore.ViewComponentAssets.Infrastructure
{
    /// <summary> Implementation of an <see cref="IViewComponentInvoker"/> that tracks <see cref="ViewComponent"/> assets to the <see cref="ViewComponentContext.ViewContext"/>. </summary>
    public class ViewComponentAssetsInvoker : IViewComponentInvoker
    {
        #region Fields
        private readonly IViewComponentInvoker defaultInvoker;
        #endregion

        public ViewComponentAssetsInvoker( IViewComponentInvoker defaultInvoker )
        {
            if( defaultInvoker is null )
            {
                throw new ArgumentNullException( nameof( defaultInvoker ) );
            }

            this.defaultInvoker = defaultInvoker;
        }

        private static void ExposeViewComponentAssets( ViewComponentContext context )
        {
            context.ViewContext.AddViewComponentScripts(
                GetViewComponentAssetPaths<ViewComponentScriptAttribute>( context.ViewComponentDescriptor )
            );
        }

        private static IEnumerable<PathString> GetViewComponentAssetPaths<TAssetAttribute>( ViewComponentDescriptor descriptor )
            where TAssetAttribute : ViewComponentAssetAttribute
        {
            // TODO: A provider/custom 'Descriptor' that provides caching of reflection/enumerating?
            return descriptor.TypeInfo.GetCustomAttributes<TAssetAttribute>( true )
                .Select( assetAttribute => assetAttribute.Path );
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
