using System;
using T2208.ViewModels.Base;

namespace T2208.Models
{
	// Token: 0x0200009F RID: 159
	public class RoutingPan : BaseViewModel
	{
		// Token: 0x17000306 RID: 774
		// (get) Token: 0x0600083F RID: 2111 RVA: 0x00009B58 File Offset: 0x00007D58
		// (set) Token: 0x06000840 RID: 2112 RVA: 0x00009B60 File Offset: 0x00007D60
		public int Value
		{
			get
			{
				return this._value;
			}
			set
			{
				base.SetProperty<int>(ref this._value, value, "Value");
			}
		}

		// Token: 0x0400048A RID: 1162
		private int _value;
	}
}
