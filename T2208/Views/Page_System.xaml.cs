using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using JayCustomControlLib;
using T2208.DeviceCommuncation;
using T2208.ViewModels;

namespace T2208.Views
{
	// Token: 0x02000024 RID: 36
	public partial class Page_System : Page
	{
		// Token: 0x060000F0 RID: 240 RVA: 0x00003EF0 File Offset: 0x000020F0
		public Page_System()
		{
			this.InitializeComponent();
			this.SetImageSource();
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000E0D4 File Offset: 0x0000C2D4
		private void JSlider_SendValueChanged(double value)
		{
			SystemIn systemIn;
			bool flag = (systemIn = base.DataContext as SystemIn) != null;
			if (flag)
			{
				UpStreamCommand.SendLCDKnobChange((byte)systemIn.LCDSendValue, (byte)systemIn.KnobSendValue);
			}
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00003F08 File Offset: 0x00002108
		private void Load_2412DS(object sender, RoutedEventArgs e)
		{
			Process.Start(AppDomain.CurrentDomain.BaseDirectory + "\\F1.exe");
			Environment.Exit(Environment.ExitCode);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00003F30 File Offset: 0x00002130
		private void SetImageSource()
		{
			this.Image.Source = new BitmapImage(new Uri("pack://application:,,,/T2208;component/Resource/TS-24PD-8.png"));
			this.lbProduct.Text = "TS-24PD-8";
			this.lbVersion.Text = Final.ver;
		}
	}
}
