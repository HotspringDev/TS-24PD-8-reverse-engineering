using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace T2208.MyConverters
{
	// Token: 0x0200007F RID: 127
	public class ByteToBrushConverter : IValueConverter
	{
		// Token: 0x0600076E RID: 1902 RVA: 0x0002411C File Offset: 0x0002231C
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			byte b = (byte)value;
			object obj;
			if (b != 1)
			{
				if (b != 2)
				{
					obj = Brushes.Gray;
				}
				else
				{
					obj = Brushes.LimeGreen;
				}
			}
			else
			{
				obj = Brushes.Red;
			}
			return obj;
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x00008DE7 File Offset: 0x00006FE7
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
