using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyAlcoholShelf.Web.Tags.Modal
{
    [HtmlTargetElement("asf:open-modal-button")]
    public class AsfOpenModalButton : TagHelper
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public object Data { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var contextId = "\"" + context.UniqueId + "\"";

            var template = $@"
            <asf:modal id='{context.UniqueId}'
                        title='{Title}'>
            </asf:modal>    
                
            <a class='btn btn-primary btn-lg'
                data-ajax-begin='showModal({contextId})'
                asp-action='{Action}' 
                asp-controller='{Controller}' 
                data-ajax='true' 
                data-ajax-method='GET' 
                data-ajax-update='{'#' + context.UniqueId}'>
                            {Text}
            </a>";

            output.Content.AppendHtml(template);
        }
    }
}
