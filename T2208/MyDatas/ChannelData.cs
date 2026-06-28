using System;
using System.Collections.Generic;
using JayLib;
using JayLib.WPF.BasicClass;
using T2208.MyInformations;
using T2208.ViewModels;

namespace T2208.MyDatas
{
	// Token: 0x0200006D RID: 109
	public class ChannelData : NotificationObject
	{
		// Token: 0x17000259 RID: 601
		// (get) Token: 0x06000680 RID: 1664 RVA: 0x00020B2C File Offset: 0x0001ED2C
		public static ChannelData ChannelDatas
		{
			get
			{
				return SingleTon<ChannelData>.GetInstance();
			}
		}

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x06000681 RID: 1665 RVA: 0x00008889 File Offset: 0x00006A89
		// (set) Token: 0x06000682 RID: 1666 RVA: 0x00008890 File Offset: 0x00006A90
		public static int PresentChannelIndex
		{
			get
			{
				return ChannelData.s_presentChannelIndex;
			}
			set
			{
				ChannelData.s_presentChannelIndex = value;
				ViewModelMessager.Messeager.Notify(ViewModelMessager.UpdateDSPGEQFXIndex);
			}
		}

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x06000683 RID: 1667 RVA: 0x00020B44 File Offset: 0x0001ED44
		// (set) Token: 0x06000684 RID: 1668 RVA: 0x000088A9 File Offset: 0x00006AA9
		public ChannelInfo CH01
		{
			get
			{
				return this._CH01;
			}
			private set
			{
				this._CH01 = value;
			}
		}

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x06000685 RID: 1669 RVA: 0x00020B5C File Offset: 0x0001ED5C
		// (set) Token: 0x06000686 RID: 1670 RVA: 0x000088B2 File Offset: 0x00006AB2
		public ChannelInfo CH02
		{
			get
			{
				return this._CH02;
			}
			private set
			{
				this._CH02 = value;
			}
		}

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06000687 RID: 1671 RVA: 0x00020B74 File Offset: 0x0001ED74
		// (set) Token: 0x06000688 RID: 1672 RVA: 0x000088BB File Offset: 0x00006ABB
		public ChannelInfo CH03
		{
			get
			{
				return this._CH03;
			}
			private set
			{
				this._CH03 = value;
			}
		}

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06000689 RID: 1673 RVA: 0x00020B8C File Offset: 0x0001ED8C
		// (set) Token: 0x0600068A RID: 1674 RVA: 0x000088C4 File Offset: 0x00006AC4
		public ChannelInfo CH04
		{
			get
			{
				return this._CH04;
			}
			private set
			{
				this._CH04 = value;
			}
		}

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x0600068B RID: 1675 RVA: 0x00020BA4 File Offset: 0x0001EDA4
		// (set) Token: 0x0600068C RID: 1676 RVA: 0x000088CD File Offset: 0x00006ACD
		public ChannelInfo CH05
		{
			get
			{
				return this._CH05;
			}
			private set
			{
				this._CH05 = value;
			}
		}

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x0600068D RID: 1677 RVA: 0x00020BBC File Offset: 0x0001EDBC
		// (set) Token: 0x0600068E RID: 1678 RVA: 0x000088D6 File Offset: 0x00006AD6
		public ChannelInfo CH06
		{
			get
			{
				return this._CH06;
			}
			private set
			{
				this._CH06 = value;
			}
		}

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x0600068F RID: 1679 RVA: 0x00020BD4 File Offset: 0x0001EDD4
		// (set) Token: 0x06000690 RID: 1680 RVA: 0x000088DF File Offset: 0x00006ADF
		public ChannelInfo CH07
		{
			get
			{
				return this._CH07;
			}
			private set
			{
				this._CH07 = value;
			}
		}

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x06000691 RID: 1681 RVA: 0x00020BEC File Offset: 0x0001EDEC
		// (set) Token: 0x06000692 RID: 1682 RVA: 0x000088E8 File Offset: 0x00006AE8
		public ChannelInfo CH08
		{
			get
			{
				return this._CH08;
			}
			private set
			{
				this._CH08 = value;
			}
		}

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000693 RID: 1683 RVA: 0x00020C04 File Offset: 0x0001EE04
		// (set) Token: 0x06000694 RID: 1684 RVA: 0x000088F1 File Offset: 0x00006AF1
		public ChannelInfo CH09
		{
			get
			{
				return this._CH09;
			}
			private set
			{
				this._CH09 = value;
			}
		}

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000695 RID: 1685 RVA: 0x00020C1C File Offset: 0x0001EE1C
		// (set) Token: 0x06000696 RID: 1686 RVA: 0x000088FA File Offset: 0x00006AFA
		public ChannelInfo CH10
		{
			get
			{
				return this._CH10;
			}
			private set
			{
				this._CH10 = value;
			}
		}

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06000697 RID: 1687 RVA: 0x00020C34 File Offset: 0x0001EE34
		// (set) Token: 0x06000698 RID: 1688 RVA: 0x00008903 File Offset: 0x00006B03
		public ChannelInfo CH11
		{
			get
			{
				return this._CH11;
			}
			private set
			{
				this._CH11 = value;
			}
		}

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x06000699 RID: 1689 RVA: 0x00020C4C File Offset: 0x0001EE4C
		// (set) Token: 0x0600069A RID: 1690 RVA: 0x0000890C File Offset: 0x00006B0C
		public ChannelInfo CH12
		{
			get
			{
				return this._CH12;
			}
			private set
			{
				this._CH12 = value;
			}
		}

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x0600069B RID: 1691 RVA: 0x00020C64 File Offset: 0x0001EE64
		// (set) Token: 0x0600069C RID: 1692 RVA: 0x00008915 File Offset: 0x00006B15
		public ChannelInfo CH13
		{
			get
			{
				return this._CH13;
			}
			private set
			{
				this._CH13 = value;
			}
		}

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x0600069D RID: 1693 RVA: 0x00020C7C File Offset: 0x0001EE7C
		// (set) Token: 0x0600069E RID: 1694 RVA: 0x0000891E File Offset: 0x00006B1E
		public ChannelInfo CH14
		{
			get
			{
				return this._CH14;
			}
			private set
			{
				this._CH14 = value;
			}
		}

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x0600069F RID: 1695 RVA: 0x00020C94 File Offset: 0x0001EE94
		// (set) Token: 0x060006A0 RID: 1696 RVA: 0x00008927 File Offset: 0x00006B27
		public ChannelInfo CH15
		{
			get
			{
				return this._CH15;
			}
			private set
			{
				this._CH15 = value;
			}
		}

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x060006A1 RID: 1697 RVA: 0x00020CAC File Offset: 0x0001EEAC
		// (set) Token: 0x060006A2 RID: 1698 RVA: 0x00008930 File Offset: 0x00006B30
		public ChannelInfo CH16
		{
			get
			{
				return this._CH16;
			}
			private set
			{
				this._CH16 = value;
			}
		}

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x060006A3 RID: 1699 RVA: 0x00020CC4 File Offset: 0x0001EEC4
		// (set) Token: 0x060006A4 RID: 1700 RVA: 0x00008939 File Offset: 0x00006B39
		public ChannelInfo CH17
		{
			get
			{
				return this._CH17;
			}
			private set
			{
				this._CH17 = value;
			}
		}

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x060006A5 RID: 1701 RVA: 0x00020CDC File Offset: 0x0001EEDC
		// (set) Token: 0x060006A6 RID: 1702 RVA: 0x00008942 File Offset: 0x00006B42
		public ChannelInfo CH18
		{
			get
			{
				return this._CH18;
			}
			private set
			{
				this._CH18 = value;
			}
		}

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x060006A7 RID: 1703 RVA: 0x00020CF4 File Offset: 0x0001EEF4
		// (set) Token: 0x060006A8 RID: 1704 RVA: 0x0000894B File Offset: 0x00006B4B
		public ChannelInfo CH19
		{
			get
			{
				return this._CH19;
			}
			private set
			{
				this._CH19 = value;
			}
		}

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x060006A9 RID: 1705 RVA: 0x00020D0C File Offset: 0x0001EF0C
		// (set) Token: 0x060006AA RID: 1706 RVA: 0x00008954 File Offset: 0x00006B54
		public ChannelInfo CH20
		{
			get
			{
				return this._CH20;
			}
			private set
			{
				this._CH20 = value;
			}
		}

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x060006AB RID: 1707 RVA: 0x00020D24 File Offset: 0x0001EF24
		// (set) Token: 0x060006AC RID: 1708 RVA: 0x0000895D File Offset: 0x00006B5D
		public ChannelInfo CH21
		{
			get
			{
				return this._CH21;
			}
			private set
			{
				this._CH21 = value;
			}
		}

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x060006AD RID: 1709 RVA: 0x00020D3C File Offset: 0x0001EF3C
		// (set) Token: 0x060006AE RID: 1710 RVA: 0x00008966 File Offset: 0x00006B66
		public ChannelInfo CH22
		{
			get
			{
				return this._CH22;
			}
			private set
			{
				this._CH22 = value;
			}
		}

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x060006AF RID: 1711 RVA: 0x00020D54 File Offset: 0x0001EF54
		// (set) Token: 0x060006B0 RID: 1712 RVA: 0x0000896F File Offset: 0x00006B6F
		public ChannelInfo CH23
		{
			get
			{
				return this._CH23;
			}
			private set
			{
				this._CH23 = value;
			}
		}

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x060006B1 RID: 1713 RVA: 0x00020D6C File Offset: 0x0001EF6C
		// (set) Token: 0x060006B2 RID: 1714 RVA: 0x00008978 File Offset: 0x00006B78
		public ChannelInfo CH24
		{
			get
			{
				return this._CH24;
			}
			private set
			{
				this._CH24 = value;
			}
		}

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x060006B3 RID: 1715 RVA: 0x00020D84 File Offset: 0x0001EF84
		// (set) Token: 0x060006B4 RID: 1716 RVA: 0x00008981 File Offset: 0x00006B81
		public ChannelInfo FX01
		{
			get
			{
				return this._FX01;
			}
			private set
			{
				this._FX01 = value;
			}
		}

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x060006B5 RID: 1717 RVA: 0x00020D9C File Offset: 0x0001EF9C
		// (set) Token: 0x060006B6 RID: 1718 RVA: 0x0000898A File Offset: 0x00006B8A
		public ChannelInfo FX02
		{
			get
			{
				return this._FX02;
			}
			private set
			{
				this._FX02 = value;
			}
		}

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x060006B7 RID: 1719 RVA: 0x00020DB4 File Offset: 0x0001EFB4
		// (set) Token: 0x060006B8 RID: 1720 RVA: 0x00008993 File Offset: 0x00006B93
		public ChannelInfo Aux01
		{
			get
			{
				return this._Aux01;
			}
			private set
			{
				this._Aux01 = value;
			}
		}

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x060006B9 RID: 1721 RVA: 0x00020DCC File Offset: 0x0001EFCC
		// (set) Token: 0x060006BA RID: 1722 RVA: 0x0000899C File Offset: 0x00006B9C
		public ChannelInfo Aux02
		{
			get
			{
				return this._Aux02;
			}
			private set
			{
				this._Aux02 = value;
			}
		}

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x060006BB RID: 1723 RVA: 0x00020DE4 File Offset: 0x0001EFE4
		// (set) Token: 0x060006BC RID: 1724 RVA: 0x000089A5 File Offset: 0x00006BA5
		public ChannelInfo Aux03
		{
			get
			{
				return this._Aux03;
			}
			private set
			{
				this._Aux03 = value;
			}
		}

