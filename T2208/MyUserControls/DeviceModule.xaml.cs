using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace T2208.MyUserControls
{
	// Token: 0x02000054 RID: 84
	public partial class DeviceModule : UserControl
	{
		// Token: 0x06000441 RID: 1089 RVA: 0x00006656 File Offset: 0x00004856
		public DeviceModule()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x06000442 RID: 1090 RVA: 0x0001D074 File Offset: 0x0001B274
		// (set) Token: 0x06000443 RID: 1091 RVA: 0x00006667 File Offset: 0x00004867
		public string DeviceName
		{
			get
			{
				return (string)base.GetValue(DeviceModule.DeviceNameProperty);
			}
			set
			{
				base.SetValue(DeviceModule.DeviceNameProperty, value);
			}
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x06000444 RID: 1092 RVA: 0x0001D098 File Offset: 0x0001B298
		// (set) Token: 0x06000445 RID: 1093 RVA: 0x00006677 File Offset: 0x00004877
		public string Address
		{
			get
			{
				return (string)base.GetValue(DeviceModule.AddressProperty);
			}
			set
			{
				base.SetValue(DeviceModule.AddressProperty, value);
			}
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x06000446 RID: 1094 RVA: 0x0001D0BC File Offset: 0x0001B2BC
		// (set) Token: 0x06000447 RID: 1095 RVA: 0x00006687 File Offset: 0x00004887
		public string MAC
		{
			get
			{
				return (string)base.GetValue(DeviceModule.MACProperty);
			}
			set
			{
				base.SetValue(DeviceModule.MACProperty, value);
			}
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x06000448 RID: 1096 RVA: 0x0001D0E0 File Offset: 0x0001B2E0
		// (set) Token: 0x06000449 RID: 1097 RVA: 0x00006697 File Offset: 0x00004897
		public Brush ActiveBrush
		{
			get
			{
				return (Brush)base.GetValue(DeviceModule.ActiveBrushProperty);
			}
			set
			{
				base.SetValue(DeviceModule.ActiveBrushProperty, value);
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x0600044A RID: 1098 RVA: 0x0001D104 File Offset: 0x0001B304
		// (set) Token: 0x0600044B RID: 1099 RVA: 0x000066A7 File Offset: 0x000048A7
		public bool IsConnected
		{
			get
			{
				return (bool)base.GetValue(DeviceModule.IsConnectedProperty);
			}
			set
			{
				base.SetValue(DeviceModule.IsConnectedProperty, value);
			}
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x0001D128 File Offset: 0x0001B328
		private static void OnIsConnectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DeviceModule deviceModule;
			bool flag = (deviceModule = d as DeviceModule) != null;
			if (flag)
			{
				deviceModule.BD.BorderBrush = (((bool)e.NewValue) ? deviceModule.ActiveBrush : Brushes.Red);
			}
		}

		// Token: 0x040002AB RID: 683
		public static readonly DependencyProperty DeviceNameProperty = DependencyProperty.Register("DeviceName", typeof(string), typeof(DeviceModule), new PropertyMetadata(null));

		// Token: 0x040002AC RID: 684
		public static readonly DependencyProperty AddressProperty = DependencyProperty.Register("Address", typeof(string), typeof(DeviceModule), new PropertyMetadata(null));

		// Token: 0x040002AD RID: 685
		public static readonly DependencyProperty MACProperty = DependencyProperty.Register("MAC", typeof(string), typeof(DeviceModule), new PropertyMetadata(null));

		// Token: 0x040002AE RID: 686
		public static readonly DependencyProperty ActiveBrushProperty = DependencyProperty.Register("ActiveBrush", typeof(Brush), typeof(DeviceModule), new PropertyMetadata(Brushes.Green));

		// Token: 0x040002AF RID: 687
		public static readonly DependencyProperty IsConnectedProperty = DependencyProperty.Register("IsConnected", typeof(bool), typeof(DeviceModule), new PropertyMetadata(false, new PropertyChangedCallback(DeviceModule.OnIsConnectedChanged)));
	}
}
