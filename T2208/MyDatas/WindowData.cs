using System;
using System.Windows;

namespace T2208.MyDatas
{
	// Token: 0x02000078 RID: 120
	public static class WindowData
	{
		// Token: 0x170002BC RID: 700
		// (get) Token: 0x06000759 RID: 1881 RVA: 0x00008DD8 File Offset: 0x00006FD8
		// (set) Token: 0x0600075A RID: 1882 RVA: 0x00008DDF File Offset: 0x00006FDF
		public static MainWindow MainWindow { get; set; }

		// Token: 0x170002BD RID: 701
		// (get) Token: 0x0600075B RID: 1883 RVA: 0x00023EB0 File Offset: 0x000220B0
		public static Window CurrentWindow
		{
			get
			{
				return WindowData.MainWindow;
			}
		}
	}
}
