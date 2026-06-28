using System;
using T2208.ViewModels.Base;

namespace T2208.Models
{
	// Token: 0x0200009C RID: 156
	public class GeqFreqModel : BaseViewModel
	{
		// Token: 0x17000300 RID: 768
		// (get) Token: 0x0600082E RID: 2094 RVA: 0x00009A75 File Offset: 0x00007C75
		// (set) Token: 0x0600082F RID: 2095 RVA: 0x00009A7D File Offset: 0x00007C7D
		public string FreqName
		{
			get
			{
				return this._freqName;
			}
			set
			{
				this._freqName = value;
				this.OnPropertyChanged<string>(() => this.FreqName);
			}
		}

		// Token: 0x17000301 RID: 769
		// (get) Token: 0x06000830 RID: 2096 RVA: 0x00009ABD File Offset: 0x00007CBD
		// (set) Token: 0x06000831 RID: 2097 RVA: 0x00009AC5 File Offset: 0x00007CC5
		public int GainValue
		{
			get
			{
				return this._gainValue;
			}
			set
			{
				base.SetProperty<int>(ref this._gainValue, value, "GainValue");
				this.OldGainValue = value;
			}
		}

		// Token: 0x17000302 RID: 770
		// (get) Token: 0x06000832 RID: 2098 RVA: 0x00009AE3 File Offset: 0x00007CE3
		// (set) Token: 0x06000833 RID: 2099 RVA: 0x00009AEB File Offset: 0x00007CEB
		public int OldGainValue { get; set; } = 24;

		// Token: 0x17000303 RID: 771
		// (get) Token: 0x06000834 RID: 2100 RVA: 0x00009AF4 File Offset: 0x00007CF4
		// (set) Token: 0x06000835 RID: 2101 RVA: 0x00009AFC File Offset: 0x00007CFC
		public int IndexName { get; set; }

		// Token: 0x17000304 RID: 772
		// (get) Token: 0x06000836 RID: 2102 RVA: 0x00009B05 File Offset: 0x00007D05
		// (set) Token: 0x06000837 RID: 2103 RVA: 0x00009B0D File Offset: 0x00007D0D
		public int Index { get; set; }

		// Token: 0x04000483 RID: 1155
		private string _freqName;

		// Token: 0x04000484 RID: 1156
		private int _gainValue = 24;
	}
}
