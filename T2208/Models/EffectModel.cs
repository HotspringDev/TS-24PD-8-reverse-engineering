using System;
using JayLib.WPF.BasicClass;

namespace T2208.Models
{
	// Token: 0x02000097 RID: 151
	public class EffectModel : NotificationObject
	{
		// Token: 0x170002EA RID: 746
		// (get) Token: 0x060007FC RID: 2044 RVA: 0x000094F5 File Offset: 0x000076F5
		// (set) Token: 0x060007FD RID: 2045 RVA: 0x000094FD File Offset: 0x000076FD
		public int DefaultEffectValue { get; set; }

		// Token: 0x170002EB RID: 747
		// (get) Token: 0x060007FE RID: 2046 RVA: 0x00009506 File Offset: 0x00007706
		// (set) Token: 0x060007FF RID: 2047 RVA: 0x0000950E File Offset: 0x0000770E
		public int EffectIndex { get; set; }

		// Token: 0x170002EC RID: 748
		// (get) Token: 0x06000800 RID: 2048 RVA: 0x00009517 File Offset: 0x00007717
		// (set) Token: 0x06000801 RID: 2049 RVA: 0x0000951F File Offset: 0x0000771F
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
				this.OnPropertyChanged<string>(() => this.Name);
			}
		}

		// Token: 0x170002ED RID: 749
		// (get) Token: 0x06000802 RID: 2050 RVA: 0x0000955F File Offset: 0x0000775F
		// (set) Token: 0x06000803 RID: 2051 RVA: 0x00009567 File Offset: 0x00007767
		public string[] EffectValueCollection
		{
			get
			{
				return this._effectValueCollection;
			}
			set
			{
				this._effectValueCollection = value;
				this.OnPropertyChanged<string[]>(() => this.EffectValueCollection);
			}
		}

		// Token: 0x170002EE RID: 750
		// (get) Token: 0x06000804 RID: 2052 RVA: 0x000095A7 File Offset: 0x000077A7
		// (set) Token: 0x06000805 RID: 2053 RVA: 0x00024888 File Offset: 0x00022A88
		public int EffectValue
		{
			get
			{
				return this._effectValue;
			}
			set
			{
				this._effectValue = value;
				this.EffectSendValue = value;
				this.OnPropertyChanged<int>(() => this.EffectValue);
			}
		}

		// Token: 0x170002EF RID: 751
		// (get) Token: 0x06000806 RID: 2054 RVA: 0x000095AF File Offset: 0x000077AF
		// (set) Token: 0x06000807 RID: 2055 RVA: 0x000095B7 File Offset: 0x000077B7
		public int EffectSendValue
		{
			get
			{
				return this._effectSendValue;
			}
			set
			{
				this._effectSendValue = value;
				this.OnPropertyChanged<int>(() => this.EffectSendValue);
			}
		}

		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x06000808 RID: 2056 RVA: 0x000095F7 File Offset: 0x000077F7
		// (set) Token: 0x06000809 RID: 2057 RVA: 0x000095FF File Offset: 0x000077FF
		public bool IsEnabled
		{
			get
			{
				return this._isEnabled;
			}
			set
			{
				this._isEnabled = value;
				this.OnPropertyChanged<bool>(() => this.IsEnabled);
			}
		}

		// Token: 0x0400046D RID: 1133
		private int _effectSendValue;

		// Token: 0x0400046E RID: 1134
		private int _effectValue;

		// Token: 0x0400046F RID: 1135
		private string[] _effectValueCollection;

		// Token: 0x04000470 RID: 1136
		private bool _isEnabled = true;

		// Token: 0x04000471 RID: 1137
		private string _name;
	}
}
