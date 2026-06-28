using System;
using System.Collections.Generic;
using T2208.DeviceCommuncation;
using T2208.Models;

namespace T2208.MyDatas
{
	// Token: 0x02000072 RID: 114
	public static class PageData
	{
		// Token: 0x170002B3 RID: 691
		// (get) Token: 0x0600073E RID: 1854 RVA: 0x00008D20 File Offset: 0x00006F20
		// (set) Token: 0x0600073F RID: 1855 RVA: 0x00008D27 File Offset: 0x00006F27
		public static PageType PresentPageType { get; set; }

		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x06000740 RID: 1856 RVA: 0x00008D2F File Offset: 0x00006F2F
		// (set) Token: 0x06000741 RID: 1857 RVA: 0x00008D36 File Offset: 0x00006F36
		public static byte UiIndex1 { get; set; }

		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x06000742 RID: 1858 RVA: 0x00008D3E File Offset: 0x00006F3E
		// (set) Token: 0x06000743 RID: 1859 RVA: 0x00008D45 File Offset: 0x00006F45
		public static byte UiIndex2 { get; set; }

		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x06000744 RID: 1860 RVA: 0x00008D4D File Offset: 0x00006F4D
		// (set) Token: 0x06000745 RID: 1861 RVA: 0x00008D54 File Offset: 0x00006F54
		public static byte UiIndex3 { get; set; }

		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x06000746 RID: 1862 RVA: 0x00008D5C File Offset: 0x00006F5C
		// (set) Token: 0x06000747 RID: 1863 RVA: 0x00008D63 File Offset: 0x00006F63
		public static byte UiIndex4 { get; set; }

		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x06000748 RID: 1864 RVA: 0x00008D6B File Offset: 0x00006F6B
		// (set) Token: 0x06000749 RID: 1865 RVA: 0x00008D72 File Offset: 0x00006F72
		public static Dictionary<byte, byte[]> PageIndexDictionary { get; private set; } = new Dictionary<byte, byte[]>();

		// Token: 0x0600074A RID: 1866 RVA: 0x00023AD8 File Offset: 0x00021CD8
		static PageData()
		{
			PageData.InitializePageIndexDictionary(CommandConst.DEVE_PAGE_HOME);
			PageData.InitializePageIndexDictionary(CommandConst.DEVE_PAGE_MIXER);
			PageData.InitializePageIndexDictionary(CommandConst.DEVE_PAGE_ASSIGN);
			PageData.InitializePageIndexDictionary(CommandConst.DEVE_PAGE_GATE);
			PageData.InitializePageIndexDictionary(CommandConst.DEVE_PAGE_CHANNEL);
			PageData.InitializePageIndexDictionary(CommandConst.DEVE_PAGE_EQUALIZER);
			PageData.InitializePageIndexDictionary(CommandConst.DEVE_PAGE_GEQ);
			PageData.InitializePageIndexDictionary(CommandConst.DEVE_PAGE_DFX);
			PageData.InitializePageIndexDictionary(CommandConst.DEVE_PAGE_SYSTEM);
			PageData.InitializePageIndexDictionary(CommandConst.DEVE_PAGE_DIGITAL);
			PageData.InitializePageIndexDictionary(CommandConst.DEVE_PAGE_COPY);
			PageData.InitializePageIndexDictionary(CommandConst.DEVE_PAGE_ROUTE);
			PageData.InitializePageIndexDictionary(CommandConst.DEVE_PAGE_GROUP);
			PageData.InitializePageIndexDictionary(CommandConst.DEVE_PAGE_LOADSAVE);
			PageData.InitializePageIndexDictionary(CommandConst.DEVE_PAGE_KeyBoard);
			PageData.InitializePageIndexDictionary(CommandConst.DEVE_PAGE_VIEW_ALL_LIM_SIG);
			PageData.InitializePageIndexDictionary(CommandConst.DEVE_PAGE_DC48VPower);
			PageData.InitializePageIndexDictionary(CommandConst.DEVE_PAGE_StartUP);
			PageData.InitializePageIndexDictionary(CommandConst.DEVE_PAGE_DCA_LONGFADER);
			PageData.InitializePageIndexDictionary(CommandConst.DEVE_PAGE_COMP);
			PageData.InitializePageIndexDictionary(CommandConst.DEVE_PAGE_InstallMatrix);
			PageData.InitializePageIndexDictionary(CommandConst.DEVE_PAGE_AutoMix);
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_SyncCommand), new Action<byte[]>(PageData.SychronizeUiIndexExecute));
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x00023C14 File Offset: 0x00021E14
		private static void SychronizeUiIndexExecute(byte[] obj)
		{
			PageData.SaveUiIndex(new byte[]
			{
				obj[10],
				obj[11],
				obj[12],
				obj[13]
			});
			PageData.UiIndex1 = obj[10];
			PageData.UiIndex2 = obj[11];
			PageData.UiIndex3 = obj[12];
			PageData.UiIndex4 = obj[13];
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x00008D7A File Offset: 0x00006F7A
		private static void InitializePageIndexDictionary(byte pageIndex)
		{
			PageData.PageIndexDictionary[pageIndex] = new byte[4];
			PageData.PageIndexDictionary[pageIndex][0] = pageIndex;
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x00023C74 File Offset: 0x00021E74
		private static void SaveUiIndex(params byte[] bytes)
		{
			byte b = bytes[0];
			bool flag = bytes.Length != 0 && PageData.PageIndexDictionary.ContainsKey(b);
			if (flag)
			{
				byte[] array = PageData.PageIndexDictionary[b];
				int num = 0;
				while (num < array.Length && num < bytes.Length)
				{
					PageData.PageIndexDictionary[b][num] = bytes[num];
					num++;
				}
			}
		}
	}
}