		// Token: 0x17000278 RID: 632
		// (get) Token: 0x060006BD RID: 1725 RVA: 0x00020DFC File Offset: 0x0001EFFC
		// (set) Token: 0x060006BE RID: 1726 RVA: 0x000089AE File Offset: 0x00006BAE
		public ChannelInfo Aux04
		{
			get
			{
				return this._Aux04;
			}
			private set
			{
				this._Aux04 = value;
			}
		}

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x060006BF RID: 1727 RVA: 0x00020E14 File Offset: 0x0001F014
		// (set) Token: 0x060006C0 RID: 1728 RVA: 0x000089B7 File Offset: 0x00006BB7
		public ChannelInfo Aux05
		{
			get
			{
				return this._Aux05;
			}
			private set
			{
				this._Aux05 = value;
			}
		}

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x060006C1 RID: 1729 RVA: 0x00020E2C File Offset: 0x0001F02C
		// (set) Token: 0x060006C2 RID: 1730 RVA: 0x000089C0 File Offset: 0x00006BC0
		public ChannelInfo Aux06
		{
			get
			{
				return this._Aux06;
			}
			private set
			{
				this._Aux06 = value;
			}
		}

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x060006C3 RID: 1731 RVA: 0x00020E44 File Offset: 0x0001F044
		// (set) Token: 0x060006C4 RID: 1732 RVA: 0x000089C9 File Offset: 0x00006BC9
		public ChannelInfo Aux07
		{
			get
			{
				return this._Aux07;
			}
			private set
			{
				this._Aux07 = value;
			}
		}

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x060006C5 RID: 1733 RVA: 0x00020E5C File Offset: 0x0001F05C
		// (set) Token: 0x060006C6 RID: 1734 RVA: 0x000089D2 File Offset: 0x00006BD2
		public ChannelInfo Aux08
		{
			get
			{
				return this._Aux08;
			}
			private set
			{
				this._Aux08 = value;
			}
		}

