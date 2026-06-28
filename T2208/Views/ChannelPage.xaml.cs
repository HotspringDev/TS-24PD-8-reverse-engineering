using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using JayCustomControlLib;
using T2208.MyInformations;
using T2208.ViewModels;

namespace T2208.Views
{
	// Token: 0x02000018 RID: 24
	public partial class ChannelPage : Page
	{
		// Token: 0x060000AC RID: 172 RVA: 0x00003D9F File Offset: 0x00001F9F
		public ChannelPage()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000C9A4 File Offset: 0x0000ABA4
		private void JSlider_SendValueChanged(double value)
		{
			ChannelPage channelPage;
			bool flag = (channelPage = base.DataContext as ChannelPage) != null;
			if (flag)
			{
				channelPage.DCAPropertyChangeExecute();
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000C9D0 File Offset: 0x0000ABD0
		private new void GotFocusEvent(object sender, RoutedEventArgs e)
		{
			DCAInfo<DCAItem> dcainfo = ((FrameworkElement)sender).DataContext as DCAInfo<DCAItem>;
			dcainfo.IsSelected = true;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000C9F8 File Offset: 0x0000ABF8
		private new void LostFocusEvent(object sender, RoutedEventArgs e)
		{
			DCAInfo<DCAItem> dcainfo = ((FrameworkElement)sender).DataContext as DCAInfo<DCAItem>;
			dcainfo.IsEditName = false;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000CA58 File Offset: 0x0000AC58
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((TextBox)target).LostFocus += this.LostFocusEvent;
				break;
			case 2:
				((JSlider)target).SendValueChanged += this.JSlider_SendValueChanged;
				((JSlider)target).GotFocus += this.GotFocusEvent;
				break;
			case 3:
				((TextBox)target).LostFocus += this.LostFocusEvent;
				break;
			case 4:
				((JSlider)target).SendValueChanged += this.JSlider_SendValueChanged;
				((JSlider)target).GotFocus += this.GotFocusEvent;
				break;
			}
		}
	}
}
