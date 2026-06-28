using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace T2208
{
	// Token: 0x02000013 RID: 19
	public partial class MainWindow : Window
	{
		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000088 RID: 136 RVA: 0x00003D1F File Offset: 0x00001F1F
		// (set) Token: 0x06000089 RID: 137 RVA: 0x00003D26 File Offset: 0x00001F26
		public static string IP { get; set; }

		// Token: 0x0600008A RID: 138 RVA: 0x0000BD80 File Offset: 0x00009F80
		public MainWindow()
		{
			Multiple_NIC multiple_NIC = new Multiple_NIC();
			NIC_Select nic_Select = new NIC_Select();
			nic_Select.ShowDialog();
			this.InitializeComponent();
			this.SetImageSource();
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00003D2E File Offset: 0x00001F2E
		private void SetImageSource()
		{
			this.Icon.Source = new BitmapImage(new Uri("pack://application:,,,/T2208;component/Resource/TS-24PD-8.ico"));
			this.CenterName.Text = "TS-24PD-8";
		}
	}
}
