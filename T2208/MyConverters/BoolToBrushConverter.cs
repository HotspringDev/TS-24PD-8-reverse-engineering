using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace T2208.MyConverters
{
	// Token: 0x0200007B RID: 123
	public sealed class BoolToBrushConverter : IValueConverter
	{
		// Token: 0x06000762 RID: 1890 RVA: 0x00023F4C File Offset: 0x0002214C
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string text;
			bool flag = (text = parameter as string) != null && !string.IsNullOrWhiteSpace(text);
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
					return flag2 ? Brushes.LimeGreen : Brushes.Red;
				}
			}
			else
			{
				bool flag5;
				bool flag6;
				if (value is bool)
				{
					flag5 = (bool)value;
					flag6 = true;
				}
				else
				{
					flag6 = false;
				}
				bool flag7 = flag6;
				if (flag7)
				{
					return flag5 ? Brushes.LimeGreen : Brushes.Gray;
				}
			}
			return Brushes.Transparent;
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x00008DE7 File Offset: 0x00006FE7
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
