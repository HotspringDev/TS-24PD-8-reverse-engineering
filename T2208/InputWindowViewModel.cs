using System;
using System.Text.RegularExpressions;
using System.Windows;
using JayLib.WPF.BasicClass;

namespace T2208
{
	// Token: 0x02000009 RID: 9
	public class InputWindowViewModel : NotificationObject
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001F RID: 31 RVA: 0x0000A8AC File Offset: 0x00008AAC
		// (set) Token: 0x06000020 RID: 32 RVA: 0x0000378E File Offset: 0x0000198E
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				this._Title = value;
				this.OnPropertyChanged<string>(() => this.Title);
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000021 RID: 33 RVA: 0x0000A8C4 File Offset: 0x00008AC4
		// (set) Token: 0x06000022 RID: 34 RVA: 0x000037CE File Offset: 0x000019CE
		public string RegularExpression
		{
			get
			{
				return this._RegularExpression;
			}
			set
			{
				this._RegularExpression = value;
				this.OnPropertyChanged<string>(() => this.RegularExpression);
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000023 RID: 35 RVA: 0x0000A8DC File Offset: 0x00008ADC
		// (set) Token: 0x06000024 RID: 36 RVA: 0x0000A8F4 File Offset: 0x00008AF4
		public string InputString
		{
			get
			{
				return this._InputString;
			}
			set
			{
				bool flag = !string.IsNullOrEmpty(this.RegularExpression) && Regex.IsMatch(value, this.RegularExpression);
				if (flag)
				{
					this._InputString = value;
				}
				else
				{
					bool flag2 = string.IsNullOrEmpty(this.RegularExpression);
					if (flag2)
					{
						this._InputString = value;
					}
				}
				this.OnPropertyChanged<string>(() => this.InputString);
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000025 RID: 37 RVA: 0x0000A97C File Offset: 0x00008B7C
		// (set) Token: 0x06000026 RID: 38 RVA: 0x0000380E File Offset: 0x00001A0E
		public bool Result
		{
			get
			{
				return this._Result;
			}
			set
			{
				this._Result = value;
				this.OnPropertyChanged<bool>(() => this.Result);
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000027 RID: 39 RVA: 0x0000384E File Offset: 0x00001A4E
		// (set) Token: 0x06000028 RID: 40 RVA: 0x00003856 File Offset: 0x00001A56
		public Window Window { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000029 RID: 41 RVA: 0x0000385F File Offset: 0x00001A5F
		// (set) Token: 0x0600002A RID: 42 RVA: 0x00003867 File Offset: 0x00001A67
		public RelayCommand CancelCommand { get; private set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00003870 File Offset: 0x00001A70
		// (set) Token: 0x0600002C RID: 44 RVA: 0x00003878 File Offset: 0x00001A78
		public RelayCommand ConfirmCommand { get; private set; }

		// Token: 0x0600002D RID: 45 RVA: 0x00003881 File Offset: 0x00001A81
		public InputWindowViewModel()
		{
			this.CancelCommand = new RelayCommand(new Action(this.CancelExecute));
			this.ConfirmCommand = new RelayCommand(new Action(this.ConfirmExecute));
		}

		// Token: 0x0600002E RID: 46 RVA: 0x0000A994 File Offset: 0x00008B94
		private void CancelExecute()
		{
			this.Result = false;
			bool flag = this.Window != null;
			if (flag)
			{
				this.Window.Close();
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x0000A9C8 File Offset: 0x00008BC8
		private void ConfirmExecute()
		{
			this.Result = !string.IsNullOrWhiteSpace(this.InputString);
			bool flag = !this.Result;
			if (flag)
			{
				MessageBox.Show("Please input preset name");
			}
			else
			{
				bool flag2 = this.Window != null;
				if (flag2)
				{
					this.Window.Close();
				}
			}
		}

		// Token: 0x04000010 RID: 16
		private string _Title;

		// Token: 0x04000011 RID: 17
		private string _RegularExpression;

		// Token: 0x04000012 RID: 18
		private string _InputString;

		// Token: 0x04000013 RID: 19
		private bool _Result;
	}
}
