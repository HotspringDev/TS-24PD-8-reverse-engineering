using System;
using System.Collections.ObjectModel;
using JayLib.WPF.BasicClass;

namespace T2208.ViewModels
{
	// Token: 0x02000040 RID: 64
	public class PresetGroup : NotificationObject
	{
		// Token: 0x1700010C RID: 268
		// (get) Token: 0x0600033A RID: 826 RVA: 0x00005B93 File Offset: 0x00003D93
		// (set) Token: 0x0600033B RID: 827 RVA: 0x00005B9B File Offset: 0x00003D9B
		public ObservableCollection<PresetItem> PresetItems { get; set; }

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x0600033C RID: 828 RVA: 0x00005BA4 File Offset: 0x00003DA4
		// (set) Token: 0x0600033D RID: 829 RVA: 0x00005BAC File Offset: 0x00003DAC
		public string GroupName { get; set; }

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x0600033E RID: 830 RVA: 0x00019D24 File Offset: 0x00017F24
		// (set) Token: 0x0600033F RID: 831 RVA: 0x00005BB5 File Offset: 0x00003DB5
		public string SelectChannel
		{
			get
			{
				return this._SelectChannel;
			}
			set
			{
				this._SelectChannel = value;
				this.OnPropertyChanged<string>(() => this.SelectChannel);
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000340 RID: 832 RVA: 0x00019D3C File Offset: 0x00017F3C
		// (set) Token: 0x06000341 RID: 833 RVA: 0x00005BF5 File Offset: 0x00003DF5
		public int SelectedPresetIndex
		{
			get
			{
				return this._SelectedPresetIndex;
			}
			set
			{
				this._SelectedPresetIndex = value;
				this.OnPropertyChanged<int>(() => this.SelectedPresetIndex);
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000342 RID: 834 RVA: 0x00019D54 File Offset: 0x00017F54
		// (set) Token: 0x06000343 RID: 835 RVA: 0x00005C35 File Offset: 0x00003E35
		public string SelectedPreset
		{
			get
			{
				return this._SelectedPreset;
			}
			set
			{
				this._SelectedPreset = value;
				this.OnPropertyChanged<string>(() => this.SelectedPreset);
			}
		}

		// Token: 0x04000236 RID: 566
		private string _SelectChannel;

		// Token: 0x04000237 RID: 567
		private int _SelectedPresetIndex;

		// Token: 0x04000238 RID: 568
		private string _SelectedPreset;
	}
}
