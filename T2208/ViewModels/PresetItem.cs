using System;
using JayLib.JayString;
using JayLib.WPF.BasicClass;

namespace T2208.ViewModels
{
	// Token: 0x0200003F RID: 63
	public class PresetItem : NotificationObject
	{
		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000331 RID: 817 RVA: 0x00019C7C File Offset: 0x00017E7C
		// (set) Token: 0x06000332 RID: 818 RVA: 0x00005A93 File Offset: 0x00003C93
		public string PresetName
		{
			get
			{
				return this._PresetName;
			}
			set
			{
				this._PresetName = value;
				this.OnPropertyChanged<string>(() => this.PresetName);
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000333 RID: 819 RVA: 0x00019C94 File Offset: 0x00017E94
		// (set) Token: 0x06000334 RID: 820 RVA: 0x00005AD3 File Offset: 0x00003CD3
		public int Index
		{
			get
			{
				return this._Index;
			}
			set
			{
				this._Index = value;
				this.OnPropertyChanged<int>(() => this.Index);
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000335 RID: 821 RVA: 0x00019CAC File Offset: 0x00017EAC
		// (set) Token: 0x06000336 RID: 822 RVA: 0x00005B13 File Offset: 0x00003D13
		public string Group
		{
			get
			{
				return this._Group;
			}
			set
			{
				this._Group = value;
				this.OnPropertyChanged<string>(() => this.Group);
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x06000337 RID: 823 RVA: 0x00019CC4 File Offset: 0x00017EC4
		// (set) Token: 0x06000338 RID: 824 RVA: 0x00005B53 File Offset: 0x00003D53
		public string IndexString
		{
			get
			{
				return this._IndexString;
			}
			set
			{
				this._IndexString = value;
				this.OnPropertyChanged<string>(() => this.IndexString);
			}
		}

		// Token: 0x06000339 RID: 825 RVA: 0x00019CDC File Offset: 0x00017EDC
		public PresetItem(string name, string group, int index)
		{
			this.PresetName = name;
			this.Group = group;
			this.Index = index;
			this.IndexString = (index + 1).ToString().RightJustified(2, '0');
		}

		// Token: 0x04000230 RID: 560
		private string _PresetName;

		// Token: 0x04000231 RID: 561
		private int _Index;

		// Token: 0x04000232 RID: 562
		private string _Group;

		// Token: 0x04000233 RID: 563
		private string _IndexString;
	}
}
