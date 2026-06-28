using System;
using System.Windows;
using System.Windows.Input;
using JayLib.WPF.BasicClass;
using T2208.MyDatas;

namespace T2208.SmallViewModels
{
	// Token: 0x02000026 RID: 38
	public class WindowViewModel : NotificationObject
	{
		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000F9 RID: 249 RVA: 0x00003F8B File Offset: 0x0000218B
		// (set) Token: 0x060000FA RID: 250 RVA: 0x00003F93 File Offset: 0x00002193
		public RelayCommand<Window> WindowMoveCommand { get; private set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000FB RID: 251 RVA: 0x00003F9C File Offset: 0x0000219C
		// (set) Token: 0x060000FC RID: 252 RVA: 0x00003FA4 File Offset: 0x000021A4
		public RelayCommand<Window> WindowStateChangeCommand { get; private set; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000FD RID: 253 RVA: 0x00003FAD File Offset: 0x000021AD
		// (set) Token: 0x060000FE RID: 254 RVA: 0x00003FB5 File Offset: 0x000021B5
		public RelayCommand<Window> WindowCloseCommand { get; private set; }

		// Token: 0x060000FF RID: 255 RVA: 0x0000E288 File Offset: 0x0000C488
		public WindowViewModel()
		{
			this.WindowMoveCommand = new RelayCommand<Window>(new Action<Window>(this.WindowMoveExecute));
			this.WindowStateChangeCommand = new RelayCommand<Window>(new Action<Window>(this.WindowStateChangedExecute));
			this.WindowCloseCommand = new RelayCommand<Window>(new Action<Window>(this.WindowCloseExecute));
		}

		// Token: 0x06000100 RID: 256 RVA: 0x0000E2E8 File Offset: 0x0000C4E8
		private void WindowCloseExecute(Window window)
		{
			bool flag = window == null;
			if (flag)
			{
				window = WindowData.CurrentWindow;
			}
			window.Close();
		}

		// Token: 0x06000101 RID: 257 RVA: 0x0000E310 File Offset: 0x0000C510
		private void WindowMoveExecute(Window window)
		{
			bool flag = window == null;
			if (flag)
			{
				window = WindowData.CurrentWindow;
			}
			bool flag2 = Mouse.LeftButton == MouseButtonState.Pressed;
			if (flag2)
			{
				bool flag3 = window.WindowState == WindowState.Maximized;
				if (flag3)
				{
					double num = Mouse.GetPosition(window).X / window.ActualWidth;
					window.WindowState = WindowState.Normal;
					window.Top = Mouse.GetPosition(null).Y - 10.0;
					window.Left = Mouse.GetPosition(null).X - window.ActualWidth * num;
				}
				window.DragMove();
			}
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000E3B4 File Offset: 0x0000C5B4
		private void WindowStateChangedExecute(Window window)
		{
			bool flag = window == null;
			if (flag)
			{
				window = WindowData.CurrentWindow;
			}
			switch (WindowData.MainWindow.WindowState)
			{
			case WindowState.Normal:
				window.WindowState = WindowState.Maximized;
				break;
			case WindowState.Maximized:
				window.WindowState = WindowState.Normal;
				break;
			}
		}
	}
}
