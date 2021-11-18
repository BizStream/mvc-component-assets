using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BizStream.AspNetCore.ViewComponentAssets
{
    [HtmlTargetElement( TagName, TagStructure = TagStructure.WithoutEndTag )]
    public class ViewComponentScriptsTagHelper : TagHelper
    {
        #region Properties
        public const string TagName = "view-component-scripts";

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; } = default!;
        #endregion

        /// <inheritdoc/>
        public override void Process( TagHelperContext context, TagHelperOutput output )
        {
            output.TagName = string.Empty;

            var scriptPaths = ViewContext.GetViewComponentScripts();
            if( scriptPaths?.Any() is true )
            {
                foreach( var path in scriptPaths )
                {
                    var script = new TagBuilder( "script" );
                    script.Attributes.Add( "src", path );

                    output.Content.AppendLine( script );
                }
            }
        }
    }
}
