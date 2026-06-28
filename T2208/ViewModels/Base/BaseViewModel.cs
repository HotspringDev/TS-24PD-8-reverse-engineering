using System;
using System.Runtime.CompilerServices;
using JayLib.WPF.BasicClass;

namespace T2208.ViewModels.Base
{
	// Token: 0x0200004B RID: 75
	public class BaseViewModel : NotificationObject
	{
		// Token: 0x060003D2 RID: 978 RVA: 0x0001ADC4 File Offset: 0x00018FC4
		protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
		{
			bool flag = object.Equals(field, value);
			bool flag2;
			if (flag)
			{
				flag2 = false;
			}
			else
			{
				field = value;
				this.OnPropertyChanged(propertyName);
				flag2 = true;
			}
			return flag2;
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x0001AE04 File Offset: 0x00019004
		protected bool SetPropertyWithoutCheckSame<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
		{
			field = value;
			this.OnPropertyChanged(propertyName);
			return true;
		}
	}
}
