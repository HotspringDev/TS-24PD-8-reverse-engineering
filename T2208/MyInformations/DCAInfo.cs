using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Windows.Controls;
using System.Windows.Input;
using JayLib.JaySerialization;
using JayLib.WPF.BasicClass;
using T2208.DeviceCommuncation;
using T2208.ViewModels;

namespace T2208.MyInformations
{
	// Token: 0x02000056 RID: 86
	[Serializable]
	public class DCAInfo<T> : GroupInfo<T>, ISerializable
	{
		// Token: 0x17000175 RID: 373
		// (get) Token: 0x06000456 RID: 1110 RVA: 0x0001D5B8 File Offset: 0x0001B7B8
		// (set) Token: 0x06000457 RID: 1111 RVA: 0x0001D5D0 File Offset: 0x0001B7D0
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

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x06000458 RID: 1112 RVA: 0x0001D620 File Offset: 0x0001B820
		// (set) Token: 0x06000459 RID: 1113 RVA: 0x0001D638 File Offset: 0x0001B838
		public ICommand PropertyChangeCommand
		{
			get
			{
				return this._PropertyChangeCommand;
			}
			set
			{
				this._PropertyChangeCommand = value;
				this.OnPropertyChanged<ICommand>(() => this.PropertyChangeCommand);
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x0600045A RID: 1114 RVA: 0x0001D688 File Offset: 0x0001B888
		// (set) Token: 0x0600045B RID: 1115 RVA: 0x0001D6A0 File Offset: 0x0001B8A0
		public ICommand SelectGroupCommand
		{
			get
			{
				return this._SelectGroupCommand;
			}
			set
			{
				this._SelectGroupCommand = value;
				this.OnPropertyChanged<ICommand>(() => this.SelectGroupCommand);
			}
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x0600045C RID: 1116 RVA: 0x0001D6F0 File Offset: 0x0001B8F0
		// (set) Token: 0x0600045D RID: 1117 RVA: 0x0001D708 File Offset: 0x0001B908
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

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x0600045E RID: 1118 RVA: 0x0001D758 File Offset: 0x0001B958
		// (set) Token: 0x0600045F RID: 1119 RVA: 0x0001D770 File Offset: 0x0001B970
		public bool IsMute
		{
			get
			{
				return this._IsMute;
			}
			set
			{
				this._IsMute = value;
				this.OnPropertyChanged<bool>(() => this.IsMute);
			}
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x06000460 RID: 1120 RVA: 0x0001D7C0 File Offset: 0x0001B9C0
		// (set) Token: 0x06000461 RID: 1121 RVA: 0x0001D7D8 File Offset: 0x0001B9D8
		public bool IsSolo
		{
			get
			{
				return this._IsSolo;
			}
			set
			{
				this._IsSolo = value;
				this.OnPropertyChanged<bool>(() => this.IsSolo);
			}
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000462 RID: 1122 RVA: 0x0001D828 File Offset: 0x0001BA28
		// (set) Token: 0x06000463 RID: 1123 RVA: 0x0001D840 File Offset: 0x0001BA40
		public ObservableCollection<ChannelInfo> ChannelInfos
		{
			get
			{
				return this._ChannelInfos;
			}
			set
			{
				this._ChannelInfos = value;
				this.OnPropertyChanged<ObservableCollection<ChannelInfo>>(() => this.ChannelInfos);
			}
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06000464 RID: 1124 RVA: 0x0001D890 File Offset: 0x0001BA90
		// (set) Token: 0x06000465 RID: 1125 RVA: 0x0001D8A8 File Offset: 0x0001BAA8
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
				this.SendValue = value;
			}
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x06000466 RID: 1126 RVA: 0x0001D900 File Offset: 0x0001BB00
		// (set) Token: 0x06000467 RID: 1127 RVA: 0x0001D918 File Offset: 0x0001BB18
		public int SendValue
		{
			get
			{
				return this._SendValue;
			}
			set
			{
				this._SendValue = value;
				this.OnPropertyChanged<int>(() => this.SendValue);
			}
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06000468 RID: 1128 RVA: 0x0001D968 File Offset: 0x0001BB68
		// (set) Token: 0x06000469 RID: 1129 RVA: 0x0001D980 File Offset: 0x0001BB80
		public int MeterValue
		{
			get
			{
				return this._MeterValue;
			}
			set
			{
				this._MeterValue = value;
				this.OnPropertyChanged<int>(() => this.MeterValue);
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x0600046A RID: 1130 RVA: 0x0001D9D0 File Offset: 0x0001BBD0
		// (set) Token: 0x0600046B RID: 1131 RVA: 0x0001D9E8 File Offset: 0x0001BBE8
		public int SceneIndex
		{
			get
			{
				return this._SceneIndex;
			}
			set
			{
				this._SceneIndex = value;
				this.OnPropertyChanged<int>(() => this.SceneIndex);
			}
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x0600046C RID: 1132 RVA: 0x0001DA38 File Offset: 0x0001BC38
		// (set) Token: 0x0600046D RID: 1133 RVA: 0x0001DA50 File Offset: 0x0001BC50
		public bool IsSelected
		{
			get
			{
				return this._IsSelected;
			}
			set
			{
				this._IsSelected = value;
				this.OnPropertyChanged<bool>(() => this.IsSelected);
				bool isSelected = this.IsSelected;
				if (isSelected)
				{
					ViewModelMessager.Messeager.Notify(ViewModelMessager.DCAIsSelected, this.DCAIndex);
				}
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x0600046E RID: 1134 RVA: 0x0001DAC8 File Offset: 0x0001BCC8
		// (set) Token: 0x0600046F RID: 1135 RVA: 0x0001DAE0 File Offset: 0x0001BCE0
		public int DCAIndex
		{
			get
			{
				return this._DCAIndex;
			}
			set
			{
				this._DCAIndex = value;
				this.OnPropertyChanged<int>(() => this.DCAIndex);
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x06000470 RID: 1136 RVA: 0x0001DB30 File Offset: 0x0001BD30
		// (set) Token: 0x06000471 RID: 1137 RVA: 0x0001DB48 File Offset: 0x0001BD48
		public string InputName
		{
			get
			{
				return this._InputName;
			}
			set
			{
				this._InputName = value;
				this.OnPropertyChanged<string>(() => this.InputName);
			}
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x06000472 RID: 1138 RVA: 0x0001DB98 File Offset: 0x0001BD98
		// (set) Token: 0x06000473 RID: 1139 RVA: 0x0001DBB0 File Offset: 0x0001BDB0
		public bool IsEditName
		{
			get
			{
				return this._IsEditName;
			}
			set
			{
				this._IsEditName = value;
				this.OnPropertyChanged<bool>(() => this.IsEditName);
			}
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06000474 RID: 1140 RVA: 0x000066CD File Offset: 0x000048CD
		// (set) Token: 0x06000475 RID: 1141 RVA: 0x000066D5 File Offset: 0x000048D5
		public byte[] NameBytes { get; set; } = new byte[12];

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06000476 RID: 1142 RVA: 0x000066DE File Offset: 0x000048DE
		// (set) Token: 0x06000477 RID: 1143 RVA: 0x000066E6 File Offset: 0x000048E6
		public string DefaultName { get; set; }

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x06000478 RID: 1144 RVA: 0x000066EF File Offset: 0x000048EF
		// (set) Token: 0x06000479 RID: 1145 RVA: 0x000066F7 File Offset: 0x000048F7
		public byte[] Channels { get; set; } = new byte[34];

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x0600047A RID: 1146 RVA: 0x00006700 File Offset: 0x00004900
		// (set) Token: 0x0600047B RID: 1147 RVA: 0x00006708 File Offset: 0x00004908
		public byte[] TempChannels { get; set; } = new byte[34];

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x0600047C RID: 1148 RVA: 0x00006711 File Offset: 0x00004911
		// (set) Token: 0x0600047D RID: 1149 RVA: 0x00006719 File Offset: 0x00004919
		public RelayCommand SetChannenlNameCommand { get; private set; }

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x0600047E RID: 1150 RVA: 0x00006722 File Offset: 0x00004922
		// (set) Token: 0x0600047F RID: 1151 RVA: 0x0000672A File Offset: 0x0000492A
		public RelayCommand<TextBox> EditChannelNameCommand { get; set; }

		// Token: 0x06000480 RID: 1152 RVA: 0x0001DC00 File Offset: 0x0001BE00
		public DCAInfo()
		{
			this.SetChannenlNameCommand = new RelayCommand(new Action(this.SetChannelNameExecute));
			this.EditChannelNameCommand = new RelayCommand<TextBox>(new Action<TextBox>(this.EditChannelNameExecute));
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x00006733 File Offset: 0x00004933
		private void EditChannelNameExecute(TextBox obj)
		{
			this.IsEditName = true;
			this.InputName = base.GroupName;
			obj.Focus();
			Keyboard.Focus(obj);
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x0001DC78 File Offset: 0x0001BE78
		public void SetChannelNameExecute()
		{
			bool isEditName = this.IsEditName;
			if (isEditName)
			{
				this.NameBytes = new byte[12];
				int num = (this.InputName.Length < this.NameBytes.Length) ? this.InputName.Length : this.NameBytes.Length;
				for (int i = 0; i < num; i++)
				{
					this.NameBytes[i] = (byte)this.InputName[i];
				}
				bool flag = base.GetType() == typeof(DCAInfo<DCAItem>);
				if (flag)
				{
					DCAInfo<DCAItem> dcainfo = this as DCAInfo<DCAItem>;
					UpStreamCommand.SendCMD_DCAGroupSet(dcainfo);
				}
				this.IsEditName = false;
			}
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x0001DD08 File Offset: 0x0001BF08
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		protected DCAInfo(SerializationInfo info, StreamingContext context)
		{
			SerializerHelper.DeserializtionPropertyHelper(info, this, new Type[]
			{
				typeof(RelayCommand),
				typeof(RelayCommand<int>),
				typeof(ICommand)
			});
			SerializerHelper.DeSerializationFieldHelper(info, this);
		}

		// Token: 0x040002B6 RID: 694
		private ICommand _Command;

		// Token: 0x040002B7 RID: 695
		private ICommand _PropertyChangeCommand;

		// Token: 0x040002B8 RID: 696
		private ICommand _SelectGroupCommand;

		// Token: 0x040002B9 RID: 697
		private ICommand _MouseEnterCommand;

		// Token: 0x040002BA RID: 698
		private bool _IsMute;

		// Token: 0x040002BB RID: 699
		private bool _IsSolo;

		// Token: 0x040002BC RID: 700
		private ObservableCollection<ChannelInfo> _ChannelInfos = new ObservableCollection<ChannelInfo>();

		// Token: 0x040002BD RID: 701
		private int _Value;

		// Token: 0x040002BE RID: 702
		private int _SendValue;

		// Token: 0x040002BF RID: 703
		private int _MeterValue;

		// Token: 0x040002C0 RID: 704
		private int _SceneIndex;

		// Token: 0x040002C1 RID: 705
		private bool _IsSelected;

		// Token: 0x040002C2 RID: 706
		private int _DCAIndex;

		// Token: 0x040002C3 RID: 707
		private string _InputName;

		// Token: 0x040002C4 RID: 708
		private bool _IsEditName;
	}
}