		// Token: 0x1700027D RID: 637
		// (get) Token: 0x060006C7 RID: 1735 RVA: 0x00020E74 File Offset: 0x0001F074
		// (set) Token: 0x060006C8 RID: 1736 RVA: 0x000089DB File Offset: 0x00006BDB
		public ChannelInfo Main
		{
			get
			{
				return this._Main;
			}
			private set
			{
				this._Main = value;
			}
		}

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x060006C9 RID: 1737 RVA: 0x00020E8C File Offset: 0x0001F08C
		// (set) Token: 0x060006CA RID: 1738 RVA: 0x000089E4 File Offset: 0x00006BE4
		public ChannelInfo Solo
		{
			get
			{
				return this._Solo;
			}
			private set
			{
				this._Solo = value;
			}
		}

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x060006CB RID: 1739 RVA: 0x00020EA4 File Offset: 0x0001F0A4
		public List<ChannelInfo> CH01_24
		{
			get
			{
				return ChannelInfo.ChannelDictionary[ChannelType.CH_01_24];
			}
		}

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x060006CC RID: 1740 RVA: 0x00020EC4 File Offset: 0x0001F0C4
		public List<ChannelInfo> FXs
		{
			get
			{
				return ChannelInfo.ChannelDictionary[ChannelType.FX];
			}
		}

