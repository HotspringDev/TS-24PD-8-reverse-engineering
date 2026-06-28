using System;
using T2208.ViewModels.Base;

namespace T2208.Models
{
	// Token: 0x0200009E RID: 158
	public class PostPre : BaseViewModel
	{
		// Token: 0x17000305 RID: 773
		// (get) Token: 0x0600083C RID: 2108 RVA: 0x00009B3B File Offset: 0x00007D3B
		// (set) Token: 0x0600083D RID: 2109 RVA: 0x00009B43 File Offset: 0x00007D43
		public bool IsAllPost
		{
			get
			{
				return this._isAllPost;
			}
			set
			{
				base.SetProperty<bool>(ref this._isAllPost, value, "IsAllPost");
			}
		}

		// Token: 0x04000489 RID: 1161
		private bool _isAllPost;
	}
}
