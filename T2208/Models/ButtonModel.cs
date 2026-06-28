using System;
using System.Windows.Input;
using JayLib.Localization;
using T2208.ViewModels.Base;

namespace T2208.Models
{
	// Token: 0x0200008F RID: 143
	public class ButtonModel : BaseViewModel
	{
		// Token: 0x060007AF RID: 1967 RVA: 0x00024738 File Offset: 0x00022938
		public ButtonModel(string contentKey)
		{
			ButtonModel <>4__this = this;
			this.Content = LocalizationManager.GetString(contentKey);
			LocalizationManager.LanguageChangedEvent += delegate(string _)
			{
				<>4__this.Content = LocalizationManager.GetString(contentKey);
			};
		}

		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x060007B0 RID: 1968 RVA: 0x00008F58 File Offset: 0x00007158
		// (set) Token: 0x060007B1 RID: 1969 RVA: 0x00008F60 File Offset: 0x00007160
		public string Content
		{
			get
			{
				return this._content;
			}
			set
			{
				base.SetProperty<string>(ref this._content, value, "Content");
			}
		}

		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x060007B2 RID: 1970 RVA: 0x00008F75 File Offset: 0x00007175
		// (set) Token: 0x060007B3 RID: 1971 RVA: 0x00008F7D File Offset: 0x0000717D
		public ICommand Command
		{
			get
			{
				return this._command;
			}
			set
			{
				base.SetProperty<ICommand>(ref this._command, value, "Command");
			}
		}

		// Token: 0x170002CA RID: 714
		// (get) Token: 0x060007B4 RID: 1972 RVA: 0x00008F92 File Offset: 0x00007192
		// (set) Token: 0x060007B5 RID: 1973 RVA: 0x00008F9A File Offset: 0x0000719A
		public bool IsSelected
		{
			get
			{
				return this._isSelected;
			}
			set
			{
				base.SetProperty<bool>(ref this._isSelected, value, "IsSelected");
			}
		}

		// Token: 0x04000445 RID: 1093
		private ICommand _command;

		// Token: 0x04000446 RID: 1094
		private string _content;

		// Token: 0x04000447 RID: 1095
		private bool _isSelected;
	}
}
