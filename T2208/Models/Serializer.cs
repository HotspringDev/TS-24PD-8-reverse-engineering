using System;
using System.Collections.Generic;
using CommLibrary;
using T2208.MyDatas;
using T2208.MyInformations;
using T2208.ViewModels;

namespace T2208.Models
{
	// Token: 0x020000A0 RID: 160
	public static class Serializer
	{
		// Token: 0x06000842 RID: 2114 RVA: 0x0002495C File Offset: 0x00022B5C
		public static bool Serialize(ChannelInfo channelInfo, string filePath)
		{
			List<byte> list = new List<byte>();
			list.Add(channelInfo.Invert ? 1 : 0);
			list.Add((byte)channelInfo.GainValue);
			list.Add(channelInfo.IsMute ? 1 : 0);
			list.Add((byte)(channelInfo.DelayValue / 100));
			list.Add((byte)(channelInfo.DelayValue % 100));
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
			list.Add(channelInfo.EqualizerAllBypass ? 0 : 1);
			list.Add(channelInfo.CompressorInfo.Threshold);
			list.Add((byte)(channelInfo.CompressorInfo.Attack / 100));
			list.Add((byte)(channelInfo.CompressorInfo.Attack % 100));
			list.Add((byte)(channelInfo.CompressorInfo.Release / 100));
			list.Add((byte)(channelInfo.CompressorInfo.Release % 100));
			list.Add(channelInfo.CompressorInfo.Ratio);
			list.Add(channelInfo.CompressorInfo.Gain);
			list.Add(channelInfo.CompressorInfo.Bypass);
			return IOBinaryOperation.WriteBinaryToFile(filePath, list.ToArray());
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x00024BCC File Offset: 0x00022DCC
		public static bool Serialize(GEQInfo geqInfo, string filePath)
		{
			List<byte> list = new List<byte>();
			foreach (GEQFrequenceValue geqfrequenceValue in geqInfo.GEQArray)
			{
				list.Add((byte)geqfrequenceValue.GainValue);
			}
			list.Add(geqInfo.Bypass ? 1 : 0);
			return IOBinaryOperation.WriteBinaryToFile(filePath, list.ToArray());
		}

		// Token: 0x06000844 RID: 2116 RVA: 0x00024C54 File Offset: 0x00022E54
		public static bool Serialize(FXInfo<FXItem> fxInfo, string filePath)
		{
			List<byte> list = new List<byte>();
			list.Add((byte)(fxInfo.PresentFXIndex + 1));
			for (int i = 0; i < 12; i++)
			{
				bool flag = i < fxInfo.GroupCollection[fxInfo.PresentFXIndex].Effect.Count;
				if (flag)
				{
					list.Add((byte)fxInfo.GroupCollection[fxInfo.PresentFXIndex].Effect[i].EffectValue);
				}
				else
				{
					list.Add(0);
				}
			}
			return IOBinaryOperation.WriteBinaryToFile(filePath, list.ToArray());
		}

		// Token: 0x06000845 RID: 2117 RVA: 0x00024CF8 File Offset: 0x00022EF8
		public static bool Serialize(SceneInfo sceneInfo, string filePath)
		{
			List<byte> list = new List<byte>();
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
				list2.Add(channelInfo.EqualizerAllBypass ? 0 : 1);
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
				list2.Add(0);
				list2.Add(0);
				list2.Add(0);
				list.AddRange(list2);
			}
			foreach (FXInfo<FXItem> fxinfo in sceneInfo.FXs)
			{
				List<byte> list3 = new List<byte>();
				list3.Add((byte)fxinfo.PresentFXIndex);
				foreach (FXItem fxitem in fxinfo.GroupCollection)
				{
					byte b = (byte)fxinfo.GroupCollection.IndexOf(fxitem);
					for (int j = 0; j < 12; j++)
					{
						bool flag2 = j < fxitem.Effect.Count;
						if (flag2)
						{
							list3.Add(FXData.GetEffectIndexFromUi(b, (byte)j, (byte)fxitem.Effect[j].EffectValue));
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
			list6.AddRange(sceneInfo.Channels.GetRange(0, 16));
			list6.AddRange(sceneInfo.Channels.GetRange(16, 8));
			list6.AddRange(sceneInfo.Channels.GetRange(24, 2));
			list6.Add(sceneInfo.Channels[29]);
			list6.Add(sceneInfo.Solo);
			foreach (ChannelInfo channelInfo2 in list6)
			{
				byte sendValue = channelInfo2.DigitalOutput.SendValue;
				byte b2 = (channelInfo2.DigitalOutput.IsFrontSet ? 128 : 0);
				byte b3 = sendValue | b2;
				list5.Add(b3);
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
			list8.Add(0);
			list8.Add(sceneInfo.SystemInfo.DefaultPage);
			list.AddRange(list8);
			return IOBinaryOperation.WriteBinaryToFile(filePath, list.ToArray());
		}
	}
}
