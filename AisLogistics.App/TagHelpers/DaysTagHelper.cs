using System.Text.Encodings.Web;
using AisLogistics.App.Utils;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AisLogistics.App.TagHelpers
{
    [HtmlTargetElement("days")]
    public class DaysTagHelper: TagHelper
    {
        //Количество дней
        public int Count { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";

            var content = $"{Count} {DeclensionGenerator.Days(Count)}";
            var color = Count switch
            {
                > 3 => "text-success",
                < 0 => "text-danger",
                _ => "text-warning"
            };
            output.AddClass(color, HtmlEncoder.Default);
            output.Content.SetContent(content);
        }
    }
}