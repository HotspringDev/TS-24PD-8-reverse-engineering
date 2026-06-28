using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using JayCustomControlLib;
using T2208.MyInformations;

namespace T2208.MyUserControls
{
	// Token: 0x0200004E RID: 78
	public partial class AssignMainButton : UserControl
	{
		// Token: 0x060003DE RID: 990 RVA: 0x00006387 File Offset: 0x00004587
		public AssignMainButton()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003DF RID: 991 RVA: 0x0001AFCC File Offset: 0x000191CC
		private void LedSlider_SliderValueChanged(object sender, int value)
		{
			ChannelInfo channelInfo;
			bool flag = (channelInfo = base.DataContext as ChannelInfo) != null;
			if (flag)
			{
				channelInfo.PanValue = value;
			}
		}
	}
}
