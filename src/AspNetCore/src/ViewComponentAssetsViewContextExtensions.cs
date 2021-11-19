using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BizStream.AspNetCore.ViewComponentAssets
{
    /// <summary> Extensions to <see cref="ViewContext"/> for tracking assets of <see cref="ViewComponent"/>s rendering within the context. </summary>
    public static class ViewComponentAssetsViewContextExtensions
    {
        #region Fields

        /// <summary> The <see cref="ViewContext.TempData"/> Key used to store paths of ViewComponent Scripts. </summary>
        public const string ScriptsKey = "BZS.ViewComponentScripts";
        #endregion

        /// <summary> Add the given <paramref name="paths"/> to the current <paramref name="context"/>. </summary>
        /// <param name="context"> The <see cref="ViewContext"/> to mutate. </param>
        /// <param name="paths"> The paths to add. </param>
        /// <exception cref="ArgumentNullException"/>
        public static void AddViewComponentScripts( this ViewContext context, IEnumerable<PathString> paths )
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

        /// <summary> Get the ViewComponent Script paths from the current <paramref name="context"/>. </summary>
        /// <param name="context"> The <see cref="ViewContext"/> to retrieve script paths from. </param>
        /// <remarks> This method will initialize an empty <see cref="ISet{T}"><c>ISet&lt;string&gt;</c></see> on the context if one does not exist. Will never return <c>null</c>. </remarks>
        /// <exception cref="ArgumentNullException"/>
        public static ISet<string> GetViewComponentScripts( this ViewContext context )
        {
            if( context is null )
            {
                throw new ArgumentNullException( nameof( context ) );
            }

            return ( ISet<string> )( context.TempData[ ScriptsKey ] ??= new SortedSet<string>( StringComparer.OrdinalIgnoreCase ) );
        }
    }
}
