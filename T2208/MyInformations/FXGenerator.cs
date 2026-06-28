using System;
using JayLib.JayString;

namespace T2208.MyInformations
{
	// Token: 0x0200005D RID: 93
	public static class FXGenerator
	{
		// Token: 0x060004F1 RID: 1265 RVA: 0x0001E608 File Offset: 0x0001C808
		public static string[] InfoGenerator(FXValueType valueType, int Maximum, int Minimum = 0, int step = 1)
		{
			string text = null;
			switch (valueType)
			{
			case FXValueType.millisecond:
				text = "ms";
				break;
			case FXValueType.percentage:
				text = "%";
				break;
			case FXValueType.none:
				text = "";
				break;
			}
			string[] array = new string[Maximum - Minimum + 1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = ((Minimum + i) * step).ToString().Append(text);
			}
			return array;
		}
	}
}
