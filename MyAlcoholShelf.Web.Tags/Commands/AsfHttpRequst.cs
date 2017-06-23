using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MyAlcoholShelf.Web.Tags.Commands
{
    [HtmlTargetElement("asf:http-request")]
    public class AsfHttpRequst : TagHelper
    {
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        
        public string Url { get; set; }
        public string Done { get; set; }
        public string AnchorId { get; set; }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            return base.ProcessAsync(context, output);
           
            
            
        }
    }
}
