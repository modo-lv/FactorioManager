using FactorioManager.Core.Infrastructure.Notices;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FactorioManager.Web.Pages {
  public class IndexModel : PageModel {
    private readonly INoticeBoard _nb;
    
    public IndexModel(INoticeBoard nb) {
      this._nb = nb;
    }

    public void OnGet() {
      this._nb.Add(new Notice("Test"));
    }
  }
}