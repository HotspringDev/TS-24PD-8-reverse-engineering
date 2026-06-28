using System;
using System.Collections.Generic;
using System.Timers;

namespace T2208.DeviceCommuncation
{
	// Token: 0x020000B6 RID: 182
	public static class DownStream
	{
		// Token: 0x17000367 RID: 871
		// (get) Token: 0x060008F3 RID: 2291 RVA: 0x00009E22 File Offset: 0x00008022
		// (set) Token: 0x060008F4 RID: 2292 RVA: 0x00009E29 File Offset: 0x00008029
		public static Action<byte[]> HighFrequencyAction { get; set; }

		// Token: 0x060008F5 RID: 2293 RVA: 0x00009E31 File Offset: 0x00008031
		static DownStream()
		{
			DownStream._HighFrequencyTransmissionTimer.Elapsed += DownStream._HighFrequencyTransmissionTimer_Elapsed;
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x00026E00 File Offset: 0x00025000
		public static void StartTimer()
		{
			bool flag = !DownStream._HighFrequencyTransmissionTimer.Enabled;
			if (flag)
			{
				DownStream._HighFrequencyTransmissionTimer.Start();
			}
		}

		// Token: 0x060008F7 RID: 2295 RVA: 0x00026E2C File Offset: 0x0002502C
		public static void StopTimer()
		{
			bool enabled = DownStream._HighFrequencyTransmissionTimer.Enabled;
			if (enabled)
			{
				DownStream._HighFrequencyTransmissionTimer.Stop();
			}
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x00026E58 File Offset: 0x00025058
		private static void _HighFrequencyTransmissionTimer_Elapsed(object sender, ElapsedEventArgs e)
		{
			Dictionary<byte, Stack<byte[]>> highFrequencyStackDictionary = DownStream._HighFrequencyStackDictionary;
			lock (highFrequencyStackDictionary)
			{
				foreach (Stack<byte[]> stack in DownStream._HighFrequencyStackDictionary.Values)
				{
					bool flag2 = stack.Count != 0;
					if (flag2)
					{
						byte[] array = stack.Pop();
						Action<byte[]> highFrequencyAction = DownStream.HighFrequencyAction;
						if (highFrequencyAction != null)
						{
							highFrequencyAction(array);
						}
						stack.Clear();
					}
					else
					{
						DownStream._StopCount++;
						bool flag3 = DownStream._StopCount > 3;
						if (flag3)
						{
							DownStream._HighFrequencyTransmissionTimer.Stop();
						}
					}
				}
			}
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x00026F38 File Offset: 0x00025138
		public static void PushData(byte dataType, byte[] data)
		{
			Dictionary<byte, Stack<byte[]>> highFrequencyStackDictionary = DownStream._HighFrequencyStackDictionary;
			lock (highFrequencyStackDictionary)
			{
				Stack<byte[]> stack;
				bool flag2 = DownStream._HighFrequencyStackDictionary.TryGetValue(dataType, out stack);
				if (flag2)
				{
					stack.Push(data);
				}
				else
				{
					DownStream._HighFrequencyStackDictionary[dataType] = new Stack<byte[]>();
					DownStream._HighFrequencyStackDictionary[dataType].Push(data);
				}
			}
		}

		// Token: 0x040004C1 RID: 1217
		private static int _StopCount;

		// Token: 0x040004C2 RID: 1218
		private static Timer _HighFrequencyTransmissionTimer = new Timer(50.0);

		// Token: 0x040004C3 RID: 1219
		private static Dictionary<byte, Stack<byte[]>> _HighFrequencyStackDictionary = new Dictionary<byte, Stack<byte[]>>();
	}
}
