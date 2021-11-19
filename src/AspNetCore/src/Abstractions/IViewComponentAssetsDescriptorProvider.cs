using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace BizStream.AspNetCore.ViewComponentAssets.Abstractions
{
    /// <summary> Describes a service that provides information about a ViewComponent's Static Assets. </summary>
    public interface IViewComponentAssetsDescriptorProvider
    {
        /// <summary> Retrieve a <see cref="ViewComponentAssetsDescriptor"/> of the assets associated with the ViewComponent described by the given <paramref name="descriptor"/>. </summary>
        /// <param name="descriptor"> The <see cref="ViewComponentDescriptor"/> that describes the ViewComponent to retrieve Assets information of. </param>
        ViewComponentAssetsDescriptor GetAssetsDescriptor( ViewComponentDescriptor descriptor );
    }
}
