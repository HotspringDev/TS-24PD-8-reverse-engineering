using System;
using JayLib.WPF.BasicClass;

namespace T2208.Models
{
	// Token: 0x02000093 RID: 147
	public class DcaItemModel : NotificationObject
	{
		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x060007D5 RID: 2005 RVA: 0x00009295 File Offset: 0x00007495
		// (set) Token: 0x060007D6 RID: 2006 RVA: 0x0000929D File Offset: 0x0000749D
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
				this.OnPropertyChanged<string>(() => this.Name);
			}
		}

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x060007D7 RID: 2007 RVA: 0x000092DD File Offset: 0x000074DD
		// (set) Token: 0x060007D8 RID: 2008 RVA: 0x000092E5 File Offset: 0x000074E5
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

		// Token: 0x04000457 RID: 1111
		private bool _isSelected;

		// Token: 0x04000458 RID: 1112
		private string _name;
	}
}
