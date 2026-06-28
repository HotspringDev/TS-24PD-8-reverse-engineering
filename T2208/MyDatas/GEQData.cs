using System;
using System.Collections.Generic;
using JayLib;
using T2208.MyInformations;

namespace T2208.MyDatas
{
	// Token: 0x02000070 RID: 112
	public class GEQData
	{
		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x06000718 RID: 1816 RVA: 0x00008BE0 File Offset: 0x00006DE0
		// (set) Token: 0x06000719 RID: 1817 RVA: 0x00008BE7 File Offset: 0x00006DE7
		public static Dictionary<byte, byte> DeviceGEQAuxToChannelAuxDictionary { get; private set; } = new Dictionary<byte, byte>();

		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x0600071A RID: 1818 RVA: 0x000237C4 File Offset: 0x000219C4
		public static GEQData GEQDatas
		{
			get
			{
				return SingleTon<GEQData>.GetInstance();
			}
		}

		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x0600071B RID: 1819 RVA: 0x00008BEF File Offset: 0x00006DEF
		// (set) Token: 0x0600071C RID: 1820 RVA: 0x00008BF6 File Offset: 0x00006DF6
		public static byte PresentGEQIndex { get; set; }

		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x0600071D RID: 1821 RVA: 0x00008BFE File Offset: 0x00006DFE
		// (set) Token: 0x0600071E RID: 1822 RVA: 0x00008C05 File Offset: 0x00006E05
		public static byte[] GEQIndexDeviceToPage { get; private set; } = new byte[] { 0, 8, 4, 5, 6, 7, 0, 1, 2, 3 };

		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x0600071F RID: 1823 RVA: 0x00008C0D File Offset: 0x00006E0D
		// (set) Token: 0x06000720 RID: 1824 RVA: 0x00008C14 File Offset: 0x00006E14
		public static byte[] GEQIndexPageToDevice { get; private set; } = new byte[] { 6, 7, 8, 9, 2, 3, 4, 5, 1 };

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x06000721 RID: 1825 RVA: 0x00008C1C File Offset: 0x00006E1C
		// (set) Token: 0x06000722 RID: 1826 RVA: 0x00008C24 File Offset: 0x00006E24
		public GEQInfo Aux1
		{
			get
			{
				return this.aux1;
			}
			set
			{
				this.aux1 = value;
			}
		}

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x06000723 RID: 1827 RVA: 0x00008C2D File Offset: 0x00006E2D
		// (set) Token: 0x06000724 RID: 1828 RVA: 0x00008C35 File Offset: 0x00006E35
		public GEQInfo Aux2
		{
			get
			{
				return this.aux2;
			}
			set
			{
				this.aux2 = value;
			}
		}

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x06000725 RID: 1829 RVA: 0x00008C3E File Offset: 0x00006E3E
		// (set) Token: 0x06000726 RID: 1830 RVA: 0x00008C46 File Offset: 0x00006E46
		public GEQInfo Aux3
		{
			get
			{
				return this.aux3;
			}
			set
			{
				this.aux3 = value;
			}
		}

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x06000727 RID: 1831 RVA: 0x00008C4F File Offset: 0x00006E4F
		// (set) Token: 0x06000728 RID: 1832 RVA: 0x00008C57 File Offset: 0x00006E57
		public GEQInfo Aux4
		{
			get
			{
				return this.aux4;
			}
			set
			{
				this.aux4 = value;
			}
		}

		// Token: 0x170002AB RID: 683
		// (get) Token: 0x06000729 RID: 1833 RVA: 0x00008C60 File Offset: 0x00006E60
		// (set) Token: 0x0600072A RID: 1834 RVA: 0x00008C68 File Offset: 0x00006E68
		public GEQInfo Aux5
		{
			get
			{
				return this.aux5;
			}
			set
			{
				this.aux5 = value;
			}
		}

		// Token: 0x170002AC RID: 684
		// (get) Token: 0x0600072B RID: 1835 RVA: 0x00008C71 File Offset: 0x00006E71
		// (set) Token: 0x0600072C RID: 1836 RVA: 0x00008C79 File Offset: 0x00006E79
		public GEQInfo Aux6
		{
			get
			{
				return this.aux6;
			}
			set
			{
				this.aux6 = value;
			}
		}

		// Token: 0x170002AD RID: 685
		// (get) Token: 0x0600072D RID: 1837 RVA: 0x00008C82 File Offset: 0x00006E82
		// (set) Token: 0x0600072E RID: 1838 RVA: 0x00008C8A File Offset: 0x00006E8A
		public GEQInfo Aux7
		{
			get
			{
				return this.aux7;
			}
			set
			{
				this.aux7 = value;
			}
		}

		// Token: 0x170002AE RID: 686
		// (get) Token: 0x0600072F RID: 1839 RVA: 0x00008C93 File Offset: 0x00006E93
		// (set) Token: 0x06000730 RID: 1840 RVA: 0x00008C9B File Offset: 0x00006E9B
		public GEQInfo Aux8
		{
			get
			{
				return this.aux8;
			}
			set
			{
				this.aux8 = value;
			}
		}

