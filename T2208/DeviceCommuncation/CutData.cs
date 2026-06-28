using System;
using System.Collections.Generic;
using System.Linq;

namespace T2208.DeviceCommuncation
{
	// Token: 0x020000B4 RID: 180
	public class CutData
	{
		// Token: 0x060008ED RID: 2285 RVA: 0x00026C60 File Offset: 0x00024E60
		public CutData(int count, int length)
		{
			this._maxCount = count;
			this._length = length;
			this._packageList = new List<byte>[count];
			for (int i = 0; i < count; i++)
			{
				this._packageList[i] = new List<byte>();
			}
			this._checkData = new byte[count];
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x00026CB8 File Offset: 0x00024EB8
		public List<byte> Add(List<byte> data, int index, int validPackageLength)
		{
			bool flag = index == 0;
			if (flag)
			{
				this.Clear();
			}
			bool flag2 = this._checkData[index] == 0;
			if (flag2)
			{
				this._checkData[index] = 1;
				data.RemoveRange(0, 25);
				int num = data.Count - validPackageLength;
				data.RemoveRange(validPackageLength, num);
				this._packageList[index].Clear();
				this._packageList[index].AddRange(data);
				bool flag3 = this._maxCount == this._checkData.Sum<byte>((byte i) => (int)i);
				if (flag3)
				{
					Array.Clear(this._checkData, 0, this._checkData.Length);
					List<byte> list = new List<byte>();
					foreach (List<byte> list2 in this._packageList)
					{
						list.AddRange(list2);
					}
					return list;
				}
			}
			return null;
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x00026DB8 File Offset: 0x00024FB8
		public void Clear()
		{
			for (int i = 0; i < this._maxCount; i++)
			{
				this._packageList[i].Clear();
			}
			Array.Clear(this._checkData, 0, this._checkData.Length);
		}

		// Token: 0x040004BB RID: 1211
		private readonly byte[] _checkData;

		// Token: 0x040004BC RID: 1212
		private readonly int _maxCount;

		// Token: 0x040004BD RID: 1213
		private readonly int _length;

		// Token: 0x040004BE RID: 1214
		private readonly List<byte>[] _packageList;
	}
}
