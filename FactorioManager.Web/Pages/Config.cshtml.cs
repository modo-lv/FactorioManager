using System;
using FactorioManager.Core.Infrastructure;
using FactorioManager.Core.Main.Data;
using FactorioManager.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FactorioManager.Web.Pages {
  public class Config : PageModel, IPageWithTitle {

    private readonly IUserConfigManager _userConfigManager;
    
    public Config(IUserConfigManager userConfigManager) {
      this._userConfigManager = userConfigManager;
    }

    public String PageTitle { get; } = "Config";

    [BindProperty]
    public UserConfig? UserConfig { get; set; }
    
    
    public void OnGetAsync() {
      this.UserConfig = this._userConfigManager.Load();
    }

    public void OnPostAsync() {
      if (this.UserConfig != null) {
        this._userConfigManager.Save(this.UserConfig);
      }
    }

  }
}