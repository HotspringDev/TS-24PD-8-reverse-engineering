using System;
using System.Collections.ObjectModel;

namespace T2208.ViewModels
{
	// Token: 0x02000031 RID: 49
	public class Ducker : ViewModelBase
	{
		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000204 RID: 516 RVA: 0x00014ED8 File Offset: 0x000130D8
		// (set) Token: 0x06000205 RID: 517 RVA: 0x000049F9 File Offset: 0x00002BF9
		public ObservableCollection<ChannelItem> BackgroundGroup
		{
			get
			{
				return this._BackgroundGroup;
			}
			set
			{
				this._BackgroundGroup = value;
				this.OnPropertyChanged<ObservableCollection<ChannelItem>>(() => this.VoiceSourceGroup);
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000206 RID: 518 RVA: 0x00014EF0 File Offset: 0x000130F0
		// (set) Token: 0x06000207 RID: 519 RVA: 0x00004A39 File Offset: 0x00002C39
		public ObservableCollection<ChannelItem> VoiceSourceGroup
		{
			get
			{
				return this._VoiceSourceGroup;
			}
			set
			{
				this._VoiceSourceGroup = value;
				this.OnPropertyChanged<ObservableCollection<ChannelItem>>(() => this.VoiceSourceGroup);
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000208 RID: 520 RVA: 0x00014F08 File Offset: 0x00013108
		// (set) Token: 0x06000209 RID: 521 RVA: 0x00004A79 File Offset: 0x00002C79
		public int ThresholdValue
		{
			get
			{
				return this._ThresholdValue;
			}
			set
			{
				this._ThresholdValue = value;
				this.OnPropertyChanged<int>(() => this.ThresholdValue);
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600020A RID: 522 RVA: 0x00014F20 File Offset: 0x00013120
		// (set) Token: 0x0600020B RID: 523 RVA: 0x00004AB9 File Offset: 0x00002CB9
		public int Depth
		{
			get
			{
				return this._Depth;
			}
			set
			{
				this._Depth = value;
				this.OnPropertyChanged<int>(() => this.Depth);
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600020C RID: 524 RVA: 0x00014F38 File Offset: 0x00013138
		// (set) Token: 0x0600020D RID: 525 RVA: 0x00004AF9 File Offset: 0x00002CF9
		public int Attack
		{
			get
			{
				return this._Attack;
			}
			set
			{
				this._Attack = value;
				this.OnPropertyChanged<int>(() => this.Attack);
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600020E RID: 526 RVA: 0x00014F50 File Offset: 0x00013150
		// (set) Token: 0x0600020F RID: 527 RVA: 0x00004B39 File Offset: 0x00002D39
		public int Release
		{
			get
			{
				return this._Release;
			}
			set
			{
				this._Release = value;
				this.OnPropertyChanged<int>(() => this.Release);
			}
		}

		// Token: 0x06000210 RID: 528 RVA: 0x00014F68 File Offset: 0x00013168
		public Ducker()
		{
			for (int i = 0; i < 19; i++)
			{
				this.BackgroundGroup.Add(new ChannelItem
				{
					ChannelName = Const.ChannelNames[i]
				});
			}
			for (int j = 0; j < 19; j++)
			{
				this.VoiceSourceGroup.Add(new ChannelItem
				{
					ChannelName = Const.ChannelNames[j]
				});
			}
		}

		// Token: 0x04000103 RID: 259
		private ObservableCollection<ChannelItem> _BackgroundGroup = new ObservableCollection<ChannelItem>();

		// Token: 0x04000104 RID: 260
		private ObservableCollection<ChannelItem> _VoiceSourceGroup = new ObservableCollection<ChannelItem>();

		// Token: 0x04000105 RID: 261
		private int _ThresholdValue;

		// Token: 0x04000106 RID: 262
		private int _Depth;

		// Token: 0x04000107 RID: 263
		private int _Attack;

		// Token: 0x04000108 RID: 264
		private int _Release;
	}
}
