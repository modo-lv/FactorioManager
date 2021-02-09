using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Simpler.NetCore.Text;

/*
 * From https://gist.github.com/DanElliott/32787b4ae1941780d70cb085d55f8b24
 */
namespace FactorioManager.Web.TagHelpers {
  [HtmlTargetElement(Attributes = "active-in-page")]
  public class ActivePageTagHelper : TagHelper {
    /// <summary>Path to the Razor page in which this element should be <c>.active</c>.</summary>
    [HtmlAttributeName("active-in-page")]
    public String? Page { get; set; }

    [HtmlAttributeNotBound]
    [ViewContext]
    public ViewContext? ViewContext { get; set; }


    public override void Process(TagHelperContext context, TagHelperOutput output) {
      base.Process(context, output);

      if (this.ShouldBeActive()) {
        MakeActive(output);
      }

      output.Attributes.RemoveAll("active-in-page");
    }

    private Boolean ShouldBeActive() {
      String currentPage = (this.ViewContext?.RouteData.Values["Page"]?.ToString()).Text();

      // ReSharper disable once SpecifyStringComparison
      return String.IsNullOrWhiteSpace(this.Page) || this.Page.ToLower() == currentPage.ToLower();
    }

    private static void MakeActive(TagHelperOutput output) {
      TagHelperAttribute? classAttr = output.Attributes.FirstOrDefault(a => a.Name == "class");
      if (classAttr == null) {
        classAttr = new TagHelperAttribute("class", "active");
        output.Attributes.Add(classAttr);
      }
      else switch (classAttr.Value) {
        case null:
          output.Attributes.SetAttribute("class", "active");
          break;
        case String s:
          output.Attributes.SetAttribute("class", s + " active");
          break;
      }
    }
  }
}