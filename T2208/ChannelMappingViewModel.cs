using System;
using System.Collections.Generic;
using JayLib.JayString;
using JayLib.WPF.BasicClass;

namespace T2208
{
	// Token: 0x02000004 RID: 4
	public class ChannelMappingViewModel : NotificationObject
	{
		// Token: 0x06000008 RID: 8 RVA: 0x0000A290 File Offset: 0x00008490
		public ChannelMappingViewModel(bool isInput)
		{
			if (isInput)
			{
				this.Column1.Add("Digital IO");
				this.Column2.Add("Mixer");
				this.Column3.Add("Digital IO");
				this.Column4.Add("Mixer");
				for (int i = 0; i < 24; i++)
				{
					string text = (i + 1).ToString().RightJustified(2, '0');
					this.InputMixerDigitalList.Add(new MixerDigitalIO
					{
						DigitalIO = "Output" + text + "/Rx Ch" + text,
						Mixer = "Ch" + text
					});
				}
				for (int j = 0; j < this.InputMixerDigitalList.Count; j++)
				{
					bool flag = j < this.InputMixerDigitalList.Count / 2;
					if (flag)
					{
						this.Column1.Add(this.InputMixerDigitalList[j].DigitalIO);
						this.Column2.Add(this.InputMixerDigitalList[j].Mixer);
					}
					else
					{
						this.Column3.Add(this.InputMixerDigitalList[j].DigitalIO);
						this.Column4.Add(this.InputMixerDigitalList[j].Mixer);
					}
				}
			}
			else
			{
				this.Column1.Add("Mixer");
				this.Column2.Add("Digital IO");
				this.Column3.Add("Mixer");
				this.Column4.Add("Digital IO");
				for (int k = 0; k < 24; k++)
				{
					string text2 = (k + 1).ToString().RightJustified(2, '0');
					this.OutputMixerDigitalList.Add(new MixerDigitalIO
					{
						DigitalIO = "Input" + text2 + "/Tx Ch" + text2,
						Mixer = "Ch" + text2
					});
				}
				for (int l = 0; l < 8; l++)
				{
					string text3 = (l + 1 + this.OutputMixerDigitalList.Count).ToString();
					this.OutputMixerDigitalList.Add(new MixerDigitalIO
					{
						DigitalIO = "Input" + text3 + "/Tx Ch" + text3,
						Mixer = "Aux" + (l + 1).ToString()
					});
				}
				this.OutputMixerDigitalList.Add(new MixerDigitalIO
				{
					DigitalIO = string.Format("Input{0}/Tx Ch{1}", this.OutputMixerDigitalList.Count + 1, this.OutputMixerDigitalList.Count + 1),
					Mixer = "Main-L"
				});
				this.OutputMixerDigitalList.Add(new MixerDigitalIO
				{
					DigitalIO = string.Format("Input{0}/Tx Ch{1}", this.OutputMixerDigitalList.Count + 1, this.OutputMixerDigitalList.Count + 1),
					Mixer = "Main-R"
				});
				this.OutputMixerDigitalList.Add(new MixerDigitalIO
				{
					DigitalIO = string.Format("Input{0}/Tx Ch{1}", this.OutputMixerDigitalList.Count + 1, this.OutputMixerDigitalList.Count + 1),
					Mixer = "Solo-L"
				});
				this.OutputMixerDigitalList.Add(new MixerDigitalIO
				{
					DigitalIO = string.Format("Input{0}/Tx Ch{1}", this.OutputMixerDigitalList.Count + 1, this.OutputMixerDigitalList.Count + 1),
					Mixer = "Solo-R"
				});
				for (int m = 0; m < this.OutputMixerDigitalList.Count; m++)
				{
					bool flag2 = m < this.OutputMixerDigitalList.Count / 2;
					if (flag2)
					{
						this.Column1.Add(this.OutputMixerDigitalList[m].Mixer);
						this.Column2.Add(this.OutputMixerDigitalList[m].DigitalIO);
					}
					else
					{
						this.Column3.Add(this.OutputMixerDigitalList[m].Mixer);
						this.Column4.Add(this.OutputMixerDigitalList[m].DigitalIO);
					}
				}
			}
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000009 RID: 9 RVA: 0x0000A784 File Offset: 0x00008984
		// (set) Token: 0x0600000A RID: 10 RVA: 0x0000361D File Offset: 0x0000181D
		public List<string> Column1
		{
			get
			{
				return this._Column1;
			}
			set
			{
				this._Column1 = value;
				this.OnPropertyChanged<List<string>>(() => this.Column1);
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000B RID: 11 RVA: 0x0000A79C File Offset: 0x0000899C
		// (set) Token: 0x0600000C RID: 12 RVA: 0x0000365D File Offset: 0x0000185D
		public List<string> Column2
		{
			get
			{
				return this._Column2;
			}
			set
			{
				this._Column2 = value;
				this.OnPropertyChanged<List<string>>(() => this.Column2);
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000D RID: 13 RVA: 0x0000A7B4 File Offset: 0x000089B4
		// (set) Token: 0x0600000E RID: 14 RVA: 0x0000369D File Offset: 0x0000189D
		public List<string> Column3
		{
			get
			{
				return this._Column3;
			}
			set
			{
				this._Column3 = value;
				this.OnPropertyChanged<List<string>>(() => this.Column3);
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000F RID: 15 RVA: 0x0000A7CC File Offset: 0x000089CC
		// (set) Token: 0x06000010 RID: 16 RVA: 0x000036DD File Offset: 0x000018DD
		public List<string> Column4
		{
			get
			{
				return this._Column4;
			}
			set
			{
				this._Column4 = value;
				this.OnPropertyChanged<List<string>>(() => this.Column4);
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000011 RID: 17 RVA: 0x0000371D File Offset: 0x0000191D
		public List<MixerDigitalIO> InputMixerDigitalList
		{
			get
			{
				return new List<MixerDigitalIO>();
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000012 RID: 18 RVA: 0x00003724 File Offset: 0x00001924
		// (set) Token: 0x06000013 RID: 19 RVA: 0x0000372C File Offset: 0x0000192C
		public List<MixerDigitalIO> OutputMixerDigitalList { get; set; } = new List<MixerDigitalIO>();

		// Token: 0x04000005 RID: 5
		private List<string> _Column1 = new List<string>();

		// Token: 0x04000006 RID: 6
		private List<string> _Column2 = new List<string>();

		// Token: 0x04000007 RID: 7
		private List<string> _Column3 = new List<string>();

		// Token: 0x04000008 RID: 8
		private List<string> _Column4 = new List<string>();
	}
}
