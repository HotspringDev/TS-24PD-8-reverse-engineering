using System;
using System.Windows.Input;
using JayLib.Localization;
using JayLib.WPF.BasicClass;

namespace T2208.ViewModels
{
	// Token: 0x02000041 RID: 65
	public class CheckBoxItem : NotificationObject
	{
		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000345 RID: 837 RVA: 0x00019D6C File Offset: 0x00017F6C
		// (set) Token: 0x06000346 RID: 838 RVA: 0x00005C75 File Offset: 0x00003E75
		public bool IsChecked
		{
			get
			{
				return this._IsChecked;
			}
			set
			{
				this._IsChecked = value;
				this.OnPropertyChanged<bool>(() => this.IsChecked);
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000347 RID: 839 RVA: 0x00019D84 File Offset: 0x00017F84
		// (set) Token: 0x06000348 RID: 840 RVA: 0x00005CB5 File Offset: 0x00003EB5
		public string Content
		{
			get
			{
				return this._Content;
			}
			set
			{
				this._Content = value;
				this.OnPropertyChanged<string>(() => this.Content);
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000349 RID: 841 RVA: 0x00019D9C File Offset: 0x00017F9C
		// (set) Token: 0x0600034A RID: 842 RVA: 0x00005CF5 File Offset: 0x00003EF5
		public ICommand Command
		{
			get
			{
				return this._Command;
			}
			set
			{
				this._Command = value;
				this.OnPropertyChanged<ICommand>(() => this.Command);
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x0600034B RID: 843 RVA: 0x00019DB4 File Offset: 0x00017FB4
		// (set) Token: 0x0600034C RID: 844 RVA: 0x00005D35 File Offset: 0x00003F35
		public bool IsEnabled
		{
			get
			{
				return this._IsEnabled;
			}
			set
			{
				this._IsEnabled = value;
				this.OnPropertyChanged<bool>(() => this.IsEnabled);
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x0600034D RID: 845 RVA: 0x00005D75 File Offset: 0x00003F75
		// (set) Token: 0x0600034E RID: 846 RVA: 0x00005D7D File Offset: 0x00003F7D
		public int Index { get; set; }

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x0600034F RID: 847 RVA: 0x00005D86 File Offset: 0x00003F86
		// (set) Token: 0x06000350 RID: 848 RVA: 0x00005D8E File Offset: 0x00003F8E
		public string ContentKey
		{
			get
			{
				return this._contentKey;
			}
			set
			{
				this._contentKey = value;
				this.SetContentKey();
			}
		}

		// Token: 0x06000351 RID: 849 RVA: 0x00019DCC File Offset: 0x00017FCC
		private void SetContentKey()
		{
			bool flag = !string.IsNullOrEmpty(this.ContentKey);
			if (flag)
			{
				this.Content = LocalizationManager.GetString(this.ContentKey);
				LocalizationManager.LanguageChangedEvent += this.LocalizationManager_LanguageChangedEvent;
			}
			else
			{
				LocalizationManager.LanguageChangedEvent -= this.LocalizationManager_LanguageChangedEvent;
			}
		}

		// Token: 0x06000352 RID: 850 RVA: 0x00005D9F File Offset: 0x00003F9F
		private void LocalizationManager_LanguageChangedEvent(string lanugage)
		{
			this.Content = LocalizationManager.GetString(this.ContentKey);
		}

		// Token: 0x04000239 RID: 569
		private bool _IsChecked;

		// Token: 0x0400023A RID: 570
		private string _Content;

		// Token: 0x0400023B RID: 571
		private ICommand _Command;

		// Token: 0x0400023C RID: 572
		private bool _IsEnabled = true;

		// Token: 0x0400023D RID: 573
		private string _contentKey;
	}
}
