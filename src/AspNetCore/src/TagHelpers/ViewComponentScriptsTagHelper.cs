using BizStream.AspNetCore.ViewComponentAssets.Infrastructure;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BizStream.AspNetCore.ViewComponentAssets.TagHelpers
{
    /// <summary> A <see cref="TagHelper"/> that provides a custom HTML element that renders <c>script</c> elements for any <see cref="ViewComponent"/>s that have been rendered thus far. </summary>
    [HtmlTargetElement( TagName, TagStructure = TagStructure.WithoutEndTag )]
    public class ViewComponentScriptsTagHelper : TagHelper
    {
        #region Properties

        /// <summary> The HTML Tag name used by this TagHelper. </summary>
        public const string TagName = "view-component-scripts";

        /// <summary> The current <see cref="ViewContext"/>. </summary>
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; } = default!;
        #endregion

        /// <inheritdoc/>
        public override void Process( TagHelperContext context, TagHelperOutput output )
        {
            output.TagName = string.Empty;

            var scripts = ViewContext.GetViewComponentScripts();
            if( scripts?.Any() is true )
            {
                foreach( var path in scripts )
                {
                    var script = new TagBuilder( "script" );
                    script.Attributes.Add( "src", path );

                    output.Content.AppendLine( script );
                }
            }
        }
    }
}
