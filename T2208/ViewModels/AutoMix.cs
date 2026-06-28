using System;
using System.Collections.ObjectModel;
using JayLib.WPF.BasicClass;
using T2208.DeviceCommuncation;
using T2208.Models;

namespace T2208.ViewModels
{
	// Token: 0x02000029 RID: 41
	public class AutoMix : ViewModelBase
	{
		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600010D RID: 269 RVA: 0x0000E488 File Offset: 0x0000C688
		// (set) Token: 0x0600010E RID: 270 RVA: 0x00004006 File Offset: 0x00002206
		public bool AutoMixActive
		{
			get
			{
				return this._AutoMixActive;
			}
			set
			{
				this._AutoMixActive = value;
				this.OnPropertyChanged<bool>(() => this.AutoMixActive);
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600010F RID: 271 RVA: 0x0000E4A0 File Offset: 0x0000C6A0
		// (set) Token: 0x06000110 RID: 272 RVA: 0x00004046 File Offset: 0x00002246
		public ObservableCollection<ButtonItem> InputGroup
		{
			get
			{
				return this._InputGroup;
			}
			set
			{
				this._InputGroup = value;
				this.OnPropertyChanged<ObservableCollection<ButtonItem>>(() => this.InputGroup);
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000111 RID: 273 RVA: 0x0000E4B8 File Offset: 0x0000C6B8
		// (set) Token: 0x06000112 RID: 274 RVA: 0x00004086 File Offset: 0x00002286
		public int ActiveTimeValue
		{
			get
			{
				return this._ActiveTimeValue;
			}
			set
			{
				this._ActiveTimeValue = value;
				this.OnPropertyChanged<int>(() => this.ActiveTimeValue);
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000113 RID: 275 RVA: 0x000040C6 File Offset: 0x000022C6
		// (set) Token: 0x06000114 RID: 276 RVA: 0x000040CE File Offset: 0x000022CE
		public RelayCommand SelectInputMixer { get; private set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000115 RID: 277 RVA: 0x000040D7 File Offset: 0x000022D7
		// (set) Token: 0x06000116 RID: 278 RVA: 0x000040DF File Offset: 0x000022DF
		public RelayCommand ClearAllCommand { get; private set; }

		// Token: 0x06000117 RID: 279 RVA: 0x0000E4D0 File Offset: 0x0000C6D0
		public AutoMix()
		{
			this.SelectInputMixer = new RelayCommand(new Action(this.SelectInputMixerExecute));
			this.ClearAllCommand = new RelayCommand(new Action(this.ClearAllExecute));
			for (int i = 0; i < 24; i++)
			{
				this.InputGroup.Add(new ButtonItem
				{
					Content = string.Format(string.Format("CH{0}", i + 1), new object[0]),
					Command = this.SelectInputMixer
				});
			}
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_ReadCurrentScene), new Action<byte[]>(this.ReadCurrentSceneExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_AutoMixAssign), new Action<byte[]>(this.UpdateAutoMixExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_SyncCommand), new Action<byte[]>(this.SynchronizeAutoMixExecute));
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0000E610 File Offset: 0x0000C810
		private void ReadCurrentSceneExecute(byte[] obj)
		{
			int num = 4672;
			for (int i = 0; i < 24; i++)
			{
				this.InputGroup[i].IsSelected = obj[num++] == 1;
			}
			this.AutoMixActive = obj[num++] == 0;
			num++;
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0000E668 File Offset: 0x0000C868
		private void ClearAllExecute()
		{
			foreach (ButtonItem buttonItem in this.InputGroup)
			{
				buttonItem.IsSelected = false;
			}
			UpStreamCommand.SendAutoMixer(this.InputGroup, this.AutoMixActive);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00003B79 File Offset: 0x00001D79
		private void SynchronizeAutoMixExecute(byte[] obj)
		{
		}

		// Token: 0x0600011B RID: 283 RVA: 0x000040E8 File Offset: 0x000022E8
		private void SelectInputMixerExecute()
		{
			UpStreamCommand.SendAutoMixer(this.InputGroup, this.AutoMixActive);
		}

		// Token: 0x0600011C RID: 284 RVA: 0x0000E6D0 File Offset: 0x0000C8D0
		private void UpdateAutoMixExecute(byte[] obj)
		{
			int num = 11;
			for (int i = 0; i < this.InputGroup.Count; i++)
			{
				this.InputGroup[i].IsSelected = obj[num++] == 1;
			}
			this.AutoMixActive = obj[num++] == 0;
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0000E72C File Offset: 0x0000C92C
		private void UpdateAutoMixFromRecallExecute(byte[] obj)
		{
			int num = 3850;
			for (int i = 0; i < this.InputGroup.Count; i++)
			{
				this.InputGroup[i].IsSelected = obj[num++] == 1;
			}
			this.AutoMixActive = obj[num++] == 0;
		}

		// Token: 0x040000AC RID: 172
		private bool _AutoMixActive;

		// Token: 0x040000AD RID: 173
		private ObservableCollection<ButtonItem> _InputGroup = new ObservableCollection<ButtonItem>();

		// Token: 0x040000AE RID: 174
		private int _ActiveTimeValue;
	}
}
