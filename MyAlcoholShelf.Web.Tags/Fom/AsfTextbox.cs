using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace MyAlcoholShelf.Web.Tags.Fom
{
    [HtmlTargetElement("asf:textbox", Attributes = "asp-for")]
    public class AsfTextbox : AsfInput
    {
        public AsfTextbox(IHtmlGenerator generator) : base(generator)
        {
        }

        protected override void GenerateInputElement(TagHelperContext context, TagHelperOutput output)
        {
            var inputTagBuilder = this.Generator.GenerateTextBox(
                viewContext: ViewContext, 
                modelExplorer: AspFor.ModelExplorer, 
                expression: AspFor.Name,
                value: (string) null,
                format: null,
                htmlAttributes: new Dictionary<string, object>(){{"class", "form-control"}});
            output.Content.AppendHtml(inputTagBuilder);
        }

    }
}