		// Token: 0x170002AF RID: 687
		// (get) Token: 0x06000731 RID: 1841 RVA: 0x00008CA4 File Offset: 0x00006EA4
		// (set) Token: 0x06000732 RID: 1842 RVA: 0x00008CAC File Offset: 0x00006EAC
		public GEQInfo Main
		{
			get
			{
				return this.main;
			}
			set
			{
				this.main = value;
			}
		}

		// Token: 0x170002B0 RID: 688
		// (get) Token: 0x06000733 RID: 1843 RVA: 0x00008CB5 File Offset: 0x00006EB5
		// (set) Token: 0x06000734 RID: 1844 RVA: 0x00008CBD File Offset: 0x00006EBD
		public Dictionary<string, GEQInfo> GEQInfoDictionary
		{
			get
			{
				return this._GEQInfoDictionary;
			}
			set
			{
				this._GEQInfoDictionary = value;
			}
		}

		// Token: 0x170002B1 RID: 689
		// (get) Token: 0x06000735 RID: 1845 RVA: 0x00008CC6 File Offset: 0x00006EC6
		// (set) Token: 0x06000736 RID: 1846 RVA: 0x00008CCE File Offset: 0x00006ECE
		public List<GEQInfo> GEQs { get; set; } = new List<GEQInfo>();

		// Token: 0x06000737 RID: 1847 RVA: 0x000237DC File Offset: 0x000219DC
		public GEQData()
		{
			this.InitializeListAndDictionary(this.Aux1);
			this.InitializeListAndDictionary(this.Aux2);
			this.InitializeListAndDictionary(this.Aux3);
			this.InitializeListAndDictionary(this.Aux4);
			this.InitializeListAndDictionary(this.Aux5);
			this.InitializeListAndDictionary(this.Aux6);
			this.InitializeListAndDictionary(this.Aux7);
			this.InitializeListAndDictionary(this.Aux8);
			this.InitializeListAndDictionary(this.Main);
			GEQData.DeviceGEQAuxToChannelAuxDictionary[6] = 17;
			GEQData.DeviceGEQAuxToChannelAuxDictionary[7] = 18;
			GEQData.DeviceGEQAuxToChannelAuxDictionary[8] = 19;
			GEQData.DeviceGEQAuxToChannelAuxDictionary[9] = 20;
			GEQData.DeviceGEQAuxToChannelAuxDictionary[2] = 21;
			GEQData.DeviceGEQAuxToChannelAuxDictionary[3] = 22;
			GEQData.DeviceGEQAuxToChannelAuxDictionary[4] = 23;
			GEQData.DeviceGEQAuxToChannelAuxDictionary[5] = 24;
			GEQData.DeviceGEQAuxToChannelAuxDictionary[1] = 30;
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x00023A14 File Offset: 0x00021C14
		private void InitializeListAndDictionary(GEQInfo geqInfo)
		{
			this.GEQInfoDictionary.Add(geqInfo.Index.ToString(), geqInfo);
			this.GEQs.Add(geqInfo);
		}

		// Token: 0x040003E3 RID: 995
		private GEQInfo aux1 = new GEQInfo
		{
			ChannnelName = "Aux1",
			Index = 0
		};

		// Token: 0x040003E4 RID: 996
		private GEQInfo aux2 = new GEQInfo
		{
			ChannnelName = "Aux2",
			Index = 1
		};

		// Token: 0x040003E5 RID: 997
		private GEQInfo aux3 = new GEQInfo
		{
			ChannnelName = "Aux3",
			Index = 2
		};

		// Token: 0x040003E6 RID: 998
		private GEQInfo aux4 = new GEQInfo
		{
			ChannnelName = "Aux4",
			Index = 3
		};

		// Token: 0x040003E7 RID: 999
		private GEQInfo aux5 = new GEQInfo
		{
			ChannnelName = "Aux5",
			Index = 4
		};

		// Token: 0x040003E8 RID: 1000
		private GEQInfo aux6 = new GEQInfo
		{
			ChannnelName = "Aux6",
			Index = 5
		};

		// Token: 0x040003E9 RID: 1001
		private GEQInfo aux7 = new GEQInfo
		{
			ChannnelName = "Aux7",
			Index = 6
		};

		// Token: 0x040003EA RID: 1002
		private GEQInfo aux8 = new GEQInfo
		{
			ChannnelName = "Aux8",
			Index = 7
		};

		// Token: 0x040003EB RID: 1003
		private GEQInfo main = new GEQInfo
		{
			ChannnelName = "Main",
			Index = 8
		};

		// Token: 0x040003EC RID: 1004
		private Dictionary<string, GEQInfo> _GEQInfoDictionary = new Dictionary<string, GEQInfo>();
	}
}
