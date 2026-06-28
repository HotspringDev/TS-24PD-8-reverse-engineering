using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using FFT;
using JayCustomControlLib;
using Lib.Controls;
using T2208.DeviceCommuncation;
using T2208.Models;
using T2208.MyDatas;
using T2208.MyInformations;
using T2208.ViewModels;

namespace T2208.Views
{
	// Token: 0x02000016 RID: 22
	public partial class AssignChannel : Page
	{
		// Token: 0x06000096 RID: 150 RVA: 0x0000BEF0 File Offset: 0x0000A0F0
		public AssignChannel()
		{
			this.InitializeComponent();
			this.myfft = new DrawerFFT(6, this.fftfrawer);
			this.fftfrawer.onFFTMouseMoveEvent += this.OnFFTMouseMoveEvent;
			base.DataContextChanged += this.AssignChannel_DataContextChanged;
			bool flag = base.DataContext is DSP;
			if (flag)
			{
				this.myfft.drawEQ(ChannelData.ChannelDatas.CH01);
			}
			ViewModelMessager.Messeager.Register<int>(ViewModelMessager.UpdateEqualizer, new Action<int>(this.UpdateEqualizerExecute));
			ViewModelMessager.Messeager.Register(ViewModelMessager.UpdateAllEqualizer, new Action(this.UpdateAllEqualizerExecute));
			ViewModelMessager.Messeager.Register<ChannelInfo>(ViewModelMessager.UpdateChannelInfo, new Action<ChannelInfo>(this.UpdateChannelInfoExecute));
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00003D8F File Offset: 0x00001F8F
		private void UpdateChannelInfoExecute(ChannelInfo obj)
		{
			this.myfft.drawEQ(obj);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000BFF8 File Offset: 0x0000A1F8
		private void UpdateAllEqualizerExecute()
		{
			DSP dsp;
			bool flag = (dsp = base.DataContext as DSP) != null;
			if (flag)
			{
				this.myfft.drawEQ(dsp.ChannelInfo);
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000C030 File Offset: 0x0000A230
		private void UpdateEqualizerExecute(int obj)
		{
			object dataContext = base.DataContext;
			DSP dsp = dataContext as DSP;
			this.myfft.drawOneEQ(this._EQIndexFromDeviceToFFT[obj], dsp.ChannelInfo.EqualizerInfos[obj], true);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000BFF8 File Offset: 0x0000A1F8
		private void AssignChannel_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			DSP dsp;
			bool flag = (dsp = base.DataContext as DSP) != null;
			if (flag)
			{
				this.myfft.drawEQ(dsp.ChannelInfo);
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000C074 File Offset: 0x0000A274
		private void OnFFTMouseMoveEvent(int freqindex, int gaindex, int qindex, int pkindex, MouseEventArgs e)
		{
			ChannelInfo channelInfo = ((DSP)base.DataContext).ChannelInfo;
			bool isConnected = MainData.ConnectionModel.IsConnected;
			if (isConnected)
			{
				int num = this._EQIndexFromFFTToDevice[pkindex];
				bool flag = freqindex == -101 && qindex != -100;
				if (flag)
				{
					channelInfo.EqualizerInfos[num].QFactorIndex = (byte)qindex;
				}
				else
				{
					bool flag2 = freqindex != -101 && qindex == -100;
					if (flag2)
					{
						channelInfo.EqualizerInfos[num].FreqIndex = freqindex;
						channelInfo.EqualizerInfos[num].GainIndex = gaindex;
					}
				}
				UpStreamCommand.SendCMD_EqualizerAdjust(channelInfo.EqualizerInfos[num], channelInfo.EqualizerAllBypass, num, channelInfo.ChannelIndex);
			}
			else
			{
				int num2 = this._EQIndexFromFFTToDevice[pkindex];
				bool flag3 = freqindex == -101 && qindex != -100;
				if (flag3)
				{
					channelInfo.EqualizerInfos[num2].QFactorIndex = (byte)qindex;
				}
				else
				{
					bool flag4 = freqindex != -101 && qindex == -100;
					if (flag4)
					{
						channelInfo.EqualizerInfos[num2].FreqIndex = freqindex;
						channelInfo.EqualizerInfos[num2].GainIndex = gaindex;
					}
				}
				this.myfft.drawOneEQ(pkindex, channelInfo.EqualizerInfos[num2], true);
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00003B79 File Offset: 0x00001D79
		private void Eq_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000BFF8 File Offset: 0x0000A1F8
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			DSP dsp;
			bool flag = (dsp = base.DataContext as DSP) != null;
			if (flag)
			{
				this.myfft.drawEQ(dsp.ChannelInfo);
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000C1D0 File Offset: 0x0000A3D0
		private void LedSlider_SliderValueChanged(object sender, int value)
		{
			DSP dsp;
			bool flag = (dsp = base.DataContext as DSP) != null;
			if (flag)
			{
				dsp.ChannelInfo.PanValue = value;
			}
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000C204 File Offset: 0x0000A404
		private void JSlider_SendValueChanged(double value)
		{
			DSP dsp;
			bool flag = (dsp = base.DataContext as DSP) != null;
			if (flag)
			{
				dsp.ChannelInfo.DelayValueChangeExecute();
			}
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000C234 File Offset: 0x0000A434
		private void JSlider_SendValueChanged_1(double value)
		{
			DSP dsp;
			bool flag = (dsp = base.DataContext as DSP) != null;
			if (flag)
			{
				ChannelInfo channelInfo = dsp.ChannelInfo;
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
					bool flag3 = channelInfo.SelectAuxFxGroup == channelInfo.AuxGroup2;
					if (flag3)
					{
						UpStreamCommand.SendCMD_FatChannel(channelInfo);
					}
					else
					{
						UpStreamCommand.SendCMD_Aux1_4FX1_2(channelInfo);
					}
				}
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000C2C0 File Offset: 0x0000A4C0
		private void dynGSlider_SendValueChanged(double value)
		{
			DSP dsp;
			bool flag = (dsp = base.DataContext as DSP) != null;
			if (flag)
			{
				UpStreamCommand.SendCMD_ChannelCompressor(dsp.ChannelInfo);
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000C2F0 File Offset: 0x0000A4F0
		private void TComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			DSP dsp;
			bool flag = (dsp = base.DataContext as DSP) != null;
			if (flag)
			{
				ChannelInfo channelInfo = dsp.ChannelInfo;
				UpStreamCommand.SendCMD_ChannelCompressor(channelInfo);
			}
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000C324 File Offset: 0x0000A524
		private void TComboBox_DropDownOpened(object sender, EventArgs e)
		{
			DSP dsp;
			bool flag = (dsp = base.DataContext as DSP) != null;
			if (flag)
			{
				ChannelInfo channelInfo = dsp.ChannelInfo;
				channelInfo.TComboBoxCanSend = true;
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000C358 File Offset: 0x0000A558
		private void TComboBox_DropDownClosed(object sender, EventArgs e)
		{
			DSP dsp;
			bool flag = (dsp = base.DataContext as DSP) != null;
			if (flag)
			{
				ChannelInfo channelInfo = dsp.ChannelInfo;
				channelInfo.TComboBoxCanSend = false;
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000C38C File Offset: 0x0000A58C
		private void LostEQFocus(object sender, RoutedEventArgs e)
		{
			bool flag = base.DataContext is DSP;
			if (flag)
			{
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000C730 File Offset: 0x0000A930
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 27)
			{
				((JSlider)target).SendValueChanged += this.JSlider_SendValueChanged_1;
			}
		}

		// Token: 0x04000055 RID: 85
		public DrawerFFT myfft;

		// Token: 0x04000056 RID: 86
		private int[] _EQIndexFromFFTToDevice = new int[] { 2, 3, 4, 5, 0, 1 };

		// Token: 0x04000057 RID: 87
		private int[] _EQIndexFromDeviceToFFT = new int[] { 4, 5, 0, 1, 2, 3 };
	}
}
