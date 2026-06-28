using System;
using System.Globalization;
using System.Windows.Data;
using Lib.Controls;

namespace T2208.MyConverters
{
	// Token: 0x0200007C RID: 124
	public class BoolToLEDStatusConverter : IValueConverter
	{
		// Token: 0x06000765 RID: 1893 RVA: 0x0002400C File Offset: 0x0002220C
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return ((bool)value) ? LED_Status.LED_Green : LED_Status.LED_Normal;
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x00008DE7 File Offset: 0x00006FE7
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
