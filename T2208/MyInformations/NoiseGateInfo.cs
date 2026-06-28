using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Windows.Input;
using BasicClassLib.BasicInterface;
using JayLib.JaySerialization;
using JayLib.WPF.BasicClass;
using T2208.ViewModels;

namespace T2208.MyInformations
{
	// Token: 0x02000062 RID: 98
	[Serializable]
	public class NoiseGateInfo : NotificationObject, ILimitEdit, ISerializable
	{
		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06000514 RID: 1300 RVA: 0x00007221 File Offset: 0x00005421
		// (set) Token: 0x06000515 RID: 1301 RVA: 0x00007229 File Offset: 0x00005429
		public int Attack
		{
			get
			{
				return this._attack;
			}
			set
			{
				this._attack = value;
				this.OnPropertyChanged<int>(() => this.Attack);
			}
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x06000516 RID: 1302 RVA: 0x00007269 File Offset: 0x00005469
		// (set) Token: 0x06000517 RID: 1303 RVA: 0x0001E928 File Offset: 0x0001CB28
		public byte Bypass
		{
			get
			{
				return this._bypass;
			}
			set
			{
				this._bypass = value;
				this.NoiseGateEnable = value == 0;
				this.OnPropertyChanged<byte>(() => this.Bypass);
			}
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06000518 RID: 1304 RVA: 0x00007271 File Offset: 0x00005471
		// (set) Token: 0x06000519 RID: 1305 RVA: 0x00007279 File Offset: 0x00005479
		public byte Gain
		{
			get
			{
				return this._gain;
			}
			set
			{
				this._gain = value;
				this.OnPropertyChanged<byte>(() => this.Gain);
			}
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x0600051A RID: 1306 RVA: 0x000072B9 File Offset: 0x000054B9
		// (set) Token: 0x0600051B RID: 1307 RVA: 0x000072C1 File Offset: 0x000054C1
		public byte Ratio
		{
			get
			{
				return this._ratio;
			}
			set
			{
				this._ratio = value;
				this.OnPropertyChanged<byte>(() => this.Ratio);
			}
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x0600051C RID: 1308 RVA: 0x00007301 File Offset: 0x00005501
		// (set) Token: 0x0600051D RID: 1309 RVA: 0x00007309 File Offset: 0x00005509
		public byte Boost
		{
			get
			{
				return this._boost;
			}
			set
			{
				this._boost = value;
				this.OnPropertyChanged<byte>(() => this.Boost);
			}
		}

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x0600051E RID: 1310 RVA: 0x00007349 File Offset: 0x00005549
		// (set) Token: 0x0600051F RID: 1311 RVA: 0x00007351 File Offset: 0x00005551
		public int Release
		{
			get
			{
				return this._release;
			}
			set
			{
				this._release = value;
				this.OnPropertyChanged<int>(() => this.Release);
			}
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x06000520 RID: 1312 RVA: 0x00007391 File Offset: 0x00005591
		// (set) Token: 0x06000521 RID: 1313 RVA: 0x0001E980 File Offset: 0x0001CB80
		public byte Threshold
		{
			get
			{
				return this._threshold;
			}
			set
			{
				this._threshold = value;
				this.SetThresholdValue();
				this.OnPropertyChanged<byte>(() => this.Threshold);
			}
		}

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x06000522 RID: 1314 RVA: 0x00007399 File Offset: 0x00005599
		// (set) Token: 0x06000523 RID: 1315 RVA: 0x000073A1 File Offset: 0x000055A1
		public int ThresholdValue
		{
			get
			{
				return this._thresholdValue;
			}
			private set
			{
				this._thresholdValue = value;
				this.OnPropertyChanged<int>(() => this.ThresholdValue);
			}
		}

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x06000524 RID: 1316 RVA: 0x000073E1 File Offset: 0x000055E1
		// (set) Token: 0x06000525 RID: 1317 RVA: 0x000073E9 File Offset: 0x000055E9
		public bool NoiseGateEnable
		{
			get
			{
				return this._noiseGateEnable;
			}
			set
			{
				this._noiseGateEnable = value;
				this.OnPropertyChanged<bool>(() => this.NoiseGateEnable);
			}
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x06000526 RID: 1318 RVA: 0x00007429 File Offset: 0x00005629
		// (set) Token: 0x06000527 RID: 1319 RVA: 0x00007431 File Offset: 0x00005631
		public byte Active
		{
			get
			{
				return this._active;
			}
			set
			{
				this._active = value;
				this.OnPropertyChanged<byte>(() => this.Active);
			}
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x00007471 File Offset: 0x00005671
		public NoiseGateInfo()
		{
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x000047F1 File Offset: 0x000029F1
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			SerializerHelper.SerializationPropertyHelper(info, this, new Type[]
			{
				typeof(RelayCommand),
				typeof(RelayCommand<int>),
				typeof(ICommand)
			});
			SerializerHelper.SerializationFieldHelper(info, this);
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x0001E9D4 File Offset: 0x0001CBD4
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		protected NoiseGateInfo(SerializationInfo info, StreamingContext context)
		{
			SerializerHelper.DeserializtionPropertyHelper(info, this, new Type[]
			{
				typeof(RelayCommand),
				typeof(RelayCommand<int>),
				typeof(ICommand)
			});
			SerializerHelper.DeSerializationFieldHelper(info, this);
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x0001EA38 File Offset: 0x0001CC38
		private void SetThresholdValue()
		{
			string text = Const.NoiseGateThresholds[(int)this.Threshold];
			text = text.Remove(text.Length - 2, 2);
			this.ThresholdValue = int.Parse(text, NumberStyles.Integer, CultureInfo.InvariantCulture);
		}

		// Token: 0x04000308 RID: 776
		private int _attack;

		// Token: 0x04000309 RID: 777
		private byte _bypass;

		// Token: 0x0400030A RID: 778
		private byte _active;

		// Token: 0x0400030B RID: 779
		private byte _gain;

		// Token: 0x0400030C RID: 780
		private byte _ratio;

		// Token: 0x0400030D RID: 781
		private byte _boost;

		// Token: 0x0400030E RID: 782
		private int _release;

		// Token: 0x0400030F RID: 783
		private byte _threshold;

		// Token: 0x04000310 RID: 784
		private bool _noiseGateEnable = true;

		// Token: 0x04000311 RID: 785
		private int _thresholdValue = -84;
	}
}
