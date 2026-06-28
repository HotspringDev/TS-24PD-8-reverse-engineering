using System;
using JayLib.WPF.BasicClass;

namespace T2208.MyInformations
{
	// Token: 0x0200006B RID: 107
	public class DeviceInfo : NotificationObject
	{
		// Token: 0x17000251 RID: 593
		// (get) Token: 0x0600066C RID: 1644 RVA: 0x000086CA File Offset: 0x000068CA
		// (set) Token: 0x0600066D RID: 1645 RVA: 0x000086D2 File Offset: 0x000068D2
		public RelayCommand<DeviceInfo> ConnectCommand { get; set; }

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x0600066E RID: 1646 RVA: 0x000209BC File Offset: 0x0001EBBC
		// (set) Token: 0x0600066F RID: 1647 RVA: 0x000086DB File Offset: 0x000068DB
		public string DeviceName
		{
			get
			{
				return this._deviceName;
			}
			set
			{
				this._deviceName = value;
				this.OnPropertyChanged<string>(() => this.DeviceName);
			}
		}

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x06000670 RID: 1648 RVA: 0x0000871B File Offset: 0x0000691B
		// (set) Token: 0x06000671 RID: 1649 RVA: 0x00008723 File Offset: 0x00006923
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

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x06000672 RID: 1650 RVA: 0x000209D4 File Offset: 0x0001EBD4
		// (set) Token: 0x06000673 RID: 1651 RVA: 0x00008739 File Offset: 0x00006939
		public string DeviceAddress
		{
			get
			{
				return this._deviceAddress;
			}
			set
			{
				this._deviceAddress = value;
				this.OnPropertyChanged<string>(() => this.DeviceName);
			}
		}

		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06000674 RID: 1652 RVA: 0x000209EC File Offset: 0x0001EBEC
		// (set) Token: 0x06000675 RID: 1653 RVA: 0x00008779 File Offset: 0x00006979
		public string DeviceMac
		{
			get
			{
				return this._deviceMac;
			}
			set
			{
				this._deviceMac = value;
				this.OnPropertyChanged<string>(() => this.DeviceName);
			}
		}

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06000676 RID: 1654 RVA: 0x00020A04 File Offset: 0x0001EC04
		// (set) Token: 0x06000677 RID: 1655 RVA: 0x000087B9 File Offset: 0x000069B9
		public string DeviceID
		{
			get
			{
				return this._deviceID;
			}
			set
			{
				this._deviceID = value;
				this.OnPropertyChanged<string>(() => this.DeviceName);
			}
		}

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x06000678 RID: 1656 RVA: 0x00020A1C File Offset: 0x0001EC1C
		// (set) Token: 0x06000679 RID: 1657 RVA: 0x000087F9 File Offset: 0x000069F9
		public bool IsSelected
		{
			get
			{
				return this._isSelected;
			}
			set
			{
				this._isSelected = value;
				this.OnPropertyChanged<string>(() => this.DeviceName);
			}
		}

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x0600067A RID: 1658 RVA: 0x00020A34 File Offset: 0x0001EC34
		// (set) Token: 0x0600067B RID: 1659 RVA: 0x00008839 File Offset: 0x00006A39
		public int DeviceIndex
		{
			get
			{
				return this._deviceIndex;
			}
			set
			{
				this._deviceIndex = value;
				this.OnPropertyChanged<string>(() => this.DeviceName);
			}
		}

		// Token: 0x04000396 RID: 918
		private ConnectTypes _connectType = ConnectTypes.Warn;

		// Token: 0x04000397 RID: 919
		private string _deviceAddress;

		// Token: 0x04000398 RID: 920
		private string _deviceMac;

		// Token: 0x04000399 RID: 921
		private string _deviceName;

		// Token: 0x0400039A RID: 922
		public int _deviceIndex;

		// Token: 0x0400039B RID: 923
		public string _deviceID;

		// Token: 0x0400039C RID: 924
		public bool _isSelected;
	}
}
