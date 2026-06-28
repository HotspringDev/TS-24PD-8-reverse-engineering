using System;
using System.Globalization;
using System.Windows.Data;

namespace T2208.MyConverters
{
	// Token: 0x02000080 RID: 128
	public class DelayToStringConverter : IValueConverter
	{
		// Token: 0x06000771 RID: 1905 RVA: 0x00024158 File Offset: 0x00022358
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			int num = Math.Min((int)value, 1443);
			double num2 = 0.208333333 * (double)num;
			num2 = num2 * 343.5 / 1000.0;
			num2 = Math.Round(num2, 2);
			return Math.Round(num2, 2).ToString();
		}

		// Token: 0x06000772 RID: 1906 RVA: 0x00008DE7 File Offset: 0x00006FE7
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
