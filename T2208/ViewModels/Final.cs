using System;
using System.Collections.Generic;
using System.Linq;

namespace T2208.ViewModels
{
	// Token: 0x02000036 RID: 54
	internal class Final
	{
		// Token: 0x06000233 RID: 563 RVA: 0x00003B79 File Offset: 0x00001D79
		public static void SelectChBtn(int chnum)
		{
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000234 RID: 564 RVA: 0x00004F20 File Offset: 0x00003120
		public static int MaxDigitalOutput
		{
			get
			{
				return 30;
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000235 RID: 565 RVA: 0x00004F24 File Offset: 0x00003124
		private static int MaxAux
		{
			get
			{
				return Final.MaxAuxMain - 1;
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000236 RID: 566 RVA: 0x00004F2D File Offset: 0x0000312D
		private static int MaxLinkAux
		{
			get
			{
				return Final.MaxAux * 2;
			}
		}

		// Token: 0x06000237 RID: 567 RVA: 0x00004F36 File Offset: 0x00003136
		public static bool CheckIsFx(int index, bool isLink = false)
		{
			return index > Final.GetMaxInputCh(isLink) - 1 && index < Final.GetMaxInputCh(isLink) + Final.GetMaxFx(isLink);
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00004F56 File Offset: 0x00003156
		public static bool GetHasDc48(int channelIndex, bool isLink)
		{
			return channelIndex < Final.GetMaxInputCh(isLink);
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00004F61 File Offset: 0x00003161
		public static int GetMaxAux(bool isLink)
		{
			return isLink ? Final.MaxLinkAux : Final.MaxAux;
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00004F72 File Offset: 0x00003172
		public static int GetMaxAuxFxMain(bool isLink)
		{
			return isLink ? Final.MaxLinkAuxFxMain : Final.MaxAuxFxMain;
		}

		// Token: 0x0600023B RID: 571 RVA: 0x00004F83 File Offset: 0x00003183
		public static int GetMaxAuxMain(bool isLink)
		{
			return isLink ? (Final.MaxLinkAux + 1) : (Final.MaxAux + 1);
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00004F98 File Offset: 0x00003198
		public static int GetMaxCh(bool isLink)
		{
			return isLink ? Final.MaxLinkCh : 51;
		}

		// Token: 0x0600023D RID: 573 RVA: 0x00004FA6 File Offset: 0x000031A6
		public static int GetMaxFx(bool isLink)
		{
			return isLink ? Final.MaxLinkFx : 2;
		}

		// Token: 0x0600023E RID: 574 RVA: 0x00004FB3 File Offset: 0x000031B3
		public static int GetMaxInputCh(bool isLink)
		{
			return isLink ? Final.MaxLinkInputCh : 24;
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00004FC1 File Offset: 0x000031C1
		public static int GetMaxMain(bool isLink)
		{
			return isLink ? Final.MaxLinkMain : 1;
		}

		// Token: 0x06000240 RID: 576 RVA: 0x00004FCE File Offset: 0x000031CE
		public static int GetMaxOutput(bool isLink)
		{
			return isLink ? Final.MaxLinkOutput : 12;
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00015264 File Offset: 0x00013464
		public static string[] GetNameArray(GroupType groupType = GroupType.AllChannel)
		{
			string[] array;
			switch (groupType)
			{
			case GroupType.AllChannel:
				array = Final.ChannelsName;
				break;
			case GroupType.AuxFx:
				array = null;
				break;
			case GroupType.AuxFxMain:
			{
				bool flag = Final._auxFxMainsName != null;
				if (flag)
				{
					array = Final._auxFxMainsName;
				}
				else
				{
					Final._auxFxMainsName = new string[Final.MaxAuxFxMain];
					Final.FxNames.CopyTo(Final._auxFxMainsName, 0);
					Final.AuxName.CopyTo(Final._auxFxMainsName, Final.FxNames.Length);
					array = Final._auxFxMainsName;
				}
				break;
			}
			case GroupType.AuxMain:
			{
				bool flag2 = Final._auxMainsName != null;
				if (flag2)
				{
					array = Final._auxMainsName;
				}
				else
				{
					Final._auxMainsName = new string[Final.MaxAuxMain];
					Array.Copy(Final.AuxName, 0, Final._auxMainsName, 0, Final.MaxAux);
					Final._auxMainsName[Final.MaxAuxMain - 1] = Final.MainName;
					array = Final._auxMainsName;
				}
				break;
			}
			case GroupType.Fx:
				array = Final.FxNames;
				break;
			case GroupType.AllOutput:
			{
				bool flag3 = Final._outputChannelsName != null;
				if (flag3)
				{
					array = Final._outputChannelsName;
				}
				else
				{
					Final._outputChannelsName = new string[12];
					Array.Copy(Final.OutputannelsName, 0, Final._outputChannelsName, 0, 12);
					array = Final._outputChannelsName;
				}
				break;
			}
			case GroupType.LinkAllChannel:
				array = Final.LinkChannelsName;
				break;
			case GroupType.LinkAuxFx:
				array = null;
				break;
			case GroupType.LinkAuxFxMain:
			{
				bool flag4 = Final._linkAuxFxMainsName != null;
				if (flag4)
				{
					array = Final._linkAuxFxMainsName;
				}
				else
				{
					Final._linkAuxFxMainsName = new string[Final.MaxLinkAuxFxMain];
					Array.Copy(Final.LinkChannelsName, Final.MaxLinkInputCh, Final._linkAuxFxMainsName, 0, Final.MaxLinkAuxFxMain);
					array = Final._linkAuxFxMainsName;
				}
				break;
			}
			case GroupType.LinkAuxMain:
			{
				bool flag5 = Final._linkAuxMainsName != null;
				if (flag5)
				{
					array = Final._linkAuxMainsName;
				}
				else
				{
					Final._linkAuxMainsName = new string[Final.MaxLinkAuxMain];
					Array.Copy(Final.AuxLinkName, 0, Final._linkAuxMainsName, 0, Final.MaxLinkAux);
					Final._linkAuxMainsName[Final.MaxLinkAuxMain - 1] = Final.MainName;
					array = Final._linkAuxMainsName;
				}
				break;
			}
			case GroupType.LinkFx:
				array = Final.LinkFxName;
				break;
			case GroupType.LinkAllOutput:
			{
				bool flag6 = Final._linkOutputannelsName != null;
				if (flag6)
				{
					array = Final._linkOutputannelsName;
				}
				else
				{
					Final._linkOutputannelsName = new string[Final.MaxLinkOutput];
					Array.Copy(Final.LinkOutputannelsName, 0, Final._linkOutputannelsName, 0, Final.MaxLinkOutput);
					array = Final._linkOutputannelsName;
				}
				break;
			}
			default:
				array = null;
				break;
			}
			return array;
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000242 RID: 578 RVA: 0x000154D4 File Offset: 0x000136D4
		public static string[] AuxLinkName
		{
			get
			{
				string[] array;
				if ((array = Final._auxLinkName) == null)
				{
					array = (Final._auxLinkName = (from i in Enumerable.Range(0, Final.MaxLinkAux)
						select string.Format("AUX{0}", i + 1)).ToArray<string>());
				}
				return array;
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000243 RID: 579 RVA: 0x00015524 File Offset: 0x00013724
		public static string[] AuxName
		{
			get
			{
				string[] array;
				if ((array = Final._auxName) == null)
				{
					array = (Final._auxName = (from i in Enumerable.Range(0, Final.MaxAux)
						select string.Format("AUX{0}", i + 1)).ToArray<string>());
				}
				return array;
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000244 RID: 580 RVA: 0x00015574 File Offset: 0x00013774
		public static string[] FxNames
		{
			get
			{
				string[] array;
				if ((array = Final._fxName) == null)
				{
					array = (Final._fxName = (from i in Enumerable.Range(0, 2)
						select string.Format("FX{0}", i + 1)).ToArray<string>());
				}
				return array;
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000245 RID: 581 RVA: 0x000155C0 File Offset: 0x000137C0
		public static string[] LinkFxName
		{
			get
			{
				string[] array;
				if ((array = Final._linkFxName) == null)
				{
					array = (Final._linkFxName = (from i in Enumerable.Range(0, Final.MaxLinkFx)
						select string.Format("FX{0}", i + 1)).ToArray<string>());
				}
				return array;
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000246 RID: 582 RVA: 0x00015610 File Offset: 0x00013810
		public static string[] OutputannelsName
		{
			get
			{
				string[] array;
				if ((array = Final._outputChannelsName) == null)
				{
					array = (Final._outputChannelsName = (from i in Enumerable.Range(0, 12)
						select string.Format("Output{0}", i + 1)).ToArray<string>());
				}
				return array;
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000247 RID: 583 RVA: 0x00015660 File Offset: 0x00013860
		public static string[] LinkOutputannelsName
		{
			get
			{
				string[] array;
				if ((array = Final._linkOutputannelsName) == null)
				{
					array = (Final._linkOutputannelsName = (from i in Enumerable.Range(0, Final.MaxLinkOutput)
						select string.Format("Output{0}", i + 1)).ToArray<string>());
				}
				return array;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000248 RID: 584 RVA: 0x00004FDC File Offset: 0x000031DC
		public static int MaxAuxFxMain
		{
			get
			{
				return 27;
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000249 RID: 585 RVA: 0x00004FE0 File Offset: 0x000031E0
		public static int MaxAuxMain
		{
			get
			{
				return Final.MaxAuxFxMain - 2;
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x0600024A RID: 586 RVA: 0x00004FE9 File Offset: 0x000031E9
		public static int MaxLinkAuxFxMain
		{
			get
			{
				return 53;
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x0600024B RID: 587 RVA: 0x00004FED File Offset: 0x000031ED
		public static int MaxLinkAuxMain
		{
			get
			{
				return Final.MaxLinkAuxFxMain - Final.MaxLinkFx;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x0600024C RID: 588 RVA: 0x00004FFA File Offset: 0x000031FA
		public static int MaxLinkCh
		{
			get
			{
				return 101;
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x0600024D RID: 589 RVA: 0x00004FFE File Offset: 0x000031FE
		public static int MaxLinkFx
		{
			get
			{
				return 4;
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x0600024E RID: 590 RVA: 0x00005001 File Offset: 0x00003201
		public static int MaxLinkInputCh
		{
			get
			{
				return 48;
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x0600024F RID: 591 RVA: 0x00004003 File Offset: 0x00002203
		public static int MaxLinkMain
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000250 RID: 592 RVA: 0x00005005 File Offset: 0x00003205
		public static int MaxLinkOutput
		{
			get
			{
				return 24;
			}
		}

		// Token: 0x04000118 RID: 280
		public static int test = 0;

		// Token: 0x04000119 RID: 281
		public static string title = "TS-24PD-8";

		// Token: 0x0400011A RID: 282
		public static string ver = "V1.0.3";

		// Token: 0x0400011B RID: 283
		public const string DSPFilter = "DR16.4R DSP File|*.DDRSAV";

		// Token: 0x0400011C RID: 284
		public const string GEQFilter = "DR16.4R GEQ File|*.GDRSAV";

		// Token: 0x0400011D RID: 285
		public const string FXFilter = "DR16.4R FX File|*.FDRSAV";

		// Token: 0x0400011E RID: 286
		public const string SenceFilter = "DR16.4 Sence File|*.SDRSAV";

		// Token: 0x0400011F RID: 287
		public const int DSPPresetCount = 48;

		// Token: 0x04000120 RID: 288
		public const int GEQPresetCount = 48;

		// Token: 0x04000121 RID: 289
		public const int FXPresetCount = 104;

		// Token: 0x04000122 RID: 290
		public const int ScenePresetCount = 24;

		// Token: 0x04000123 RID: 291
		public const int FPS = 80;

		// Token: 0x04000124 RID: 292
		public static int[] inital_freq_ary = new int[] { 25, 50, 75, 102, 0, 128 };

		// Token: 0x04000125 RID: 293
		public const int getPackageOfPresetLenth = 1908;

		// Token: 0x04000126 RID: 294
		public const int EQ_MAX = 6;

		// Token: 0x04000127 RID: 295
		public const int MaxOnlyCH = 18;

		// Token: 0x04000128 RID: 296
		public const int CH_MAX = 34;

		// Token: 0x04000129 RID: 297
		public const int INPUT_METER_MAX = 16;

		// Token: 0x0400012A RID: 298
		public const int MAXCHWITHOUTMAIN = 19;

		// Token: 0x0400012B RID: 299
		public const int FBCLeftChanel = 20;

		// Token: 0x0400012C RID: 300
		public const int Matrix_TNUM = 32;

		// Token: 0x0400012D RID: 301
		public const int Matrix_CTL_NUM = 20;

		// Token: 0x0400012E RID: 302
		public const int FBCChanel = 28;

		// Token: 0x0400012F RID: 303
		public const int MAX_GEQ = 31;

		// Token: 0x04000130 RID: 304
		public const int Max_FBCStatus = 24;

		// Token: 0x04000131 RID: 305
		public const int MAX_48V = 16;

		// Token: 0x04000132 RID: 306
		public const byte LByte = 15;

		// Token: 0x04000133 RID: 307
		public const int SCAN_ALL_APID = 65535;

		// Token: 0x04000134 RID: 308
		public const int APPID = 10;

		// Token: 0x04000135 RID: 309
		public const int GUI_MAIN_SEND = 23;

		// Token: 0x04000136 RID: 310
		public const int GUI_DIGITAL_IN = 11;

		// Token: 0x04000137 RID: 311
		public const int GUI_DIGITAL_OUT = 12;

		// Token: 0x04000138 RID: 312
		public const int GUI_DIGITAL_GEQ = 9;

		// Token: 0x04000139 RID: 313
		public const int CMD_Gain = 1;

		// Token: 0x0400013A RID: 314
		public const int CMD_MUTE = 2;

		// Token: 0x0400013B RID: 315
		public const int CMD_Delay = 3;

		// Token: 0x0400013C RID: 316
		public const int CMD_Invert = 4;

		// Token: 0x0400013D RID: 317
		public const int CMD_EQ = 5;

		// Token: 0x0400013E RID: 318
		public const int CMD_EQ_ALL_Bypass = 6;

		// Token: 0x0400013F RID: 319
		public const int CMD_HLP = 7;

		// Token: 0x04000140 RID: 320
		public const int CMD_GATE = 8;

		// Token: 0x04000141 RID: 321
		public const int CMD_EQ_Flat = 9;

		// Token: 0x04000142 RID: 322
		public const int CMD_Meter = 10;

		// Token: 0x04000143 RID: 323
		public const int CMD_Assign = 11;

		// Token: 0x04000144 RID: 324
		public const int CMD_SendGain = 12;

		// Token: 0x04000145 RID: 325
		public const int CMD_Send_Pre = 37;

		// Token: 0x04000146 RID: 326
		public const int CMD_Main_Send = 40;

		// Token: 0x04000147 RID: 327
		public const int CMD_COMP = 13;

		// Token: 0x04000148 RID: 328
		public const int CMD_PAN = 14;

		// Token: 0x04000149 RID: 329
		public const int CMD_Solo = 15;

		// Token: 0x0400014A RID: 330
		public const int CMD_Solo_Clear = 16;

		// Token: 0x0400014B RID: 331
		public const int CMD_GEQ = 17;

		// Token: 0x0400014C RID: 332
		public const int CMD_FX = 18;

		// Token: 0x0400014D RID: 333
		public const int CMD_DC48V = 19;

		// Token: 0x0400014E RID: 334
		public const int CMD_ACK = 20;

		// Token: 0x0400014F RID: 335
		public const int CMD_Recall = 21;

		// Token: 0x04000150 RID: 336
		public const int CMD_SAVE = 22;

		// Token: 0x04000151 RID: 337
		public const int CMD_Load = 23;

		// Token: 0x04000152 RID: 338
		public const int CMD_GUI_Control = 24;

		// Token: 0x04000153 RID: 339
		public const int CMD_CH_Control = 29;

		// Token: 0x04000154 RID: 340
		public const int CMD_Change_Devic_Name = 26;

		// Token: 0x04000155 RID: 341
		public const int CMD_GEQ_Flat = 27;

		// Token: 0x04000156 RID: 342
		public const int CMD_AssignMain = 28;

		// Token: 0x04000157 RID: 343
		public const int CMD_DefultSetting = 29;

		// Token: 0x04000158 RID: 344
		public const int CMD_Digital_Out = 39;

		// Token: 0x04000159 RID: 345
		public const int CMD_Digital_In = 38;

		// Token: 0x0400015A RID: 346
		public const int CMD_ComBypass = 41;

		// Token: 0x0400015B RID: 347
		public const int CMD_GateBypass = 42;

		// Token: 0x0400015C RID: 348
		public const int CMD_PFL = 44;

		// Token: 0x0400015D RID: 349
		public const int CMD_Link = 43;

		// Token: 0x0400015E RID: 350
		public const int CMD_GateMeter = 45;

		// Token: 0x0400015F RID: 351
		public const int CMD_CompMeter = 46;

		// Token: 0x04000160 RID: 352
		public const int CMD_Delete = 47;

		// Token: 0x04000161 RID: 353
		public const int CMD_SoloMeter = 48;

		// Token: 0x04000162 RID: 354
		public const int CMD_ChangeCHName = 49;

		// Token: 0x04000163 RID: 355
		public const int CMD_AllPost = 52;

		// Token: 0x04000164 RID: 356
		public const int CMD_Copy = 53;

		// Token: 0x04000165 RID: 357
		public const int CMD_LocalLoadEnd = 54;

		// Token: 0x04000166 RID: 358
		public const int CMD_LocalLoad = 57;

		// Token: 0x04000167 RID: 359
		public const int CMD_LoadPCDSP = 58;

		// Token: 0x04000168 RID: 360
		public const int CMD_LoadPCFX = 59;

		// Token: 0x04000169 RID: 361
		public const int CMD_LoadPCGEQ = 60;

		// Token: 0x0400016A RID: 362
		public const int CMD_DeviceName = 61;

		// Token: 0x0400016B RID: 363
		public const int CMD_FBCInAssign = 118;

		// Token: 0x0400016C RID: 364
		public const int CMD_FBCOutAssign = 119;

		// Token: 0x0400016D RID: 365
		public const int CMD_FBCStatus = 113;

		// Token: 0x0400016E RID: 366
		public const int CMD_FBCSet_Up = 112;

		// Token: 0x0400016F RID: 367
		public const int CMD_FBCSetting = 110;

		// Token: 0x04000170 RID: 368
		public const int CMD_DuckerPara = 75;

		// Token: 0x04000171 RID: 369
		public const int CMD_DuckerMix = 76;

		// Token: 0x04000172 RID: 370
		public const int CMD_AutoMixer = 55;

		// Token: 0x04000173 RID: 371
		public const int CMD_ENTER_IAP = 256;

		// Token: 0x04000174 RID: 372
		public const int CMD_IAP_MODE_ENTER_READY = 239;

		// Token: 0x04000175 RID: 373
		public const int CMD_IAP_PROGRAMING = 240;

		// Token: 0x04000176 RID: 374
		public const int CMD_IAP_Finish = 241;

		// Token: 0x04000177 RID: 375
		public const int CMD_DSPFirmwareUpdate = 242;

		// Token: 0x04000178 RID: 376
		public const int CMD_F_UpdateProgress = 243;

		// Token: 0x04000179 RID: 377
		public const int CMD_F_DSPUpdateFinish = 245;

		// Token: 0x0400017A RID: 378
		public const int CMD_F_MatrixMixer = 78;

		// Token: 0x0400017B RID: 379
		public const int MAX_FBCFilter = 24;

		// Token: 0x0400017C RID: 380
		public static string[] strFBCMode = new string[] { "Speech", "Music" };

		// Token: 0x0400017D RID: 381
		public static string[] strFBCFilterRelease = new string[] { "Fast", "Mid", "Slow" };

		// Token: 0x0400017E RID: 382
		public static string[] strAutoReleseTable = new string[]
		{
			"10mS", "20mS", "25mS", "50mS", "100mS", "200mS", "300mS", "400mS", "500mS", "600mS",
			"700mS", "800mS", "900mS", "1000mS", "1200mS", "1500mS", "2000mS", "2500mS", "3000mS", "3500mS",
			"4000mS", "4500mS", "5000mS", "5500mS", "6000mS"
		};

		// Token: 0x0400017F RID: 383
		public static string[] strDuck_Attack = new string[]
		{
			"10mS", "20mS", "25mS", "30mS", "50mS", "100mS", "120mS", "150mS", "175mS", "200mS",
			"250mS", "300mS", "350mS", "400mS", "450mS", "500mS", "550mS", "600mS", "650mS", "700mS",
			"750mS", "800mS", "850mS", "900mS", "1000mS"
		};

		// Token: 0x04000180 RID: 384
		public static string[] FreqValueTable = new string[]
		{
			"20Hz", "25Hz", "31.5Hz", "40Hz", "50Hz", "63Hz", "80Hz", "100Hz", "125Hz", "160Hz",
			"200Hz", "250Hz", "315Hz", "400Hz", "500Hz", "630Hz", "800Hz", "1.0KHz", "1.25KHz", "1.6KHz",
			"2.0KHz", "2.5KHz", "3.15KHz", "4.0KHz", "5.0KHz", "6.3KHz", "8.0KHz", "10.0KHz", "12.5KHz", "16.0KHz",
			"20.0KHz"
		};

		// Token: 0x04000181 RID: 385
		public static string[] strDuck_Release = new string[]
		{
			"10mS", "20mS", "25mS", "50mS", "100mS", "200mS", "300mS", "400mS", "500mS", "600mS",
			"700mS", "800mS", "900mS", "1000mS", "1200mS", "1500mS", "2000mS", "2500mS", "3000mS", "3500mS",
			"4000mS", "4500mS", "5000mS", "5500mS", "6000mS"
		};

		// Token: 0x04000182 RID: 386
		public static string[] chgainStr = new string[]
		{
			"OFF  ", "-70.0dB", "-65.0dB", "-60.0dB", "-50.0dB", "-45.0dB", "-40.0dB", "-30.0dB", "-29.0dB", "-28.0dB",
			"-27.0dB", "-26.0dB", "-25.0dB", "-24.0dB", "-23.0dB", "-22.0dB", "-21.0dB", "-20.0dB", "-19.5dB", "-19.0dB",
			"-18.5dB", "-18.0dB", "-17.5dB", "-17.0dB", "-16.5dB", "-16.0dB", "-15.5dB", "-15.0dB", "-14.5dB", "-14.0dB",
			"-13.5dB", "-13.0dB", "-12.5dB", "-12.0dB", "-11.5dB", "-11.0dB", "-10.5dB", "-10.0dB", "-9.5dB", "-9.2dB",
			"-9.0dB", "-8.7dB", "-8.5dB", "-8.2dB", "-8.0dB", "-7.8dB", "-7.5dB", "-7.2dB", "-7.0dB", "-6.5dB",
			"-6.0dB", "-5.5dB", "-5.0dB", "-4.5dB", "-4.0dB", "-3.0dB", "-2.0dB", "-1.5dB", "-1.0dB", "-0.5dB",
			"0.0dB", "0.5dB", "1.0dB", "1.5dB", "2.0dB", "2.5dB", "3.0dB", "3.5dB", "4.0dB", "5.0dB",
			"5.5dB", "6.0dB", "6.5dB", "7.0dB", "7.5dB", "8.0dB", "8.5dB", "9.0dB", "9.5dB", "9.7dB",
			"10.0dB"
		};

		// Token: 0x04000183 RID: 387
		public static string[] Qstr = new string[]
		{
			"0.4", "0.42", "0.45", "0.47", "0.5", "0.53", "0.56", "0.59", "0.63", "0.67",
			"0.71", "0.75", "0.79", "0.84", "0.89", "0.94", "1.0", "1.06", "1.12", "1.19",
			"1.26", "1.3", "1.4", "1.5", "1.6", "1.7", "1.8", "1.9", "2.0", "2.1",
			"2.1", "2.4", "2.5", "2.7", "2.8", "3.0", "3.2", "3.4", "3.6", "3.8",
			"4.0", "4.2", "4.5", "4.8", "5.0", "5.3", "5.7", "6.0", "6.3", "6.7",
			"7.1", "7.6", "8.0", "8.5", "9.0", "9.5", "10.1", "10.7", "11.3", "12",
			"12.7", "13.5", "14", "15", "16", "17", "18", "19", "20", "21",
			"23", "24", "25", "27", "29", "30", "32", "34", "36", "38",
			"40", "43", "45", "48", "51", "54", "57", "60", "64", "68",
			"72", "76", "81", "85", "91", "96", "102", "108", "114", "121",
			"128"
		};

		// Token: 0x04000184 RID: 388
		public static double[] EqGain = new double[]
		{
			-18.0, -17.5, -17.0, -16.5, -16.0, -15.5, -15.0, -14.5, -14.0, -13.5,
			-13.0, -12.5, -12.0, -11.5, -11.0, -10.5, -10.0, -9.5, -9.0, -8.5,
			-8.0, -7.5, -7.0, -6.5, -6.0, -5.5, -5.0, -4.5, -4.0, -3.5,
			-3.0, -2.5, -2.0, -1.5, -1.0, -0.5, 0.0, 0.5, 1.0, 1.5,
			2.0, 2.5, 3.0, 3.5, 4.0, 4.5, 5.0, 5.5, 6.0, 6.5,
			7.0, 7.5, 8.0, 8.5, 9.0, 9.5, 10.0, 10.5, 11.0, 11.5,
			12.0, 12.5, 13.0, 13.5, 14.0, 14.5, 15.0, 15.5, 16.0, 16.5,
			17.0, 17.5, 18.0
		};

		// Token: 0x04000185 RID: 389
		public static double[] EQ24Gain = new double[]
		{
			-24.0, -23.0, -22.0, -21.0, -20.0, -19.0, -18.0, -17.0, -16.0, -15.0,
			-14.0, -13.0, -12.0, -11.0, -10.0, -9.0, -8.0, -7.0, -6.0, -5.0,
			-4.0, -3.0, -2.0, -1.0, 0.0, 1.0, 2.0, 3.0, 4.0, 5.0,
			6.0, 7.0, 8.0, 9.0, 10.0, 11.0, 12.0, 13.0, 14.0, 15.0,
			16.0, 17.0, 18.0, 19.0, 20.0, 21.0, 22.0, 23.0, 24.0
		};

		// Token: 0x04000186 RID: 390
		public static double[] Freq300Table = new double[]
		{
			19.7, 20.1, 20.6, 21.1, 21.6, 22.1, 22.6, 23.1, 23.7, 24.2,
			24.8, 25.4, 26.0, 26.6, 27.2, 27.8, 28.5, 29.2, 29.8, 30.5,
			31.2, 32.0, 32.7, 33.5, 34.3, 35.1, 35.9, 36.7, 37.6, 38.5,
			39.4, 40.3, 41.2, 42.2, 43.2, 44.2, 45.2, 46.3, 47.4, 48.5,
			49.6, 50.8, 52.0, 53.2, 54.4, 55.7, 57.0, 58.3, 59.7, 61.1,
			62.5, 64.0, 65.5, 67.0, 68.6, 70.2, 71.8, 73.5, 75.2, 76.9,
			78.7, 80.6, 82.5, 84.4, 86.4, 88.4, 90.5, 92.6, 94.7, 96.9,
			99.2, 101.5, 103.9, 106.3, 108.8, 111.4, 114.0, 116.6, 119.4, 122.1,
			125.0, 127.9, 130.9, 134.0, 137.1, 140.3, 143.6, 146.9, 150.4, 153.9,
			157.5, 161.2, 164.9, 168.8, 172.7, 176.8, 180.9, 185.1, 189.5, 193.9,
			198.4, 203.1, 207.8, 212.7, 217.6, 222.7, 227.9, 233.3, 238.7, 244.3,
			250.0, 255.8, 261.8, 267.9, 274.2, 280.6, 287.2, 293.9, 300.8, 307.8,
			315.0, 322.3, 329.9, 337.6, 345.5, 353.6, 361.8, 370.3, 378.9, 387.8,
			396.9, 406.1, 415.6, 425.3, 435.3, 445.4, 455.9, 466.5, 477.4, 488.6,
			500.0, 511.7, 523.6, 535.9, 548.4, 561.2, 574.3, 587.8, 601.5, 615.6,
			630.0, 644.7, 659.8, 675.2, 691.0, 707.1, 723.6, 740.5, 757.9, 775.6,
			793.7, 812.3, 831.2, 850.7, 870.6, 890.9, 911.7, 933.0, 954.8, 977.2,
			1000.0, 1030.0, 1050.0, 1080.0, 1100.0, 1130.0, 1150.0, 1180.0, 1210.0, 1240.0,
			1260.0, 1290.0, 1320.0, 1350.0, 1390.0, 1420.0, 1450.0, 1490.0, 1520.0, 1560.0,
			1590.0, 1630.0, 1670.0, 1710.0, 1750.0, 1790.0, 1830.0, 1870.0, 1910.0, 1960.0,
			2010.0, 2050.0, 2100.0, 2150.0, 2200.0, 2250.0, 2300.0, 2360.0, 2410.0, 2470.0,
			2520.0, 2580.0, 2640.0, 2700.0, 2770.0, 2830.0, 2900.0, 2970.0, 3040.0, 3110.0,
			3180.0, 3250.0, 3330.0, 3410.0, 3490.0, 3570.0, 3650.0, 3740.0, 3820.0, 3910.0,
			4010.0, 4100.0, 4190.0, 4290.0, 4390.0, 4490.0, 4600.0, 4710.0, 4820.0, 4930.0,
			5040.0, 5160.0, 5280.0, 5410.0, 5530.0, 5660.0, 5790.0, 5930.0, 6070.0, 6210.0,
			6350.0, 6500.0, 6650.0, 6810.0, 6970.0, 7130.0, 7300.0, 7470.0, 7640.0, 7820.0,
			8000.0, 8190.0, 8380.0, 8580.0, 8780.0, 8980.0, 9190.0, 9410.0, 9630.0, 9850.0,
			10080.0, 10320.0, 10560.0, 10810.0, 11060.0, 11320.0, 11580.0, 11850.0, 12130.0, 12410.0,
			12700.0, 13000.0, 13300.0, 13610.0, 13930.0, 14260.0, 14590.0, 14930.0, 15280.0, 15640.0,
			16010.0, 16380.0, 16760.0, 17150.0, 17550.0, 17960.0, 18380.0, 18810.0, 19250.0, 19700.0,
			20160.0
		};

		// Token: 0x04000187 RID: 391
		public static double[] Freq128Table = new double[]
		{
			20.6, 21.6, 23.1, 24.8, 25.8, 27.8, 30.0, 32.3, 35.1, 36.7,
			37.6, 38.5, 39.4, 40.0, 42.2, 45.2, 48.5, 50.0, 54.4, 57.0,
			60.0, 64.0, 67.0, 70.0, 75.2, 78.7, 80.0, 86.4, 90.0, 94.7,
			100.0, 106.3, 114.0, 119.4, 125.0, 134.0, 140.3, 150.4, 161.2, 168.8,
			176.8, 185.1, 195.3, 200.0, 212.7, 227.9, 233.3, 250.0, 261.8, 280.6,
			300.0, 315.0, 329.9, 353.6, 370.3, 387.8, 400.0, 425.3, 445.4, 466.5,
			500.0, 535.9, 574.3, 600.0, 630.0, 675.2, 700.0, 757.9, 800.0, 831.2,
			870.6, 900.0, 954.8, 1000.0, 1050.0, 1150.0, 1210.0, 1290.0, 1420.0, 1490.0,
			1560.0, 1670.0, 1750.0, 1830.0, 1960.0, 2000.0, 2100.0, 2150.0, 2250.0, 2360.0,
			2520.0, 2640.0, 2900.0, 3000.0, 3250.0, 3570.0, 3740.0, 3910.0, 4000.0, 4100.0,
			4390.0, 4600.0, 4930.0, 5000.0, 5280.0, 5790.0, 6000.0, 6350.0, 6810.0, 7000.0,
			7640.0, 8000.0, 8190.0, 8780.0, 9000.0, 10000.0, 11500.0, 12100.0, 12700.0, 13300.0,
			13900.0, 14500.0, 15200.0, 16000.0, 16700.0, 17500.0, 18300.0, 19200.0, 20000.0
		};

		// Token: 0x04000188 RID: 392
		public static string[] GEQFreqStr = new string[]
		{
			"20", "25", "31.5", "40", "50", "63", "80", "100", "125", "160",
			"200", "250", "315", "400", "500", "630", "800", "1K", "1.25K", "1.6K",
			"2K", "2.5K", "3.15K", "4K", "5K", "6.3K", "8K", "10K", "12.5K", "16K",
			"20K"
		};

		// Token: 0x04000189 RID: 393
		public static readonly string[] PageNameKey = new string[] { "Str_AssianChannel", "Str_System" };

		// Token: 0x0400018A RID: 394
		public static readonly string[] PageNameStrings = new string[] { "AssignChannel", "System" };

		// Token: 0x0400018B RID: 395
		public const int AppId = 43;

		// Token: 0x0400018C RID: 396
		public const int DeviceId = 43;

		// Token: 0x0400018D RID: 397
		public const int DspPresetCount = 48;

		// Token: 0x0400018E RID: 398
		public const int EqMax = 2;

		// Token: 0x0400018F RID: 399
		public const int FxPresetCount = 104;

		// Token: 0x04000190 RID: 400
		public const int GeqPresetCount = 48;

		// Token: 0x04000191 RID: 401
		public const int MaxBottomGroupChShow = 16;

		// Token: 0x04000192 RID: 402
		public const int MaxCh = 51;

		// Token: 0x04000193 RID: 403
		public const int ChannelNameLength = 8;

		// Token: 0x04000194 RID: 404
		public const int MaxDevice = 2;

		// Token: 0x04000195 RID: 405
		public const int MaxFx = 2;

		// Token: 0x04000196 RID: 406
		public const int MaxInputCh = 24;

		// Token: 0x04000197 RID: 407
		public const int MaxOutput = 12;

		// Token: 0x04000198 RID: 408
		public const int MaxDigitalOutPut = 30;

		// Token: 0x04000199 RID: 409
		public static readonly int[] PresetType = new int[] { 1, 3, 2, 0 };

		// Token: 0x0400019A RID: 410
		public const int MaxMain = 1;

		// Token: 0x0400019B RID: 411
		public static string Title = "DM24.8";

		// Token: 0x0400019C RID: 412
		public static string MainName = "MAIN";

		// Token: 0x0400019D RID: 413
		public static string Name_APP = "DM24.8";

		// Token: 0x0400019E RID: 414
		public static string INI_sec = "Settings";

		// Token: 0x0400019F RID: 415
		public static string Ver = "1.0.1";

		// Token: 0x040001A0 RID: 416
		public static string SuppVer = "1.0.1";

		// Token: 0x040001A1 RID: 417
		public static string AgNum = "(c)2019";

		// Token: 0x040001A2 RID: 418
		private static string[] _auxFxMainsName;

		// Token: 0x040001A3 RID: 419
		private static string[] _auxLinkName;

		// Token: 0x040001A4 RID: 420
		private static string[] _auxMainsName;

		// Token: 0x040001A5 RID: 421
		private static string[] _auxName;

		// Token: 0x040001A6 RID: 422
		private static string[] _fxName;

		// Token: 0x040001A7 RID: 423
		private static string[] _outputChannelsName;

		// Token: 0x040001A8 RID: 424
		private static string[] _linkAuxFxMainsName;

		// Token: 0x040001A9 RID: 425
		private static string[] _linkAuxMainsName;

		// Token: 0x040001AA RID: 426
		private static string[] _linkFxName;

		// Token: 0x040001AB RID: 427
		private static string[] _linkOutputannelsName;

		// Token: 0x040001AC RID: 428
		public const int ExtraLocalIdHigh = 9;

		// Token: 0x040001AD RID: 429
		public const int ExtraLocalIdLow = 108;

		// Token: 0x040001AE RID: 430
		public static int[] BackUpItemCountList = new int[] { 48, 48, 104, 24 };

		// Token: 0x040001AF RID: 431
		public static IReadOnlyList<string> BackUpNames = new string[] { "DSP", "GEQ", "FX", "Scene" };

		// Token: 0x040001B0 RID: 432
		public static readonly string[] ChannelsName = new string[]
		{
			"CH1", "CH2", "CH3", "CH4", "CH5", "CH6", "CH7", "CH8", "CH9", "CH10",
			"CH11", "CH12", "CH13", "CH14", "CH15", "CH16", "CH17", "CH18", "CH19", "CH20",
			"CH21", "CH22", "CH23", "CH24", "FX1", "FX2", "AUX1", "AUX2", "AUX3", "AUX4",
			"AUX5", "AUX6", "AUX7", "AUX8", "AUX9", "AUX10", "AUX11", "AUX12", "Output1", "Output2",
			"Output3", "Output4", "Output5", "Output6", "Output7", "Output8", "Output9", "Output10", "Output11", "Output12",
			"MAIN"
		};

		// Token: 0x040001B1 RID: 433
		public static readonly string[] DcaArrayName = new string[]
		{
			"DCA1", "DCA2", "DCA3", "DCA4", "DCA5", "DCA6", "DCA7", "DCA8", "DCA9", "DCA10",
			"DCA11", "DCA12"
		};

		// Token: 0x040001B2 RID: 434
		public static readonly int[] InitialFreqAry = new int[] { 25, 50, 75, 102, 0, 128 };

		// Token: 0x040001B3 RID: 435
		public static readonly string[] LinkChannelsName = new string[]
		{
			"CH1", "CH2", "CH3", "CH4", "CH5", "CH6", "CH7", "CH8", "CH9", "CH10",
			"CH11", "CH12", "CH13", "CH14", "CH15", "CH16", "CH17", "CH18", "CH19", "CH20",
			"CH21", "CH22", "CH23", "CH24", "CH25", "CH26", "CH27", "CH28", "CH29", "CH30",
			"CH31", "CH32", "CH33", "CH34", "CH35", "CH36", "CH37", "CH38", "CH39", "CH40",
			"CH41", "CH42", "CH43", "CH44", "CH45", "CH46", "CH47", "CH48", "FX1", "FX2",
			"FX3", "FX4", "AUX1", "AUX2", "AUX3", "AUX4", "AUX5", "AUX6", "AUX7", "AUX8",
			"AUX9", "AUX10", "AUX11", "AUX12", "AUX13", "AUX14", "AUX15", "AUX16", "AUX17", "AUX18",
			"AUX19", "AUX20", "AUX21", "AUX22", "AUX23", "AUX24", "Output1", "Output2", "Output3", "Output4",
			"Output5", "Output6", "Output7", "Output8", "Output9", "Output10", "Output11", "Output12", "Output13", "Output14",
			"Output15", "Output16", "Output17", "Output18", "Output19", "Output20", "Output21", "Output22", "Output23", "Output24",
			"MAIN"
		};

		// Token: 0x040001B4 RID: 436
		public static readonly string[] PageNameKey_DS = new string[] { "Str_AssianChannel_DS", "Str_System_DS" };

		// Token: 0x040001B5 RID: 437
		public static readonly string[] PageNameStrings_DS = new string[] { "AssignChannel", "System" };

		// Token: 0x040001B6 RID: 438
		public static int[] LinkChannelIndexForPc = new int[]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
			20, 21, 22, 23, 48, 49, 52, 53, 54, 55,
			56, 57, 58, 59, 60, 61, 62, 63, 76, 24,
			25, 26, 27, 28, 29, 30, 31, 32, 33, 34,
			35, 36, 37, 38, 39, 40, 41, 42, 43, 44,
			45, 46, 47, 50, 51, 64, 65, 66, 67, 68,
			69, 70, 71, 72, 73, 74, 75
		};

		// Token: 0x040001B7 RID: 439
		public static int[] LinkGeqMasterIndexForPc = new int[]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 24
		};

		// Token: 0x040001B8 RID: 440
		public static int[] LinkGeqMForDevice = new int[]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 13, 14, 15, 16, 17, 18, 19, 20,
			21, 22, 23, 24, 12
		};

		// Token: 0x040001B9 RID: 441
		public static int[] LinkGeqSlaveIndexForPc = new int[]
		{
			12, 13, 14, 15, 16, 17, 18, 19, 20, 21,
			22, 23
		};
	}
}
