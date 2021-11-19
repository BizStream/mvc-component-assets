using BizStream.AspNetCore.ViewComponentAssets.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace BizStream.AspNetCore.ViewComponentAssets.Abstractions
{
    /// <summary> Represents information about a <see cref="ViewComponent"/>'s static assets, as annotated via <see cref="ViewComponentAssetAttribute"/>s. </summary>
    public class ViewComponentAssetsDescriptor
    {
        #region Fields
        private readonly string id;
        #endregion

        #region Properties

        /// <summary> Gets the <see cref="ViewComponentDescriptor.Id"/>. </summary>
        public string Id => id;

        /// <summary> Get or sets the list of scripts paths.  </summary>
        public IReadOnlyList<PathString> Scripts { get; set; } = default!;
        #endregion

        public ViewComponentAssetsDescriptor( string id )
        {
            this.id = id;
        }
    }
}
