using System;

namespace T2208.ViewModels
{
	// Token: 0x0200002B RID: 43
	public static class Const
	{
		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000157 RID: 343 RVA: 0x00004394 File Offset: 0x00002594
		// (set) Token: 0x06000158 RID: 344 RVA: 0x0000439B File Offset: 0x0000259B
		public static string[] MeterStrings
		{
			get
			{
				return Const._meterStrings;
			}
			private set
			{
				Const._meterStrings = value;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000159 RID: 345 RVA: 0x000043A3 File Offset: 0x000025A3
		// (set) Token: 0x0600015A RID: 346 RVA: 0x000043AA File Offset: 0x000025AA
		public static string[] FaderTickStrings
		{
			get
			{
				return Const._faderTickStrings;
			}
			private set
			{
				Const._faderTickStrings = value;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600015B RID: 347 RVA: 0x000043B2 File Offset: 0x000025B2
		// (set) Token: 0x0600015C RID: 348 RVA: 0x000043B9 File Offset: 0x000025B9
		public static string[] FaderStrings
		{
			get
			{
				return Const._faderStrings;
			}
			set
			{
				Const._faderStrings = value;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600015D RID: 349 RVA: 0x0000F7B0 File Offset: 0x0000D9B0
		public static double FaderValueMaximum
		{
			get
			{
				return (double)(Const.FaderStrings.Length - 1);
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600015E RID: 350 RVA: 0x000043C1 File Offset: 0x000025C1
		// (set) Token: 0x0600015F RID: 351 RVA: 0x000043C8 File Offset: 0x000025C8
		public static string[] QFactorStrings
		{
			get
			{
				return Const._qFactorStrings;
			}
			set
			{
				Const._qFactorStrings = value;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000160 RID: 352 RVA: 0x000043D0 File Offset: 0x000025D0
		// (set) Token: 0x06000161 RID: 353 RVA: 0x000043D7 File Offset: 0x000025D7
		public static string[] QFactorLSFStrings
		{
			get
			{
				return Const._qFactorLSFStrings;
			}
			set
			{
				Const._qFactorLSFStrings = value;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000162 RID: 354 RVA: 0x000043DF File Offset: 0x000025DF
		// (set) Token: 0x06000163 RID: 355 RVA: 0x000043E6 File Offset: 0x000025E6
		public static string[] QFactorHSFStrings
		{
			get
			{
				return Const._qFactorHSFStrings;
			}
			set
			{
				Const._qFactorHSFStrings = value;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000164 RID: 356 RVA: 0x000043EE File Offset: 0x000025EE
		// (set) Token: 0x06000165 RID: 357 RVA: 0x000043F5 File Offset: 0x000025F5
		public static string[] Frequence300Strings
		{
			get
			{
				return Const._frequence300Strings;
			}
			set
			{
				Const._frequence300Strings = value;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000166 RID: 358 RVA: 0x000043FD File Offset: 0x000025FD
		// (set) Token: 0x06000167 RID: 359 RVA: 0x00004404 File Offset: 0x00002604
		public static string[] Frequence128Strings
		{
			get
			{
				return Const._frequence128Strings;
			}
			set
			{
				Const._frequence128Strings = value;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000168 RID: 360 RVA: 0x0000440C File Offset: 0x0000260C
		// (set) Token: 0x06000169 RID: 361 RVA: 0x00004413 File Offset: 0x00002613
		public static string[] GainTable
		{
			get
			{
				return Const._gainTable;
			}
			set
			{
				Const._gainTable = value;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600016A RID: 362 RVA: 0x0000441B File Offset: 0x0000261B
		// (set) Token: 0x0600016B RID: 363 RVA: 0x00004422 File Offset: 0x00002622
		public static string[] High_LowPassFilter
		{
			get
			{
				return Const._high_lowPassFilter;
			}
			set
			{
				Const._high_lowPassFilter = value;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600016C RID: 364 RVA: 0x0000442A File Offset: 0x0000262A
		// (set) Token: 0x0600016D RID: 365 RVA: 0x00004431 File Offset: 0x00002631
		public static string[] TypeFilter
		{
			get
			{
				return Const._typeFilter;
			}
			set
			{
				Const._typeFilter = value;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600016E RID: 366 RVA: 0x00004439 File Offset: 0x00002639
		// (set) Token: 0x0600016F RID: 367 RVA: 0x00004440 File Offset: 0x00002640
		public static string[] NoiseGateCoordinateAxis
		{
			get
			{
				return Const._NoiseGateCoordinateAxis;
			}
			set
			{
				Const._NoiseGateCoordinateAxis = value;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000170 RID: 368 RVA: 0x00004448 File Offset: 0x00002648
		// (set) Token: 0x06000171 RID: 369 RVA: 0x0000444F File Offset: 0x0000264F
		public static string[] NoiseGateThresholds
		{
			get
			{
				return Const._NoiseGateThresholds;
			}
			set
			{
				Const._NoiseGateThresholds = value;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000172 RID: 370 RVA: 0x00004457 File Offset: 0x00002657
		// (set) Token: 0x06000173 RID: 371 RVA: 0x0000445E File Offset: 0x0000265E
		public static string[] NoiseGateReleases
		{
			get
			{
				return Const._NoiseGateReleases;
			}
			set
			{
				Const._NoiseGateReleases = value;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000174 RID: 372 RVA: 0x00004466 File Offset: 0x00002666
		// (set) Token: 0x06000175 RID: 373 RVA: 0x0000446D File Offset: 0x0000266D
		public static string[] NoiseGateAttacks
		{
			get
			{
				return Const._NoiseGateAttacks;
			}
			set
			{
				Const._NoiseGateAttacks = value;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000176 RID: 374 RVA: 0x00004475 File Offset: 0x00002675
		// (set) Token: 0x06000177 RID: 375 RVA: 0x0000447C File Offset: 0x0000267C
		public static string[] DelayStrings
		{
			get
			{
				return Const._DelayStrings;
			}
			set
			{
				Const._DelayStrings = value;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000178 RID: 376 RVA: 0x00004484 File Offset: 0x00002684
		// (set) Token: 0x06000179 RID: 377 RVA: 0x0000448B File Offset: 0x0000268B
		public static string[] CompressorCoordinateAxis
		{
			get
			{
				return Const._CompressorCoordinateAxis;
			}
			set
			{
				Const._CompressorCoordinateAxis = value;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x0600017A RID: 378 RVA: 0x00004493 File Offset: 0x00002693
		// (set) Token: 0x0600017B RID: 379 RVA: 0x0000449A File Offset: 0x0000269A
		public static string[] CompressorRatios
		{
			get
			{
				return Const._CompressorRatios;
			}
			set
			{
				Const._CompressorRatios = value;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600017C RID: 380 RVA: 0x000044A2 File Offset: 0x000026A2
		// (set) Token: 0x0600017D RID: 381 RVA: 0x000044A9 File Offset: 0x000026A9
		public static string[] CompressorThresholds
		{
			get
			{
				return Const._CompressorThresholds;
			}
			set
			{
				Const._CompressorThresholds = value;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600017E RID: 382 RVA: 0x000044B1 File Offset: 0x000026B1
		// (set) Token: 0x0600017F RID: 383 RVA: 0x000044B8 File Offset: 0x000026B8
		public static string[] CompressorReleases
		{
			get
			{
				return Const._CompressorReleases;
			}
			set
			{
				Const._CompressorReleases = value;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000180 RID: 384 RVA: 0x000044C0 File Offset: 0x000026C0
		// (set) Token: 0x06000181 RID: 385 RVA: 0x000044C7 File Offset: 0x000026C7
		public static string[] CompressorAttacks
		{
			get
			{
				return Const._CompressorAttacks;
			}
			set
			{
				Const._CompressorAttacks = value;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000182 RID: 386 RVA: 0x000044CF File Offset: 0x000026CF
		// (set) Token: 0x06000183 RID: 387 RVA: 0x000044D6 File Offset: 0x000026D6
		public static string[] CompressorGains
		{
			get
			{
				return Const._CompressorGains;
			}
			set
			{
				Const._CompressorGains = value;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000184 RID: 388 RVA: 0x000044DE File Offset: 0x000026DE
		// (set) Token: 0x06000185 RID: 389 RVA: 0x000044E5 File Offset: 0x000026E5
		public static string[] GEQFrequenceStrings
		{
			get
			{
				return Const._GEQFrequenceStrings;
			}
			set
			{
				Const._GEQFrequenceStrings = value;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000186 RID: 390 RVA: 0x000044ED File Offset: 0x000026ED
		// (set) Token: 0x06000187 RID: 391 RVA: 0x000044F4 File Offset: 0x000026F4
		public static string[] GEQGainValueStrings
		{
			get
			{
				return Const._GEQGainValueStrings;
			}
			set
			{
				Const._GEQGainValueStrings = value;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000188 RID: 392 RVA: 0x000044FC File Offset: 0x000026FC
		// (set) Token: 0x06000189 RID: 393 RVA: 0x00004503 File Offset: 0x00002703
		public static string[] ChannelNames
		{
			get
			{
				return Const._ChannelNames;
			}
			set
			{
				Const._ChannelNames = value;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x0600018A RID: 394 RVA: 0x0000450B File Offset: 0x0000270B
		// (set) Token: 0x0600018B RID: 395 RVA: 0x00004512 File Offset: 0x00002712
		public static string[] AutoMixActiveTimeStrings
		{
			get
			{
				return Const._AutoMixActiveTimeStrings;
			}
			set
			{
				Const._AutoMixActiveTimeStrings = value;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600018C RID: 396 RVA: 0x0000451A File Offset: 0x0000271A
		// (set) Token: 0x0600018D RID: 397 RVA: 0x00004521 File Offset: 0x00002721
		public static string[] DuckerThresholds
		{
			get
			{
				return Const._DuckerThresholds;
			}
			set
			{
				Const._DuckerThresholds = value;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600018E RID: 398 RVA: 0x00004529 File Offset: 0x00002729
		// (set) Token: 0x0600018F RID: 399 RVA: 0x00004530 File Offset: 0x00002730
		public static string[] DuckerDepth
		{
			get
			{
				return Const._DuckerDepth;
			}
			set
			{
				Const._DuckerDepth = value;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000190 RID: 400 RVA: 0x00004538 File Offset: 0x00002738
		// (set) Token: 0x06000191 RID: 401 RVA: 0x0000453F File Offset: 0x0000273F
		public static string[] DuckerAttack
		{
			get
			{
				return Const._DuckerAttack;
			}
			set
			{
				Const._DuckerAttack = value;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000192 RID: 402 RVA: 0x00004547 File Offset: 0x00002747
		// (set) Token: 0x06000193 RID: 403 RVA: 0x0000454E File Offset: 0x0000274E
		public static string[] DuckerRelease
		{
			get
			{
				return Const._DuckerRelease;
			}
			set
			{
				Const._DuckerRelease = value;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000194 RID: 404 RVA: 0x00004556 File Offset: 0x00002756
		// (set) Token: 0x06000195 RID: 405 RVA: 0x0000455D File Offset: 0x0000275D
		public static byte[] MeterDeviceToPageConverter
		{
			get
			{
				return Const._meterDeviceToPageConverter;
			}
			set
			{
				Const._meterDeviceToPageConverter = value;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000196 RID: 406 RVA: 0x00004565 File Offset: 0x00002765
		// (set) Token: 0x06000197 RID: 407 RVA: 0x0000456C File Offset: 0x0000276C
		public static string[] CompressorMeterStrings
		{
			get
			{
				return Const._compressorMeterStrings;
			}
			set
			{
				Const._compressorMeterStrings = value;
			}
		}

		// Token: 0x06000198 RID: 408 RVA: 0x0000F7CC File Offset: 0x0000D9CC
		static Const()
		{
			for (int i = 0; i <= 1443; i++)
			{
				int num = Math.Min(i, 1443);
				double num2 = Math.Round(0.208333333 * (double)num, 2);
				Const.DelayStrings[i] = num2.ToString();
			}
		}

		// Token: 0x040000C6 RID: 198
		private static string[] _ChannelNames = new string[]
		{
			"CH01", "CH02", "CH03", "CH04", "CH05", "CH06", "CH07", "CH08", "CH09", "CH10",
			"CH11", "CH12", "CH13", "CH14", "CH15", "CH16", "CH17", "CH18", "CH19", "CH20",
			"USB", "FX1", "FX2", "AUX1", "AUX2", "AUX3", "AUX4", "AUX5", "AUX6", "AUX7",
			"AUX8", "MAIN"
		};

		// Token: 0x040000C7 RID: 199
		private static string[] _qFactorStrings = new string[]
		{
			" 0.4", " 0.5", " 0.6", " 0.7", " 0.8", " 0.9", " 1.0", " 1.2", " 1.6", " 2.0",
			" 2.5", " 3.0", " 3.5", " 4.0", " 5.0", " 6.0", " 8.0", " 10.0", " 12.0", " 14.0",
			" 16.0", " 18.0", " 20.0", " 22.0", " 24.0"
		};

		// Token: 0x040000C8 RID: 200
		private static string[] _qFactorHSFStrings = new string[] { "HSF" };

		// Token: 0x040000C9 RID: 201
		private static string[] _qFactorLSFStrings = new string[] { "LSF" };

		// Token: 0x040000CA RID: 202
		private static string[] _frequence300Strings = new string[]
		{
			"19.7Hz", "20.1Hz", "20.6Hz", "21.1Hz", "21.6Hz", "22.1Hz", "22.6Hz", "23.1Hz", "23.7Hz", "24.2Hz",
			"24.8Hz", "25.4Hz", "26.0Hz", "26.6Hz", "27.2Hz", "27.8Hz", "28.5Hz", "29.2Hz", "29.8Hz", "30.5Hz",
			"31.2Hz", "32.0Hz", "32.7Hz", "33.5Hz", "34.3Hz", "35.1Hz", "35.9Hz", "36.7Hz", "37.6Hz", "38.5Hz",
			"39.4Hz", "40.3Hz", "41.2Hz", "42.2Hz", "43.2Hz", "44.2Hz", "45.2Hz", "46.3Hz", "47.4Hz", "48.5Hz",
			"49.6Hz", "50.8Hz", "52.0Hz", "53.2Hz", "54.4Hz", "55.7Hz", "57.0Hz", "58.3Hz", "59.7Hz", "61.1Hz",
			"62.5Hz", "64.0Hz", "65.5Hz", "67.0Hz", "68.6Hz", "70.2Hz", "71.8Hz", "73.5Hz", "75.2Hz", "76.9Hz",
			"78.7Hz", "80.6Hz", "82.5Hz", "84.4Hz", "86.4Hz", "88.4Hz", "90.5Hz", "92.6Hz", "94.7Hz", "96.9Hz",
			"99.2Hz", "101.5Hz", "103.9Hz", "106.3Hz", "108.8Hz", "111.4Hz", "114.0Hz", "116.6Hz", "119.4Hz", "122.1Hz",
			"125.0Hz", "127.9Hz", "130.9Hz", "134.0Hz", "137.1Hz", "140.3Hz", "143.6Hz", "146.9Hz", "150.4Hz", "153.9Hz",
			"157.5Hz", "161.2Hz", "164.9Hz", "168.8Hz", "172.7Hz", "176.8Hz", "180.9Hz", "185.1Hz", "189.5Hz", "193.9Hz",
			"198.4Hz", "203.1Hz", "207.8Hz", "212.7Hz", "217.6Hz", "222.7Hz", "227.9Hz", "233.3Hz", "238.7Hz", "244.3Hz",
			"250.0Hz", "255.8Hz", "261.8Hz", "267.9Hz", "274.2Hz", "280.6Hz", "287.2Hz", "293.9Hz", "300.8Hz", "307.8Hz",
			"315.0Hz", "322.3Hz", "329.9Hz", "337.6Hz", "345.5Hz", "353.6Hz", "361.8Hz", "370.3Hz", "378.9Hz", "387.8Hz",
			"396.9Hz", "406.1Hz", "415.6Hz", "425.3Hz", "435.3Hz", "445.4Hz", "455.9Hz", "466.5Hz", "477.4Hz", "488.6Hz",
			"500.0Hz", "511.7Hz", "523.6Hz", "535.9Hz", "548.4Hz", "561.2Hz", "574.3Hz", "587.8Hz", "601.5Hz", "615.6Hz",
			"630.0Hz", "644.7Hz", "659.8Hz", "675.2Hz", "691.0Hz", "707.1Hz", "723.6Hz", "740.5Hz", "757.9Hz", "775.6Hz",
			"793.7Hz", "812.3Hz", "831.2Hz", "850.7Hz", "870.6Hz", "890.9Hz", "911.7Hz", "933.0Hz", "954.8Hz", "977.2Hz",
			"1.00KHz", "1.03KHz", "1.05KHz", "1.08KHz", "1.10KHz", "1.13KHz", "1.15KHz", "1.18KHz", "1.21KHz", "1.24KHz",
			"1.26KHz", "1.29KHz", "1.32KHz", "1.35KHz", "1.39KHz", "1.42KHz", "1.45KHz", "1.49KHz", "1.52KHz", "1.56KHz",
			"1.59KHz", "1.63KHz", "1.67KHz", "1.71KHz", "1.75KHz", "1.79KHz", "1.83KHz", "1.87KHz", "1.91KHz", "1.96KHz",
			"2.01KHz", "2.05KHz", "2.10KHz", "2.15KHz", "2.20KHz", "2.25KHz", "2.30KHz", "2.36KHz", "2.41KHz", "2.47KHz",
			"2.52KHz", "2.58KHz", "2.64KHz", "2.70KHz", "2.77KHz", "2.83KHz", "2.90KHz", "2.97KHz", "3.04KHz", "3.11KHz",
			"3.18KHz", "3.25KHz", "3.33KHz", "3.41KHz", "3.49KHz", "3.57KHz", "3.65KHz", "3.74KHz", "3.82KHz", "3.91KHz",
			"4.01KHz", "4.10KHz", "4.19KHz", "4.29KHz", "4.39KHz", "4.49KHz", "4.60KHz", "4.71KHz", "4.82KHz", "4.93KHz",
			"5.04KHz", "5.16KHz", "5.28KHz", "5.41KHz", "5.53KHz", "5.66KHz", "5.79KHz", "5.93KHz", "6.07KHz", "6.21KHz",
			"6.35KHz", "6.50KHz", "6.65KHz", "6.81KHz", "6.97KHz", "7.13KHz", "7.30KHz", "7.47KHz", "7.64KHz", "7.82KHz",
			"8.00KHz", "8.19KHz", "8.38KHz", "8.58KHz", "8.78KHz", "8.98KHz", "9.19KHz", "9.41KHz", "9.63KHz", "9.85KHz",
			"10.08KHz", "10.32KHz", "10.56KHz", "10.81KHz", "11.06KHz", "11.32KHz", "11.58KHz", "11.85KHz", "12.13KHz", "12.41KHz",
			"12.70KHz", "13.00KHz", "13.30KHz", "13.61KHz", "13.93KHz", "14.26KHz", "14.59KHz", "14.93KHz", "15.28KHz", "15.64KHz",
			"16.01KHz", "16.38KHz", "16.76KHz", "17.15KHz", "17.55KHz", "17.96KHz", "18.38KHz", "18.81KHz", "19.25KHz", "19.70KHz",
			"20.16KHz"
		};

		// Token: 0x040000CB RID: 203
		private static string[] _frequence128Strings = new string[]
		{
			"20.6Hz", "21.6Hz", "23.1Hz", "24.8Hz", "25.8Hz", "27.8Hz", "30.0Hz", "32.3Hz", "35.1Hz", "36.7Hz",
			"37.6Hz", "38.5Hz", "39.4Hz", "40.0Hz", "42.2Hz", "45.2Hz", "48.5Hz", "50.0Hz", "54.4Hz", "57.0Hz",
			"60.0Hz", "64.0Hz", "67.0Hz", "70.0Hz", "75.2Hz", "78.7Hz", "80.0Hz", "86.4Hz", "90.0Hz", "94.7Hz",
			"100.0Hz", "106.3Hz", "114.0Hz", "119.4Hz", "125.0Hz", "134.0Hz", "140.3Hz", "150.4Hz", "161.2Hz", "168.8Hz",
			"176.8Hz", "185.1Hz", "195.3Hz", "200.0Hz", "212.7Hz", "227.9Hz", "233.3Hz", "250.0Hz", "261.8Hz", "280.6Hz",
			"300.0Hz", "315.0Hz", "329.9Hz", "353.6Hz", "370.3Hz", "387.8Hz", "400.0Hz", "425.3Hz", "445.4Hz", "466.5Hz",
			"500.0Hz", "535.9Hz", "574.3Hz", "600.0Hz", "630.0Hz", "675.2Hz", "700.0Hz", "757.9Hz", "800.0Hz", "831.2Hz",
			"870.6Hz", "900.0Hz", "954.8Hz", "1.0kHz", "1.05kHz", "1.15kHz", "1.21kHz", "1.29kHz", "1.42kHz", "1.49kHz",
			"1.56kHz", "1.67kHz", "1.75kHz", "1.83kHz", "1.96kHz", "2.00kHz", "2.10kHz", "2.15kHz", "2.25kHz", "2.36kHz",
			"2.52kHz", "2.64kHz", "2.90kHz", "3.00kHz", "3.25kHz", "3.57kHz", "3.74kHz", "3.91kHz", "4.00kHz", "4.10kHz",
			"4.39kHz", "4.60kHz", "4.93kHz", "5.00kHz", "5.28kHz", "5.79kHz", "6.00kHz", "6.35kHz", "6.81kHz", "7.00kHz",
			"7.64kHz", "8.00kHz", "8.19kHz", "8.78kHz", "9.00kHz", "10.0kHz", "11.5kHz", "12.1kHz", "12.7kHz", "13.3kHz",
			"13.9kHz", "14.5kHz", "15.2kHz", "16.0kHz", "16.7kHz", "17.5kHz", "18.3kHz", "19.2kHz", "20.0kHz"
		};

		// Token: 0x040000CC RID: 204
		private static string[] _gainTable = new string[]
		{
			"-24dB", "-23dB", "-22dB", "-21dB", "-20dB", "-19dB", "-18dB", "-17dB", "-16dB", "-15dB",
			"-14dB", "-13dB", "-12dB", "-11dB", "-10dB", "-9dB", "-8dB", "-7dB", "-6dB", "-5dB",
			"-4dB", "-3dB", "-2dB", "-1dB", "0dB", "1dB", "2dB", "3dB", "4dB", "5dB",
			"6dB", "7dB", "8dB", "9dB", "10dB", "11dB", "12dB", "13dB", "14dB", "15dB",
			"16dB", "17dB", "18dB", "19dB", "20dB", "21dB", "22dB", "23dB", "24dB"
		};

		// Token: 0x040000CD RID: 205
		private static string[] _high_lowPassFilter = new string[]
		{
			"Bypass", "BW6", "BES6", "BW12", "BES12", "LK12", "BW18", "BES18", "BW24", "BES24",
			"LK24", "BW30", "BES30", "BW36", "BES36", "LK36", "BW42", "BES42", "BW48", "BES48",
			"LK48"
		};

		// Token: 0x040000CE RID: 206
		private static string[] _NoiseGateCoordinateAxis = new string[] { "-84", "-71", "-58", "-45", "-32", "-19", "-6", "  7", "20" };

		// Token: 0x040000CF RID: 207
		private static string[] _NoiseGateThresholds = new string[]
		{
			"-84dB", "-83dB", "-82dB", "-81dB", "-80dB", "-79dB", "-78dB", "-77dB", "-76dB", "-75dB",
			"-74dB", "-73dB", "-72dB", "-71dB", "-70dB", "-69dB", "-68dB", "-67dB", "-66dB", "-65dB",
			"-64dB", "-63dB", "-62dB", "-61dB", "-60dB", "-59dB", "-58dB", "-57dB", "-56dB", "-55dB",
			"-54dB", "-53dB", "-52dB", "-51dB", "-50dB", "-49dB", "-48dB", "-47dB", "-46dB", "-45dB",
			"-44dB", "-43dB", "-42dB", "-41dB", "-40dB", "-39dB", "-38dB", "-37dB", "-36dB", "-35dB",
			"-34dB", "-33dB", "-32dB", "-31dB", "-30dB", "-29dB", "-28dB", "-27dB", "-26dB", "-25dB",
			"-24dB", "-23dB", "-22dB", "-21dB", "-20dB", "-18dB", "-16dB", "-14dB", "-12dB", "-10dB",
			"-8dB", "-6dB", "-4dB", "-2dB", "0dB", "2dB", "4dB", "6dB", "8dB", "10dB",
			"12dB", "14dB", "16dB", "18dB", "20dB"
		};

		// Token: 0x040000D0 RID: 208
		private static string[] _NoiseGateReleases = new string[]
		{
			"10ms", "20ms", "25ms", "30ms", "50ms", "100ms", "120ms", "150ms", "175ms", "200ms",
			"250ms", "300ms", "350ms", "400ms", "450ms", "500ms", "550ms", "600ms", "650ms", "700ms",
			"750ms", "800ms", "850ms", "900ms", "1000ms"
		};

		// Token: 0x040000D1 RID: 209
		private static string[] _NoiseGateAttacks = new string[]
		{
			"0.5ms", "1ms", "2.5ms", "5ms", "7.5ms", "10ms", "15ms", "20ms", "25ms", "30ms",
			"35ms", "40ms", "45ms", "50ms", "55ms", "60ms", "75ms", "85ms", "90ms", "100ms",
			"110ms", "125ms", "140ms", "150ms", "200ms"
		};

		// Token: 0x040000D2 RID: 210
		private static string[] _CompressorCoordinateAxis = new string[] { "-30", "-20", "-10", "0", "10", "20" };

		// Token: 0x040000D3 RID: 211
		private static string[] _CompressorRatios = new string[]
		{
			"1:1", "1.2:1", "1.3:1", "1.5:1", "1.7:1", "2.0:1", "2.2:1", "2.3:1", "2.5:1", "3:1",
			"3.5:1", "4:1", "4.5:1", "5:1", "5.5:1", "6:1", "6.5:1", "7:1", "7.5:1", "8:1",
			"8.5:1", "9:1", "9.5:1", "10:1", "Limit"
		};

		// Token: 0x040000D4 RID: 212
		private static string[] _CompressorThresholds = new string[]
		{
			"-30dB", "-29dB", "-28dB", "-27dB", "-26dB", "-25dB", "-24dB", "-23dB", "-22dB", "-21dB",
			"-20dB", "-19dB", "-18dB", "-17dB", "-16dB", "-15dB", "-14dB", "-13dB", "-12dB", "-11dB",
			"-10dB", "-9dB", "-8dB", "-7dB", "-6dB", "-5dB", "-4dB", "-3dB", "-2dB", "-1dB",
			"0dB", "1dB", "2dB", "3dB", "4dB", "5dB", "6dB", "7dB", "8dB", "9dB",
			"10dB", "11dB", "12dB", "13dB", "14dB", "15dB", "16dB", "17dB", "18dB", "19dB",
			"20dB"
		};

		// Token: 0x040000D5 RID: 213
		private static string[] _CompressorReleases = new string[]
		{
			"10ms", "20ms", "25ms", "30ms", "50ms", "100ms", "120ms", "150ms", "175ms", "200ms",
			"250ms", "300ms", "350ms", "400ms", "450ms", "500ms", "550ms", "600ms", "650ms", "700ms",
			"750ms", "800ms", "850ms", "900ms", "1000ms"
		};

		// Token: 0x040000D6 RID: 214
		private static string[] _CompressorAttacks = new string[]
		{
			"10ms", "15ms", "20ms", "25ms", "30ms", "35ms", "40ms", "45ms", "50ms", "55ms",
			"60ms", "65ms", "70ms", "75ms", "80ms", "85ms", "90ms", "95ms", "100ms", "105ms",
			"110ms", "115ms", "120ms"
		};

		// Token: 0x040000D7 RID: 215
		private static string[] _CompressorGains = new string[]
		{
			"0.0dB", "1dB", "2dB", "3dB", "4dB", "5dB", "6dB", "7dB", "8dB", "9dB",
			"10dB", "11dB", "12dB", "13dB", "14dB", "15dB", "16dB", "17dB", "18dB", "19dB",
			"20dB", "21dB", "22dB", "23dB", "24dB"
		};

		// Token: 0x040000D8 RID: 216
		private static string[] _DelayStrings = new string[1444];

		// Token: 0x040000D9 RID: 217
		private static string[] _faderStrings = new string[]
		{
			"OFF", "-70.0dB", "-65.0dB", "-60.0dB", "-50.0dB", "-45.0dB", "-40.0dB", "-30.0dB", "-29.0dB", "-28.0dB",
			"-27.0dB", "-26.0dB", "-25.0dB", "-24.0dB", "-23.0dB", "-22.0dB", "-21.0dB", "-20.0dB", "-19.5dB", "-19.0dB",
			"-18.5dB", "-18.0dB", "-17.5dB", "-17.0dB", "-16.5dB", "-16.0dB", "-15.5dB", "-15.0dB", "-14.5dB", "-14.0dB",
			"-13.5dB", "-13.0dB", "-12.5dB", "-12.0dB", "-11.5dB", "-11.0dB", "-10.5dB", "-10.0dB", "-9.5dB", "-9.2dB",
			"-9.0dB", "-8.7dB", "-8.5dB", "-8.2dB", "-8.0dB", "-7.8dB", "-7.5dB", "-7.2dB", "-7.0dB", "-6.5dB",
			"-6.0dB", "-5.5dB", "-5.0dB", "-4.5dB", "-4.0dB", "-3.0dB", "-2.0dB", "-1.5dB", "-1.0dB", "-0.5dB",
			"0.0dB", "0.5dB", "1.0dB", "1.5dB", "2.0dB", "2.5dB", "3.0dB", "3.5dB", "4.0dB", "5.0dB",
			"5.5dB", "6.0dB", "6.5dB", "7.0dB", "7.5dB", "8.0dB", "8.5dB", "9.0dB", "9.5dB", "9.7dB",
			"10.0dB"
		};

		// Token: 0x040000DA RID: 218
		private static string[] _faderTickStrings = new string[]
		{
			"OFF", "-70", "", "", "", "", "", "", "", "",
			"", "", "-25", "", "", "", "", "", "", "",
			"", "-18", "", "", "", "", "", "", "", "",
			"", "-13", "", "", "", "", "", "", "", "",
			" -9", "", "", "", "", "", "", "", "", "",
			" -6", "", "", "", "", "", "", "", "", "",
			"  0", "", "", "", "", "", "", "", "", "",
			"", " +6", "", "", "", "", "", "", "", "",
			"+10"
		};

		// Token: 0x040000DB RID: 219
		private static string[] _meterStrings = new string[]
		{
			"Clip", "+10", "+7", "+4", "+2", "0", "-2", "-4", "-7", "-10",
			"-20", "-30"
		};

		// Token: 0x040000DC RID: 220
		private static byte[] _meterDeviceToPageConverter = new byte[]
		{
			0, 0, 0, 1, 2, 2, 2, 3, 3, 3,
			3, 4, 4, 4, 5, 5, 5, 6, 6, 6,
			6, 7, 7, 7, 8, 8, 8, 9, 9, 9,
			9, 10, 10, 10, 11, 11, 11, 12, 12, 12,
			12
		};

		// Token: 0x040000DD RID: 221
		private static string[] _compressorMeterStrings = new string[]
		{
			"4", "8", "13", "17", "21", "25", "30", "34", "38", "42",
			"46", "50"
		};

		// Token: 0x040000DE RID: 222
		private static string[] _typeFilter = new string[] { "Peak", "Low", "High" };

		// Token: 0x040000DF RID: 223
		private static string[] _GEQFrequenceStrings = new string[]
		{
			"20", "25", "31.5", "40", "50", "63", "80", "100", "125", "160",
			"200", "250", "315", "400", "500", "630", "800", "1K", "1.25K", "1.6K",
			"2K", "2.5K", "3.15K", "4K", "5K", "6.3K", "8K", "10K", "12.5K", "16K",
			"20K"
		};

		// Token: 0x040000E0 RID: 224
		private static string[] _GEQGainValueStrings = new string[]
		{
			"-24", "-23", "-22", "-21", "-20", "-19", "-18", "-17", "-16", "-15",
			"-14", "-13", "-12", "-11", "-10", "-9", "-8", "-7", "-6", "-5",
			"-4", "-3", "-2", "-1", "0", "1", "2", "3", "4", "5",
			"6", "7", "8", "9", "10", "11", "12", "13", "14", "15",
			"16", "17", "18", "19", "20", "21", "22", "23", "24"
		};

		// Token: 0x040000E1 RID: 225
		private static string[] _AutoMixActiveTimeStrings = new string[]
		{
			"10ms", "20ms", "25ms", "50ms", "100ms", "200ms", "300ms", "400ms", "500ms", "600ms",
			"700ms", "800ms", "900ms", "1000ms", "1200ms", "1500ms", "2000ms", "2500ms", "3000ms", "3500ms",
			"4000ms", "4500ms", "5000ms", "5500ms", "6000ms"
		};

		// Token: 0x040000E2 RID: 226
		private static string[] _DuckerThresholds = new string[]
		{
			"-80dB", "-79dB", "-78dB", "-77dB", "-76dB", "-75dB", "-74dB", "-73dB", "-72dB", "-71dB",
			"-70dB", "-69dB", "-68dB", "-67dB", "-66dB", "-65dB", "-64dB", "-63dB", "-62dB", "-61dB",
			"-60dB", "-59dB", "-58dB", "-57dB", "-56dB", "-55dB", "-54dB", "-53dB", "-52dB", "-51dB",
			"-50dB", "-49dB", "-48dB", "-47dB", "-46dB", "-45dB", "-44dB", "-43dB", "-42dB", "-41dB",
			"-40dB", "-39dB", "-38dB", "-37dB", "-36dB", "-35dB", "-34dB", "-33dB", "-32dB", "-31dB",
			"-30dB", "-29dB", "-28dB", "-27dB", "-26dB", "-25dB", "-24dB", "-23dB", "-22dB", "-21dB",
			"-20dB", "-19dB", "-18dB", "-17dB", "-16dB", "-15dB", "-14dB", "-13dB", "-12dB", "-11dB",
			"-10dB", "-9dB", "-8dB", "-7dB", "-6dB", "-5dB", "-4dB", "-3dB", "-2dB", "-1dB",
			"0dB"
		};

		// Token: 0x040000E3 RID: 227
		private static string[] _DuckerDepth = new string[]
		{
			"-60dB", "-59dB", "-58dB", "-57dB", "-56dB", "-55dB", "-54dB", "-53dB", "-52dB", "-51dB",
			"-50dB", "-49dB", "-48dB", "-47dB", "-46dB", "-45dB", "-44dB", "-43dB", "-42dB", "-41dB",
			"-40dB", "-39dB", "-38dB", "-37dB", "-36dB", "-35dB", "-34dB", "-33dB", "-32dB", "-31dB",
			"-30dB", "-29dB", "-28dB", "-27dB", "-26dB", "-25dB", "-24dB", "-23dB", "-22dB", "-21dB",
			"-20dB", "-19dB", "-18dB", "-17dB", "-16dB", "-15dB", "-14dB", "-13dB", "-12dB", "-11dB",
			"-10dB", "-9dB", "-8dB", "-7dB", "-6dB", "-5dB", "-4dB", "-3dB", "-2dB", "-1dB",
			"0dB"
		};

		// Token: 0x040000E4 RID: 228
		private static string[] _DuckerAttack = new string[]
		{
			"10mS", "20mS", "25mS", "30mS", "50mS", "100mS", "120mS", "150mS", "175mS", "200mS",
			"250mS", "300mS", "350mS", "400mS", "450mS", "500mS", "550mS", "600mS", "650mS", "700mS",
			"750mS", "800mS", "850mS", "900mS", "1000mS"
		};

		// Token: 0x040000E5 RID: 229
		private static string[] _DuckerRelease = new string[]
		{
			"10mS", "20mS", "25mS", "50mS", "100mS", "200mS", "300mS", "400mS", "500mS", "600mS",
			"700mS", "800mS", "900mS", "1000mS", "1200mS", "1500mS", "2000mS", "2500mS", "3000mS", "3500mS",
			"4000mS", "4500mS", "5000mS", "5500mS", "6000mS"
		};

		// Token: 0x040000E6 RID: 230
		public const double DELAY_CONST = 0.208333333;

		// Token: 0x040000E7 RID: 231
		public const double DELAY_CONST_M = 343.5;
	}
}
