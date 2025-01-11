using AisLogistics.App.Models;
using AisLogistics.App.Utils;
using AisLogistics.App.ViewModels.ModelBuilder;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AisLogistics.App.TagHelpers
{
    [HtmlTargetElement("table", Attributes = ForAttributeName)]
    [HtmlTargetElement("table", Attributes = AccessAttributeName)]
    public class TableTagHelper : TagHelper
    {
        private IActionContextAccessor _actionContextAccessor;
        public TableTagHelper(IActionContextAccessor actionContextAccessor)
        {
            _actionContextAccessor = actionContextAccessor;
        }
        private const string ForAttributeName = "asp-for";
        private const string AccessAttributeName = "asp-access-key-name";
        public override int Order => -1000;

        [HtmlAttributeName(ForAttributeName)]
        public ViewModelBuilder For { get; set; }

        [HtmlAttributeName(AccessAttributeName)]
        public string AccessKeyName { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            if (_actionContextAccessor.ActionContext.HttpContext.User.HasClaim(AccessKeyName, AccessKeyValues.View) == false)
            {
                output.TagName = "div";
                output.Content.SetHtmlContent("<div class=\"alert alert-danger my-3\" role=\"alert\"><h6 class=\"alert-heading mb-1\">Внимание!</h6>У Вас нет прав для просмотра !</div>");
                return;
            }

            IDictionary<string, object> htmlAttributes = null;
            if (string.IsNullOrEmpty(ViewContext.ViewData.TemplateInfo.HtmlFieldPrefix) &&
                !string.IsNullOrEmpty(For.TableName))
            {
                htmlAttributes = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
                {
                    { "name", For.TableName },
                    { "id", For.TableName },
                    { "data-action-table", For.TableMethodAction },
                };
            }

            if (_actionContextAccessor.ActionContext is not null)
            {
                if (_actionContextAccessor.ActionContext.HttpContext.User.HasClaim(AccessKeyName, AccessKeyValues.Add) &&
                    For.EditMethodAction is not null)
                {
                    htmlAttributes?.Add("data-action-add", For.EditMethodAction);
                }

                if (_actionContextAccessor.ActionContext.HttpContext.User.HasClaim(AccessKeyName, AccessKeyValues.Edit) &&
                    For.EditMethodAction is not null)
                {
                    htmlAttributes?.Add("data-action-edit", For.EditMethodAction);
                }

                if (_actionContextAccessor.ActionContext.HttpContext.User.HasClaim(AccessKeyName, AccessKeyValues.Remove) &&
                    For.RemoveMethodAction is not null)
                {
                    htmlAttributes?.Add("data-action-remove", For.RemoveMethodAction);
                }
            }

            if (htmlAttributes is null) return;
            foreach (var (key, value) in htmlAttributes)
                output.Attributes.SetAttribute(key, value);
        }
    }
}