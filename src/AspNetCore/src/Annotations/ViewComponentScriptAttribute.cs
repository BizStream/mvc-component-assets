using Microsoft.AspNetCore.Mvc;

namespace BizStream.AspNetCore.ViewComponentAssets.Annotations
{
    /// <summary> Annotates a <see cref="ViewComponent"/> with an association to a static JavaScript asset. </summary>
    public class ViewComponentScriptAttribute : ViewComponentAssetAttribute
    {
        public ViewComponentScriptAttribute( string path )
            : base( path )
        {
        }
    }
}