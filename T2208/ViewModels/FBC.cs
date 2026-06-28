using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace T2208.ViewModels
{
	// Token: 0x02000033 RID: 51
	public class FBC : ViewModelBase
	{
		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000218 RID: 536 RVA: 0x00015040 File Offset: 0x00013240
		// (set) Token: 0x06000219 RID: 537 RVA: 0x00004C42 File Offset: 0x00002E42
		public ObservableCollection<ButtonItem> InputGroup
		{
			get
			{
				return this._InputGroup;
			}
			set
			{
				this._InputGroup = value;
				this.OnPropertyChanged<ObservableCollection<ButtonItem>>(() => this.InputGroup);
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600021A RID: 538 RVA: 0x00015058 File Offset: 0x00013258
		// (set) Token: 0x0600021B RID: 539 RVA: 0x00004C82 File Offset: 0x00002E82
		public ObservableCollection<ButtonItem> OutputGroup
		{
			get
			{
				return this._OutputGroup;
			}
			set
			{
				this._OutputGroup = value;
				this.OnPropertyChanged<ObservableCollection<ButtonItem>>(() => this.OutputGroup);
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x0600021C RID: 540 RVA: 0x00015070 File Offset: 0x00013270
		// (set) Token: 0x0600021D RID: 541 RVA: 0x00004CC2 File Offset: 0x00002EC2
		public ObservableCollection<FBCLightItem> FBCLights
		{
			get
			{
				return this._FBCLigths;
			}
			set
			{
				this._FBCLigths = value;
				this.OnPropertyChanged<ObservableCollection<FBCLightItem>>(() => this.FBCLights);
			}
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00015088 File Offset: 0x00013288
		public FBC()
		{
			for (int i = 0; i < 24; i++)
			{
				this.InputGroup.Add(new ButtonItem
				{
					Content = string.Format(string.Format("CH{0}", i + 1), new object[0])
				});
			}
			for (int j = 0; j < 8; j++)
			{
				this.OutputGroup.Add(new ButtonItem
				{
					Content = string.Format(string.Format("Aux{0}", j + 1), new object[0])
				});
			}
			this.OutputGroup.Add(new ButtonItem
			{
				Content = "Main"
			});
			for (int k = 0; k < 24; k++)
			{
				this.FBCLights.Add(new FBCLightItem
				{
					Content = (k + 1).ToString()
				});
			}
			this.FBCLights.First<FBCLightItem>().IsBlink = true;
			this.FBCLights.First<FBCLightItem>().BlinkLightStatus = 1;
		}

		// Token: 0x0400010C RID: 268
		private ObservableCollection<ButtonItem> _InputGroup = new ObservableCollection<ButtonItem>();

		// Token: 0x0400010D RID: 269
		private ObservableCollection<ButtonItem> _OutputGroup = new ObservableCollection<ButtonItem>();

		// Token: 0x0400010E RID: 270
		private ObservableCollection<FBCLightItem> _FBCLigths = new ObservableCollection<FBCLightItem>();
	}
}
