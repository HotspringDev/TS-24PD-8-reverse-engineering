using System;
using System.Globalization;
using System.Windows.Data;
using T2208.ViewModels;

namespace T2208.MyConverters
{
	// Token: 0x02000081 RID: 129
	public sealed class FaderValueToStringConverter : IValueConverter
	{
		// Token: 0x06000774 RID: 1908 RVA: 0x000241B8 File Offset: 0x000223B8
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Const.FaderStrings[(int)value];
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x00008DE7 File Offset: 0x00006FE7
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
