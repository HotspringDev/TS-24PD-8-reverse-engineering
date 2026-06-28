using System;

namespace T2208.Models
{
	// Token: 0x020000A6 RID: 166
	public static class MainData
	{
		// Token: 0x1700030B RID: 779
		// (get) Token: 0x06000865 RID: 2149 RVA: 0x00009C79 File Offset: 0x00007E79
		// (set) Token: 0x06000866 RID: 2150 RVA: 0x00009C80 File Offset: 0x00007E80
		public static ConnectionModel ConnectionModel { get; private set; } = new ConnectionModel();

		// Token: 0x1700030C RID: 780
		// (get) Token: 0x06000867 RID: 2151 RVA: 0x00009C88 File Offset: 0x00007E88
		// (set) Token: 0x06000868 RID: 2152 RVA: 0x00009C8F File Offset: 0x00007E8F
		public static ActionManager ActionManager { get; private set; } = new ActionManager();
	}
}
