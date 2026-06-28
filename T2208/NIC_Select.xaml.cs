using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace T2208
{
	// Token: 0x0200000C RID: 12
	public partial class NIC_Select : Window
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00003941 File Offset: 0x00001B41
		// (set) Token: 0x06000041 RID: 65 RVA: 0x00003949 File Offset: 0x00001B49
		public object NICIP { get; private set; }

		// Token: 0x06000042 RID: 66 RVA: 0x0000AC30 File Offset: 0x00008E30
		public NIC_Select()
		{
			this.InitializeComponent();
			this.vs.Clear();
			bool flag = Multiple_NIC.Multiple_NIC_collection.Count < 1;
			if (flag)
			{
				MessageBox.Show("There is no useful Internet Card in this computer.");
				Environment.Exit(Environment.ExitCode);
			}
			for (int i = 0; i < Multiple_NIC.Multiple_NIC_collection.Count; i++)
			{
				string nic_Name = Multiple_NIC.Multiple_NIC_collection[i].NIC_Name1;
				this.vs.Add(nic_Name);
			}
			this.NIC_collect.ItemsSource = this.vs;
			this.NIC_collect.SelectedIndex = 0;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003952 File Offset: 0x00001B52
		private void Select_Click(object sender, RoutedEventArgs e)
		{
			MainWindow.IP = Multiple_NIC.Multiple_NIC_collection[this.NIC_collect.SelectedIndex].NIC_IP1;
			this.selected = true;
			base.Close();
		}

		// Token: 0x06000044 RID: 68 RVA: 0x0000ACEC File Offset: 0x00008EEC
		private void Window_Closed(object sender, EventArgs e)
		{
			bool flag = !this.selected;
			if (flag)
			{
				MainWindow.IP = Multiple_NIC.Multiple_NIC_collection[this.NIC_collect.SelectedIndex].NIC_IP1;
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x0000AD28 File Offset: 0x00008F28
		private void Refresh_Click(object sender, RoutedEventArgs e)
		{
			Multiple_NIC multiple_NIC = new Multiple_NIC();
			multiple_NIC.refresh();
			this.vs.Clear();
			for (int i = 0; i < Multiple_NIC.Multiple_NIC_collection.Count; i++)
			{
				string nic_Name = Multiple_NIC.Multiple_NIC_collection[i].NIC_Name1;
				this.vs.Add(nic_Name);
			}
			this.NIC_collect.ItemsSource = null;
			this.NIC_collect.ItemsSource = this.vs;
			this.NIC_collect.SelectedIndex = 0;
		}

		// Token: 0x04000020 RID: 32
		private Collection<string> vs = new Collection<string>();

		// Token: 0x04000021 RID: 33
		private bool selected = false;
	}
}
