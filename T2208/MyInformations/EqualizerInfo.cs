using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Windows.Input;
using BasicClassLib.BasicInterface;
using JayLib.JaySerialization;
using JayLib.WPF.BasicClass;
using T2208.ViewModels;

namespace T2208.MyInformations
{
	// Token: 0x02000058 RID: 88
	[Serializable]
	public class EqualizerInfo : NotificationObject, IEqualizerEdit, ISerializable
	{
		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06000495 RID: 1173 RVA: 0x000068AA File Offset: 0x00004AAA
		// (set) Token: 0x06000496 RID: 1174 RVA: 0x0001DE70 File Offset: 0x0001C070
		public int FilterIndex
		{
			get
			{
				return this._filterIndex;
			}
			set
			{
				bool isHighLowPass = this.IsHighLowPass;
				if (isHighLowPass)
				{
					this._filterIndex = value;
				}
				else
				{
					this._filterIndex = Math.Max(-1, Math.Min(2, value));
				}
				this.OnPropertyChanged<int>(() => this.FilterIndex);
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06000497 RID: 1175 RVA: 0x000068B2 File Offset: 0x00004AB2
		// (set) Token: 0x06000498 RID: 1176 RVA: 0x000068BA File Offset: 0x00004ABA
		public int SendFreqIndex
		{
			get
			{
				return this._sendFreqIndex;
			}
			set
			{
				this._sendFreqIndex = value;
				this.OnPropertyChanged<int>(() => this.FreqIndex);
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06000499 RID: 1177 RVA: 0x000068FA File Offset: 0x00004AFA
		// (set) Token: 0x0600049A RID: 1178 RVA: 0x0001DEDC File Offset: 0x0001C0DC
		public int FreqIndex
		{
			get
			{
				return this._freqIndex;
			}
			set
			{
				this.SendFreqIndex = value;
				this._freqIndex = value;
				this.OnPropertyChanged<int>(() => this.FreqIndex);
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x0600049B RID: 1179 RVA: 0x00006902 File Offset: 0x00004B02
		// (set) Token: 0x0600049C RID: 1180 RVA: 0x0000690A File Offset: 0x00004B0A
		public int SendQFactorIndex
		{
			get
			{
				return this._sendQFactorIndex;
			}
			set
			{
				this._sendQFactorIndex = value;
				this.OnPropertyChanged<int>(() => this.FreqIndex);
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x0600049D RID: 1181 RVA: 0x0000694A File Offset: 0x00004B4A
		// (set) Token: 0x0600049E RID: 1182 RVA: 0x0001DF30 File Offset: 0x0001C130
		public byte QFactorIndex
		{
			get
			{
				return this._qFactorIndex;
			}
			set
			{
				bool isHighLowPass = this.IsHighLowPass;
				if (!isHighLowPass)
				{
					bool flag = this.FilterIndex == 0;
					if (flag)
					{
						this.SendQFactorIndex = (int)value;
						this._qFactorIndex = value;
						this.OnPropertyChanged<byte>(() => this.QFactorIndex);
					}
				}
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x0600049F RID: 1183 RVA: 0x00006952 File Offset: 0x00004B52
		// (set) Token: 0x060004A0 RID: 1184 RVA: 0x0000695A File Offset: 0x00004B5A
		public int SendGainIndex
		{
			get
			{
				return this._sendGainIndex;
			}
			set
			{
				this._sendGainIndex = value;
				this.OnPropertyChanged<int>(() => this.FreqIndex);
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x060004A1 RID: 1185 RVA: 0x0000699A File Offset: 0x00004B9A
		// (set) Token: 0x060004A2 RID: 1186 RVA: 0x0001DFA0 File Offset: 0x0001C1A0
		public int GainIndex
		{
			get
			{
				return this._gainIndex;
			}
			set
			{
				bool isHighLowPass = this.IsHighLowPass;
				if (!isHighLowPass)
				{
					this.SendGainIndex = value;
					this._gainIndex = value;
					this.OnPropertyChanged<int>(() => this.GainIndex);
				}
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x060004A3 RID: 1187 RVA: 0x000069A2 File Offset: 0x00004BA2
		// (set) Token: 0x060004A4 RID: 1188 RVA: 0x0001E000 File Offset: 0x0001C200
		public byte Bypass
		{
			get
			{
				return this._bypass;
			}
			set
			{
				this._bypass = value;
				this.UpdateEqualizerEnable();
				this.OnPropertyChanged<byte>(() => this.Bypass);
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x060004A5 RID: 1189 RVA: 0x000069AA File Offset: 0x00004BAA
		// (set) Token: 0x060004A6 RID: 1190 RVA: 0x000069B2 File Offset: 0x00004BB2
		public bool EqualizerEnable
		{
			get
			{
				return this._equalizerEnable;
			}
			set
			{
				this._equalizerEnable = value;
				this.OnPropertyChanged<bool>(() => this.EqualizerEnable);
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x060004A7 RID: 1191 RVA: 0x000069F2 File Offset: 0x00004BF2
		// (set) Token: 0x060004A8 RID: 1192 RVA: 0x000069FA File Offset: 0x00004BFA
		public bool IsHighLowPass { get; set; }

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x060004A9 RID: 1193 RVA: 0x00006A03 File Offset: 0x00004C03
		// (set) Token: 0x060004AA RID: 1194 RVA: 0x00006A0B File Offset: 0x00004C0B
		public int FFTEqualizerIndex { get; set; }

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x060004AB RID: 1195 RVA: 0x00006A14 File Offset: 0x00004C14
		// (set) Token: 0x060004AC RID: 1196 RVA: 0x00006A1C File Offset: 0x00004C1C
		public int DeviceEqualizerIndex { get; set; }

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x00006A25 File Offset: 0x00004C25
		// (set) Token: 0x060004AE RID: 1198 RVA: 0x00006A2D File Offset: 0x00004C2D
		public List<string[]> QFactorCollections
		{
			get
			{
				return this._qFactorCollections;
			}
			set
			{
				this._qFactorCollections = value;
			}
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x0001E054 File Offset: 0x0001C254
		public EqualizerInfo(int fFTEqualizerIndex, int deviceEqualizerIndex = 0)
		{
			this.FFTEqualizerIndex = fFTEqualizerIndex;
			this.DeviceEqualizerIndex = deviceEqualizerIndex;
			this.EqualizerEnable = true;
			this.FilterIndex = 0;
			this.FreqIndex = Final.inital_freq_ary[this.FFTEqualizerIndex];
			this.GainIndex = 24;
			this.QFactorIndex = 12;
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x0001E108 File Offset: 0x0001C308
		public void EqualizerFlat()
		{
			this.EqualizerEnable = true;
			bool isHighLowPass = this.IsHighLowPass;
			if (isHighLowPass)
			{
				this.FilterIndex = 3;
			}
			else
			{
				this.FilterIndex = 0;
			}
			this.FreqIndex = Final.inital_freq_ary[this.FFTEqualizerIndex];
			this.GainIndex = 24;
			this.QFactorIndex = 12;
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x00006A36 File Offset: 0x00004C36
		private void UpdateEqualizerEnable()
		{
			this.EqualizerEnable = true;
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x000047F1 File Offset: 0x000029F1
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

		// Token: 0x060004B3 RID: 1203 RVA: 0x0001E160 File Offset: 0x0001C360
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		protected EqualizerInfo(SerializationInfo info, StreamingContext context)
		{
			SerializerHelper.DeserializtionPropertyHelper(info, this, new Type[]
			{
				typeof(RelayCommand),
				typeof(RelayCommand<int>),
				typeof(ICommand)
			});
			SerializerHelper.DeSerializationFieldHelper(info, this);
		}

		// Token: 0x040002D2 RID: 722
		private int _filterIndex = -1;

		// Token: 0x040002D3 RID: 723
		private int _freqIndex = 0;

		// Token: 0x040002D4 RID: 724
		private byte _qFactorIndex = 12;

		// Token: 0x040002D5 RID: 725
		private int _gainIndex = 0;

		// Token: 0x040002D6 RID: 726
		private byte _bypass = 0;

		// Token: 0x040002D7 RID: 727
		private List<string[]> _qFactorCollections = new List<string[]>
		{
			Const.QFactorStrings,
			Const.QFactorLSFStrings,
			Const.QFactorHSFStrings
		};

		// Token: 0x040002D8 RID: 728
		private bool _equalizerEnable = true;

		// Token: 0x040002D9 RID: 729
		private int _sendFreqIndex;

		// Token: 0x040002DA RID: 730
		private int _sendQFactorIndex;

		// Token: 0x040002DB RID: 731
		private int _sendGainIndex;
	}
}
