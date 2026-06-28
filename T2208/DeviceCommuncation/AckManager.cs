using System;

namespace T2208.DeviceCommuncation
{
	// Token: 0x020000B0 RID: 176
	public static class AckManager
	{
		// Token: 0x0600088F RID: 2191 RVA: 0x00009DAF File Offset: 0x00007FAF
		public static void Clean()
		{
			AckManager._ackIndex = 0;
			AckManager._maxAck = 5;
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x0002663C File Offset: 0x0002483C
		public static bool Check()
		{
			return AckManager._ackIndex++ > AckManager._maxAck;
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x00009DBE File Offset: 0x00007FBE
		public static void SetMaxAck(int maxAck = 20)
		{
			AckManager._maxAck = maxAck;
		}

		// Token: 0x040004B2 RID: 1202
		private static int _ackIndex = 0;

		// Token: 0x040004B3 RID: 1203
		private const int DefaultAck = 5;

		// Token: 0x040004B4 RID: 1204
		private static int _maxAck = 5;
	}
}
