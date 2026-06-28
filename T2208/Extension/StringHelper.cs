using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace T2208.Extension
{
	// Token: 0x020000AA RID: 170
	public static class StringHelper
	{
		// Token: 0x06000875 RID: 2165 RVA: 0x000262A8 File Offset: 0x000244A8
		public static string RemoveNumber(this string key)
		{
			return Regex.Replace(key, "\\d", string.Empty);
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x000262CC File Offset: 0x000244CC
		public static string RemoveNotNumber(this string key)
		{
			string text = Regex.Replace(key, "[^\\d]*", string.Empty);
			return string.IsNullOrEmpty(text) ? key : text;
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x000262FC File Offset: 0x000244FC
		public static byte[] StringToBytes(this string key, int length = 16)
		{
			bool flag = key == null;
			if (flag)
			{
				key = string.Empty;
			}
			byte[] bytes = Encoding.Default.GetBytes(key);
			byte[] array = new byte[length];
			length = ((bytes.Length < length) ? bytes.Length : length);
			Array.Copy(bytes, array, length);
			return array;
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x00026348 File Offset: 0x00024548
		public static byte[] StringToBytesWithReplace(this string key, int length = 16, byte element = 32)
		{
			bool flag = key == null;
			if (flag)
			{
				key = string.Empty;
			}
			byte[] bytes = Encoding.Default.GetBytes(key);
			byte[] array = Enumerable.Repeat<byte>(element, length).ToArray<byte>();
			length = ((bytes.Length < length) ? bytes.Length : length);
			Array.Copy(bytes, array, length);
			return array;
		}
	}
}
