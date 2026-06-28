using System;
using System.Collections.Generic;

namespace T2208.DeviceCommuncation
{
	// Token: 0x020000B1 RID: 177
	public static class CommandConst
	{
		// Token: 0x17000312 RID: 786
		// (get) Token: 0x06000893 RID: 2195 RVA: 0x00026664 File Offset: 0x00024864
		public static byte CMD_RESERVED
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17000313 RID: 787
		// (get) Token: 0x06000894 RID: 2196 RVA: 0x00026678 File Offset: 0x00024878
		public static byte CMD_FatChannel
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17000314 RID: 788
		// (get) Token: 0x06000895 RID: 2197 RVA: 0x0002668C File Offset: 0x0002488C
		public static byte CMD_GATE
		{
			get
			{
				return 2;
			}
		}

		// Token: 0x17000315 RID: 789
		// (get) Token: 0x06000896 RID: 2198 RVA: 0x000266A0 File Offset: 0x000248A0
		public static byte CMD_COMP_LIMIT
		{
			get
			{
				return 3;
			}
		}

		// Token: 0x17000316 RID: 790
		// (get) Token: 0x06000897 RID: 2199 RVA: 0x000266B4 File Offset: 0x000248B4
		public static byte CMD_Equalizer
		{
			get
			{
				return 4;
			}
		}

		// Token: 0x17000317 RID: 791
		// (get) Token: 0x06000898 RID: 2200 RVA: 0x000266C8 File Offset: 0x000248C8
		public static byte CMD_MUTE_GAIN
		{
			get
			{
				return 5;
			}
		}

		// Token: 0x17000318 RID: 792
		// (get) Token: 0x06000899 RID: 2201 RVA: 0x000266DC File Offset: 0x000248DC
		public static byte CMD_BusMixer
		{
			get
			{
				return 6;
			}
		}

		// Token: 0x17000319 RID: 793
		// (get) Token: 0x0600089A RID: 2202 RVA: 0x000266F0 File Offset: 0x000248F0
		public static byte CMD_LCDBlackLight
		{
			get
			{
				return 7;
			}
		}

		// Token: 0x1700031A RID: 794
		// (get) Token: 0x0600089B RID: 2203 RVA: 0x00026704 File Offset: 0x00024904
		public static byte CMD_DC48V
		{
			get
			{
				return 8;
			}
		}

		// Token: 0x1700031B RID: 795
		// (get) Token: 0x0600089C RID: 2204 RVA: 0x00026718 File Offset: 0x00024918
		public static byte CMD_DefaultPreset
		{
			get
			{
				return 9;
			}
		}

		// Token: 0x1700031C RID: 796
		// (get) Token: 0x0600089D RID: 2205 RVA: 0x0002672C File Offset: 0x0002492C
		public static byte CMD_DFXChannel
		{
			get
			{
				return 10;
			}
		}

		// Token: 0x1700031D RID: 797
		// (get) Token: 0x0600089E RID: 2206 RVA: 0x00026740 File Offset: 0x00024940
		public static byte CMD_SOLO
		{
			get
			{
				return 11;
			}
		}

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x0600089F RID: 2207 RVA: 0x00026754 File Offset: 0x00024954
		public static byte CMD_allFadergroupSelect
		{
			get
			{
				return 12;
			}
		}

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x060008A0 RID: 2208 RVA: 0x00026768 File Offset: 0x00024968
		public static byte CMD_allFadergroupGain
		{
			get
			{
				return 13;
			}
		}

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x060008A1 RID: 2209 RVA: 0x0002677C File Offset: 0x0002497C
		public static byte CMD_AllAuxPost
		{
			get
			{
				return 14;
			}
		}

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x060008A2 RID: 2210 RVA: 0x00026790 File Offset: 0x00024990
		public static byte CMD_PRESET_REMOTE_SAVE_START
		{
			get
			{
				return 15;
			}
		}

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x060008A3 RID: 2211 RVA: 0x000267A4 File Offset: 0x000249A4
		public static byte CMD_GEQChannel
		{
			get
			{
				return 16;
			}
		}

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x060008A4 RID: 2212 RVA: 0x000267B8 File Offset: 0x000249B8
		public static byte CMD_BBEFunction
		{
			get
			{
				return 17;
			}
		}

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x060008A5 RID: 2213 RVA: 0x000267CC File Offset: 0x000249CC
		public static byte CMD_ReadStatus
		{
			get
			{
				return 18;
			}
		}

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x060008A6 RID: 2214 RVA: 0x000267E0 File Offset: 0x000249E0
		public static byte CMD_ReadCurrentScene
		{
			get
			{
				return 19;
			}
		}

