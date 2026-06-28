using System;
using System.Collections.ObjectModel;
using JayLib.WPF.BasicClass;

namespace T2208.Models
{
	// Token: 0x02000098 RID: 152
	public class FxItemModel : NotificationObject
	{
		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x0600080B RID: 2059 RVA: 0x0000964F File Offset: 0x0000784F
		// (set) Token: 0x0600080C RID: 2060 RVA: 0x00009657 File Offset: 0x00007857
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

		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x0600080D RID: 2061 RVA: 0x00009697 File Offset: 0x00007897
		// (set) Token: 0x0600080E RID: 2062 RVA: 0x0000969F File Offset: 0x0000789F
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

		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x0600080F RID: 2063 RVA: 0x000096DF File Offset: 0x000078DF
		// (set) Token: 0x06000810 RID: 2064 RVA: 0x000096E7 File Offset: 0x000078E7
		public ObservableCollection<EffectModel> EffectModelsSource
		{
			get
			{
				return this._effect;
			}
			set
			{
				this._effect = value;
				this.OnPropertyChanged<ObservableCollection<EffectModel>>(() => this.EffectModelsSource);
			}
		}

		// Token: 0x04000474 RID: 1140
		private ObservableCollection<EffectModel> _effect;

		// Token: 0x04000475 RID: 1141
		private bool _isSelected;

		// Token: 0x04000476 RID: 1142
		private string _name;
	}
}
