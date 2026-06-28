using System;
using System.Collections.Generic;
using T2208.MyInformations;

namespace T2208.MyDatas
{
	// Token: 0x02000075 RID: 117
	public class RouterAdapter
	{
		// Token: 0x170002BB RID: 699
		public AuxFxItem this[RouterTableRow row, RouterTableColumn column]
		{
			get
			{
				return this.routeInfos[(int)row, (int)column];
			}
			set
			{
				this.routeInfos[(int)row, (int)column] = value;
			}
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x00023CFC File Offset: 0x00021EFC
		public AuxFxItem[] GetRow(RouterTableRow row)
		{
			List<AuxFxItem> list = new List<AuxFxItem>();
			for (int i = 0; i < this.routeInfos.GetLength(1); i++)
			{
				list.Add(this.routeInfos[(int)row, i]);
			}
			return list.ToArray();
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x00023D50 File Offset: 0x00021F50
		public AuxFxItem[] GetColumn(RouterTableColumn column)
		{
			List<AuxFxItem> list = new List<AuxFxItem>();
			for (int i = 0; i < this.routeInfos.GetLength(0); i++)
			{
				list.Add(this.routeInfos[i, (int)column]);
			}
			return list.ToArray();
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x00023DA4 File Offset: 0x00021FA4
		public RouterAdapter()
		{
			for (int i = 0; i < this.routeInfos.GetLength(0); i++)
			{
				for (int j = 0; j < this.routeInfos.GetLength(1) - 2; j++)
				{
					AuxFxItem[,] array = this.routeInfos;
					int num = i;
					int num2 = j;
					RouterTableRow routerTableRow = (RouterTableRow)i;
					string text = routerTableRow.ToString();
					RouterTableColumn routerTableColumn = (RouterTableColumn)j;
					array[num, num2] = new AuxFxItem(text, routerTableColumn.ToString(), i < 26, i, j);
				}
				for (int k = this.routeInfos.GetLength(1) - 2; k < this.routeInfos.GetLength(1); k++)
				{
					AuxFxItem[,] array2 = this.routeInfos;
					int num3 = i;
					int num4 = k;
					RouterTableRow routerTableRow = (RouterTableRow)i;
					string text2 = routerTableRow.ToString();
					RouterTableColumn routerTableColumn = (RouterTableColumn)k;
					array2[num3, num4] = new AuxFxItem(text2, routerTableColumn.ToString(), i < 24, i, k);
				}
			}
		}

		// Token: 0x04000408 RID: 1032
		private AuxFxItem[,] routeInfos = new AuxFxItem[36, 10];
	}
}
