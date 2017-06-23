using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyAlcoholShelf.Web.Tags.Fom
{
    [HtmlTargetElement("asf:textarea")]
    public class AsfTextarea : AsfInput
    {
        public int Rows { get; set; } = 5;
        public int Columns { get; set; } = 5;
        public AsfTextarea(IHtmlGenerator generator) : base(generator)
        {
        }

        protected override void GenerateInputElement(TagHelperContext context, TagHelperOutput output)
        {
            var textarea = Generator.GenerateTextArea(
                viewContext: ViewContext, 
                modelExplorer: AspFor.ModelExplorer, 
                expression: AspFor.Name, 
                rows: Rows, 
                columns: Columns, 
                htmlAttributes: null);
            textarea.Attributes.Add("class", "form-control");
            output.Content.AppendHtml(textarea);
        }
    }
}