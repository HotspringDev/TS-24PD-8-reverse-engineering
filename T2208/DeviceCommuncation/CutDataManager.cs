using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace T2208.DeviceCommuncation
{
	// Token: 0x020000B3 RID: 179
	public static class CutDataManager
	{
		// Token: 0x060008EA RID: 2282 RVA: 0x00026AE0 File Offset: 0x00024CE0
		public static List<byte> AddPackage(List<byte> package, string ip)
		{
			Debug.WriteLine(BitConverter.ToString(package.ToArray()));
			int num = (int)package[9] * 256 + (int)package[10];
			int num2 = (int)package[5] * 256 + (int)package[6];
			int num3 = (int)package[15];
			int num4 = (int)package[16];
			int num5 = (int)package[13] * 256 + (int)package[14];
			int num6 = (int)package[11] * 256 + (int)package[12];
			Debug.WriteLine("CutDataManager CMD:" + num);
			Debug.WriteLine("CutDataManager count:" + num3);
			Dictionary<int, Dictionary<int, CutData>> dictionary;
			bool flag = !CutDataManager.DataManagerSource.TryGetValue(ip, out dictionary);
			if (flag)
			{
				CutDataManager.DataManagerSource.Add(ip, new Dictionary<int, Dictionary<int, CutData>>());
			}
			Dictionary<int, CutData> dictionary2;
			bool flag2 = !CutDataManager.DataManagerSource[ip].TryGetValue(num2, out dictionary2);
			if (flag2)
			{
				CutDataManager.DataManagerSource[ip].Add(num2, new Dictionary<int, CutData>());
			}
			CutData cutData;
			bool flag3 = !CutDataManager.DataManagerSource[ip][num2].TryGetValue(num, out cutData);
			if (flag3)
			{
				CutDataManager.DataManagerSource[ip][num2].Add(num, new CutData(num3, num6));
			}
			return CutDataManager.DataManagerSource[ip][num2][num].Add(package, num4, num5);
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x00003B79 File Offset: 0x00001D79
		public static void ClearCMD_Data(int cmd)
		{
		}

		// Token: 0x040004BA RID: 1210
		private static readonly Dictionary<string, Dictionary<int, Dictionary<int, CutData>>> DataManagerSource = new Dictionary<string, Dictionary<int, Dictionary<int, CutData>>>();
	}
}
