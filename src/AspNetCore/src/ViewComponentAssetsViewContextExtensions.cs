using Microsoft.AspNetCore.Mvc.Rendering;

namespace BizStream.AspNetCore.ViewComponentAssets
{
    public static class ViewComponentAssetsViewContextExtensions
    {
        #region Fields
        private const string ScriptsKey = "BZS.ViewComponentScripts";
        #endregion

        public static void AddViewComponentScripts( this ViewContext context, IEnumerable<string> paths )
        {
            if( context is null )
            {
                throw new ArgumentNullException( nameof( context ) );
            }

            var scripts = GetViewComponentScripts( context );
            foreach( var path in paths )
            {
                if( !scripts.Contains( path ) )
                {
                    scripts.Add( path );
                }
            }
        }

        public static ISet<string> GetViewComponentScripts( this ViewContext context )
        {
            if( context is null )
            {
                throw new ArgumentNullException( nameof( context ) );
            }

            return ( ISet<string> )( context.TempData[ ScriptsKey ] ??= new HashSet<string>( StringComparer.OrdinalIgnoreCase ) );
        }
    }
}
