using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using JayCustomControlLib;
using T2208.DeviceCommuncation;
using T2208.MyInformations;

namespace T2208.MyUserControls
{
	// Token: 0x02000051 RID: 81
	public partial class RouterFader : UserControl
	{
		// Token: 0x060003E8 RID: 1000 RVA: 0x000063CE File Offset: 0x000045CE
		public RouterFader()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x0001B0D8 File Offset: 0x000192D8
		private void JSlider_SendValueChanged(double value)
		{
			AuxFxItem auxFxItem;
			bool flag = (auxFxItem = base.DataContext as AuxFxItem) != null;
			if (flag)
			{
				int channelIndex = auxFxItem.ChannelIndex;
				ChannelInfo channelInfo = ChannelInfo.ChannelInfos[channelIndex];
				bool link = channelInfo.Link;
				if (link)
				{
					bool flag2 = channelInfo.SelectAuxFxGroup == channelInfo.AuxGroup2;
					if (flag2)
					{
						UpStreamCommand.SendCMD_FatChannelLink(channelInfo);
					}
					else
					{
						UpStreamCommand.SendCMD_Aux1_4FX1_2Link(channelInfo);
					}
				}
				else
				{
					bool flag3 = auxFxItem.AuxIndex < 4 || auxFxItem.AuxIndex > 7;
					if (flag3)
					{
						UpStreamCommand.SendCMD_Aux1_4FX1_2(channelInfo);
					}
					else
					{
						UpStreamCommand.SendCMD_FatChannel(channelInfo);
					}
				}
			}
		}
	}
}
