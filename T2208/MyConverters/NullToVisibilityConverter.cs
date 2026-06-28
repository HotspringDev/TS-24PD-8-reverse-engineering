using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace T2208.MyConverters
{
	// Token: 0x02000087 RID: 135
	public class NullToVisibilityConverter : IValueConverter
	{
		// Token: 0x06000786 RID: 1926 RVA: 0x0002430C File Offset: 0x0002250C
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool flag = value == null;
			object obj;
			if (flag)
			{
				obj = Visibility.Collapsed;
			}
			else
			{
				obj = Visibility.Visible;
			}
			return obj;
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x00008DE7 File Offset: 0x00006FE7
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
