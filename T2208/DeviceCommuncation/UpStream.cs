using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Timers;
using CommLibrary;
using Lib.Controls;
using T2208.Models;

namespace T2208.DeviceCommuncation
{
	// Token: 0x020000B7 RID: 183
	public class UpStream
	{
		// Token: 0x17000368 RID: 872
		// (get) Token: 0x060008FA RID: 2298 RVA: 0x00009E68 File Offset: 0x00008068
		public static Cilent Client
		{
			get
			{
				return ConnectionModel.GetCilent();
			}
		}

		// Token: 0x17000369 RID: 873
		// (get) Token: 0x060008FB RID: 2299 RVA: 0x00009E6F File Offset: 0x0000806F
		// (set) Token: 0x060008FC RID: 2300 RVA: 0x00009E76 File Offset: 0x00008076
		public static bool DuringProcessDownStream { get; set; }

		// Token: 0x060008FD RID: 2301 RVA: 0x00026FB8 File Offset: 0x000251B8
		static UpStream()
		{
			UpStream._HighFrequencyTransmissionTimer.Elapsed += UpStream._HighFrequencyTransmissionTimer_Elapsed;
			UpStream._HighFrequencyTransmissionTimer.Start();
		}

		// Token: 0x060008FE RID: 2302 RVA: 0x00027070 File Offset: 0x00025270
		private static void _HighFrequencyTransmissionTimer_Elapsed(object sender, ElapsedEventArgs e)
		{
			foreach (Stack<List<byte>> stack in UpStream._UpStreamDictionary.Values)
			{
				bool flag = stack.Count > 0;
				if (flag)
				{
					UpStream.SendBytes(stack.Pop().ToArray());
					stack.Clear();
				}
			}
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x000270EC File Offset: 0x000252EC
		public static void SendMatrixValueChanged(params byte[] IsSelected)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 29, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_Matrix, 0);
			UpStream.InsertData(list, IsSelected);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x00027138 File Offset: 0x00025338
		public static void SendCMD_SwitchPage(byte uiIndex1, byte uiIndex2, byte uiIndex3, byte uiIndex4)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 17, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_SyncCommand, 0);
			UpStream.InsertData(list, uiIndex1, uiIndex2, new byte[] { uiIndex3, uiIndex4 });
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x06000901 RID: 2305 RVA: 0x00027194 File Offset: 0x00025394
		public static void SendCMD_LEDBackLight(byte lcd, byte knob)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 13, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_LCDBlackLight);
			UpStream.InsertData(list, 0, lcd, new byte[] { knob });
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x000271E8 File Offset: 0x000253E8
		public static void SendCMD_CopyChannel(params byte[] bytes)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 42, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_Copy);
			UpStream.InsertData(list, bytes);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x00027234 File Offset: 0x00025434
		public static void SendCMD_ACK()
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 11, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_AckCommd, 0);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x00027278 File Offset: 0x00025478
		public static void SendCMD_DC48VPower()
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 37, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_DC48V);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x000272BC File Offset: 0x000254BC
		public static void SendCMD_EQ(params byte[] bytes)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 21, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_Equalizer);
			UpStream.InsertData(list, bytes);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x06000906 RID: 2310 RVA: 0x00027308 File Offset: 0x00025508
		public static void SendCMD_ResetToFactory()
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 11, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_ResetCommand);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x0002734C File Offset: 0x0002554C
		public static void SendCMD_GEQChange(params byte[] bytes)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 45, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_GEQChannel);
			UpStream.InsertData(list, bytes);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x06000908 RID: 2312 RVA: 0x00027398 File Offset: 0x00025598
		public static void SendCMD_Solo(params byte[] bytes)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 48, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_SOLO);
			UpStream.InsertData(list, bytes);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x06000909 RID: 2313 RVA: 0x000273E4 File Offset: 0x000255E4
		public static void SendCMD_EQFlat(byte channelIndex)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 13, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_FlatEQCommand);
			UpStream.InsertData(list, channelIndex, new byte[0]);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x0600090A RID: 2314 RVA: 0x00027434 File Offset: 0x00025634
		public static void SendCMD_Recall()
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 12, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_ReadCurrentScene);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x00027478 File Offset: 0x00025678
		public static void SendCMD_MuteGain(params byte[] bytes)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 48, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_MUTE_GAIN);
			UpStream.InsertData(list, bytes);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x000274C4 File Offset: 0x000256C4
		public static void SendCMD_DeletePreset(byte type, byte index)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 12, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_DeletePreset);
			UpStream.InsertData(list, type, index, new byte[0]);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x00027514 File Offset: 0x00025714
		public static void SendCMD_SavePresetToDevice(params byte[] bytes)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 29, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_SavePreset);
			UpStream.InsertData(list, bytes);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x00027560 File Offset: 0x00025760
		public static void SendCMD_LoadPresetFromDevice(byte sMode, byte channelIndex, byte index)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 12, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, sMode);
			UpStream.InsertData(list, channelIndex, index, new byte[0]);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x000275AC File Offset: 0x000257AC
		public static void SendCMD_PackageOfChannel(params byte[] bytes)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 30, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_FatChannel);
			UpStream.InsertData(list, bytes);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x000275F8 File Offset: 0x000257F8
		public static void SendCMD_PackageofChannelLink(byte[] ch1Bytes, byte[] ch2Bytes)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 30, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_FatChannel);
			UpStream.InsertData(list, ch1Bytes);
			list.Add(64);
			List<byte> list2 = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list2, 30, true);
			UpStream.InsertApp_ID(list2);
			UpStream.InsertLocal_ID(list2);
			UpStream.InsertDataType(list2, CommandConst.CMD_FatChannel);
			UpStream.InsertData(list2, ch2Bytes);
			list.AddRange(list);
			UpStream.InsertStopBitAndCheckBit(list, false, false);
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x00027684 File Offset: 0x00025884
		public static void SendCMD_Gate(params byte[] bytes)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 19, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_GATE);
			UpStream.InsertData(list, bytes);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x000276D0 File Offset: 0x000258D0
		public static void SendCMD_Compressor(params byte[] bytes)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 21, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_COMP_LIMIT);
			UpStream.InsertData(list, bytes);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x0002771C File Offset: 0x0002591C
		public static void SendCMD_DigitalOutGain(params byte[] bytes)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 44, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_DigltalOut);
			UpStream.InsertData(list, bytes);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x00027768 File Offset: 0x00025968
		public static void SendCMD_ChangeChannelName(params byte[] bytes)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 19, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_SetChannelName);
			UpStream.InsertData(list, bytes);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x000277B4 File Offset: 0x000259B4
		public static void SendCMD_DFX(params byte[] bytes)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 27, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_DFXChannel);
			UpStream.InsertData(list, bytes);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x00027800 File Offset: 0x00025A00
		public static void SendCMD_LoadScenePresetFromPC(params byte[] bytes)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 245, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_PCLocalPresetLoad);
			UpStream.InsertData(list, bytes);
			UpStream.InsertStopBitAndCheckBit(list, false, false);
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x0002784C File Offset: 0x00025A4C
		public static void SendCMD_LoadPresetFromPC(params byte[] bytes)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 240, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_PCLocalPresetLoad);
			UpStream.InsertData(list, bytes);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x00027898 File Offset: 0x00025A98
		public static void SendCMD_GroupSelect(params byte[] bytes)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 18, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_allFadergroupSelect);
			UpStream.InsertData(list, bytes);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x000278E4 File Offset: 0x00025AE4
		public static void SendCMD_AllPost(params byte[] bytes)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 14, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_AllAuxPost);
			UpStream.InsertData(list, bytes);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x0600091A RID: 2330 RVA: 0x00027930 File Offset: 0x00025B30
		public static void SendCMD_AR(byte routingPageIndex, byte postFlag)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 14, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_AllAuxPost);
			UpStream.InsertData(list, routingPageIndex, postFlag, new byte[0]);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x00027980 File Offset: 0x00025B80
		public static void SendCMD_BusMixer(params byte[] bytes)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 29, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_BusMixer);
			UpStream.InsertData(list, bytes);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x000279CC File Offset: 0x00025BCC
		public static void SendCMD_BusMixerLink(byte[] ch1Bytes, byte[] ch2Bytes)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 29, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_BusMixer);
			UpStream.InsertData(list, ch1Bytes);
			list.Add(64);
			List<byte> list2 = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list2, 29, true);
			UpStream.InsertApp_ID(list2);
			UpStream.InsertLocal_ID(list2);
			UpStream.InsertDataType(list2, CommandConst.CMD_BusMixer);
			UpStream.InsertData(list2, ch2Bytes);
			list.AddRange(list);
			UpStream.InsertStopBitAndCheckBit(list, false, false);
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x00027A58 File Offset: 0x00025C58
		public static void SendCMD_DCASoloMuteGainChange(byte reserved, byte change, byte index)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 16, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_allFadergroupGain);
			UpStream.InsertData(list, new byte[0]);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x00027AA8 File Offset: 0x00025CA8
		public static void SendCMD_ReadGUIIndex()
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 10, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_ReadeSysGUIindex);
			UpStream.InsertData(list, new byte[0]);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x00027AF8 File Offset: 0x00025CF8
		public static void SendCMD_TempDCAGroupSet(params byte[] bytes)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 56, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_bGroupSet);
			UpStream.InsertData(list, bytes);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x00027B44 File Offset: 0x00025D44
		public static void SendCMD_ReadPresetList(params byte[] bytes)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, 13, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, CommandConst.CMD_ReadPresetList);
			UpStream.InsertData(list, bytes);
			UpStream.InsertStopBitAndCheckBit(list, false, true);
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x00009E7E File Offset: 0x0000807E
		public static void SendCMD_DCAGroupSet(params byte[] bytes)
		{
			UpStream.PrimaryCommandGenerator(54, CommandConst.CMD_GroupSet, false, bytes);
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x00009E90 File Offset: 0x00008090
		public static void SendCMD_ActiveGroup(params byte[] bytes)
		{
			UpStream.PrimaryCommandGenerator(16, CommandConst.CMD_allFadergroupSelect, false, bytes);
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x00009EA2 File Offset: 0x000080A2
		public static void SendCMD_AutoMixer(params byte[] bytes)
		{
			UpStream.PrimaryCommandGenerator(35, CommandConst.CMD_AutoMixAssign, false, bytes);
		}

		// Token: 0x06000924 RID: 2340 RVA: 0x00009EB4 File Offset: 0x000080B4
		public static void SendCMD_LoadDSPPreset(params byte[] bytes)
		{
			UpStream.PrimaryCommandGenerator(10, CommandConst.CMD_LoadDSPPreset, false, bytes);
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x00009EC6 File Offset: 0x000080C6
		public static void SendCMD_LoadGEQPreset(params byte[] bytes)
		{
			UpStream.PrimaryCommandGenerator(10, CommandConst.CMD_LoadGEQPreset, false, bytes);
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x00009ED8 File Offset: 0x000080D8
		public static void SendCMD_LoadFXPreset(params byte[] bytes)
		{
			UpStream.PrimaryCommandGenerator(10, CommandConst.CMD_LoadDfxPreset, false, bytes);
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x00009EEA File Offset: 0x000080EA
		public static void SendCMD_LoadScenePreset(params byte[] bytes)
		{
			UpStream.PrimaryCommandGenerator(10, CommandConst.CMD_LoadSencePreset, false, bytes);
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x00009EFC File Offset: 0x000080FC
		public static void SendCMD_Link(params byte[] bytes)
		{
			UpStream.PrimaryCommandGenerator(10, CommandConst.CMD_ChannelButtonClick, false, bytes);
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x00009F0E File Offset: 0x0000810E
		public static void SendClearSolo()
		{
			UpStream.PrimaryCommandGenerator(9, CommandConst.CMD_ClearSolo, false, new byte[1]);
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x00009F25 File Offset: 0x00008125
		public static void SendDefaultPreset(params byte[] bytes)
		{
			UpStream.PrimaryCommandGenerator(70, CommandConst.CMD_DefaultPreset, false, bytes);
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x00009F37 File Offset: 0x00008137
		public static void SendDeviceName(params byte[] bytes)
		{
			UpStream.PrimaryCommandGenerator(25, CommandConst.CMD_SetDeviceName, false, bytes);
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x00009F49 File Offset: 0x00008149
		public static void SendReadDeviceName(params byte[] bytes)
		{
			UpStream.PrimaryCommandGenerator(9, CommandConst.CMD_ReadDeviceName, false, bytes);
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x00009F5B File Offset: 0x0000815B
		public static void SendSetChannelName(params byte[] bytes)
		{
			UpStream.PrimaryCommandGenerator(17, CommandConst.CMD_SetChannelName, false, bytes);
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x00027B90 File Offset: 0x00025D90
		private static void PrimaryCommandGenerator(byte lenght, byte dataType, bool hasCheckBit = false, params byte[] bytes)
		{
			List<byte> list = UpStream.CommandGenerator();
			UpStream.InsertCommandlength(list, lenght, true);
			UpStream.InsertApp_ID(list);
			UpStream.InsertLocal_ID(list);
			UpStream.InsertDataType(list, dataType);
			UpStream.InsertData(list, bytes);
			bool flag = !hasCheckBit;
			if (flag)
			{
				list.Add(1);
			}
			else
			{
				list.Add(0);
			}
			UpStream.InsertStopBitAndCheckBit(list, hasCheckBit, true);
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x00027BF0 File Offset: 0x00025DF0
		private static List<byte> CommandGenerator()
		{
			return new List<byte> { 1, 32, 3 };
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x00009F6D File Offset: 0x0000816D
		private static void InsertCommandlength(List<byte> data, byte length, bool isSingle = true)
		{
			data.Add((byte)((int)length / 256));
			data.Add((byte)((int)length % 256));
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x00009F8E File Offset: 0x0000818E
		private static void InsertApp_ID(List<byte> data)
		{
			data.Add(0);
			data.Add(35);
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x00009FA2 File Offset: 0x000081A2
		private static void InsertLocal_ID(List<byte> data)
		{
			data.Add(0);
			data.Add(1);
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x00009FB5 File Offset: 0x000081B5
		private static void InsertDataType(List<byte> data, byte high, byte low)
		{
			data.Add(0);
			data.Add(high);
			data.Add(low);
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x00009FD0 File Offset: 0x000081D0
		private static void InsertDataType(List<byte> data, byte dataType)
		{
			data.Add(0);
			data.Add(dataType);
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x00027C24 File Offset: 0x00025E24
		private static void InsertData(List<byte> data, params byte[] datas)
		{
			bool flag = datas == null;
			if (!flag)
			{
				foreach (byte b in datas)
				{
					data.Add(b);
				}
			}
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x00027C5C File Offset: 0x00025E5C
		private static void InsertData(List<byte> data, byte sMode, byte split, params byte[] datas)
		{
			data.Add(sMode);
			data.Add(split);
			foreach (byte b in datas)
			{
				data.Add(b);
			}
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x00027C9C File Offset: 0x00025E9C
		private static void InsertData(List<byte> data, byte sMode, params byte[] datas)
		{
			data.Add(sMode);
			foreach (byte b in datas)
			{
				data.Add(b);
			}
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x00027CD4 File Offset: 0x00025ED4
		private static void InsertStopBitAndCheckBit(List<byte> data, bool hasCheckBit = false, bool calculateLength = true)
		{
			data.Add(64);
			data[3] = (byte)(data.Count / 256);
			data[4] = (byte)(data.Count % 256);
			byte b = data[10];
			bool flag = UpStream._HighFrequencyTransmission.Contains(b);
			if (flag)
			{
				Stack<List<byte>> stack;
				bool flag2 = UpStream._UpStreamDictionary.TryGetValue(b, out stack);
				if (flag2)
				{
					stack.Push(data);
				}
				else
				{
					UpStream._UpStreamDictionary[b] = new Stack<List<byte>>();
					UpStream._UpStreamDictionary[b].Push(data);
				}
			}
			else
			{
				UpStream.SendBytes(data.ToArray());
			}
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x00027D80 File Offset: 0x00025F80
		private static void SendCMD_PRIMARY(Cilent mclient, int machineType, int deviceID, byte length, byte cmdType, string message, byte[] data = null)
		{
			byte[] array = new byte[(int)length];
			LCommand lcommand = new LCommand((int)length, (int)cmdType)
			{
				ID_Machine = machineType,
				Device_ID = deviceID
			};
			bool flag = data == null || data.Length == 0;
			if (flag)
			{
				array = lcommand.getPackage_withoutDataArray();
			}
			else
			{
				array = lcommand.getPackage_withDataArray(data);
			}
			UpStream.Cal_checkSum_SendData(mclient, array, (int)length);
			Debug.WriteLine(message);
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x00027DE8 File Offset: 0x00025FE8
		private static void Cal_checkSum_SendData(Cilent mclient, byte[] m_Data, int count)
		{
			StringBuilder stringBuilder = new StringBuilder("Send CMD :");
			foreach (byte b in m_Data)
			{
				stringBuilder.Append(b.ToString("x2")).Append("-");
			}
			Debug.WriteLine(stringBuilder.ToString());
			byte b2 = m_Data[0];
			for (int j = 1; j < count; j++)
			{
				bool flag = j != count - 2;
				if (flag)
				{
					b2 ^= m_Data[j];
				}
			}
			m_Data[count - 2] = b2;
			bool flag2 = mclient != null;
			if (flag2)
			{
				mclient.sendByte(m_Data);
			}
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x00027E90 File Offset: 0x00026090
		private static void SendBytes(byte[] bytes)
		{
			bool flag = !UpStream.DuringProcessDownStream;
			if (flag)
			{
				IPProces.printAryByte("Send data: ", bytes);
				Cilent client = UpStream.Client;
				if (client != null)
				{
					client.sendByte(bytes);
				}
			}
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x00009FE3 File Offset: 0x000081E3
		public static void SendSceneSaveToDevice(params byte[] bytes)
		{
			UpStream.SendBytes(bytes);
		}

		// Token: 0x040004C6 RID: 1222
		private static Dictionary<byte, Stack<List<byte>>> _UpStreamDictionary = new Dictionary<byte, Stack<List<byte>>>();

		// Token: 0x040004C7 RID: 1223
		private static List<byte> _HighFrequencyTransmission = new List<byte>
		{
			CommandConst.CMD_LCDBlackLight,
			CommandConst.CMD_GroupSet,
			CommandConst.CMD_MUTE_GAIN,
			CommandConst.CMD_FatChannel,
			CommandConst.CMD_Equalizer,
			CommandConst.CMD_BusMixer,
			CommandConst.CMD_GATE,
			CommandConst.CMD_COMP_LIMIT
		};

		// Token: 0x040004C8 RID: 1224
		private static Timer _HighFrequencyTransmissionTimer = new Timer(100.0);
	}
}
