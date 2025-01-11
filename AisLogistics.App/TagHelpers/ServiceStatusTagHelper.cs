using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;

namespace AisLogistics.App.TagHelpers
{
    [HtmlTargetElement("service-status")]
    public class ServiceStatusTagHelper : TagHelper
    {
        //id статуса
        public int Status { get; set; }
        public string Name { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            var className = Status switch
            {
                0 => "bg-warning",
                1 => "bg-success",
                2 => "bg-danger",
                3 => "bg-danger",
                4 => "bg-danger",
                5 => "bg-danger",
                6 => "bg-warning",
                _ => "bg-warning"
            };

            output.AddClass("badge", HtmlEncoder.Default);
            output.AddClass("p-2", HtmlEncoder.Default);
            output.AddClass(className, HtmlEncoder.Default);
            output.Content.SetContent(Name);
        }
    }
}
