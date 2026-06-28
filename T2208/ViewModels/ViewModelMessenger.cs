using System;
using System.Linq.Expressions;
using JayLib.WPF.BasicClass;

namespace T2208.ViewModels
{
	// Token: 0x02000049 RID: 73
	internal static class ViewModelMessenger
	{
		// Token: 0x1700014B RID: 331
		// (get) Token: 0x060003C0 RID: 960 RVA: 0x00006307 File Offset: 0x00004507
		public static Messeager Messenger { get; } = new Messeager();

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x060003C1 RID: 961 RVA: 0x0000630E File Offset: 0x0000450E
		public static string UpdateDeviceStatus { get; } = ViewModelMessenger.GetMessage<string>(() => ViewModelMessenger.UpdateDeviceStatus);

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x060003C2 RID: 962 RVA: 0x00006315 File Offset: 0x00004515
		public static string UpdateDeviceName { get; } = ViewModelMessenger.GetMessage<string>(() => ViewModelMessenger.UpdateDeviceName);

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x0000631C File Offset: 0x0000451C
		public static string UpdateSystemDeviceName { get; } = ViewModelMessenger.GetMessage<string>(() => ViewModelMessenger.UpdateSystemDeviceName);

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x060003C4 RID: 964 RVA: 0x00006323 File Offset: 0x00004523
		public static string UpdateSystemDanteName { get; } = ViewModelMessenger.GetMessage<string>(() => ViewModelMessenger.UpdateSystemDanteName);

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x060003C5 RID: 965 RVA: 0x0000632A File Offset: 0x0000452A
		public static string UpdateEqualizer { get; } = ViewModelMessenger.GetMessage<string>(() => ViewModelMessenger.UpdateEqualizer);

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x060003C6 RID: 966 RVA: 0x00006331 File Offset: 0x00004531
		public static string UpdateChannelInfo { get; } = ViewModelMessenger.GetMessage<string>(() => ViewModelMessenger.UpdateChannelInfo);

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x060003C7 RID: 967 RVA: 0x00006338 File Offset: 0x00004538
		public static string UpdateGeqSelectedItem { get; } = ViewModelMessenger.GetMessage<string>(() => ViewModelMessenger.UpdateGeqSelectedItem);

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x060003C8 RID: 968 RVA: 0x0000633F File Offset: 0x0000453F
		public static string UpdateFxForBackUp { get; } = ViewModelMessenger.GetMessage<string>(() => ViewModelMessenger.UpdateFxForBackUp);

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x060003C9 RID: 969 RVA: 0x00006346 File Offset: 0x00004546
		public static string IsSearching { get; } = ViewModelMessenger.GetMessage<string>(() => ViewModelMessenger.IsSearching);

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x060003CA RID: 970 RVA: 0x0000634D File Offset: 0x0000454D
		public static string IsBusy { get; } = ViewModelMessenger.GetMessage<string>(() => ViewModelMessenger.IsBusy);

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x060003CB RID: 971 RVA: 0x00006354 File Offset: 0x00004554
		public static string UpdateLink { get; } = ViewModelMessenger.GetMessage<string>(() => ViewModelMessenger.UpdateLink);

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x060003CC RID: 972 RVA: 0x0000635B File Offset: 0x0000455B
		public static string UpdateDspgeqfxIndex { get; } = ViewModelMessenger.GetMessage<string>(() => ViewModelMessenger.UpdateDspgeqfxIndex);

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x060003CD RID: 973 RVA: 0x00006362 File Offset: 0x00004562
		public static string UpdateAllEqualizer { get; } = ViewModelMessenger.GetMessage<string>(() => ViewModelMessenger.UpdateAllEqualizer);

		// Token: 0x060003CE RID: 974 RVA: 0x0001AB5C File Offset: 0x00018D5C
		private static string GetMessage<T>(Expression<Func<T>> propertyExpression)
		{
			MemberExpression memberExpression = propertyExpression.Body as MemberExpression;
			return memberExpression.Member.Name;
		}
	}
}