		// Token: 0x17000326 RID: 806
		// (get) Token: 0x060008A7 RID: 2215 RVA: 0x000267F4 File Offset: 0x000249F4
		public static byte CMD_AckCommd
		{
			get
			{
				return 20;
			}
		}

		// Token: 0x17000327 RID: 807
		// (get) Token: 0x060008A8 RID: 2216 RVA: 0x00026808 File Offset: 0x00024A08
		public static byte CMD_ClearSolo
		{
			get
			{
				return 21;
			}
		}

		// Token: 0x17000328 RID: 808
		// (get) Token: 0x060008A9 RID: 2217 RVA: 0x0002681C File Offset: 0x00024A1C
		public static byte CMD_SavePreset
		{
			get
			{
				return 22;
			}
		}

		// Token: 0x17000329 RID: 809
		// (get) Token: 0x060008AA RID: 2218 RVA: 0x00026830 File Offset: 0x00024A30
		public static byte CMD_DeletePreset
		{
			get
			{
				return 23;
			}
		}

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x060008AB RID: 2219 RVA: 0x00026844 File Offset: 0x00024A44
		public static byte CMD_ReadPresetList
		{
			get
			{
				return 24;
			}
		}

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x060008AC RID: 2220 RVA: 0x00026858 File Offset: 0x00024A58
		public static byte CMD_SetChannelName
		{
			get
			{
				return 25;
			}
		}

		// Token: 0x1700032C RID: 812
		// (get) Token: 0x060008AD RID: 2221 RVA: 0x0002686C File Offset: 0x00024A6C
		public static byte CMD_DigltalOut
		{
			get
			{
				return 26;
			}
		}

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x060008AE RID: 2222 RVA: 0x00026880 File Offset: 0x00024A80
		public static byte CMD_LoadSencePreset
		{
			get
			{
				return 28;
			}
		}

		// Token: 0x1700032E RID: 814
		// (get) Token: 0x060008AF RID: 2223 RVA: 0x00026894 File Offset: 0x00024A94
		public static byte CMD_LoadDSPPreset
		{
			get
			{
				return 29;
			}
		}

		// Token: 0x1700032F RID: 815
		// (get) Token: 0x060008B0 RID: 2224 RVA: 0x000268A8 File Offset: 0x00024AA8
		public static byte CMD_LoadDfxPreset
		{
			get
			{
				return 30;
			}
		}

		// Token: 0x17000330 RID: 816
		// (get) Token: 0x060008B1 RID: 2225 RVA: 0x000268BC File Offset: 0x00024ABC
		public static byte CMD_LoadGEQPreset
		{
			get
			{
				return 31;
			}
		}

		// Token: 0x17000331 RID: 817
		// (get) Token: 0x060008B2 RID: 2226 RVA: 0x000268D0 File Offset: 0x00024AD0
		public static byte CMD_FlatEQCommand
		{
			get
			{
				return 32;
			}
		}

		// Token: 0x17000332 RID: 818
		// (get) Token: 0x060008B3 RID: 2227 RVA: 0x000268E4 File Offset: 0x00024AE4
		public static byte CMD_SyncCommand
		{
			get
			{
				return 33;
			}
		}

