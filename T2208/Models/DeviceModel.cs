using System;
using System.Windows.Media;
using JayLib.WPF.BasicClass;
using T2208.ViewModels.Base;

namespace T2208.Models
{
	// Token: 0x02000095 RID: 149
	public class DeviceModel : BaseViewModel
	{
		// Token: 0x170002DA RID: 730
		// (get) Token: 0x060007DA RID: 2010 RVA: 0x00009325 File Offset: 0x00007525
		// (set) Token: 0x060007DB RID: 2011 RVA: 0x0000932D File Offset: 0x0000752D
		public RelayCommand<DeviceModel> ConnectCommand { get; set; }

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x060007DC RID: 2012 RVA: 0x00009336 File Offset: 0x00007536
		// (set) Token: 0x060007DD RID: 2013 RVA: 0x0000933E File Offset: 0x0000753E
		public string DeviceName
		{
			get
			{
				return this._deviceName;
			}
			set
			{
				base.SetProperty<string>(ref this._deviceName, value, "DeviceName");
			}
		}

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x060007DE RID: 2014 RVA: 0x00009353 File Offset: 0x00007553
		// (set) Token: 0x060007DF RID: 2015 RVA: 0x0000935B File Offset: 0x0000755B
		public ConnectTypes ConnectType
		{
			get
			{
				return this._connectType;
			}
			set
			{
				this._connectType = value;
				this.OnPropertyChanged("ConnectType");
			}
		}

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x060007E0 RID: 2016 RVA: 0x00009371 File Offset: 0x00007571
		// (set) Token: 0x060007E1 RID: 2017 RVA: 0x00009379 File Offset: 0x00007579
		public string DeviceAddress
		{
			get
			{
				return this._deviceAddress;
			}
			set
			{
				base.SetProperty<string>(ref this._deviceAddress, value, "DeviceAddress");
			}
		}

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x060007E2 RID: 2018 RVA: 0x0000938E File Offset: 0x0000758E
		// (set) Token: 0x060007E3 RID: 2019 RVA: 0x00009396 File Offset: 0x00007596
		public Brush DeviceBrush
		{
			get
			{
				return this._brushes;
			}
			set
			{
				base.SetProperty<Brush>(ref this._brushes, value, "DeviceBrush");
			}
		}

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x060007E4 RID: 2020 RVA: 0x000093AB File Offset: 0x000075AB
		// (set) Token: 0x060007E5 RID: 2021 RVA: 0x000093B3 File Offset: 0x000075B3
		public string DeviceMac
		{
			get
			{
				return this._deviceMac;
			}
			set
			{
				base.SetProperty<string>(ref this._deviceMac, value, "DeviceMac");
			}
		}

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x060007E6 RID: 2022 RVA: 0x000093C8 File Offset: 0x000075C8
		// (set) Token: 0x060007E7 RID: 2023 RVA: 0x000093D0 File Offset: 0x000075D0
		public string DeviceID
		{
			get
			{
				return this._deviceID;
			}
			set
			{
				base.SetProperty<string>(ref this._deviceID, value, "DeviceID");
			}
		}

		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x060007E8 RID: 2024 RVA: 0x000093E5 File Offset: 0x000075E5
		// (set) Token: 0x060007E9 RID: 2025 RVA: 0x000093ED File Offset: 0x000075ED
		public bool IsSelected
		{
			get
			{
				return this._isSelected;
			}
			set
			{
				base.SetProperty<bool>(ref this._isSelected, value, "IsSelected");
			}
		}

		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x060007EA RID: 2026 RVA: 0x00009402 File Offset: 0x00007602
		// (set) Token: 0x060007EB RID: 2027 RVA: 0x0000940A File Offset: 0x0000760A
		public int DeviceIndex
		{
			get
			{
				return this._deviceIndex;
			}
			set
			{
				base.SetProperty<int>(ref this._deviceIndex, value, "DeviceIndex");
			}
		}

		// Token: 0x0400045D RID: 1117
		private Brush _brushes;

		// Token: 0x0400045E RID: 1118
		private ConnectTypes _connectType = ConnectTypes.Warn;

		// Token: 0x0400045F RID: 1119
		private string _deviceAddress;

		// Token: 0x04000460 RID: 1120
		private string _deviceMac;

		// Token: 0x04000461 RID: 1121
		private string _deviceName;

		// Token: 0x04000462 RID: 1122
		public int _deviceIndex;

		// Token: 0x04000463 RID: 1123
		public string _deviceID;

		// Token: 0x04000464 RID: 1124
		public bool _isSelected;
	}
}
