using System;
using System.Globalization;
using System.Windows.Data;

namespace T2208.MyConverters
{
	// Token: 0x02000083 RID: 131
	public class GEQConverter : IMultiValueConverter
	{
		// Token: 0x0600077A RID: 1914 RVA: 0x00024238 File Offset: 0x00022438
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			bool flag = (bool)values[2];
			object obj;
			if (flag)
			{
				obj = values[1];
			}
			else
			{
				obj = values[0];
			}
			return obj;
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x00008DE7 File Offset: 0x00006FE7
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
