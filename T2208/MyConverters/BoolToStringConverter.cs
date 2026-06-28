using System;
using System.Globalization;
using System.Windows.Data;

namespace T2208.MyConverters
{
	// Token: 0x0200007E RID: 126
	public class BoolToStringConverter : IValueConverter
	{
		// Token: 0x0600076B RID: 1899 RVA: 0x000240A8 File Offset: 0x000222A8
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string text;
			bool flag = (text = parameter as string) != null;
			if (flag)
			{
				string[] array = text.Split(new char[] { '|' });
				bool flag2;
				bool flag3;
				if (array.Length == 2)
				{
					if (value is bool)
					{
						flag2 = (bool)value;
						flag3 = true;
					}
					else
					{
						flag3 = false;
					}
				}
				else
				{
					flag3 = false;
				}
				bool flag4 = flag3;
				if (flag4)
				{
					return flag2 ? array[0] : array[1];
				}
			}
			return value.ToString();
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x00008DE7 File Offset: 0x00006FE7
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
