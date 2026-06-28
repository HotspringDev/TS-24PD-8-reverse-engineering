using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FFT;
using JayLib.JaySerialization;
using JayLib.Localization;
using JayLib.WPF.BasicClass;
using T2208.DeviceCommuncation;
using T2208.ViewModels;

namespace T2208.MyInformations
{
	// Token: 0x02000066 RID: 102
	[Serializable]
	public class ChannelInfo : NotificationObject, ISerializable
	{
		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06000567 RID: 1383 RVA: 0x0001ED10 File Offset: 0x0001CF10
		// (set) Token: 0x06000568 RID: 1384 RVA: 0x0001ED28 File Offset: 0x0001CF28
		public string ChannelName
		{
			get
			{
				return this._ChannelName;
			}
			set
			{
				this._ChannelName = value;
				this.OnPropertyChanged<string>(() => this.ChannelName);
				this.DigitalInput.ChannelName = (this.DigitalOutput.ChannelName = this.ChannelName);
				bool flag = string.IsNullOrWhiteSpace(this.DefaultChannelName);
				if (flag)
				{
					this.DefaultChannelName = value;
				}
			}
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06000569 RID: 1385 RVA: 0x0001EDB0 File Offset: 0x0001CFB0
		// (set) Token: 0x0600056A RID: 1386 RVA: 0x00007810 File Offset: 0x00005A10
		public string InputName
		{
			get
			{
				return this._InputName;
			}
			set
			{
				this._InputName = value;
				this.OnPropertyChanged<string>(() => this.InputName);
			}
		}

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x0600056B RID: 1387 RVA: 0x0001EDC8 File Offset: 0x0001CFC8
		// (set) Token: 0x0600056C RID: 1388 RVA: 0x00007850 File Offset: 0x00005A50
		public bool IsEditName
		{
			get
			{
				return this._IsEditName;
			}
			set
			{
				this._IsEditName = value;
				this.OnPropertyChanged<bool>(() => this.IsEditName);
			}
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x0600056D RID: 1389 RVA: 0x00007890 File Offset: 0x00005A90
		// (set) Token: 0x0600056E RID: 1390 RVA: 0x00007898 File Offset: 0x00005A98
		public string DefaultChannelName { get; private set; }

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x0600056F RID: 1391 RVA: 0x0001EDE0 File Offset: 0x0001CFE0
		// (set) Token: 0x06000570 RID: 1392 RVA: 0x000078A1 File Offset: 0x00005AA1
		public bool IsPresentChannel
		{
			get
			{
				return this._IsPresentChannel;
			}
			set
			{
				this._IsPresentChannel = value;
				this.OnPropertyChanged<bool>(() => this.IsPresentChannel);
			}
		}

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x06000571 RID: 1393 RVA: 0x0001EDF8 File Offset: 0x0001CFF8
		// (set) Token: 0x06000572 RID: 1394 RVA: 0x000078E1 File Offset: 0x00005AE1
		public bool IsMute
		{
			get
			{
				return this._IsMute;
			}
			set
			{
				this._IsMute = value;
				this.OnPropertyChanged<bool>(() => this.IsMute);
			}
		}

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x06000573 RID: 1395 RVA: 0x0001EE10 File Offset: 0x0001D010
		// (set) Token: 0x06000574 RID: 1396 RVA: 0x00007921 File Offset: 0x00005B21
		public bool IsSolo
		{
			get
			{
				return this._IsSolo;
			}
			set
			{
				this._IsSolo = value;
				this.OnPropertyChanged<bool>(() => this.IsSolo);
			}
		}

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x06000575 RID: 1397 RVA: 0x0001EE28 File Offset: 0x0001D028
		// (set) Token: 0x06000576 RID: 1398 RVA: 0x0001EE40 File Offset: 0x0001D040
		public int MeterValue
		{
			get
			{
				return this._MeterValue;
			}
			set
			{
				bool flag = this._MeterValue == value;
				if (!flag)
				{
					this._MeterValue = value;
					this.OnPropertyChanged<int>(() => this.MeterValue);
				}
			}
		}

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x06000577 RID: 1399 RVA: 0x0001EE9C File Offset: 0x0001D09C
		// (set) Token: 0x06000578 RID: 1400 RVA: 0x00007961 File Offset: 0x00005B61
		public bool HasStereo
		{
			get
			{
				return this._HasStereo;
			}
			set
			{
				this._HasStereo = value;
				this.OnPropertyChanged<bool>(() => this.HasStereo);
			}
		}

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x06000579 RID: 1401 RVA: 0x0001EEB4 File Offset: 0x0001D0B4
		// (set) Token: 0x0600057A RID: 1402 RVA: 0x000079A1 File Offset: 0x00005BA1
		public int RightMeterValue
		{
			get
			{
				return this._RightMeterValue;
			}
			set
			{
				this._RightMeterValue = value;
				this.OnPropertyChanged<int>(() => this.RightMeterValue);
			}
		}

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x0600057B RID: 1403 RVA: 0x0001EECC File Offset: 0x0001D0CC
		// (set) Token: 0x0600057C RID: 1404 RVA: 0x0001EEE4 File Offset: 0x0001D0E4
		public int GainValue
		{
			get
			{
				return this._GainValue;
			}
			set
			{
				this._GainValue = value;
				this.OnPropertyChanged<int>(() => this.GainValue);
				this.SendGainValue = (double)value;
			}
		}

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x0600057D RID: 1405 RVA: 0x0001EF38 File Offset: 0x0001D138
		// (set) Token: 0x0600057E RID: 1406 RVA: 0x000079E1 File Offset: 0x00005BE1
		public double SendGainValue
		{
			get
			{
				return this._sendGainValue;
			}
			set
			{
				this._sendGainValue = value;
				this.OnPropertyChanged<double>(() => this.SendGainValue);
			}
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x0600057F RID: 1407 RVA: 0x0001EF50 File Offset: 0x0001D150
		// (set) Token: 0x06000580 RID: 1408 RVA: 0x00007A21 File Offset: 0x00005C21
		public string GainString
		{
			get
			{
				return this._GainString;
			}
			set
			{
				this._GainString = value;
				this.OnPropertyChanged<string>(() => this.GainString);
			}
		}

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000581 RID: 1409 RVA: 0x0001EF68 File Offset: 0x0001D168
		// (set) Token: 0x06000582 RID: 1410 RVA: 0x00007A61 File Offset: 0x00005C61
		public bool EqualizerAllBypass
		{
			get
			{
				return this._AllBypass;
			}
			set
			{
				this._AllBypass = value;
				this.OnPropertyChanged<bool>(() => this.EqualizerAllBypass);
			}
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000583 RID: 1411 RVA: 0x0001EF80 File Offset: 0x0001D180
		// (set) Token: 0x06000584 RID: 1412 RVA: 0x00007AA1 File Offset: 0x00005CA1
		public EqualizerInfo EqualizerEdit1
		{
			get
			{
				return this._EqualizerEdit1;
			}
			set
			{
				this._EqualizerEdit1 = value;
				this.OnPropertyChanged<EqualizerInfo>(() => this.EqualizerEdit1);
			}
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000585 RID: 1413 RVA: 0x0001EF98 File Offset: 0x0001D198
		// (set) Token: 0x06000586 RID: 1414 RVA: 0x00007AE1 File Offset: 0x00005CE1
		public EqualizerInfo EqualizerEdit2
		{
			get
			{
				return this._EqualizerEdit2;
			}
			set
			{
				this._EqualizerEdit2 = value;
				this.OnPropertyChanged<EqualizerInfo>(() => this.EqualizerEdit2);
			}
		}

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000587 RID: 1415 RVA: 0x0001EFB0 File Offset: 0x0001D1B0
		// (set) Token: 0x06000588 RID: 1416 RVA: 0x00007B21 File Offset: 0x00005D21
		public EqualizerInfo EqualizerEdit3
		{
			get
			{
				return this._EqualizerEdit3;
			}
			set
			{
				this._EqualizerEdit3 = value;
				this.OnPropertyChanged<EqualizerInfo>(() => this.EqualizerEdit3);
			}
		}

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000589 RID: 1417 RVA: 0x0001EFC8 File Offset: 0x0001D1C8
		// (set) Token: 0x0600058A RID: 1418 RVA: 0x00007B61 File Offset: 0x00005D61
		public EqualizerInfo EqualizerEdit4
		{
			get
			{
				return this._EqualizerEdit4;
			}
			set
			{
				this._EqualizerEdit4 = value;
				this.OnPropertyChanged<EqualizerInfo>(() => this.EqualizerEdit4);
			}
		}

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x0600058B RID: 1419 RVA: 0x0001EFE0 File Offset: 0x0001D1E0
		// (set) Token: 0x0600058C RID: 1420 RVA: 0x00007BA1 File Offset: 0x00005DA1
		public EqualizerInfo HighPassFilter
		{
			get
			{
				return this._HighPassFilter;
			}
			set
			{
				this._HighPassFilter = value;
				this.OnPropertyChanged<EqualizerInfo>(() => this.HighPassFilter);
			}
		}

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x0600058D RID: 1421 RVA: 0x0001EFF8 File Offset: 0x0001D1F8
		// (set) Token: 0x0600058E RID: 1422 RVA: 0x00007BE1 File Offset: 0x00005DE1
		public EqualizerInfo LowPassFilter
		{
			get
			{
				return this._LowPassFilter;
			}
			set
			{
				this._LowPassFilter = value;
				this.OnPropertyChanged<EqualizerInfo>(() => this.LowPassFilter);
			}
		}

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x0600058F RID: 1423 RVA: 0x00007C21 File Offset: 0x00005E21
		// (set) Token: 0x06000590 RID: 1424 RVA: 0x00007C29 File Offset: 0x00005E29
		public bool TComboBoxCanSend { get; set; }

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06000591 RID: 1425 RVA: 0x00007C32 File Offset: 0x00005E32
		// (set) Token: 0x06000592 RID: 1426 RVA: 0x00007C3A File Offset: 0x00005E3A
		public List<EqualizerInfo> EqualizerInfos { get; set; } = new List<EqualizerInfo>();

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06000593 RID: 1427 RVA: 0x0001F010 File Offset: 0x0001D210
		// (set) Token: 0x06000594 RID: 1428 RVA: 0x00007C43 File Offset: 0x00005E43
		public NoiseGateInfo NoiseGateInfo
		{
			get
			{
				return this._NoiseGateInfo;
			}
			set
			{
				this._NoiseGateInfo = value;
				this.OnPropertyChanged<NoiseGateInfo>(() => this.NoiseGateInfo);
			}
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06000595 RID: 1429 RVA: 0x0001F028 File Offset: 0x0001D228
		// (set) Token: 0x06000596 RID: 1430 RVA: 0x00007C83 File Offset: 0x00005E83
		public bool HasNoiseGate
		{
			get
			{
				return this._HasNoiseGate;
			}
			set
			{
				this._HasNoiseGate = value;
				this.OnPropertyChanged<bool>(() => this.HasNoiseGate);
			}
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x06000597 RID: 1431 RVA: 0x0001F040 File Offset: 0x0001D240
		// (set) Token: 0x06000598 RID: 1432 RVA: 0x00007CC3 File Offset: 0x00005EC3
		public CompressorInfo CompressorInfo
		{
			get
			{
				return this._CompressorInfo;
			}
			set
			{
				this._CompressorInfo = value;
				this.OnPropertyChanged<CompressorInfo>(() => this.CompressorInfo);
			}
		}

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06000599 RID: 1433 RVA: 0x0001F058 File Offset: 0x0001D258
		// (set) Token: 0x0600059A RID: 1434 RVA: 0x00007D03 File Offset: 0x00005F03
		public ChannelType ChannelType
		{
			get
			{
				return this._ChannelType;
			}
			set
			{
				this._ChannelType = value;
				this.OnPropertyChanged<ChannelType>(() => this.ChannelType);
			}
		}

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x0600059B RID: 1435 RVA: 0x00007D43 File Offset: 0x00005F43
		// (set) Token: 0x0600059C RID: 1436 RVA: 0x00007D4B File Offset: 0x00005F4B
		public byte ChannelIndex { get; set; }

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x0600059D RID: 1437 RVA: 0x0001F070 File Offset: 0x0001D270
		// (set) Token: 0x0600059E RID: 1438 RVA: 0x00007D54 File Offset: 0x00005F54
		public int PanValue
		{
			get
			{
				return this._PanValue;
			}
			set
			{
				this._PanValue = value;
				this.OnPropertyChanged<int>(() => this.PanValue);
			}
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x0600059F RID: 1439 RVA: 0x0001F088 File Offset: 0x0001D288
		// (set) Token: 0x060005A0 RID: 1440 RVA: 0x00007D94 File Offset: 0x00005F94
		public bool DelayEnabled
		{
			get
			{
				return this._DelayEnabled;
			}
			set
			{
				this._DelayEnabled = value;
				this.OnPropertyChanged<bool>(() => this.DelayEnabled);
			}
		}

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x060005A1 RID: 1441 RVA: 0x0001F0A0 File Offset: 0x0001D2A0
		// (set) Token: 0x060005A2 RID: 1442 RVA: 0x00007DD4 File Offset: 0x00005FD4
		public double SendDelayValue
		{
			get
			{
				return this._SendDelayValue;
			}
			set
			{
				this._SendDelayValue = value;
				this.OnPropertyChanged<double>(() => this.SendDelayValue);
			}
		}

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x060005A3 RID: 1443 RVA: 0x0001F0B8 File Offset: 0x0001D2B8
		// (set) Token: 0x060005A4 RID: 1444 RVA: 0x0001F0D0 File Offset: 0x0001D2D0
		public int DelayValue
		{
			get
			{
				return this._DelayValue;
			}
			set
			{
				this._DelayValue = value;
				this.OnPropertyChanged<int>(() => this.DelayValue);
				this.SendDelayValue = (double)value;
			}
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x060005A5 RID: 1445 RVA: 0x0001F124 File Offset: 0x0001D324
		// (set) Token: 0x060005A6 RID: 1446 RVA: 0x00007E14 File Offset: 0x00006014
		public bool HasDC48V
		{
			get
			{
				return this._HasDC48V;
			}
			set
			{
				this._HasDC48V = value;
				this.OnPropertyChanged<bool>(() => this.HasDC48V);
			}
		}

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x060005A7 RID: 1447 RVA: 0x0001F13C File Offset: 0x0001D33C
		// (set) Token: 0x060005A8 RID: 1448 RVA: 0x00007E54 File Offset: 0x00006054
		public bool DC48VEnabled
		{
			get
			{
				return this._DC48VEnabled;
			}
			set
			{
				this._DC48VEnabled = value;
				this.OnPropertyChanged<bool>(() => this.DC48VEnabled);
			}
		}

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x060005A9 RID: 1449 RVA: 0x0001F154 File Offset: 0x0001D354
		// (set) Token: 0x060005AA RID: 1450 RVA: 0x00007E94 File Offset: 0x00006094
		public bool Invert
		{
			get
			{
				return this._Invert;
			}
			set
			{
				this._Invert = value;
				this.OnPropertyChanged<bool>(() => this.Invert);
			}
		}

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x060005AB RID: 1451 RVA: 0x0001F16C File Offset: 0x0001D36C
		// (set) Token: 0x060005AC RID: 1452 RVA: 0x00007ED4 File Offset: 0x000060D4
		public bool AssignMain
		{
			get
			{
				return this._AssignMain;
			}
			set
			{
				this._AssignMain = value;
				this.OnPropertyChanged<bool>(() => this.AssignMain);
			}
		}

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x060005AD RID: 1453 RVA: 0x0001F184 File Offset: 0x0001D384
		// (set) Token: 0x060005AE RID: 1454 RVA: 0x00007F14 File Offset: 0x00006114
		public bool HasLink
		{
			get
			{
				return this._HasLink;
			}
			set
			{
				this._HasLink = value;
				this.OnPropertyChanged<bool>(() => this.HasLink);
			}
		}

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x060005AF RID: 1455 RVA: 0x0001F19C File Offset: 0x0001D39C
		// (set) Token: 0x060005B0 RID: 1456 RVA: 0x00007F54 File Offset: 0x00006154
		public bool Link
		{
			get
			{
				return this._Link;
			}
			set
			{
				this._Link = value;
				this.OnPropertyChanged<bool>(() => this.Link);
			}
		}

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x060005B1 RID: 1457 RVA: 0x00007F94 File Offset: 0x00006194
		// (set) Token: 0x060005B2 RID: 1458 RVA: 0x0001F1B4 File Offset: 0x0001D3B4
		public bool IsStartLinkChannel
		{
			get
			{
				return this._IsStartLinkChannel;
			}
			set
			{
				bool flag = this._IsStartLinkChannel != value;
				if (flag)
				{
					this.OnIsStartLinkChannelChanged(value);
					this._IsStartLinkChannel = value;
				}
			}
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x0001F1E4 File Offset: 0x0001D3E4
		private void OnIsStartLinkChannelChanged(bool flag)
		{
			int num = ChannelInfo.ChannelInfos.IndexOf(this) / 2;
			ChannelInfo channelInfo = ChannelInfo.ChannelInfos[num * 2];
			ChannelInfo channelInfo2 = ChannelInfo.ChannelInfos[num * 2 + 1];
			ChannelInfo channelInfo3 = channelInfo;
			channelInfo2.Link = flag;
			channelInfo3.Link = flag;
			bool flag2 = flag && (channelInfo.IsPresentChannel || channelInfo2.IsPresentChannel);
			if (flag2)
			{
				channelInfo.IsPresentChannel = (channelInfo2.IsPresentChannel = true);
			}
			bool flag3 = !flag && (channelInfo.IsPresentChannel || channelInfo2.IsPresentChannel);
			if (flag3)
			{
				channelInfo.IsPresentChannel = channelInfo.IsStartLinkChannel;
				channelInfo2.IsPresentChannel = channelInfo2.IsStartLinkChannel;
			}
		}

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x060005B4 RID: 1460 RVA: 0x00007F9C File Offset: 0x0000619C
		// (set) Token: 0x060005B5 RID: 1461 RVA: 0x00007FA4 File Offset: 0x000061A4
		public ChannelInfo LinkChannel { get; set; }

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x060005B6 RID: 1462 RVA: 0x0001F29C File Offset: 0x0001D49C
		// (set) Token: 0x060005B7 RID: 1463 RVA: 0x00007FAD File Offset: 0x000061AD
		public bool IsMain
		{
			get
			{
				return this._IsMain;
			}
			set
			{
				this._IsMain = value;
				this.OnPropertyChanged<bool>(() => this.IsMain);
			}
		}

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x060005B8 RID: 1464 RVA: 0x0001F2B4 File Offset: 0x0001D4B4
		// (set) Token: 0x060005B9 RID: 1465 RVA: 0x00007FED File Offset: 0x000061ED
		public bool HasAux
		{
			get
			{
				return this._HasAux;
			}
			set
			{
				this._HasAux = value;
				this.OnPropertyChanged<bool>(() => this.HasAux);
			}
		}

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x060005BA RID: 1466 RVA: 0x0001F2CC File Offset: 0x0001D4CC
		// (set) Token: 0x060005BB RID: 1467 RVA: 0x0000802D File Offset: 0x0000622D
		public bool HasFX
		{
			get
			{
				return this._HasFX;
			}
			set
			{
				this._HasFX = value;
				this.OnPropertyChanged<bool>(() => this.HasFX);
			}
		}

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x060005BC RID: 1468 RVA: 0x0000806D File Offset: 0x0000626D
		// (set) Token: 0x060005BD RID: 1469 RVA: 0x00008075 File Offset: 0x00006275
		public GroupInfo<AuxFxItem> AuxGroup1 { get; private set; } = new GroupInfo<AuxFxItem>
		{
			GroupName = "Aux1-4"
		};

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x060005BE RID: 1470 RVA: 0x0000807E File Offset: 0x0000627E
		// (set) Token: 0x060005BF RID: 1471 RVA: 0x00008086 File Offset: 0x00006286
		public GroupInfo<AuxFxItem> AuxGroup2 { get; private set; } = new GroupInfo<AuxFxItem>
		{
			GroupName = "Aux5-8"
		};

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x060005C0 RID: 1472 RVA: 0x0000808F File Offset: 0x0000628F
		// (set) Token: 0x060005C1 RID: 1473 RVA: 0x00008097 File Offset: 0x00006297
		public GroupInfo<AuxFxItem> FXGroup { get; set; } = new GroupInfo<AuxFxItem>
		{
			GroupName = "FX"
		};

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x060005C2 RID: 1474 RVA: 0x0001F2E4 File Offset: 0x0001D4E4
		// (set) Token: 0x060005C3 RID: 1475 RVA: 0x0001F2FC File Offset: 0x0001D4FC
		public AuxFxItem[] AuxFxItems
		{
			get
			{
				return this._AuxFxItems;
			}
			set
			{
				this._AuxFxItems = value;
				bool flag = this._AuxFxItems == null;
				if (!flag)
				{
					this.UpdateAuxFxGroup();
				}
			}
		}

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x060005C4 RID: 1476 RVA: 0x0001F328 File Offset: 0x0001D528
		// (set) Token: 0x060005C5 RID: 1477 RVA: 0x000080A0 File Offset: 0x000062A0
		public ObservableCollection<GroupInfo<AuxFxItem>> AuxFxGroup
		{
			get
			{
				return this._AuxFxGroup;
			}
			set
			{
				this._AuxFxGroup = value;
				this.OnPropertyChanged<ObservableCollection<GroupInfo<AuxFxItem>>>(() => this.AuxFxGroup);
			}
		}

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x060005C6 RID: 1478 RVA: 0x0001F340 File Offset: 0x0001D540
		// (set) Token: 0x060005C7 RID: 1479 RVA: 0x000080E0 File Offset: 0x000062E0
		public GroupInfo<AuxFxItem> SelectAuxFxGroup
		{
			get
			{
				return this._SelectAuxFxGroup;
			}
			set
			{
				this._SelectAuxFxGroup = value;
				this.OnPropertyChanged<GroupInfo<AuxFxItem>>(() => this.SelectAuxFxGroup);
			}
		}

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x060005C8 RID: 1480 RVA: 0x0001F358 File Offset: 0x0001D558
		// (set) Token: 0x060005C9 RID: 1481 RVA: 0x00008120 File Offset: 0x00006320
		public int SelectAuxFXIndex
		{
			get
			{
				return this._SelectAuxFXIndex;
			}
			set
			{
				this._SelectAuxFXIndex = value;
				this.OnPropertyChanged<int>(() => this.SelectAuxFXIndex);
			}
		}

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x060005CA RID: 1482 RVA: 0x0001F370 File Offset: 0x0001D570
		// (set) Token: 0x060005CB RID: 1483 RVA: 0x00008160 File Offset: 0x00006360
		public GroupInfo<FXItem> FXEffect
		{
			get
			{
				return this._FXEffects;
			}
			set
			{
				this._FXEffects = value;
				this.OnPropertyChanged<GroupInfo<FXItem>>(() => this.FXEffect);
			}
		}

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x060005CC RID: 1484 RVA: 0x0001F388 File Offset: 0x0001D588
		// (set) Token: 0x060005CD RID: 1485 RVA: 0x000081A0 File Offset: 0x000063A0
		public DigitalInfo DigitalInput
		{
			get
			{
				return this._DigitalInput;
			}
			set
			{
				this._DigitalInput = value;
				this.OnPropertyChanged<DigitalInfo>(() => this.DigitalInput);
			}
		}

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x060005CE RID: 1486 RVA: 0x0001F3A0 File Offset: 0x0001D5A0
		// (set) Token: 0x060005CF RID: 1487 RVA: 0x000081E0 File Offset: 0x000063E0
		public DigitalInfo DigitalOutput
		{
			get
			{
				return this._DigitalOutput;
			}
			set
			{
				this._DigitalOutput = value;
				this.OnPropertyChanged<DigitalInfo>(() => this.DigitalOutput);
			}
		}

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x060005D0 RID: 1488 RVA: 0x0001F3B8 File Offset: 0x0001D5B8
		// (set) Token: 0x060005D1 RID: 1489 RVA: 0x00008220 File Offset: 0x00006420
		public int SelectedDCAIndex
		{
			get
			{
				return this._SelectedDCAIndex;
			}
			set
			{
				this._SelectedDCAIndex = value;
				this.OnPropertyChanged<int>(() => this.SelectedDCAIndex);
			}
		}

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x060005D2 RID: 1490 RVA: 0x0001F3D0 File Offset: 0x0001D5D0
		// (set) Token: 0x060005D3 RID: 1491 RVA: 0x00008260 File Offset: 0x00006460
		public int DCAGain
		{
			get
			{
				return this._DCAGain;
			}
			set
			{
				this._DCAGain = value;
				this.OnPropertyChanged<int>(() => this.DCAGain);
			}
		}

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x060005D4 RID: 1492 RVA: 0x0001F3E8 File Offset: 0x0001D5E8
		// (set) Token: 0x060005D5 RID: 1493 RVA: 0x000082A0 File Offset: 0x000064A0
		public int PresetIndex
		{
			get
			{
				return this._PresetIndex;
			}
			set
			{
				this._PresetIndex = value;
				this.OnPropertyChanged<int>(() => this.PresetIndex);
			}
		}

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x060005D6 RID: 1494 RVA: 0x0001F400 File Offset: 0x0001D600
		// (set) Token: 0x060005D7 RID: 1495 RVA: 0x0001F418 File Offset: 0x0001D618
		public bool IsSelected_Left
		{
			get
			{
				return this._IsSelected_Left;
			}
			set
			{
				this._IsSelected_Left = value;
				this.OnPropertyChanged<bool>(() => this.IsSelected_Left);
				bool isSelected_Left = this.IsSelected_Left;
				if (isSelected_Left)
				{
					this.IsSelected_Right = false;
				}
			}
		}

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x060005D8 RID: 1496 RVA: 0x0001F478 File Offset: 0x0001D678
		// (set) Token: 0x060005D9 RID: 1497 RVA: 0x0001F490 File Offset: 0x0001D690
		public bool IsSelected_Right
		{
			get
			{
				return this._IsSelected_Right;
			}
			set
			{
				this._IsSelected_Right = value;
				this.OnPropertyChanged<bool>(() => this.IsSelected_Right);
				bool isSelected_Right = this.IsSelected_Right;
				if (isSelected_Right)
				{
					this.IsSelected_Left = false;
				}
			}
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x0001F4F0 File Offset: 0x0001D6F0
		private void UpdateAuxFxGroup()
		{
			this.AuxGroup1.GroupCollection.Clear();
			this.AuxGroup2.GroupCollection.Clear();
			this.FXGroup.GroupCollection.Clear();
			for (int i = 0; i < this.AuxFxItems.Length; i++)
			{
				bool flag = i < 4;
				if (flag)
				{
					this.AuxGroup1.Add(this.AuxFxItems[i]);
				}
				else
				{
					bool flag2 = i >= 4 && i < 8;
					if (flag2)
					{
						this.AuxGroup2.Add(this.AuxFxItems[i]);
					}
					else
					{
						this.FXGroup.Add(this.AuxFxItems[i]);
					}
				}
				this.AuxFxItems[i].MouseEnterCommand = this.MouseEnterAuxFxCommand;
			}
			this.AuxFxGroup.Add(this.AuxGroup1);
			this.AuxFxGroup.Add(this.AuxGroup2);
			this.AuxFxGroup.Add(this.FXGroup);
		}

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x060005DB RID: 1499 RVA: 0x000082E0 File Offset: 0x000064E0
		// (set) Token: 0x060005DC RID: 1500 RVA: 0x000082E8 File Offset: 0x000064E8
		public RelayCommand UpdatePresentChannelCommand { get; private set; } = null;

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x060005DD RID: 1501 RVA: 0x000082F1 File Offset: 0x000064F1
		// (set) Token: 0x060005DE RID: 1502 RVA: 0x000082F9 File Offset: 0x000064F9
		public RelayCommand MouseEnterCommand { get; private set; }

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x060005DF RID: 1503 RVA: 0x00008302 File Offset: 0x00006502
		// (set) Token: 0x060005E0 RID: 1504 RVA: 0x0000830A File Offset: 0x0000650A
		public RelayCommand<int> MouseEnterAuxFxCommand { get; private set; }

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x060005E1 RID: 1505 RVA: 0x00008313 File Offset: 0x00006513
		// (set) Token: 0x060005E2 RID: 1506 RVA: 0x0000831B File Offset: 0x0000651B
		public RelayCommand MouseEnterOtherCommand { get; private set; }

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x060005E3 RID: 1507 RVA: 0x00008324 File Offset: 0x00006524
		// (set) Token: 0x060005E4 RID: 1508 RVA: 0x0000832C File Offset: 0x0000652C
		public RelayCommand<int> MouseEnterOtherWithParameterCommand { get; private set; }

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x060005E5 RID: 1509 RVA: 0x00008335 File Offset: 0x00006535
		// (set) Token: 0x060005E6 RID: 1510 RVA: 0x0000833D File Offset: 0x0000653D
		public RelayCommand EqualizerFlatCommand { get; private set; } = null;

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x060005E7 RID: 1511 RVA: 0x00008346 File Offset: 0x00006546
		// (set) Token: 0x060005E8 RID: 1512 RVA: 0x0000834E File Offset: 0x0000654E
		public RelayCommand AllBypassCommand { get; private set; } = null;

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x060005E9 RID: 1513 RVA: 0x00008357 File Offset: 0x00006557
		// (set) Token: 0x060005EA RID: 1514 RVA: 0x0000835F File Offset: 0x0000655F
		public RelayCommand NoiseGateBypassCommand { get; private set; } = null;

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x060005EB RID: 1515 RVA: 0x00008368 File Offset: 0x00006568
		// (set) Token: 0x060005EC RID: 1516 RVA: 0x00008370 File Offset: 0x00006570
		public RelayCommand CompressorBypassCommand { get; private set; } = null;

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x060005ED RID: 1517 RVA: 0x00008379 File Offset: 0x00006579
		// (set) Token: 0x060005EE RID: 1518 RVA: 0x00008381 File Offset: 0x00006581
		public RelayCommand DC48Command { get; private set; }

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x060005EF RID: 1519 RVA: 0x0000838A File Offset: 0x0000658A
		// (set) Token: 0x060005F0 RID: 1520 RVA: 0x00008392 File Offset: 0x00006592
		public RelayCommand InvertCommand { get; private set; }

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x060005F1 RID: 1521 RVA: 0x0000839B File Offset: 0x0000659B
		// (set) Token: 0x060005F2 RID: 1522 RVA: 0x000083A3 File Offset: 0x000065A3
		public RelayCommand DelayValueChangeCommand { get; private set; }

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x060005F3 RID: 1523 RVA: 0x000083AC File Offset: 0x000065AC
		// (set) Token: 0x060005F4 RID: 1524 RVA: 0x000083B4 File Offset: 0x000065B4
		public RelayCommand AuxGroup1ChangeCommand { get; private set; }

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x060005F5 RID: 1525 RVA: 0x000083BD File Offset: 0x000065BD
		// (set) Token: 0x060005F6 RID: 1526 RVA: 0x000083C5 File Offset: 0x000065C5
		public RelayCommand AuxGroup2ChangeCommand { get; private set; }

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x060005F7 RID: 1527 RVA: 0x000083CE File Offset: 0x000065CE
		// (set) Token: 0x060005F8 RID: 1528 RVA: 0x000083D6 File Offset: 0x000065D6
		public RelayCommand AssignMainCommand { get; private set; }

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x060005F9 RID: 1529 RVA: 0x000083DF File Offset: 0x000065DF
		// (set) Token: 0x060005FA RID: 1530 RVA: 0x000083E7 File Offset: 0x000065E7
		public RelayCommand LinkCommand { get; private set; }

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x060005FB RID: 1531 RVA: 0x000083F0 File Offset: 0x000065F0
		// (set) Token: 0x060005FC RID: 1532 RVA: 0x000083F8 File Offset: 0x000065F8
		public RelayCommand FatChannelCommand { get; private set; }

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x060005FD RID: 1533 RVA: 0x00008401 File Offset: 0x00006601
		// (set) Token: 0x060005FE RID: 1534 RVA: 0x00008409 File Offset: 0x00006609
		public RelayCommand PanValueChangeCommand { get; private set; }

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x060005FF RID: 1535 RVA: 0x00008412 File Offset: 0x00006612
		// (set) Token: 0x06000600 RID: 1536 RVA: 0x0000841A File Offset: 0x0000661A
		public RelayCommand<int> UpdateEqualizerCommand { get; private set; }

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x06000601 RID: 1537 RVA: 0x00008423 File Offset: 0x00006623
		// (set) Token: 0x06000602 RID: 1538 RVA: 0x0000842B File Offset: 0x0000662B
		public RelayCommand<int> UpdateEqualizerTypeCommand { get; private set; }

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x06000603 RID: 1539 RVA: 0x00008434 File Offset: 0x00006634
		// (set) Token: 0x06000604 RID: 1540 RVA: 0x0000843C File Offset: 0x0000663C
		public RelayCommand AuxFxChangeCommand { get; private set; }

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x06000605 RID: 1541 RVA: 0x00008445 File Offset: 0x00006645
		// (set) Token: 0x06000606 RID: 1542 RVA: 0x0000844D File Offset: 0x0000664D
		public RelayCommand MuteGainChangeCommand { get; private set; }

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x06000607 RID: 1543 RVA: 0x00008456 File Offset: 0x00006656
		// (set) Token: 0x06000608 RID: 1544 RVA: 0x0000845E File Offset: 0x0000665E
		public RelayCommand SoloCommand { get; private set; }

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x06000609 RID: 1545 RVA: 0x00008467 File Offset: 0x00006667
		// (set) Token: 0x0600060A RID: 1546 RVA: 0x0000846F File Offset: 0x0000666F
		public RelayCommand SetChannenlNameCommand { get; set; }

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x0600060B RID: 1547 RVA: 0x00008478 File Offset: 0x00006678
		// (set) Token: 0x0600060C RID: 1548 RVA: 0x00008480 File Offset: 0x00006680
		public RelayCommand<TextBox> EditChannelNameCommand { get; set; }

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x0600060D RID: 1549 RVA: 0x00008489 File Offset: 0x00006689
		// (set) Token: 0x0600060E RID: 1550 RVA: 0x00008491 File Offset: 0x00006691
		public RelayCommand MatrixSelectedCommand { get; set; }

		// Token: 0x0600060F RID: 1551 RVA: 0x0001F5F4 File Offset: 0x0001D7F4
		private void MouseEnterOtherWithParameterExecute(int obj)
		{
			bool flag = obj == 0 && this.HasNoiseGate;
			if (flag)
			{
				UpStreamCommand.SendSynchronizePage(CommandConst.DEVE_PAGE_GATE, this.ChannelIndex + 1, 0, 0);
			}
			else
			{
				bool flag2 = obj == 1;
				if (flag2)
				{
					UpStreamCommand.SendSynchronizePage(CommandConst.DEVE_PAGE_COMP, this.ChannelIndex + 1, 0, 0);
				}
				else
				{
					UpStreamCommand.SendSynchronizePage(CommandConst.DEVE_PAGE_EQUALIZER, this.ChannelIndex + 1, 0, 0);
				}
			}
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x0001F668 File Offset: 0x0001D868
		private void MouseEnterAuxFxExecute(int obj)
		{
			bool flag = obj < 4;
			if (flag)
			{
				UpStreamCommand.SendSynchronizePage(CommandConst.DEVE_PAGE_ASSIGN, this.ChannelIndex + 1, (byte)obj, 0);
			}
			else
			{
				bool flag2 = obj >= 4 && obj < 8;
				if (flag2)
				{
					UpStreamCommand.SendSynchronizePage(CommandConst.DEVE_PAGE_ASSIGN, this.ChannelIndex + 1, (byte)(obj - 4), 1);
				}
				else
				{
					UpStreamCommand.SendSynchronizePage(CommandConst.DEVE_PAGE_ASSIGN, this.ChannelIndex + 1, (byte)(obj - 4), 0);
				}
			}
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x0000849A File Offset: 0x0000669A
		private void MouseEnterOtherExecute()
		{
			UpStreamCommand.SendSynchronizePage(CommandConst.DEVE_PAGE_CHANNEL, this.ChannelIndex + 1, 0, 0);
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x00003B79 File Offset: 0x00001D79
		private void MouseEnterExecute()
		{
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x0001F6E0 File Offset: 0x0001D8E0
		public void UpdatePresentChannelExecute()
		{
			bool link = this.Link;
			if (link)
			{
				int num = ChannelInfo.ChannelInfos.IndexOf(this) / 2;
				ChannelInfo channelInfo = ChannelInfo.ChannelInfos[2 * num];
				ChannelInfo channelInfo2 = ChannelInfo.ChannelInfos[2 * num + 1];
				ChannelInfo channelInfo3 = (channelInfo.IsStartLinkChannel ? channelInfo : channelInfo2);
				ViewModelMessager.Messeager.Notify(ViewModelMessager.UpdateChannelInfo, channelInfo3);
				UpStreamCommand.SendSynchronizePage(CommandConst.DEVE_PAGE_HOME, channelInfo3.ChannelIndex + 1, 0, 0);
			}
			else
			{
				ViewModelMessager.Messeager.Notify(ViewModelMessager.UpdateChannelInfo, this);
				UpStreamCommand.SendSynchronizePage(CommandConst.DEVE_PAGE_HOME, this.ChannelIndex + 1, 0, 0);
			}
			Application.Current.Dispatcher.Invoke(delegate
			{
				ChannelInfo.ChangedHighLightStatus(this);
			});
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x0001F7A4 File Offset: 0x0001D9A4
		private void EqualizerFlatExecute()
		{
			bool flag = MessageBox.Show(LocalizationManager.GetString("Str_FlatWarning"), LocalizationManager.GetString("Str_Tips"), MessageBoxButton.YesNo) == MessageBoxResult.Yes;
			if (flag)
			{
				foreach (EqualizerInfo equalizerInfo in this.EqualizerInfos)
				{
					equalizerInfo.EqualizerFlat();
				}
				UpStreamCommand.SendEqualizerFlat((int)this.ChannelIndex);
				ViewModelMessager.Messeager.Notify(ViewModelMessager.UpdateAllEqualizer);
			}
		}

		// Token: 0x06000615 RID: 1557 RVA: 0x0001F83C File Offset: 0x0001DA3C
		private void AllBypassExecute()
		{
			int num = 0;
			EqualizerInfo equalizerInfo = this.EqualizerInfos[num];
			UpStreamCommand.SendCMD_EqualizerAdjust(equalizerInfo, this.EqualizerAllBypass, num, this.ChannelIndex);
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x000084B3 File Offset: 0x000066B3
		private void NoiseGateBypassExecute()
		{
			UpStreamCommand.SendCMD_ChannelNoiseGate(this);
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x000084BD File Offset: 0x000066BD
		private void CompressorBypassExecute()
		{
			UpStreamCommand.SendCMD_ChannelCompressor(this);
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x000084C7 File Offset: 0x000066C7
		private void LinkExecute()
		{
			UpStreamCommand.SendChannelLink(this);
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x0001F870 File Offset: 0x0001DA70
		private void AssignMainExecute()
		{
			bool link = this.Link;
			if (link)
			{
				UpStreamCommand.SendCMD_FatChannelLink(this);
			}
			else
			{
				UpStreamCommand.SendCMD_FatChannel(this);
			}
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x00003B79 File Offset: 0x00001D79
		private void AuxGroup1ChangeExeucte()
		{
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x00003B79 File Offset: 0x00001D79
		private void AuxGroup2ChangeExeucte()
		{
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x000084D1 File Offset: 0x000066D1
		public void DelayValueChangeExecute()
		{
			UpStreamCommand.SendCMD_FatChannel(this);
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x000084D1 File Offset: 0x000066D1
		private void InvertExecute()
		{
			UpStreamCommand.SendCMD_FatChannel(this);
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x0001F89C File Offset: 0x0001DA9C
		private void DC48Execute()
		{
			bool flag = this.HasDC48V && this.DC48VEnabled;
			if (flag)
			{
				bool flag2 = MessageBox.Show(LocalizationManager.GetString("Str_48VWarning"), LocalizationManager.GetString("Str_Warning"), MessageBoxButton.OKCancel) == MessageBoxResult.OK;
				if (flag2)
				{
					UpStreamCommand.SendCMD_FatChannel(this);
				}
				else
				{
					this.DC48VEnabled = false;
				}
			}
			else
			{
				UpStreamCommand.SendCMD_FatChannel(this);
			}
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x0001F904 File Offset: 0x0001DB04
		private void PanValueChangeExecute()
		{
			bool flag = Mouse.LeftButton == MouseButtonState.Pressed;
			if (flag)
			{
				UpStreamCommand.SendCMD_FatChannel(this);
			}
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x000084D1 File Offset: 0x000066D1
		private void FatChannelExecute()
		{
			UpStreamCommand.SendCMD_FatChannel(this);
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x0001F928 File Offset: 0x0001DB28
		private void AuxFxChangeExecute()
		{
			bool flag = this.SelectAuxFxGroup == this.AuxGroup2;
			if (flag)
			{
				UpStreamCommand.SendCMD_FatChannel(this);
			}
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x0001F954 File Offset: 0x0001DB54
		public void MuteGainChangeExeucte()
		{
			bool link = this.Link;
			if (link)
			{
				this.LinkChannel.SendGainValue = this.SendGainValue;
				this.LinkChannel.IsMute = this.IsMute;
			}
			UpStreamCommand.SendCMD_ChannelsMuteGain();
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x0001F998 File Offset: 0x0001DB98
		private void UpdateEqualizerExeucte(int equalizerIndex)
		{
			EqualizerInfo equalizerInfo = this.EqualizerInfos[equalizerIndex];
			UpStreamCommand.SendCMD_EqualizerAdjust(equalizerInfo, this.EqualizerAllBypass, equalizerIndex, this.ChannelIndex);
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x0001F9C8 File Offset: 0x0001DBC8
		private void UpdateEqualizerTypeExecute(int equalizerIndex)
		{
			EqualizerInfo equalizerInfo = this.EqualizerInfos[equalizerIndex];
			bool tcomboBoxCanSend = this.TComboBoxCanSend;
			if (tcomboBoxCanSend)
			{
				UpStreamCommand.SendCMD_EqualizerAdjust(equalizerInfo, this.EqualizerAllBypass, equalizerIndex, this.ChannelIndex);
				this.TComboBoxCanSend = false;
			}
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x0001FA0C File Offset: 0x0001DC0C
		private void SoloExecute()
		{
			bool link = this.Link;
			if (link)
			{
				this.LinkChannel.IsSolo = this.IsSolo;
			}
			UpStreamCommand.SendCMD_ChannelsSolo();
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x0001FA40 File Offset: 0x0001DC40
		public void SetChannelNameExecute()
		{
			bool isMain = this.IsMain;
			if (!isMain)
			{
				bool isEditName = this.IsEditName;
				if (isEditName)
				{
					UpStreamCommand.SendSetChannelName(this);
					this.IsEditName = false;
				}
			}
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x000084DB File Offset: 0x000066DB
		private void EditChannelNameExecute(TextBox obj)
		{
			this.IsEditName = true;
			this.InputName = this.ChannelName;
			obj.Focus();
			Keyboard.Focus(obj);
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x00008501 File Offset: 0x00006701
		private void MatrixSelectedExecute()
		{
			UpStreamCommand.SendMatrixValueChanged(this);
		}

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x06000629 RID: 1577 RVA: 0x0000850B File Offset: 0x0000670B
		public Func<string, int> HPFFunc
		{
			get
			{
				return new Func<string, int>(this.HPFStrToInt1);
			}
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x0001FA7C File Offset: 0x0001DC7C
		public int HPFStrToInt1(string str)
		{
			double num;
			bool flag = double.TryParse(str, out num);
			int num2;
			if (flag)
			{
				num2 = HalfSearcher.search(FFTConstaint.FreqTable, FFTConstaint.FreqTable.Length, num);
			}
			else
			{
				num2 = this.HighPassFilter.FreqIndex;
			}
			return num2;
		}

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x0600062B RID: 1579 RVA: 0x00008519 File Offset: 0x00006719
		public Func<string, int> LPFFunc
		{
			get
			{
				return new Func<string, int>(this.LPFStrToInt1);
			}
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x0001FABC File Offset: 0x0001DCBC
		public int LPFStrToInt1(string str)
		{
			double num;
			bool flag = double.TryParse(str, out num);
			int num2;
			if (flag)
			{
				num2 = HalfSearcher.search(FFTConstaint.FreqTable, FFTConstaint.FreqTable.Length, num);
			}
			else
			{
				num2 = this.LowPassFilter.FreqIndex;
			}
			return num2;
		}

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x0600062D RID: 1581 RVA: 0x00008527 File Offset: 0x00006727
		public Func<string, int> FreqFunc1
		{
			get
			{
				return new Func<string, int>(this.FreqStrToInt1);
			}
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x0001FAFC File Offset: 0x0001DCFC
		public int FreqStrToInt1(string str)
		{
			double num;
			bool flag = double.TryParse(str, out num);
			int num2;
			if (flag)
			{
				num2 = HalfSearcher.search(FFTConstaint.FreqTable, FFTConstaint.FreqTable.Length, num);
			}
			else
			{
				num2 = this.EqualizerEdit1.FreqIndex;
			}
			return num2;
		}

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x0600062F RID: 1583 RVA: 0x00008535 File Offset: 0x00006735
		public Func<string, int> QFunc1
		{
			get
			{
				return new Func<string, int>(this.QStrToInt1);
			}
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x0001FB3C File Offset: 0x0001DD3C
		private int QStrToInt1(string str)
		{
			double num;
			bool flag = double.TryParse(str, out num);
			int num2;
			if (flag)
			{
				num2 = HalfSearcher.search(FFTConstaint.QValue24FactorTable, FFTConstaint.QValue24FactorTable.Length, num);
			}
			else
			{
				num2 = (int)this.EqualizerEdit1.QFactorIndex;
			}
			return num2;
		}

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x06000631 RID: 1585 RVA: 0x00008543 File Offset: 0x00006743
		public Func<string, int> GainFunc1
		{
			get
			{
				return new Func<string, int>(this.GainStrToInt1);
			}
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x0001FB7C File Offset: 0x0001DD7C
		private int GainStrToInt1(string str)
		{
			double num;
			bool flag = double.TryParse(str, out num);
			int num2;
			if (flag)
			{
				num2 = HalfSearcher.search(FFTConstaint.Gain24Table, FFTConstaint.Gain24Table.Length, num);
			}
			else
			{
				num2 = this.EqualizerEdit1.GainIndex;
			}
			return num2;
		}

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06000633 RID: 1587 RVA: 0x00008551 File Offset: 0x00006751
		public Func<string, int> FreqFunc2
		{
			get
			{
				return new Func<string, int>(this.FreqStrToInt2);
			}
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x0001FBBC File Offset: 0x0001DDBC
		public int FreqStrToInt2(string str)
		{
			double num;
			bool flag = double.TryParse(str, out num);
			int num2;
			if (flag)
			{
				num2 = HalfSearcher.search(FFTConstaint.FreqTable, FFTConstaint.FreqTable.Length, num);
			}
			else
			{
				num2 = this.EqualizerEdit2.FreqIndex;
			}
			return num2;
		}

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06000635 RID: 1589 RVA: 0x0000855F File Offset: 0x0000675F
		public Func<string, int> QFunc2
		{
			get
			{
				return new Func<string, int>(this.QStrToInt2);
			}
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x0001FBFC File Offset: 0x0001DDFC
		private int QStrToInt2(string str)
		{
			double num;
			bool flag = double.TryParse(str, out num);
			int num2;
			if (flag)
			{
				num2 = HalfSearcher.search(FFTConstaint.QValue24FactorTable, FFTConstaint.QValue24FactorTable.Length, num);
			}
			else
			{
				num2 = (int)this.EqualizerEdit2.QFactorIndex;
			}
			return num2;
		}

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06000637 RID: 1591 RVA: 0x0000856D File Offset: 0x0000676D
		public Func<string, int> GainFunc2
		{
			get
			{
				return new Func<string, int>(this.GainStrToInt2);
			}
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x0001FC3C File Offset: 0x0001DE3C
		private int GainStrToInt2(string str)
		{
			double num;
			bool flag = double.TryParse(str, out num);
			int num2;
			if (flag)
			{
				num2 = HalfSearcher.search(FFTConstaint.Gain24Table, FFTConstaint.Gain24Table.Length, num);
			}
			else
			{
				num2 = this.EqualizerEdit2.GainIndex;
			}
			return num2;
		}

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06000639 RID: 1593 RVA: 0x0000857B File Offset: 0x0000677B
		public Func<string, int> FreqFunc3
		{
			get
			{
				return new Func<string, int>(this.FreqStrToInt3);
			}
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x0001FC7C File Offset: 0x0001DE7C
		public int FreqStrToInt3(string str)
		{
			double num;
			bool flag = double.TryParse(str, out num);
			int num2;
			if (flag)
			{
				num2 = HalfSearcher.search(FFTConstaint.FreqTable, FFTConstaint.FreqTable.Length, num);
			}
			else
			{
				num2 = this.EqualizerEdit3.FreqIndex;
			}
			return num2;
		}

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x0600063B RID: 1595 RVA: 0x00008589 File Offset: 0x00006789
		public Func<string, int> QFunc3
		{
			get
			{
				return new Func<string, int>(this.QStrToInt3);
			}
		}

		// Token: 0x0600063C RID: 1596 RVA: 0x0001FCBC File Offset: 0x0001DEBC
		private int QStrToInt3(string str)
		{
			double num;
			bool flag = double.TryParse(str, out num);
			int num2;
			if (flag)
			{
				num2 = HalfSearcher.search(FFTConstaint.QValue24FactorTable, FFTConstaint.QValue24FactorTable.Length, num);
			}
			else
			{
				num2 = (int)this.EqualizerEdit3.QFactorIndex;
			}
			return num2;
		}

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x0600063D RID: 1597 RVA: 0x00008597 File Offset: 0x00006797
		public Func<string, int> GainFunc3
		{
			get
			{
				return new Func<string, int>(this.GainStrToInt3);
			}
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x0001FCFC File Offset: 0x0001DEFC
		private int GainStrToInt3(string str)
		{
			double num;
			bool flag = double.TryParse(str, out num);
			int num2;
			if (flag)
			{
				num2 = HalfSearcher.search(FFTConstaint.Gain24Table, FFTConstaint.Gain24Table.Length, num);
			}
			else
			{
				num2 = this.EqualizerEdit3.GainIndex;
			}
			return num2;
		}

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x0600063F RID: 1599 RVA: 0x000085A5 File Offset: 0x000067A5
		public Func<string, int> FreqFunc4
		{
			get
			{
				return new Func<string, int>(this.FreqStrToInt4);
			}
		}

		// Token: 0x06000640 RID: 1600 RVA: 0x0001FD3C File Offset: 0x0001DF3C
		public int FreqStrToInt4(string str)
		{
			double num;
			bool flag = double.TryParse(str, out num);
			int num2;
			if (flag)
			{
				num2 = HalfSearcher.search(FFTConstaint.FreqTable, FFTConstaint.FreqTable.Length, num);
			}
			else
			{
				num2 = this.EqualizerEdit4.FreqIndex;
			}
			return num2;
		}

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x06000641 RID: 1601 RVA: 0x000085B3 File Offset: 0x000067B3
		public Func<string, int> QFunc4
		{
			get
			{
				return new Func<string, int>(this.QStrToInt4);
			}
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x0001FD7C File Offset: 0x0001DF7C
		private int QStrToInt4(string str)
		{
			double num;
			bool flag = double.TryParse(str, out num);
			int num2;
			if (flag)
			{
				num2 = HalfSearcher.search(FFTConstaint.QValue24FactorTable, FFTConstaint.QValue24FactorTable.Length, num);
			}
			else
			{
				num2 = (int)this.EqualizerEdit4.QFactorIndex;
			}
			return num2;
		}

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x06000643 RID: 1603 RVA: 0x000085C1 File Offset: 0x000067C1
		public Func<string, int> GainFunc4
		{
			get
			{
				return new Func<string, int>(this.GainStrToInt4);
			}
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x0001FDBC File Offset: 0x0001DFBC
		private int GainStrToInt4(string str)
		{
			double num;
			bool flag = double.TryParse(str, out num);
			int num2;
			if (flag)
			{
				num2 = HalfSearcher.search(FFTConstaint.Gain24Table, FFTConstaint.Gain24Table.Length, num);
			}
			else
			{
				num2 = this.EqualizerEdit4.GainIndex;
			}
			return num2;
		}

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06000645 RID: 1605 RVA: 0x000085CF File Offset: 0x000067CF
		public Func<string, int> DelayFunc
		{
			get
			{
				return new Func<string, int>(this.DelayStrToInt);
			}
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x0001FDFC File Offset: 0x0001DFFC
		private int DelayStrToInt(string str)
		{
			double num;
			bool flag = double.TryParse(str, out num);
			int num3;
			if (flag)
			{
				int num2 = (int)Math.Min(Math.Max(0.0, num * 4.8), 1443.0);
				num3 = num2;
			}
			else
			{
				num3 = this.DelayValue;
			}
			return num3;
		}

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06000647 RID: 1607 RVA: 0x000085DD File Offset: 0x000067DD
		public Func<string, int> NGThresFunc
		{
			get
			{
				return new Func<string, int>(this.NGThresStrToInt1);
			}
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x0001FE50 File Offset: 0x0001E050
		public int NGThresStrToInt1(string str)
		{
			double num;
			bool flag = double.TryParse(str, out num);
			int num2;
			if (flag)
			{
				num2 = HalfSearcher.search_String(Const.NoiseGateThresholds, Const.NoiseGateThresholds.Length, str);
			}
			else
			{
				num2 = (int)this.NoiseGateInfo.Threshold;
			}
			return num2;
		}

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06000649 RID: 1609 RVA: 0x000085EB File Offset: 0x000067EB
		public Func<string, int> CPThresFunc
		{
			get
			{
				return new Func<string, int>(this.CPThresStrToInt1);
			}
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x0001FE90 File Offset: 0x0001E090
		public int CPThresStrToInt1(string str)
		{
			double num;
			bool flag = double.TryParse(str, out num);
			int num2;
			if (flag)
			{
				num2 = HalfSearcher.search_String(Const.CompressorThresholds, Const.CompressorThresholds.Length, str);
			}
			else
			{
				num2 = this.HighPassFilter.FreqIndex;
			}
			return num2;
		}

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x0600064B RID: 1611 RVA: 0x000085F9 File Offset: 0x000067F9
		public Func<string, int> NGRatioFunc
		{
			get
			{
				return new Func<string, int>(this.NGRatioStrToInt1);
			}
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x0001FA7C File Offset: 0x0001DC7C
		public int NGRatioStrToInt1(string str)
		{
			double num;
			bool flag = double.TryParse(str, out num);
			int num2;
			if (flag)
			{
				num2 = HalfSearcher.search(FFTConstaint.FreqTable, FFTConstaint.FreqTable.Length, num);
			}
			else
			{
				num2 = this.HighPassFilter.FreqIndex;
			}
			return num2;
		}

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x0600064D RID: 1613 RVA: 0x00008607 File Offset: 0x00006807
		public Func<string, int> CPRatioFunc
		{
			get
			{
				return new Func<string, int>(this.CPRatioStrToInt1);
			}
		}

		// Token: 0x0600064E RID: 1614 RVA: 0x0001FA7C File Offset: 0x0001DC7C
		public int CPRatioStrToInt1(string str)
		{
			double num;
			bool flag = double.TryParse(str, out num);
			int num2;
			if (flag)
			{
				num2 = HalfSearcher.search(FFTConstaint.FreqTable, FFTConstaint.FreqTable.Length, num);
			}
			else
			{
				num2 = this.HighPassFilter.FreqIndex;
			}
			return num2;
		}

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x0600064F RID: 1615 RVA: 0x00008615 File Offset: 0x00006815
		public Func<string, int> NGATKFunc
		{
			get
			{
				return new Func<string, int>(this.NGATKStrToInt1);
			}
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x0001FED0 File Offset: 0x0001E0D0
		public int NGATKStrToInt1(string str)
		{
			double num;
			bool flag = double.TryParse(str, out num);
			int num2;
			if (flag)
			{
				num2 = HalfSearcher.search_String(Const.NoiseGateAttacks, Const.NoiseGateAttacks.Length, str);
			}
			else
			{
				num2 = this.NoiseGateInfo.Attack;
			}
			return num2;
		}

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000651 RID: 1617 RVA: 0x00008623 File Offset: 0x00006823
		public Func<string, int> CPATKFunc
		{
			get
			{
				return new Func<string, int>(this.CPATKStrToInt1);
			}
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x0001FF10 File Offset: 0x0001E110
		public int CPATKStrToInt1(string str)
		{
			double num;
			bool flag = double.TryParse(str, out num);
			int num2;
			if (flag)
			{
				num2 = HalfSearcher.search_String(Const.CompressorAttacks, Const.CompressorAttacks.Length, str);
			}
			else
			{
				num2 = this.NoiseGateInfo.Attack;
			}
			return num2;
		}

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06000653 RID: 1619 RVA: 0x00008631 File Offset: 0x00006831
		public Func<string, int> NGReleaseFunc
		{
			get
			{
				return new Func<string, int>(this.NGReleaseStrToInt1);
			}
		}

		// Token: 0x06000654 RID: 1620 RVA: 0x0001FF50 File Offset: 0x0001E150
		public int NGReleaseStrToInt1(string str)
		{
			double num;
			bool flag = double.TryParse(str, out num);
			int num2;
			if (flag)
			{
				num2 = HalfSearcher.search_String(Const.NoiseGateReleases, Const.NoiseGateReleases.Length, str);
			}
			else
			{
				num2 = this.HighPassFilter.FreqIndex;
			}
			return num2;
		}

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06000655 RID: 1621 RVA: 0x0000863F File Offset: 0x0000683F
		public Func<string, int> CPReleaseFunc
		{
			get
			{
				return new Func<string, int>(this.CPReleaseStrToInt1);
			}
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x0001FF90 File Offset: 0x0001E190
		public int CPReleaseStrToInt1(string str)
		{
			double num;
			bool flag = double.TryParse(str, out num);
			int num2;
			if (flag)
			{
				num2 = HalfSearcher.search_String(Const.CompressorReleases, Const.CompressorReleases.Length, str);
			}
			else
			{
				num2 = this.HighPassFilter.FreqIndex;
			}
			return num2;
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000657 RID: 1623 RVA: 0x0001FFD0 File Offset: 0x0001E1D0
		// (remove) Token: 0x06000658 RID: 1624 RVA: 0x00020008 File Offset: 0x0001E208
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event ChannelInfo.RouteValueChangedEventHandler RouteValueChanged;

		// Token: 0x06000659 RID: 1625 RVA: 0x000047F1 File Offset: 0x000029F1
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			SerializerHelper.SerializationPropertyHelper(info, this, new Type[]
			{
				typeof(RelayCommand),
				typeof(RelayCommand<int>),
				typeof(ICommand)
			});
			SerializerHelper.SerializationFieldHelper(info, this);
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x00020040 File Offset: 0x0001E240
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		protected ChannelInfo(SerializationInfo info, StreamingContext context)
		{
			SerializerHelper.DeSerializationFieldHelper(info, this);
			SerializerHelper.DeserializtionPropertyHelper(info, this, new Type[]
			{
				typeof(RelayCommand),
				typeof(RelayCommand<int>),
				typeof(ICommand)
			});
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x000201CC File Offset: 0x0001E3CC
		public ChannelInfo(ChannelType channelType)
		{
			this.ChannelType = channelType;
			switch (this.ChannelType)
			{
			case ChannelType.CH_01_24:
				this.InitializeProperty(true, true, true, true, true, true, true);
				break;
			case ChannelType.FX:
				this.InitializeProperty(false, false, false, false, true, false, false);
				break;
			case ChannelType.Aux:
				this.InitializeProperty(false, true, false, false, true, false, false);
				break;
			case ChannelType.Main:
				this.InitializeProperty(false, false, false, false, false, false, true);
				break;
			}
			this.InitializeArray();
			this.InitialCommand();
			ChannelInfo.ChannelInfos.Add(this);
			ChannelInfo.AddChannelInDictionary(channelType, this);
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x000203A8 File Offset: 0x0001E5A8
		public ChannelInfo()
		{
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x0000864D File Offset: 0x0000684D
		private void InitializeProperty(bool hasDC48V, bool hasLink, bool hasAux, bool hasFx, bool assignMain, bool hasNoiseGate, bool hasStereo)
		{
			this.HasDC48V = hasDC48V;
			this.HasLink = hasLink;
			this.HasAux = hasAux;
			this.HasFX = hasFx;
			this.AssignMain = assignMain;
			this.HasNoiseGate = hasNoiseGate;
			this.HasStereo = hasStereo;
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x000204F8 File Offset: 0x0001E6F8
		private void InitializeArray()
		{
			this.EqualizerInfos.Add(this.HighPassFilter);
			this.EqualizerInfos.Add(this.LowPassFilter);
			this.EqualizerInfos.Add(this.EqualizerEdit1);
			this.EqualizerInfos.Add(this.EqualizerEdit2);
			this.EqualizerInfos.Add(this.EqualizerEdit3);
			this.EqualizerInfos.Add(this.EqualizerEdit4);
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x00020574 File Offset: 0x0001E774
		private void InitialCommand()
		{
			this.MouseEnterCommand = new RelayCommand(new Action(this.MouseEnterExecute));
			this.UpdatePresentChannelCommand = new RelayCommand(new Action(this.UpdatePresentChannelExecute));
			this.EqualizerFlatCommand = new RelayCommand(new Action(this.EqualizerFlatExecute));
			this.AllBypassCommand = new RelayCommand(new Action(this.AllBypassExecute));
			this.NoiseGateBypassCommand = new RelayCommand(new Action(this.NoiseGateBypassExecute));
			this.CompressorBypassCommand = new RelayCommand(new Action(this.CompressorBypassExecute));
			this.DC48Command = new RelayCommand(new Action(this.DC48Execute));
			this.InvertCommand = new RelayCommand(new Action(this.InvertExecute));
			this.DelayValueChangeCommand = new RelayCommand(new Action(this.DelayValueChangeExecute));
			this.AuxGroup1ChangeCommand = new RelayCommand(new Action(this.AuxGroup1ChangeExeucte));
			this.AuxGroup2ChangeCommand = new RelayCommand(new Action(this.AuxGroup2ChangeExeucte));
			this.AssignMainCommand = new RelayCommand(new Action(this.AssignMainExecute));
			this.LinkCommand = new RelayCommand(new Action(this.LinkExecute));
			this.PanValueChangeCommand = new RelayCommand(new Action(this.PanValueChangeExecute));
			this.UpdateEqualizerCommand = new RelayCommand<int>(new Action<int>(this.UpdateEqualizerExeucte));
			this.UpdateEqualizerTypeCommand = new RelayCommand<int>(new Action<int>(this.UpdateEqualizerTypeExecute));
			this.FatChannelCommand = new RelayCommand(new Action(this.FatChannelExecute));
			this.AuxFxChangeCommand = new RelayCommand(new Action(this.AuxFxChangeExecute));
			this.MuteGainChangeCommand = new RelayCommand(new Action(this.MuteGainChangeExeucte));
			this.SoloCommand = new RelayCommand(new Action(this.SoloExecute));
			this.MouseEnterAuxFxCommand = new RelayCommand<int>(new Action<int>(this.MouseEnterAuxFxExecute));
			this.MouseEnterOtherCommand = new RelayCommand(new Action(this.MouseEnterOtherExecute));
			this.MouseEnterOtherWithParameterCommand = new RelayCommand<int>(new Action<int>(this.MouseEnterOtherWithParameterExecute));
			this.SetChannenlNameCommand = new RelayCommand(new Action(this.SetChannelNameExecute));
			this.EditChannelNameCommand = new RelayCommand<TextBox>(new Action<TextBox>(this.EditChannelNameExecute));
			this.MatrixSelectedCommand = new RelayCommand(new Action(this.MatrixSelectedExecute));
		}

		// Token: 0x06000660 RID: 1632 RVA: 0x000207F4 File Offset: 0x0001E9F4
		public static void ChangedHighLightStatus(ChannelInfo channelInfo)
		{
			bool isPresentChannel = channelInfo.IsPresentChannel;
			if (isPresentChannel)
			{
				bool flag = channelInfo.Link && channelInfo.HasLink;
				if (flag)
				{
					int num = ChannelInfo.ChannelInfos.IndexOf(channelInfo) / 2;
					ChannelInfo channelInfo2 = ChannelInfo.ChannelInfos[num * 2];
					ChannelInfo channelInfo3 = ChannelInfo.ChannelInfos[num * 2 + 1];
					foreach (ChannelInfo channelInfo4 in ChannelInfo.ChannelInfos)
					{
						channelInfo4.IsPresentChannel = channelInfo4.Equals(channelInfo2) || channelInfo4.Equals(channelInfo3);
					}
				}
				else
				{
					foreach (ChannelInfo channelInfo5 in ChannelInfo.ChannelInfos)
					{
						channelInfo5.IsPresentChannel = channelInfo5.Equals(channelInfo);
					}
				}
			}
			else
			{
				bool link = channelInfo.Link;
				if (link)
				{
					int num2 = ChannelInfo.ChannelInfos.IndexOf(channelInfo) / 2;
					ChannelInfo channelInfo6 = ChannelInfo.ChannelInfos[num2 * 2];
					ChannelInfo channelInfo7 = ChannelInfo.ChannelInfos[num2 * 2 + 1];
					channelInfo6.IsPresentChannel = (channelInfo7.IsPresentChannel = true);
				}
				else
				{
					channelInfo.IsPresentChannel = true;
				}
			}
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x00020974 File Offset: 0x0001EB74
		private static void AddChannelInDictionary(ChannelType channelType, ChannelInfo channelInfo)
		{
			List<ChannelInfo> list;
			bool flag = ChannelInfo.ChannelDictionary.TryGetValue(channelType, out list);
			if (flag)
			{
				list.Add(channelInfo);
			}
			else
			{
				ChannelInfo.ChannelDictionary[channelType] = new List<ChannelInfo> { channelInfo };
			}
		}

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06000662 RID: 1634 RVA: 0x0000868C File Offset: 0x0000688C
		// (set) Token: 0x06000663 RID: 1635 RVA: 0x00008693 File Offset: 0x00006893
		public static Dictionary<ChannelType, List<ChannelInfo>> ChannelDictionary { get; set; } = new Dictionary<ChannelType, List<ChannelInfo>>();

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06000664 RID: 1636 RVA: 0x0000869B File Offset: 0x0000689B
		// (set) Token: 0x06000665 RID: 1637 RVA: 0x000086A2 File Offset: 0x000068A2
		public static List<ChannelInfo> ChannelInfos { get; set; } = new List<ChannelInfo>();

		// Token: 0x0400032A RID: 810
		private string _ChannelName = "Text";

		// Token: 0x0400032B RID: 811
		private string _InputName;

		// Token: 0x0400032C RID: 812
		private bool _IsEditName;

		// Token: 0x0400032E RID: 814
		private bool _IsPresentChannel;

		// Token: 0x0400032F RID: 815
		private bool _IsMute;

		// Token: 0x04000330 RID: 816
		private bool _IsSolo;

		// Token: 0x04000331 RID: 817
		private int _MeterValue;

		// Token: 0x04000332 RID: 818
		private bool _HasStereo;

		// Token: 0x04000333 RID: 819
		private int _RightMeterValue;

		// Token: 0x04000334 RID: 820
		private int _GainValue;

		// Token: 0x04000335 RID: 821
		private double _sendGainValue;

		// Token: 0x04000336 RID: 822
		private string _GainString;

		// Token: 0x04000337 RID: 823
		private bool _AllBypass = true;

		// Token: 0x04000338 RID: 824
		private EqualizerInfo _EqualizerEdit1 = new EqualizerInfo(0, 2)
		{
			IsHighLowPass = false
		};

		// Token: 0x04000339 RID: 825
		private EqualizerInfo _EqualizerEdit2 = new EqualizerInfo(1, 3)
		{
			IsHighLowPass = false
		};

		// Token: 0x0400033A RID: 826
		private EqualizerInfo _EqualizerEdit3 = new EqualizerInfo(2, 4)
		{
			IsHighLowPass = false
		};

		// Token: 0x0400033B RID: 827
		private EqualizerInfo _EqualizerEdit4 = new EqualizerInfo(3, 5)
		{
			IsHighLowPass = false
		};

		// Token: 0x0400033C RID: 828
		private EqualizerInfo _HighPassFilter = new EqualizerInfo(4, 0)
		{
			IsHighLowPass = true
		};

		// Token: 0x0400033D RID: 829
		private EqualizerInfo _LowPassFilter = new EqualizerInfo(5, 1)
		{
			IsHighLowPass = true
		};

		// Token: 0x04000340 RID: 832
		private NoiseGateInfo _NoiseGateInfo = new NoiseGateInfo();

		// Token: 0x04000341 RID: 833
		private bool _HasNoiseGate;

		// Token: 0x04000342 RID: 834
		private CompressorInfo _CompressorInfo = new CompressorInfo();

		// Token: 0x04000343 RID: 835
		private ChannelType _ChannelType;

		// Token: 0x04000345 RID: 837
		private int _PanValue;

		// Token: 0x04000346 RID: 838
		private bool _DelayEnabled;

		// Token: 0x04000347 RID: 839
		private double _SendDelayValue;

		// Token: 0x04000348 RID: 840
		private int _DelayValue;

		// Token: 0x04000349 RID: 841
		private bool _HasDC48V;

		// Token: 0x0400034A RID: 842
		private bool _DC48VEnabled;

		// Token: 0x0400034B RID: 843
		private bool _Invert;

		// Token: 0x0400034C RID: 844
		private bool _AssignMain;

		// Token: 0x0400034D RID: 845
		private bool _HasLink;

		// Token: 0x0400034E RID: 846
		private bool _Link;

		// Token: 0x0400034F RID: 847
		private bool _IsStartLinkChannel;

		// Token: 0x04000351 RID: 849
		private bool _IsMain;

		// Token: 0x04000352 RID: 850
		private bool _HasAux;

		// Token: 0x04000353 RID: 851
		private bool _HasFX;

		// Token: 0x04000357 RID: 855
		private AuxFxItem[] _AuxFxItems;

		// Token: 0x04000358 RID: 856
		private ObservableCollection<GroupInfo<AuxFxItem>> _AuxFxGroup = new ObservableCollection<GroupInfo<AuxFxItem>>();

		// Token: 0x04000359 RID: 857
		private GroupInfo<AuxFxItem> _SelectAuxFxGroup;

		// Token: 0x0400035A RID: 858
		private int _SelectAuxFXIndex;

		// Token: 0x0400035B RID: 859
		private GroupInfo<FXItem> _FXEffects;

		// Token: 0x0400035C RID: 860
		private DigitalInfo _DigitalInput = new DigitalInfo();

		// Token: 0x0400035D RID: 861
		private DigitalInfo _DigitalOutput = new DigitalInfo();

		// Token: 0x0400035E RID: 862
		private int _SelectedDCAIndex;

		// Token: 0x0400035F RID: 863
		private int _DCAGain;

		// Token: 0x04000360 RID: 864
		private int _PresetIndex;

		// Token: 0x04000361 RID: 865
		private bool _IsSelected_Left;

		// Token: 0x04000362 RID: 866
		private bool _IsSelected_Right;

		// Token: 0x02000067 RID: 103
		// (Invoke) Token: 0x06000669 RID: 1641
		public delegate void RouteValueChangedEventHandler(RouteType routeType, int value);
	}
}
