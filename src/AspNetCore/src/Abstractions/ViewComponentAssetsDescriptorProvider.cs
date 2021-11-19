using Microsoft.AspNetCore.Http;

namespace BizStream.AspNetCore.ViewComponentAssets.Abstractions
{
    public class ViewComponentAssetsDescriptor
    {
        public IReadOnlyList<PathString> Scripts { get; set; } = new List<PathString>();
    }
}
