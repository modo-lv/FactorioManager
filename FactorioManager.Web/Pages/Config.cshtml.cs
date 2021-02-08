using System;
using FactorioManager.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FactorioManager.Web.Pages {
  public class Config : PageModel, IPageWithTitle {

    public String PageTitle { get; } = "Config";

    public void OnGet() {
    }

  }
}