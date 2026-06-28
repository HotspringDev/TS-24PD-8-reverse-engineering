using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CommLibrary;
using JayLib.Localization;
using JayLib.WPF.BasicClass;
using T2208.DeviceCommuncation;
using T2208.Models;
using T2208.MyDatas;
using T2208.MyInformations;
using T2208.MyUserControls;
using T2208.ViewModels;
using T2208.Views;

namespace T2208
{
	// Token: 0x0200000D RID: 13
	public class MainWindowViewModel : NotificationObject
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00003983 File Offset: 0x00001B83
		// (set) Token: 0x06000049 RID: 73 RVA: 0x0000398B File Offset: 0x00001B8B
		public RelayCommand StartScanDeviceCommand { get; private set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00003994 File Offset: 0x00001B94
		// (set) Token: 0x0600004B RID: 75 RVA: 0x0000399C File Offset: 0x00001B9C
		public RelayCommand StopScanDeviceCommand { get; private set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600004C RID: 76 RVA: 0x000039A5 File Offset: 0x00001BA5
		// (set) Token: 0x0600004D RID: 77 RVA: 0x000039AD File Offset: 0x00001BAD
		public RelayCommand<DeviceModule> ConnectCommand { get; private set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600004E RID: 78 RVA: 0x000039B6 File Offset: 0x00001BB6
		// (set) Token: 0x0600004F RID: 79 RVA: 0x000039BE File Offset: 0x00001BBE
		public RelayCommand MouseEnterCommand { get; private set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000050 RID: 80 RVA: 0x0000AE94 File Offset: 0x00009094
		// (set) Token: 0x06000051 RID: 81 RVA: 0x000039C7 File Offset: 0x00001BC7
		public ObservableCollection<DeviceInfo> DeviceCollection
		{
			get
			{
				return this._DeviceCollection;
			}
			set
			{
				this._DeviceCollection = value;
				this.OnPropertyChanged<ObservableCollection<DeviceInfo>>(() => this.DeviceCollection);
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000052 RID: 82 RVA: 0x0000AEAC File Offset: 0x000090AC
		// (set) Token: 0x06000053 RID: 83 RVA: 0x00003A07 File Offset: 0x00001C07
		public ObservableCollection<PageItem> PageItemCollection
		{
			get
			{
				return this._PageItemCollection;
			}
			set
			{
				this._PageItemCollection = value;
				this.OnPropertyChanged<ObservableCollection<PageItem>>(() => this.PageItemCollection);
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000054 RID: 84 RVA: 0x0000AEC4 File Offset: 0x000090C4
		// (set) Token: 0x06000055 RID: 85 RVA: 0x00003A47 File Offset: 0x00001C47
		public Page PageContent
		{
			get
			{
				return this._PageContent;
			}
			set
			{
				this._PageContent = value;
				this.OnPropertyChanged<Page>(() => this.PageContent);
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000056 RID: 86 RVA: 0x0000AEDC File Offset: 0x000090DC
		// (set) Token: 0x06000057 RID: 87 RVA: 0x0000AEF4 File Offset: 0x000090F4
		public int SelectedLanguage
		{
			get
			{
				return this._SelectedLanugae;
			}
			set
			{
				this._SelectedLanugae = value;
				this.OnPropertyChanged<int>(() => this.SelectedLanguage);
				this.Setlanguage();
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000058 RID: 88 RVA: 0x0000AF48 File Offset: 0x00009148
		// (set) Token: 0x06000059 RID: 89 RVA: 0x00003A87 File Offset: 0x00001C87
		public bool IsConnected
		{
			get
			{
				return this._IsConnected;
			}
			set
			{
				this._IsConnected = value;
				this.OnPropertyChanged<bool>(() => this.IsConnected);
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600005A RID: 90 RVA: 0x0000AF60 File Offset: 0x00009160
		// (set) Token: 0x0600005B RID: 91 RVA: 0x00003AC7 File Offset: 0x00001CC7
		public bool IsBusy
		{
			get
			{
				return this._IsBusy;
			}
			set
			{
				this._IsBusy = value;
				this.OnPropertyChanged<bool>(() => this.IsBusy);
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600005C RID: 92 RVA: 0x0000AF78 File Offset: 0x00009178
		// (set) Token: 0x0600005D RID: 93 RVA: 0x00003B07 File Offset: 0x00001D07
		public bool IsShowDeviceList
		{
			get
			{
				return this._IsShowDeviceList;
			}
			set
			{
				this._IsShowDeviceList = value;
				this.OnPropertyChanged<bool>(() => this.IsShowDeviceList);
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00003B47 File Offset: 0x00001D47
		// (set) Token: 0x0600005F RID: 95 RVA: 0x00003B4F File Offset: 0x00001D4F
		public string[] Languages { get; set; } = new string[] { "English", "中文" };

		// Token: 0x06000060 RID: 96 RVA: 0x0000AF90 File Offset: 0x00009190
		public MainWindowViewModel()
		{
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_AckCommd), new Action<byte[]>(this.ACKExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_DefaultPreset), new Action<byte[]>(this.DefaultSettingExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_SyncCommand), new Action<byte[]>(this.SynchronizePageExecute));
			this._ShowPage = new RelayCommand<PageItem>(new Action<PageItem>(this.ShowPageExecute));
			this.StartScanDeviceCommand = new RelayCommand(new Action(this.StartScanDeviceExecute));
			this.StopScanDeviceCommand = new RelayCommand(new Action(this.StopScanDeviceExecute));
			this.MouseEnterCommand = new RelayCommand(new Action(this.MouseEnterExeucte));
			this._connectCommand = new RelayCommand<DeviceInfo>(new Action<DeviceInfo>(this.ConnectExecute));
			this.PageItemCollection.Add(new PageItem
			{
				NameKey = "Str_DSP",
				Command = new RelayCommand<PageItem>(new Action<PageItem>(this.ShowPageExecute)),
				Page = new AssignChannel
				{
					DataContext = new DSP
					{
						ChannelInfo = ChannelData.ChannelDatas.CH01,
						PageType = PageType.Gate_Equalize_Compressor
					}
				},
				DevicePageIndex = 
				{
					CommandConst.DEVE_PAGE_CHANNEL,
					CommandConst.DEVE_PAGE_ASSIGN,
					CommandConst.DEVE_PAGE_COMP,
					CommandConst.DEVE_PAGE_GATE
				}
			});
			this.PageItemCollection.Add(new PageItem
			{
				NameKey = "Str_DCA",
				Command = new RelayCommand<PageItem>(new Action<PageItem>(this.ShowPageExecute)),
				Page = new Page_DCA
				{
					DataContext = new DCA
					{
						PageType = PageType.DCASetting
					}
				},
				DevicePageIndex = { CommandConst.DEVE_PAGE_GROUP }
			});
			this.PageItemCollection.Add(new PageItem
			{
				NameKey = "Str_Route",
				Command = new RelayCommand<PageItem>(new Action<PageItem>(this.ShowPageExecute)),
				Page = new T2208.Views.Route
				{
					DataContext = new T2208.ViewModels.Route
					{
						PageType = PageType.Router
					}
				},
				DevicePageIndex = { CommandConst.DEVE_PAGE_ROUTE }
			});
			this.PageItemCollection.Add(new PageItem
			{
				NameKey = "Str_GEQ",
				Command = new RelayCommand<PageItem>(new Action<PageItem>(this.ShowPageExecute)),
				Page = new T2208.Views.GEQ
				{
					DataContext = new T2208.ViewModels.GEQ
					{
						PageType = PageType.GEQ
					}
				},
				DevicePageIndex = { CommandConst.DEVE_PAGE_GEQ }
			});
			this.PageItemCollection.Add(new PageItem
			{
				NameKey = "Str_AutoMix",
				Command = new RelayCommand<PageItem>(new Action<PageItem>(this.ShowPageExecute)),
				Page = new Page_AutoMix
				{
					DataContext = new AutoMix
					{
						PageType = PageType.AutoMix
					}
				},
				DevicePageIndex = { CommandConst.DEVE_PAGE_AutoMix }
			});
			this.PageItemCollection.Add(new PageItem
			{
				NameKey = "Str_Digital",
				Command = new RelayCommand<PageItem>(new Action<PageItem>(this.ShowPageExecute)),
				Page = new Page_Digital
				{
					DataContext = new Digital
					{
						PageType = PageType.Digital
					}
				},
				DevicePageIndex = { CommandConst.DEVE_PAGE_DIGITAL }
			});
			this.PageItemCollection.Add(new PageItem
			{
				NameKey = "Str_FX",
				Command = new RelayCommand<PageItem>(new Action<PageItem>(this.ShowPageExecute)),
				Page = new Page_FX
				{
					DataContext = new FX
					{
						PageType = PageType.FX
					}
				},
				DevicePageIndex = { CommandConst.DEVE_PAGE_DFX }
			});
			this.PageItemCollection.Add(new PageItem
			{
				NameKey = "Str_SaveLoadCopy",
				Command = new RelayCommand<PageItem>(new Action<PageItem>(this.ShowPageExecute)),
				Page = new Page_SaveLoadCopy
				{
					DataContext = new SaveLoadCopy
					{
						PageType = PageType.Save_Load_Copy
					}
				},
				DevicePageIndex = 
				{
					CommandConst.DEVE_PAGE_LOADSAVE,
					CommandConst.DEVE_PAGE_COPY
				}
			});
			this.PageItemCollection.Add(new PageItem
			{
				NameKey = "Str_System",
				Command = new RelayCommand<PageItem>(new Action<PageItem>(this.ShowPageExecute)),
				Page = new Page_System
				{
					DataContext = new SystemIn
					{
						PageType = PageType.SystemSetting
					}
				},
				DevicePageIndex = { CommandConst.DEVE_PAGE_SYSTEM }
			});
			this.PageItemCollection.First<PageItem>().Command.Execute(this.PageItemCollection.First<PageItem>());
			this.PageItemCollection.First<PageItem>().IsChecked = true;
			ChannelData.ChannelDatas.CH01.IsPresentChannel = true;
			ViewModelMessager.Messeager.Register<ChannelInfo>(ViewModelMessager.UpdateChannelInfo, new Action<ChannelInfo>(this.UpdateChannelInfoExecute));
			ViewModelMessager.Messeager.Register<RouterInfo>(ViewModelMessager.FindNewDevice, new Action<RouterInfo>(this.FindNewDeviceExecute));
			ViewModelMessager.Messeager.Register<byte[]>(ViewModelMessager.FindT2208, new Action<byte[]>(this.FindT2208Execute));
			ViewModelMessager.Messeager.Register<bool>(ViewModelMessager.UpdateConnectionState, new Action<bool>(this.UpdateConnectionStateExecute));
			ViewModelMessager.Messeager.Register<bool>(ViewModelMessager.IsBusy, new Action<bool>(this.UpdateIsBusy));
			LocalizationManager.Language = "en-US";
			this.ackTimer.Elapsed += this.AckTimer_Elapsed;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x0000B5F8 File Offset: 0x000097F8
		private void UpdateIsBusy(bool obj)
		{
			Application.Current.Dispatcher.Invoke(delegate
			{
				this.IsBusy = obj;
			});
			UpStream.SendCMD_ACK();
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000B63C File Offset: 0x0000983C
		private void UpdateConnectionStateExecute(bool isConnected)
		{
			this.IsConnected = isConnected;
			if (isConnected)
			{
				this.IsShowDeviceList = false;
			}
			if (isConnected)
			{
				this.ackTimer.Start();
			}
			else
			{
				this.ackTimer.Stop();
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00003B58 File Offset: 0x00001D58
		private void MouseEnterExeucte()
		{
			UpStreamCommand.SendSynchronizePage(this.uiIndex1, this.uiIndex2, this.uiIndex3, this.uiIndex4);
		}

		// Token: 0x06000064 RID: 100 RVA: 0x0000B684 File Offset: 0x00009884
		private void SynchronizePageExecute(byte[] obj)
		{
			byte b = obj[12];
			bool flag = PageData.PresentPageType == PageType.Save_Load_Copy && b == CommandConst.DEVE_PAGE_SYSTEM;
			if (!flag)
			{
				foreach (PageItem pageItem in this.PageItemCollection)
				{
					bool flag2 = pageItem.DevicePageIndex.Contains(b) && (int)b != this.presentPageIndex;
					if (flag2)
					{
						this.presentPageIndex = (int)b;
						this.uiUpdateFromDevice = true;
						pageItem.Command.Execute(pageItem);
						pageItem.IsChecked = true;
						this.uiIndex1 = obj[12];
						this.uiIndex2 = obj[13];
						this.uiIndex3 = obj[14];
						this.uiIndex4 = obj[15];
					}
				}
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x0000B768 File Offset: 0x00009968
		private void AckTimer_Elapsed(object sender, ElapsedEventArgs e)
		{
			this.receiveACK++;
			bool flag = this.receiveACK < 8;
			if (flag)
			{
				UpStream.SendCMD_ACK();
			}
			bool flag2 = this.receiveACK == 8;
			if (flag2)
			{
				this.IsConnected = false;
				Cilent cilent = ConnectionModel.GetCilent();
				if (cilent != null)
				{
					cilent.disConnect();
				}
				NetCilent.netCilent.disConnect();
				ComCilent.comCilent.disConnect();
				this.ackTimer.Stop();
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000B7E4 File Offset: 0x000099E4
		private void FindNewDeviceExecute(RouterInfo obj)
		{
			int index = this.DeviceCollection.Count;
			Application.Current.Dispatcher.Invoke(delegate
			{
				this.DeviceCollection.Add(new DeviceInfo
				{
					DeviceAddress = obj.RouterAddr,
					DeviceMac = obj.RouterMac,
					DeviceIndex = index,
					ConnectCommand = this._connectCommand
				});
				this.receiveACK = 0;
			});
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000B834 File Offset: 0x00009A34
		private void FindT2208Execute(byte[] obj)
		{
			Application.Current.Dispatcher.Invoke(delegate
			{
				DeviceInfo deviceInfo = new DeviceInfo();
				foreach (DeviceInfo deviceInfo2 in this.DeviceCollection)
				{
					bool flag = deviceInfo2.DeviceAddress == MainData.ConnectionModel.ConnectingIP;
					if (flag)
					{
						deviceInfo.DeviceAddress = deviceInfo2.DeviceAddress;
						deviceInfo.DeviceMac = deviceInfo2.DeviceMac;
					}
				}
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < 16; i++)
				{
					bool flag2 = obj[12 + i] != 32 && obj[12 + i] > 0;
					if (flag2)
					{
						stringBuilder.Append((char)obj[12 + i]);
					}
				}
				deviceInfo.DeviceName = stringBuilder.ToString();
				this.DeviceCollection.Clear();
				this.DeviceCollection.Add(deviceInfo);
			});
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00003B79 File Offset: 0x00001D79
		private void DefaultSettingExecute(byte[] obj)
		{
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000B874 File Offset: 0x00009A74
		private void ACKExecute(byte[] obj)
		{
			this.receiveACK = 0;
			bool flag = obj[11] == 1;
			bool flag2 = obj[12] == 1;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000B89C File Offset: 0x00009A9C
		private void UpdateChannelInfoExecute(ChannelInfo obj)
		{
			DSP dsp = this.PageItemCollection[0].Page.DataContext as DSP;
			dsp.ChannelInfo = obj;
			ChannelData.PresentChannelIndex = (int)obj.ChannelIndex;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000B8DC File Offset: 0x00009ADC
		private void ShowPageExecute(PageItem obj)
		{
			this.PageContent = obj.Page;
			PageData.PresentPageType = ((ViewModelBase)obj.Page.DataContext).PageType;
			bool flag = obj.DevicePageIndex != null;
			if (flag)
			{
				bool flag2 = this.uiUpdateFromDevice;
				if (flag2)
				{
					this.uiUpdateFromDevice = false;
				}
				else
				{
					byte b = obj.DevicePageIndex.First<byte>();
					bool flag3 = b == CommandConst.DEVE_PAGE_CHANNEL;
					if (flag3)
					{
						UpStreamCommand.SendSynchronizePage(b, (byte)(ChannelData.PresentChannelIndex + 1), 0, 0);
					}
					bool flag4 = b == CommandConst.DEVE_PAGE_ROUTE;
					if (flag4)
					{
						UpStreamCommand.SendSynchronizePage(b, RouterData.SelectedRouteDeviceIndex, 0, 0);
					}
					bool flag5 = b == CommandConst.DEVE_PAGE_GROUP;
					if (flag5)
					{
						byte b2 = 0;
						foreach (DCAInfo<DCAItem> dcainfo in DCAData.DCAs)
						{
							bool isSelected = dcainfo.IsSelected;
							if (isSelected)
							{
								b2 = (byte)dcainfo.DCAIndex;
							}
						}
						UpStreamCommand.SendSynchronizePage(b, b2, 0, 0);
					}
					bool flag6 = b == CommandConst.DEVE_PAGE_GEQ;
					if (flag6)
					{
						UpStreamCommand.SendSynchronizePage(CommandConst.DEVE_PAGE_HOME, GEQData.DeviceGEQAuxToChannelAuxDictionary[T2208.Views.GEQ.SelectedGEQDeviceIndex], 0, 0);
						UpStreamCommand.SendSynchronizePage(b, T2208.Views.GEQ.SelectedGEQDeviceIndex, 0, 0);
					}
					bool flag7 = b == CommandConst.DEVE_PAGE_AutoMix;
					if (flag7)
					{
						UpStreamCommand.SendSynchronizePage(b, 1, 0, 0);
					}
					bool flag8 = b == CommandConst.DEVE_PAGE_DIGITAL;
					if (flag8)
					{
						UpStreamCommand.SendSynchronizePage(b, (byte)Digital.SelectedDigitalIndex, 0, 0);
					}
					bool flag9 = b == CommandConst.DEVE_PAGE_DFX;
					if (flag9)
					{
						UpStreamCommand.SendSynchronizePage(b, (byte)(FX.FXSelectedIndex + 1), 1, 0);
					}
					bool flag10 = b == CommandConst.DEVE_PAGE_LOADSAVE;
					if (flag10)
					{
						UpStreamCommand.SendSynchronizePage(CommandConst.DEVE_PAGE_SYSTEM, 0, 0, 0);
					}
					bool flag11 = b == CommandConst.DEVE_PAGE_SYSTEM;
					if (flag11)
					{
						UpStreamCommand.SendSynchronizePage(CommandConst.DEVE_PAGE_SYSTEM, 0, 0, 0);
					}
				}
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003B79 File Offset: 0x00001D79
		private void ConnectExecute(DeviceInfo deviceInfo)
		{
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003B79 File Offset: 0x00001D79
		private void StopScanDeviceExecute()
		{
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00003B7C File Offset: 0x00001D7C
		private void StartScanDeviceExecute()
		{
			this.DeviceCollection.Clear();
			MainData.ConnectionModel.DeviceScaner.startScan();
			this.IsBusy = false;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000BAD0 File Offset: 0x00009CD0
		private void Setlanguage()
		{
			bool flag = this.SelectedLanguage == 0;
			if (flag)
			{
				LocalizationManager.Language = "en-US";
			}
			else
			{
				LocalizationManager.Language = "zh-CN";
			}
		}

		// Token: 0x0400002B RID: 43
		public RelayCommand<DeviceInfo> _connectCommand;

		// Token: 0x0400002C RID: 44
		private readonly Page_Digital page_Digital = new Page_Digital();

		// Token: 0x0400002D RID: 45
		private ObservableCollection<DeviceInfo> _DeviceCollection = new ObservableCollection<DeviceInfo>();

		// Token: 0x0400002E RID: 46
		private ObservableCollection<PageItem> _PageItemCollection = new ObservableCollection<PageItem>();

		// Token: 0x0400002F RID: 47
		private Page _PageContent;

		// Token: 0x04000030 RID: 48
		private int _SelectedLanugae;

		// Token: 0x04000031 RID: 49
		private bool _IsConnected;

		// Token: 0x04000032 RID: 50
		private bool _IsBusy;

		// Token: 0x04000033 RID: 51
		private bool _IsShowDeviceList;

		// Token: 0x04000035 RID: 53
		private Timer ackTimer = new Timer(3000.0);

		// Token: 0x04000036 RID: 54
		private bool uiUpdateFromDevice;

		// Token: 0x04000037 RID: 55
		private int presentPageIndex = -1;

		// Token: 0x04000038 RID: 56
		private int receiveACK = 0;

		// Token: 0x04000039 RID: 57
		private byte uiIndex1;

		// Token: 0x0400003A RID: 58
		private byte uiIndex2;

		// Token: 0x0400003B RID: 59
		private byte uiIndex3;

		// Token: 0x0400003C RID: 60
		private byte uiIndex4;

		// Token: 0x0400003D RID: 61
		private ICommand _ShowPage = null;
	}
}
