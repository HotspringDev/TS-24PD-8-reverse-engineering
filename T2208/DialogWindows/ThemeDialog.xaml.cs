using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using MyTypespace;

namespace T2208.DialogWindows
{
	// Token: 0x020000AF RID: 175
	public partial class ThemeDialog : UserControl
	{
		// Token: 0x06000888 RID: 2184 RVA: 0x00009D8E File Offset: 0x00007F8E
		public ThemeDialog()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000310 RID: 784
		// (get) Token: 0x06000889 RID: 2185 RVA: 0x00009D9F File Offset: 0x00007F9F
		// (set) Token: 0x0600088A RID: 2186 RVA: 0x000264C8 File Offset: 0x000246C8
		public ThemeDialogType ThemeDialogType
		{
			get
			{
				return this._themeDialogType;
			}
			set
			{
				this._themeDialogType = value;
				if (value != ThemeDialogType.OkChanceMessage)
				{
					if (value == ThemeDialogType.Wait)
					{
						this.textBlockMessage.Visibility = Visibility.Collapsed;
						this.progressBar.Visibility = Visibility.Visible;
						this.btnOk.Visibility = Visibility.Collapsed;
					}
				}
				else
				{
					this.textBlockMessage.Visibility = Visibility.Visible;
					this.progressBar.Visibility = Visibility.Collapsed;
					this.btnOk.Visibility = Visibility.Visible;
				}
			}
		}

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x0600088B RID: 2187 RVA: 0x00009DA7 File Offset: 0x00007FA7
		// (set) Token: 0x0600088C RID: 2188 RVA: 0x00026540 File Offset: 0x00024740
		public string MessageText
		{
			get
			{
				return this._messageText;
			}
			set
			{
				this._messageText = value;
				this.textBlockMessage.Text = this._messageText;
				bool flag = value == null;
				if (flag)
				{
					this.textBlockMessage.Visibility = Visibility.Collapsed;
					this.progressBar.Visibility = Visibility.Visible;
				}
				else
				{
					this.textBlockMessage.Visibility = Visibility.Visible;
					this.progressBar.Visibility = Visibility.Collapsed;
				}
			}
		}

		// Token: 0x040004AC RID: 1196
		private ThemeDialogType _themeDialogType;

		// Token: 0x040004AD RID: 1197
		private string _messageText;
	}
}
