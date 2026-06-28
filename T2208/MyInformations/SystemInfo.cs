using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Windows.Input;
using JayLib.JaySerialization;
using JayLib.WPF.BasicClass;

namespace T2208.MyInformations
{
	// Token: 0x02000065 RID: 101
	[Serializable]
	public class SystemInfo : ISerializable
	{
		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06000558 RID: 1368 RVA: 0x000077AA File Offset: 0x000059AA
		// (set) Token: 0x06000559 RID: 1369 RVA: 0x000077B2 File Offset: 0x000059B2
		public byte PFLFlag { get; set; }

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x0600055A RID: 1370 RVA: 0x000077BB File Offset: 0x000059BB
		// (set) Token: 0x0600055B RID: 1371 RVA: 0x000077C3 File Offset: 0x000059C3
		public byte LCDValue { get; set; }

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x0600055C RID: 1372 RVA: 0x000077CC File Offset: 0x000059CC
		// (set) Token: 0x0600055D RID: 1373 RVA: 0x000077D4 File Offset: 0x000059D4
		public byte KnobValue { get; set; }

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x0600055E RID: 1374 RVA: 0x000077DD File Offset: 0x000059DD
		// (set) Token: 0x0600055F RID: 1375 RVA: 0x000077E5 File Offset: 0x000059E5
		public byte DefaultPage { get; set; }

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x06000560 RID: 1376 RVA: 0x000077EE File Offset: 0x000059EE
		// (set) Token: 0x06000561 RID: 1377 RVA: 0x000077F6 File Offset: 0x000059F6
		public byte AuxBusMode { get; set; }

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06000562 RID: 1378 RVA: 0x000077FF File Offset: 0x000059FF
		// (set) Token: 0x06000563 RID: 1379 RVA: 0x00007807 File Offset: 0x00005A07
		public string Name { get; set; }

		// Token: 0x06000564 RID: 1380 RVA: 0x00003D5D File Offset: 0x00001F5D
		public SystemInfo()
		{
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x000047F1 File Offset: 0x000029F1
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			SerializerHelper.SerializationPropertyHelper(info, this, new Type[]
			{
				typeof(RelayCommand),
				typeof(RelayCommand<int>),
				typeof(ICommand)
			});
			SerializerHelper.SerializationFieldHelper(info, this);
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x0001ECBC File Offset: 0x0001CEBC
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		protected SystemInfo(SerializationInfo info, StreamingContext context)
		{
			SerializerHelper.DeserializtionPropertyHelper(info, this, new Type[]
			{
				typeof(RelayCommand),
				typeof(RelayCommand<int>),
				typeof(ICommand)
			});
			SerializerHelper.DeSerializationFieldHelper(info, this);
		}
	}
}
