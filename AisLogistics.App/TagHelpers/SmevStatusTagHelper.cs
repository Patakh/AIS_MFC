using AisLogistics.App.Settings;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;

namespace AisLogistics.App.TagHelpers
{
    [HtmlTargetElement("smev-status")]
    public class SmevStatusTagHelper : TagHelper
    {
        //id статуса
        public int Status { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";

            var (name, className) = (SmevStatusType)Status switch
            {
                SmevStatusType.Expired => ("Просрочено", "bg-label-danger"),
                SmevStatusType.Sent => ("Отправлено", "bg-label-warning"),
                SmevStatusType.Error => ("Ошибка", "bg-label-danger"),
                SmevStatusType.ResponseSuccess => ("Получен ответ", "bg-label-success"),
                _ => ("Неизвестно", "bg-label-warning")
            };

            output.AddClass("badge", HtmlEncoder.Default);
            output.AddClass("me-1", HtmlEncoder.Default);
            output.AddClass(className, HtmlEncoder.Default);
            output.Content.SetContent(name);
        }
    }
}