		// Token: 0x17000281 RID: 641
		// (get) Token: 0x060006CD RID: 1741 RVA: 0x00020EE4 File Offset: 0x0001F0E4
		public List<ChannelInfo> Aux1_8
		{
			get
			{
				return ChannelInfo.ChannelDictionary[ChannelType.Aux];
			}
		}

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x060006CE RID: 1742 RVA: 0x000089ED File Offset: 0x00006BED
		// (set) Token: 0x060006CF RID: 1743 RVA: 0x000089F5 File Offset: 0x00006BF5
		public List<ChannelInfo> DeviceChannels { get; set; } = new List<ChannelInfo>();

		// Token: 0x060006D0 RID: 1744 RVA: 0x00020F04 File Offset: 0x0001F104
		public ChannelData()
		{
			this.InitialProperty();
			this.InitialLinkChannel();
		}

		// Token: 0x060006D1 RID: 1745 RVA: 0x00021680 File Offset: 0x0001F880
		private void InitialProperty()
		{
			this.DeviceChannels.AddRange(this.CH01_24);
			this.DeviceChannels.AddRange(this.FXs);
			this.DeviceChannels.AddRange(this.Aux1_8);
			this.DeviceChannels.Add(this.Main);
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x000216D8 File Offset: 0x0001F8D8
		private void InitialLinkChannel()
		{
			for (int i = 0; i < this.DeviceChannels.Count; i++)
			{
				ChannelInfo channelInfo = this.DeviceChannels[i];
				bool hasLink = channelInfo.HasLink;
				if (hasLink)
				{
					int num = (int)(channelInfo.ChannelIndex / 2);
					ChannelInfo channelInfo2 = this.DeviceChannels[2 * num];
					ChannelInfo channelInfo3 = this.DeviceChannels[2 * num + 1];
					channelInfo.LinkChannel = (channelInfo.Equals(channelInfo2) ? channelInfo3 : channelInfo2);
				}
			}
		}

		// Token: 0x0400039E RID: 926
		private ChannelInfo _CH01 = new ChannelInfo(ChannelType.CH_01_24)
		{
			ChannelName = "CH01",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.CH01),
			ChannelIndex = 0
		};

