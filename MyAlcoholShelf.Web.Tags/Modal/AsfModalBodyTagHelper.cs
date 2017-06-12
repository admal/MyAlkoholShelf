using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyAlcoholShelf.Web.Tags.Modal
{
    [HtmlTargetElement("asf:modal-body", ParentTag = "asf:modal")]
    public class AsfModalBodyTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var modalContext = (ModalContext)context.Items[typeof(AsfModalTagHelper)];
            modalContext.Body = childContent;
            output.SuppressOutput();
        }
    }
}