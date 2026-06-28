using System;
using System.Collections.ObjectModel;
using JayLib.WPF.BasicClass;
using T2208.DeviceCommuncation;
using T2208.Models;
using T2208.MyDatas;
using T2208.MyInformations;

namespace T2208.ViewModels
{
	// Token: 0x0200003C RID: 60
	public class Route : ViewModelBase
	{
		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000287 RID: 647 RVA: 0x00017454 File Offset: 0x00015654
		// (set) Token: 0x06000288 RID: 648 RVA: 0x0001746C File Offset: 0x0001566C
		public GroupInfo<AuxFxItem> SelectedCollection
		{
			get
			{
				return this._SelectedCollection;
			}
			set
			{
				this._SelectedCollection = value;
				this.OnPropertyChanged<GroupInfo<AuxFxItem>>(() => this.SelectedCollection);
				this.IsMainGroup = value == this.Main;
				this.IsAuxFXGroup = !this.IsMainGroup;
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000289 RID: 649 RVA: 0x000174D8 File Offset: 0x000156D8
		// (set) Token: 0x0600028A RID: 650 RVA: 0x000174F0 File Offset: 0x000156F0
		public int SelectIndex
		{
			get
			{
				return this._SelectIndex;
			}
			set
			{
				this._SelectIndex = value;
				this.OnPropertyChanged<int>(() => this.SelectIndex);
				RouterData.SelectedRouteDeviceIndex = (byte)this._SelectedIndexPageToDevice[value];
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x0600028B RID: 651 RVA: 0x0001754C File Offset: 0x0001574C
		// (set) Token: 0x0600028C RID: 652 RVA: 0x0000528F File Offset: 0x0000348F
		public bool IsAllPost
		{
			get
			{
				return this._IsAllPost;
			}
			set
			{
				this._IsAllPost = value;
				this.OnPropertyChanged<bool>(() => this.IsAllPost);
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x0600028D RID: 653 RVA: 0x00017564 File Offset: 0x00015764
		// (set) Token: 0x0600028E RID: 654 RVA: 0x000052CF File Offset: 0x000034CF
		public bool IsAllPre
		{
			get
			{
				return this._IsAllPre;
			}
			set
			{
				this._IsAllPre = value;
				this.OnPropertyChanged<bool>(() => this.IsAllPre);
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x0600028F RID: 655 RVA: 0x0001757C File Offset: 0x0001577C
		// (set) Token: 0x06000290 RID: 656 RVA: 0x0000530F File Offset: 0x0000350F
		public ObservableCollection<GroupInfo<AuxFxItem>> ChannelGroup
		{
			get
			{
				return this._ChannelGroups;
			}
			set
			{
				this._ChannelGroups = value;
				this.OnPropertyChanged<ObservableCollection<GroupInfo<AuxFxItem>>>(() => this.ChannelGroup);
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000291 RID: 657 RVA: 0x00017594 File Offset: 0x00015794
		// (set) Token: 0x06000292 RID: 658 RVA: 0x0000534F File Offset: 0x0000354F
		public bool IsMainGroup
		{
			get
			{
				return this._IsMainGroup;
			}
			set
			{
				this._IsMainGroup = value;
				this.OnPropertyChanged<bool>(() => this.IsMainGroup);
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000293 RID: 659 RVA: 0x000175AC File Offset: 0x000157AC
		// (set) Token: 0x06000294 RID: 660 RVA: 0x0000538F File Offset: 0x0000358F
		public bool IsAuxFXGroup
		{
			get
			{
				return this._IsAuxFXGroup;
			}
			set
			{
				this._IsAuxFXGroup = value;
				this.OnPropertyChanged<bool>(() => this.IsAuxFXGroup);
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000295 RID: 661 RVA: 0x000175C4 File Offset: 0x000157C4
		// (set) Token: 0x06000296 RID: 662 RVA: 0x000053CF File Offset: 0x000035CF
		public ObservableCollection<ChannelInfo> AssignMainChannelGroup
		{
			get
			{
				return this._AssignMainChannelGroup;
			}
			set
			{
				this._AssignMainChannelGroup = value;
				this.OnPropertyChanged<ObservableCollection<ChannelInfo>>(() => this.AssignMainChannelGroup);
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000297 RID: 663 RVA: 0x0000540F File Offset: 0x0000360F
		// (set) Token: 0x06000298 RID: 664 RVA: 0x00005417 File Offset: 0x00003617
		public GroupInfo<AuxFxItem> FX1 { get; set; } = new GroupInfo<AuxFxItem>
		{
			GroupName = "FX1"
		};

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000299 RID: 665 RVA: 0x00005420 File Offset: 0x00003620
		// (set) Token: 0x0600029A RID: 666 RVA: 0x00005428 File Offset: 0x00003628
		public GroupInfo<AuxFxItem> FX2 { get; set; } = new GroupInfo<AuxFxItem>
		{
			GroupName = "FX2"
		};

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600029B RID: 667 RVA: 0x00005431 File Offset: 0x00003631
		// (set) Token: 0x0600029C RID: 668 RVA: 0x00005439 File Offset: 0x00003639
		public GroupInfo<AuxFxItem> Aux1 { get; set; } = new GroupInfo<AuxFxItem>
		{
			GroupName = "Aux1"
		};

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x0600029D RID: 669 RVA: 0x00005442 File Offset: 0x00003642
		// (set) Token: 0x0600029E RID: 670 RVA: 0x0000544A File Offset: 0x0000364A
		public GroupInfo<AuxFxItem> Aux2 { get; set; } = new GroupInfo<AuxFxItem>
		{
			GroupName = "Aux2"
		};

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x0600029F RID: 671 RVA: 0x00005453 File Offset: 0x00003653
		// (set) Token: 0x060002A0 RID: 672 RVA: 0x0000545B File Offset: 0x0000365B
		public GroupInfo<AuxFxItem> Aux3 { get; set; } = new GroupInfo<AuxFxItem>
		{
			GroupName = "Aux3"
		};

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x060002A1 RID: 673 RVA: 0x00005464 File Offset: 0x00003664
		// (set) Token: 0x060002A2 RID: 674 RVA: 0x0000546C File Offset: 0x0000366C
		public GroupInfo<AuxFxItem> Aux4 { get; set; } = new GroupInfo<AuxFxItem>
		{
			GroupName = "Aux4"
		};

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x060002A3 RID: 675 RVA: 0x00005475 File Offset: 0x00003675
		// (set) Token: 0x060002A4 RID: 676 RVA: 0x0000547D File Offset: 0x0000367D
		public GroupInfo<AuxFxItem> Aux5 { get; set; } = new GroupInfo<AuxFxItem>
		{
			GroupName = "Aux5"
		};

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x060002A5 RID: 677 RVA: 0x00005486 File Offset: 0x00003686
		// (set) Token: 0x060002A6 RID: 678 RVA: 0x0000548E File Offset: 0x0000368E
		public GroupInfo<AuxFxItem> Aux6 { get; set; } = new GroupInfo<AuxFxItem>
		{
			GroupName = "Aux6"
		};

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x060002A7 RID: 679 RVA: 0x00005497 File Offset: 0x00003697
		// (set) Token: 0x060002A8 RID: 680 RVA: 0x0000549F File Offset: 0x0000369F
		public GroupInfo<AuxFxItem> Aux7 { get; set; } = new GroupInfo<AuxFxItem>
		{
			GroupName = "Aux7"
		};

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x060002A9 RID: 681 RVA: 0x000054A8 File Offset: 0x000036A8
		// (set) Token: 0x060002AA RID: 682 RVA: 0x000054B0 File Offset: 0x000036B0
		public GroupInfo<AuxFxItem> Aux8 { get; set; } = new GroupInfo<AuxFxItem>
		{
			GroupName = "Aux8"
		};

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x060002AB RID: 683 RVA: 0x000054B9 File Offset: 0x000036B9
		// (set) Token: 0x060002AC RID: 684 RVA: 0x000054C1 File Offset: 0x000036C1
		public GroupInfo<AuxFxItem> Main { get; set; } = new GroupInfo<AuxFxItem>
		{
			GroupName = "Main"
		};

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060002AD RID: 685 RVA: 0x000054CA File Offset: 0x000036CA
		// (set) Token: 0x060002AE RID: 686 RVA: 0x000054D2 File Offset: 0x000036D2
		public RelayCommand AllPostCommand { get; set; }

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060002AF RID: 687 RVA: 0x000054DB File Offset: 0x000036DB
		// (set) Token: 0x060002B0 RID: 688 RVA: 0x000054E3 File Offset: 0x000036E3
		public RelayCommand AllPreCommand { get; set; }

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060002B1 RID: 689 RVA: 0x000054EC File Offset: 0x000036EC
		// (set) Token: 0x060002B2 RID: 690 RVA: 0x000054F4 File Offset: 0x000036F4
		public RelayCommand RouteSelectChangeCommand { get; private set; }

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060002B3 RID: 691 RVA: 0x000054FD File Offset: 0x000036FD
		// (set) Token: 0x060002B4 RID: 692 RVA: 0x00005505 File Offset: 0x00003705
		public RelayCommand<int> PostClickCommand { get; private set; }

		// Token: 0x060002B5 RID: 693 RVA: 0x000175DC File Offset: 0x000157DC
		public Route()
		{
			this.SelectIndex = 0;
			this.InitializeCommands();
			this.InitializeChannelGroup();
			this.ChannelGroup.Add(this.Main);
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_AllAuxPost), new Action<byte[]>(this.AllPostExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_SyncCommand), new Action<byte[]>(this.SynchronizePageExecute));
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x000177D4 File Offset: 0x000159D4
		private void PostClickExecute(int obj)
		{
			ChannelInfo channelInfo = ChannelInfo.ChannelInfos[obj];
			bool flag = this.SelectIndex < 4 || this.SelectIndex > 7;
			if (flag)
			{
				UpStreamCommand.SendCMD_Aux1_4FX1_2(channelInfo);
			}
			else
			{
				UpStreamCommand.SendCMD_FatChannel(channelInfo);
			}
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x0001781C File Offset: 0x00015A1C
		private void SynchronizePageExecute(byte[] obj)
		{
			bool flag = obj[10] == CommandConst.DEVE_PAGE_ROUTE && obj[11] != 0 && (int)obj[11] < this._SelectedIndexDeviceToPage.Length;
			if (flag)
			{
				bool flag2 = this.SelectIndex == this._SelectedIndexDeviceToPage[(int)obj[11]];
				if (!flag2)
				{
					this._UpdateSelectedRouteFromDevice = true;
					this.SelectIndex = this._SelectedIndexDeviceToPage[(int)obj[11]];
				}
			}
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00017888 File Offset: 0x00015A88
		private void RouteSelectChangeExecute()
		{
			bool updateSelectedRouteFromDevice = this._UpdateSelectedRouteFromDevice;
			if (updateSelectedRouteFromDevice)
			{
				this._UpdateSelectedRouteFromDevice = false;
			}
			else
			{
				UpStreamCommand.SendSynchronizePage(CommandConst.DEVE_PAGE_ROUTE, (byte)this._SelectedIndexPageToDevice[this.SelectIndex], 0, 0);
			}
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x0000550E File Offset: 0x0000370E
		private void AllPostExecute()
		{
			UpStreamCommand.SendRouteAllPost((byte)this._SelectedIndexPageToDevice[this.SelectIndex], 1);
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00005526 File Offset: 0x00003726
		private void AllPreExecute()
		{
			UpStreamCommand.SendRouteAllPost((byte)this._SelectedIndexPageToDevice[this.SelectIndex], 0);
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0000553E File Offset: 0x0000373E
		private void AllPostExecute(byte[] obj)
		{
			this.SelectIndex = this._SelectedIndexDeviceToPage[(int)obj[11]];
			this.IsAllPost = obj[12] == 1;
			this.IsAllPre = obj[12] == 0;
		}

		// Token: 0x060002BC RID: 700 RVA: 0x000178C8 File Offset: 0x00015AC8
		private void InitializeCommands()
		{
			this.AllPostCommand = new RelayCommand(new Action(this.AllPostExecute));
			this.AllPreCommand = new RelayCommand(new Action(this.AllPreExecute));
			this.RouteSelectChangeCommand = new RelayCommand(new Action(this.RouteSelectChangeExecute));
			this.PostClickCommand = new RelayCommand<int>(new Action<int>(this.PostClickExecute));
		}

		// Token: 0x060002BD RID: 701 RVA: 0x00017938 File Offset: 0x00015B38
		private void InitializeChannelGroup()
		{
			this.InitializeAuxGroup(this.Aux1, RouterTableColumn.Aux1);
			this.InitializeAuxGroup(this.Aux2, RouterTableColumn.Aux2);
			this.InitializeAuxGroup(this.Aux3, RouterTableColumn.Aux3);
			this.InitializeAuxGroup(this.Aux4, RouterTableColumn.Aux4);
			this.InitializeAuxGroup(this.Aux5, RouterTableColumn.Aux5);
			this.InitializeAuxGroup(this.Aux6, RouterTableColumn.Aux6);
			this.InitializeAuxGroup(this.Aux7, RouterTableColumn.Aux7);
			this.InitializeAuxGroup(this.Aux8, RouterTableColumn.Aux8);
			this.InitializeAuxGroup(this.FX1, RouterTableColumn.FX1);
			this.InitializeAuxGroup(this.FX2, RouterTableColumn.FX2);
			this.InitializeMainGroup();
		}

		// Token: 0x060002BE RID: 702 RVA: 0x000179DC File Offset: 0x00015BDC
		private void InitializeMainGroup()
		{
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.CH01);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.CH02);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.CH03);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.CH04);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.CH05);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.CH06);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.CH07);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.CH08);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.CH09);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.CH10);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.CH11);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.CH12);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.CH13);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.CH14);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.CH15);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.CH16);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.CH17);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.CH18);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.CH19);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.CH20);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.CH21);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.CH22);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.CH23);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.CH24);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.FX01);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.FX02);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.Aux01);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.Aux02);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.Aux03);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.Aux04);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.Aux05);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.Aux06);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.Aux07);
			this.AssignMainChannelGroup.Add(ChannelData.ChannelDatas.Aux08);
		}

		// Token: 0x060002BF RID: 703 RVA: 0x00017CD8 File Offset: 0x00015ED8
		private void InitializeAuxGroup(GroupInfo<AuxFxItem> groupInfo, RouterTableColumn column)
		{
			AuxFxItem[] column2 = RouterData.RouterAdapter.GetColumn(column);
			foreach (AuxFxItem auxFxItem in column2)
			{
				groupInfo.Add(auxFxItem);
				auxFxItem.Command = this.PostClickCommand;
			}
			this.ChannelGroup.Add(groupInfo);
		}

		// Token: 0x040001E0 RID: 480
		private GroupInfo<AuxFxItem> _SelectedCollection = new GroupInfo<AuxFxItem>();

		// Token: 0x040001E1 RID: 481
		private int _SelectIndex;

		// Token: 0x040001E2 RID: 482
		private bool _IsAllPost;

		// Token: 0x040001E3 RID: 483
		private bool _IsAllPre;

		// Token: 0x040001E4 RID: 484
		private ObservableCollection<GroupInfo<AuxFxItem>> _ChannelGroups = new ObservableCollection<GroupInfo<AuxFxItem>>();

		// Token: 0x040001E5 RID: 485
		private bool _IsMainGroup;

		// Token: 0x040001E6 RID: 486
		private bool _IsAuxFXGroup = true;

		// Token: 0x040001E7 RID: 487
		private ObservableCollection<ChannelInfo> _AssignMainChannelGroup = new ObservableCollection<ChannelInfo>();

		// Token: 0x040001F7 RID: 503
		private int[] _SelectedIndexDeviceToPage = new int[]
		{
			-1, 10, 4, 5, 6, 7, 0, 1, 2, 3,
			8, 9
		};

		// Token: 0x040001F8 RID: 504
		private int[] _SelectedIndexPageToDevice = new int[]
		{
			6, 7, 8, 9, 2, 3, 4, 5, 10, 11,
			1
		};

		// Token: 0x040001F9 RID: 505
		private bool _UpdateSelectedRouteFromDevice;
	}
}
