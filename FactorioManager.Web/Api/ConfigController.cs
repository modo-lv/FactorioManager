using System;
using System.IO;
using System.Runtime.InteropServices;
using FactorioManager.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Simpler.NetCore.Text;

namespace FactorioManager.Web.Api {
  [Route("api/config")]
  [ApiController]
  public class ConfigController : ControllerBase {
    private readonly IGameReader _game;

    public ConfigController(IGameReader game) {
      this._game = game;
    }

    /// <summary>
    /// Attempt to detect where the game's user folder is.
    /// </summary>
    /// <returns></returns>
    [HttpGet("game_home")]
    public String AutoGameUserHome() {
      return this._game.UserHome.Text();
    }



  }
}