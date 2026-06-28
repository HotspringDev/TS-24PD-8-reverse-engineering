using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace T2208.MyConverters
{
	// Token: 0x02000082 RID: 130
	public sealed class BoolToVisibilityConverter : IValueConverter
	{
		// Token: 0x06000777 RID: 1911 RVA: 0x000241D8 File Offset: 0x000223D8
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string text;
			bool flag = (text = parameter as string) != null;
			object obj;
			if (flag)
			{
				Visibility visibility = (Visibility)Enum.Parse(typeof(Visibility), text);
				obj = (((bool)value) ? Visibility.Visible : visibility);
			}
			else
			{
				obj = (((bool)value) ? Visibility.Visible : Visibility.Hidden);
			}
			return obj;
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x00008DE7 File Offset: 0x00006FE7
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
