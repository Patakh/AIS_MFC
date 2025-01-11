using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;

namespace AisLogistics.App.TagHelpers
{

    public class PdfTagHelper : TagHelper
    {
        public string Src { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "iframe";

            output.Attributes.Add("style", "overflow: hidden;");
            output.Attributes.Add("style", "height:100%;");
            output.Attributes.Add("style", "width:100%;");
            output.Attributes.Add("width", "100%;");
            output.Attributes.Add("height","100%;");
            output.Attributes.Add("src", $"data:application/pdf;base64,{Src}");
        }
    }
}
