using System;
using System.Collections.Generic;
using System.Linq;
using Simpler.NetCore;
using Simpler.NetCore.Text;

namespace FactorioManager.Core.Infrastructure.Notices {
  public interface INoticeBoard {
    /// <summary>
    /// Notices currently on the board.
    /// </summary>
    ICollection<Notice> Notices { get; protected set; }

    /// <summary>
    /// Add a notice to the board.
    /// </summary>
    /// <param name="notice">Notice to add.</param>
    /// <returns>Notice that was added. If adding a persistent notice and one with the same name already exists on the
    /// board, that will be returned instead.</returns>
    Notice Add(Notice notice) {
      Notice? exists = notice.Name.IsBlank()
        ? null
        : this.Notices.SingleOrDefault(_ => _.Name == notice.Name);
      if (exists == null) {
        this.Notices.Add(notice);
      }
      return exists ?? notice;
    }
    
    /// <summary>
    /// Remove (and return) all non-named notices from the board.
    /// Call this to show unread notices to the user and simultaneously remove them from the board. 
    /// </summary>
    /// <returns>List of removed notices.</returns>
    IEnumerable<Notice> RemoveAllTransient() {
      Notice[] transient = this.Notices.Where(_ => _.Name.IsBlank()).ToArray();
      this.Notices = this.Notices.Except(transient).ToHashSet();
      return transient;
    }

    /// <summary>
    /// Remove a persistent (named) notice from the board.
    /// </summary>
    /// <param name="name">Name of the notice to remove.</param>
    /// <returns>Removed notice, or <c>null</c> if there wasn't one.</returns>
    Notice? RemovePersistent(String name) {
      Notice? notice = this.Notices.SingleOrDefault(_ => _.Name == name);
      notice.IfNotNull(n => this.Notices.Remove(n!));
      return notice;
    }
  }
}