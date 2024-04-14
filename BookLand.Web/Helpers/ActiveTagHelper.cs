using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.IdentityModel.Tokens;

namespace Bookify.Web.Helpers;

[HtmlTargetElement("a", Attributes = "active-when")]
public class ActiveTagHelper : TagHelper
{
    public string? ActiveWhen { get; set; }

    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext? ViewContextData { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (ActiveWhen.IsNullOrEmpty())
            return;

        var currentController = ViewContextData?.RouteData.Values["controller"]?.ToString();

        if (currentController!.Equals(ActiveWhen))
        {
            if (output.Attributes.ContainsName("class"))
                output.Attributes.SetAttribute("class", $"{output.Attributes["class"].Value} active");
            else
                output.Attributes.SetAttribute("class", "active");
        }
    }
}