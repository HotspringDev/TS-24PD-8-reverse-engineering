using System;
using System.Collections.ObjectModel;
using System.Text;
using JayCustomControlLib;
using JayLib.WPF.BasicClass;
using T2208.DeviceCommuncation;
using T2208.Models;
using T2208.MyDatas;
using T2208.MyInformations;

namespace T2208.ViewModels
{
	// Token: 0x0200002A RID: 42
	public class ChannelPage : ViewModelBase
	{
		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600011E RID: 286 RVA: 0x000040FD File Offset: 0x000022FD
		// (set) Token: 0x0600011F RID: 287 RVA: 0x00004105 File Offset: 0x00002305
		public ObservableCollection<ChannelInfo> InputGroup1 { get; set; } = new ObservableCollection<ChannelInfo>();

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000120 RID: 288 RVA: 0x0000410E File Offset: 0x0000230E
		// (set) Token: 0x06000121 RID: 289 RVA: 0x00004116 File Offset: 0x00002316
		public ObservableCollection<ChannelInfo> InputGroup2 { get; set; } = new ObservableCollection<ChannelInfo>();

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000122 RID: 290 RVA: 0x0000411F File Offset: 0x0000231F
		// (set) Token: 0x06000123 RID: 291 RVA: 0x00004127 File Offset: 0x00002327
		public ObservableCollection<ChannelInfo> InputGroup3 { get; set; } = new ObservableCollection<ChannelInfo>();

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000124 RID: 292 RVA: 0x00004130 File Offset: 0x00002330
		// (set) Token: 0x06000125 RID: 293 RVA: 0x00004138 File Offset: 0x00002338
		public ObservableCollection<ChannelInfo> InputGroup4 { get; set; } = new ObservableCollection<ChannelInfo>();

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000126 RID: 294 RVA: 0x00004141 File Offset: 0x00002341
		// (set) Token: 0x06000127 RID: 295 RVA: 0x00004149 File Offset: 0x00002349
		public ObservableCollection<ChannelInfo> OutputGroup1 { get; set; } = new ObservableCollection<ChannelInfo>();

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000128 RID: 296 RVA: 0x00004152 File Offset: 0x00002352
		// (set) Token: 0x06000129 RID: 297 RVA: 0x0000415A File Offset: 0x0000235A
		public ObservableCollection<ChannelInfo> OutputGroup2 { get; set; } = new ObservableCollection<ChannelInfo>();

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600012A RID: 298 RVA: 0x00004163 File Offset: 0x00002363
		// (set) Token: 0x0600012B RID: 299 RVA: 0x0000416B File Offset: 0x0000236B
		public ObservableCollection<DCAInfo<DCAItem>> DCA1Group
		{
			get
			{
				return this._dCAGroup1;
			}
			set
			{
				this._dCAGroup1 = value;
				this.OnPropertyChanged<ObservableCollection<DCAInfo<DCAItem>>>(() => this.DCA1Group);
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600012C RID: 300 RVA: 0x000041AB File Offset: 0x000023AB
		// (set) Token: 0x0600012D RID: 301 RVA: 0x000041B3 File Offset: 0x000023B3
		public ObservableCollection<DCAInfo<DCAItem>> DCA2Group
		{
			get
			{
				return this._dCAGroup2;
			}
			set
			{
				this._dCAGroup2 = value;
				this.OnPropertyChanged<ObservableCollection<DCAInfo<DCAItem>>>(() => this.DCA2Group);
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600012E RID: 302 RVA: 0x0000E78C File Offset: 0x0000C98C
		// (set) Token: 0x0600012F RID: 303 RVA: 0x0000E7A4 File Offset: 0x0000C9A4
		public ObservableCollection<ChannelInfo> LeftGroup
		{
			get
			{
				return this._LeftGroup;
			}
			set
			{
				bool flag = this._LeftGroup == value;
				if (!flag)
				{
					this._LeftGroup = value;
					this.OnPropertyChanged<ObservableCollection<ChannelInfo>>(() => this.LeftGroup);
				}
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000130 RID: 304 RVA: 0x0000E800 File Offset: 0x0000CA00
		// (set) Token: 0x06000131 RID: 305 RVA: 0x0000E818 File Offset: 0x0000CA18
		public ObservableCollection<ChannelInfo> RightGroup
		{
			get
			{
				return this._RightGroup;
			}
			set
			{
				bool flag = this._RightGroup == value;
				if (!flag)
				{
					this._RightGroup = value;
					this.OnPropertyChanged<ObservableCollection<ChannelInfo>>(() => this.RightGroup);
				}
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000132 RID: 306 RVA: 0x0000E874 File Offset: 0x0000CA74
		// (set) Token: 0x06000133 RID: 307 RVA: 0x000041F3 File Offset: 0x000023F3
		public bool IsShowOutputGroup
		{
			get
			{
				return this._IsShowOutputGroup;
			}
			set
			{
				this._IsShowOutputGroup = value;
				this.OnPropertyChanged<bool>(() => this.IsShowOutputGroup);
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000134 RID: 308 RVA: 0x0000E88C File Offset: 0x0000CA8C
		// (set) Token: 0x06000135 RID: 309 RVA: 0x00004233 File Offset: 0x00002433
		public bool IsShowDCA1Group
		{
			get
			{
				return this._IsShowDCA1Group;
			}
			set
			{
				this._IsShowDCA1Group = value;
				this.OnPropertyChanged<bool>(() => this.IsShowDCA1Group);
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000136 RID: 310 RVA: 0x0000E8A4 File Offset: 0x0000CAA4
		// (set) Token: 0x06000137 RID: 311 RVA: 0x00004273 File Offset: 0x00002473
		public bool IsShowDCA2Group
		{
			get
			{
				return this._IsShowDCA2Group;
			}
			set
			{
				this._IsShowDCA2Group = value;
				this.OnPropertyChanged<bool>(() => this.IsShowDCA2Group);
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000138 RID: 312 RVA: 0x0000E8BC File Offset: 0x0000CABC
		// (set) Token: 0x06000139 RID: 313 RVA: 0x000042B3 File Offset: 0x000024B3
		public bool PFL
		{
			get
			{
				return this._PFL;
			}
			set
			{
				this._PFL = value;
				this.OnPropertyChanged<bool>(() => this.PFL);
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600013A RID: 314 RVA: 0x000042F3 File Offset: 0x000024F3
		// (set) Token: 0x0600013B RID: 315 RVA: 0x000042FB File Offset: 0x000024FB
		public RelayCommand<int> SwitchChannelGroupCommand { get; private set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600013C RID: 316 RVA: 0x00004304 File Offset: 0x00002504
		// (set) Token: 0x0600013D RID: 317 RVA: 0x0000430C File Offset: 0x0000250C
		public RelayCommand DCAPropertyChangeCommand { get; private set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600013E RID: 318 RVA: 0x00004315 File Offset: 0x00002515
		// (set) Token: 0x0600013F RID: 319 RVA: 0x0000431D File Offset: 0x0000251D
		public RelayCommand DCASelectCommand { get; private set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000140 RID: 320 RVA: 0x00004326 File Offset: 0x00002526
		// (set) Token: 0x06000141 RID: 321 RVA: 0x0000432E File Offset: 0x0000252E
		public RelayCommand DCAMouseEnterCommand { get; private set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000142 RID: 322 RVA: 0x00004337 File Offset: 0x00002537
		// (set) Token: 0x06000143 RID: 323 RVA: 0x0000433F File Offset: 0x0000253F
		public RelayCommand ChannelMouseEnterCommand { get; private set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000144 RID: 324 RVA: 0x00004348 File Offset: 0x00002548
		// (set) Token: 0x06000145 RID: 325 RVA: 0x00004350 File Offset: 0x00002550
		public RelayCommand ClearSoloCommand { get; private set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000146 RID: 326 RVA: 0x00004359 File Offset: 0x00002559
		// (set) Token: 0x06000147 RID: 327 RVA: 0x00004361 File Offset: 0x00002561
		public RelayCommand PFLCommand { get; private set; }

		// Token: 0x06000148 RID: 328 RVA: 0x0000E8D4 File Offset: 0x0000CAD4
		public ChannelPage()
		{
			this.InitializeCommands();
			this.InitializeDCAGroup();
			this.InitializeChannelGroup();
			this.LeftGroup = this.InputGroup1;
			this.RightGroup = this.OutputGroup1;
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_SyncCommand), new Action<byte[]>(this.SychronizeChannelExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_DefaultPreset), new Action<byte[]>(this.DefaultPresetExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_ReadCurrentScene), new Action<byte[]>(this.ReadCurrentSceneExecute));
		}

		// Token: 0x06000149 RID: 329 RVA: 0x0000EA1C File Offset: 0x0000CC1C
		private void ReadCurrentSceneExecute(byte[] obj)
		{
			SceneData.SceneInfo.PFL = (this.PFL = obj[4713] == 0);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0000EA4C File Offset: 0x0000CC4C
		private void SetChannelNameExecute(byte[] obj)
		{
			int num = (int)(obj[11] - 1);
			ChannelInfo channelInfo = ChannelData.ChannelDatas.DeviceChannels[num];
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < 8; i++)
			{
				bool flag = obj[12 + i] != 32 && obj[10 + i] > 0;
				if (flag)
				{
					stringBuilder.Append((char)obj[10 + i]);
				}
			}
			channelInfo.ChannelName = stringBuilder.ToString();
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0000EAC4 File Offset: 0x0000CCC4
		private void DefaultPresetExecute(byte[] obj)
		{
			SceneData.SceneInfo.PFL = (this.PFL = obj[59] == 0);
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0000EAF0 File Offset: 0x0000CCF0
		private void SychronizeChannelExecute(byte[] obj)
		{
			byte b = obj[11];
			bool flag = obj[10] == CommandConst.DEVE_PAGE_HOME || obj[10] == CommandConst.DEVE_PAGE_GATE || obj[10] == CommandConst.DEVE_PAGE_COMP || obj[10] == CommandConst.DEVE_PAGE_EQUALIZER;
			if (flag)
			{
				ChannelInfo channelInfo = ChannelData.ChannelDatas.DeviceChannels[(int)(b - 1)];
				channelInfo.IsPresentChannel = true;
				ChannelInfo.ChangedHighLightStatus(channelInfo);
				ViewModelMessager.Messeager.Notify(ViewModelMessager.UpdateChannelInfo, channelInfo);
				bool flag2 = b <= 6;
				if (flag2)
				{
					JSwitcher.JSwitcherGroup["InputChannelGroup"][0].IsChecked = new bool?(true);
					this.LeftGroup = this.InputGroup1;
				}
				else
				{
					bool flag3 = b <= 12;
					if (flag3)
					{
						JSwitcher.JSwitcherGroup["InputChannelGroup"][1].IsChecked = new bool?(true);
						this.LeftGroup = this.InputGroup2;
					}
					else
					{
						bool flag4 = b <= 18;
						if (flag4)
						{
							JSwitcher.JSwitcherGroup["InputChannelGroup"][2].IsChecked = new bool?(true);
							this.LeftGroup = this.InputGroup3;
						}
						else
						{
							bool flag5 = b <= 24;
							if (flag5)
							{
								JSwitcher.JSwitcherGroup["InputChannelGroup"][2].IsChecked = new bool?(true);
								this.LeftGroup = this.InputGroup4;
							}
							else
							{
								bool flag6 = b <= 28;
								if (flag6)
								{
									JSwitcher.JSwitcherGroup["OutputChannelGroup"][0].IsChecked = new bool?(true);
									this.RightGroup = this.OutputGroup1;
									this.IsShowOutputGroup = true;
									this.IsShowDCA1Group = false;
									this.IsShowDCA2Group = false;
								}
								else
								{
									bool flag7 = b <= 32;
									if (flag7)
									{
										JSwitcher.JSwitcherGroup["OutputChannelGroup"][1].IsChecked = new bool?(true);
										this.RightGroup = this.OutputGroup2;
										this.IsShowOutputGroup = true;
										this.IsShowDCA1Group = false;
										this.IsShowDCA2Group = false;
									}
									else
									{
										bool flag8 = b <= 36;
										if (flag8)
										{
											this.IsShowOutputGroup = true;
											this.IsShowDCA1Group = false;
											this.IsShowDCA2Group = false;
										}
									}
								}
							}
						}
					}
				}
			}
			bool flag9 = obj[10] == CommandConst.DEVE_PAGE_DCA_LONGFADER;
			if (flag9)
			{
				JSwitcher.JSwitcherGroup["OutputChannelGroup"][2].IsChecked = new bool?(true);
				this.DCA1Group[(int)(b - 1)].IsSelected = true;
				this.IsShowOutputGroup = false;
				this.IsShowDCA1Group = true;
				this.IsShowDCA2Group = false;
			}
			bool flag10 = obj[10] == CommandConst.DEVE_PAGE_GROUP;
			if (flag10)
			{
				JSwitcher.JSwitcherGroup["OutputChannelGroup"][3].IsChecked = new bool?(true);
				this.DCA2Group[(int)(b - 7)].IsSelected = true;
				this.IsShowOutputGroup = false;
				this.IsShowDCA1Group = false;
				this.IsShowDCA2Group = true;
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0000EE14 File Offset: 0x0000D014
		private void InitializeDCAGroup()
		{
			this.DCA1Group.Add(DCAData.DCA1);
			this.DCA1Group.Add(DCAData.DCA2);
			this.DCA1Group.Add(DCAData.DCA3);
			this.DCA1Group.Add(DCAData.DCA4);
			this.DCA1Group.Add(DCAData.DCA5);
			this.DCA1Group.Add(DCAData.DCA6);
			this.DCA2Group.Add(DCAData.DCA7);
			this.DCA2Group.Add(DCAData.DCA8);
			this.DCA2Group.Add(DCAData.DCA9);
			this.DCA2Group.Add(DCAData.DCA10);
			this.DCA2Group.Add(DCAData.DCA11);
			this.DCA2Group.Add(DCAData.DCA12);
			foreach (DCAInfo<DCAItem> dcainfo in this.DCA1Group)
			{
				dcainfo.PropertyChangeCommand = this.DCAPropertyChangeCommand;
				dcainfo.SelectGroupCommand = this.DCASelectCommand;
				dcainfo.MouseEnterCommand = this.DCAMouseEnterCommand;
			}
			foreach (DCAInfo<DCAItem> dcainfo2 in this.DCA2Group)
			{
				dcainfo2.PropertyChangeCommand = this.DCAPropertyChangeCommand;
				dcainfo2.SelectGroupCommand = this.DCASelectCommand;
				dcainfo2.MouseEnterCommand = this.DCAMouseEnterCommand;
			}
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0000EFB4 File Offset: 0x0000D1B4
		private void InitializeCommands()
		{
			this.SwitchChannelGroupCommand = new RelayCommand<int>(new Action<int>(this.SwitchChannelGroupExecute));
			this.DCAPropertyChangeCommand = new RelayCommand(new Action(this.DCAPropertyChangeExecute));
			this.DCASelectCommand = new RelayCommand(new Action(this.DCASelectExecute));
			this.DCAMouseEnterCommand = new RelayCommand(new Action(this.DCAMouseEnterExecute));
			this.ChannelMouseEnterCommand = new RelayCommand(new Action(this.ChannelMouseEnterExecute));
			this.ClearSoloCommand = new RelayCommand(new Action(this.ClearSoloExecute));
			this.PFLCommand = new RelayCommand(new Action(this.PFLExecute));
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0000436A File Offset: 0x0000256A
		private void PFLExecute()
		{
			SceneData.SceneInfo.PFL = !SceneData.SceneInfo.PFL;
			UpStreamCommand.SendDefaultPreset();
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0000438B File Offset: 0x0000258B
		private void ClearSoloExecute()
		{
			UpStreamCommand.SendClearSolo();
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00003B79 File Offset: 0x00001D79
		private void ChannelMouseEnterExecute()
		{
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0000F06C File Offset: 0x0000D26C
		private void DCAMouseEnterExecute()
		{
			bool? flag = JSwitcher.JSwitcherGroup["OutputChannelGroup"][2].IsChecked;
			bool flag2 = true;
			bool flag3 = (flag.GetValueOrDefault() == flag2) & (flag != null);
			if (flag3)
			{
				foreach (DCAInfo<DCAItem> dcainfo in this.DCA1Group)
				{
					bool isSelected = dcainfo.IsSelected;
					if (isSelected)
					{
						UpStreamCommand.SendSynchronizePage(CommandConst.DEVE_PAGE_DCA_LONGFADER, (byte)(dcainfo.DCAIndex + 1), 0, 0);
						break;
					}
				}
			}
			else
			{
				flag = JSwitcher.JSwitcherGroup["OutputChannelGroup"][3].IsChecked;
				flag2 = true;
				bool flag4 = (flag.GetValueOrDefault() == flag2) & (flag != null);
				if (flag4)
				{
					foreach (DCAInfo<DCAItem> dcainfo2 in this.DCA2Group)
					{
						bool isSelected2 = dcainfo2.IsSelected;
						if (isSelected2)
						{
							UpStreamCommand.SendSynchronizePage(CommandConst.DEVE_PAGE_DCA_LONGFADER, (byte)(dcainfo2.DCAIndex + 1), 0, 0);
							break;
						}
					}
				}
				else
				{
					UpStreamCommand.SendSynchronizePage(CommandConst.DEVE_PAGE_HOME, 0, 0, 0);
				}
			}
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0000F1C8 File Offset: 0x0000D3C8
		private void DCASelectExecute()
		{
			foreach (DCAInfo<DCAItem> dcainfo in this.DCA1Group)
			{
				bool isSelected = dcainfo.IsSelected;
				if (isSelected)
				{
					UpStreamCommand.SendCMD_DCAGroupSelect(dcainfo);
				}
			}
			foreach (DCAInfo<DCAItem> dcainfo2 in this.DCA2Group)
			{
				bool isSelected2 = dcainfo2.IsSelected;
				if (isSelected2)
				{
					UpStreamCommand.SendCMD_DCAGroupSelect(dcainfo2);
				}
			}
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0000F278 File Offset: 0x0000D478
		public void DCAPropertyChangeExecute()
		{
			foreach (DCAInfo<DCAItem> dcainfo in this.DCA1Group)
			{
				bool isSelected = dcainfo.IsSelected;
				if (isSelected)
				{
					UpStreamCommand.SendCMD_DCAGroupSet(dcainfo);
				}
			}
			foreach (DCAInfo<DCAItem> dcainfo2 in this.DCA2Group)
			{
				bool isSelected2 = dcainfo2.IsSelected;
				if (isSelected2)
				{
					UpStreamCommand.SendCMD_DCAGroupSet(dcainfo2);
				}
			}
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0000F328 File Offset: 0x0000D528
		private void SwitchChannelGroupExecute(int obj)
		{
			switch (obj)
			{
			case 0:
				this.LeftGroup = this.InputGroup1;
				break;
			case 1:
				this.LeftGroup = this.InputGroup2;
				break;
			case 2:
				this.LeftGroup = this.InputGroup3;
				break;
			case 3:
				this.LeftGroup = this.InputGroup4;
				break;
			case 4:
				this.RightGroup = this.OutputGroup1;
				this.IsShowOutputGroup = true;
				this.IsShowDCA1Group = false;
				this.IsShowDCA2Group = false;
				break;
			case 5:
				this.RightGroup = this.OutputGroup2;
				this.IsShowOutputGroup = true;
				this.IsShowDCA1Group = false;
				this.IsShowDCA2Group = false;
				break;
			case 6:
				this.IsShowOutputGroup = false;
				this.IsShowDCA1Group = true;
				this.IsShowDCA2Group = false;
				UpStreamCommand.SendSynchronizePage(PageData.PageIndexDictionary[CommandConst.DEVE_PAGE_GROUP]);
				break;
			case 7:
				this.IsShowOutputGroup = false;
				this.IsShowDCA1Group = false;
				this.IsShowDCA2Group = true;
				UpStreamCommand.SendSynchronizePage(PageData.PageIndexDictionary[CommandConst.DEVE_PAGE_GROUP]);
				break;
			}
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0000F45C File Offset: 0x0000D65C
		private void InitializeChannelGroup()
		{
			this.InputGroup1.Add(ChannelData.ChannelDatas.CH01);
			this.InputGroup1.Add(ChannelData.ChannelDatas.CH02);
			this.InputGroup1.Add(ChannelData.ChannelDatas.CH03);
			this.InputGroup1.Add(ChannelData.ChannelDatas.CH04);
			this.InputGroup1.Add(ChannelData.ChannelDatas.CH05);
			this.InputGroup1.Add(ChannelData.ChannelDatas.CH06);
			this.InputGroup2.Add(ChannelData.ChannelDatas.CH07);
			this.InputGroup2.Add(ChannelData.ChannelDatas.CH08);
			this.InputGroup2.Add(ChannelData.ChannelDatas.CH09);
			this.InputGroup2.Add(ChannelData.ChannelDatas.CH10);
			this.InputGroup2.Add(ChannelData.ChannelDatas.CH11);
			this.InputGroup2.Add(ChannelData.ChannelDatas.CH12);
			this.InputGroup3.Add(ChannelData.ChannelDatas.CH13);
			this.InputGroup3.Add(ChannelData.ChannelDatas.CH14);
			this.InputGroup3.Add(ChannelData.ChannelDatas.CH15);
			this.InputGroup3.Add(ChannelData.ChannelDatas.CH16);
			this.InputGroup3.Add(ChannelData.ChannelDatas.CH17);
			this.InputGroup3.Add(ChannelData.ChannelDatas.CH18);
			this.InputGroup4.Add(ChannelData.ChannelDatas.CH19);
			this.InputGroup4.Add(ChannelData.ChannelDatas.CH20);
			this.InputGroup4.Add(ChannelData.ChannelDatas.CH21);
			this.InputGroup4.Add(ChannelData.ChannelDatas.CH22);
			this.InputGroup4.Add(ChannelData.ChannelDatas.CH23);
			this.InputGroup4.Add(ChannelData.ChannelDatas.CH24);
			this.OutputGroup1.Add(ChannelData.ChannelDatas.Aux01);
			this.OutputGroup1.Add(ChannelData.ChannelDatas.Aux02);
			this.OutputGroup1.Add(ChannelData.ChannelDatas.Aux03);
			this.OutputGroup1.Add(ChannelData.ChannelDatas.Aux04);
			this.OutputGroup2.Add(ChannelData.ChannelDatas.Aux05);
			this.OutputGroup2.Add(ChannelData.ChannelDatas.Aux06);
			this.OutputGroup2.Add(ChannelData.ChannelDatas.Aux07);
			this.OutputGroup2.Add(ChannelData.ChannelDatas.Aux08);
			this.OutputGroup1.Add(ChannelData.ChannelDatas.FX01);
			this.OutputGroup1.Add(ChannelData.ChannelDatas.FX02);
			this.OutputGroup1.Add(ChannelData.ChannelDatas.Main);
			this.OutputGroup2.Add(ChannelData.ChannelDatas.FX01);
			this.OutputGroup2.Add(ChannelData.ChannelDatas.FX02);
			this.OutputGroup2.Add(ChannelData.ChannelDatas.Main);
		}

		// Token: 0x040000B7 RID: 183
		private ObservableCollection<ChannelInfo> _LeftGroup;

		// Token: 0x040000B8 RID: 184
		private ObservableCollection<ChannelInfo> _RightGroup;

		// Token: 0x040000B9 RID: 185
		private bool _IsShowOutputGroup = true;

		// Token: 0x040000BA RID: 186
		private bool _IsShowDCA1Group = false;

		// Token: 0x040000BB RID: 187
		private bool _IsShowDCA2Group = false;

		// Token: 0x040000BC RID: 188
		private ObservableCollection<DCAInfo<DCAItem>> _dCAGroup1 = new ObservableCollection<DCAInfo<DCAItem>>();

		// Token: 0x040000BD RID: 189
		private ObservableCollection<DCAInfo<DCAItem>> _dCAGroup2 = new ObservableCollection<DCAInfo<DCAItem>>();

		// Token: 0x040000BE RID: 190
		private bool _PFL;
	}
}
