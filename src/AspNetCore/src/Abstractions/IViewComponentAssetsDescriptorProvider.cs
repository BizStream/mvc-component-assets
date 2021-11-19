using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace BizStream.AspNetCore.ViewComponentAssets.Abstractions
{
    public interface IViewComponentAssetsDescriptorProvider
    {
        ViewComponentAssetsDescriptor GetAssetsDescriptor( ViewComponentDescriptor descriptor );
    }
}
