using System;
using System.Windows;
using FFT;
using T2208.Models;
using T2208.MyInformations;

namespace T2208.Views
{
	// Token: 0x02000017 RID: 23
	public class DrawerFFT
	{
		// Token: 0x060000A9 RID: 169 RVA: 0x0000C764 File Offset: 0x0000A964
		public DrawerFFT(int dEqNum, FFTDrawer fft)
		{
			bool flag = fft == null;
			if (flag)
			{
				MessageBox.Show("fftDrawer cannot be null");
			}
			this.fftControl = fft;
			this.chanlDataGenerator = new XChannelFFTDataGenerator(6, FFTConstaint.Freq128Table, FFTConstaint.Gain24Table, FFTConstaint.QValue24FactorTable);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000C7B0 File Offset: 0x0000A9B0
		public void drawOneEQ(int eindex, EqualizerInfo equalizerInfo, bool drawone = true)
		{
			bool equalizerEnable = equalizerInfo.EqualizerEnable;
			if (equalizerEnable)
			{
				this.chanlDataGenerator.setEQParam(BaseData.ParamOfEQ(equalizerInfo), equalizerInfo.FFTEqualizerIndex, this.fftControl);
			}
			else
			{
				this.chanlDataGenerator.setEQParam(BaseData.ParamOfFlatEQ(equalizerInfo), equalizerInfo.FFTEqualizerIndex, this.fftControl);
			}
			this.chanlDataGenerator.setOneFFTAdapter(this.fftControl, eindex);
			this.fftControl.drawone = true;
			bool flag = eindex > 3;
			if (flag)
			{
				this.fftControl.isdrawwave2 = false;
			}
			this.fftControl.moveIndex = eindex;
			this.fftControl.Redraw();
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000C854 File Offset: 0x0000AA54
		public void drawEQ(ChannelInfo channelInfo)
		{
			bool flag = !this.fftControl.isSupportMutiLine;
			if (flag)
			{
				bool equalizerAllBypass = channelInfo.EqualizerAllBypass;
				if (equalizerAllBypass)
				{
					foreach (EqualizerInfo equalizerInfo in channelInfo.EqualizerInfos)
					{
						bool equalizerEnable = equalizerInfo.EqualizerEnable;
						if (equalizerEnable)
						{
							this.chanlDataGenerator.setEQParam(BaseData.ParamOfEQ(equalizerInfo), equalizerInfo.FFTEqualizerIndex, this.fftControl);
						}
						else
						{
							this.chanlDataGenerator.setEQParam(BaseData.ParamOfFlatEQ(equalizerInfo), equalizerInfo.FFTEqualizerIndex, this.fftControl);
						}
					}
				}
				else
				{
					foreach (EqualizerInfo equalizerInfo2 in channelInfo.EqualizerInfos)
					{
						this.chanlDataGenerator.setEQParam(BaseData.ParamOfEQ(equalizerInfo2), equalizerInfo2.FFTEqualizerIndex, this.fftControl);
					}
				}
			}
			this.fftControl.drawone = false;
			this.chanlDataGenerator.setFFTAdapter(this.fftControl);
			this.fftControl.Redraw();
		}

		// Token: 0x0400006A RID: 106
		private FFTDrawer fftControl;

		// Token: 0x0400006B RID: 107
		private XChannelFFTDataGenerator chanlDataGenerator;
	}
}
