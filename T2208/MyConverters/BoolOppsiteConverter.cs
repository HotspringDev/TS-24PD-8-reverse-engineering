using System;
using System.Globalization;
using System.Windows.Data;

namespace T2208.MyConverters
{
	// Token: 0x02000079 RID: 121
	public sealed class BoolOppsiteConverter : IValueConverter
	{
		// Token: 0x0600075C RID: 1884 RVA: 0x00023EC8 File Offset: 0x000220C8
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return !(bool)value;
		}

		// Token: 0x0600075D RID: 1885 RVA: 0x00023EC8 File Offset: 0x000220C8
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return !(bool)value;
		}
	}
}
