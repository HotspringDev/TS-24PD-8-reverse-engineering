using System;
using System.Collections.ObjectModel;
using T2208.ViewModels.Base;

namespace T2208.Models
{
	// Token: 0x02000092 RID: 146
	public class DcaGroupItemModel : BaseViewModel, IChannelGroup
	{
		// Token: 0x170002CF RID: 719
		// (get) Token: 0x060007C0 RID: 1984 RVA: 0x00009030 File Offset: 0x00007230
		// (set) Token: 0x060007C1 RID: 1985 RVA: 0x00009038 File Offset: 0x00007238
		public int Index
		{
			get
			{
				return this._index;
			}
			set
			{
				this._index = value;
				this.OnPropertyChanged<int>(() => this.Index);
			}
		}

		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x060007C2 RID: 1986 RVA: 0x00009078 File Offset: 0x00007278
		// (set) Token: 0x060007C3 RID: 1987 RVA: 0x00009080 File Offset: 0x00007280
		public int Gain
		{
			get
			{
				return this._gain;
			}
			set
			{
				base.SetProperty<int>(ref this._gain, value, "Gain");
				this.SendValue = value;
			}
		}

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x060007C4 RID: 1988 RVA: 0x0000909E File Offset: 0x0000729E
		// (set) Token: 0x060007C5 RID: 1989 RVA: 0x000090A6 File Offset: 0x000072A6
		public int SendValue
		{
			get
			{
				return this._sendValue;
			}
			set
			{
				base.SetProperty<int>(ref this._sendValue, value, "SendValue");
			}
		}

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x060007C6 RID: 1990 RVA: 0x000090BB File Offset: 0x000072BB
		// (set) Token: 0x060007C7 RID: 1991 RVA: 0x000090C3 File Offset: 0x000072C3
		public ObservableCollection<DcaItemModel> GroupCollection
		{
			get
			{
				return this._groupCollection;
			}
			set
			{
				this._groupCollection = value;
				this.OnPropertyChanged<ObservableCollection<DcaItemModel>>(() => this.GroupCollection);
			}
		}

		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x060007C8 RID: 1992 RVA: 0x00009103 File Offset: 0x00007303
		// (set) Token: 0x060007C9 RID: 1993 RVA: 0x0000910B File Offset: 0x0000730B
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

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x060007CA RID: 1994 RVA: 0x0000914B File Offset: 0x0000734B
		// (set) Token: 0x060007CB RID: 1995 RVA: 0x00009153 File Offset: 0x00007353
		public bool IsMute
		{
			get
			{
				return this._isMute;
			}
			set
			{
				this._isMute = value;
				this.OnPropertyChanged<bool>(() => this.IsMute);
			}
		}

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x060007CC RID: 1996 RVA: 0x00009193 File Offset: 0x00007393
		// (set) Token: 0x060007CD RID: 1997 RVA: 0x0000919B File Offset: 0x0000739B
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

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x060007CE RID: 1998 RVA: 0x000091DB File Offset: 0x000073DB
		// (set) Token: 0x060007CF RID: 1999 RVA: 0x000091E3 File Offset: 0x000073E3
		public bool IsSolo
		{
			get
			{
				return this._isSolo;
			}
			set
			{
				this._isSolo = value;
				this.OnPropertyChanged<bool>(() => this.IsSolo);
			}
		}

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x060007D0 RID: 2000 RVA: 0x00009223 File Offset: 0x00007423
		// (set) Token: 0x060007D1 RID: 2001 RVA: 0x0000922B File Offset: 0x0000742B
		public int MeterValue
		{
			get
			{
				return this._meterValue;
			}
			set
			{
				this._meterValue = value;
				this.OnPropertyChanged<int>(() => this.MeterValue);
			}
		}

		// Token: 0x060007D2 RID: 2002 RVA: 0x0000926B File Offset: 0x0000746B
		public virtual void Add(DcaItemModel newItem)
		{
			ObservableCollection<DcaItemModel> groupCollection = this.GroupCollection;
			if (groupCollection != null)
			{
				groupCollection.Add(newItem);
			}
		}

		// Token: 0x060007D3 RID: 2003 RVA: 0x00024788 File Offset: 0x00022988
		public DcaGroupItemModel Clone()
		{
			DcaGroupItemModel dcaGroupItemModel = new DcaGroupItemModel
			{
				_gain = this._gain,
				_isMute = this._isMute,
				_isSolo = this._isSolo,
				_meterValue = this._meterValue,
				IsMute = this.IsMute,
				IsSolo = this.IsSolo,
				Gain = this.Gain,
				MeterValue = this.MeterValue,
				GroupName = this.GroupName
			};
			dcaGroupItemModel.GroupCollection.Clear();
			foreach (DcaItemModel dcaItemModel in this.GroupCollection)
			{
				dcaGroupItemModel.GroupCollection.Add(new DcaItemModel
				{
					IsSelected = dcaItemModel.IsSelected,
					Name = dcaItemModel.Name
				});
			}
			return dcaGroupItemModel;
		}

		// Token: 0x0400044E RID: 1102
		private int _gain;

		// Token: 0x0400044F RID: 1103
		private ObservableCollection<DcaItemModel> _groupCollection = new ObservableCollection<DcaItemModel>();

		// Token: 0x04000450 RID: 1104
		private string _groupName;

		// Token: 0x04000451 RID: 1105
		private bool _isMute;

		// Token: 0x04000452 RID: 1106
		private bool _isSelected;

		// Token: 0x04000453 RID: 1107
		private int _index;

		// Token: 0x04000454 RID: 1108
		private bool _isSolo;

		// Token: 0x04000455 RID: 1109
		private int _meterValue;

		// Token: 0x04000456 RID: 1110
		private int _sendValue;
	}
}
