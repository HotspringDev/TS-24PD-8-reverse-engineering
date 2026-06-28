using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace T2208.Views
{
	// Token: 0x02000023 RID: 35
	public partial class Page_SaveLoadCopy : Page
	{
		// Token: 0x060000EC RID: 236 RVA: 0x00003EC4 File Offset: 0x000020C4
		public Page_SaveLoadCopy()
		{
			this.InitializeComponent();
			this.SetImageSource();
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00003EDC File Offset: 0x000020DC
		private void SetImageSource()
		{
			this.DevicePresetBtn.Content = "TS-24PD-8";
		}
	}
}