		// Token: 0x17000333 RID: 819
		// (get) Token: 0x060008B4 RID: 2228 RVA: 0x000268F8 File Offset: 0x00024AF8
		public static byte CMD_ResetCommand
		{
			get
			{
				return 34;
			}
		}

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x060008B5 RID: 2229 RVA: 0x0002690C File Offset: 0x00024B0C
		public static byte CMD_PCLocalPresetLoad
		{
			get
			{
				return 35;
			}
		}

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x060008B6 RID: 2230 RVA: 0x00026920 File Offset: 0x00024B20
		public static byte CMD_SetDeviceName
		{
			get
			{
				return 36;
			}
		}

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x060008B7 RID: 2231 RVA: 0x00026934 File Offset: 0x00024B34
		public static byte CMD_ReadDeviceName
		{
			get
			{
				return 37;
			}
		}

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x060008B8 RID: 2232 RVA: 0x00026948 File Offset: 0x00024B48
		public static byte CMD_Copy
		{
			get
			{
				return 38;
			}
		}

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x060008B9 RID: 2233 RVA: 0x0002695C File Offset: 0x00024B5C
		public static byte CMD_ChannelButtonClick
		{
			get
			{
				return 39;
			}
		}

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x060008BA RID: 2234 RVA: 0x00026970 File Offset: 0x00024B70
		public static byte CMD_ReadLimitMeter
		{
			get
			{
				return 40;
			}
		}

		// Token: 0x1700033A RID: 826
		// (get) Token: 0x060008BB RID: 2235 RVA: 0x00026984 File Offset: 0x00024B84
		public static byte CMD_ReadMeter
		{
			get
			{
				return 41;
			}
		}

		// Token: 0x1700033B RID: 827
		// (get) Token: 0x060008BC RID: 2236 RVA: 0x00026998 File Offset: 0x00024B98
		public static byte CMD_GroupSet
		{
			get
			{
				return 42;
			}
		}

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x060008BD RID: 2237 RVA: 0x000269AC File Offset: 0x00024BAC
		public static byte CMD_bGroupSet
		{
			get
			{
				return 43;
			}
		}

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x060008BE RID: 2238 RVA: 0x000269C0 File Offset: 0x00024BC0
		public static byte CMD_ReadVersionCmd
		{
			get
			{
				return 44;
			}
		}

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x060008BF RID: 2239 RVA: 0x000269D4 File Offset: 0x00024BD4
		public static byte CMD_ChangeSceneCmd
		{
			get
			{
				return 45;
			}
		}

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x060008C0 RID: 2240 RVA: 0x000269E8 File Offset: 0x00024BE8
		public static byte CMD_MemoryExport
		{
			get
			{
				return 47;
			}
		}

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x060008C1 RID: 2241 RVA: 0x000269FC File Offset: 0x00024BFC
		public static byte CMD_MemoryExportAck
		{
			get
			{
				return 48;
			}
		}

		// Token: 0x17000341 RID: 833
		// (get) Token: 0x060008C2 RID: 2242 RVA: 0x00026A10 File Offset: 0x00024C10
		public static byte CMD_MemoryImport
		{
			get
			{
				return 49;
			}
		}

		// Token: 0x17000342 RID: 834
		// (get) Token: 0x060008C3 RID: 2243 RVA: 0x00026A24 File Offset: 0x00024C24
		public static byte CMD_LoadlocalFinish
		{
			get
			{
				return 51;
			}
		}

		// Token: 0x17000343 RID: 835
		// (get) Token: 0x060008C4 RID: 2244 RVA: 0x00026A38 File Offset: 0x00024C38
		public static byte CMD_ReadeSysGUIindex
		{
			get
			{
				return 52;
			}
		}

		// Token: 0x17000344 RID: 836
		// (get) Token: 0x060008C5 RID: 2245 RVA: 0x00026A4C File Offset: 0x00024C4C
		public static byte CMD_AutoMixAssign
		{
			get
			{
				return 55;
			}
		}

		// Token: 0x17000345 RID: 837
		// (get) Token: 0x060008C6 RID: 2246 RVA: 0x00026A60 File Offset: 0x00024C60
		public static byte CMD_Matrix
		{
			get
			{
				return 62;
			}
		}

		// Token: 0x17000346 RID: 838
		// (get) Token: 0x060008C7 RID: 2247 RVA: 0x00009DD5 File Offset: 0x00007FD5
		// (set) Token: 0x060008C8 RID: 2248 RVA: 0x00009DDC File Offset: 0x00007FDC
		public static Dictionary<int, int> DataTypeLengthDictionary { get; private set; } = new Dictionary<int, int>
		{
			{ 245, 3869 },
			{ 247, 395 },
			{ 248, 779 },
			{ 249, 1675 },
			{ 250, 779 }
		};

