using System;
using System.Collections.Generic;
using JayLib.WPF.BasicClass;
using T2208.ViewModels;

namespace T2208.Models
{
	// Token: 0x0200009B RID: 155
	public class GeqChannelModel : NotificationObject
	{
		// Token: 0x06000821 RID: 2081 RVA: 0x000248DC File Offset: 0x00022ADC
		public GeqChannelModel()
		{
			for (int i = 0; i < Const.GEQFrequenceStrings.Length; i++)
			{
				this.GeqArray.Add(new GeqFreqModel
				{
					FreqName = Const.GEQFrequenceStrings[i],
					Index = i,
					IndexName = i + 1
				});
			}
		}

		// Token: 0x170002FA RID: 762
		// (get) Token: 0x06000822 RID: 2082 RVA: 0x000098FC File Offset: 0x00007AFC
		// (set) Token: 0x06000823 RID: 2083 RVA: 0x00009904 File Offset: 0x00007B04
		public int Index { get; set; }

		// Token: 0x170002FB RID: 763
		// (get) Token: 0x06000824 RID: 2084 RVA: 0x0000990D File Offset: 0x00007B0D
		// (set) Token: 0x06000825 RID: 2085 RVA: 0x00009915 File Offset: 0x00007B15
		public string ChannelName
		{
			get
			{
				return this._channelName;
			}
			set
			{
				this._channelName = value;
				this.OnPropertyChanged<string>(() => this.ChannelName);
			}
		}

		// Token: 0x170002FC RID: 764
		// (get) Token: 0x06000826 RID: 2086 RVA: 0x00009955 File Offset: 0x00007B55
		// (set) Token: 0x06000827 RID: 2087 RVA: 0x0000995D File Offset: 0x00007B5D
		public bool IsSelected
		{
			get
			{
				return this._isSelected;
			}
			set
			{
				this._isSelected = value;
				this.OnPropertyChanged<bool>(() => this.IsSelected);
			}
		}

		// Token: 0x170002FD RID: 765
		// (get) Token: 0x06000828 RID: 2088 RVA: 0x0000999D File Offset: 0x00007B9D
		// (set) Token: 0x06000829 RID: 2089 RVA: 0x000099A5 File Offset: 0x00007BA5
		public List<GeqFreqModel> GeqArray
		{
			get
			{
				return this._geqArray;
			}
			set
			{
				this._geqArray = value;
				this.OnPropertyChanged<List<GeqFreqModel>>(() => this.GeqArray);
			}
		}

		// Token: 0x170002FE RID: 766
		// (get) Token: 0x0600082A RID: 2090 RVA: 0x000099E5 File Offset: 0x00007BE5
		// (set) Token: 0x0600082B RID: 2091 RVA: 0x000099ED File Offset: 0x00007BED
		public bool Bypass
		{
			get
			{
				return this._bypass;
			}
			set
			{
				this._bypass = value;
				this.OnPropertyChanged<bool>(() => this.Bypass);
			}
		}

		// Token: 0x170002FF RID: 767
		// (get) Token: 0x0600082C RID: 2092 RVA: 0x00009A2D File Offset: 0x00007C2D
		// (set) Token: 0x0600082D RID: 2093 RVA: 0x00009A35 File Offset: 0x00007C35
		public bool SendBypass
		{
			get
			{
				return this._sendBypass;
			}
			set
			{
				this._sendBypass = value;
				this.OnPropertyChanged<bool>(() => this.SendBypass);
			}
		}

		// Token: 0x0400047D RID: 1149
		private bool _bypass;

		// Token: 0x0400047E RID: 1150
		private string _channelName;

		// Token: 0x0400047F RID: 1151
		private List<GeqFreqModel> _geqArray = new List<GeqFreqModel>();

		// Token: 0x04000480 RID: 1152
		private bool _isSelected;

		// Token: 0x04000482 RID: 1154
		private bool _sendBypass;
	}
}
