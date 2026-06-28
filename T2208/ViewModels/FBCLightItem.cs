using System;
using JayLib.WPF.BasicClass;

namespace T2208.ViewModels
{
	// Token: 0x02000035 RID: 53
	public class FBCLightItem : NotificationObject
	{
		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x0600022A RID: 554 RVA: 0x00015204 File Offset: 0x00013404
		// (set) Token: 0x0600022B RID: 555 RVA: 0x00004E20 File Offset: 0x00003020
		public int LightStatus
		{
			get
			{
				return this._LightStatus;
			}
			set
			{
				this._LightStatus = value;
				this.OnPropertyChanged<int>(() => this.LightStatus);
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x0600022C RID: 556 RVA: 0x0001521C File Offset: 0x0001341C
		// (set) Token: 0x0600022D RID: 557 RVA: 0x00004E60 File Offset: 0x00003060
		public int BlinkLightStatus
		{
			get
			{
				return this._BlinkLightStatus;
			}
			set
			{
				this._BlinkLightStatus = value;
				this.OnPropertyChanged<int>(() => this.BlinkLightStatus);
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x0600022E RID: 558 RVA: 0x00015234 File Offset: 0x00013434
		// (set) Token: 0x0600022F RID: 559 RVA: 0x00004EA0 File Offset: 0x000030A0
		public bool IsBlink
		{
			get
			{
				return this._IsBlink;
			}
			set
			{
				this._IsBlink = value;
				this.OnPropertyChanged<bool>(() => this.IsBlink);
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000230 RID: 560 RVA: 0x0001524C File Offset: 0x0001344C
		// (set) Token: 0x06000231 RID: 561 RVA: 0x00004EE0 File Offset: 0x000030E0
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

		// Token: 0x04000114 RID: 276
		private int _LightStatus;

		// Token: 0x04000115 RID: 277
		private int _BlinkLightStatus;

		// Token: 0x04000116 RID: 278
		private bool _IsBlink;

		// Token: 0x04000117 RID: 279
		private string _Content;
	}
}