		// Token: 0x17000347 RID: 839
		// (get) Token: 0x060008C9 RID: 2249 RVA: 0x00026678 File Offset: 0x00024878
		public static byte DEVE_PAGE_HOME
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17000348 RID: 840
		// (get) Token: 0x060008CA RID: 2250 RVA: 0x0002668C File Offset: 0x0002488C
		public static byte DEVE_PAGE_MIXER
		{
			get
			{
				return 2;
			}
		}

		// Token: 0x17000349 RID: 841
		// (get) Token: 0x060008CB RID: 2251 RVA: 0x000266A0 File Offset: 0x000248A0
		public static byte DEVE_PAGE_ASSIGN
		{
			get
			{
				return 3;
			}
		}

		// Token: 0x1700034A RID: 842
		// (get) Token: 0x060008CC RID: 2252 RVA: 0x000266B4 File Offset: 0x000248B4
		public static byte DEVE_PAGE_GATE
		{
			get
			{
				return 4;
			}
		}

		// Token: 0x1700034B RID: 843
		// (get) Token: 0x060008CD RID: 2253 RVA: 0x000266C8 File Offset: 0x000248C8
		public static byte DEVE_PAGE_CHANNEL
		{
			get
			{
				return 5;
			}
		}

		// Token: 0x1700034C RID: 844
		// (get) Token: 0x060008CE RID: 2254 RVA: 0x000266DC File Offset: 0x000248DC
		public static byte DEVE_PAGE_EQUALIZER
		{
			get
			{
				return 6;
			}
		}

		// Token: 0x1700034D RID: 845
		// (get) Token: 0x060008CF RID: 2255 RVA: 0x000266F0 File Offset: 0x000248F0
		public static byte DEVE_PAGE_GEQ
		{
			get
			{
				return 7;
			}
		}

		// Token: 0x1700034E RID: 846
		// (get) Token: 0x060008D0 RID: 2256 RVA: 0x00026704 File Offset: 0x00024904
		public static byte DEVE_PAGE_DFX
		{
			get
			{
				return 8;
			}
		}

		// Token: 0x1700034F RID: 847
		// (get) Token: 0x060008D1 RID: 2257 RVA: 0x00026718 File Offset: 0x00024918
		public static byte DEVE_PAGE_SYSTEM
		{
			get
			{
				return 9;
			}
		}

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x060008D2 RID: 2258 RVA: 0x0002672C File Offset: 0x0002492C
		public static byte DEVE_PAGE_DIGITAL
		{
			get
			{
				return 10;
			}
		}

		// Token: 0x17000351 RID: 849
		// (get) Token: 0x060008D3 RID: 2259 RVA: 0x00026740 File Offset: 0x00024940
		public static byte DEVE_PAGE_COPY
		{
			get
			{
				return 11;
			}
		}

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x060008D4 RID: 2260 RVA: 0x00026754 File Offset: 0x00024954
		public static byte DEVE_PAGE_ROUTE
		{
			get
			{
				return 12;
			}
		}

		// Token: 0x17000353 RID: 851
		// (get) Token: 0x060008D5 RID: 2261 RVA: 0x00026768 File Offset: 0x00024968
		public static byte DEVE_PAGE_GROUP
		{
			get
			{
				return 13;
			}
		}

		// Token: 0x17000354 RID: 852
		// (get) Token: 0x060008D6 RID: 2262 RVA: 0x0002677C File Offset: 0x0002497C
		public static byte DEVE_PAGE_LOADSAVE
		{
			get
			{
				return 14;
			}
		}

		// Token: 0x17000355 RID: 853
		// (get) Token: 0x060008D7 RID: 2263 RVA: 0x00026790 File Offset: 0x00024990
		public static byte DEVE_PAGE_KeyBoard
		{
			get
			{
				return 15;
			}
		}

		// Token: 0x17000356 RID: 854
		// (get) Token: 0x060008D8 RID: 2264 RVA: 0x00026808 File Offset: 0x00024A08
		public static byte DEVE_PAGE_VIEW_ALL_LIM_SIG
		{
			get
			{
				return 21;
			}
		}

