using System;
using System.Globalization;
using System.Windows.Data;

namespace T2208.MyConverters
{
	// Token: 0x02000086 RID: 134
	public class MultiBoolConverter : IMultiValueConverter
	{
		// Token: 0x06000783 RID: 1923 RVA: 0x000242D0 File Offset: 0x000224D0
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			bool flag = true;
			for (int i = 0; i < values.Length; i++)
			{
				flag &= (bool)values[i];
			}
			return flag;
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x00008DE7 File Offset: 0x00006FE7
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
