using System;
using FFT;
using T2208.MyInformations;

namespace T2208.MyDatas
{
	// Token: 0x0200006C RID: 108
	internal class BaseDate
	{
		// Token: 0x0600067D RID: 1661 RVA: 0x00020A4C File Offset: 0x0001EC4C
		public static EQParam ParamOfFlatEq(EqualizerInfo equalizerInfo)
		{
			return BaseDate.ParamOfEq(equalizerInfo, true);
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x00020A68 File Offset: 0x0001EC68
		public static EQParam ParamOfEq(EqualizerInfo equalizerInfo, bool isFlat = false)
		{
			EQParam eqparam = new EQParam();
			int freqIndex = equalizerInfo.FreqIndex;
			int num = (isFlat ? 24 : equalizerInfo.GainIndex);
			int qfactorIndex = (int)equalizerInfo.QFactorIndex;
			int num2 = equalizerInfo.FilterIndex;
			byte bypass = equalizerInfo.Bypass;
			eqparam.Freq = FFTConstaint.FreqTable[freqIndex];
			eqparam.Gain = FFTConstaint.GainTale[num];
			eqparam.QValue = (equalizerInfo.IsHighLowPass ? 0.05 : FFTConstaint.QValueTable[qfactorIndex]);
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
	}
}
