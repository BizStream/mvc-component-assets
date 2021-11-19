using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizStream.AspNetCore.ViewComponentAssets
{
    /// <summary> Annotates a <see cref="ViewComponent"/> with an associating to a static JavaScript asset. </summary>
    [AttributeUsage( AttributeTargets.Class )]
    public class ViewComponentScriptAttribute : Attribute
    {
        #region Fields
        private readonly string path;
        #endregion

        #region Properties
        public PathString Path => path;
        #endregion

        public ViewComponentScriptAttribute( string path )
        {
            if( string.IsNullOrEmpty( path ) || path == "/" )
            {
                throw new ArgumentNullException( nameof( path ) );
            }

            this.path = path;
        }
    }
}