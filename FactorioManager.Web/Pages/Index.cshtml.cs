using System;
using FactorioManager.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FactorioManager.Web.Pages {
  public class IndexModel : PageModel, IPageWithTitle {
    public String PageTitle { get; } = "Welcome";
    public void OnGet() {
    }

  }
}