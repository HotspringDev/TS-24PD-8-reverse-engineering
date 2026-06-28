using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using JayLib.Localization;
using JayLib.WPF.BasicClass;

namespace T2208
{
	// Token: 0x02000011 RID: 17
	public class PageItem : NotificationObject
	{
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000076 RID: 118 RVA: 0x0000BC98 File Offset: 0x00009E98
		// (set) Token: 0x06000077 RID: 119 RVA: 0x00003BB8 File Offset: 0x00001DB8
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				this._Name = value;
				this.OnPropertyChanged<string>(() => this.Name);
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000078 RID: 120 RVA: 0x0000BCB0 File Offset: 0x00009EB0
		// (set) Token: 0x06000079 RID: 121 RVA: 0x00003BF8 File Offset: 0x00001DF8
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

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600007A RID: 122 RVA: 0x0000BCC8 File Offset: 0x00009EC8
		// (set) Token: 0x0600007B RID: 123 RVA: 0x00003C38 File Offset: 0x00001E38
		public Page Page
		{
			get
			{
				return this._Page;
			}
			set
			{
				this._Page = value;
				this.OnPropertyChanged<Page>(() => this.Page);
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600007C RID: 124 RVA: 0x0000BCE0 File Offset: 0x00009EE0
		// (set) Token: 0x0600007D RID: 125 RVA: 0x00003C78 File Offset: 0x00001E78
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

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600007E RID: 126 RVA: 0x00003CB8 File Offset: 0x00001EB8
		// (set) Token: 0x0600007F RID: 127 RVA: 0x00003CC0 File Offset: 0x00001EC0
		public string NameKey { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00003CC9 File Offset: 0x00001EC9
		// (set) Token: 0x06000081 RID: 129 RVA: 0x00003CD1 File Offset: 0x00001ED1
		public List<byte> DevicePageIndex { get; set; } = new List<byte>();

		// Token: 0x06000082 RID: 130 RVA: 0x00003CDA File Offset: 0x00001EDA
		public PageItem()
		{
			LocalizationManager.LanguageChangedEvent += this.LocalizationManager_LanguageChangedEvent;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00003D01 File Offset: 0x00001F01
		private void LocalizationManager_LanguageChangedEvent(string lanugage)
		{
			this.Name = LocalizationManager.GetString(this.NameKey);
		}

		// Token: 0x04000045 RID: 69
		private string _Name;

		// Token: 0x04000046 RID: 70
		private ICommand _Command;

		// Token: 0x04000047 RID: 71
		private Page _Page;

		// Token: 0x04000048 RID: 72
		private bool _IsChecked;
	}
}
