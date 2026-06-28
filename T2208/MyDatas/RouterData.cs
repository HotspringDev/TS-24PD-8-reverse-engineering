using System;

namespace T2208.MyDatas
{
	// Token: 0x02000074 RID: 116
	public class RouterData
	{
		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x0600074E RID: 1870 RVA: 0x00008D9D File Offset: 0x00006F9D
		// (set) Token: 0x0600074F RID: 1871 RVA: 0x00008DA4 File Offset: 0x00006FA4
		public static RouterAdapter RouterAdapter { get; set; } = new RouterAdapter();

		// Token: 0x170002BA RID: 698
		// (get) Token: 0x06000750 RID: 1872 RVA: 0x00008DAC File Offset: 0x00006FAC
		// (set) Token: 0x06000751 RID: 1873 RVA: 0x00008DB3 File Offset: 0x00006FB3
		public static byte SelectedRouteDeviceIndex { get; set; }
	}
}
