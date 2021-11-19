using System.Collections.Concurrent;
using System.Reflection;
using BizStream.AspNetCore.ViewComponentAssets.Abstractions;
using BizStream.AspNetCore.ViewComponentAssets.Annotations;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace BizStream.AspNetCore.ViewComponentAssets.Infrastructure
{
    /// <summary> Default implementation of an <see cref="IViewComponentAssetsDescriptorProvider"/>, based on a <see cref="ConcurrentDictionary{TKey, TValue}"/> for caching reflection. </summary>
    public class ViewComponentAssetsDescriptorProvider : IViewComponentAssetsDescriptorProvider
    {
        #region Fields
        private readonly ConcurrentDictionary<string, ViewComponentAssetsDescriptor> descriptors;
        #endregion

        public ViewComponentAssetsDescriptorProvider( )
        {
            descriptors = new ConcurrentDictionary<string, ViewComponentAssetsDescriptor>();
        }

        private static ViewComponentAssetsDescriptor CreateAssetsDescriptor( string id, ViewComponentDescriptor descriptor )
        {
            if( id != descriptor.Id )
            {
                throw new ArgumentException( $"{nameof( id )} and {nameof( descriptor )}.{nameof( descriptor.Id )} must match." );
            }

            var assets = descriptor.TypeInfo?.GetCustomAttributes<ViewComponentAssetAttribute>( true )
                ?? Enumerable.Empty<ViewComponentAssetAttribute>();

            return new( id )
            {
                Scripts = assets.OfType<ViewComponentScriptAttribute>()
                    .Select( asset => asset.Path )
                    .ToList()
            };
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException"/>
        public ViewComponentAssetsDescriptor GetAssetsDescriptor( ViewComponentDescriptor descriptor )
        {
            if( descriptor is null )
            {
                throw new ArgumentNullException( nameof( descriptor ) );
            }

            return descriptors.GetOrAdd( descriptor.Id, CreateAssetsDescriptor, descriptor );
        }
    }
}
