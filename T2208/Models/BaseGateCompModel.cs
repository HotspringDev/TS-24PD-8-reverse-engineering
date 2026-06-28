using System;
using System.Globalization;
using T2208.ViewModels;
using T2208.ViewModels.Base;

namespace T2208.Models
{
	// Token: 0x0200008D RID: 141
	public class BaseGateCompModel : BaseViewModel
	{
		// Token: 0x170002BE RID: 702
		// (get) Token: 0x06000798 RID: 1944 RVA: 0x00008DFF File Offset: 0x00006FFF
		// (set) Token: 0x06000799 RID: 1945 RVA: 0x00008E07 File Offset: 0x00007007
		public int Attack
		{
			get
			{
				return this._attack;
			}
			set
			{
				base.SetProperty<int>(ref this._attack, value, "Attack");
			}
		}

		// Token: 0x170002BF RID: 703
		// (get) Token: 0x0600079A RID: 1946 RVA: 0x00008E1C File Offset: 0x0000701C
		// (set) Token: 0x0600079B RID: 1947 RVA: 0x00008E24 File Offset: 0x00007024
		public byte Bypass
		{
			get
			{
				return this._bypass;
			}
			set
			{
				base.SetProperty<byte>(ref this._bypass, value, "Bypass");
				this.Enable = value == 0;
			}
		}

		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x0600079C RID: 1948 RVA: 0x00008E45 File Offset: 0x00007045
		// (set) Token: 0x0600079D RID: 1949 RVA: 0x00008E4D File Offset: 0x0000704D
		public bool Enable
		{
			get
			{
				return this._enable;
			}
			set
			{
				base.SetProperty<bool>(ref this._enable, value, "Enable");
			}
		}

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x0600079E RID: 1950 RVA: 0x00008E62 File Offset: 0x00007062
		// (set) Token: 0x0600079F RID: 1951 RVA: 0x00008E6A File Offset: 0x0000706A
		public byte Ratio
		{
			get
			{
				return this._ratio;
			}
			set
			{
				base.SetProperty<byte>(ref this._ratio, value, "Ratio");
			}
		}

		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x060007A0 RID: 1952 RVA: 0x00008E7F File Offset: 0x0000707F
		// (set) Token: 0x060007A1 RID: 1953 RVA: 0x00008E87 File Offset: 0x00007087
		public int Release
		{
			get
			{
				return this._release;
			}
			set
			{
				base.SetProperty<int>(ref this._release, value, "Release");
			}
		}

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x060007A2 RID: 1954 RVA: 0x00008E9C File Offset: 0x0000709C
		// (set) Token: 0x060007A3 RID: 1955 RVA: 0x00008EA4 File Offset: 0x000070A4
		public byte Threshold
		{
			get
			{
				return this._threshold;
			}
			set
			{
				base.SetProperty<byte>(ref this._threshold, value, "Threshold");
				this.SetThresholdValue();
			}
		}

		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x060007A4 RID: 1956 RVA: 0x00008EC1 File Offset: 0x000070C1
		// (set) Token: 0x060007A5 RID: 1957 RVA: 0x00008EC9 File Offset: 0x000070C9
		public int ThresholdValue
		{
			get
			{
				return this._thresholdValue;
			}
			set
			{
				base.SetProperty<int>(ref this._thresholdValue, value, "ThresholdValue");
			}
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x000246F8 File Offset: 0x000228F8
		private void SetThresholdValue()
		{
			string text = Const.NoiseGateThresholds[(int)this.Threshold];
			text = text.Remove(text.Length - 2, 2);
			this.ThresholdValue = int.Parse(text, NumberStyles.Integer, CultureInfo.InvariantCulture);
		}

		// Token: 0x0400043B RID: 1083
		private int _attack;

		// Token: 0x0400043C RID: 1084
		private byte _bypass;

		// Token: 0x0400043D RID: 1085
		private bool _enable = true;

		// Token: 0x0400043E RID: 1086
		private byte _ratio;

		// Token: 0x0400043F RID: 1087
		private int _release;

		// Token: 0x04000440 RID: 1088
		private byte _threshold;

		// Token: 0x04000441 RID: 1089
		private int _thresholdValue;
	}
}
