using System;
using T2208.MyInformations;

namespace T2208.MyDatas
{
	// Token: 0x02000071 RID: 113
	public class SceneData
	{
		// Token: 0x170002B2 RID: 690
		// (get) Token: 0x0600073A RID: 1850 RVA: 0x00008D11 File Offset: 0x00006F11
		// (set) Token: 0x0600073B RID: 1851 RVA: 0x00008D18 File Offset: 0x00006F18
		public static SceneInfo SceneInfo { get; set; } = new SceneInfo();

		// Token: 0x0600073C RID: 1852 RVA: 0x00023A4C File Offset: 0x00021C4C
		static SceneData()
		{
			SceneData.SceneInfo.Channels.AddRange(ChannelData.ChannelDatas.DeviceChannels);
			SceneData.SceneInfo.Solo = ChannelData.ChannelDatas.Solo;
			SceneData.SceneInfo.GEQs.AddRange(GEQData.GEQDatas.GEQs);
			SceneData.SceneInfo.FXs.AddRange(FXData.FXs);
			SceneData.SceneInfo.DCAs.AddRange(DCAData.DCAs);
		}
	}
}
