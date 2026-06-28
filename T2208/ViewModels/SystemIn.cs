using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using JayLib.Localization;
using JayLib.WPF.BasicClass;
using T2208.DeviceCommuncation;
using T2208.Models;
using T2208.MyDatas;
using T2208.MyInformations;

namespace T2208.ViewModels
{
	// Token: 0x02000043 RID: 67
	public class SystemIn : ViewModelBase
	{
		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000354 RID: 852 RVA: 0x00019E28 File Offset: 0x00018028
		// (set) Token: 0x06000355 RID: 853 RVA: 0x00005DC4 File Offset: 0x00003FC4
		public string DefaultName
		{
			get
			{
				return this._DefaultName;
			}
			set
			{
				this._DefaultName = value;
				this.OnPropertyChanged<string>(() => this.DefaultName);
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000356 RID: 854 RVA: 0x00019E40 File Offset: 0x00018040
		// (set) Token: 0x06000357 RID: 855 RVA: 0x00005E04 File Offset: 0x00004004
		public bool ShowDIO24
		{
			get
			{
				return this._ShowDIO24;
			}
			set
			{
				this._ShowDIO24 = value;
				this.OnPropertyChanged<bool>(() => this.ShowDIO24);
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000358 RID: 856 RVA: 0x00019E58 File Offset: 0x00018058
		// (set) Token: 0x06000359 RID: 857 RVA: 0x00005E44 File Offset: 0x00004044
		public string DeviceName
		{
			get
			{
				return this._DeviceName;
			}
			set
			{
				this._DeviceName = value;
				this.OnPropertyChanged<string>(() => this.DeviceName);
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x0600035A RID: 858 RVA: 0x00019E70 File Offset: 0x00018070
		// (set) Token: 0x0600035B RID: 859 RVA: 0x00019E88 File Offset: 0x00018088
		public int LCDValue
		{
			get
			{
				return this._LCDValue;
			}
			set
			{
				this._LCDValue = value;
				this.OnPropertyChanged<int>(() => this.LCDValue);
				this.LCDSendValue = value;
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x0600035C RID: 860 RVA: 0x00019EDC File Offset: 0x000180DC
		// (set) Token: 0x0600035D RID: 861 RVA: 0x00019EF4 File Offset: 0x000180F4
		public int KnobValue
		{
			get
			{
				return this._KnobValue;
			}
			set
			{
				this._KnobValue = value;
				this.OnPropertyChanged<int>(() => this.KnobValue);
				this.KnobSendValue = value;
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x0600035E RID: 862 RVA: 0x00019F48 File Offset: 0x00018148
		// (set) Token: 0x0600035F RID: 863 RVA: 0x00005E84 File Offset: 0x00004084
		public int LCDSendValue
		{
			get
			{
				return this._LCDSendValue;
			}
			set
			{
				this._LCDSendValue = value;
				this.OnPropertyChanged<int>(() => this.LCDSendValue);
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000360 RID: 864 RVA: 0x00019F60 File Offset: 0x00018160
		// (set) Token: 0x06000361 RID: 865 RVA: 0x00005EC4 File Offset: 0x000040C4
		public int KnobSendValue
		{
			get
			{
				return this._KnobSendValue;
			}
			set
			{
				this._KnobSendValue = value;
				this.OnPropertyChanged<int>(() => this.KnobSendValue);
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000362 RID: 866 RVA: 0x00019F78 File Offset: 0x00018178
		// (set) Token: 0x06000363 RID: 867 RVA: 0x00005F04 File Offset: 0x00004104
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

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000364 RID: 868 RVA: 0x00019F90 File Offset: 0x00018190
		// (set) Token: 0x06000365 RID: 869 RVA: 0x00005F44 File Offset: 0x00004144
		public string DSP1Version
		{
			get
			{
				return this._DSP1Version;
			}
			set
			{
				this._DSP1Version = value;
				this.OnPropertyChanged<string>(() => this.DSP1Version);
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000366 RID: 870 RVA: 0x00019FA8 File Offset: 0x000181A8
		// (set) Token: 0x06000367 RID: 871 RVA: 0x00005F84 File Offset: 0x00004184
		public string DSP2Version
		{
			get
			{
				return this._DSP2Version;
			}
			set
			{
				this._DSP2Version = value;
				this.OnPropertyChanged<string>(() => this.DSP2Version);
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000368 RID: 872 RVA: 0x00019FC0 File Offset: 0x000181C0
		// (set) Token: 0x06000369 RID: 873 RVA: 0x00005FC4 File Offset: 0x000041C4
		public string MCU1Version
		{
			get
			{
				return this._MCU1Version;
			}
			set
			{
				this._MCU1Version = value;
				this.OnPropertyChanged<string>(() => this.MCU1Version);
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x0600036A RID: 874 RVA: 0x00019FD8 File Offset: 0x000181D8
		// (set) Token: 0x0600036B RID: 875 RVA: 0x00006004 File Offset: 0x00004204
		public string MCU2Version
		{
			get
			{
				return this._MCU2Version;
			}
			set
			{
				this._MCU2Version = value;
				this.OnPropertyChanged<string>(() => this.MCU2Version);
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x0600036C RID: 876 RVA: 0x00019FF0 File Offset: 0x000181F0
		// (set) Token: 0x0600036D RID: 877 RVA: 0x00006044 File Offset: 0x00004244
		public string InitialPage
		{
			get
			{
				return this._InitialPage;
			}
			set
			{
				this._InitialPage = value;
				this.OnPropertyChanged<string>(() => this.InitialPage);
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x0600036E RID: 878 RVA: 0x00006084 File Offset: 0x00004284
		// (set) Token: 0x0600036F RID: 879 RVA: 0x0000608C File Offset: 0x0000428C
		public RelayCommand SetDefaultSettingCommand { get; private set; }

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000370 RID: 880 RVA: 0x00006095 File Offset: 0x00004295
		// (set) Token: 0x06000371 RID: 881 RVA: 0x0000609D File Offset: 0x0000429D
		public RelayCommand SetNameCommand { get; private set; }

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000372 RID: 882 RVA: 0x000060A6 File Offset: 0x000042A6
		// (set) Token: 0x06000373 RID: 883 RVA: 0x000060AE File Offset: 0x000042AE
		public RelayCommand ChangeInitialPageCommand { get; private set; }

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000374 RID: 884 RVA: 0x000060B7 File Offset: 0x000042B7
		// (set) Token: 0x06000375 RID: 885 RVA: 0x000060BF File Offset: 0x000042BF
		public RelayCommand SoloMeterCommand { get; private set; }

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000376 RID: 886 RVA: 0x000060C8 File Offset: 0x000042C8
		// (set) Token: 0x06000377 RID: 887 RVA: 0x000060D0 File Offset: 0x000042D0
		public RelayCommand MatrixPageCommand { get; private set; }

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000378 RID: 888 RVA: 0x000060D9 File Offset: 0x000042D9
		// (set) Token: 0x06000379 RID: 889 RVA: 0x000060E1 File Offset: 0x000042E1
		public ObservableCollection<ChannelInfo> LeftGroup { get; set; } = new ObservableCollection<ChannelInfo>();

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x0600037A RID: 890 RVA: 0x000060EA File Offset: 0x000042EA
		// (set) Token: 0x0600037B RID: 891 RVA: 0x000060F2 File Offset: 0x000042F2
		public ObservableCollection<ChannelInfo> RightGroup { get; set; } = new ObservableCollection<ChannelInfo>();

		// Token: 0x0600037C RID: 892 RVA: 0x0001A008 File Offset: 0x00018208
		public SystemIn()
		{
			this.InitializeChannelGroup();
			this.SetDefaultSettingCommand = new RelayCommand(new Action(this.SetDefaultSettingExecute));
			this.SetNameCommand = new RelayCommand(new Action(this.SetNameExecute));
			this.ChangeInitialPageCommand = new RelayCommand(new Action(this.ChangeInitialPageExecute));
			this.SoloMeterCommand = new RelayCommand(new Action(this.SoloMeterExecute));
			this.MatrixPageCommand = new RelayCommand(new Action(this.ChangeMatrixPageExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_DefaultPreset), new Action<byte[]>(this.DefaultSettingExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_LCDBlackLight), new Action<byte[]>(this.LCDSettingExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_ReadDeviceName), new Action<byte[]>(this.ReadDeviceNameExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_ReadCurrentScene), new Action<byte[]>(this.ReadCurrentScene));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_ReadVersionCmd), new Action<byte[]>(this.UpdateVersionExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_ResetCommand), new Action<byte[]>(this.ResetExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_Matrix), new Action<byte[]>(this.UpdateMatrix));
		}

		// Token: 0x0600037D RID: 893 RVA: 0x0001A210 File Offset: 0x00018410
		private void ResetExecute(byte[] obj)
		{
			UpStreamCommand.SendReadDeviceName();
			UpStream.SendCMD_Recall();
			Task.Factory.StartNew(delegate
			{
				Thread.Sleep(1000);
			}).ContinueWith(delegate(Task _)
			{
				Application.Current.Dispatcher.Invoke(delegate
				{
					ViewModelMessager.Messeager.Notify(ViewModelMessager.IsBusy, false);
				});
			});
		}

		// Token: 0x0600037E RID: 894 RVA: 0x000060FB File Offset: 0x000042FB
		private void ChangeMatrixPageExecute()
		{
			UpStreamCommand.SendSynchronizePage(CommandConst.DEVE_PAGE_Matrix, 1, 0, 0);
		}

		// Token: 0x0600037F RID: 895 RVA: 0x00003B79 File Offset: 0x00001D79
		private void SoloMeterExecute()
		{
		}

		// Token: 0x06000380 RID: 896 RVA: 0x0000610C File Offset: 0x0000430C
		private void ChangeInitialPageExecute()
		{
			SceneData.SceneInfo.SystemInfo.DefaultPage = ((SceneData.SceneInfo.SystemInfo.DefaultPage == 1) ? 0 : 1);
			UpStreamCommand.SendDefaultPreset();
		}

		// Token: 0x06000381 RID: 897 RVA: 0x0001A278 File Offset: 0x00018478
		private void UpdateMatrix(byte[] obj)
		{
			int num = 12;
			for (int i = 0; i < 8; i++)
			{
				this.LeftGroup[i].IsSelected_Left = Convert.ToBoolean(obj[num++]);
			}
			for (int j = 0; j < 8; j++)
			{
				this.RightGroup[j].IsSelected_Right = Convert.ToBoolean(obj[num++]);
			}
		}

		// Token: 0x06000382 RID: 898 RVA: 0x00003B79 File Offset: 0x00001D79
		private void UpdateVersionExecute(byte[] obj)
		{
		}

		// Token: 0x06000383 RID: 899 RVA: 0x0001A2E8 File Offset: 0x000184E8
		private void ReadCurrentScene(byte[] obj)
		{
			int num = 4615;
			for (int i = 0; i < 35; i++)
			{
				num++;
			}
			for (int j = 0; j < 2; j++)
			{
				num++;
			}
			for (int k = 0; k < 9; k++)
			{
				num++;
			}
			num++;
			this.PFL = obj[num++] == 1;
			this.LCDValue = (int)obj[num++];
			this.KnobValue = (int)obj[num++];
			this.DSP1Version = obj[num++].ToString("x2").Insert(1, ".");
			this.DSP2Version = obj[num++].ToString("x2").Insert(1, ".");
			this.MCU1Version = obj[num++].ToString("x2").Insert(1, ".");
			this.MCU2Version = obj[num++].ToString("x2").Insert(1, ".");
			SceneData.SceneInfo.SystemInfo.AuxBusMode = obj[num++];
			num++;
			SceneData.SceneInfo.SystemInfo.DefaultPage = obj[num++];
			this.InitialPage = ((SceneData.SceneInfo.SystemInfo.DefaultPage == 0) ? "All Faders" : "Long Faders");
			SceneData.SceneInfo.SystemInfo.PFLFlag = (this.PFL ? 1 : 0);
			SceneData.SceneInfo.SystemInfo.LCDValue = (byte)this.LCDValue;
			SceneData.SceneInfo.SystemInfo.KnobValue = (byte)this.KnobValue;
			UpStreamCommand.SendReadPresentGUI();
			UpStreamCommand.SendReadPresetList(PresetType.DSP);
			UpStreamCommand.SendReadPresetList(PresetType.GEQ);
			UpStreamCommand.SendReadPresetList(PresetType.FX);
			UpStreamCommand.SendReadPresetList(PresetType.Scene);
			num = 4698;
			for (int l = 0; l < 8; l++)
			{
				this.RightGroup[l].IsSelected_Right = obj[num++] == 1;
			}
			for (int m = 0; m < 8; m++)
			{
				this.RightGroup[m].IsSelected_Right = obj[num++] == 1;
			}
		}

		// Token: 0x06000384 RID: 900 RVA: 0x0001A548 File Offset: 0x00018748
		private void ReadDeviceNameExecute(byte[] obj)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < 16; i++)
			{
				bool flag = obj[12 + i] != 32 && obj[12 + i] > 0;
				if (flag)
				{
					stringBuilder.Append((char)obj[12 + i]);
				}
			}
			this.DeviceName = stringBuilder.ToString();
		}

		// Token: 0x06000385 RID: 901 RVA: 0x0001A5A8 File Offset: 0x000187A8
		private void LCDSettingExecute(byte[] obj)
		{
			this.LCDValue = (int)((obj[12] > 16) ? 16 : obj[12]);
			this.KnobValue = (int)((obj[13] > 16) ? 16 : obj[13]);
			SceneData.SceneInfo.SystemInfo.LCDValue = (byte)this.LCDValue;
			SceneData.SceneInfo.SystemInfo.KnobValue = (byte)this.KnobValue;
		}

		// Token: 0x06000386 RID: 902 RVA: 0x0001A614 File Offset: 0x00018814
		private void DefaultSettingExecute(byte[] obj)
		{
			int num = 12;
			for (int i = 0; i < 35; i++)
			{
				num++;
			}
			for (int j = 0; j < 2; j++)
			{
				num++;
			}
			for (int k = 0; k < 9; k++)
			{
				num++;
			}
			num++;
			this.PFL = obj[num++] == 1;
			this.LCDValue = (int)obj[num++];
			this.KnobValue = (int)obj[num++];
			this.DSP1Version = obj[num++].ToString("x2").Insert(1, ".");
			this.DSP2Version = obj[num++].ToString("x2").Insert(1, ".");
			this.MCU1Version = obj[num++].ToString("x2").Insert(1, ".");
			this.MCU2Version = obj[num++].ToString("x2").Insert(1, ".");
			SceneData.SceneInfo.SystemInfo.AuxBusMode = obj[num++];
			num++;
			SceneData.SceneInfo.SystemInfo.DefaultPage = obj[num++];
			this.InitialPage = ((SceneData.SceneInfo.SystemInfo.DefaultPage == 0) ? "All Faders" : "Long Faders");
			SceneData.SceneInfo.SystemInfo.PFLFlag = (this.PFL ? 1 : 0);
			SceneData.SceneInfo.SystemInfo.LCDValue = (byte)this.LCDValue;
			SceneData.SceneInfo.SystemInfo.KnobValue = (byte)this.KnobValue;
		}

		// Token: 0x06000387 RID: 903 RVA: 0x0000613C File Offset: 0x0000433C
		private void SetNameExecute()
		{
			SceneData.SceneInfo.SystemInfo.Name = this.DeviceName;
			UpStreamCommand.SendSetDeviceName();
		}

		// Token: 0x06000388 RID: 904 RVA: 0x0001A7E0 File Offset: 0x000189E0
		private void SetDefaultSettingExecute()
		{
			bool flag = MessageBox.Show(LocalizationManager.GetString("Str_ResetToDefaultSetting"), LocalizationManager.GetString("Str_Tips"), MessageBoxButton.YesNo) == MessageBoxResult.Yes;
			if (flag)
			{
				ViewModelMessager.Messeager.Notify(ViewModelMessager.IsBusy, true);
				UpStreamCommand.SendReset();
			}
		}

		// Token: 0x06000389 RID: 905 RVA: 0x0001A830 File Offset: 0x00018A30
		private void InitializeChannelGroup()
		{
			this.LeftGroup.Add(ChannelData.ChannelDatas.Aux01);
			this.LeftGroup.Add(ChannelData.ChannelDatas.Aux02);
			this.LeftGroup.Add(ChannelData.ChannelDatas.Aux03);
			this.LeftGroup.Add(ChannelData.ChannelDatas.Aux04);
			this.LeftGroup.Add(ChannelData.ChannelDatas.Aux05);
			this.LeftGroup.Add(ChannelData.ChannelDatas.Aux06);
			this.LeftGroup.Add(ChannelData.ChannelDatas.Aux07);
			this.LeftGroup.Add(ChannelData.ChannelDatas.Aux08);
			this.RightGroup.Add(ChannelData.ChannelDatas.Aux01);
			this.RightGroup.Add(ChannelData.ChannelDatas.Aux02);
			this.RightGroup.Add(ChannelData.ChannelDatas.Aux03);
			this.RightGroup.Add(ChannelData.ChannelDatas.Aux04);
			this.RightGroup.Add(ChannelData.ChannelDatas.Aux05);
			this.RightGroup.Add(ChannelData.ChannelDatas.Aux06);
			this.RightGroup.Add(ChannelData.ChannelDatas.Aux07);
			this.RightGroup.Add(ChannelData.ChannelDatas.Aux08);
		}

		// Token: 0x04000244 RID: 580
		private string _DefaultName;

		// Token: 0x04000245 RID: 581
		private bool _ShowDIO24;

		// Token: 0x04000246 RID: 582
		private string _DeviceName;

		// Token: 0x04000247 RID: 583
		private int _LCDValue;

		// Token: 0x04000248 RID: 584
		private int _KnobValue;

		// Token: 0x04000249 RID: 585
		private int _LCDSendValue;

		// Token: 0x0400024A RID: 586
		private int _KnobSendValue;

		// Token: 0x0400024B RID: 587
		private bool _PFL;

		// Token: 0x0400024C RID: 588
		private string _DSP1Version;

		// Token: 0x0400024D RID: 589
		private string _DSP2Version;

		// Token: 0x0400024E RID: 590
		private string _MCU1Version;

		// Token: 0x0400024F RID: 591
		private string _MCU2Version;

		// Token: 0x04000250 RID: 592
		private string _InitialPage;
	}
}
