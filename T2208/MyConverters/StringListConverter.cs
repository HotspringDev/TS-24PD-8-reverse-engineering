using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;

namespace T2208.MyConverters
{
	// Token: 0x02000089 RID: 137
	public sealed class StringListConverter : IValueConverter
	{
		// Token: 0x0600078C RID: 1932 RVA: 0x00024374 File Offset: 0x00022574
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			IList<string> list;
			bool flag = (list = parameter as IList<string>) != null;
			if (flag)
			{
				bool flag2 = value.GetType().Equals(typeof(int)) && (int)value >= 0 && (int)value < list.Count;
				if (flag2)
				{
					return list[(int)value];
				}
				bool flag3 = value.GetType().Equals(typeof(byte)) && (byte)value >= 0 && (int)((byte)value) < list.Count;
				if (flag3)
				{
					return list[(int)((byte)value)];
				}
				bool flag4 = value.GetType().Equals(typeof(double));
				if (flag4)
				{
					int num = (int)((double)value);
					bool flag5 = num >= 0 && num < list.Count;
					if (flag5)
					{
						return list[num];
					}
				}
			}
			Debug.Write(value.GetType());
			return "";
		}

		// Token: 0x0600078D RID: 1933 RVA: 0x00008DE7 File Offset: 0x00006FE7
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
