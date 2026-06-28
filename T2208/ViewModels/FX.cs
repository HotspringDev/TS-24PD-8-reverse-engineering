using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Timers;
using System.Windows;
using JayLib.WPF.BasicClass;
using T2208.DeviceCommuncation;
using T2208.Models;
using T2208.MyDatas;
using T2208.MyInformations;

namespace T2208.ViewModels
{
	// Token: 0x02000039 RID: 57
	public class FX : ViewModelBase
	{
		// Token: 0x170000BA RID: 186
		// (get) Token: 0x0600025B RID: 603 RVA: 0x00016A24 File Offset: 0x00014C24
		// (set) Token: 0x0600025C RID: 604 RVA: 0x00005051 File Offset: 0x00003251
		public ObservableCollection<GroupInfo<FXItem>> FXGroups
		{
			get
			{
				return this._FXGroups;
			}
			set
			{
				this._FXGroups = value;
				this.OnPropertyChanged<ObservableCollection<GroupInfo<FXItem>>>(() => this.FXGroups);
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x0600025D RID: 605 RVA: 0x00016A3C File Offset: 0x00014C3C
		// (set) Token: 0x0600025E RID: 606 RVA: 0x00005091 File Offset: 0x00003291
		public GroupInfo<FXItem> SelectedFX
		{
			get
			{
				return this._SelectedFX;
			}
			set
			{
				this._SelectedFX = value;
				this.OnPropertyChanged<GroupInfo<FXItem>>(() => this.SelectedFX);
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x0600025F RID: 607 RVA: 0x00016A54 File Offset: 0x00014C54
		// (set) Token: 0x06000260 RID: 608 RVA: 0x00016A6C File Offset: 0x00014C6C
		public int SelectedFXIndex
		{
			get
			{
				return this._SelectedFXIndex;
			}
			set
			{
				this._SelectedFXIndex = value;
				this.OnPropertyChanged<int>(() => this.SelectedFXIndex);
				FXData.PresentFxIndex = (byte)value;
				FX.FXSelectedIndex = value;
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000261 RID: 609 RVA: 0x00016AC8 File Offset: 0x00014CC8
		// (set) Token: 0x06000262 RID: 610 RVA: 0x00016AE0 File Offset: 0x00014CE0
		public FXItem SelectedEffectGroup
		{
			get
			{
				return this._SelectedEffectGroup;
			}
			set
			{
				bool flag = value != null;
				if (flag)
				{
					this._SelectedEffectGroup = value;
					this.CopyEffects(value.Effect, this.Effects);
					this.OnPropertyChanged<FXItem>(() => this.SelectedEffectGroup);
				}
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06000263 RID: 611 RVA: 0x00016B48 File Offset: 0x00014D48
		// (set) Token: 0x06000264 RID: 612 RVA: 0x000050D1 File Offset: 0x000032D1
		public ObservableCollection<EffectInfo> Effects
		{
			get
			{
				return this._Effects;
			}
			set
			{
				this._Effects = value;
				this.OnPropertyChanged<ObservableCollection<EffectInfo>>(() => this.Effects);
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06000265 RID: 613 RVA: 0x00016B60 File Offset: 0x00014D60
		// (set) Token: 0x06000266 RID: 614 RVA: 0x00016B78 File Offset: 0x00014D78
		public int SelectedEffectIndex
		{
			get
			{
				return this._SelectedEffectIndex;
			}
			set
			{
				bool flag = value == -1;
				if (!flag)
				{
					this._SelectedEffectIndex = value;
					this.OnPropertyChanged<int>(() => this.SelectedEffectIndex);
					bool flag2 = this.SelectedFXIndex == 0;
					if (flag2)
					{
						FXData.FX1.PresentFXIndex = value;
					}
					else
					{
						FXData.FX2.PresentFXIndex = value;
					}
				}
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000267 RID: 615 RVA: 0x00005111 File Offset: 0x00003311
		// (set) Token: 0x06000268 RID: 616 RVA: 0x00005119 File Offset: 0x00003319
		public RelayCommand FXChangeCommand { get; private set; }

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000269 RID: 617 RVA: 0x00005122 File Offset: 0x00003322
		// (set) Token: 0x0600026A RID: 618 RVA: 0x0000512A File Offset: 0x0000332A
		public RelayCommand EffectChangeCommand { get; private set; }

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x0600026B RID: 619 RVA: 0x00005133 File Offset: 0x00003333
		// (set) Token: 0x0600026C RID: 620 RVA: 0x0000513B File Offset: 0x0000333B
		public RelayCommand PageLoadCommand { get; private set; }

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x0600026D RID: 621 RVA: 0x00005144 File Offset: 0x00003344
		// (set) Token: 0x0600026E RID: 622 RVA: 0x0000514C File Offset: 0x0000334C
		public RelayCommand EffectValueChangeCommand { get; private set; }

		// Token: 0x0600026F RID: 623 RVA: 0x00016BFC File Offset: 0x00014DFC
		public FX()
		{
			this.InitializeProperty();
			this.FXChangeCommand = new RelayCommand(new Action(this.FXChangeExecute));
			this.EffectChangeCommand = new RelayCommand(new Action(this.EffectChangeExecute));
			this.PageLoadCommand = new RelayCommand(new Action(this.PageLoadExecute));
			this.EffectValueChangeCommand = new RelayCommand(new Action(this.EffectValueChangeExecute));
			foreach (FXItem fxitem in FXData.FX1.GroupCollection)
			{
				foreach (EffectInfo effectInfo in fxitem.Effect)
				{
					effectInfo.CommonCommand = this.EffectValueChangeCommand;
				}
			}
			foreach (FXItem fxitem2 in FXData.FX2.GroupCollection)
			{
				foreach (EffectInfo effectInfo2 in fxitem2.Effect)
				{
					effectInfo2.CommonCommand = this.EffectValueChangeCommand;
				}
			}
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_ReadCurrentScene), new Action<byte[]>(this.ReadCurrentSceneExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_DFXChannel), new Action<byte[]>(this.UpdateFXExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_ResetCommand), new Action<byte[]>(this.ResetFXExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_SyncCommand), new Action<byte[]>(this.SychronizeFxExecute));
			this.timer.Elapsed += this.Timer_Elapsed;
			this.timer.AutoReset = false;
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00005155 File Offset: 0x00003355
		private void EffectValueChangeExecute()
		{
			UpStreamCommand.SendFxChange(this.SelectedFXIndex, this.SelectedEffectIndex, this.Effects);
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00016EBC File Offset: 0x000150BC
		private void SychronizeFxExecute(byte[] obj)
		{
			bool flag = obj[10] == CommandConst.DEVE_PAGE_DFX;
			if (flag)
			{
				this._UpdateFromDevice = true;
				this.SelectedFXIndex = (int)(obj[11] - 1);
				this.SelectedEffectIndex = (int)(obj[12] - 1);
				this._UpdateFromDevice = false;
			}
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00005170 File Offset: 0x00003370
		private void PageLoadExecute()
		{
			this.CopyEffects(this.SelectedEffectGroup.Effect, this.Effects);
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000518B File Offset: 0x0000338B
		private void Timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			Application.Current.Dispatcher.Invoke(delegate
			{
				this.UpdateEffects(this.Effects);
			});
		}

		// Token: 0x06000274 RID: 628 RVA: 0x00016F04 File Offset: 0x00015104
		private void ResetFXExecute(byte[] obj)
		{
			foreach (FXItem fxitem in FXData.FX1.GroupCollection)
			{
				foreach (EffectInfo effectInfo in fxitem.Effect)
				{
					effectInfo.EffectValue = effectInfo.DefaultEffectValue;
				}
			}
			foreach (FXItem fxitem2 in FXData.FX2.GroupCollection)
			{
				foreach (EffectInfo effectInfo2 in fxitem2.Effect)
				{
					effectInfo2.EffectValue = effectInfo2.DefaultEffectValue;
				}
			}
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0001702C File Offset: 0x0001522C
		private void UpdateFXExecute(byte[] obj)
		{
			this.SelectedFXIndex = (int)(obj[11] - 1);
			this.SelectedEffectIndex = (int)(obj[12] - 1);
			int num = 13;
			int count = this.FXGroups[this.SelectedFXIndex].GroupCollection[this.SelectedEffectIndex].Effect.Count;
			ObservableCollection<EffectInfo> effect = this.FXGroups[this.SelectedFXIndex].GroupCollection[this.SelectedEffectIndex].Effect;
			for (int i = 0; i < 12; i++)
			{
				bool flag = i < count;
				if (flag)
				{
					effect[i].EffectValue = (int)FXData.GetEffectIndexFromDevice((byte)this.SelectedEffectIndex, (byte)i, obj[num++]);
					this.Effects[i].EffectValue = effect[i].EffectValue;
				}
				else
				{
					num++;
				}
			}
			bool flag2 = this.SelectedFXIndex == 0;
			if (flag2)
			{
				ChannelData.ChannelDatas.FX01.IsMute = obj[num++] == 1;
			}
			else
			{
				ChannelData.ChannelDatas.FX02.IsMute = obj[num++] == 1;
			}
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0001715C File Offset: 0x0001535C
		private void FXChangeExecute()
		{
			bool updateFromDevice = this._UpdateFromDevice;
			if (!updateFromDevice)
			{
				UpStreamCommand.SendSynchronizePage(CommandConst.DEVE_PAGE_DFX, (byte)(this.SelectedFXIndex + 1), (byte)(FXData.FXs[this.SelectedFXIndex].PresentFXIndex + 1), 0);
			}
		}

		// Token: 0x06000277 RID: 631 RVA: 0x000171A4 File Offset: 0x000153A4
		private void EffectChangeExecute()
		{
			bool updateFromDevice = this._UpdateFromDevice;
			if (!updateFromDevice)
			{
				UpStreamCommand.SendSynchronizePage(CommandConst.DEVE_PAGE_DFX, (byte)(this.SelectedFXIndex + 1), (byte)(this.SelectedEffectIndex + 1), 0);
			}
		}

		// Token: 0x06000278 RID: 632 RVA: 0x000051AA File Offset: 0x000033AA
		private void InitializeProperty()
		{
			this.FXGroups.Add(FXData.FX1);
			this.FXGroups.Add(FXData.FX2);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x000171E0 File Offset: 0x000153E0
		private void ReadCurrentSceneExecute(byte[] obj)
		{
			int num = 3407;
			for (int i = 0; i < this.FXGroups.Count; i++)
			{
				bool flag = i == 0;
				if (flag)
				{
					FXData.FX1.PresentFXIndex = (int)(obj[num++] - 1);
				}
				else
				{
					FXData.FX2.PresentFXIndex = (int)(obj[num++] - 1);
				}
				for (int j = 0; j < this.FXGroups[i].GroupCollection.Count; j++)
				{
					for (int k = 0; k < 12; k++)
					{
						bool flag2 = k < this.FXGroups[i].GroupCollection[j].Effect.Count;
						if (flag2)
						{
							this.FXGroups[i].GroupCollection[j].Effect[k].EffectValue = (int)FXData.GetEffectIndexFromDevice((byte)j, (byte)i, obj[num++]);
						}
						else
						{
							num++;
						}
					}
				}
			}
			this.CopyEffects(this.SelectedEffectGroup.Effect, this.Effects);
		}

		// Token: 0x0600027A RID: 634 RVA: 0x00017320 File Offset: 0x00015520
		private void UpdateEffects(ObservableCollection<EffectInfo> effectInfos)
		{
			int num = 0;
			while (num < this._TempEffect.Count && num < effectInfos.Count)
			{
				effectInfos[num].EffectValue = this._TempEffect[num];
				num++;
			}
		}

		// Token: 0x0600027B RID: 635 RVA: 0x00017370 File Offset: 0x00015570
		private void CopyEffects(ObservableCollection<EffectInfo> source, ObservableCollection<EffectInfo> denstination)
		{
			denstination.Clear();
			this._TempEffect.Clear();
			foreach (EffectInfo effectInfo in source)
			{
				denstination.Add(new EffectInfo
				{
					EffectValueCollection = effectInfo.EffectValueCollection,
					EffectIndex = effectInfo.EffectIndex,
					Name = effectInfo.Name,
					EffectValue = effectInfo.EffectValue,
					DefaultEffectValue = effectInfo.DefaultEffectValue,
					IsEnabled = effectInfo.IsEnabled,
					CommonCommand = effectInfo.CommonCommand
				});
				this._TempEffect.Add(effectInfo.EffectValue);
			}
			this.timer.Start();
		}

		// Token: 0x040001CE RID: 462
		private ObservableCollection<GroupInfo<FXItem>> _FXGroups = new ObservableCollection<GroupInfo<FXItem>>();

		// Token: 0x040001CF RID: 463
		private GroupInfo<FXItem> _SelectedFX;

		// Token: 0x040001D0 RID: 464
		public static int FXSelectedIndex;

		// Token: 0x040001D1 RID: 465
		private int _SelectedFXIndex;

		// Token: 0x040001D2 RID: 466
		private FXItem _SelectedEffectGroup;

		// Token: 0x040001D3 RID: 467
		private ObservableCollection<EffectInfo> _Effects = new ObservableCollection<EffectInfo>();

		// Token: 0x040001D4 RID: 468
		private int _SelectedEffectIndex;

		// Token: 0x040001D9 RID: 473
		private Timer timer = new Timer(10.0);

		// Token: 0x040001DA RID: 474
		private bool _UpdateFromDevice = false;

		// Token: 0x040001DB RID: 475
		private List<int> _TempEffect = new List<int>();
	}
}
