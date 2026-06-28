using System;
using System.Globalization;
using System.Windows.Data;
using JayLib.JayString;

namespace T2208.MyConverters
{
	// Token: 0x0200008A RID: 138
	public sealed class StringSuffixConverter : IValueConverter
	{
		// Token: 0x0600078F RID: 1935 RVA: 0x00024484 File Offset: 0x00022684
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value.ToString().Append(parameter.ToString());
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x00008DE7 File Offset: 0x00006FE7
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
