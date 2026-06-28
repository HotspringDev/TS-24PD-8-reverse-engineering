using System;

namespace T2208.Models
{
	// Token: 0x0200009D RID: 157
	public class ModelInstance
	{
		// Token: 0x06000839 RID: 2105 RVA: 0x00024944 File Offset: 0x00022B44
		public static ModelInstance GetVmInstance()
		{
			return ModelInstance.Instance;
		}

		// Token: 0x04000488 RID: 1160
		private static readonly ModelInstance Instance = new ModelInstance();
	}
}
