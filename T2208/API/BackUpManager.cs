using System;

namespace T2208.API
{
	// Token: 0x020000BC RID: 188
	internal static class BackUpManager
	{
		// Token: 0x0600098E RID: 2446 RVA: 0x0000A17F File Offset: 0x0000837F
		public static void SetLink(bool isLink)
		{
			BackUpManager._isLink = isLink;
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x0002AAF0 File Offset: 0x00028CF0
		public static bool GetLink()
		{
			return BackUpManager._isLink;
		}

		// Token: 0x040004D5 RID: 1237
		private static bool _isLink;
	}
}
