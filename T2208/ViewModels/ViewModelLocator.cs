using System;
using JayLib;
using T2208.MyInformations;
using T2208.SmallViewModels;

namespace T2208.ViewModels
{
	// Token: 0x02000046 RID: 70
	public static class ViewModelLocator
	{
		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000392 RID: 914 RVA: 0x000061D1 File Offset: 0x000043D1
		public static MainWindowViewModel MainWindowViewModel
		{
			get
			{
				return SingleTon<MainWindowViewModel>.GetInstance();
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000393 RID: 915 RVA: 0x000061D8 File Offset: 0x000043D8
		public static InputWindowViewModel InputWindowViewModel
		{
			get
			{
				return SingleTon<InputWindowViewModel>.GetInstance();
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000394 RID: 916 RVA: 0x000061DF File Offset: 0x000043DF
		public static WindowViewModel WindowViewModel
		{
			get
			{
				return SingleTon<WindowViewModel>.GetInstance();
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000395 RID: 917 RVA: 0x000061E6 File Offset: 0x000043E6
		public static DSP DSP
		{
			get
			{
				return SingleTon<DSP>.GetInstance();
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000396 RID: 918 RVA: 0x000061ED File Offset: 0x000043ED
		public static ChannelPage ChannelPage
		{
			get
			{
				return SingleTon<ChannelPage>.GetInstance();
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000397 RID: 919 RVA: 0x000061F4 File Offset: 0x000043F4
		public static ChannelInfo ChannelInfo
		{
			get
			{
				return SingleTon<ChannelInfo>.GetInstance();
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000398 RID: 920 RVA: 0x000061FB File Offset: 0x000043FB
		public static FBC FBC
		{
			get
			{
				return SingleTon<FBC>.GetInstance();
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000399 RID: 921 RVA: 0x00006202 File Offset: 0x00004402
		public static AutoMix AutoMix
		{
			get
			{
				return SingleTon<AutoMix>.GetInstance();
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x0600039A RID: 922 RVA: 0x00006209 File Offset: 0x00004409
		public static Digital Digital
		{
			get
			{
				return SingleTon<Digital>.GetInstance();
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x0600039B RID: 923 RVA: 0x00006210 File Offset: 0x00004410
		public static FX FX
		{
			get
			{
				return SingleTon<FX>.GetInstance();
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x0600039C RID: 924 RVA: 0x00006217 File Offset: 0x00004417
		public static Ducker Ducker
		{
			get
			{
				return SingleTon<Ducker>.GetInstance();
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x0600039D RID: 925 RVA: 0x0000621E File Offset: 0x0000441E
		public static SaveLoadCopy SaveLoadCopy
		{
			get
			{
				return SingleTon<SaveLoadCopy>.GetInstance();
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x0600039E RID: 926 RVA: 0x00006225 File Offset: 0x00004425
		public static DCA DCA
		{
			get
			{
				return SingleTon<DCA>.GetInstance();
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x0600039F RID: 927 RVA: 0x0000622C File Offset: 0x0000442C
		public static SystemIn SystemIn
		{
			get
			{
				return SingleTon<SystemIn>.GetInstance();
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x060003A0 RID: 928 RVA: 0x00006233 File Offset: 0x00004433
		public static DCAInfo<DCAItem> DCAInfo
		{
			get
			{
				return SingleTon<DCAInfo<DCAItem>>.GetInstance();
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x060003A1 RID: 929 RVA: 0x0000623A File Offset: 0x0000443A
		public static FBCLightItem FBCLightItem
		{
			get
			{
				return SingleTon<FBCLightItem>.GetInstance();
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x060003A2 RID: 930 RVA: 0x00006241 File Offset: 0x00004441
		public static AuxFxItem AuxFxItem
		{
			get
			{
				return SingleTon<AuxFxItem>.GetInstance();
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x060003A3 RID: 931 RVA: 0x00006248 File Offset: 0x00004448
		public static DigitalInfo DigitalBox
		{
			get
			{
				return SingleTon<DigitalInfo>.GetInstance();
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x060003A4 RID: 932 RVA: 0x0000624F File Offset: 0x0000444F
		public static ChannelMappingViewModel ChannelMappingViewModel
		{
			get
			{
				return new ChannelMappingViewModel(true);
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x060003A5 RID: 933 RVA: 0x00006257 File Offset: 0x00004457
		public static Route Route
		{
			get
			{
				return SingleTon<Route>.GetInstance();
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x060003A6 RID: 934 RVA: 0x0000625E File Offset: 0x0000445E
		public static MainWindow MainWindow
		{
			get
			{
				return SingleTon<MainWindow>.GetInstance();
			}
		}
	}
}
