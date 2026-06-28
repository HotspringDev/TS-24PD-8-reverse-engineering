using System;
using System.Globalization;
using System.Windows.Data;

namespace T2208.MyConverters
{
	// Token: 0x02000088 RID: 136
	public sealed class OnlyTrueConverter : IValueConverter
	{
		// Token: 0x06000789 RID: 1929 RVA: 0x00024338 File Offset: 0x00022538
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value != null && (bool)value;
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x0002435C File Offset: 0x0002255C
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return true;
		}
	}
}
