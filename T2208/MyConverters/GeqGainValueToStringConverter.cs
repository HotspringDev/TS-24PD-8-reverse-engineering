using System;
using System.Globalization;
using System.Windows.Data;

namespace T2208.MyConverters
{
	// Token: 0x02000084 RID: 132
	public sealed class GeqGainValueToStringConverter : IValueConverter
	{
		// Token: 0x0600077D RID: 1917 RVA: 0x00024264 File Offset: 0x00022464
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			int num = (int)value;
			return (num - 24).ToString();
		}

		// Token: 0x0600077E RID: 1918 RVA: 0x00008DE7 File Offset: 0x00006FE7
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
