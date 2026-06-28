using System;
using System.Linq.Expressions;
using JayLib.WPF.BasicClass;

namespace T2208.ViewModels
{
	// Token: 0x02000047 RID: 71
	public class ViewModelMessager
	{
		// Token: 0x17000141 RID: 321
		// (get) Token: 0x060003A7 RID: 935 RVA: 0x00006265 File Offset: 0x00004465
		// (set) Token: 0x060003A8 RID: 936 RVA: 0x0000626C File Offset: 0x0000446C
		public static Messeager Messeager { get; private set; } = new Messeager();

		// Token: 0x060003A9 RID: 937 RVA: 0x0001A9A0 File Offset: 0x00018BA0
		private static string GetMessage<T>(Expression<Func<T>> propertyExpression)
		{
			return (propertyExpression.Body as MemberExpression).Member.Name;
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x060003AA RID: 938 RVA: 0x00006274 File Offset: 0x00004474
		// (set) Token: 0x060003AB RID: 939 RVA: 0x0000627B File Offset: 0x0000447B
		public static string UpdateChannelInfo { get; private set; } = ViewModelMessager.GetMessage<string>(() => ViewModelMessager.UpdateChannelInfo);

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x060003AC RID: 940 RVA: 0x00006283 File Offset: 0x00004483
		// (set) Token: 0x060003AD RID: 941 RVA: 0x0000628A File Offset: 0x0000448A
		public static string DCAIsSelected { get; private set; } = ViewModelMessager.GetMessage<string>(() => ViewModelMessager.DCAIsSelected);

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060003AE RID: 942 RVA: 0x00006292 File Offset: 0x00004492
		// (set) Token: 0x060003AF RID: 943 RVA: 0x00006299 File Offset: 0x00004499
		public static string FindNewDevice { get; private set; } = ViewModelMessager.GetMessage<string>(() => ViewModelMessager.FindNewDevice);

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060003B0 RID: 944 RVA: 0x000062A1 File Offset: 0x000044A1
		// (set) Token: 0x060003B1 RID: 945 RVA: 0x000062A8 File Offset: 0x000044A8
		public static string FindT2208 { get; private set; } = ViewModelMessager.GetMessage<string>(() => ViewModelMessager.FindT2208);

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x060003B2 RID: 946 RVA: 0x000062B0 File Offset: 0x000044B0
		// (set) Token: 0x060003B3 RID: 947 RVA: 0x000062B7 File Offset: 0x000044B7
		public static string UpdateEqualizer { get; private set; } = ViewModelMessager.GetMessage<string>(() => ViewModelMessager.UpdateEqualizer);

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x060003B4 RID: 948 RVA: 0x000062BF File Offset: 0x000044BF
		// (set) Token: 0x060003B5 RID: 949 RVA: 0x000062C6 File Offset: 0x000044C6
		public static string UpdateAllEqualizer { get; private set; } = ViewModelMessager.GetMessage<string>(() => ViewModelMessager.UpdateAllEqualizer);

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060003B6 RID: 950 RVA: 0x000062CE File Offset: 0x000044CE
		// (set) Token: 0x060003B7 RID: 951 RVA: 0x000062D5 File Offset: 0x000044D5
		public static string UpdateDSPGEQFXIndex { get; private set; } = ViewModelMessager.GetMessage<string>(() => ViewModelMessager.UpdateDSPGEQFXIndex);

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x060003B8 RID: 952 RVA: 0x000062DD File Offset: 0x000044DD
		// (set) Token: 0x060003B9 RID: 953 RVA: 0x000062E4 File Offset: 0x000044E4
		public static string UpdateConnectionState { get; private set; } = ViewModelMessager.GetMessage<string>(() => ViewModelMessager.UpdateConnectionState);

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x060003BA RID: 954 RVA: 0x000062EC File Offset: 0x000044EC
		// (set) Token: 0x060003BB RID: 955 RVA: 0x000062F3 File Offset: 0x000044F3
		public static string IsBusy { get; internal set; } = ViewModelMessager.GetMessage<string>(() => ViewModelMessager.IsBusy);
	}
}
