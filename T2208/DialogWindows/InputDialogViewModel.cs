using System;
using T2208.ViewModels.Base;

namespace T2208.DialogWindows
{
	// Token: 0x020000AD RID: 173
	public class InputDialogViewModel : BaseViewModel
	{
		// Token: 0x1700030D RID: 781
		// (get) Token: 0x0600087E RID: 2174 RVA: 0x00009D26 File Offset: 0x00007F26
		// (set) Token: 0x0600087F RID: 2175 RVA: 0x00009D2E File Offset: 0x00007F2E
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				base.SetProperty<string>(ref this._name, value, "Name");
			}
		}

		// Token: 0x1700030E RID: 782
		// (get) Token: 0x06000880 RID: 2176 RVA: 0x00009D43 File Offset: 0x00007F43
		// (set) Token: 0x06000881 RID: 2177 RVA: 0x00009D4B File Offset: 0x00007F4B
		public string Title
		{
			get
			{
				return this._title;
			}
			set
			{
				base.SetProperty<string>(ref this._title, value, "Title");
			}
		}

		// Token: 0x1700030F RID: 783
		// (get) Token: 0x06000882 RID: 2178 RVA: 0x00009D60 File Offset: 0x00007F60
		// (set) Token: 0x06000883 RID: 2179 RVA: 0x00009D68 File Offset: 0x00007F68
		public string HintName
		{
			get
			{
				return this._hintName;
			}
			set
			{
				base.SetProperty<string>(ref this._hintName, value, "HintName");
			}
		}

		// Token: 0x040004A6 RID: 1190
		private string _name;

		// Token: 0x040004A7 RID: 1191
		private string _title;

		// Token: 0x040004A8 RID: 1192
		private string _hintName;
	}
}
