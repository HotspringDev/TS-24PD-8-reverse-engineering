using System;
using System.Windows.Input;
using JayLib.WPF.BasicClass;

namespace T2208.ViewModels
{
	// Token: 0x02000032 RID: 50
	public class ChannelItem : NotificationObject
	{
		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000211 RID: 529 RVA: 0x00014FF8 File Offset: 0x000131F8
		// (set) Token: 0x06000212 RID: 530 RVA: 0x00004B79 File Offset: 0x00002D79
		public string ChannelName
		{
			get
			{
				return this._ChannelName;
			}
			set
			{
				this._ChannelName = value;
				this.OnPropertyChanged<string>(() => this.ChannelName);
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000213 RID: 531 RVA: 0x00015010 File Offset: 0x00013210
		// (set) Token: 0x06000214 RID: 532 RVA: 0x00004BB9 File Offset: 0x00002DB9
		public bool IsEnable
		{
			get
			{
				return this._IsEnable;
			}
			set
			{
				this._IsEnable = value;
				this.OnPropertyChanged<bool>(() => this.IsEnable);
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000215 RID: 533 RVA: 0x00015028 File Offset: 0x00013228
		// (set) Token: 0x06000216 RID: 534 RVA: 0x00004BF9 File Offset: 0x00002DF9
		public ICommand Command
		{
			get
			{
				return this._Command;
			}
			set
			{
				this._Command = value;
				this.OnPropertyChanged<ICommand>(() => this.Command);
			}
		}

		// Token: 0x04000109 RID: 265
		private string _ChannelName;

		// Token: 0x0400010A RID: 266
		private bool _IsEnable;

		// Token: 0x0400010B RID: 267
		private ICommand _Command;
	}
}
