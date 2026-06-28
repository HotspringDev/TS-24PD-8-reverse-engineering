using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using CommLibrary;
using JayLib.JayFile;
using JayLib.JaySerialization;
using JayLib.JayString;
using JayLib.Localization;
using JayLib.WPF.BasicClass;
using T2208.DeviceCommuncation;
using T2208.Models;
using T2208.MyDatas;
using T2208.MyInformations;

namespace T2208.ViewModels
{
	// Token: 0x0200003D RID: 61
	public class SaveLoadCopy : ViewModelBase
	{
		// Token: 0x170000DF RID: 223
		// (get) Token: 0x060002C0 RID: 704 RVA: 0x0000556F File Offset: 0x0000376F
		// (set) Token: 0x060002C1 RID: 705 RVA: 0x00005577 File Offset: 0x00003777
		public ObservableCollection<PresetItem> DSP { get; set; } = new ObservableCollection<PresetItem>();

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060002C2 RID: 706 RVA: 0x00005580 File Offset: 0x00003780
		// (set) Token: 0x060002C3 RID: 707 RVA: 0x00005588 File Offset: 0x00003788
		public ObservableCollection<PresetItem> GEQ { get; set; } = new ObservableCollection<PresetItem>();

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x00005591 File Offset: 0x00003791
		// (set) Token: 0x060002C5 RID: 709 RVA: 0x00005599 File Offset: 0x00003799
		public ObservableCollection<PresetItem> FX { get; set; } = new ObservableCollection<PresetItem>();

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x000055A2 File Offset: 0x000037A2
		// (set) Token: 0x060002C7 RID: 711 RVA: 0x000055AA File Offset: 0x000037AA
		public ObservableCollection<PresetItem> Scene { get; set; } = new ObservableCollection<PresetItem>();

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x000055B3 File Offset: 0x000037B3
		// (set) Token: 0x060002C9 RID: 713 RVA: 0x000055BB File Offset: 0x000037BB
		public PresetGroup DSPGroup { get; set; }

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060002CA RID: 714 RVA: 0x000055C4 File Offset: 0x000037C4
		// (set) Token: 0x060002CB RID: 715 RVA: 0x000055CC File Offset: 0x000037CC
		public PresetGroup GEQGroup { get; set; }

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060002CC RID: 716 RVA: 0x000055D5 File Offset: 0x000037D5
		// (set) Token: 0x060002CD RID: 717 RVA: 0x000055DD File Offset: 0x000037DD
		public PresetGroup FXGroup { get; set; }

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060002CE RID: 718 RVA: 0x000055E6 File Offset: 0x000037E6
		// (set) Token: 0x060002CF RID: 719 RVA: 0x000055EE File Offset: 0x000037EE
		public PresetGroup SceneGroup { get; set; }

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060002D0 RID: 720 RVA: 0x000055F7 File Offset: 0x000037F7
		// (set) Token: 0x060002D1 RID: 721 RVA: 0x000055FF File Offset: 0x000037FF
		public PresetGroup LocalDSPGroup { get; set; } = new PresetGroup();

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060002D2 RID: 722 RVA: 0x00005608 File Offset: 0x00003808
		// (set) Token: 0x060002D3 RID: 723 RVA: 0x00005610 File Offset: 0x00003810
		public PresetGroup LocalGEQGroup { get; set; } = new PresetGroup();

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060002D4 RID: 724 RVA: 0x00005619 File Offset: 0x00003819
		// (set) Token: 0x060002D5 RID: 725 RVA: 0x00005621 File Offset: 0x00003821
		public PresetGroup LocalFXGroup { get; set; } = new PresetGroup();

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060002D6 RID: 726 RVA: 0x0000562A File Offset: 0x0000382A
		// (set) Token: 0x060002D7 RID: 727 RVA: 0x00005632 File Offset: 0x00003832
		public PresetGroup LocalSceneGroup { get; set; } = new PresetGroup();

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x0000563B File Offset: 0x0000383B
		// (set) Token: 0x060002D9 RID: 729 RVA: 0x00005643 File Offset: 0x00003843
		public ObservableCollection<ButtonItem> OnlineCommandGroup { get; set; } = new ObservableCollection<ButtonItem>();

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060002DA RID: 730 RVA: 0x0000564C File Offset: 0x0000384C
		// (set) Token: 0x060002DB RID: 731 RVA: 0x00005654 File Offset: 0x00003854
		public ObservableCollection<ButtonItem> OfflineCommandGroup { get; set; } = new ObservableCollection<ButtonItem>();

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060002DC RID: 732 RVA: 0x0000565D File Offset: 0x0000385D
		// (set) Token: 0x060002DD RID: 733 RVA: 0x00005665 File Offset: 0x00003865
		public int PresetNameIndex { get; set; }

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060002DE RID: 734 RVA: 0x0000566E File Offset: 0x0000386E
		// (set) Token: 0x060002DF RID: 735 RVA: 0x00005676 File Offset: 0x00003876
		public int CHIndex { get; set; }

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x0000567F File Offset: 0x0000387F
		// (set) Token: 0x060002E1 RID: 737 RVA: 0x00005687 File Offset: 0x00003887
		public string CHPresetName { get; set; }

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x060002E2 RID: 738 RVA: 0x00005690 File Offset: 0x00003890
		// (set) Token: 0x060002E3 RID: 739 RVA: 0x00005698 File Offset: 0x00003898
		public string[] ChannelGroup { get; set; }

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060002E4 RID: 740 RVA: 0x00017D2C File Offset: 0x00015F2C
		// (set) Token: 0x060002E5 RID: 741 RVA: 0x00017D44 File Offset: 0x00015F44
		public int SelectedCopyChannelIndex
		{
			get
			{
				return this._SelectedCopyChannelIndex;
			}
			set
			{
				bool flag = value >= 0 && value < this.CheckBoxGroup.Count;
				if (flag)
				{
					this.CheckBoxGroup[this.SelectedCopyChannelIndex].IsEnabled = true;
					this.CheckBoxGroup[value].IsEnabled = false;
					this.CheckBoxGroup[value].IsChecked = false;
				}
				this._SelectedCopyChannelIndex = value;
				this.OnPropertyChanged<int>(() => this.SelectedCopyChannelIndex);
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060002E6 RID: 742 RVA: 0x00017DE8 File Offset: 0x00015FE8
		// (set) Token: 0x060002E7 RID: 743 RVA: 0x000056A1 File Offset: 0x000038A1
		public ObservableCollection<PresetGroup> PresetGroups
		{
			get
			{
				return this._PresetGroups;
			}
			set
			{
				this._PresetGroups = value;
				this.OnPropertyChanged<ObservableCollection<PresetGroup>>(() => this.PresetGroups);
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060002E8 RID: 744 RVA: 0x00017E00 File Offset: 0x00016000
		// (set) Token: 0x060002E9 RID: 745 RVA: 0x000056E1 File Offset: 0x000038E1
		public ObservableCollection<PresetGroup> LocalPresetGroups
		{
			get
			{
				return this._LocalPresetGroups;
			}
			set
			{
				this._LocalPresetGroups = value;
				this.OnPropertyChanged<ObservableCollection<PresetGroup>>(() => this.LocalPresetGroups);
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x060002EA RID: 746 RVA: 0x00017E18 File Offset: 0x00016018
		// (set) Token: 0x060002EB RID: 747 RVA: 0x00005721 File Offset: 0x00003921
		public ObservableCollection<PresetGroup> SelectedPresetGroups
		{
			get
			{
				return this._SelectedPresetGroups;
			}
			set
			{
				this._SelectedPresetGroups = value;
				this.OnPropertyChanged<ObservableCollection<PresetGroup>>(() => this.SelectedPresetGroups);
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x060002EC RID: 748 RVA: 0x00017E30 File Offset: 0x00016030
		// (set) Token: 0x060002ED RID: 749 RVA: 0x00005761 File Offset: 0x00003961
		public PresetGroup SelectGroup
		{
			get
			{
				return this._SelectGroup;
			}
			set
			{
				this._SelectGroup = value;
				this.OnPropertyChanged<PresetGroup>(() => this.SelectGroup);
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x060002EE RID: 750 RVA: 0x00017E48 File Offset: 0x00016048
		// (set) Token: 0x060002EF RID: 751 RVA: 0x000057A1 File Offset: 0x000039A1
		public int SelectedGroupIndex
		{
			get
			{
				return this._SelectedGroupIndex;
			}
			set
			{
				this._SelectedGroupIndex = value;
				this.OnPropertyChanged<int>(() => this.SelectedGroupIndex);
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060002F0 RID: 752 RVA: 0x00017E60 File Offset: 0x00016060
		// (set) Token: 0x060002F1 RID: 753 RVA: 0x000057E1 File Offset: 0x000039E1
		public ObservableCollection<ButtonItem> ButtonGroup
		{
			get
			{
				return this._ButtonGroup;
			}
			set
			{
				this._ButtonGroup = value;
				this.OnPropertyChanged<ObservableCollection<ButtonItem>>(() => this.ButtonGroup);
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x00017E78 File Offset: 0x00016078
		// (set) Token: 0x060002F3 RID: 755 RVA: 0x00005821 File Offset: 0x00003A21
		public ObservableCollection<CheckBoxItem> CheckBoxGroup
		{
			get
			{
				return this._CheckBoxGroup;
			}
			set
			{
				this._CheckBoxGroup = value;
				this.OnPropertyChanged<ObservableCollection<CheckBoxItem>>(() => this.CheckBoxGroup);
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060002F4 RID: 756 RVA: 0x00017E90 File Offset: 0x00016090
		// (set) Token: 0x060002F5 RID: 757 RVA: 0x00005861 File Offset: 0x00003A61
		public ObservableCollection<CheckBoxItem> CopyItemGroup
		{
			get
			{
				return this._CopyItemGroup;
			}
			set
			{
				this._CopyItemGroup = value;
				this.OnPropertyChanged<ObservableCollection<CheckBoxItem>>(() => this.CopyItemGroup);
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060002F6 RID: 758 RVA: 0x00017EA8 File Offset: 0x000160A8
		// (set) Token: 0x060002F7 RID: 759 RVA: 0x000058A1 File Offset: 0x00003AA1
		public bool IsClickAll
		{
			get
			{
				return this._IsClickAll;
			}
			set
			{
				this._IsClickAll = value;
				this.OnPropertyChanged<bool>(() => this.IsClickAll);
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060002F8 RID: 760 RVA: 0x00017EC0 File Offset: 0x000160C0
		// (set) Token: 0x060002F9 RID: 761 RVA: 0x000058E1 File Offset: 0x00003AE1
		public int ScenePresetIndex
		{
			get
			{
				return this._ScenePresetIndex;
			}
			set
			{
				this._ScenePresetIndex = value;
				this.OnPropertyChanged<int>(() => this.ScenePresetIndex);
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x060002FA RID: 762 RVA: 0x00005921 File Offset: 0x00003B21
		// (set) Token: 0x060002FB RID: 763 RVA: 0x00005929 File Offset: 0x00003B29
		public RelayCommand<int> SwitchButtonGroupCommand { get; private set; }

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x060002FC RID: 764 RVA: 0x00005932 File Offset: 0x00003B32
		// (set) Token: 0x060002FD RID: 765 RVA: 0x0000593A File Offset: 0x00003B3A
		public RelayCommand SelectAllCommand { get; private set; }

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x060002FE RID: 766 RVA: 0x00005943 File Offset: 0x00003B43
		// (set) Token: 0x060002FF RID: 767 RVA: 0x0000594B File Offset: 0x00003B4B
		public RelayCommand MouseEnterSaveLoadAreaCommand { get; private set; }

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000300 RID: 768 RVA: 0x00005954 File Offset: 0x00003B54
		// (set) Token: 0x06000301 RID: 769 RVA: 0x0000595C File Offset: 0x00003B5C
		public RelayCommand MouseEnterCopyAreaCommand { get; private set; }

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000302 RID: 770 RVA: 0x00005965 File Offset: 0x00003B65
		// (set) Token: 0x06000303 RID: 771 RVA: 0x0000596D File Offset: 0x00003B6D
		public RelayCommand LoadDevicePresetCommand { get; private set; }

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06000304 RID: 772 RVA: 0x00005976 File Offset: 0x00003B76
		// (set) Token: 0x06000305 RID: 773 RVA: 0x0000597E File Offset: 0x00003B7E
		public RelayCommand SaveDevicePresetCommand { get; private set; }

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000306 RID: 774 RVA: 0x00005987 File Offset: 0x00003B87
		// (set) Token: 0x06000307 RID: 775 RVA: 0x0000598F File Offset: 0x00003B8F
		public RelayCommand DeleteDevicePresetCommand { get; private set; }

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000308 RID: 776 RVA: 0x00005998 File Offset: 0x00003B98
		// (set) Token: 0x06000309 RID: 777 RVA: 0x000059A0 File Offset: 0x00003BA0
		public RelayCommand LoadPCPresetCommand { get; private set; }

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x0600030A RID: 778 RVA: 0x000059A9 File Offset: 0x00003BA9
		// (set) Token: 0x0600030B RID: 779 RVA: 0x000059B1 File Offset: 0x00003BB1
		public RelayCommand SavePCPresetCommand { get; private set; }

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x0600030C RID: 780 RVA: 0x000059BA File Offset: 0x00003BBA
		// (set) Token: 0x0600030D RID: 781 RVA: 0x000059C2 File Offset: 0x00003BC2
		public RelayCommand DeletePCPresetCommand { get; private set; }

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x0600030E RID: 782 RVA: 0x000059CB File Offset: 0x00003BCB
		// (set) Token: 0x0600030F RID: 783 RVA: 0x000059D3 File Offset: 0x00003BD3
		public RelayCommand CopyChannelClickCommand { get; private set; }

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000310 RID: 784 RVA: 0x000059DC File Offset: 0x00003BDC
		// (set) Token: 0x06000311 RID: 785 RVA: 0x000059E4 File Offset: 0x00003BE4
		public RelayCommand CopyCommand { get; private set; }

		// Token: 0x06000312 RID: 786 RVA: 0x00017ED8 File Offset: 0x000160D8
		public SaveLoadCopy()
		{
			this.SwitchButtonGroupCommand = new RelayCommand<int>(new Action<int>(this.SwitchButtonGroupExecute));
			this.SelectAllCommand = new RelayCommand(new Action(this.SelectAllExecute));
			this.MouseEnterSaveLoadAreaCommand = new RelayCommand(new Action(this.MouseEnterSaveLoadAreaExecute));
			this.MouseEnterCopyAreaCommand = new RelayCommand(new Action(this.MouseEnterCopyAreaExecute));
			this.LoadDevicePresetCommand = new RelayCommand(new Action(this.LoadDevicePresetExecute));
			this.SaveDevicePresetCommand = new RelayCommand(new Action(this.SaveDevicePresetExecute));
			this.DeleteDevicePresetCommand = new RelayCommand(new Action(this.DeleteDevicePresetExecute));
			this.LoadPCPresetCommand = new RelayCommand(new Action(this.LoadPCPresetExecute));
			this.SavePCPresetCommand = new RelayCommand(new Action(this.SavePCPresetExecute));
			this.DeletePCPresetCommand = new RelayCommand(new Action(this.DeletePCPresetExecute));
			this.CopyChannelClickCommand = new RelayCommand(new Action(this.CopyChannelClickExecute));
			this.CopyCommand = new RelayCommand(new Action(this.CopyExecute));
			this.InitialProperty();
			this.ButtonGroup = this.OfflineCommandGroup;
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_DefaultPreset), new Action<byte[]>(this.DefaultSettingExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_DeletePreset), new Action<byte[]>(this.DeletePresetExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_SavePreset), new Action<byte[]>(this.SavePresetExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_ReadPresetList), new Action<byte[]>(this.UpdatePresetListExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_Copy), new Action<byte[]>(this.DeviceFinishCopyExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_ReadCurrentScene), new Action<byte[]>(this.ReadCurrentSceneExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_SyncCommand), new Action<byte[]>(this.SyncExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_LoadlocalFinish), new Action<byte[]>(this.PCLoadFinishExecute));
			ViewModelMessager.Messeager.Register(ViewModelMessager.UpdateDSPGEQFXIndex, new Action(this.UpdateDSPGEQFXExecute));
		}

		// Token: 0x06000313 RID: 787 RVA: 0x000182E8 File Offset: 0x000164E8
		private void PCLoadFinishExecute(byte[] obj)
		{
			bool flag = obj[11] == 4;
			if (flag)
			{
				Task.Factory.StartNew(delegate
				{
					Thread.Sleep(2000);
					UpStream.SendCMD_Recall();
				}).ContinueWith(delegate(Task _)
				{
					Application.Current.Dispatcher.Invoke(delegate
					{
						ViewModelMessager.Messeager.Notify(ViewModelMessager.IsBusy, false);
						MessageBox.Show(LocalizationManager.GetString("Str_LoadSuccessfully"));
						this._IsLoading = false;
					});
				});
			}
		}

		// Token: 0x06000314 RID: 788 RVA: 0x00018340 File Offset: 0x00016540
		private void SyncExecute(byte[] obj)
		{
			bool flag = this._IsLoading && PageData.PresentPageType == PageType.Save_Load_Copy && (obj[10] == CommandConst.DEVE_PAGE_HOME || obj[10] == CommandConst.DEVE_PAGE_GEQ || obj[10] == CommandConst.DEVE_PAGE_DFX || obj[10] == CommandConst.DEVE_PAGE_MIXER);
			if (flag)
			{
				ViewModelMessager.Messeager.Notify(ViewModelMessager.IsBusy, false);
				Application.Current.Dispatcher.Invoke(delegate
				{
				});
				this._IsLoading = false;
			}
		}

		// Token: 0x06000315 RID: 789 RVA: 0x00003B79 File Offset: 0x00001D79
		private void ReadCurrentSceneExecute(byte[] obj)
		{
		}

		// Token: 0x06000316 RID: 790 RVA: 0x000183E4 File Offset: 0x000165E4
		private void DefaultSettingExecute(byte[] obj)
		{
			int num = 12;
			for (int i = 0; i < 30; i++)
			{
				byte b = obj[num++];
				ChannelData.ChannelDatas.DeviceChannels[i].PresetIndex = ((b == byte.MaxValue) ? (-1) : ((int)b));
			}
			for (int j = 0; j < 2; j++)
			{
				byte b2 = obj[num++];
				FXData.FXs[j].PresetIndex = ((b2 == byte.MaxValue) ? (-1) : ((int)b2));
			}
			byte b3 = obj[num++];
			GEQData.GEQDatas.Main.PresetIndex = ((b3 == byte.MaxValue) ? (-1) : ((int)b3));
			for (int k = 4; k < 8; k++)
			{
				byte b4 = obj[num++];
				GEQData.GEQDatas.GEQs[k].PresetIndex = ((b4 == byte.MaxValue) ? (-1) : ((int)b4));
			}
			for (int l = 0; l < 4; l++)
			{
				byte b5 = obj[num++];
				GEQData.GEQDatas.GEQs[l].PresetIndex = ((b5 == byte.MaxValue) ? (-1) : ((int)b5));
			}
			byte b6 = obj[num++];
			this.SceneGroup.SelectedPresetIndex = ((b6 == byte.MaxValue) ? (-1) : ((int)b6));
			num++;
			num++;
			num++;
			num++;
			num++;
			num++;
			num++;
			num++;
			num++;
			num++;
			this.UpdateDSPGEQFXExecute();
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00018578 File Offset: 0x00016778
		private void CopyExecute()
		{
			int num = 0;
			foreach (CheckBoxItem checkBoxItem in this.CopyItemGroup)
			{
				bool isChecked = checkBoxItem.IsChecked;
				if (isChecked)
				{
					num |= checkBoxItem.Index;
				}
			}
			byte b = (byte)(this.SelectedCopyChannelIndex + 1);
			List<byte> list = new List<byte> { b };
			foreach (CheckBoxItem checkBoxItem2 in this.CheckBoxGroup)
			{
				bool isChecked2 = checkBoxItem2.IsChecked;
				if (isChecked2)
				{
					list.Add(1);
				}
				else
				{
					list.Add(0);
				}
			}
			list.Add((byte)num);
			UpStreamCommand.SendCopyChannel(list.ToArray());
		}

		// Token: 0x06000318 RID: 792 RVA: 0x00018670 File Offset: 0x00016870
		private void CopyChannelClickExecute()
		{
			bool flag = true;
			foreach (CheckBoxItem checkBoxItem in this.CheckBoxGroup)
			{
				bool isEnabled = checkBoxItem.IsEnabled;
				if (isEnabled)
				{
					flag &= checkBoxItem.IsChecked;
				}
			}
			this.IsClickAll = flag;
		}

		// Token: 0x06000319 RID: 793 RVA: 0x000186DC File Offset: 0x000168DC
		private void DeletePCPresetExecute()
		{
			bool flag = this.SelectGroup.SelectedPresetIndex == -1 || this.SelectGroup.PresetItems.Count == 0;
			if (!flag)
			{
				PresetType presetType = this.SelectedGroupIndex + PresetType.DSP;
				string text = AppDomain.CurrentDomain.BaseDirectory + "Presets";
				bool flag2 = !Directory.Exists(text);
				if (flag2)
				{
					Directory.CreateDirectory(text);
				}
				string presetName = this.SelectGroup.PresetItems[this.SelectGroup.SelectedPresetIndex].PresetName;
				string text2 = text + "/" + presetName;
				bool flag3 = !FileHelper.IsFileCanUse(text2);
				if (!flag3)
				{
					File.Delete(text2);
					this.RefreshLocalPresetGroup();
					bool flag4 = this.SelectGroup.PresetItems.Count > 0;
					if (flag4)
					{
						this.SelectGroup.SelectedPresetIndex = 0;
					}
				}
			}
		}

		// Token: 0x0600031A RID: 794 RVA: 0x000187C8 File Offset: 0x000169C8
		private void SavePCPresetExecute()
		{
			PresetType presetType = this.SelectedGroupIndex + PresetType.DSP;
			string text = AppDomain.CurrentDomain.BaseDirectory + "Presets";
			bool flag = !Directory.Exists(text);
			if (flag)
			{
				Directory.CreateDirectory(text);
			}
			InputWindowViewModel inputWindowViewModel = new InputWindowViewModel
			{
				Title = "Input Name",
				InputString = "",
				RegularExpression = "^[a-z0-9A-Z_]*$"
			};
			InputWindow inputWindow = new InputWindow
			{
				Owner = WindowHelper.GetTopWindow(),
				DataContext = inputWindowViewModel
			};
			inputWindowViewModel.Window = inputWindow;
			inputWindow.ShowDialog();
			bool flag2 = false;
			bool result = inputWindowViewModel.Result;
			if (result)
			{
				switch (presetType)
				{
				case PresetType.DSP:
					flag2 = Serializer.Serialize(ChannelData.ChannelDatas.DeviceChannels[(int)this._SelectedDSPIndex], text + "/" + inputWindowViewModel.InputString + ".dsp");
					break;
				case PresetType.GEQ:
					flag2 = JSerializer.Serialize(GEQData.GEQDatas.GEQs[(int)this._SelectedGEQIndex], text + "/" + inputWindowViewModel.InputString + ".geq");
					break;
				case PresetType.FX:
					flag2 = JSerializer.Serialize(FXData.FXs[(int)this._SelectedIndex], text + "/" + inputWindowViewModel.InputString + ".fx");
					break;
				case PresetType.Scene:
					flag2 = Serializer.Serialize(SceneData.SceneInfo, text + "/" + inputWindowViewModel.InputString + ".scene");
					break;
				}
			}
			bool flag3 = flag2;
			if (flag3)
			{
				this.RefreshLocalPresetGroup();
			}
		}

		// Token: 0x0600031B RID: 795 RVA: 0x00018968 File Offset: 0x00016B68
		private void LoadPCPresetExecute()
		{
			if (this.SelectGroup.SelectedPresetIndex != -1 && this.SelectGroup.PresetItems.Count != 0)
			{
				PresetType presetType = this.SelectedGroupIndex + PresetType.DSP;
				string text = AppDomain.CurrentDomain.BaseDirectory + "Presets";
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				string presetName = this.SelectGroup.PresetItems[this.SelectGroup.SelectedPresetIndex].PresetName;
				switch (presetType)
				{
				case PresetType.DSP:
					UpStreamCommand.SendLoadPresetFromPC(IOBinaryOperation.ReadBinaryFile(text + "\\" + presetName, 57), (byte)ChannelData.PresentChannelIndex);
					break;
				case PresetType.GEQ:
				{
					GEQInfo geqinfo = JSerializer.Deserialize(text + "\\" + presetName) as GEQInfo;
					UpStreamCommand.SendLoadPresetFromPC(geqinfo, GEQData.GEQIndexPageToDevice[geqinfo.Index]);
					break;
				}
				case PresetType.FX:
				{
					FXInfo<FXItem> fxinfo = JSerializer.Deserialize(text + "\\" + presetName) as FXInfo<FXItem>;
					UpStreamCommand.SendLoadPresetFromPC(fxinfo, (byte)fxinfo.FXIndex);
					break;
				}
				case PresetType.Scene:
					UpStreamCommand.SendLoadPresetFromPC(IOBinaryOperation.ReadBinaryFile(text + "\\" + presetName, 3928));
					break;
				}
				if (MainData.ConnectionModel.IsConnected)
				{
					ViewModelMessager.Messeager.Notify(ViewModelMessager.IsBusy, true);
					this._IsLoading = true;
				}
			}
		}

		// Token: 0x0600031C RID: 796 RVA: 0x00018AB8 File Offset: 0x00016CB8
		private void DeleteDevicePresetExecute()
		{
			bool flag = MessageBox.Show(LocalizationManager.GetString("Str_DeleteWarning"), LocalizationManager.GetString("Str_Warning"), MessageBoxButton.YesNo) == MessageBoxResult.Yes;
			if (flag)
			{
				this.PresetNameIndex = this.SelectGroup.SelectedPresetIndex;
				bool flag2 = this.PresetNameIndex < 0 || this.PresetNameIndex > this.SelectGroup.PresetItems.Count;
				if (!flag2)
				{
					this.CHIndex = this.SelectedGroupIndex + 1;
					switch (this.CHIndex)
					{
					case 1:
						this.DSP[this.PresetNameIndex].PresetName = "---Empty---";
						break;
					case 2:
						this.GEQ[this.PresetNameIndex].PresetName = "---Empty---";
						break;
					case 3:
						this.FX[this.PresetNameIndex].PresetName = "---Empty---";
						break;
					case 4:
						this.Scene[this.PresetNameIndex].PresetName = "---Empty---";
						break;
					}
					UpStreamCommand.SendDeletePreset((byte)(this.SelectedGroupIndex + 1), (byte)this.SelectGroup.SelectedPresetIndex);
				}
			}
		}

		// Token: 0x0600031D RID: 797 RVA: 0x00018BF0 File Offset: 0x00016DF0
		private void SaveDevicePresetExecute()
		{
			InputWindowViewModel inputWindowViewModel = new InputWindowViewModel
			{
				Title = "Input Name",
				InputString = (this.SelectGroup.PresetItems[this.SelectGroup.SelectedPresetIndex].PresetName.StartsWith("---") ? "" : this.SelectGroup.PresetItems[this.SelectGroup.SelectedPresetIndex].PresetName),
				RegularExpression = "^[a-z0-9A-Z_]*$"
			};
			InputWindow inputWindow = new InputWindow
			{
				Owner = WindowHelper.GetTopWindow(),
				DataContext = inputWindowViewModel
			};
			inputWindowViewModel.Window = inputWindow;
			inputWindow.ShowDialog();
			bool result = inputWindowViewModel.Result;
			if (result)
			{
				PresetType presetType = this.SelectedGroupIndex + PresetType.DSP;
				this.CHPresetName = inputWindowViewModel.InputString;
				this.PresetNameIndex = this.SelectGroup.SelectedPresetIndex;
				switch (presetType)
				{
				case PresetType.DSP:
				{
					byte b = this._SelectedDSPIndex + 1;
					this.DSP[this.SelectGroup.SelectedPresetIndex].PresetName = inputWindowViewModel.InputString;
					UpStreamCommand.SendSavePreset(presetType, 1, (byte)this.SelectGroup.SelectedPresetIndex, inputWindowViewModel.InputString);
					break;
				}
				case PresetType.GEQ:
				{
					byte b = GEQData.GEQIndexPageToDevice[(int)this._SelectedGEQIndex];
					this.GEQ[this.SelectGroup.SelectedPresetIndex].PresetName = inputWindowViewModel.InputString;
					UpStreamCommand.SendSavePreset(presetType, 1, (byte)this.SelectGroup.SelectedPresetIndex, inputWindowViewModel.InputString);
					break;
				}
				case PresetType.FX:
				{
					byte b = this._SelectedIndex + 3;
					this.FX[this.SelectGroup.SelectedPresetIndex].PresetName = inputWindowViewModel.InputString;
					UpStreamCommand.SendSavePreset(presetType, 1, (byte)this.SelectGroup.SelectedPresetIndex, inputWindowViewModel.InputString);
					bool isFirstSendFXPreset = this.IsFirstSendFXPreset;
					if (isFirstSendFXPreset)
					{
						Thread.Sleep(5000);
					}
					this.IsFirstSendFXPreset = false;
					break;
				}
				case PresetType.Scene:
				{
					this.Scene[this.SelectGroup.SelectedPresetIndex].PresetName = inputWindowViewModel.InputString;
					List<byte> list = new List<byte>
					{
						1,
						32,
						3,
						0,
						31,
						0,
						35,
						0,
						1,
						0,
						22,
						4,
						1,
						(byte)this.PresetNameIndex
					};
					for (int i = 0; i < 16; i++)
					{
						bool flag = i < inputWindowViewModel.InputString.Length;
						if (flag)
						{
							list.Add((byte)inputWindowViewModel.InputString[i]);
						}
						else
						{
							list.Add(32);
						}
					}
					list.Add(64);
					UpStream.SendSceneSaveToDevice(list.ToArray());
					Thread.Sleep(3000);
					break;
				}
				}
				this.IsFirstSendFXPreset = false;
			}
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00018F28 File Offset: 0x00017128
		private void LoadDevicePresetExecute()
		{
			bool flag = this.SelectGroup.SelectedPresetIndex == -1;
			if (!flag)
			{
				PresetType presetType = this.SelectedGroupIndex + PresetType.DSP;
				bool flag2 = this.SelectGroup.PresetItems[this.SelectGroup.SelectedPresetIndex].PresetName == "---Empty---" || this.SelectGroup.PresetItems[this.SelectGroup.SelectedPresetIndex].PresetName == "---Empty---     ";
				if (flag2)
				{
					MessageBox.Show("The preset you choose is empty.");
				}
				else
				{
					byte b = 0;
					switch (presetType)
					{
					case PresetType.DSP:
						b = this._SelectedDSPIndex + 1;
						break;
					case PresetType.GEQ:
						b = GEQData.GEQIndexPageToDevice[(int)this._SelectedGEQIndex];
						break;
					case PresetType.FX:
						b = this._SelectedIndex + 1;
						break;
					}
					UpStreamCommand.SendLoadPreset(presetType, b, (byte)this.SelectGroup.SelectedPresetIndex);
					bool isConnected = MainData.ConnectionModel.IsConnected;
					if (isConnected)
					{
						ViewModelMessager.Messeager.Notify(ViewModelMessager.IsBusy, true);
						this._IsLoading = true;
					}
				}
			}
		}

		// Token: 0x0600031F RID: 799 RVA: 0x00019054 File Offset: 0x00017254
		private void UpdateDSPGEQFXExecute()
		{
			this._SelectedDSPIndex = (byte)ChannelData.PresentChannelIndex;
			this._SelectedGEQIndex = GEQData.PresentGEQIndex;
			this._SelectedIndex = FXData.PresentFxIndex;
			this.LocalDSPGroup.SelectChannel = (this.DSPGroup.SelectChannel = ChannelData.ChannelDatas.DeviceChannels[(int)this._SelectedDSPIndex].ChannelName);
			this.LocalGEQGroup.SelectChannel = (this.GEQGroup.SelectChannel = GEQData.GEQDatas.GEQs[(int)this._SelectedGEQIndex].ChannnelName);
			this.LocalFXGroup.SelectChannel = (this.FXGroup.SelectChannel = FXData.FXs[(int)this._SelectedIndex].GroupName);
			this.DSPGroup.SelectedPresetIndex = ChannelData.ChannelDatas.DeviceChannels[(int)this._SelectedDSPIndex].PresetIndex;
			this.GEQGroup.SelectedPresetIndex = GEQData.GEQDatas.GEQs[(int)this._SelectedGEQIndex].PresetIndex;
			this.FXGroup.SelectedPresetIndex = FXData.FXs[(int)this._SelectedIndex].PresetIndex;
			this.DSPGroup.SelectedPreset = ((this.DSPGroup.SelectedPresetIndex == -1) ? null : this.DSPGroup.PresetItems[this.DSPGroup.SelectedPresetIndex].PresetName);
			this.GEQGroup.SelectedPreset = ((this.GEQGroup.SelectedPresetIndex == -1) ? null : this.GEQGroup.PresetItems[this.GEQGroup.SelectedPresetIndex].PresetName);
			this.FXGroup.SelectedPreset = ((this.FXGroup.SelectedPresetIndex == -1) ? null : this.FXGroup.PresetItems[this.FXGroup.SelectedPresetIndex].PresetName);
			this.SceneGroup.SelectedPreset = ((this.SceneGroup.SelectedPresetIndex == -1) ? null : this.SceneGroup.PresetItems[this.SceneGroup.SelectedPresetIndex].PresetName);
		}

		// Token: 0x06000320 RID: 800 RVA: 0x000059ED File Offset: 0x00003BED
		private void MouseEnterCopyAreaExecute()
		{
			UpStreamCommand.SendSynchronizePage(CommandConst.DEVE_PAGE_COPY, 0, 0, 0);
		}

		// Token: 0x06000321 RID: 801 RVA: 0x000059FE File Offset: 0x00003BFE
		private void MouseEnterSaveLoadAreaExecute()
		{
			UpStreamCommand.SendSynchronizePage(CommandConst.DEVE_PAGE_SYSTEM, 0, 0, 0);
		}

		// Token: 0x06000322 RID: 802 RVA: 0x00005A0F File Offset: 0x00003C0F
		private void DeviceFinishCopyExecute(byte[] obj)
		{
			MessageBox.Show("Copy successfully");
			this.CheckCopyIndex = 0;
		}

		// Token: 0x06000323 RID: 803 RVA: 0x00019280 File Offset: 0x00017480
		private void UpdateAfterLoadLocalPreset(int presetType)
		{
			switch (presetType)
			{
			}
		}

		// Token: 0x06000324 RID: 804 RVA: 0x000192B4 File Offset: 0x000174B4
		private void UpdatePresetListExecute(byte[] obj)
		{
			int num = 12;
			ObservableCollection<PresetItem> observableCollection = null;
			switch (obj[11])
			{
			case 1:
				observableCollection = this.DSP;
				break;
			case 2:
				observableCollection = this.GEQ;
				break;
			case 3:
				observableCollection = this.FX;
				break;
			case 4:
				observableCollection = this.Scene;
				break;
			}
			bool flag = observableCollection != null;
			if (flag)
			{
				foreach (PresetItem presetItem in observableCollection)
				{
					string text = "";
					for (int i = 0; i < 16; i++)
					{
						text = text.Append((char)obj[num++]);
					}
					presetItem.PresetName = (string.IsNullOrWhiteSpace(text) ? "---Empty---" : text);
				}
			}
		}

		// Token: 0x06000325 RID: 805 RVA: 0x000193A4 File Offset: 0x000175A4
		private void SavePresetExecute(byte[] obj)
		{
			bool flag = obj.Length == 11;
			if (!flag)
			{
				switch (this.CHIndex)
				{
				case 1:
					this.DSP[this.PresetNameIndex].PresetName = this.CHPresetName;
					break;
				case 2:
					this.GEQ[this.PresetNameIndex].PresetName = this.CHPresetName;
					break;
				case 3:
					this.FX[this.PresetNameIndex].PresetName = this.CHPresetName;
					break;
				case 4:
					this.Scene[this.PresetNameIndex].PresetName = this.CHPresetName;
					break;
				}
			}
		}

		// Token: 0x06000326 RID: 806 RVA: 0x00019464 File Offset: 0x00017664
		private void DeletePresetExecute(byte[] obj)
		{
			bool flag = obj.Length == 11;
			if (!flag)
			{
				switch (this.CHIndex)
				{
				case 1:
					this.DSP[this.PresetNameIndex].PresetName = "---Empty---";
					break;
				case 2:
					this.GEQ[this.PresetNameIndex].PresetName = "---Empty---";
					break;
				case 3:
					this.FX[this.PresetNameIndex].PresetName = "---Empty---";
					break;
				case 4:
					this.Scene[this.PresetNameIndex].PresetName = "---Empty---";
					break;
				}
			}
		}

		// Token: 0x06000327 RID: 807 RVA: 0x00019520 File Offset: 0x00017720
		private void SelectAllExecute()
		{
			foreach (CheckBoxItem checkBoxItem in this.CheckBoxGroup)
			{
				bool isEnabled = checkBoxItem.IsEnabled;
				if (isEnabled)
				{
					checkBoxItem.IsChecked = this.IsClickAll;
				}
			}
		}

		// Token: 0x06000328 RID: 808 RVA: 0x00019584 File Offset: 0x00017784
		private void SwitchButtonGroupExecute(int obj)
		{
			this.ButtonGroup = ((obj == 0) ? this.OnlineCommandGroup : this.OfflineCommandGroup);
			this._IsOnline = obj == 0;
			this.SelectedPresetGroups = ((obj == 0) ? this.PresetGroups : this.LocalPresetGroups);
			this.SelectedGroupIndex = 0;
		}

		// Token: 0x06000329 RID: 809 RVA: 0x000195D4 File Offset: 0x000177D4
		private void InitialProperty()
		{
			for (int i = 0; i < 48; i++)
			{
				this.DSP.Add(new PresetItem("---Empty---", "DSP", i));
			}
			for (int j = 0; j < 48; j++)
			{
				this.GEQ.Add(new PresetItem("---Empty---", "GEQ", j));
			}
			for (int k = 0; k < 104; k++)
			{
				this.FX.Add(new PresetItem("---Empty---", "FX", k));
			}
			for (int l = 0; l < 24; l++)
			{
				this.Scene.Add(new PresetItem("---Empty---", "Scene", l));
			}
			this.DSPGroup = new PresetGroup
			{
				GroupName = "DSP",
				PresetItems = this.DSP
			};
			this.GEQGroup = new PresetGroup
			{
				GroupName = "GEQ",
				PresetItems = this.GEQ
			};
			this.FXGroup = new PresetGroup
			{
				GroupName = "FX",
				PresetItems = this.FX
			};
			this.SceneGroup = new PresetGroup
			{
				GroupName = "Sence",
				PresetItems = this.Scene
			};
			this.PresetGroups.Add(this.DSPGroup);
			this.PresetGroups.Add(this.GEQGroup);
			this.PresetGroups.Add(this.FXGroup);
			this.PresetGroups.Add(this.SceneGroup);
			this.LocalDSPGroup = new PresetGroup
			{
				GroupName = "DSP",
				PresetItems = new ObservableCollection<PresetItem>()
			};
			this.LocalGEQGroup = new PresetGroup
			{
				GroupName = "GEQ",
				PresetItems = new ObservableCollection<PresetItem>()
			};
			this.LocalFXGroup = new PresetGroup
			{
				GroupName = "FX",
				PresetItems = new ObservableCollection<PresetItem>()
			};
			this.LocalSceneGroup = new PresetGroup
			{
				GroupName = "Scene",
				PresetItems = new ObservableCollection<PresetItem>()
			};
			this.LocalPresetGroups.Add(this.LocalDSPGroup);
			this.LocalPresetGroups.Add(this.LocalGEQGroup);
			this.LocalPresetGroups.Add(this.LocalFXGroup);
			this.LocalPresetGroups.Add(this.LocalSceneGroup);
			this.OnlineCommandGroup.Add(new ButtonItem("Str_Load")
			{
				Command = this.LoadDevicePresetCommand
			});
			this.OnlineCommandGroup.Add(new ButtonItem("Str_Save")
			{
				Command = this.SaveDevicePresetCommand
			});
			this.OnlineCommandGroup.Add(new ButtonItem("Str_Delete")
			{
				Command = this.DeleteDevicePresetCommand
			});
			this.OfflineCommandGroup.Add(new ButtonItem("Str_Load")
			{
				Command = this.LoadPCPresetCommand
			});
			this.OfflineCommandGroup.Add(new ButtonItem("Str_Save")
			{
				Command = this.SavePCPresetCommand
			});
			this.OfflineCommandGroup.Add(new ButtonItem("Str_Delete")
			{
				Command = this.DeletePCPresetCommand
			});
			List<string> list = new List<string>();
			for (int m = 0; m < ChannelData.ChannelDatas.DeviceChannels.Count; m++)
			{
				this.CheckBoxGroup.Add(new CheckBoxItem
				{
					Content = ChannelData.ChannelDatas.DeviceChannels[m].DefaultChannelName,
					Index = m,
					Command = this.CopyChannelClickCommand
				});
				list.Add(ChannelData.ChannelDatas.DeviceChannels[m].DefaultChannelName);
			}
			this.ChannelGroup = list.ToArray();
			this.ButtonGroup = this.OfflineCommandGroup;
			this.CheckBoxGroup.First<CheckBoxItem>().IsEnabled = false;
			this.SelectedPresetGroups = this.LocalPresetGroups;
			this.SelectedGroupIndex = 0;
			int num = 0;
			while (num < this._CopyItemStringKeyArray.Length && num < this._CopyItemIndexArray.Length)
			{
				this.CopyItemGroup.Add(new CheckBoxItem
				{
					ContentKey = this._CopyItemStringKeyArray[num],
					Index = this._CopyItemIndexArray[num]
				});
				num++;
			}
			this.RefreshLocalPresetGroup();
		}

		// Token: 0x0600032A RID: 810 RVA: 0x00019A6C File Offset: 0x00017C6C
		private void RefreshLocalPresetGroup()
		{
			string text = AppDomain.CurrentDomain.BaseDirectory + "Presets";
			bool flag = !Directory.Exists(text);
			if (flag)
			{
				Directory.CreateDirectory(text);
			}
			string[] files = Directory.GetFiles(text, "*.dsp");
			string[] files2 = Directory.GetFiles(text, "*.geq");
			string[] files3 = Directory.GetFiles(text, "*.fx");
			string[] files4 = Directory.GetFiles(text, "*.scene");
			foreach (PresetGroup presetGroup in this.LocalPresetGroups)
			{
				presetGroup.PresetItems.Clear();
			}
			for (int i = 0; i < files.Length; i++)
			{
				string text2 = files[i].Split(new char[] { '\\' }).Last<string>();
				this.LocalDSPGroup.PresetItems.Add(new PresetItem(text2, "DSP", i));
			}
			for (int j = 0; j < files2.Length; j++)
			{
				string text3 = files2[j].Split(new char[] { '\\' }).Last<string>();
				this.LocalGEQGroup.PresetItems.Add(new PresetItem(text3, "GEQ", j));
			}
			for (int k = 0; k < files3.Length; k++)
			{
				string text4 = files3[k].Split(new char[] { '\\' }).Last<string>();
				this.LocalFXGroup.PresetItems.Add(new PresetItem(text4, "FX", k));
			}
			for (int l = 0; l < files4.Length; l++)
			{
				string text5 = files4[l].Split(new char[] { '\\' }).Last<string>();
				this.LocalSceneGroup.PresetItems.Add(new PresetItem(text5, "Scene", l));
			}
		}

		// Token: 0x0400020C RID: 524
		private int _SelectedCopyChannelIndex;

		// Token: 0x0400020D RID: 525
		private int CheckLoadIndex = 0;

		// Token: 0x0400020E RID: 526
		private int CheckCopyIndex = 0;

		// Token: 0x0400020F RID: 527
		private bool IsFirstSendFXPreset = true;

		// Token: 0x04000210 RID: 528
		private ObservableCollection<PresetGroup> _PresetGroups = new ObservableCollection<PresetGroup>();

		// Token: 0x04000211 RID: 529
		private ObservableCollection<PresetGroup> _LocalPresetGroups = new ObservableCollection<PresetGroup>();

		// Token: 0x04000212 RID: 530
		private ObservableCollection<PresetGroup> _SelectedPresetGroups;

		// Token: 0x04000213 RID: 531
		private PresetGroup _SelectGroup;

		// Token: 0x04000214 RID: 532
		private int _SelectedGroupIndex;

		// Token: 0x04000215 RID: 533
		private ObservableCollection<ButtonItem> _ButtonGroup;

		// Token: 0x04000216 RID: 534
		private ObservableCollection<CheckBoxItem> _CheckBoxGroup = new ObservableCollection<CheckBoxItem>();

		// Token: 0x04000217 RID: 535
		private ObservableCollection<CheckBoxItem> _CopyItemGroup = new ObservableCollection<CheckBoxItem>();

		// Token: 0x04000218 RID: 536
		private bool _IsClickAll = false;

		// Token: 0x04000219 RID: 537
		private int _ScenePresetIndex;

		// Token: 0x04000226 RID: 550
		private bool _IsOnline;

		// Token: 0x04000227 RID: 551
		private bool _IsLoading;

		// Token: 0x04000228 RID: 552
		private byte _SelectedDSPIndex;

		// Token: 0x04000229 RID: 553
		private byte _SelectedGEQIndex;

		// Token: 0x0400022A RID: 554
		private byte _SelectedIndex;

		// Token: 0x0400022B RID: 555
		private string[] _CopyItemStringKeyArray = new string[] { "Str_Invert", "Str_Gain", "Str_Delay", "Str_NoiseGate", "Str_Compressor", "Str_EQ", "Str_AssignMain", "Str_Send" };

		// Token: 0x0400022C RID: 556
		private int[] _CopyItemIndexArray = new int[] { 128, 64, 32, 16, 4, 8, 2, 1 };
	}
}
