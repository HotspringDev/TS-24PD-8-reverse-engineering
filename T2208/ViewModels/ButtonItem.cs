using System;
using System.Windows.Input;
using JayLib.Localization;
using JayLib.WPF.BasicClass;

namespace T2208.ViewModels
{
	// Token: 0x02000034 RID: 52
	public class ButtonItem : NotificationObject
	{
		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x0600021F RID: 543 RVA: 0x00004D02 File Offset: 0x00002F02
		// (set) Token: 0x06000220 RID: 544 RVA: 0x00004D0A File Offset: 0x00002F0A
		public string Content { get; set; }

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000221 RID: 545 RVA: 0x00004D13 File Offset: 0x00002F13
		// (set) Token: 0x06000222 RID: 546 RVA: 0x00004D1B File Offset: 0x00002F1B
		public ICommand Command
		{
			get
			{
				return this._command;
			}
			set
			{
				this._command = value;
				this.OnPropertyChanged<ICommand>(() => this.Command);
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000223 RID: 547 RVA: 0x000151D4 File Offset: 0x000133D4
		// (set) Token: 0x06000224 RID: 548 RVA: 0x00004D5B File Offset: 0x00002F5B
		public string NotificationContent
		{
			get
			{
				return this._NotificationContent;
			}
			set
			{
				this._NotificationContent = value;
				this.OnPropertyChanged<string>(() => this.NotificationContent);
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000225 RID: 549 RVA: 0x000151EC File Offset: 0x000133EC
		// (set) Token: 0x06000226 RID: 550 RVA: 0x00004D9B File Offset: 0x00002F9B
		public bool IsSelected
		{
			get
			{
				return this._IsSelected;
			}
			set
			{
				this._IsSelected = value;
				this.OnPropertyChanged<bool>(() => this.IsSelected);
			}
		}

		// Token: 0x06000227 RID: 551 RVA: 0x000047E7 File Offset: 0x000029E7
		public ButtonItem()
		{
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00004DDB File Offset: 0x00002FDB
		public ButtonItem(string contentKey)
		{
			this._ContentKey = contentKey;
			this.NotificationContent = LocalizationManager.GetString(contentKey);
			LocalizationManager.LanguageChangedEvent += this.LocalizationManager_LanguageChangedEvent;
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00004E0B File Offset: 0x0000300B
		private void LocalizationManager_LanguageChangedEvent(string lanugage)
		{
			this.NotificationContent = LocalizationManager.GetString(this._ContentKey);
		}

		// Token: 0x04000110 RID: 272
		private string _NotificationContent;

		// Token: 0x04000111 RID: 273
		private bool _IsSelected;

		// Token: 0x04000112 RID: 274
		private string _ContentKey;

		// Token: 0x04000113 RID: 275
		private ICommand _command;
	}
}
