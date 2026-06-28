using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Windows.Input;
using JayLib.JaySerialization;
using JayLib.WPF.BasicClass;

namespace T2208.MyInformations
{
	// Token: 0x0200005C RID: 92
	[Serializable]
	public class EffectInfo : NotificationObject, ISerializable
	{
		// Token: 0x170001AF RID: 431
		// (get) Token: 0x060004DE RID: 1246 RVA: 0x0001E4C8 File Offset: 0x0001C6C8
		// (set) Token: 0x060004DF RID: 1247 RVA: 0x00006E23 File Offset: 0x00005023
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				this._Name = value;
				this.OnPropertyChanged<string>(() => this.Name);
			}
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x060004E0 RID: 1248 RVA: 0x0001E4E0 File Offset: 0x0001C6E0
		// (set) Token: 0x060004E1 RID: 1249 RVA: 0x00006E63 File Offset: 0x00005063
		public string[] EffectValueCollection
		{
			get
			{
				return this._EffectValueCollection;
			}
			set
			{
				this._EffectValueCollection = value;
				this.OnPropertyChanged<string[]>(() => this.EffectValueCollection);
			}
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x060004E2 RID: 1250 RVA: 0x0001E4F8 File Offset: 0x0001C6F8
		// (set) Token: 0x060004E3 RID: 1251 RVA: 0x0001E510 File Offset: 0x0001C710
		public int EffectValue
		{
			get
			{
				return this._EffectValue;
			}
			set
			{
				this._EffectValue = value;
				this.EffectSendValue = value;
				this.OnPropertyChanged<int>(() => this.EffectValue);
			}
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x060004E4 RID: 1252 RVA: 0x0001E564 File Offset: 0x0001C764
		// (set) Token: 0x060004E5 RID: 1253 RVA: 0x00006EA3 File Offset: 0x000050A3
		public int EffectSendValue
		{
			get
			{
				return this._EffectSendValue;
			}
			set
			{
				this._EffectSendValue = value;
				this.OnPropertyChanged<int>(() => this.EffectSendValue);
			}
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x060004E6 RID: 1254 RVA: 0x0001E57C File Offset: 0x0001C77C
		// (set) Token: 0x060004E7 RID: 1255 RVA: 0x00006EE3 File Offset: 0x000050E3
		public bool IsEnabled
		{
			get
			{
				return this._IsEnabled;
			}
			set
			{
				this._IsEnabled = value;
				this.OnPropertyChanged<bool>(() => this.IsEnabled);
			}
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x060004E8 RID: 1256 RVA: 0x0001E594 File Offset: 0x0001C794
		// (set) Token: 0x060004E9 RID: 1257 RVA: 0x00006F23 File Offset: 0x00005123
		public ICommand CommonCommand
		{
			get
			{
				return this._CommonCommand;
			}
			set
			{
				this._CommonCommand = value;
				this.OnPropertyChanged<ICommand>(() => this.CommonCommand);
			}
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x060004EA RID: 1258 RVA: 0x00006F63 File Offset: 0x00005163
		// (set) Token: 0x060004EB RID: 1259 RVA: 0x00006F6B File Offset: 0x0000516B
		public int DefaultEffectValue { get; set; }

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x060004EC RID: 1260 RVA: 0x00006F74 File Offset: 0x00005174
		// (set) Token: 0x060004ED RID: 1261 RVA: 0x00006F7C File Offset: 0x0000517C
		public int EffectIndex { get; set; }

		// Token: 0x060004EE RID: 1262 RVA: 0x00006F85 File Offset: 0x00005185
		public EffectInfo()
		{
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x000047F1 File Offset: 0x000029F1
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

		// Token: 0x060004F0 RID: 1264 RVA: 0x0001E5AC File Offset: 0x0001C7AC
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		protected EffectInfo(SerializationInfo info, StreamingContext context)
		{
			SerializerHelper.DeserializtionPropertyHelper(info, this, new Type[]
			{
				typeof(RelayCommand),
				typeof(RelayCommand<int>),
				typeof(ICommand)
			});
			SerializerHelper.DeSerializationFieldHelper(info, this);
		}

		// Token: 0x040002F0 RID: 752
		private string _Name;

		// Token: 0x040002F1 RID: 753
		private string[] _EffectValueCollection;

		// Token: 0x040002F2 RID: 754
		private int _EffectValue;

		// Token: 0x040002F3 RID: 755
		private int _EffectSendValue;

		// Token: 0x040002F4 RID: 756
		private bool _IsEnabled = true;

		// Token: 0x040002F5 RID: 757
		private ICommand _CommonCommand;
	}
}