		// Token: 0x17000357 RID: 855
		// (get) Token: 0x060008D9 RID: 2265 RVA: 0x0002681C File Offset: 0x00024A1C
		public static byte DEVE_PAGE_DC48VPower
		{
			get
			{
				return 22;
			}
		}

		// Token: 0x17000358 RID: 856
		// (get) Token: 0x060008DA RID: 2266 RVA: 0x00026830 File Offset: 0x00024A30
		public static byte DEVE_PAGE_StartUP
		{
			get
			{
				return 23;
			}
		}

		// Token: 0x17000359 RID: 857
		// (get) Token: 0x060008DB RID: 2267 RVA: 0x00026844 File Offset: 0x00024A44
		public static byte DEVE_PAGE_DCA_LONGFADER
		{
			get
			{
				return 24;
			}
		}

		// Token: 0x1700035A RID: 858
		// (get) Token: 0x060008DC RID: 2268 RVA: 0x00026858 File Offset: 0x00024A58
		public static byte DEVE_PAGE_COMP
		{
			get
			{
				return 25;
			}
		}

		// Token: 0x1700035B RID: 859
		// (get) Token: 0x060008DD RID: 2269 RVA: 0x0002686C File Offset: 0x00024A6C
		public static byte DEVE_PAGE_InstallMatrix
		{
			get
			{
				return 26;
			}
		}

		// Token: 0x1700035C RID: 860
		// (get) Token: 0x060008DE RID: 2270 RVA: 0x00026880 File Offset: 0x00024A80
		public static byte DEVE_PAGE_AutoMix
		{
			get
			{
				return 28;
			}
		}

		// Token: 0x1700035D RID: 861
		// (get) Token: 0x060008DF RID: 2271 RVA: 0x000268A8 File Offset: 0x00024AA8
		public static byte DEVE_PAGE_Matrix
		{
			get
			{
				return 30;
			}
		}

		// Token: 0x1700035E RID: 862
		// (get) Token: 0x060008E0 RID: 2272 RVA: 0x00009DE4 File Offset: 0x00007FE4
		public static byte CMD_SetDeviceID
		{
			get
			{
				return 38;
			}
		}

		// Token: 0x1700035F RID: 863
		// (get) Token: 0x060008E1 RID: 2273 RVA: 0x00009DE8 File Offset: 0x00007FE8
		public static byte CMD_ReadDeviceSettings
		{
			get
			{
				return 87;
			}
		}

		// Token: 0x17000360 RID: 864
		// (get) Token: 0x060008E2 RID: 2274 RVA: 0x00009DEC File Offset: 0x00007FEC
		public static byte CMD_SetDanteName
		{
			get
			{
				return 88;
			}
		}

		// Token: 0x17000361 RID: 865
		// (get) Token: 0x060008E3 RID: 2275 RVA: 0x00009DF0 File Offset: 0x00007FF0
		public static byte CMD_FX
		{
			get
			{
				return 10;
			}
		}

		// Token: 0x17000362 RID: 866
		// (get) Token: 0x060008E4 RID: 2276 RVA: 0x00009DF4 File Offset: 0x00007FF4
		public static byte CMD_GEQFlat
		{
			get
			{
				return 28;
			}
		}

		// Token: 0x17000363 RID: 867
		// (get) Token: 0x060008E5 RID: 2277 RVA: 0x00009DF8 File Offset: 0x00007FF8
		public static byte CMD_Link
		{
			get
			{
				return 39;
			}
		}

		// Token: 0x17000364 RID: 868
		// (get) Token: 0x060008E6 RID: 2278 RVA: 0x00009DFC File Offset: 0x00007FFC
		public static byte CMD_AuxPanOnly
		{
			get
			{
				return 7;
			}
		}

		// Token: 0x17000365 RID: 869
		// (get) Token: 0x060008E7 RID: 2279 RVA: 0x00009DFF File Offset: 0x00007FFF
		public static byte CMD_AllPresetName
		{
			get
			{
				return 29;
			}
		}

		// Token: 0x17000366 RID: 870
		// (get) Token: 0x060008E8 RID: 2280 RVA: 0x00009E03 File Offset: 0x00008003
		public static byte CMD_LoadPreset
		{
			get
			{
				return 23;
			}
		}
	}
}
