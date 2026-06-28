using System;
using JayLib.WPF.BasicClass;

namespace T2208.Models
{
	// Token: 0x0200008E RID: 142
	public class ButtonItemModel : NotificationObject
	{
		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x060007A8 RID: 1960 RVA: 0x00008EEE File Offset: 0x000070EE
		// (set) Token: 0x060007A9 RID: 1961 RVA: 0x00008EF6 File Offset: 0x000070F6
		public string Content { get; set; }

		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x060007AA RID: 1962 RVA: 0x00008EFF File Offset: 0x000070FF
		// (set) Token: 0x060007AB RID: 1963 RVA: 0x00008F07 File Offset: 0x00007107
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

		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x060007AC RID: 1964 RVA: 0x00008F47 File Offset: 0x00007147
		// (set) Token: 0x060007AD RID: 1965 RVA: 0x00008F4F File Offset: 0x0000714F
		public object Command { get; set; }

		// Token: 0x04000442 RID: 1090
		private bool _isSelected;
	}
}
