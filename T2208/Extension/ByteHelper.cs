using System;
using System.Linq;
using System.Text;

namespace T2208.Extension
{
	// Token: 0x020000A7 RID: 167
	public static class ByteHelper
	{
		// Token: 0x0600086A RID: 2154 RVA: 0x0002611C File Offset: 0x0002431C
		public static byte[] IntsToBytes(params int[] intArray)
		{
			return intArray.Select<int, byte>((int i) => (byte)i).ToArray<byte>();
		}

		// Token: 0x0600086B RID: 2155 RVA: 0x00026158 File Offset: 0x00024358
		public static string BytesToString(this byte[] data, int length = 16)
		{
			byte[] array = new byte[length];
			length = ((data.Length < length) ? data.Length : length);
			Array.Copy(data, array, length);
			Convert.ToString(array);
			return Encoding.ASCII.GetString(array).Replace('\0', ' ').Trim();
		}

		// Token: 0x0600086C RID: 2156 RVA: 0x00026158 File Offset: 0x00024358
		public static string BytesToString_CH(this byte[] data, int length = 8)
		{
			byte[] array = new byte[length];
			length = ((data.Length < length) ? data.Length : length);
			Array.Copy(data, array, length);
			Convert.ToString(array);
			return Encoding.ASCII.GetString(array).Replace('\0', ' ').Trim();
		}

		// Token: 0x0600086D RID: 2157 RVA: 0x000261A8 File Offset: 0x000243A8
		public static string BytesToString(this byte[] data, int startIndex, int length = 16)
		{
			bool flag = startIndex > data.Length - 1;
			if (flag)
			{
				throw new RankException();
			}
			bool flag2 = length <= 0;
			if (flag2)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			byte[] array = new byte[length];
			int num = data.Length - startIndex;
			length = ((num < length) ? num : length);
			Array.Copy(data, startIndex, array, 0, length);
			return Encoding.Default.GetString(array).Replace('\0', ' ').Trim();
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x00026220 File Offset: 0x00024420
		public static string BytesToString_V2(this byte[] obj, int startIndex, int length = 16)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < length; i++)
			{
				bool flag = obj[startIndex] > 0;
				if (flag)
				{
					stringBuilder.Append((char)obj[startIndex++]);
				}
				else
				{
					stringBuilder.Append(' ');
					startIndex++;
				}
			}
			return stringBuilder.ToString().Trim();
		}
	}
}
