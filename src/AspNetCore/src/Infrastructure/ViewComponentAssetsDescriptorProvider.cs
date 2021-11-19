using System.Collections.Concurrent;
using System.Reflection;
using BizStream.AspNetCore.ViewComponentAssets.Abstractions;
using BizStream.AspNetCore.ViewComponentAssets.Annotations;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace BizStream.AspNetCore.ViewComponentAssets.Infrastructure
{
    public class ViewComponentAssetsDescriptorProvider : IViewComponentAssetsDescriptorProvider
    {
        #region Fields
        private readonly ConcurrentDictionary<string, ViewComponentAssetsDescriptor> descriptors;
        #endregion

        public ViewComponentAssetsDescriptorProvider( )
        {
            descriptors = new ConcurrentDictionary<string, ViewComponentAssetsDescriptor>();
        }

        private static ViewComponentAssetsDescriptor CreateAssetsDescriptor( ViewComponentDescriptor descriptor )
        {
            var assets = descriptor.TypeInfo?.GetCustomAttributes<ViewComponentAssetAttribute>( true )
                ?? Enumerable.Empty<ViewComponentAssetAttribute>();

            return new()
            {
                Scripts = assets.OfType<ViewComponentScriptAttribute>()
                    .Select( asset => asset.Path )
                    .ToList()
            };
        }

        public ViewComponentAssetsDescriptor GetAssetsDescriptor( ViewComponentDescriptor descriptor )
        {
            if( descriptor is null )
            {
                throw new ArgumentNullException( nameof( descriptor ) );
            }

            return descriptors.GetOrAdd( descriptor.Id, ( _, desc ) => CreateAssetsDescriptor( desc ), descriptor );
        }
    }
}
