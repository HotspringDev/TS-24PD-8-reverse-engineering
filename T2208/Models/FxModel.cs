using System;
using System.Collections.ObjectModel;
using JayLib.WPF.BasicClass;

namespace T2208.Models
{
	// Token: 0x02000099 RID: 153
	public class FxModel : NotificationObject
	{
		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x06000812 RID: 2066 RVA: 0x00009727 File Offset: 0x00007927
		// (set) Token: 0x06000813 RID: 2067 RVA: 0x0000972F File Offset: 0x0000792F
		public string GroupName
		{
			get
			{
				return this._groupName;
			}
			set
			{
				this._groupName = value;
				this.OnPropertyChanged<string>(() => this.GroupName);
			}
		}

		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x06000814 RID: 2068 RVA: 0x0000976F File Offset: 0x0000796F
		// (set) Token: 0x06000815 RID: 2069 RVA: 0x00009777 File Offset: 0x00007977
		public bool IsSelectedFxModel
		{
			get
			{
				return this._isSelectedFxModel;
			}
			set
			{
				this._isSelectedFxModel = value;
				this.OnPropertyChanged<bool>(() => this.IsSelectedFxModel);
			}
		}

		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x06000816 RID: 2070 RVA: 0x000097B7 File Offset: 0x000079B7
		// (set) Token: 0x06000817 RID: 2071 RVA: 0x000097BF File Offset: 0x000079BF
		public ObservableCollection<FxItemModel> FxItemSource
		{
			get
			{
				return this._groupCollection;
			}
			set
			{
				this._groupCollection = value;
				this.OnPropertyChanged<ObservableCollection<FxItemModel>>(() => this.FxItemSource);
			}
		}

		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x06000818 RID: 2072 RVA: 0x000097FF File Offset: 0x000079FF
		// (set) Token: 0x06000819 RID: 2073 RVA: 0x00009807 File Offset: 0x00007A07
		public FxItemModel SelectedItem
		{
			get
			{
				return this._selectedItem;
			}
			set
			{
				this._selectedItem = value;
				this.OnPropertyChanged<FxItemModel>(() => this.SelectedItem);
			}
		}

		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x0600081A RID: 2074 RVA: 0x00009847 File Offset: 0x00007A47
		// (set) Token: 0x0600081B RID: 2075 RVA: 0x0000984F File Offset: 0x00007A4F
		public int SelectedIndex
		{
			get
			{
				return this._selectedIndex;
			}
			set
			{
				this._selectedIndex = value;
				this.OnPropertyChanged<int>(() => this._selectedIndex);
			}
		}

		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x0600081C RID: 2076 RVA: 0x0000988A File Offset: 0x00007A8A
		// (set) Token: 0x0600081D RID: 2077 RVA: 0x00009892 File Offset: 0x00007A92
		public int CurrentIndex
		{
			get
			{
				return this._currentIndex;
			}
			set
			{
				this._currentIndex = value;
				this.OnPropertyChanged<int>(() => this.CurrentIndex);
			}
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x000098D2 File Offset: 0x00007AD2
		public virtual void Add(FxItemModel newItem)
		{
			ObservableCollection<FxItemModel> fxItemSource = this.FxItemSource;
			if (fxItemSource != null)
			{
				fxItemSource.Add(newItem);
			}
		}

		// Token: 0x04000477 RID: 1143
		private int _currentIndex;

		// Token: 0x04000478 RID: 1144
		private ObservableCollection<FxItemModel> _groupCollection = new ObservableCollection<FxItemModel>();

		// Token: 0x04000479 RID: 1145
		private string _groupName;

		// Token: 0x0400047A RID: 1146
		private bool _isSelectedFxModel;

		// Token: 0x0400047B RID: 1147
		private int _selectedIndex;

		// Token: 0x0400047C RID: 1148
		private FxItemModel _selectedItem;
	}
}
