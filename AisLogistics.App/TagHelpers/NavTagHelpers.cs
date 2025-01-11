using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AisLogistics.App.TagHelpers
{
    public static class NavTagHelperConsts
    {     
        public const string DefaultActivePaneId = "navs-tabs-default";
        public const string ActiveTabId = "ActiveTabId";
    }

    [HtmlTargetElement("nav-left")]
    public class NavLeftTagHelper : TagHelper
    {
        [HtmlAttributeName("id")]
        public string Id { get; set; } = "nav-left-container";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            await base.ProcessAsync(context, output);

            output.TagName = "div";
            output.Attributes.SetAttribute(nameof(Id), Id);
            output.Attributes.Add("class", "nav-align-left");

            //--- ul start ---
            var ulTag = new TagBuilder("ul");
            ulTag.AddCssClass("nav nav-tabs tabs-line border-end");
            ulTag.Attributes.Add("role", "tablist");
            ulTag.InnerHtml.AppendHtml(await output.GetChildContentAsync(false));            

            output.Content.AppendHtml(ulTag);

            //--- ul end ---

            ////--- tab-content start ---
            //var tabContent = new TagBuilder("div");
            //tabContent.AddCssClass("tab-content shadow-none");

            ////   --- active pane start ---
            //var defaultActivePane = new TagBuilder("div");
            //defaultActivePane.AddCssClass("tab-pane fade active show");
            //defaultActivePane.Attributes.Add("id", NavTagHelperConsts.defaultActivePaneId);
            ////   --- active pane end ---

            //output.Content.AppendHtml(defaultActivePane);

            ////---  tab-content end ---

            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }

    /// <summary>
    /// Элемент навигации
    /// </summary>
    [HtmlTargetElement("nav-tab")]
    public class NavTabTagHelper : TagHelper
    {
        //private readonly LinkGenerator _linkGenerator;
        [HtmlAttributeName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Target { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            await base.ProcessAsync(context, output);

            output.TagName = "li";
            output.Attributes.Add("class", "nav-item");

            bool isActiveTabId = Id.Equals(ViewContext.ViewData[NavTagHelperConsts.ActiveTabId]?.ToString(), StringComparison.OrdinalIgnoreCase);

            var navItemTag = new TagBuilder("a");
            navItemTag.Attributes.Add("id", Id);
            navItemTag.AddCssClass("nav-link");
            navItemTag.Attributes.Add("role", "tab");
            navItemTag.Attributes.Add("data-bs-target", $"#{NavTagHelperConsts.DefaultActivePaneId}");
            if (isActiveTabId)
            {
                navItemTag.AddCssClass("active");
                navItemTag.Attributes.Add("style", "color: #5a8dee;");
                navItemTag.Attributes.Add("href", "javascript:void(0);");
            }
            else
            {
                navItemTag.Attributes.Add("href", Target);
            }
            //aTag.Attributes.Add("data-bs-toggle", "tab");
            //aTag.Attributes.Add("aria-controls", NavTagHelperConsts.defaultActivePaneId);
            //aTag.Attributes.Add("aria-selected", isActiveTabId ? "true" : "false");

            // текст внутри
            var childContext = await output.GetChildContentAsync();
            string innerHtml = childContext.GetContent();

            navItemTag.InnerHtml.Append(innerHtml);

            output.Content.AppendHtml(navItemTag);

            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }

    /// <summary>
    /// Навигация вертикально слева
    /// </summary>
    [HtmlTargetElement("navtabs-left")]
    public class NavTabsLeftTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            await base.ProcessAsync(context, output);

            output.TagName = "ul";
            //output.Attributes.SetAttribute(nameof(Id), Id);
            //output.Attributes.Add("class", "nav-align-left");
            output.Attributes.Add("class", "nav nav-tabs tabs-line border-end");
            output.Attributes.Add("role", "tablist");
            output.Content.AppendHtml(await output.GetChildContentAsync(false));

            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }

    /// <summary>
    /// Навигация сверху
    /// </summary>
    [HtmlTargetElement("navtabs-top")]
    public class NavTabsTopTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            await base.ProcessAsync(context, output);

            output.TagName = "ul";
            //output.Attributes.SetAttribute(nameof(Id), Id);
            //output.Attributes.Add("class", "nav-align-left");
            output.Attributes.Add("class", "nav nav-tabs nav-top tabs-line");
            output.Attributes.Add("role", "tablist");
            output.Content.AppendHtml(await output.GetChildContentAsync(false));

            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
