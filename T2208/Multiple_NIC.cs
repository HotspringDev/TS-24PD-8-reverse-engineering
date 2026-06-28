using System;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace T2208
{
	// Token: 0x0200000A RID: 10
	public class Multiple_NIC
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000030 RID: 48 RVA: 0x000038BB File Offset: 0x00001ABB
		// (set) Token: 0x06000031 RID: 49 RVA: 0x000038C2 File Offset: 0x00001AC2
		public static Collection<Multiple_NIC.Multiple_NIC_Info> Multiple_NIC_collection { get; set; }

		// Token: 0x06000032 RID: 50 RVA: 0x000038CA File Offset: 0x00001ACA
		public Multiple_NIC()
		{
			this.NIC_Info_Collect();
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000038E6 File Offset: 0x00001AE6
		public static void Share_Multiple_NIC()
		{
			Multiple_NIC.multiple_NIC = new Multiple_NIC();
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000038F3 File Offset: 0x00001AF3
		public void refresh()
		{
			this.NIC_Info_Collect();
		}

		// Token: 0x06000035 RID: 53 RVA: 0x0000AA24 File Offset: 0x00008C24
		private bool EXCheck(Collection<Multiple_NIC.Multiple_NIC_Info> multiple_NIC_collection, Multiple_NIC.Multiple_NIC_Info multiple_NIC_Info)
		{
			foreach (Multiple_NIC.Multiple_NIC_Info multiple_NIC_Info2 in multiple_NIC_collection)
			{
				bool flag = multiple_NIC_Info2.NIC_IP1 == multiple_NIC_Info.NIC_IP1;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x0000AA8C File Offset: 0x00008C8C
		private void NIC_Info_Collect()
		{
			this.nics = NetworkInterface.GetAllNetworkInterfaces();
			Multiple_NIC.Multiple_NIC_collection = new Collection<Multiple_NIC.Multiple_NIC_Info>();
			foreach (NetworkInterface networkInterface in this.nics)
			{
				bool flag = networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || networkInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet;
				if (flag)
				{
					bool flag2 = networkInterface.OperationalStatus == OperationalStatus.Up;
					if (flag2)
					{
						IPInterfaceProperties ipproperties = networkInterface.GetIPProperties();
						UnicastIPAddressInformationCollection unicastAddresses = ipproperties.UnicastAddresses;
						foreach (UnicastIPAddressInformation unicastIPAddressInformation in unicastAddresses)
						{
							bool flag3 = unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork;
							if (flag3)
							{
								this.multiple_NIC_Info = new Multiple_NIC.Multiple_NIC_Info();
								this.multiple_NIC_Info.NIC_IP1 = unicastIPAddressInformation.Address.ToString();
								this.multiple_NIC_Info.NIC_Name1 = networkInterface.Name;
								this.multiple_NIC_Info.NIC_MAC1 = networkInterface.GetPhysicalAddress().ToString();
								bool flag4 = networkInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet;
								if (flag4)
								{
									this.multiple_NIC_Info.NIC_Type1 = "Ethernet";
								}
								else
								{
									bool flag5 = networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211;
									if (flag5)
									{
										this.multiple_NIC_Info.NIC_Type1 = "Wireless80211";
									}
									else
									{
										this.multiple_NIC_Info.NIC_Type1 = "Unknow";
									}
								}
								Multiple_NIC.Multiple_NIC_collection.Add(this.multiple_NIC_Info);
							}
						}
					}
				}
			}
		}

		// Token: 0x04000017 RID: 23
		private Collection<Multiple_NIC.Multiple_NIC_Info> multiple_NIC_collection = new Collection<Multiple_NIC.Multiple_NIC_Info>();

		// Token: 0x04000018 RID: 24
		public static Multiple_NIC multiple_NIC;

		// Token: 0x04000019 RID: 25
		public Multiple_NIC.Multiple_NIC_Info multiple_NIC_Info;

		// Token: 0x0400001A RID: 26
		private NetworkInterface[] nics;

		// Token: 0x0200000B RID: 11
		public class Multiple_NIC_Info
		{
			// Token: 0x17000011 RID: 17
			// (get) Token: 0x06000037 RID: 55 RVA: 0x000038FD File Offset: 0x00001AFD
			// (set) Token: 0x06000038 RID: 56 RVA: 0x00003905 File Offset: 0x00001B05
			public string NIC_IP1 { get; set; }

			// Token: 0x17000012 RID: 18
			// (get) Token: 0x06000039 RID: 57 RVA: 0x0000390E File Offset: 0x00001B0E
			// (set) Token: 0x0600003A RID: 58 RVA: 0x00003916 File Offset: 0x00001B16
			public string NIC_Name1 { get; set; }

			// Token: 0x17000013 RID: 19
			// (get) Token: 0x0600003B RID: 59 RVA: 0x0000391F File Offset: 0x00001B1F
			// (set) Token: 0x0600003C RID: 60 RVA: 0x00003927 File Offset: 0x00001B27
			public string NIC_Type1 { get; set; }

			// Token: 0x17000014 RID: 20
			// (get) Token: 0x0600003D RID: 61 RVA: 0x00003930 File Offset: 0x00001B30
			// (set) Token: 0x0600003E RID: 62 RVA: 0x00003938 File Offset: 0x00001B38
			public string NIC_MAC1 { get; set; }
		}
	}
}
