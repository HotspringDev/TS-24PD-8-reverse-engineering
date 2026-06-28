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

namespace T2208.MyUserControls
{
	// Token: 0x02000055 RID: 85
	public partial class ChannelFader : UserControl
	{
		// Token: 0x06000450 RID: 1104 RVA: 0x000066BC File Offset: 0x000048BC
		public ChannelFader()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x0001D2C4 File Offset: 0x0001B4C4
		private void JSlider_SlideValueChangedEvent(double value)
		{
			ChannelInfo channelInfo = base.DataContext as ChannelInfo;
			channelInfo.MuteGainChangeExeucte();
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x0001D2E8 File Offset: 0x0001B4E8
		private void LostFocusEvents(object sender, RoutedEventArgs e)
		{
			ChannelInfo channelInfo = base.DataContext as ChannelInfo;
			DCAInfo<DCAItem> dcainfo = base.DataContext as DCAInfo<DCAItem>;
			bool flag = dcainfo == null;
			if (flag)
			{
				channelInfo.SetChannelNameExecute();
			}
			else
			{
				dcainfo.SetChannelNameExecute();
				this.text.IsEditing = false;
			}
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x0001D334 File Offset: 0x0001B534
		private void SelectedEvents(object sender, RoutedEventArgs e)
		{
			ChannelInfo channelInfo = base.DataContext as ChannelInfo;
			bool link = channelInfo.Link;
			if (link)
			{
				for (int i = 0; i < ChannelInfo.ChannelInfos.Count; i++)
				{
					ChannelInfo.ChannelInfos[i].IsPresentChannel = false;
				}
				for (int j = 0; j < ChannelInfo.ChannelInfos.Count; j++)
				{
					bool flag = j % 2 == 1 && ChannelInfo.ChannelInfos[j].Link && ChannelInfo.ChannelInfos[j].ChannelName == (string)this.text.Content;
					if (flag)
					{
						ChannelInfo.ChannelInfos[j - 1].IsPresentChannel = true;
					}
					else
					{
						bool flag2 = j % 2 == 0 && ChannelInfo.ChannelInfos[j].Link && ChannelInfo.ChannelInfos[j].ChannelName == (string)this.text.Content;
						if (flag2)
						{
							ChannelInfo.ChannelInfos[j + 1].IsPresentChannel = true;
						}
					}
				}
				this.text.IsChecked = new bool?(true);
				channelInfo.UpdatePresentChannelExecute();
			}
			else
			{
				for (int k = 0; k < ChannelInfo.ChannelInfos.Count; k++)
				{
					ChannelInfo.ChannelInfos[k].IsPresentChannel = false;
				}
				this.text.IsChecked = new bool?(true);
				channelInfo.UpdatePresentChannelExecute();
			}
		}
	}
}
