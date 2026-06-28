using System;
using FFT;
using T2208.MyInformations;

namespace T2208.Models
{
	// Token: 0x0200008C RID: 140
	public class BaseData
	{
		// Token: 0x06000795 RID: 1941 RVA: 0x0002456C File Offset: 0x0002276C
		public static EQParam ParamOfFlatEQ(EqualizerInfo equalizerInfo)
		{
			EQParam eqparam = new EQParam();
			int freqIndex = equalizerInfo.FreqIndex;
			int num = 24;
			int qfactorIndex = (int)equalizerInfo.QFactorIndex;
			int num2 = equalizerInfo.FilterIndex;
			byte bypass = equalizerInfo.Bypass;
			eqparam.Freq = FFTConstaint.FreqTable[freqIndex];
			eqparam.Gain = FFTConstaint.GainTale[num];
			bool isHighLowPass = equalizerInfo.IsHighLowPass;
			if (isHighLowPass)
			{
				eqparam.QValue = 0.05;
			}
			else
			{
				eqparam.QValue = FFTConstaint.QValueTable[qfactorIndex];
			}
			bool flag = !equalizerInfo.IsHighLowPass;
			if (flag)
			{
				eqparam.TypeFilter = num2 + 1;
			}
			else
			{
				FFTConstaint.XoverType xoverType = (FFTConstaint.XoverType)num2;
				num2 = FFTConstaint.getFilterWithType(xoverType);
				eqparam.TypeFilter = num2;
			}
			eqparam.ByPass = bypass;
			return eqparam;
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x00024630 File Offset: 0x00022830
		public static EQParam ParamOfEQ(EqualizerInfo equalizerInfo)
		{
			EQParam eqparam = new EQParam();
			int freqIndex = equalizerInfo.FreqIndex;
			int gainIndex = equalizerInfo.GainIndex;
			int qfactorIndex = (int)equalizerInfo.QFactorIndex;
			int num = equalizerInfo.FilterIndex;
			byte bypass = equalizerInfo.Bypass;
			eqparam.Freq = FFTConstaint.FreqTable[freqIndex];
			eqparam.Gain = FFTConstaint.GainTale[gainIndex];
			bool isHighLowPass = equalizerInfo.IsHighLowPass;
			if (isHighLowPass)
			{
				eqparam.QValue = 0.05;
			}
			else
			{
				eqparam.QValue = FFTConstaint.QValueTable[qfactorIndex];
			}
			bool flag = !equalizerInfo.IsHighLowPass;
			if (flag)
			{
				eqparam.TypeFilter = num + 1;
			}
			else
			{
				FFTConstaint.XoverType xoverType = (FFTConstaint.XoverType)num;
				num = FFTConstaint.getFilterWithType(xoverType);
				eqparam.TypeFilter = num;
			}
			eqparam.ByPass = bypass;
			return eqparam;
		}
	}
}
