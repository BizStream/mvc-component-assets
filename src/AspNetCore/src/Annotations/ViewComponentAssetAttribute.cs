using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizStream.AspNetCore.ViewComponentAssets.Annotations
{
    /// <summary> Base class for an attribute that annotates a <see cref="ViewComponent"/> with an association to a static asset. </summary>
    [AttributeUsage( AttributeTargets.Class )]
    public abstract class ViewComponentAssetAttribute : Attribute
    {
        #region Fields
        private readonly string path;
        #endregion

        #region Properties

        /// <summary> The absolute path of the script asset. </summary>
        public PathString Path => path;
        #endregion

        protected ViewComponentAssetAttribute( string path )
        {
            if( string.IsNullOrEmpty( path ) || path == "/" )
            {
                throw new ArgumentNullException( nameof( path ) );
            }

            this.path = path;
        }
    }
}
