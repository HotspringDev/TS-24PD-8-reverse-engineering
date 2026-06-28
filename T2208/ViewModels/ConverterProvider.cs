using System;
using JayLib;
using T2208.MyConverters;

namespace T2208.ViewModels
{
	// Token: 0x0200002C RID: 44
	public static class ConverterProvider
	{
		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000199 RID: 409 RVA: 0x00004574 File Offset: 0x00002774
		public static FaderValueToStringConverter FaderValueToStringConverter
		{
			get
			{
				return SingleTon<FaderValueToStringConverter>.GetInstance();
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x0600019A RID: 410 RVA: 0x0000457B File Offset: 0x0000277B
		public static DelayToStringConverter DelayToStringConverter
		{
			get
			{
				return SingleTon<DelayToStringConverter>.GetInstance();
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600019B RID: 411 RVA: 0x00004582 File Offset: 0x00002782
		public static StringListConverter StringListConverter
		{
			get
			{
				return SingleTon<StringListConverter>.GetInstance();
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600019C RID: 412 RVA: 0x00004589 File Offset: 0x00002789
		public static BoolToStringConverter BoolToStringConverter
		{
			get
			{
				return SingleTon<BoolToStringConverter>.GetInstance();
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600019D RID: 413 RVA: 0x00004590 File Offset: 0x00002790
		public static BoolToVisibilityConverter BoolToVisibilityConverter
		{
			get
			{
				return SingleTon<BoolToVisibilityConverter>.GetInstance();
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x0600019E RID: 414 RVA: 0x00004597 File Offset: 0x00002797
		public static NullToVisibilityConverter NullToVisibilityConverter
		{
			get
			{
				return SingleTon<NullToVisibilityConverter>.GetInstance();
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x0600019F RID: 415 RVA: 0x0000459E File Offset: 0x0000279E
		public static LightStatusConverter LightStatusConverter
		{
			get
			{
				return SingleTon<LightStatusConverter>.GetInstance();
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060001A0 RID: 416 RVA: 0x000045A5 File Offset: 0x000027A5
		public static StringSuffixConverter StringSuffixConverter
		{
			get
			{
				return SingleTon<StringSuffixConverter>.GetInstance();
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x000045AC File Offset: 0x000027AC
		public static BoolOppsiteConverter BoolOppositeConverter
		{
			get
			{
				return SingleTon<BoolOppsiteConverter>.GetInstance();
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x000045B3 File Offset: 0x000027B3
		public static BoolToResourceStringConverter BoolToResourceStringConverter
		{
			get
			{
				return SingleTon<BoolToResourceStringConverter>.GetInstance();
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x000045BA File Offset: 0x000027BA
		public static BoolToBrushConverter BoolToBrushConverter
		{
			get
			{
				return SingleTon<BoolToBrushConverter>.GetInstance();
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x000045C1 File Offset: 0x000027C1
		public static MultiBoolConverter MultiBoolConverter
		{
			get
			{
				return SingleTon<MultiBoolConverter>.GetInstance();
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060001A5 RID: 421 RVA: 0x000045C8 File Offset: 0x000027C8
		public static ByteToBrushConverter ByteToBrushConverter
		{
			get
			{
				return SingleTon<ByteToBrushConverter>.GetInstance();
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060001A6 RID: 422 RVA: 0x000045CF File Offset: 0x000027CF
		public static BoolToLEDStatusConverter BoolToLEDStatusConverter
		{
			get
			{
				return SingleTon<BoolToLEDStatusConverter>.GetInstance();
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x000045D6 File Offset: 0x000027D6
		public static GeqGainValueToStringConverter GeqGainValueToStringConverter
		{
			get
			{
				return SingleTon<GeqGainValueToStringConverter>.GetInstance();
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060001A8 RID: 424 RVA: 0x000045DD File Offset: 0x000027DD
		public static BoolOppsiteToVisibilityConverter BoolOppsiteToVisibilityConverter
		{
			get
			{
				return SingleTon<BoolOppsiteToVisibilityConverter>.GetInstance();
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060001A9 RID: 425 RVA: 0x000045E4 File Offset: 0x000027E4
		public static OnlyTrueConverter OnlyTrueConverter
		{
			get
			{
				return SingleTon<OnlyTrueConverter>.GetInstance();
			}
		}
	}
}
