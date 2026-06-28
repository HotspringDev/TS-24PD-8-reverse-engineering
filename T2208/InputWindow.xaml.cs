using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace T2208
{
	// Token: 0x02000008 RID: 8
	public partial class InputWindow : Window
	{
		// Token: 0x0600001C RID: 28 RVA: 0x00003771 File Offset: 0x00001971
		public InputWindow()
		{
			this.InitializeComponent();
			this.InputStrings.Focus();
		}
	}
}
