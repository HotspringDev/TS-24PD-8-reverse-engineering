using System;
using System.Text;
using T2208.DeviceCommuncation;
using T2208.Models;
using T2208.MyDatas;
using T2208.MyInformations;

namespace T2208.ViewModels
{
	// Token: 0x02000030 RID: 48
	public class DSP : ViewModelBase
	{
		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x00013D30 File Offset: 0x00011F30
		// (set) Token: 0x060001F3 RID: 499 RVA: 0x000049B9 File Offset: 0x00002BB9
		public ChannelInfo ChannelInfo
		{
			get
			{
				return this._ChannelInfo;
			}
			set
			{
				this._ChannelInfo = value;
				this.OnPropertyChanged<ChannelInfo>(() => this.ChannelInfo);
			}
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00013D48 File Offset: 0x00011F48
		public DSP()
		{
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_SyncCommand), new Action<byte[]>(this.SynchronicExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_DC48V), new Action<byte[]>(this.DC48VExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_ReadMeter), new Action<byte[]>(this.MeterExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_MUTE_GAIN), new Action<byte[]>(this.UpdateMuteGainExeucte));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_SOLO), new Action<byte[]>(this.UpdateSoloExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_ReadCurrentScene), new Action<byte[]>(this.ReadCurrentSceneExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_FatChannel), new Action<byte[]>(this.UpdateChannelExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_Equalizer), new Action<byte[]>(this.UpdateChannelEQExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_GATE), new Action<byte[]>(this.UpdateChannelGateExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_COMP_LIMIT), new Action<byte[]>(this.UpdateCompressorLimitExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_ReadLimitMeter), new Action<byte[]>(this.UpdateChannelCompressorMeterExeucte));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_BusMixer), new Action<byte[]>(this.UpdateAux1FXsExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_SetChannelName), new Action<byte[]>(this.SetChannelNameExecute));
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00013FF4 File Offset: 0x000121F4
		private void SynchronicExecute(byte[] obj)
		{
			bool flag = obj[12] == CommandConst.DEVE_PAGE_GATE || obj[12] == CommandConst.DEVE_PAGE_COMP || obj[12] == CommandConst.DEVE_PAGE_EQUALIZER;
			if (flag)
			{
				int num = (int)(obj[13] - 1);
				bool flag2 = (int)this.ChannelInfo.ChannelIndex != num;
				if (flag2)
				{
					this.ChannelInfo = ChannelData.ChannelDatas.DeviceChannels[num];
				}
			}
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00014064 File Offset: 0x00012264
		private void UpdateChannelCompressorMeterExeucte(byte[] obj)
		{
			int num = 11;
			for (int i = 0; i < ChannelData.ChannelDatas.CH01_24.Count; i++)
			{
				ChannelInfo channelInfo = ChannelData.ChannelDatas.CH01_24[i];
				byte b = obj[num++];
				byte b2 = b & 127;
				channelInfo.CompressorInfo.CompressorMeter = (int)b2;
				channelInfo.CompressorInfo.Active = ((b2 > 0) ? 2 : 0);
				channelInfo.NoiseGateInfo.Active = (channelInfo.NoiseGateInfo.NoiseGateEnable ? ((b > 127) ? 1 : 2) : 0);
			}
			for (int j = 0; j < ChannelData.ChannelDatas.FXs.Count; j++)
			{
				ChannelInfo channelInfo2 = ChannelData.ChannelDatas.FXs[j];
				byte b3 = obj[num++];
				byte b4 = b3 & 127;
				channelInfo2.CompressorInfo.CompressorMeter = (int)b4;
				channelInfo2.CompressorInfo.Active = ((b4 > 0) ? 2 : 0);
				channelInfo2.NoiseGateInfo.Active = (channelInfo2.NoiseGateInfo.NoiseGateEnable ? ((b3 > 127) ? 1 : 2) : 0);
			}
			for (int k = 0; k < ChannelData.ChannelDatas.Aux1_8.Count; k++)
			{
				ChannelData.ChannelDatas.Aux1_8[k].CompressorInfo.CompressorMeter = (int)obj[num++];
			}
			ChannelData.ChannelDatas.Main.CompressorInfo.CompressorMeter = (int)obj[num++];
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x00014204 File Offset: 0x00012404
		private void SetChannelNameExecute(byte[] obj)
		{
			int num = 11;
			int num2 = (int)(obj[num++] - 1);
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < 8; i++)
			{
				bool flag = obj[num] > 0;
				if (flag)
				{
					stringBuilder.Append((char)obj[num++]);
				}
				else
				{
					stringBuilder.Append(' ');
					num++;
				}
			}
			ChannelData.ChannelDatas.DeviceChannels[num2].ChannelName = stringBuilder.ToString().Trim();
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x00003B79 File Offset: 0x00001D79
		private void ResetChannelExecute(byte[] obj)
		{
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00014288 File Offset: 0x00012488
		private void UpdateAux1FXsExecute(byte[] obj)
		{
			int num = (int)(obj[11] - 1);
			int num2 = 12;
			ChannelInfo channelInfo = ChannelData.ChannelDatas.DeviceChannels[num];
			for (int i = 0; i < 4; i++)
			{
				channelInfo.AuxGroup1.GroupCollection[i].Value = (int)obj[num2++];
			}
			for (int j = 0; j < 2; j++)
			{
				channelInfo.FXGroup.GroupCollection[j].Value = (int)obj[num2++];
			}
			for (int k = 0; k < 4; k++)
			{
				channelInfo.AuxGroup1.GroupCollection[k].IsFrontSet = obj[num2++] == 1;
			}
			for (int l = 0; l < 2; l++)
			{
				channelInfo.FXGroup.GroupCollection[l].IsFrontSet = obj[num2++] == 1;
			}
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00014388 File Offset: 0x00012588
		private void UpdateCompressorLimitExecute(byte[] obj)
		{
			int num = (int)(obj[11] - 1);
			int num2 = 12;
			CompressorInfo compressorInfo = ChannelData.ChannelDatas.DeviceChannels[num].CompressorInfo;
			compressorInfo.Threshold = obj[num2++];
			compressorInfo.Attack = (int)(obj[num2++] * 100 + obj[num2++]);
			compressorInfo.Release = (int)(obj[num2++] * 100 + obj[num2++]);
			compressorInfo.Ratio = obj[num2++];
			compressorInfo.Gain = obj[num2++];
			compressorInfo.Bypass = obj[num2++];
		}

		// Token: 0x060001FB RID: 507 RVA: 0x00014420 File Offset: 0x00012620
		private void UpdateChannelGateExecute(byte[] obj)
		{
			int num = (int)(obj[11] - 1);
			int num2 = 12;
			NoiseGateInfo noiseGateInfo = ChannelData.ChannelDatas.DeviceChannels[num].NoiseGateInfo;
			noiseGateInfo.Threshold = obj[num2++];
			noiseGateInfo.Attack = (int)(obj[num2++] * 100 + obj[num2++]);
			noiseGateInfo.Release = (int)(obj[num2++] * 100 + obj[num2++]);
			noiseGateInfo.Bypass = obj[num2++];
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0001449C File Offset: 0x0001269C
		private void UpdateChannelEQExecute(byte[] obj)
		{
			int num = (int)(obj[11] - 1);
			int num2 = (int)(obj[12] - 1);
			int num3 = 13;
			EqualizerInfo equalizerInfo = ChannelData.ChannelDatas.DeviceChannels[num].EqualizerInfos[num2];
			equalizerInfo.FilterIndex = (int)((num2 < 2) ? obj[num3++] : (obj[num3++] - 1));
			equalizerInfo.FreqIndex = (int)(obj[num3++] * 100 + obj[num3++]);
			equalizerInfo.QFactorIndex = obj[num3++];
			equalizerInfo.GainIndex = (int)obj[num3++];
			equalizerInfo.Bypass = obj[num3++];
			ChannelData.ChannelDatas.DeviceChannels[num].EqualizerAllBypass = obj[num3++] == 0;
			ViewModelMessager.Messeager.Notify(ViewModelMessager.UpdateEqualizer, num2);
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00014570 File Offset: 0x00012770
		private void UpdateChannelExecute(byte[] obj)
		{
			int num = (int)(obj[11] - 1);
			int num2 = 12;
			ChannelInfo channelInfo = ChannelData.ChannelDatas.DeviceChannels[num];
			channelInfo.Invert = obj[num2++] == 1;
			channelInfo.GainValue = (int)obj[num2++];
			channelInfo.IsMute = obj[num2++] == 1;
			channelInfo.DelayValue = (int)(obj[num2++] * 100 + obj[num2++]);
			channelInfo.DelayEnabled = obj[num2++] == 0;
			int num3 = (int)obj[num2++];
			channelInfo.DigitalInput.IsFrontSet = num3 > 127;
			channelInfo.DigitalInput.TempInputIsFrontSet = num3 > 127;
			channelInfo.DigitalInput.Value = num3 & 127;
			channelInfo.DC48VEnabled = obj[num2++] == 1;
			channelInfo.IsStartLinkChannel = obj[num2++] == 1;
			channelInfo.PanValue = (int)obj[num2++];
			channelInfo.AssignMain = obj[num2++] == 1;
			int num4 = (int)obj[26];
			bool flag = num4 != 0;
			if (flag)
			{
				foreach (AuxFxItem auxFxItem in channelInfo.AuxGroup2.GroupCollection)
				{
					byte b = obj[num2++];
					auxFxItem.IsFrontSet = b > 127;
					auxFxItem.Value = (int)(b & 127);
				}
			}
			else
			{
				foreach (AuxFxItem auxFxItem2 in channelInfo.AuxGroup2.GroupCollection)
				{
					byte b2 = obj[num2++];
					auxFxItem2.IsFrontSet = b2 > 127;
					auxFxItem2.Value = (int)(b2 & 127);
				}
			}
			channelInfo.IsSolo = obj[num2++] == 1;
			bool isStartLinkChannel = channelInfo.IsStartLinkChannel;
			if (isStartLinkChannel)
			{
				this.CopyLinkProperty(channelInfo, channelInfo.LinkChannel);
			}
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00014788 File Offset: 0x00012988
		private void CopyLinkProperty(ChannelInfo source, ChannelInfo destination)
		{
		}

		// Token: 0x060001FF RID: 511 RVA: 0x00014798 File Offset: 0x00012998
		private void ReadCurrentSceneExecute(byte[] obj)
		{
			UpStream.DuringProcessDownStream = true;
			int num = 12;
			for (int i = 0; i < 35; i++)
			{
				ChannelInfo channelInfo = ChannelData.ChannelDatas.DeviceChannels[i];
				channelInfo.Invert = obj[num++] == 1;
				channelInfo.GainValue = (int)obj[num++];
				channelInfo.IsMute = obj[num++] == 1;
				channelInfo.DelayValue = (int)(obj[num++] * 100 + obj[num++]);
				channelInfo.DelayEnabled = obj[num++] == 0;
				channelInfo.NoiseGateInfo.Threshold = obj[num++];
				channelInfo.NoiseGateInfo.Attack = (int)(obj[num++] * 100 + obj[num++]);
				channelInfo.NoiseGateInfo.Release = (int)(obj[num++] * 100 + obj[num++]);
				channelInfo.NoiseGateInfo.Bypass = obj[num++];
				for (int j = 0; j < 6; j++)
				{
					channelInfo.EqualizerInfos[j].FilterIndex = (int)((j < 2) ? obj[num++] : (obj[num++] - 1));
					channelInfo.EqualizerInfos[j].FreqIndex = (int)(obj[num++] * 100 + obj[num++]);
					channelInfo.EqualizerInfos[j].QFactorIndex = obj[num++];
					channelInfo.EqualizerInfos[j].GainIndex = (int)obj[num++];
					channelInfo.EqualizerInfos[j].Bypass = obj[num++];
				}
				channelInfo.EqualizerAllBypass = obj[num++] == 0;
				channelInfo.CompressorInfo.Threshold = obj[num++];
				channelInfo.CompressorInfo.Attack = (int)(obj[num++] * 100 + obj[num++]);
				channelInfo.CompressorInfo.Release = (int)(obj[num++] * 100 + obj[num++]);
				channelInfo.CompressorInfo.Ratio = obj[num++];
				channelInfo.CompressorInfo.Gain = obj[num++];
				channelInfo.CompressorInfo.Bypass = obj[num++];
				channelInfo.PanValue = (int)obj[num++];
				channelInfo.IsSolo = obj[num++] == 1;
				channelInfo.AssignMain = obj[num++] == 1;
				num++;
				num++;
				num++;
				num++;
				for (int k = 0; k < channelInfo.AuxGroup1.GroupCollection.Count; k++)
				{
					channelInfo.AuxGroup1.GroupCollection[k].Value = (int)obj[num++];
				}
				for (int l = 0; l < channelInfo.FXGroup.GroupCollection.Count; l++)
				{
					channelInfo.FXGroup.GroupCollection[l].Value = (int)obj[num++];
				}
				for (int m = 0; m < channelInfo.AuxGroup1.GroupCollection.Count; m++)
				{
					channelInfo.AuxGroup1.GroupCollection[m].IsFrontSet = obj[num++] == 1;
				}
				for (int n = 0; n < channelInfo.FXGroup.GroupCollection.Count; n++)
				{
					channelInfo.FXGroup.GroupCollection[n].IsFrontSet = obj[num++] == 1;
				}
				channelInfo.IsStartLinkChannel = obj[num++] == 1;
				byte b = obj[num++];
				channelInfo.DigitalInput.IsFrontSet = b > 127;
				channelInfo.DigitalInput.TempInputIsFrontSet = b > 127;
				channelInfo.DigitalInput.Value = (int)(b & 127);
				channelInfo.DC48VEnabled = obj[num++] == 1;
				channelInfo.SelectedDCAIndex = (int)obj[num++];
				channelInfo.DCAGain = (int)obj[num++];
				StringBuilder stringBuilder = new StringBuilder();
				for (int num2 = 0; num2 < 8; num2++)
				{
					bool flag = obj[num] != 32 && obj[num] > 0;
					if (flag)
					{
						stringBuilder.Append((char)obj[num++]);
					}
					else
					{
						stringBuilder.Append(' ');
						num++;
					}
				}
				channelInfo.ChannelName = stringBuilder.ToString().Trim();
				for (int num3 = 0; num3 < channelInfo.AuxGroup2.GroupCollection.Count; num3++)
				{
					channelInfo.AuxGroup2.GroupCollection[num3].Value = (int)obj[num++];
				}
				for (int num4 = 0; num4 < channelInfo.AuxGroup2.GroupCollection.Count; num4++)
				{
					channelInfo.AuxGroup2.GroupCollection[num4].IsFrontSet = obj[num++] == 1;
				}
			}
			ViewModelMessager.Messeager.Notify(ViewModelMessager.UpdateAllEqualizer);
			UpStream.DuringProcessDownStream = false;
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00014CD4 File Offset: 0x00012ED4
		private void UpdateSoloExecute(byte[] obj)
		{
			int num = 12;
			for (int i = 0; i < ChannelData.ChannelDatas.DeviceChannels.Count; i++)
			{
				ChannelData.ChannelDatas.DeviceChannels[i].IsSolo = obj[num] == 1;
				num++;
			}
		}

		// Token: 0x06000201 RID: 513 RVA: 0x00014D28 File Offset: 0x00012F28
		private void UpdateMuteGainExeucte(byte[] obj)
		{
			int num = 12;
			for (int i = 0; i < ChannelData.ChannelDatas.DeviceChannels.Count; i++)
			{
				ChannelData.ChannelDatas.DeviceChannels[i].IsMute = obj[num] > 127;
				ChannelData.ChannelDatas.DeviceChannels[i].GainValue = (int)(obj[num] & 127);
				num++;
			}
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00014D98 File Offset: 0x00012F98
		private void MeterExecute(byte[] obj)
		{
			int num = 11;
			for (int i = 0; i < ChannelData.ChannelDatas.CH01_24.Count; i++)
			{
				ChannelData.ChannelDatas.CH01_24[i].MeterValue = (int)Const.MeterDeviceToPageConverter[(int)obj[num++]];
			}
			for (int j = 0; j < ChannelData.ChannelDatas.FXs.Count; j++)
			{
				ChannelData.ChannelDatas.FXs[j].MeterValue = (int)Const.MeterDeviceToPageConverter[(int)obj[num++]];
			}
			for (int k = 0; k < ChannelData.ChannelDatas.Aux1_8.Count; k++)
			{
				ChannelData.ChannelDatas.Aux1_8[k].MeterValue = (int)Const.MeterDeviceToPageConverter[(int)obj[num++]];
			}
			ChannelData.ChannelDatas.Main.MeterValue = (int)Const.MeterDeviceToPageConverter[(int)obj[num++]];
		}

		// Token: 0x06000203 RID: 515 RVA: 0x00014E98 File Offset: 0x00013098
		private void DC48VExecute(byte[] obj)
		{
			for (int i = 0; i < 24; i++)
			{
				ChannelData.ChannelDatas.CH01_24[i].DC48VEnabled = obj[12 + i] == 1;
			}
		}

		// Token: 0x04000102 RID: 258
		private ChannelInfo _ChannelInfo = new ChannelInfo();
	}
}
