using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using T2208.MyDatas;
using T2208.MyInformations;
using T2208.ViewModels;

namespace T2208.DeviceCommuncation
{
	// Token: 0x020000B8 RID: 184
	public class UpStreamCommand
	{
		// Token: 0x0600093E RID: 2366 RVA: 0x00027ECC File Offset: 0x000260CC
		public static void SendMatrixValueChanged(ChannelInfo channelInfo)
		{
			List<byte> list = new List<byte>();
			for (int i = 0; i < 8; i++)
			{
				SystemIn systemIn = new SystemIn();
				list.Add(Convert.ToByte(systemIn.LeftGroup[i].IsSelected_Left));
			}
			for (int j = 0; j < 8; j++)
			{
				SystemIn systemIn2 = new SystemIn();
				list.Add(Convert.ToByte(systemIn2.LeftGroup[j].IsSelected_Right));
			}
			UpStream.SendMatrixValueChanged(list.ToArray());
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x00009FED File Offset: 0x000081ED
		public static void SendCMD_FatChannel(ChannelInfo channel)
		{
			UpStream.SendCMD_PackageOfChannel(UpStreamCommand.GetFatChannel(channel));
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x00027F60 File Offset: 0x00026160
		public static void SendCMD_FatChannelLink(ChannelInfo channelInfo)
		{
			byte[] fatChannel = UpStreamCommand.GetFatChannel(channelInfo);
			byte[] array = new byte[fatChannel.Length];
			Array.Copy(fatChannel, array, fatChannel.Length);
			array[0] = channelInfo.LinkChannel.ChannelIndex + 1;
			UpStream.SendCMD_PackageofChannelLink(fatChannel, array);
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x00027FA4 File Offset: 0x000261A4
		private static byte[] GetFatChannel(ChannelInfo channelInfo)
		{
			List<byte> list = new List<byte>();
			AuxFxItem auxFxItem = channelInfo.AuxGroup2.GroupCollection[0];
			AuxFxItem auxFxItem2 = channelInfo.AuxGroup2.GroupCollection[1];
			AuxFxItem auxFxItem3 = channelInfo.AuxGroup2.GroupCollection[2];
			AuxFxItem auxFxItem4 = channelInfo.AuxGroup2.GroupCollection[3];
			list.Add(channelInfo.ChannelIndex + 1);
			list.Add(channelInfo.Invert ? 1 : 0);
			list.Add((byte)channelInfo.GainValue);
			list.Add(channelInfo.IsMute ? 1 : 0);
			list.Add((byte)(channelInfo.SendDelayValue / 100.0));
			list.Add((byte)(channelInfo.SendDelayValue % 100.0));
			list.Add(channelInfo.DelayEnabled ? 0 : 1);
			list.Add(channelInfo.DigitalInput.IsFrontSet ? (channelInfo.DigitalInput.SendValue | 128) : channelInfo.DigitalInput.SendValue);
			list.Add(channelInfo.DC48VEnabled ? 1 : 0);
			list.Add(channelInfo.Link ? 1 : 0);
			list.Add((byte)channelInfo.PanValue);
			list.Add(channelInfo.AssignMain ? 1 : 0);
			list.Add((byte)(auxFxItem.IsFrontSet ? 128 : (0 | (int)auxFxItem.SendValue)));
			list.Add((byte)(auxFxItem2.IsFrontSet ? 128 : (0 | (int)auxFxItem2.SendValue)));
			list.Add((byte)(auxFxItem3.IsFrontSet ? 128 : (0 | (int)auxFxItem3.SendValue)));
			list.Add((byte)(auxFxItem4.IsFrontSet ? 128 : (0 | (int)auxFxItem4.SendValue)));
			list.Add(0);
			list.Add(0);
			return list.ToArray();
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x000281A8 File Offset: 0x000263A8
		public static void SendCMD_EqualizerAdjust(EqualizerInfo equalizerInfo, bool allBypasss, int equalizerIndex, byte channelIndex)
		{
			byte b = (equalizerInfo.IsHighLowPass ? ((byte)equalizerInfo.FilterIndex) : ((byte)(equalizerInfo.FilterIndex + 1)));
			byte b2 = (byte)(equalizerInfo.SendFreqIndex / 100);
			byte b3 = (byte)(equalizerInfo.SendFreqIndex % 100);
			byte b4 = (byte)equalizerInfo.SendQFactorIndex;
			byte b5 = (byte)equalizerInfo.SendGainIndex;
			byte bypass = equalizerInfo.Bypass;
			byte b6 = (allBypasss ? 0 : 1);
			UpStream.SendCMD_EQ(new byte[]
			{
				channelIndex + 1,
				(byte)equalizerIndex,
				b,
				b2,
				b3,
				b4,
				b5,
				bypass,
				b6
			});
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x00028244 File Offset: 0x00026444
		public static void SendCMD_ChannelsMuteGain()
		{
			byte[] array = new byte[ChannelData.ChannelDatas.DeviceChannels.Count];
			for (int i = 0; i < ChannelData.ChannelDatas.DeviceChannels.Count; i++)
			{
				ChannelInfo channelInfo = ChannelData.ChannelDatas.DeviceChannels[i];
				array[i] = (byte)((channelInfo.IsMute ? 128 : 0) + (int)channelInfo.SendGainValue);
			}
			for (int j = 0; j < ChannelData.ChannelDatas.DeviceChannels.Count - 1; j++)
			{
				ChannelInfo channelInfo2 = ChannelData.ChannelDatas.DeviceChannels[j];
				bool isStartLinkChannel = channelInfo2.IsStartLinkChannel;
				if (isStartLinkChannel)
				{
					int num = j / 2;
					ChannelInfo channelInfo3 = ChannelData.ChannelDatas.DeviceChannels[2 * num];
					ChannelInfo channelInfo4 = ChannelData.ChannelDatas.DeviceChannels[2 * num + 1];
					byte b = (byte)((channelInfo2.IsMute ? 128 : 0) + (int)channelInfo2.SendGainValue);
					array[2 * num] = b;
					array[2 * num + 1] = b;
				}
			}
			byte[] array2 = new byte[array.Length + 1];
			Array.Copy(array, 0, array2, 1, array.Length);
			UpStream.SendCMD_MuteGain(array2);
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x00028388 File Offset: 0x00026588
		public static void SendCMD_ChannelsSolo()
		{
			byte[] array = new byte[ChannelData.ChannelDatas.DeviceChannels.Count];
			for (int i = 0; i < ChannelData.ChannelDatas.DeviceChannels.Count; i++)
			{
				ChannelInfo channelInfo = ChannelData.ChannelDatas.DeviceChannels[i];
				array[i] = (channelInfo.IsSolo ? 1 : 0);
			}
			for (int j = 0; j < ChannelData.ChannelDatas.DeviceChannels.Count; j++)
			{
				ChannelInfo channelInfo2 = ChannelData.ChannelDatas.DeviceChannels[j];
				bool isStartLinkChannel = channelInfo2.IsStartLinkChannel;
				if (isStartLinkChannel)
				{
					int num = j / 2;
					ChannelInfo channelInfo3 = ChannelData.ChannelDatas.DeviceChannels[2 * num];
					ChannelInfo channelInfo4 = ChannelData.ChannelDatas.DeviceChannels[2 * num + 1];
					array[2 * num] = (channelInfo2.IsSolo ? 1 : 0);
					array[2 * num + 1] = (channelInfo2.IsSolo ? 1 : 0);
				}
			}
			byte[] array2 = new byte[array.Length + 1];
			Array.Copy(array, 0, array2, 1, array.Length);
			UpStream.SendCMD_Solo(array2);
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x00009FFC File Offset: 0x000081FC
		public static void SendCMD_Aux1_4FX1_2(ChannelInfo channel)
		{
			UpStream.SendCMD_BusMixer(UpStreamCommand.GetAuxFxDatas(channel));
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x000284B4 File Offset: 0x000266B4
		public static void SendCMD_Aux1_4FX1_2Link(ChannelInfo channel)
		{
			byte[] auxFxDatas = UpStreamCommand.GetAuxFxDatas(channel);
			byte[] array = new byte[auxFxDatas.Length];
			Array.Copy(auxFxDatas, array, auxFxDatas.Length);
			array[0] = channel.LinkChannel.ChannelIndex + 1;
			UpStream.SendCMD_BusMixerLink(auxFxDatas, array);
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x000284F8 File Offset: 0x000266F8
		private static byte[] GetAuxFxDatas(ChannelInfo channelInfo)
		{
			byte b = channelInfo.ChannelIndex + 1;
			List<byte> list = new List<byte> { b };
			List<byte> list2 = new List<byte>();
			foreach (AuxFxItem auxFxItem in channelInfo.AuxGroup1.GroupCollection)
			{
				list.Add((byte)auxFxItem.SendValue);
				list2.Add(auxFxItem.IsFrontSet ? 1 : 0);
			}
			foreach (AuxFxItem auxFxItem2 in channelInfo.FXGroup.GroupCollection)
			{
				list.Add((byte)auxFxItem2.SendValue);
				list2.Add(auxFxItem2.IsFrontSet ? 1 : 0);
			}
			list.AddRange(list2);
			return list.ToArray();
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x00028608 File Offset: 0x00026808
		public static void SendCMD_ChannelNoiseGate(ChannelInfo channel)
		{
			byte b = channel.ChannelIndex + 1;
			List<byte> list = new List<byte> { b };
			list.Add(channel.NoiseGateInfo.Threshold);
			list.Add((byte)(channel.NoiseGateInfo.Attack / 100));
			list.Add((byte)(channel.NoiseGateInfo.Attack % 100));
			list.Add((byte)(channel.NoiseGateInfo.Release / 100));
			list.Add((byte)(channel.NoiseGateInfo.Release % 100));
			list.Add(channel.NoiseGateInfo.NoiseGateEnable ? 0 : 1);
			UpStream.SendCMD_Gate(list.ToArray());
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x000286C0 File Offset: 0x000268C0
		public static void SendCMD_ChannelCompressor(ChannelInfo channel)
		{
			byte b = channel.ChannelIndex + 1;
			List<byte> list = new List<byte> { b };
			list.Add(channel.CompressorInfo.Threshold);
			list.Add((byte)(channel.CompressorInfo.Attack / 100));
			list.Add((byte)(channel.CompressorInfo.Attack % 100));
			list.Add((byte)(channel.CompressorInfo.Release / 100));
			list.Add((byte)(channel.CompressorInfo.Release % 100));
			list.Add(channel.CompressorInfo.Ratio);
			list.Add(channel.CompressorInfo.SendGain);
			list.Add(channel.CompressorInfo.CompressorEnable ? 0 : 1);
			UpStream.SendCMD_Compressor(list.ToArray());
		}

		// Token: 0x0600094A RID: 2378 RVA: 0x0002879C File Offset: 0x0002699C
		public static void SendCMD_TempDCAGroupSet(DCAInfo<DCAItem> DCAGroup)
		{
			List<byte> list = new List<byte> { (byte)(DCAGroup.DCAIndex + 1) };
			list.Add((byte)DCAGroup.Value);
			list.Add(DCAGroup.IsMute ? 1 : 0);
			list.Add((byte)DCAGroup.SceneIndex);
			for (int i = 0; i < 12; i++)
			{
				list.Add(DCAGroup.NameBytes[i]);
			}
			for (int j = 0; j < 34; j++)
			{
				list.Add(DCAGroup.GroupCollection[j].IsSelected ? 1 : 0);
			}
			UpStream.SendCMD_TempDCAGroupSet(list.ToArray());
		}

		// Token: 0x0600094B RID: 2379 RVA: 0x00028854 File Offset: 0x00026A54
		public static void SendCMD_DCAGroupSet(DCAInfo<DCAItem> DCAGroup)
		{
			List<byte> list = new List<byte> { (byte)(DCAGroup.DCAIndex + 1) };
			list.Add((byte)DCAGroup.SendValue);
			list.Add(DCAGroup.IsMute ? 1 : 0);
			list.Add((byte)DCAGroup.SceneIndex);
			for (int i = 0; i < 12; i++)
			{
				list.Add(DCAGroup.NameBytes[i]);
			}
			foreach (DCAItem dcaitem in DCAGroup.GroupCollection)
			{
				list.Add(dcaitem.IsSelected ? 1 : 0);
			}
			UpStream.SendCMD_DCAGroupSet(list.ToArray());
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x00028928 File Offset: 0x00026B28
		public static void SendCMD_DCAGroupClear(DCAInfo<DCAItem> DCAGroup)
		{
			List<byte> list = new List<byte> { (byte)(DCAGroup.DCAIndex + 1) };
			list.Add((byte)DCAGroup.SendValue);
			list.Add(DCAGroup.IsMute ? 1 : 0);
			list.Add((byte)DCAGroup.SceneIndex);
			for (int i = 0; i < 12; i++)
			{
				list.Add(DCAGroup.NameBytes[i]);
			}
			foreach (DCAItem dcaitem in DCAGroup.GroupCollection)
			{
				list.Add(0);
			}
			UpStream.SendCMD_DCAGroupSet(list.ToArray());
			UpStream.SendCMD_TempDCAGroupSet(list.ToArray());
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x000289FC File Offset: 0x00026BFC
		public static void SendCMD_DCAGroupSelect(DCAInfo<DCAItem> DCAGroup)
		{
			List<byte> list = new List<byte>
			{
				0,
				(byte)(DCAGroup.DCAIndex + 1)
			};
			list.Add((byte)DCAGroup.Value);
			list.Add(DCAGroup.IsSelected ? 1 : 0);
			list.Add(0);
			list.Add(DCAGroup.IsMute ? 1 : 0);
			UpStream.SendCMD_ActiveGroup(list.ToArray());
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x00028A74 File Offset: 0x00026C74
		public static void SendSynchronizePage(byte uiIndex1 = 0, byte uiIndex2 = 0, byte uiIndex3 = 0, byte uiIndex4 = 0)
		{
			bool flag = PageData.UiIndex1 == uiIndex1 && PageData.UiIndex2 == uiIndex2 && PageData.UiIndex3 == uiIndex3 && PageData.UiIndex4 == uiIndex4;
			if (!flag)
			{
				UpStream.SendCMD_SwitchPage(uiIndex1, uiIndex2, uiIndex3, uiIndex4);
			}
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x00028AB8 File Offset: 0x00026CB8
		public static void SendSynchronizePage(params byte[] bytes)
		{
			bool flag = bytes.Length == 1;
			if (flag)
			{
				UpStreamCommand.SendSynchronizePage(bytes[0], 0, 0, 0);
			}
			else
			{
				bool flag2 = bytes.Length == 2;
				if (flag2)
				{
					UpStreamCommand.SendSynchronizePage(bytes[0], bytes[1], 0, 0);
				}
				else
				{
					bool flag3 = bytes.Length == 3;
					if (flag3)
					{
						UpStreamCommand.SendSynchronizePage(bytes[0], bytes[1], bytes[2], 0);
					}
					else
					{
						bool flag4 = bytes.Length == 4;
						if (flag4)
						{
							UpStreamCommand.SendSynchronizePage(bytes[0], bytes[1], bytes[2], bytes[3]);
						}
					}
				}
			}
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x0000A00B File Offset: 0x0000820B
		public static void SendRouteAllPost(byte routeIndex, byte isAllPost)
		{
			UpStream.SendCMD_AllPost(new byte[] { routeIndex, isAllPost });
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x00028B38 File Offset: 0x00026D38
		public static void SendAutoMixer(ObservableCollection<ButtonItem> inputGroup, bool autoMixerActive)
		{
			List<byte> list = new List<byte>();
			foreach (ButtonItem buttonItem in inputGroup)
			{
				list.Add(buttonItem.IsSelected ? 1 : 0);
			}
			list.Add(autoMixerActive ? 0 : 1);
			UpStream.SendCMD_AutoMixer(list.ToArray());
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x00028BB4 File Offset: 0x00026DB4
		public static void SendGEQChange(GEQInfo geqInfo, byte deviceIndex, bool isFlat = false)
		{
			List<byte> list = new List<byte> { deviceIndex };
			bool flag = !isFlat;
			if (flag)
			{
				foreach (GEQFrequenceValue geqfrequenceValue in geqInfo.GEQArray)
				{
					list.Add((byte)geqfrequenceValue.GainValue);
				}
			}
			else
			{
				foreach (GEQFrequenceValue geqfrequenceValue2 in geqInfo.GEQArray)
				{
					list.Add(24);
				}
			}
			list.Add(geqInfo.Bypass ? 1 : 0);
			UpStream.SendCMD_GEQChange(list.ToArray());
		}

		// Token: 0x06000953 RID: 2387 RVA: 0x00028C98 File Offset: 0x00026E98
		public static void SendDigitalOutput(bool allPost, params ChannelInfo[] channelInfoArray)
		{
			List<byte> list = new List<byte> { 0 };
			for (int i = 0; i < 20; i++)
			{
				byte sendValue = channelInfoArray[i].DigitalOutput.SendValue;
				byte b = (channelInfoArray[i].DigitalOutput.IsFrontSet ? 128 : 0);
				byte b2 = sendValue | b;
				list.Add(b2);
			}
			for (int j = 24; j < 34; j++)
			{
				byte sendValue2 = channelInfoArray[j].DigitalOutput.SendValue;
				byte b3 = (channelInfoArray[j].DigitalOutput.IsFrontSet ? 128 : 0);
				byte b4 = sendValue2 | b3;
				list.Add(b4);
			}
			list.Add(allPost ? 0 : 1);
			UpStream.SendCMD_DigitalOutGain(list.ToArray());
		}

		// Token: 0x06000954 RID: 2388 RVA: 0x00028D70 File Offset: 0x00026F70
		public static void SendFxChange(int fxIndex, int effectIndex, ObservableCollection<EffectInfo> effectInfos)
		{
			List<byte> list = new List<byte>
			{
				(byte)(fxIndex + 1),
				(byte)(effectIndex + 1)
			};
			for (int i = 0; i < 12; i++)
			{
				bool flag = i < effectInfos.Count;
				if (flag)
				{
					list.Add(FXData.GetEffectIndexFromUi((byte)effectIndex, (byte)i, (byte)effectInfos[i].EffectSendValue));
				}
				else
				{
					list.Add(0);
				}
			}
			list.Add(ChannelData.ChannelDatas.FXs[fxIndex].IsMute ? 1 : 0);
			UpStream.SendCMD_DFX(list.ToArray());
		}

		// Token: 0x06000955 RID: 2389 RVA: 0x0000A022 File Offset: 0x00008222
		public static void SendEqualizerFlat(int channelIndex)
		{
			UpStream.SendCMD_EQFlat((byte)(channelIndex + 1));
		}

		// Token: 0x06000956 RID: 2390 RVA: 0x0000A02F File Offset: 0x0000822F
		public static void SendReadPresetList(PresetType presetType)
		{
			UpStream.SendCMD_ReadPresetList(new byte[] { (byte)presetType });
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x00028E14 File Offset: 0x00027014
		public static void SendLoadPreset(PresetType presetType, byte channelIndex, byte presetIndex)
		{
			switch (presetType)
			{
			case PresetType.DSP:
				UpStream.SendCMD_LoadDSPPreset(new byte[] { channelIndex, presetIndex });
				break;
			case PresetType.GEQ:
				UpStream.SendCMD_LoadGEQPreset(new byte[] { channelIndex, presetIndex });
				break;
			case PresetType.FX:
				UpStream.SendCMD_LoadFXPreset(new byte[] { channelIndex, presetIndex });
				break;
			case PresetType.Scene:
				UpStream.SendCMD_LoadScenePreset(new byte[] { channelIndex, presetIndex });
				break;
			}
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x00028E98 File Offset: 0x00027098
		public static void SendSavePreset(PresetType presetType, byte channelIndex, byte presetIndex, string presetName)
		{
			byte b = (byte)presetType;
			List<byte> list = new List<byte> { b, channelIndex, presetIndex };
			for (int i = 0; i < 16; i++)
			{
				bool flag = i < presetName.Length;
				if (flag)
				{
					list.Add((byte)presetName[i]);
				}
				else
				{
					list.Add(32);
				}
			}
			UpStream.SendCMD_SavePresetToDevice(list.ToArray());
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x0000A043 File Offset: 0x00008243
		public static void SendDeletePreset(byte presetType, byte presetIndex)
		{
			UpStream.SendCMD_DeletePreset(presetType, presetIndex);
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x0000A04E File Offset: 0x0000824E
		public static void SendDeletePreset(PresetType presetType, byte presetIndex)
		{
			UpStreamCommand.SendDeletePreset((byte)presetType, presetIndex);
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x0000A05A File Offset: 0x0000825A
		public static void SendCopyChannel(params byte[] bytes)
		{
			UpStream.SendCMD_CopyChannel(bytes);
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x0000A064 File Offset: 0x00008264
		public static void SendChannelLink(ChannelInfo channelInfo)
		{
			UpStream.SendCMD_Link(new byte[]
			{
				channelInfo.ChannelIndex + 1,
				1
			});
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x0000A083 File Offset: 0x00008283
		public static void SendReadPresentGUI()
		{
			UpStream.SendCMD_ReadGUIIndex();
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x00028F14 File Offset: 0x00027114
		public static void SendLoadPresetFromPC(ChannelInfo channelInfo, byte channelIndex)
		{
			byte b = 1;
			List<byte> list = new List<byte>
			{
				b,
				channelIndex + 1
			};
			list.Add(channelInfo.Invert ? 1 : 0);
			list.Add((byte)channelInfo.GainValue);
			list.Add(channelInfo.IsMute ? 1 : 0);
			list.Add((byte)(channelInfo.SendDelayValue / 100.0));
			list.Add((byte)(channelInfo.SendDelayValue % 100.0));
			list.Add(channelInfo.DelayEnabled ? 0 : 1);
			list.Add(channelInfo.NoiseGateInfo.Threshold);
			list.Add((byte)(channelInfo.NoiseGateInfo.Attack / 100));
			list.Add((byte)(channelInfo.NoiseGateInfo.Attack % 100));
			list.Add((byte)(channelInfo.NoiseGateInfo.Release / 100));
			list.Add((byte)(channelInfo.NoiseGateInfo.Release % 100));
			list.Add(channelInfo.NoiseGateInfo.Bypass);
			foreach (EqualizerInfo equalizerInfo in channelInfo.EqualizerInfos)
			{
				list.Add((byte)(equalizerInfo.IsHighLowPass ? equalizerInfo.FilterIndex : ((int)((byte)(equalizerInfo.FilterIndex + 1)))));
				list.Add((byte)(equalizerInfo.FreqIndex / 100));
				list.Add((byte)(equalizerInfo.FreqIndex % 100));
				list.Add(equalizerInfo.QFactorIndex);
				list.Add((byte)equalizerInfo.GainIndex);
				list.Add(equalizerInfo.Bypass);
			}
			list.Add(channelInfo.EqualizerAllBypass ? 1 : 0);
			list.Add(channelInfo.CompressorInfo.Threshold);
			list.Add((byte)(channelInfo.CompressorInfo.Attack / 100));
			list.Add((byte)(channelInfo.CompressorInfo.Attack % 100));
			list.Add((byte)(channelInfo.CompressorInfo.Release / 100));
			list.Add((byte)(channelInfo.CompressorInfo.Release % 100));
			list.Add(channelInfo.CompressorInfo.Ratio);
			list.Add(channelInfo.CompressorInfo.Gain);
			list.Add(channelInfo.CompressorInfo.Bypass);
			UpStream.SendCMD_LoadPresetFromPC(list.ToArray());
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x000291A4 File Offset: 0x000273A4
		public static void SendLoadPresetFromPC(byte[] data, byte channelIndex)
		{
			byte b = 1;
			List<byte> list = new List<byte>
			{
				b,
				channelIndex + 1
			};
			list.AddRange(data);
			UpStream.SendCMD_LoadPresetFromPC(list.ToArray());
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x000291E4 File Offset: 0x000273E4
		public static void SendLoadPresetFromPC(GEQInfo geqInfo, byte deviceChannelIndex)
		{
			List<byte> list = new List<byte> { 2, deviceChannelIndex };
			foreach (GEQFrequenceValue geqfrequenceValue in geqInfo.GEQArray)
			{
				list.Add((byte)geqfrequenceValue.GainValue);
			}
			list.Add(geqInfo.Bypass ? 1 : 0);
			UpStream.SendCMD_LoadPresetFromPC(list.ToArray());
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x00029278 File Offset: 0x00027478
		public static void SendLoadPresetFromPC(FXInfo<FXItem> fxInfo, byte fxIndex)
		{
			List<byte> list = new List<byte>
			{
				3,
				fxIndex + 1
			};
			list.Add((byte)(fxInfo.PresentFXIndex + 1));
			ObservableCollection<EffectInfo> effect = fxInfo.GroupCollection[fxInfo.PresentFXIndex].Effect;
			for (int i = 0; i < 12; i++)
			{
				bool flag = i < effect.Count;
				if (flag)
				{
					list.Add(FXData.GetEffectIndexFromUi((byte)fxInfo.PresentFXIndex, (byte)i, (byte)effect[i].EffectValue));
				}
				else
				{
					list.Add(0);
				}
			}
			UpStream.SendCMD_LoadPresetFromPC(list.ToArray());
		}

		// Token: 0x06000962 RID: 2402 RVA: 0x00029324 File Offset: 0x00027524
		public static void SendLoadPresetFromPC(SceneInfo sceneInfo)
		{
			List<byte> list = new List<byte> { 4 };
			foreach (ChannelInfo channelInfo in sceneInfo.Channels)
			{
				List<byte> list2 = new List<byte>();
				list2.Add(channelInfo.Invert ? 1 : 0);
				list2.Add((byte)channelInfo.GainValue);
				list2.Add(channelInfo.IsMute ? 1 : 0);
				list2.Add((byte)(channelInfo.DelayValue / 100));
				list2.Add((byte)(channelInfo.DelayValue % 100));
				list2.Add(channelInfo.DelayEnabled ? 0 : 1);
				list2.Add(channelInfo.NoiseGateInfo.Threshold);
				list2.Add((byte)(channelInfo.NoiseGateInfo.Attack / 100));
				list2.Add((byte)(channelInfo.NoiseGateInfo.Attack % 100));
				list2.Add((byte)(channelInfo.NoiseGateInfo.Release / 100));
				list2.Add((byte)(channelInfo.NoiseGateInfo.Release % 100));
				list2.Add(channelInfo.NoiseGateInfo.Bypass);
				foreach (EqualizerInfo equalizerInfo in channelInfo.EqualizerInfos)
				{
					list2.Add((byte)(equalizerInfo.IsHighLowPass ? equalizerInfo.FilterIndex : ((int)((byte)(equalizerInfo.FilterIndex + 1)))));
					list2.Add((byte)(equalizerInfo.FreqIndex / 100));
					list2.Add((byte)(equalizerInfo.FreqIndex % 100));
					list2.Add(equalizerInfo.QFactorIndex);
					list2.Add((byte)equalizerInfo.GainIndex);
					list2.Add(equalizerInfo.Bypass);
				}
				list2.Add(channelInfo.EqualizerAllBypass ? 1 : 0);
				list2.Add(channelInfo.CompressorInfo.Threshold);
				list2.Add((byte)(channelInfo.CompressorInfo.Attack / 100));
				list2.Add((byte)(channelInfo.CompressorInfo.Attack % 100));
				list2.Add((byte)(channelInfo.CompressorInfo.Release / 100));
				list2.Add((byte)(channelInfo.CompressorInfo.Release % 100));
				list2.Add(channelInfo.CompressorInfo.Ratio);
				list2.Add(channelInfo.CompressorInfo.Gain);
				list2.Add(channelInfo.CompressorInfo.Bypass);
				list2.Add((byte)channelInfo.PanValue);
				list2.Add(channelInfo.IsSolo ? 1 : 0);
				list2.Add(channelInfo.AssignMain ? 1 : 0);
				list2.Add(0);
				list2.Add(0);
				list2.Add(0);
				list2.Add(0);
				list2.Add((byte)channelInfo.AuxGroup1.GroupCollection[0].Value);
				list2.Add((byte)channelInfo.AuxGroup1.GroupCollection[1].Value);
				list2.Add((byte)channelInfo.AuxGroup1.GroupCollection[2].Value);
				list2.Add((byte)channelInfo.AuxGroup1.GroupCollection[3].Value);
				list2.Add((byte)channelInfo.FXGroup.GroupCollection[0].Value);
				list2.Add((byte)channelInfo.FXGroup.GroupCollection[1].Value);
				list2.Add(channelInfo.AuxGroup1.GroupCollection[0].IsFrontSet ? 1 : 0);
				list2.Add(channelInfo.AuxGroup1.GroupCollection[1].IsFrontSet ? 1 : 0);
				list2.Add(channelInfo.AuxGroup1.GroupCollection[2].IsFrontSet ? 1 : 0);
				list2.Add(channelInfo.AuxGroup1.GroupCollection[3].IsFrontSet ? 1 : 0);
				list2.Add(channelInfo.FXGroup.GroupCollection[0].IsFrontSet ? 1 : 0);
				list2.Add(channelInfo.FXGroup.GroupCollection[1].IsFrontSet ? 1 : 0);
				list2.Add(channelInfo.IsStartLinkChannel ? 1 : 0);
				list2.Add((byte)(channelInfo.DigitalInput.IsFrontSet ? (channelInfo.DigitalInput.Value | 128) : channelInfo.DigitalInput.Value));
				list2.Add(channelInfo.DC48VEnabled ? 1 : 0);
				list2.Add(0);
				list2.Add(0);
				for (int i = 0; i < 8; i++)
				{
					bool flag = i < channelInfo.ChannelName.Length;
					if (flag)
					{
						list2.Add((byte)channelInfo.ChannelName[i]);
					}
					else
					{
						list2.Add(0);
					}
				}
				foreach (AuxFxItem auxFxItem in channelInfo.AuxGroup2.GroupCollection)
				{
					list2.Add((byte)auxFxItem.Value);
				}
				foreach (AuxFxItem auxFxItem2 in channelInfo.AuxGroup2.GroupCollection)
				{
					list2.Add(auxFxItem2.IsFrontSet ? 1 : 0);
				}
				list.AddRange(list2);
			}
			foreach (FXInfo<FXItem> fxinfo in sceneInfo.FXs)
			{
				List<byte> list3 = new List<byte>();
				list3.Add((byte)fxinfo.PresentFXIndex);
				foreach (FXItem fxitem in fxinfo.GroupCollection)
				{
					for (int j = 0; j < 12; j++)
					{
						bool flag2 = j < fxitem.Effect.Count;
						if (flag2)
						{
							list3.Add((byte)fxitem.Effect[j].EffectValue);
						}
						else
						{
							list3.Add(0);
						}
					}
				}
				list.AddRange(list3);
			}
			foreach (GEQInfo geqinfo in sceneInfo.GEQs)
			{
				List<byte> list4 = new List<byte>();
				foreach (GEQFrequenceValue geqfrequenceValue in geqinfo.GEQArray)
				{
					list4.Add((byte)geqfrequenceValue.GainValue);
				}
				list4.Add(geqinfo.Bypass ? 1 : 0);
				list.AddRange(list4);
			}
			List<byte> list5 = new List<byte>();
			List<ChannelInfo> list6 = new List<ChannelInfo>();
			list6.AddRange(ChannelData.ChannelDatas.CH01_24);
			list6.AddRange(ChannelData.ChannelDatas.Aux1_8);
			list6.Add(ChannelData.ChannelDatas.Main);
			list6.Add(ChannelData.ChannelDatas.Solo);
			foreach (ChannelInfo channelInfo2 in list6)
			{
				byte sendValue = channelInfo2.DigitalOutput.SendValue;
				byte b = (channelInfo2.DigitalOutput.IsFrontSet ? 128 : 0);
				byte b2 = sendValue | b;
				list5.Add(b2);
			}
			list.AddRange(list5);
			foreach (DCAInfo<DCAItem> dcainfo in sceneInfo.DCAs)
			{
				List<byte> list7 = new List<byte>();
				list7.Add((byte)dcainfo.Value);
				list7.Add(dcainfo.IsMute ? 1 : 0);
				list7.Add((byte)dcainfo.SceneIndex);
				for (int k = 0; k < 12; k++)
				{
					bool flag3 = k < dcainfo.GroupName.Length;
					if (flag3)
					{
						list7.Add((byte)dcainfo.GroupName[k]);
					}
					else
					{
						list7.Add(0);
					}
				}
				list7.AddRange(dcainfo.Channels);
				list.AddRange(list7);
			}
			List<byte> list8 = new List<byte>();
			foreach (ChannelInfo channelInfo3 in sceneInfo.Channels)
			{
				list8.Add((byte)channelInfo3.PresetIndex);
			}
			foreach (FXInfo<FXItem> fxinfo2 in sceneInfo.FXs)
			{
				list8.Add((byte)fxinfo2.PresetIndex);
			}
			foreach (GEQInfo geqinfo2 in sceneInfo.GEQs)
			{
				list8.Add((byte)geqinfo2.PresetIndex);
			}
			list8.Add(sceneInfo.PresetIndex);
			list8.Add(sceneInfo.SystemInfo.PFLFlag);
			list8.Add(sceneInfo.SystemInfo.LCDValue);
			list8.Add(sceneInfo.SystemInfo.KnobValue);
			list8.Add(0);
			list8.Add(0);
			list8.Add(0);
			list8.Add(0);
			list8.Add(0);
			list8.Add(sceneInfo.SystemInfo.DefaultPage);
			list.AddRange(list8);
			UpStream.SendCMD_LoadPresetFromPC(new byte[0]);
		}

		// Token: 0x06000963 RID: 2403 RVA: 0x00029F38 File Offset: 0x00028138
		public static void SendLoadPresetFromPC(byte[] sceneInfo)
		{
			List<byte> list = new List<byte> { 4 };
			list.AddRange(sceneInfo);
			UpStream.SendCMD_LoadScenePresetFromPC(list.ToArray());
		}

		// Token: 0x06000964 RID: 2404 RVA: 0x0000A08C File Offset: 0x0000828C
		public static void SendClearSolo()
		{
			UpStream.SendClearSolo();
		}

		// Token: 0x06000965 RID: 2405 RVA: 0x00029F68 File Offset: 0x00028168
		public static void SendDefaultPreset()
		{
			List<byte> list = new List<byte> { 0 };
			foreach (ChannelInfo channelInfo in ChannelData.ChannelDatas.DeviceChannels)
			{
				list.Add((byte)channelInfo.PresetIndex);
			}
			foreach (FXInfo<FXItem> fxinfo in FXData.FXs)
			{
				list.Add((byte)fxinfo.PresetIndex);
			}
			foreach (GEQInfo geqinfo in GEQData.GEQDatas.GEQs)
			{
				list.Add((byte)geqinfo.PresetIndex);
			}
			list.Add(SceneData.SceneInfo.PresetIndex);
			list.Add(SceneData.SceneInfo.PFL ? 0 : 1);
			list.Add(SceneData.SceneInfo.SystemInfo.LCDValue);
			list.Add(SceneData.SceneInfo.SystemInfo.KnobValue);
			list.Add(0);
			list.Add(0);
			list.Add(0);
			list.Add(0);
			list.Add(SceneData.SceneInfo.SystemInfo.AuxBusMode);
			list.Add(0);
			list.Add(SceneData.SceneInfo.SystemInfo.DefaultPage);
			UpStream.SendDefaultPreset(list.ToArray());
		}

		// Token: 0x06000966 RID: 2406 RVA: 0x0000A095 File Offset: 0x00008295
		public static void SendReset()
		{
			UpStream.SendCMD_ResetToFactory();
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x0002A130 File Offset: 0x00028330
		public static void SendSetDeviceName()
		{
			List<byte> list = new List<byte> { 0 };
			bool flag = SceneData.SceneInfo.SystemInfo.Name == null;
			if (flag)
			{
				MessageBox.Show("Cannot be empty");
			}
			else
			{
				bool flag2 = SceneData.SceneInfo.SystemInfo.Name.Length < 1;
				if (flag2)
				{
					MessageBox.Show("Cannot be empty");
				}
				else
				{
					for (int i = 0; i < 16; i++)
					{
						bool flag3 = i < SceneData.SceneInfo.SystemInfo.Name.Length;
						if (flag3)
						{
							list.Add((byte)SceneData.SceneInfo.SystemInfo.Name[i]);
						}
						else
						{
							list.Add(32);
						}
					}
					UpStream.SendDeviceName(list.ToArray());
				}
			}
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x0000A09E File Offset: 0x0000829E
		public static void SendLCDKnobChange(byte lcd, byte knob)
		{
			UpStream.SendCMD_LEDBackLight(lcd, knob);
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x0000A0A9 File Offset: 0x000082A9
		public static void SendReadDeviceName()
		{
			UpStream.SendReadDeviceName(new byte[0]);
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x0002A208 File Offset: 0x00028408
		public static void SendSetChannelName(ChannelInfo channelInfo)
		{
			List<byte> list = new List<byte> { channelInfo.ChannelIndex + 1 };
			for (int i = 0; i < 8; i++)
			{
				bool flag = i < channelInfo.InputName.Length;
				if (flag)
				{
					list.Add((byte)channelInfo.InputName[i]);
				}
				else
				{
					list.Add(0);
				}
			}
			UpStream.SendSetChannelName(list.ToArray());
		}
	}
}
