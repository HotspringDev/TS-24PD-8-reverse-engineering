using System;

namespace T2208.Models
{
	// Token: 0x02000091 RID: 145
	public class CompModel : BaseGateCompModel
	{
		// Token: 0x170002CB RID: 715
		// (get) Token: 0x060007B8 RID: 1976 RVA: 0x00008FC8 File Offset: 0x000071C8
		// (set) Token: 0x060007B9 RID: 1977 RVA: 0x00008FD0 File Offset: 0x000071D0
		public int Gain
		{
			get
			{
				return this._gain;
			}
			set
			{
				base.SetProperty<int>(ref this._gain, value, "Gain");
			}
		}

		// Token: 0x170002CC RID: 716
		// (get) Token: 0x060007BA RID: 1978 RVA: 0x00008FE5 File Offset: 0x000071E5
		// (set) Token: 0x060007BB RID: 1979 RVA: 0x00008FED File Offset: 0x000071ED
		public int SendGain
		{
			get
			{
				return this._sendGain;
			}
			set
			{
				base.SetProperty<int>(ref this._sendGain, value, "SendGain");
			}
		}

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x060007BC RID: 1980 RVA: 0x00009002 File Offset: 0x00007202
		// (set) Token: 0x060007BD RID: 1981 RVA: 0x0000900A File Offset: 0x0000720A
		public int Meter
		{
			get
			{
				return this._meter;
			}
			set
			{
				base.SetProperty<int>(ref this._meter, value, "Meter");
			}
		}

		// Token: 0x170002CE RID: 718
		// (get) Token: 0x060007BE RID: 1982 RVA: 0x0000901F File Offset: 0x0000721F
		public object CompressorBypassCommand { get; }

		// Token: 0x0400044A RID: 1098
		private int _gain;

		// Token: 0x0400044B RID: 1099
		private int _meter;

		// Token: 0x0400044C RID: 1100
		private int _sendGain;
	}
}
