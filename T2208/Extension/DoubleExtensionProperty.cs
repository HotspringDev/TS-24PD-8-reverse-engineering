using System;
using System.Windows;

namespace T2208.Extension
{
	// Token: 0x020000A9 RID: 169
	public static class DoubleExtensionProperty
	{
		// Token: 0x06000872 RID: 2162 RVA: 0x00009CBD File Offset: 0x00007EBD
		public static void SetCustomDouble(DependencyObject element, double value)
		{
			element.SetValue(DoubleExtensionProperty.CustomDoubleProperty, value);
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x00026284 File Offset: 0x00024484
		public static double GetCustomDouble(DependencyObject element)
		{
			return (double)element.GetValue(DoubleExtensionProperty.CustomDoubleProperty);
		}

		// Token: 0x040004A2 RID: 1186
		public static readonly DependencyProperty CustomDoubleProperty = DependencyProperty.RegisterAttached("CustomDouble", typeof(double), typeof(DoubleExtensionProperty), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
	}
}
