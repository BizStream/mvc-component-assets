using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace BizStream.AspNetCore.ViewComponentAssets
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

        // TODO: A provider/custom 'Descriptor' that provides caching of reflection/enumerating?
        private static void AddViewComponentScripts( ViewComponentContext context )
        {
            var scriptAttributes = context.ViewComponentDescriptor.TypeInfo.GetCustomAttributes<ViewComponentScriptAttribute>();
            if( scriptAttributes?.Any() is true )
            {
                context.ViewContext.AddViewComponentScripts(
                    scriptAttributes.Select( bundleAttribute => bundleAttribute.Path )
                );
            }
        }

        /// <inheritdoc/>
        public async Task InvokeAsync( ViewComponentContext context )
        {
            if( context is null )
            {
                throw new ArgumentNullException( nameof( context ) );
            }

            await defaultInvoker.InvokeAsync( context );

            AddViewComponentScripts( context );
        }
    }
}
