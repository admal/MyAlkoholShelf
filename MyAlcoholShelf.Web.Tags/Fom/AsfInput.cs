using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyAlcoholShelf.Web.Tags.Fom
{
    public abstract class AsfInput : TagHelper
    {
        protected AsfInput(IHtmlGenerator generator)
        {
            Generator = generator;
        }

        protected const string ForAttributeName = "asp-for";
        
        public string Class { get; set; }
        
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        
        protected IHtmlGenerator Generator { get; }
        
        [HtmlAttributeName("asp-for")]
        public ModelExpression AspFor { get; set; }
        
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            var forInput = AspFor.Name;
            output.Attributes.Add("class", $"form-group {Class}");
            var labelTagBuilder = this.Generator.GenerateLabel(
                viewContext: ViewContext, 
                modelExplorer: AspFor.ModelExplorer, 
                expression: AspFor.Name, 
                labelText: (string) null, 
                htmlAttributes: null);
            
            output.Content.AppendHtml(labelTagBuilder);
            output.TagMode = TagMode.StartTagAndEndTag;
            GenerateInputElement(context, output);
            await base.ProcessAsync(context, output);
        }
        
        /// <summary>
        /// Method that generates input element.
        /// It is called in ProcessAsync method.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        protected abstract void GenerateInputElement(TagHelperContext context, TagHelperOutput output);
    }
}