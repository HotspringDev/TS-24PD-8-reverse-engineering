using System;
using System.Windows.Input;
using T2208.ViewModels.Base;

namespace T2208.Models
{
	// Token: 0x02000096 RID: 150
	public class DigitalModel : BaseViewModel, IItemModel
	{
		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x060007ED RID: 2029 RVA: 0x0000942F File Offset: 0x0000762F
		// (set) Token: 0x060007EE RID: 2030 RVA: 0x00009437 File Offset: 0x00007637
		public int Value
		{
			get
			{
				return this._value;
			}
			set
			{
				base.SetProperty<int>(ref this._value, value, "Value");
				this.SendValue = (byte)value;
			}
		}

		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x060007EF RID: 2031 RVA: 0x00009456 File Offset: 0x00007656
		// (set) Token: 0x060007F0 RID: 2032 RVA: 0x0000945E File Offset: 0x0000765E
		public ICommand CommonCommand { get; set; }

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x060007F1 RID: 2033 RVA: 0x00009467 File Offset: 0x00007667
		// (set) Token: 0x060007F2 RID: 2034 RVA: 0x0000946F File Offset: 0x0000766F
		public byte SendValue
		{
			get
			{
				return this._sendValue;
			}
			set
			{
				base.SetProperty<byte>(ref this._sendValue, value, "SendValue");
			}
		}

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x060007F3 RID: 2035 RVA: 0x00009484 File Offset: 0x00007684
		// (set) Token: 0x060007F4 RID: 2036 RVA: 0x0000948C File Offset: 0x0000768C
		public bool IsOpened
		{
			get
			{
				return this._isOpened;
			}
			set
			{
				base.SetProperty<bool>(ref this._isOpened, value, "IsOpened");
			}
		}

		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x060007F5 RID: 2037 RVA: 0x000094A1 File Offset: 0x000076A1
		// (set) Token: 0x060007F6 RID: 2038 RVA: 0x000094A9 File Offset: 0x000076A9
		public bool TempInputIsFrontSet { get; set; }

		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x060007F7 RID: 2039 RVA: 0x000094B2 File Offset: 0x000076B2
		// (set) Token: 0x060007F8 RID: 2040 RVA: 0x000094BA File Offset: 0x000076BA
		public int Index
		{
			get
			{
				return this._index;
			}
			set
			{
				base.SetProperty<int>(ref this._index, value, "Index");
			}
		}

		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x060007F9 RID: 2041 RVA: 0x000094CF File Offset: 0x000076CF
		// (set) Token: 0x060007FA RID: 2042 RVA: 0x000094D7 File Offset: 0x000076D7
		public string Name
		{
			get
			{
				return this._channelName;
			}
			set
			{
				base.SetProperty<string>(ref this._channelName, value, "Name");
			}
		}

		// Token: 0x04000466 RID: 1126
		private string _channelName;

		// Token: 0x04000467 RID: 1127
		private bool _isOpened;

		// Token: 0x04000468 RID: 1128
		private byte _sendValue;

		// Token: 0x04000469 RID: 1129
		private int _value;

		// Token: 0x0400046C RID: 1132
		private int _index;
	}
}
