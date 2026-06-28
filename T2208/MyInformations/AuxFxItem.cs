using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Windows.Input;
using JayLib.JaySerialization;
using JayLib.Localization;
using JayLib.WPF.BasicClass;

namespace T2208.MyInformations
{
	// Token: 0x02000063 RID: 99
	[Serializable]
	public class AuxFxItem : NotificationObject, ISerializable
	{
		// Token: 0x170001CD RID: 461
		// (get) Token: 0x0600052C RID: 1324 RVA: 0x0001EA78 File Offset: 0x0001CC78
		// (set) Token: 0x0600052D RID: 1325 RVA: 0x0000748A File Offset: 0x0000568A
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

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x0600052E RID: 1326 RVA: 0x0001EA90 File Offset: 0x0001CC90
		// (set) Token: 0x0600052F RID: 1327 RVA: 0x000074CA File Offset: 0x000056CA
		public string ChName
		{
			get
			{
				return this._ChName;
			}
			set
			{
				this._ChName = value;
				this.OnPropertyChanged<string>(() => this.ChName);
			}
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x06000530 RID: 1328 RVA: 0x0001EAA8 File Offset: 0x0001CCA8
		// (set) Token: 0x06000531 RID: 1329 RVA: 0x0000750A File Offset: 0x0000570A
		public ICommand Command
		{
			get
			{
				return this._Command;
			}
			set
			{
				this._Command = value;
				this.OnPropertyChanged<ICommand>(() => this.Command);
			}
		}

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x06000532 RID: 1330 RVA: 0x0001EAC0 File Offset: 0x0001CCC0
		// (set) Token: 0x06000533 RID: 1331 RVA: 0x0001EAD8 File Offset: 0x0001CCD8
		public int Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				this._Value = value;
				this.OnPropertyChanged<int>(() => this.Value);
				this.SendValue = (double)value;
			}
		}

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x06000534 RID: 1332 RVA: 0x0001EB2C File Offset: 0x0001CD2C
		// (set) Token: 0x06000535 RID: 1333 RVA: 0x0000754A File Offset: 0x0000574A
		public double SendValue
		{
			get
			{
				return this._SendValue;
			}
			set
			{
				this._SendValue = value;
				this.OnPropertyChanged<double>(() => this.SendValue);
			}
		}

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x06000536 RID: 1334 RVA: 0x0001EB44 File Offset: 0x0001CD44
		// (set) Token: 0x06000537 RID: 1335 RVA: 0x0000758A File Offset: 0x0000578A
		public bool ItemEnabled
		{
			get
			{
				return this._ItemEnabled;
			}
			set
			{
				this._ItemEnabled = value;
				this.OnPropertyChanged<bool>(() => this.ItemEnabled);
			}
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x06000538 RID: 1336 RVA: 0x0001EB5C File Offset: 0x0001CD5C
		// (set) Token: 0x06000539 RID: 1337 RVA: 0x000075CA File Offset: 0x000057CA
		public bool IsFrontSet
		{
			get
			{
				return this._IsFrontSet;
			}
			set
			{
				this._IsFrontSet = value;
				this.OnPropertyChanged<bool>(() => this.IsFrontSet);
			}
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x0600053A RID: 1338 RVA: 0x0001EB74 File Offset: 0x0001CD74
		// (set) Token: 0x0600053B RID: 1339 RVA: 0x0000760A File Offset: 0x0000580A
		public ICommand MouseEnterCommand
		{
			get
			{
				return this._MouseEnterCommand;
			}
			set
			{
				this._MouseEnterCommand = value;
				this.OnPropertyChanged<ICommand>(() => this.MouseEnterCommand);
			}
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x0600053C RID: 1340 RVA: 0x0000764A File Offset: 0x0000584A
		// (set) Token: 0x0600053D RID: 1341 RVA: 0x00007652 File Offset: 0x00005852
		public int ChannelIndex
		{
			get
			{
				return this._channelIndex;
			}
			set
			{
				this._channelIndex = value;
				this.OnPropertyChanged<int>(() => this.ChannelIndex);
			}
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x0600053E RID: 1342 RVA: 0x00007692 File Offset: 0x00005892
		// (set) Token: 0x0600053F RID: 1343 RVA: 0x0000769A File Offset: 0x0000589A
		public int AuxIndex
		{
			get
			{
				return this._auxIndex;
			}
			set
			{
				this._auxIndex = value;
				this.OnPropertyChanged<int>(() => this.AuxIndex);
			}
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x000076DA File Offset: 0x000058DA
		public AuxFxItem()
			: this(null, null, false, 0, 0)
		{
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x0001EB8C File Offset: 0x0001CD8C
		public AuxFxItem(string channelName, string name, bool isExist, int channelIndex = 0, int auxIndex = 0)
		{
			this.ChName = channelName;
			this.Name = name;
			this.ItemEnabled = isExist;
			if (isExist)
			{
				this.ChannelIndex = channelIndex;
				this.AuxIndex = auxIndex;
			}
			LocalizationManager.LanguageChangedEvent += this.LocalizationManager_LanguageChangedEvent;
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x000076E9 File Offset: 0x000058E9
		private void LocalizationManager_LanguageChangedEvent(string lanugage)
		{
			this.OnPropertyChanged<bool>(() => this.IsFrontSet);
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x000047F1 File Offset: 0x000029F1
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

		// Token: 0x06000544 RID: 1348 RVA: 0x00013488 File Offset: 0x00011688
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		protected AuxFxItem(SerializationInfo info, StreamingContext context)
		{
			SerializerHelper.DeserializtionPropertyHelper(info, this, new Type[]
			{
				typeof(RelayCommand),
				typeof(RelayCommand<int>),
				typeof(ICommand)
			});
			SerializerHelper.DeSerializationFieldHelper(info, this);
		}

		// Token: 0x04000312 RID: 786
		private string _Name;

		// Token: 0x04000313 RID: 787
		private string _ChName;

		// Token: 0x04000314 RID: 788
		private ICommand _Command;

		// Token: 0x04000315 RID: 789
		private int _Value;

		// Token: 0x04000316 RID: 790
		private double _SendValue;

		// Token: 0x04000317 RID: 791
		private bool _ItemEnabled;

		// Token: 0x04000318 RID: 792
		private bool _IsFrontSet;

		// Token: 0x04000319 RID: 793
		private ICommand _MouseEnterCommand;

		// Token: 0x0400031A RID: 794
		private int _channelIndex;

		// Token: 0x0400031B RID: 795
		private int _auxIndex;
	}
}
