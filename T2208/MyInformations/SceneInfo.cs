using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Windows.Input;
using JayLib.JaySerialization;
using JayLib.WPF.BasicClass;
using T2208.ViewModels;

namespace T2208.MyInformations
{
	// Token: 0x02000064 RID: 100
	[Serializable]
	public class SceneInfo : ISerializable
	{
		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x06000545 RID: 1349 RVA: 0x00007722 File Offset: 0x00005922
		// (set) Token: 0x06000546 RID: 1350 RVA: 0x0000772A File Offset: 0x0000592A
		public List<ChannelInfo> Channels { get; set; } = new List<ChannelInfo>();

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x06000547 RID: 1351 RVA: 0x00007733 File Offset: 0x00005933
		// (set) Token: 0x06000548 RID: 1352 RVA: 0x0000773B File Offset: 0x0000593B
		public ChannelInfo Solo { get; set; }

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x06000549 RID: 1353 RVA: 0x00007744 File Offset: 0x00005944
		// (set) Token: 0x0600054A RID: 1354 RVA: 0x0000774C File Offset: 0x0000594C
		public List<GEQInfo> GEQs { get; set; } = new List<GEQInfo>();

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x0600054B RID: 1355 RVA: 0x00007755 File Offset: 0x00005955
		// (set) Token: 0x0600054C RID: 1356 RVA: 0x0000775D File Offset: 0x0000595D
		public List<FXInfo<FXItem>> FXs { get; set; } = new List<FXInfo<FXItem>>();

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x0600054D RID: 1357 RVA: 0x00007766 File Offset: 0x00005966
		// (set) Token: 0x0600054E RID: 1358 RVA: 0x0000776E File Offset: 0x0000596E
		public List<DCAInfo<DCAItem>> DCAs { get; set; } = new List<DCAInfo<DCAItem>>();

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x0600054F RID: 1359 RVA: 0x00007777 File Offset: 0x00005977
		// (set) Token: 0x06000550 RID: 1360 RVA: 0x0000777F File Offset: 0x0000597F
		public SystemInfo SystemInfo { get; set; } = new SystemInfo();

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x06000551 RID: 1361 RVA: 0x00007788 File Offset: 0x00005988
		// (set) Token: 0x06000552 RID: 1362 RVA: 0x00007790 File Offset: 0x00005990
		public byte PresetIndex { get; set; }

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06000553 RID: 1363 RVA: 0x00007799 File Offset: 0x00005999
		// (set) Token: 0x06000554 RID: 1364 RVA: 0x000077A1 File Offset: 0x000059A1
		public bool PFL { get; set; }

		// Token: 0x06000555 RID: 1365 RVA: 0x0001EBE4 File Offset: 0x0001CDE4
		public SceneInfo()
		{
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x000047F1 File Offset: 0x000029F1
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

		// Token: 0x06000557 RID: 1367 RVA: 0x0001EC30 File Offset: 0x0001CE30
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		protected SceneInfo(SerializationInfo info, StreamingContext context)
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
