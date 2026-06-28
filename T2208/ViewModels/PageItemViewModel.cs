using System;
using System.Windows.Controls;
using JayLib.Localization;
using JayLib.WPF.BasicClass;

namespace T2208.ViewModels
{
	// Token: 0x0200003B RID: 59
	public class PageItemViewModel : NotificationObject
	{
		// Token: 0x06000280 RID: 640 RVA: 0x000051F9 File Offset: 0x000033F9
		public PageItemViewModel(string headerKey, string header, UserControl pageContent)
		{
			this.HeaderKey = headerKey;
			this.Header = LocalizationManager.GetString(this.HeaderKey);
			this.PageContent = pageContent;
			LocalizationManager.LanguageChangedEvent += this.LocalizationManager_LanguageChangedEvent;
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000281 RID: 641 RVA: 0x00005236 File Offset: 0x00003436
		private string HeaderKey { get; }

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000282 RID: 642 RVA: 0x0000523E File Offset: 0x0000343E
		// (set) Token: 0x06000283 RID: 643 RVA: 0x00005246 File Offset: 0x00003446
		public UserControl PageContent
		{
			get
			{
				return this._myPageContent;
			}
			set
			{
				this._myPageContent = value;
				this.OnPropertyChanged("PageContent");
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000284 RID: 644 RVA: 0x0000525C File Offset: 0x0000345C
		// (set) Token: 0x06000285 RID: 645 RVA: 0x00005264 File Offset: 0x00003464
		public string Header
		{
			get
			{
				return this._header;
			}
			set
			{
				this._header = value;
				this.OnPropertyChanged("Header");
			}
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0000527A File Offset: 0x0000347A
		private void LocalizationManager_LanguageChangedEvent(string language)
		{
			this.Header = LocalizationManager.GetString(this.HeaderKey);
		}

		// Token: 0x040001DD RID: 477
		private string _header;

		// Token: 0x040001DE RID: 478
		private UserControl _myPageContent;
	}
}
