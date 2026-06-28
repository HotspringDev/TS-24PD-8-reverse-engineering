using System;
using System.Collections.ObjectModel;
using System.Text;
using JayLib.JayString;
using JayLib.WPF.BasicClass;
using T2208.DeviceCommuncation;
using T2208.Models;
using T2208.MyDatas;
using T2208.MyInformations;

namespace T2208.ViewModels
{
	// Token: 0x0200002D RID: 45
	public class DCA : ViewModelBase
	{
		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060001AA RID: 426 RVA: 0x00012A08 File Offset: 0x00010C08
		// (set) Token: 0x060001AB RID: 427 RVA: 0x00012A20 File Offset: 0x00010C20
		public DCAInfo<DCAItem> SelectedDCA
		{
			get
			{
				return this._SelectedDCA;
			}
			set
			{
				bool flag = value != null;
				if (flag)
				{
					this._SelectedDCA = value;
					this.OnPropertyChanged<DCAInfo<DCAItem>>(() => this.SelectedDCA);
					this.SelectedDCA.IsSelected = true;
				}
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060001AC RID: 428 RVA: 0x00012A84 File Offset: 0x00010C84
		// (set) Token: 0x060001AD RID: 429 RVA: 0x000045EB File Offset: 0x000027EB
		public ObservableCollection<DCAInfo<DCAItem>> DCAGroup
		{
			get
			{
				return this._DCAGroup;
			}
			set
			{
				this._DCAGroup = value;
				this.OnPropertyChanged<ObservableCollection<DCAInfo<DCAItem>>>(() => this.DCAGroup);
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060001AE RID: 430 RVA: 0x00012A9C File Offset: 0x00010C9C
		// (set) Token: 0x060001AF RID: 431 RVA: 0x0000462B File Offset: 0x0000282B
		public int SelectedDCAIndex
		{
			get
			{
				return this._SelectedDCAIndex;
			}
			set
			{
				this._SelectedDCAIndex = value;
				this.OnPropertyChanged<int>(() => this.SelectedDCAIndex);
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060001B0 RID: 432 RVA: 0x0000466B File Offset: 0x0000286B
		// (set) Token: 0x060001B1 RID: 433 RVA: 0x00004673 File Offset: 0x00002873
		public RelayCommand TempGroupSetSelectCommand { get; set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060001B2 RID: 434 RVA: 0x0000467C File Offset: 0x0000287C
		// (set) Token: 0x060001B3 RID: 435 RVA: 0x00004684 File Offset: 0x00002884
		public RelayCommand GroupSetCommand { get; set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x0000468D File Offset: 0x0000288D
		// (set) Token: 0x060001B5 RID: 437 RVA: 0x00004695 File Offset: 0x00002895
		public RelayCommand SelectedDCAChangeCommand { get; private set; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060001B6 RID: 438 RVA: 0x0000469E File Offset: 0x0000289E
		// (set) Token: 0x060001B7 RID: 439 RVA: 0x000046A6 File Offset: 0x000028A6
		public RelayCommand ClearDCAGroupCommand { get; private set; }

		// Token: 0x060001B8 RID: 440 RVA: 0x00012AB4 File Offset: 0x00010CB4
		public DCA()
		{
			this.TempGroupSetSelectCommand = new RelayCommand(new Action(this.TempSelectExecute));
			this.GroupSetCommand = new RelayCommand(new Action(this.GroupSetExecute));
			this.SelectedDCAChangeCommand = new RelayCommand(new Action(this.SelectedDCAChangeExecute));
			this.ClearDCAGroupCommand = new RelayCommand(new Action(this.ClearDCAGroupExecute));
			this.InitializeDCAGroup();
			ViewModelMessager.Messeager.Register<int>(ViewModelMessager.DCAIsSelected, new Action<int>(this.UpdateDCA));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_ReadCurrentScene), new Action<byte[]>(this.ReadCurrentSceneExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_GroupSet), new Action<byte[]>(this.UpdateGroupExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_bGroupSet), new Action<byte[]>(this.UpdateTempGroupExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_allFadergroupGain), new Action<byte[]>(this.UpdateDCAGainExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_allFadergroupSelect), new Action<byte[]>(this.UpdateDCASelectExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_SyncCommand), new Action<byte[]>(this.SynchronizeDCAExecute));
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x000046AF File Offset: 0x000028AF
		private void ClearDCAGroupExecute()
		{
			UpStreamCommand.SendCMD_DCAGroupClear(this.SelectedDCA);
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00012C84 File Offset: 0x00010E84
		private void SelectedDCAChangeExecute()
		{
			bool flag = this.SelectedDCAIndex > -1 && this.SelectedDCAIndex < 12;
			if (flag)
			{
				UpStreamCommand.SendSynchronizePage(CommandConst.DEVE_PAGE_GROUP, (byte)this.SelectedDCAIndex, 0, 0);
			}
		}

		// Token: 0x060001BB RID: 443 RVA: 0x00012CC4 File Offset: 0x00010EC4
		private void SynchronizeDCAExecute(byte[] obj)
		{
			bool flag = obj[10] == CommandConst.DEVE_PAGE_GROUP;
			if (flag)
			{
				this._DeviceDCAIndex = (int)obj[11];
				this.SelectedDCAIndex = (int)obj[11];
			}
		}

		// Token: 0x060001BC RID: 444 RVA: 0x000046BE File Offset: 0x000028BE
		private void GroupSetExecute()
		{
			UpStreamCommand.SendCMD_DCAGroupSet(this.SelectedDCA);
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00012CF8 File Offset: 0x00010EF8
		private void InitializeDCAGroup()
		{
			this.DCAGroup.Add(DCAData.DCA1);
			this.DCAGroup.Add(DCAData.DCA2);
			this.DCAGroup.Add(DCAData.DCA3);
			this.DCAGroup.Add(DCAData.DCA4);
			this.DCAGroup.Add(DCAData.DCA5);
			this.DCAGroup.Add(DCAData.DCA6);
			this.DCAGroup.Add(DCAData.DCA7);
			this.DCAGroup.Add(DCAData.DCA8);
			this.DCAGroup.Add(DCAData.DCA9);
			this.DCAGroup.Add(DCAData.DCA10);
			this.DCAGroup.Add(DCAData.DCA11);
			this.DCAGroup.Add(DCAData.DCA12);
			foreach (DCAInfo<DCAItem> dcainfo in this.DCAGroup)
			{
				foreach (DCAItem dcaitem in dcainfo.GroupCollection)
				{
					dcaitem.Command = this.TempGroupSetSelectCommand;
				}
			}
		}

		// Token: 0x060001BE RID: 446 RVA: 0x000046CD File Offset: 0x000028CD
		private void TempSelectExecute()
		{
			UpStreamCommand.SendCMD_TempDCAGroupSet(this.SelectedDCA);
		}

		// Token: 0x060001BF RID: 447 RVA: 0x00003B79 File Offset: 0x00001D79
		private void ResetDCAExecute(byte[] obj)
		{
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00012E58 File Offset: 0x00011058
		private void UpdateDCASelectExecute(byte[] obj)
		{
			int num = 12;
			int num2 = (int)(obj[num++] - 1);
			DCAData.DCAs[num2].Value = (int)obj[num++];
			DCAData.DCAs[num2].IsSelected = obj[num++] == 1;
			num++;
			DCAData.DCAs[num2].IsMute = obj[num++] == 1;
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x00012EC8 File Offset: 0x000110C8
		private void UpdateDCAGainExecute(byte[] obj)
		{
			int num = 12;
			int num2 = (int)(obj[num++] - 1);
			DCAInfo<DCAItem> dcainfo = DCAData.DCAs[num2];
			dcainfo.IsSelected = obj[num++] == 1;
			num++;
			dcainfo.IsSolo = obj[num++] == 1;
			foreach (ChannelInfo channelInfo in dcainfo.ChannelInfos)
			{
				channelInfo.IsSolo = dcainfo.IsSolo;
			}
			dcainfo.IsMute = obj[num++] == 1;
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x00012F74 File Offset: 0x00011174
		private void UpdateGroupExecute(byte[] obj)
		{
			int num = (int)(obj[11] - 1);
			bool flag = num < 0 || num > 11;
			if (!flag)
			{
				int num2 = 12;
				DCAInfo<DCAItem> dcainfo = DCAData.DCAs[num];
				dcainfo.Value = (int)obj[num2++];
				dcainfo.IsMute = obj[num2++] == 1;
				dcainfo.SceneIndex = (int)obj[num2++];
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < 12; i++)
				{
					bool flag2 = obj[num2] != 0 && obj[num2] != 10 && obj[num2] != 32;
					if (flag2)
					{
						dcainfo.NameBytes[i] = obj[num2];
						stringBuilder.Append((char)obj[num2++]);
					}
					else
					{
						num2++;
					}
				}
				bool flag3 = stringBuilder.Length > 0;
				if (flag3)
				{
					dcainfo.GroupName = stringBuilder.ToString().Trim();
				}
				for (int j = 0; j < 34; j++)
				{
					dcainfo.Channels[j] = obj[num2++];
				}
				dcainfo.ChannelInfos.Clear();
				int num3 = 0;
				while (num3 < dcainfo.Channels.Length && num3 < dcainfo.GroupCollection.Count)
				{
					dcainfo.GroupCollection[num3].IsSelected = dcainfo.Channels[num3] == 1;
					bool isSelected = dcainfo.GroupCollection[num3].IsSelected;
					if (isSelected)
					{
						dcainfo.ChannelInfos.Add(ChannelData.ChannelDatas.DeviceChannels[num3]);
					}
					num3++;
				}
			}
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x00013120 File Offset: 0x00011320
		private void UpdateTempGroupExecute(byte[] obj)
		{
			int num = (int)(obj[11] - 1);
			bool flag = num < 0 || num > 11;
			if (!flag)
			{
				int num2 = 12;
				DCAInfo<DCAItem> dcainfo = DCAData.DCAs[num];
				dcainfo.Value = (int)obj[num2++];
				dcainfo.IsMute = obj[num2++] == 1;
				dcainfo.SceneIndex = (int)obj[num2++];
				string text = "";
				for (int i = 0; i < 12; i++)
				{
					bool flag2 = obj[num2] != 0 && obj[num2] != 10;
					if (flag2)
					{
						text = text.Append((char)obj[num2++]);
					}
					else
					{
						num2++;
					}
				}
				for (int j = 0; j < 34; j++)
				{
					dcainfo.TempChannels[j] = obj[num2++];
				}
				int num3 = 0;
				while (num3 < this.DCAGroup[num].Channels.Length && num3 < this.DCAGroup[num].GroupCollection.Count)
				{
					this.DCAGroup[num].GroupCollection[num3].IsSelected = this.DCAGroup[num].TempChannels[num3] == 1;
					num3++;
				}
			}
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x00013280 File Offset: 0x00011480
		private void ReadCurrentSceneExecute(byte[] obj)
		{
			int num = 4015;
			for (int i = 0; i < this.DCAGroup.Count; i++)
			{
				DCAInfo<DCAItem> dcainfo = this.DCAGroup[i];
				dcainfo.Value = (int)obj[num++];
				dcainfo.IsMute = obj[num++] == 1;
				dcainfo.SceneIndex = (int)obj[num++];
				StringBuilder stringBuilder = new StringBuilder();
				for (int j = 0; j < 12; j++)
				{
					dcainfo.NameBytes[j] = obj[num];
					bool flag = obj[num] != 0 && obj[num] != 10;
					if (flag)
					{
						stringBuilder.Append((char)obj[num++]);
					}
					else
					{
						num++;
					}
				}
				bool flag2 = stringBuilder.Length > 0;
				if (flag2)
				{
					dcainfo.GroupName = stringBuilder.ToString().Trim();
				}
				for (int k = 0; k < 34; k++)
				{
					dcainfo.Channels[k] = obj[num++];
				}
				num++;
				int num2 = 0;
				while (num2 < dcainfo.Channels.Length && num2 < dcainfo.GroupCollection.Count)
				{
					dcainfo.GroupCollection[num2].IsSelected = dcainfo.Channels[num2] == 1;
					bool isSelected = dcainfo.GroupCollection[num2].IsSelected;
					if (isSelected)
					{
						dcainfo.ChannelInfos.Add(ChannelData.ChannelDatas.DeviceChannels[num2]);
					}
					num2++;
				}
			}
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x000046DC File Offset: 0x000028DC
		private void UpdateDCA(int obj)
		{
			this.SelectedDCAIndex = obj;
		}

		// Token: 0x040000E8 RID: 232
		private DCAInfo<DCAItem> _SelectedDCA;

		// Token: 0x040000E9 RID: 233
		private ObservableCollection<DCAInfo<DCAItem>> _DCAGroup = new ObservableCollection<DCAInfo<DCAItem>>();

		// Token: 0x040000EA RID: 234
		private int _SelectedDCAIndex;

		// Token: 0x040000EF RID: 239
		private int _DeviceDCAIndex;
	}
}
