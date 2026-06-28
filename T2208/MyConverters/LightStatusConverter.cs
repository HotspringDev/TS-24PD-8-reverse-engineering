using System;
using System.Globalization;
using System.Windows.Data;
using JayCustomControlLib;

namespace T2208.MyConverters
{
	// Token: 0x02000085 RID: 133
	public sealed class LightStatusConverter : IValueConverter
	{
		// Token: 0x06000780 RID: 1920 RVA: 0x0002428C File Offset: 0x0002248C
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			int num = (int)value;
			bool flag = num == 0;
			object obj;
			if (flag)
			{
				obj = LightStatus.LED_Normal;
			}
			else
			{
				bool flag2 = num == 1;
				if (flag2)
				{
					obj = LightStatus.LED_Green;
				}
				else
				{
					obj = LightStatus.LED_Red;
				}
			}
			return obj;
		}

		// Token: 0x06000781 RID: 1921 RVA: 0x00008DE7 File Offset: 0x00006FE7
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
