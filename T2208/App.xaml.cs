using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using T2208.MyDatas;

namespace T2208
{
	// Token: 0x02000012 RID: 18
	public partial class App : Application
	{
		// Token: 0x06000084 RID: 132 RVA: 0x0000BCF8 File Offset: 0x00009EF8
		protected override void OnStartup(StartupEventArgs e)
		{
			MainWindow mainWindow = new MainWindow();
			WindowData.MainWindow = mainWindow;
			mainWindow.Show();
			base.OnStartup(e);
		}
	}
}
