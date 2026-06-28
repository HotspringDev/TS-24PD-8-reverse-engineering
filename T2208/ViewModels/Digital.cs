using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using JayLib.Localization;
using JayLib.WPF.BasicClass;
using T2208.DeviceCommuncation;
using T2208.Models;
using T2208.MyDatas;
using T2208.MyInformations;

namespace T2208.ViewModels
{
	// Token: 0x0200002F RID: 47
	public class Digital : ViewModelBase
	{
		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x000134DC File Offset: 0x000116DC
		// (set) Token: 0x060001D2 RID: 466 RVA: 0x00004831 File Offset: 0x00002A31
		public ObservableCollection<GroupInfo<DigitalInfo>> ChannelGroup
		{
			get
			{
				return this._ChannelGroup;
			}
			set
			{
				this._ChannelGroup = value;
				this.OnPropertyChanged<ObservableCollection<GroupInfo<DigitalInfo>>>(() => this.ChannelGroup);
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x000134F4 File Offset: 0x000116F4
		// (set) Token: 0x060001D4 RID: 468 RVA: 0x00004871 File Offset: 0x00002A71
		public GroupInfo<DigitalInfo> SelectedGroup
		{
			get
			{
				return this._SelectedGroup;
			}
			set
			{
				this._SelectedGroup = value;
				this.OnPropertyChanged<GroupInfo<DigitalInfo>>(() => this.SelectedGroup);
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x0001350C File Offset: 0x0001170C
		// (set) Token: 0x060001D6 RID: 470 RVA: 0x00013524 File Offset: 0x00011724
		public int SelectedIndex
		{
			get
			{
				return this._SelectedIndex;
			}
			set
			{
				this._SelectedIndex = value;
				this.OnPropertyChanged<int>(() => this.SelectedIndex);
				Digital.SelectedDigitalIndex = value;
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060001D7 RID: 471 RVA: 0x00013578 File Offset: 0x00011778
		// (set) Token: 0x060001D8 RID: 472 RVA: 0x000048B1 File Offset: 0x00002AB1
		public bool AllPost
		{
			get
			{
				return this._AllPost;
			}
			set
			{
				this._AllPost = value;
				this.OnPropertyChanged<bool>(() => this.AllPost);
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x000048F1 File Offset: 0x00002AF1
		// (set) Token: 0x060001DA RID: 474 RVA: 0x000048F9 File Offset: 0x00002AF9
		public GroupInfo<DigitalInfo> OutputGroup { get; set; } = new GroupInfo<DigitalInfo>
		{
			GroupName = LocalizationManager.GetString("Str_DigitalOutput"),
			HasAllPost = true
		};

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060001DB RID: 475 RVA: 0x00004902 File Offset: 0x00002B02
		// (set) Token: 0x060001DC RID: 476 RVA: 0x0000490A File Offset: 0x00002B0A
		public GroupInfo<DigitalInfo> InputGroup { get; set; } = new GroupInfo<DigitalInfo>
		{
			GroupName = LocalizationManager.GetString("Str_DigitalInput"),
			HasAllPost = false
		};

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060001DD RID: 477 RVA: 0x00004913 File Offset: 0x00002B13
		// (set) Token: 0x060001DE RID: 478 RVA: 0x0000491B File Offset: 0x00002B1B
		public RelayCommand SelectDigitalGourpCommand { get; private set; }

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060001DF RID: 479 RVA: 0x00004924 File Offset: 0x00002B24
		// (set) Token: 0x060001E0 RID: 480 RVA: 0x0000492C File Offset: 0x00002B2C
		public RelayCommand DigitalInputChangeCommand { get; private set; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x00004935 File Offset: 0x00002B35
		// (set) Token: 0x060001E2 RID: 482 RVA: 0x0000493D File Offset: 0x00002B3D
		public RelayCommand DigitalOutputChangeCommand { get; private set; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x00004946 File Offset: 0x00002B46
		// (set) Token: 0x060001E4 RID: 484 RVA: 0x0000494E File Offset: 0x00002B4E
		public RelayCommand DigitalOutputAllPostChangeCammand { get; private set; }

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060001E5 RID: 485 RVA: 0x00004957 File Offset: 0x00002B57
		// (set) Token: 0x060001E6 RID: 486 RVA: 0x0000495F File Offset: 0x00002B5F
		public RelayCommand ShowChannelMappingCommand { get; private set; }

		// Token: 0x060001E7 RID: 487 RVA: 0x00013590 File Offset: 0x00011790
		public Digital()
		{
			this.SelectDigitalGourpCommand = new RelayCommand(new Action(this.SelectDigitalGroupExecute));
			this.DigitalInputChangeCommand = new RelayCommand(new Action(this.DigitalInputChangeExecute));
			this.DigitalOutputChangeCommand = new RelayCommand(new Action(this.DigitalOutputChangeExecute));
			this.DigitalOutputAllPostChangeCammand = new RelayCommand(new Action(this.DigitalOutputAllPostChangeExecute));
			this.ShowChannelMappingCommand = new RelayCommand(new Action(this.ShowChannelMappingExecute));
			foreach (ChannelInfo channelInfo in ChannelData.ChannelDatas.CH01_24)
			{
				this.InputGroup.Add(channelInfo.DigitalInput);
				bool flag = channelInfo.ChannelIndex != 20 && channelInfo.ChannelIndex != 21 && channelInfo.ChannelIndex != 22 && channelInfo.ChannelIndex != 23;
				if (flag)
				{
					this.OutputGroup.Add(channelInfo.DigitalOutput);
				}
			}
			foreach (ChannelInfo channelInfo2 in ChannelData.ChannelDatas.Aux1_8)
			{
				this.OutputGroup.Add(channelInfo2.DigitalOutput);
			}
			this.OutputGroup.Add(ChannelData.ChannelDatas.Main.DigitalOutput);
			this.OutputGroup.Add(ChannelData.ChannelDatas.Solo.DigitalOutput);
			foreach (DigitalInfo digitalInfo in this.InputGroup.GroupCollection)
			{
				digitalInfo.CommonCommand = this.DigitalInputChangeCommand;
			}
			foreach (DigitalInfo digitalInfo2 in this.OutputGroup.GroupCollection)
			{
				digitalInfo2.CommonCommand = this.DigitalOutputChangeCommand;
			}
			this.ChannelGroup.Add(this.InputGroup);
			this.ChannelGroup.Add(this.OutputGroup);
			LocalizationManager.LanguageChangedEvent += this.LocalizationManager_LanguageChangedEvent;
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_ReadCurrentScene), new Action<byte[]>(this.ReadCurrentSceneExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_DigltalOut), new Action<byte[]>(this.UpdateDigitalOutputExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_SyncCommand), new Action<byte[]>(this.SynchronizePageExecute));
			this.channelInfos.AddRange(ChannelData.ChannelDatas.CH01_24);
			this.channelInfos.AddRange(ChannelData.ChannelDatas.Aux1_8);
			this.channelInfos.Add(ChannelData.ChannelDatas.Main);
			this.channelInfos.Add(ChannelData.ChannelDatas.Solo);
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00004968 File Offset: 0x00002B68
		private void DigitalOutputChangeExecute()
		{
			UpStreamCommand.SendDigitalOutput(this.AllPost, this.channelInfos.ToArray());
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00013970 File Offset: 0x00011B70
		private void ShowChannelMappingExecute()
		{
			bool flag = this.SelectedIndex == 0;
			if (flag)
			{
				ChannelMappingWindow channelMappingWindow = new ChannelMappingWindow
				{
					DataContext = new ChannelMappingViewModel(true),
					Owner = WindowHelper.GetTopWindow()
				};
				channelMappingWindow.Show();
			}
			else
			{
				ChannelMappingWindow channelMappingWindow2 = new ChannelMappingWindow
				{
					DataContext = new ChannelMappingViewModel(false),
					Owner = WindowHelper.GetTopWindow()
				};
				channelMappingWindow2.Show();
			}
		}

		// Token: 0x060001EA RID: 490 RVA: 0x000139E0 File Offset: 0x00011BE0
		private void DigitalOutputAllPostChangeExecute()
		{
			bool allPost = this.AllPost;
			if (allPost)
			{
				bool flag = MessageBox.Show(LocalizationManager.GetString("Str_DigitalAllPostTips"), LocalizationManager.GetString("Str_Tips"), MessageBoxButton.YesNo) == MessageBoxResult.Yes;
				if (flag)
				{
					UpStreamCommand.SendDigitalOutput(this.AllPost, this.channelInfos.ToArray());
				}
				else
				{
					this.AllPost = false;
				}
			}
			else
			{
				UpStreamCommand.SendDigitalOutput(this.AllPost, this.channelInfos.ToArray());
			}
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00013A5C File Offset: 0x00011C5C
		private void DigitalInputChangeExecute()
		{
			for (int i = 0; i < this.InputGroup.GroupCollection.Count; i++)
			{
				DigitalInfo digitalInfo = this.InputGroup.GroupCollection[i];
				bool flag = (int)digitalInfo.SendValue != digitalInfo.Value || digitalInfo.IsFrontSet != digitalInfo.TempInputIsFrontSet;
				if (flag)
				{
					UpStreamCommand.SendCMD_FatChannel(ChannelData.ChannelDatas.CH01_24[i]);
				}
			}
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00013ADC File Offset: 0x00011CDC
		private void SelectDigitalGroupExecute()
		{
			bool updateFromUi = this._UpdateFromUi;
			if (!updateFromUi)
			{
				UpStreamCommand.SendSynchronizePage(CommandConst.DEVE_PAGE_DIGITAL, (byte)this.SelectedIndex, 0, 0);
			}
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00013B10 File Offset: 0x00011D10
		private void SynchronizePageExecute(byte[] obj)
		{
			bool flag = obj[10] == CommandConst.DEVE_PAGE_DIGITAL;
			if (flag)
			{
				bool flag2 = this.SelectedIndex != (int)obj[11];
				if (flag2)
				{
					this._UpdateFromUi = true;
				}
				bool flag3 = obj[11] == 0;
				if (flag3)
				{
					this.SelectedIndex = 0;
				}
				else
				{
					this.SelectedIndex = 1;
				}
			}
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00013B6C File Offset: 0x00011D6C
		private void UpdateDigitalOutputExecute(byte[] obj)
		{
			int num = 12;
			for (int i = 0; i < 20; i++)
			{
				byte b = obj[num++];
				this.channelInfos[i].DigitalOutput.IsFrontSet = b > 127;
				this.channelInfos[i].DigitalOutput.Value = (int)(b & 127);
			}
			for (int j = 24; j < 34; j++)
			{
				byte b2 = obj[num++];
				this.channelInfos[j].DigitalOutput.IsFrontSet = b2 > 127;
				this.channelInfos[j].DigitalOutput.Value = (int)(b2 & 127);
			}
			this.AllPost = obj[num++] == 0;
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00013C40 File Offset: 0x00011E40
		private void ReadCurrentSceneExecute(byte[] obj)
		{
			int num = 3985;
			for (int i = 0; i < 20; i++)
			{
				byte b = obj[num++];
				ChannelData.ChannelDatas.DeviceChannels[i].DigitalOutput.IsFrontSet = b > 127;
				ChannelData.ChannelDatas.DeviceChannels[i].DigitalOutput.Value = (int)(b & 127);
			}
			for (int j = 0; j < 10; j++)
			{
				byte b2 = obj[num++];
				ChannelData.ChannelDatas.DeviceChannels[24 + j].DigitalOutput.IsFrontSet = b2 > 127;
				ChannelData.ChannelDatas.DeviceChannels[24 + j].DigitalOutput.Value = (int)(b2 & 127);
			}
			num = 4697;
			this.AllPost = obj[num++] == 0;
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00004982 File Offset: 0x00002B82
		private void LocalizationManager_LanguageChangedEvent(string lanugage)
		{
			this.InputGroup.GroupName = LocalizationManager.GetString("Str_DigitalInput");
			this.OutputGroup.GroupName = LocalizationManager.GetString("Str_DigitalOutput");
		}

		// Token: 0x040000F4 RID: 244
		private ObservableCollection<GroupInfo<DigitalInfo>> _ChannelGroup = new ObservableCollection<GroupInfo<DigitalInfo>>();

		// Token: 0x040000F5 RID: 245
		public static int SelectedDigitalIndex = 0;

		// Token: 0x040000F6 RID: 246
		private GroupInfo<DigitalInfo> _SelectedGroup;

		// Token: 0x040000F7 RID: 247
		private int _SelectedIndex;

		// Token: 0x040000F8 RID: 248
		private bool _AllPost;

		// Token: 0x04000100 RID: 256
		private bool _UpdateFromUi;

		// Token: 0x04000101 RID: 257
		private List<ChannelInfo> channelInfos = new List<ChannelInfo>();
	}
}
