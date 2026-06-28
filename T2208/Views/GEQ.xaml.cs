using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using JayCustomControlLib;
using JayLib.Localization;
using T2208.DeviceCommuncation;
using T2208.Models;
using T2208.MyDatas;
using T2208.MyInformations;
using T2208.MyUserControls;
using T2208.ViewModels;

namespace T2208.Views
{
	// Token: 0x02000019 RID: 25
	public partial class GEQ : Page
	{
		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x00003DBA File Offset: 0x00001FBA
		// (set) Token: 0x060000B4 RID: 180 RVA: 0x00003DC1 File Offset: 0x00001FC1
		public static byte SelectedGEQPageIndex { get; set; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x00003DC9 File Offset: 0x00001FC9
		// (set) Token: 0x060000B6 RID: 182 RVA: 0x0000CB20 File Offset: 0x0000AD20
		public static byte SelectedGEQDeviceIndex
		{
			get
			{
				return GEQ.s_selectedGEQDeviceIndex;
			}
			set
			{
				bool flag = value == 0;
				if (!flag)
				{
					GEQ.s_selectedGEQDeviceIndex = value;
				}
			}
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000CB40 File Offset: 0x0000AD40
		public GEQ()
		{
			this.InitializeComponent();
			this.FreqValue.Text = "20.0KHz";
			this.Text_GainValue.Text = "0dB";
			base.Loaded += this.Page_Loaded;
			foreach (object obj in this.grid2.Children)
			{
				bool flag = obj.GetType() == typeof(Label);
				if (flag)
				{
					Label label = obj as Label;
					int num = (int)Convert.ToInt16(label.Tag);
					this.Tb[num] = label;
				}
			}
			foreach (object obj2 in this.slidergrid.Children)
			{
				bool flag2 = obj2.GetType() == typeof(T2208.MyUserControls.Slider);
				if (flag2)
				{
					T2208.MyUserControls.Slider slider = obj2 as T2208.MyUserControls.Slider;
					int num2 = (int)Convert.ToInt16(slider.Tag);
					this.Sliders[num2] = slider;
					slider.OnKaSliderValueChanged += this.Cs_SliderValueChanged;
				}
			}
			for (int i = 0; i < 3; i++)
			{
				this.switcher[i] = base.FindName("btn" + i) as JSwitcher;
			}
			for (int j = 0; j < 31; j++)
			{
				TextBlock textBlock = new TextBlock();
				textBlock.Text = (j + 1).ToString();
				textBlock.Foreground = Brushes.White;
				textBlock.FontFamily = new FontFamily("Times New Roman");
				textBlock.HorizontalAlignment = HorizontalAlignment.Center;
				textBlock.VerticalAlignment = VerticalAlignment.Center;
				Grid.SetRow(textBlock, 1);
				Grid.SetColumn(textBlock, j + 1);
				this.grid2.Children.Add(textBlock);
			}
			for (int k = 0; k < 31; k++)
			{
				int num3 = 5 - k % 2;
				TextBlock textBlock2 = new TextBlock();
				textBlock2.Text = Const.GEQFrequenceStrings[k];
				textBlock2.Padding = new Thickness(0.0);
				textBlock2.FontFamily = new FontFamily("Times New Roman");
				textBlock2.Foreground = Brushes.White;
				textBlock2.VerticalAlignment = VerticalAlignment.Center;
				textBlock2.HorizontalAlignment = HorizontalAlignment.Center;
				Grid.SetRow(textBlock2, num3);
				Grid.SetColumn(textBlock2, k + 1);
				this.grid2.Children.Add(textBlock2);
			}
			this._GEQInfo = GEQData.GEQDatas.Aux1;
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_ReadCurrentScene), new Action<byte[]>(this.ReadCurrentSceneExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_GEQChannel), new Action<byte[]>(this.UpdateGEQExecute));
			MainData.ConnectionModel.Messager.Register(new int?(1), new int?(1), new int?((int)CommandConst.CMD_SyncCommand), new Action<byte[]>(this.SynchronizeGEQExecute));
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000CF48 File Offset: 0x0000B148
		private void SynchronizeGEQExecute(byte[] obj)
		{
			bool flag = obj[10] == CommandConst.DEVE_PAGE_GEQ && obj[11] != 10;
			if (flag)
			{
				int num = (int)this._GEQIndexDeviceToPage[(int)obj[11]];
				GEQ.SelectedGEQPageIndex = (byte)num;
				GEQ.SelectedGEQDeviceIndex = obj[11];
				this.UpdateGeqChindex(num.ToString(), true);
				JSwitcher.JSwitcherGroup["GEQ"][num].IsChecked = new bool?(true);
			}
			bool flag2 = (obj[10] == CommandConst.DEVE_PAGE_HOME && obj[11] > 16 && obj[11] < 25) || obj[11] == 30;
			if (flag2)
			{
				int num2 = (int)(obj[11] - 17);
				bool flag3 = obj[11] == 30;
				if (flag3)
				{
					num2 = 8;
				}
				GEQ.SelectedGEQPageIndex = (byte)num2;
				GEQ.SelectedGEQDeviceIndex = this._GEQIndexDeviceToPage[num2];
				this.UpdateGeqChindex(num2.ToString(), true);
				JSwitcher.JSwitcherGroup["GEQ"][num2].IsChecked = new bool?(true);
			}
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000D050 File Offset: 0x0000B250
		private void UpdateGEQExecute(byte[] obj)
		{
			int num = (int)this._GEQIndexDeviceToPage[(int)obj[11]];
			GEQ.SelectedGEQPageIndex = (byte)num;
			GEQ.SelectedGEQDeviceIndex = obj[11];
			int startIndex = 12;
			this._GEQInfo = GEQData.GEQDatas.GEQInfoDictionary[num.ToString()];
			int num2;
			for (int i = 0; i < this._GEQInfo.GEQArray.Count; i++)
			{
				GEQFrequenceValue geqfrequenceValue = this._GEQInfo.GEQArray[i];
				num2 = startIndex;
				startIndex = num2 + 1;
				geqfrequenceValue.GainValue = (int)obj[num2];
			}
			GEQInfo geqinfo = this._GEQInfo;
			num2 = startIndex;
			startIndex = num2 + 1;
			geqinfo.Bypass = obj[num2] == 1;
			this.UpdateGeqChindex(num.ToString(), true);
			JSwitcher.JSwitcherGroup["GEQ"][num].IsChecked = new bool?(true);
			Action <>9__2;
			Task.Factory.StartNew(delegate
			{
				for (int j = 0; j < 2; j++)
				{
					Thread.Sleep(50);
					Dispatcher dispatcher = this.Dispatcher;
					Action action;
					if ((action = <>9__2) == null)
					{
						action = (<>9__2 = delegate
						{
							this.RefreshFreqGain();
						});
					}
					dispatcher.BeginInvoke(action, new object[0]);
				}
			}).ContinueWith<int>((Task _) => startIndex = 0);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000D174 File Offset: 0x0000B374
		private void ReadCurrentSceneExecute(byte[] obj)
		{
			int num = 3697;
			for (int i = 0; i < 9; i++)
			{
				int num2 = (int)this._GEQIndexDeviceToPage[i + 1];
				GEQInfo geqinfo = GEQData.GEQDatas.GEQInfoDictionary[num2.ToString()];
				List<GEQFrequenceValue> geqarray = GEQData.GEQDatas.GEQInfoDictionary[num2.ToString()].GEQArray;
				for (int j = 0; j < geqarray.Count; j++)
				{
					geqarray[j].GainValue = (int)obj[num++];
				}
				geqinfo.Bypass = obj[num++] == 1;
			}
			this.UpdateGeqChindex(GEQ.SelectedGEQPageIndex.ToString(), true);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000D240 File Offset: 0x0000B440
		private void GEQ_Page_Click(object sender, RoutedEventArgs e)
		{
			JSwitcher jswitcher = sender as JSwitcher;
			this.UpdateGeqChindex(jswitcher.Tag.ToString(), true);
			int index = int.Parse(jswitcher.Tag.ToString(), NumberStyles.Integer, CultureInfo.InvariantCulture);
			bool flag = PageData.UiIndex1 == CommandConst.DEVE_PAGE_HOME;
			if (flag)
			{
				bool flag2 = PageData.UiIndex2 <= 16 || PageData.UiIndex2 >= 25;
				if (flag2)
				{
					UpStreamCommand.SendSynchronizePage(CommandConst.DEVE_PAGE_HOME, GEQData.DeviceGEQAuxToChannelAuxDictionary[this._GEQIndexPageToDevice[index]], 0, 0);
				}
			}
			UpStreamCommand.SendSynchronizePage(CommandConst.DEVE_PAGE_GEQ, this._GEQIndexPageToDevice[index], 0, 0);
			Action <>9__2;
			Task.Factory.StartNew(delegate
			{
				for (int i = 0; i < 7; i++)
				{
					Thread.Sleep(50);
					Dispatcher dispatcher = this.Dispatcher;
					Action action;
					if ((action = <>9__2) == null)
					{
						action = (<>9__2 = delegate
						{
							this.RefreshFreqGain();
						});
					}
					dispatcher.BeginInvoke(action, new object[0]);
				}
			}).ContinueWith<int>((Task _) => index = 0);
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000D328 File Offset: 0x0000B528
		private void RefreshPageClick()
		{
			foreach (object obj in this.slidergrid.Children)
			{
				bool flag = obj.GetType() == typeof(T2208.MyUserControls.Slider);
				if (flag)
				{
					T2208.MyUserControls.Slider slider = obj as T2208.MyUserControls.Slider;
					int num = (int)Convert.ToInt16(slider.Tag);
					slider.IsLastUpdate = false;
					slider.ThumbImage = new BitmapImage(new Uri("pack://application:,,,/T2208;component/Images/ThumbVertical.png"));
					slider.LastUpdateThumb = new BitmapImage(new Uri("pack://application:,,,/T2208;component/Images/ThumbVertical.png"));
					bool flag2 = num == GEQ.CurrentIndex;
					if (flag2)
					{
						slider.IsLastUpdate = true;
						slider.ThumbImage = new BitmapImage(new Uri("pack://application:,,,/T2208;component/Images/geqThumbFocus.png"));
						slider.LastUpdateThumb = new BitmapImage(new Uri("pack://application:,,,/T2208;component/Images/geqThumbFocus.png"));
					}
				}
			}
			int gainValue = this._GEQInfo.GEQArray[GEQ.CurrentIndex].GainValue;
			this.FreqValue.Text = Final.FreqValueTable[GEQ.CurrentIndex];
			this.Text_GainValue.Text = Convert.ToInt32(gainValue) - 24 + "dB";
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000D494 File Offset: 0x0000B694
		public void UpdateGeqChindex(string index, bool updateFocus = true)
		{
			GEQData.PresentGEQIndex = byte.Parse(index);
			ViewModelMessager.Messeager.Notify(ViewModelMessager.UpdateDSPGEQFXIndex);
			this._GEQInfo = GEQData.GEQDatas.GEQInfoDictionary[index];
			this.BypassBtn.IsChecked = new bool?(this._GEQInfo.Bypass);
			this.slidergrid.IsEnabled = !this._GEQInfo.Bypass;
			int num = int.Parse(index, NumberStyles.Integer, CultureInfo.InvariantCulture);
			bool isLoaded = base.IsLoaded;
			if (isLoaded)
			{
				if (updateFocus)
				{
					this.Refresh();
				}
			}
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000D530 File Offset: 0x0000B730
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			bool flag = MessageBox.Show(LocalizationManager.GetString("Str_FlatWarning"), LocalizationManager.GetString("Str_Tips"), MessageBoxButton.YesNo) == MessageBoxResult.Yes;
			if (flag)
			{
				bool isConnected = MainData.ConnectionModel.IsConnected;
				if (isConnected)
				{
					UpStreamCommand.SendGEQChange(this._GEQInfo, this._GEQIndexPageToDevice[this._GEQInfo.Index], true);
					this.FlatGeq(this._GEQInfo.Index);
					int gainValue = this._GEQInfo.GEQArray[GEQ.CurrentIndex].GainValue;
					this.FreqValue.Text = Final.FreqValueTable[GEQ.CurrentIndex];
					this.Text_GainValue.Text = Convert.ToInt32(gainValue) - 24 + "dB";
				}
				else
				{
					this.FlatGeq(this._GEQInfo.Index);
					int gainValue2 = this._GEQInfo.GEQArray[GEQ.CurrentIndex].GainValue;
					this.FreqValue.Text = Final.FreqValueTable[GEQ.CurrentIndex];
					this.Text_GainValue.Text = Convert.ToInt32(gainValue2) - 24 + "dB";
				}
			}
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000D66C File Offset: 0x0000B86C
		private void Cs_SliderValueChanged(object sender, int value)
		{
			T2208.MyUserControls.Slider slider = sender as T2208.MyUserControls.Slider;
			int num = (int)Convert.ToInt16(slider.Tag);
			bool isConnected = MainData.ConnectionModel.IsConnected;
			if (isConnected)
			{
				bool flag = !this.HasSend;
				if (flag)
				{
					this._GEQInfo.GEQArray[num].GainValue = value;
					UpStreamCommand.SendGEQChange(this._GEQInfo, this._GEQIndexPageToDevice[this._GEQInfo.Index], false);
					this.HasSend = true;
					Task.Factory.StartNew(delegate
					{
						Thread.Sleep(200);
					}).ContinueWith<bool>((Task _) => this.HasSend = false);
				}
			}
			foreach (object obj in this.slidergrid.Children)
			{
				bool flag2 = obj.GetType() == typeof(T2208.MyUserControls.Slider);
				if (flag2)
				{
					T2208.MyUserControls.Slider slider2 = obj as T2208.MyUserControls.Slider;
					slider2.ThumbImage = new BitmapImage(new Uri("pack://application:,,,/T2208;component/Images/ThumbVertical.png"));
					slider2.LastUpdateThumb = new BitmapImage(new Uri("pack://application:,,,/T2208;component/Images/geqThumbFocus.png"));
				}
			}
			this._GEQInfo.GEQArray[num].GainValue = value;
			this.UpdateoneGEQ(num, true);
			this.FreqValue.Text = Final.FreqValueTable[Convert.ToInt32(slider.Tag)];
			this.Text_GainValue.Text = Convert.ToInt32(value) - 24 + "dB";
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000D834 File Offset: 0x0000BA34
		public void UpdateAllGEQ()
		{
			for (int i = 0; i < 31; i++)
			{
				this.UpdateoneGEQ(i, true);
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000D860 File Offset: 0x0000BA60
		public void UpdateoneGEQ(int eqindex, bool IsShowAnimation = true)
		{
			int gainValue = this._GEQInfo.GEQArray[eqindex].GainValue;
			bool flag = !IsShowAnimation;
			if (flag)
			{
				this.Sliders[eqindex].BeginAnimation(T2208.MyUserControls.Slider.ValueProperty, null);
				this.Sliders[eqindex].Value = gainValue;
			}
			else
			{
				Int32Animation int32Animation = new Int32Animation();
				int32Animation.From = new int?((int)((short)this.Sliders[eqindex].Value));
				int32Animation.To = new int?((int)((short)gainValue));
				int32Animation.Duration = TimeSpan.FromSeconds((double)Math.Abs(gainValue - this.Sliders[eqindex].Value) * 0.01);
				int32Animation.FillBehavior = FillBehavior.HoldEnd;
				int32Animation.EasingFunction = new CircleEase
				{
					EasingMode = EasingMode.EaseOut
				};
				this.story.Children.Add(int32Animation);
				Storyboard.SetTarget(int32Animation, this.Sliders[eqindex]);
				Storyboard.SetTargetProperty(int32Animation, new PropertyPath(T2208.MyUserControls.Slider.ValueProperty));
				this.story.Begin(this.slidergrid);
				this.story.Children.Remove(int32Animation);
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00003DD0 File Offset: 0x00001FD0
		public void Refresh()
		{
			this.UpdateAllGEQ();
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000D98C File Offset: 0x0000BB8C
		public void FlatGeq(int chnumber)
		{
			for (int i = 0; i < 31; i++)
			{
				this._GEQInfo.GEQArray[i].GainValue = 24;
			}
			this.UpdateAllGEQ();
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000D9D0 File Offset: 0x0000BBD0
		private void Bypass_Click(object sender, RoutedEventArgs e)
		{
			this._GEQInfo.Bypass = this.BypassBtn.IsChecked.Value;
			bool isConnected = MainData.ConnectionModel.IsConnected;
			if (isConnected)
			{
				UpStreamCommand.SendGEQChange(this._GEQInfo, this._GEQIndexPageToDevice[this._GEQInfo.Index], false);
			}
			this.slidergrid.IsEnabled = !this._GEQInfo.Bypass;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00003DDA File Offset: 0x00001FDA
		protected override void OnRender(DrawingContext drawingContext)
		{
			base.OnRender(drawingContext);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00003DE5 File Offset: 0x00001FE5
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			this.Refresh();
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000DA48 File Offset: 0x0000BC48
		private new void GotFocusEvent(object sender, RoutedEventArgs e)
		{
			T2208.MyUserControls.Slider slider = sender as T2208.MyUserControls.Slider;
			GEQ.CurrentIndex = Convert.ToInt32(slider.Tag);
			int gainValue = this._GEQInfo.GEQArray[GEQ.CurrentIndex].GainValue;
			this.FreqValue.Text = Final.FreqValueTable[GEQ.CurrentIndex];
			this.Text_GainValue.Text = Convert.ToInt32(gainValue) - 24 + "dB";
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000DAC4 File Offset: 0x0000BCC4
		private void RefreshFreqGain()
		{
			int gainValue = this._GEQInfo.GEQArray[GEQ.CurrentIndex].GainValue;
			this.FreqValue.Text = Final.FreqValueTable[GEQ.CurrentIndex];
			this.Text_GainValue.Text = Convert.ToInt32(gainValue) - 24 + "dB";
		}

		// Token: 0x0400006D RID: 109
		private T2208.MyUserControls.Slider[] Sliders = new T2208.MyUserControls.Slider[31];

		// Token: 0x0400006E RID: 110
		private Label[] Tb = new Label[31];

		// Token: 0x0400006F RID: 111
		private JSwitcher[] switcher = new JSwitcher[3];

		// Token: 0x04000070 RID: 112
		private GEQInfo _GEQInfo = null;

		// Token: 0x04000071 RID: 113
		private byte[] _GEQIndexDeviceToPage = new byte[] { 0, 8, 4, 5, 6, 7, 0, 1, 2, 3 };

		// Token: 0x04000072 RID: 114
		private byte[] _GEQIndexPageToDevice = new byte[] { 6, 7, 8, 9, 2, 3, 4, 5, 1 };

		// Token: 0x04000074 RID: 116
		private static byte s_selectedGEQDeviceIndex = 6;

		// Token: 0x04000075 RID: 117
		private bool HasSend = false;

		// Token: 0x04000076 RID: 118
		private Storyboard story = new Storyboard();

		// Token: 0x04000077 RID: 119
		public static int CurrentIndex = 30;
	}
}
