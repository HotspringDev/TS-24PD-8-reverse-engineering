using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace T2208.MyConverters
{
	// Token: 0x0200007A RID: 122
	public class BoolOppsiteToVisibilityConverter : IValueConverter
	{
		// Token: 0x0600075F RID: 1887 RVA: 0x00023EE8 File Offset: 0x000220E8
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string text;
			bool flag = (text = parameter as string) == null;
			object obj;
			if (flag)
			{
				obj = ((value != null && (bool)value) ? Visibility.Hidden : Visibility.Visible);
			}
			else
			{
				Visibility visibility = (Visibility)Enum.Parse(typeof(Visibility), text);
				obj = ((value != null && (bool)value) ? visibility : Visibility.Visible);
			}
			return obj;
		}

		// Token: 0x06000760 RID: 1888 RVA: 0x00008DE7 File Offset: 0x00006FE7
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