		// Token: 0x0400039F RID: 927
		private ChannelInfo _CH02 = new ChannelInfo(ChannelType.CH_01_24)
		{
			ChannelName = "CH02",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.CH02),
			ChannelIndex = 1
		};

		// Token: 0x040003A0 RID: 928
		private ChannelInfo _CH03 = new ChannelInfo(ChannelType.CH_01_24)
		{
			ChannelName = "CH03",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.CH03),
			ChannelIndex = 2
		};

		// Token: 0x040003A1 RID: 929
		private ChannelInfo _CH04 = new ChannelInfo(ChannelType.CH_01_24)
		{
			ChannelName = "CH04",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.CH04),
			ChannelIndex = 3
		};

		// Token: 0x040003A2 RID: 930
		private ChannelInfo _CH05 = new ChannelInfo(ChannelType.CH_01_24)
		{
			ChannelName = "CH05",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.CH05),
			ChannelIndex = 4
		};

		// Token: 0x040003A3 RID: 931
		private ChannelInfo _CH06 = new ChannelInfo(ChannelType.CH_01_24)
		{
			ChannelName = "CH06",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.CH06),
			ChannelIndex = 5
		};

		// Token: 0x040003A4 RID: 932
		private ChannelInfo _CH07 = new ChannelInfo(ChannelType.CH_01_24)
		{
			ChannelName = "CH07",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.CH07),
			ChannelIndex = 6
		};

		// Token: 0x040003A5 RID: 933
		private ChannelInfo _CH08 = new ChannelInfo(ChannelType.CH_01_24)
		{
			ChannelName = "CH08",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.CH08),
			ChannelIndex = 7
		};

		// Token: 0x040003A6 RID: 934
		private ChannelInfo _CH09 = new ChannelInfo(ChannelType.CH_01_24)
		{
			ChannelName = "CH09",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.CH09),
			ChannelIndex = 8
		};

		// Token: 0x040003A7 RID: 935
		private ChannelInfo _CH10 = new ChannelInfo(ChannelType.CH_01_24)
		{
			ChannelName = "CH10",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.CH10),
			ChannelIndex = 9
		};

		// Token: 0x040003A8 RID: 936
		private ChannelInfo _CH11 = new ChannelInfo(ChannelType.CH_01_24)
		{
			ChannelName = "CH11",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.CH11),
			ChannelIndex = 10
		};

		// Token: 0x040003A9 RID: 937
		private ChannelInfo _CH12 = new ChannelInfo(ChannelType.CH_01_24)
		{
			ChannelName = "CH12",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.CH12),
			ChannelIndex = 11
		};

		// Token: 0x040003AA RID: 938
		private ChannelInfo _CH13 = new ChannelInfo(ChannelType.CH_01_24)
		{
			ChannelName = "CH13",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.CH13),
			ChannelIndex = 12
		};

		// Token: 0x040003AB RID: 939
		private ChannelInfo _CH14 = new ChannelInfo(ChannelType.CH_01_24)
		{
			ChannelName = "CH14",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.CH14),
			ChannelIndex = 13
		};

		// Token: 0x040003AC RID: 940
		private ChannelInfo _CH15 = new ChannelInfo(ChannelType.CH_01_24)
		{
			ChannelName = "CH15",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.CH15),
			ChannelIndex = 14
		};

		// Token: 0x040003AD RID: 941
		private ChannelInfo _CH16 = new ChannelInfo(ChannelType.CH_01_24)
		{
			ChannelName = "CH16",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.CH16),
			ChannelIndex = 15
		};

		// Token: 0x040003AE RID: 942
		private ChannelInfo _CH17 = new ChannelInfo(ChannelType.CH_01_24)
		{
			ChannelName = "CH17",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.CH17),
			ChannelIndex = 16
		};

		// Token: 0x040003AF RID: 943
		private ChannelInfo _CH18 = new ChannelInfo(ChannelType.CH_01_24)
		{
			ChannelName = "CH18",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.CH18),
			ChannelIndex = 17
		};

		// Token: 0x040003B0 RID: 944
		private ChannelInfo _CH19 = new ChannelInfo(ChannelType.CH_01_24)
		{
			ChannelName = "CH19",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.CH19),
			ChannelIndex = 18
		};

		// Token: 0x040003B1 RID: 945
		private ChannelInfo _CH20 = new ChannelInfo(ChannelType.CH_01_24)
		{
			ChannelName = "CH20",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.CH20),
			ChannelIndex = 19
		};

		// Token: 0x040003B2 RID: 946
		private ChannelInfo _CH21 = new ChannelInfo(ChannelType.CH_01_24)
		{
			ChannelName = "CH21",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.CH21),
			ChannelIndex = 20
		};

		// Token: 0x040003B3 RID: 947
		private ChannelInfo _CH22 = new ChannelInfo(ChannelType.CH_01_24)
		{
			ChannelName = "CH22",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.CH22),
			ChannelIndex = 21
		};

		// Token: 0x040003B4 RID: 948
		private ChannelInfo _CH23 = new ChannelInfo(ChannelType.CH_01_24)
		{
			ChannelName = "CH23",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.CH23),
			ChannelIndex = 22
		};

		// Token: 0x040003B5 RID: 949
		private ChannelInfo _CH24 = new ChannelInfo(ChannelType.CH_01_24)
		{
			ChannelName = "CH24",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.CH24),
			ChannelIndex = 23
		};

		// Token: 0x040003B6 RID: 950
		private ChannelInfo _FX01 = new ChannelInfo(ChannelType.FX)
		{
			ChannelName = "FX1",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.FX1),
			FXEffect = FXData.FX1,
			ChannelIndex = 24
		};

		// Token: 0x040003B7 RID: 951
		private ChannelInfo _FX02 = new ChannelInfo(ChannelType.FX)
		{
			ChannelName = "FX2",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.FX2),
			FXEffect = FXData.FX2,
			ChannelIndex = 25
		};

		// Token: 0x040003B8 RID: 952
		private ChannelInfo _Aux01 = new ChannelInfo(ChannelType.Aux)
		{
			ChannelName = "Aux1",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.Aux1),
			ChannelIndex = 26
		};

		// Token: 0x040003B9 RID: 953
		private ChannelInfo _Aux02 = new ChannelInfo(ChannelType.Aux)
		{
			ChannelName = "Aux2",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.Aux2),
			ChannelIndex = 27
		};

		// Token: 0x040003BA RID: 954
		private ChannelInfo _Aux03 = new ChannelInfo(ChannelType.Aux)
		{
			ChannelName = "Aux3",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.Aux3),
			ChannelIndex = 28
		};

		// Token: 0x040003BB RID: 955
		private ChannelInfo _Aux04 = new ChannelInfo(ChannelType.Aux)
		{
			ChannelName = "Aux4",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.Aux4),
			ChannelIndex = 29
		};

		// Token: 0x040003BC RID: 956
		private ChannelInfo _Aux05 = new ChannelInfo(ChannelType.Aux)
		{
			ChannelName = "Aux5",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.Aux5),
			ChannelIndex = 30
		};

		// Token: 0x040003BD RID: 957
		private ChannelInfo _Aux06 = new ChannelInfo(ChannelType.Aux)
		{
			ChannelName = "Aux6",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.Aux6),
			ChannelIndex = 31
		};

		// Token: 0x040003BE RID: 958
		private ChannelInfo _Aux07 = new ChannelInfo(ChannelType.Aux)
		{
			ChannelName = "Aux7",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.Aux7),
			ChannelIndex = 32
		};

		// Token: 0x040003BF RID: 959
		private ChannelInfo _Aux08 = new ChannelInfo(ChannelType.Aux)
		{
			ChannelName = "Aux8",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.Aux8),
			ChannelIndex = 33
		};

		// Token: 0x040003C0 RID: 960
		private ChannelInfo _Main = new ChannelInfo(ChannelType.Main)
		{
			ChannelName = "Main",
			AuxFxItems = RouterData.RouterAdapter.GetRow(RouterTableRow.Main),
			IsMain = true,
			ChannelIndex = 34
		};

		// Token: 0x040003C1 RID: 961
		private ChannelInfo _Solo = new ChannelInfo(ChannelType.Solo)
		{
			ChannelName = "Solo",
			ChannelIndex = 35
		};

		// Token: 0x040003C2 RID: 962
		private static int s_presentChannelIndex;
	}
}
