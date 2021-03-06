using System.Net.Http.Headers;
using AngleSharp;
using AngleSharp.Html.Dom;
using AngleSharp.Io;

namespace BizStream.AspNetCore.ViewComponentAssets.Tests.Abstractions
{
    public static class HtmlHelpers
    {
        public static async Task<IHtmlElement?> GetElementAsync( HttpResponseMessage response, CancellationToken cancellation = default )
        {
            var document = await GetDocumentAsync( response, cancellation );
            return document?.Body?.FirstElementChild as IHtmlElement;
        }

        public static async Task<IHtmlDocument?> GetDocumentAsync( HttpResponseMessage response, CancellationToken cancellation = default )
        {
            if( response is null )
            {
                throw new ArgumentNullException( nameof( response ) );
            }

            using var content = await response.Content.ReadAsStreamAsync();
            var document = await BrowsingContext.New()
                .OpenAsync( ResponseFactory, cancellation );

            return document as IHtmlDocument;

            void ResponseFactory( VirtualResponse htmlResponse )
            {
                htmlResponse.Status( response.StatusCode )
                    .Address( response.RequestMessage.RequestUri );

                MapHeaders( response.Headers );
                MapHeaders( response.Content.Headers );

                htmlResponse.Content( content );

                void MapHeaders( HttpHeaders headers )
                {
                    foreach( var header in headers )
                    {
                        foreach( var value in header.Value )
                        {
                            htmlResponse.Header( header.Key, value );
                        }
                    }
                }
            }
        }
    }
}
