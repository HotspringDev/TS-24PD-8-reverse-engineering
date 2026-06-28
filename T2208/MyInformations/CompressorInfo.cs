using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using BasicClassLib.BasicInterface;
using JayLib.JaySerialization;
using JayLib.WPF.BasicClass;

namespace T2208.MyInformations
{
	// Token: 0x02000059 RID: 89
	[Serializable]
	public class CompressorInfo : NotificationObject, ILimitEdit, ISerializable
	{
		// Token: 0x1700019E RID: 414
		// (get) Token: 0x060004B4 RID: 1204 RVA: 0x00006A41 File Offset: 0x00004C41
		// (set) Token: 0x060004B5 RID: 1205 RVA: 0x00006A49 File Offset: 0x00004C49
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

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x060004B6 RID: 1206 RVA: 0x00006A89 File Offset: 0x00004C89
		// (set) Token: 0x060004B7 RID: 1207 RVA: 0x0001E20C File Offset: 0x0001C40C
		public byte Bypass
		{
			get
			{
				return this._bypass;
			}
			set
			{
				this._bypass = value;
				this.CompressorEnable = value == 0;
				this.OnPropertyChanged<byte>(() => this.Bypass);
			}
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x060004B8 RID: 1208 RVA: 0x00006A91 File Offset: 0x00004C91
		// (set) Token: 0x060004B9 RID: 1209 RVA: 0x0001E264 File Offset: 0x0001C464
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
				this.SendGain = value;
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x060004BA RID: 1210 RVA: 0x00006A99 File Offset: 0x00004C99
		// (set) Token: 0x060004BB RID: 1211 RVA: 0x00006AA1 File Offset: 0x00004CA1
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

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x060004BC RID: 1212 RVA: 0x00006AE1 File Offset: 0x00004CE1
		// (set) Token: 0x060004BD RID: 1213 RVA: 0x00006AE9 File Offset: 0x00004CE9
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

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x060004BE RID: 1214 RVA: 0x00006B29 File Offset: 0x00004D29
		// (set) Token: 0x060004BF RID: 1215 RVA: 0x00006B31 File Offset: 0x00004D31
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

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x060004C0 RID: 1216 RVA: 0x00006B71 File Offset: 0x00004D71
		// (set) Token: 0x060004C1 RID: 1217 RVA: 0x00006B79 File Offset: 0x00004D79
		public byte Threshold
		{
			get
			{
				return this._threshold;
			}
			set
			{
				this._threshold = value;
				this.OnPropertyChanged<byte>(() => this.Threshold);
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x060004C2 RID: 1218 RVA: 0x00006BB9 File Offset: 0x00004DB9
		// (set) Token: 0x060004C3 RID: 1219 RVA: 0x00006BC1 File Offset: 0x00004DC1
		public bool CompressorEnable
		{
			get
			{
				return this._noiseGateEnable;
			}
			set
			{
				this._noiseGateEnable = value;
				this.OnPropertyChanged<bool>(() => this.CompressorEnable);
			}
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x060004C4 RID: 1220 RVA: 0x00006C01 File Offset: 0x00004E01
		// (set) Token: 0x060004C5 RID: 1221 RVA: 0x0001E2B8 File Offset: 0x0001C4B8
		public int CompressorMeter
		{
			get
			{
				return this._compressorMeter;
			}
			set
			{
				bool flag = this._compressorMeter == value;
				if (!flag)
				{
					this._compressorMeter = value;
					this.OnPropertyChanged<int>(() => this.CompressorMeter);
				}
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x060004C6 RID: 1222 RVA: 0x00006C09 File Offset: 0x00004E09
		// (set) Token: 0x060004C7 RID: 1223 RVA: 0x00006C11 File Offset: 0x00004E11
		public byte SendGain
		{
			get
			{
				return this._sendGain;
			}
			set
			{
				this._sendGain = value;
				this.OnPropertyChanged<byte>(() => this.SendGain);
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x060004C8 RID: 1224 RVA: 0x00006C51 File Offset: 0x00004E51
		// (set) Token: 0x060004C9 RID: 1225 RVA: 0x00006C59 File Offset: 0x00004E59
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

		// Token: 0x060004CA RID: 1226 RVA: 0x00006C99 File Offset: 0x00004E99
		public CompressorInfo()
		{
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x00006CAA File Offset: 0x00004EAA
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			SerializerHelper.SerializationPropertyHelper(info, this, new Type[]
			{
				typeof(RelayCommand),
				typeof(RelayCommand<int>)
			});
			SerializerHelper.SerializationFieldHelper(info, this);
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x0001E314 File Offset: 0x0001C514
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		protected CompressorInfo(SerializationInfo info, StreamingContext context)
		{
			SerializerHelper.DeserializtionPropertyHelper(info, this, new Type[]
			{
				typeof(RelayCommand),
				typeof(RelayCommand<int>)
			});
			SerializerHelper.DeSerializationFieldHelper(info, this);
		}

		// Token: 0x040002DF RID: 735
		private int _attack;

		// Token: 0x040002E0 RID: 736
		private byte _bypass;

		// Token: 0x040002E1 RID: 737
		private byte _active;

		// Token: 0x040002E2 RID: 738
		private byte _gain;

		// Token: 0x040002E3 RID: 739
		private byte _sendGain;

		// Token: 0x040002E4 RID: 740
		private byte _ratio;

		// Token: 0x040002E5 RID: 741
		private byte _boost;

		// Token: 0x040002E6 RID: 742
		private int _release;

		// Token: 0x040002E7 RID: 743
		private byte _threshold;

		// Token: 0x040002E8 RID: 744
		private bool _noiseGateEnable = true;

		// Token: 0x040002E9 RID: 745
		private int _compressorMeter;
	}
}
