using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using T2208.Views;

namespace T2208.MyUserControls
{
	// Token: 0x02000052 RID: 82
	public partial class Slider : UserControl
	{
		// Token: 0x060003EC RID: 1004 RVA: 0x0001B214 File Offset: 0x00019414
		public Slider()
		{
			this.InitializeComponent();
			this.thumb.Height = Slider.thumbHeight;
			this.thumb.Width = Slider.thumbWidth;
			base.PreviewMouseLeftButtonDown += this.Slider_MouseLeftButtonDown;
			base.Focusable = true;
			Slider.InitializeCommands();
			base.PreviewMouseMove += this.Slider_MouseMove;
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x0001B2D0 File Offset: 0x000194D0
		private void Slider_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = !this.IsDrag && this.IsShowGEQ;
			if (flag)
			{
				bool flag2 = e.LeftButton == MouseButtonState.Pressed;
				if (flag2)
				{
				}
			}
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x0001B304 File Offset: 0x00019504
		private static void InitializeCommands()
		{
			RoutedCommand routedCommand = new RoutedCommand("IncreaseSmall", typeof(Slider));
			RoutedCommand routedCommand2 = new RoutedCommand("DecreaseSmall", typeof(Slider));
			RoutedCommand routedCommand3 = new RoutedCommand("IncreaseLarge", typeof(Slider));
			RoutedCommand routedCommand4 = new RoutedCommand("DecreaseLarge", typeof(Slider));
			CommandManager.RegisterClassCommandBinding(typeof(Slider), new CommandBinding(routedCommand3, new ExecutedRoutedEventHandler(Slider.OnIncreaseLargeCommand)));
			CommandManager.RegisterClassCommandBinding(typeof(Slider), new CommandBinding(routedCommand4, new ExecutedRoutedEventHandler(Slider.OnDecreaseLargeCommand)));
			CommandManager.RegisterClassCommandBinding(typeof(Slider), new CommandBinding(routedCommand, new ExecutedRoutedEventHandler(Slider.OnIncreaseSmallCommand)));
			CommandManager.RegisterClassCommandBinding(typeof(Slider), new CommandBinding(routedCommand2, new ExecutedRoutedEventHandler(Slider.OnDecreaseSmallCommand)));
			CommandManager.RegisterClassInputBinding(typeof(Slider), new InputBinding(routedCommand3, new KeyGesture(Key.Next)));
			CommandManager.RegisterClassInputBinding(typeof(Slider), new InputBinding(routedCommand4, new KeyGesture(Key.Prior)));
			CommandManager.RegisterClassInputBinding(typeof(Slider), new InputBinding(routedCommand, new KeyGesture(Key.Up)));
			CommandManager.RegisterClassInputBinding(typeof(Slider), new InputBinding(routedCommand, new KeyGesture(Key.Right)));
			CommandManager.RegisterClassInputBinding(typeof(Slider), new InputBinding(routedCommand2, new KeyGesture(Key.Down)));
			CommandManager.RegisterClassInputBinding(typeof(Slider), new InputBinding(routedCommand2, new KeyGesture(Key.Left)));
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x000063DF File Offset: 0x000045DF
		protected override void OnMouseUp(MouseButtonEventArgs e)
		{
			base.Focus();
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x0001B49C File Offset: 0x0001969C
		private void Slider_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			base.Focus();
			bool flag = !this.IsVertical;
			if (flag)
			{
				Slider.SliderHeight = base.ActualHeight - this.thumb.Height;
				double num = e.GetPosition(this).Y;
				num = Math.Min(Math.Max(num, 0.0), Slider.SliderHeight);
				int num2 = (int)((Slider.SliderHeight - num) / Slider.SliderHeight * (double)(this.Maximum - this.Minimum) + (double)this.Minimum);
				bool flag2 = this.valueTemp == num2;
				if (!flag2)
				{
					this.valueTemp = num2;
					Slider.SliderValueChanged onKaSliderValueChanged = this.OnKaSliderValueChanged;
					if (onKaSliderValueChanged != null)
					{
						onKaSliderValueChanged(this, num2);
					}
				}
			}
			else
			{
				Slider.SliderHeight = base.ActualWidth - this.thumb.Width;
				double num3 = e.GetPosition(this).X;
				num3 = Math.Min(Math.Max(num3, 0.0), Slider.SliderHeight);
				int num4 = (int)(num3 / Slider.SliderHeight * (double)(this.Maximum - this.Minimum) + (double)this.Minimum);
				bool flag3 = this.valueTemp == num4;
				if (!flag3)
				{
					this.valueTemp = num4;
					Slider.SliderValueChanged onKaSliderValueChanged2 = this.OnKaSliderValueChanged;
					if (onKaSliderValueChanged2 != null)
					{
						onKaSliderValueChanged2(this, num4);
					}
				}
			}
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x000063E9 File Offset: 0x000045E9
		protected override void OnGotFocus(RoutedEventArgs e)
		{
			base.OnGotFocus(e);
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x000063F4 File Offset: 0x000045F4
		protected override void OnLostFocus(RoutedEventArgs e)
		{
			base.OnLostFocus(e);
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x060003F3 RID: 1011 RVA: 0x0001B5F8 File Offset: 0x000197F8
		// (set) Token: 0x060003F4 RID: 1012 RVA: 0x000063FF File Offset: 0x000045FF
		public int Maximum
		{
			get
			{
				return (int)base.GetValue(Slider.MaximumProperty);
			}
			set
			{
				base.SetValue(Slider.MaximumProperty, value);
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x060003F5 RID: 1013 RVA: 0x0001B61C File Offset: 0x0001981C
		// (set) Token: 0x060003F6 RID: 1014 RVA: 0x00006414 File Offset: 0x00004614
		public int Minimum
		{
			get
			{
				return (int)base.GetValue(Slider.MinimumProperty);
			}
			set
			{
				base.SetValue(Slider.MinimumProperty, value);
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x060003F7 RID: 1015 RVA: 0x0001B640 File Offset: 0x00019840
		// (set) Token: 0x060003F8 RID: 1016 RVA: 0x00006429 File Offset: 0x00004629
		public bool IsVerticalSlider
		{
			get
			{
				return (bool)base.GetValue(Slider.isVerticalSliderProperty);
			}
			set
			{
				base.SetValue(Slider.isVerticalSliderProperty, value);
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x060003F9 RID: 1017 RVA: 0x0001B664 File Offset: 0x00019864
		// (set) Token: 0x060003FA RID: 1018 RVA: 0x0000643E File Offset: 0x0000463E
		public bool IsVertical
		{
			get
			{
				return (bool)base.GetValue(Slider.IsVerticalProperty);
			}
			set
			{
				base.SetValue(Slider.IsVerticalProperty, value);
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x060003FB RID: 1019 RVA: 0x0001B688 File Offset: 0x00019888
		// (set) Token: 0x060003FC RID: 1020 RVA: 0x00006453 File Offset: 0x00004653
		public bool IsShowStr
		{
			get
			{
				return (bool)base.GetValue(Slider.isShowStrSliderProperty);
			}
			set
			{
				base.SetValue(Slider.isShowStrSliderProperty, value);
			}
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x060003FD RID: 1021 RVA: 0x0001B6AC File Offset: 0x000198AC
		// (set) Token: 0x060003FE RID: 1022 RVA: 0x00006468 File Offset: 0x00004668
		public ImageSource Imagethumb
		{
			get
			{
				return (ImageSource)base.GetValue(Slider.thumbProperty);
			}
			set
			{
				base.SetValue(Slider.thumbProperty, value);
			}
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x0001B6D0 File Offset: 0x000198D0
		private static void OnThumbChange(DependencyObject obj, DependencyPropertyChangedEventArgs args)
		{
			Slider slider = obj as Slider;
			bool flag = slider == null;
			if (!flag)
			{
				slider.InvalidateVisual();
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x06000400 RID: 1024 RVA: 0x0001B6F8 File Offset: 0x000198F8
		// (set) Token: 0x06000401 RID: 1025 RVA: 0x00006478 File Offset: 0x00004678
		public ImageSource ThumbImage
		{
			get
			{
				return (ImageSource)base.GetValue(Slider.ThumbImageProperty);
			}
			set
			{
				base.SetValue(Slider.ThumbImageProperty, value);
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06000402 RID: 1026 RVA: 0x0001B71C File Offset: 0x0001991C
		// (set) Token: 0x06000403 RID: 1027 RVA: 0x00006488 File Offset: 0x00004688
		public ImageSource ImagethumbBack
		{
			get
			{
				return (ImageSource)base.GetValue(Slider.thumbBackProperty);
			}
			set
			{
				base.SetValue(Slider.thumbBackProperty, value);
			}
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x0001B6D0 File Offset: 0x000198D0
		private static void OnThumbBackChange(DependencyObject obj, DependencyPropertyChangedEventArgs args)
		{
			Slider slider = obj as Slider;
			bool flag = slider == null;
			if (!flag)
			{
				slider.InvalidateVisual();
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06000405 RID: 1029 RVA: 0x0001B740 File Offset: 0x00019940
		// (set) Token: 0x06000406 RID: 1030 RVA: 0x00006498 File Offset: 0x00004698
		public ImageSource ThumbBackgroundImage
		{
			get
			{
				return (ImageSource)base.GetValue(Slider.ThumbBackgroundImageProperty);
			}
			set
			{
				base.SetValue(Slider.ThumbBackgroundImageProperty, value);
			}
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000407 RID: 1031 RVA: 0x0001B764 File Offset: 0x00019964
		// (remove) Token: 0x06000408 RID: 1032 RVA: 0x0001B79C File Offset: 0x0001999C
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event Slider.SliderValueChanged OnKaSliderValueChanged;

		// Token: 0x06000409 RID: 1033 RVA: 0x0001B7D4 File Offset: 0x000199D4
		private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Slider slider = d as Slider;
			bool isShowGEQ = slider.IsShowGEQ;
			if (isShowGEQ)
			{
				slider.UpdateCs_SliderGroup();
				slider.IsLastUpdate = true;
			}
			slider.InvalidateVisual();
			GEQ.CurrentIndex = Convert.ToInt32(slider.Tag);
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x0600040A RID: 1034 RVA: 0x0001B81C File Offset: 0x00019A1C
		// (set) Token: 0x0600040B RID: 1035 RVA: 0x000064A8 File Offset: 0x000046A8
		public int Value
		{
			get
			{
				return (int)base.GetValue(Slider.ValueProperty);
			}
			set
			{
				base.SetValue(Slider.ValueProperty, Math.Min(this.Maximum, value));
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x0600040C RID: 1036 RVA: 0x0001B840 File Offset: 0x00019A40
		// (set) Token: 0x0600040D RID: 1037 RVA: 0x000064C8 File Offset: 0x000046C8
		public double LineWidth
		{
			get
			{
				return (double)base.GetValue(Slider.LineWidthPropertyProperty);
			}
			set
			{
				base.SetValue(Slider.LineWidthPropertyProperty, value);
			}
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x0001B864 File Offset: 0x00019A64
		private static void OnLineWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Slider slider = d as Slider;
			slider.InvalidateVisual();
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x0600040F RID: 1039 RVA: 0x0001B880 File Offset: 0x00019A80
		// (set) Token: 0x06000410 RID: 1040 RVA: 0x000064DD File Offset: 0x000046DD
		public string MarkStr
		{
			get
			{
				return (string)base.GetValue(Slider.MarkStrProperty);
			}
			set
			{
				base.SetValue(Slider.MarkStrProperty, value);
			}
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x0001B864 File Offset: 0x00019A64
		private static void OnMarkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Slider slider = d as Slider;
			slider.InvalidateVisual();
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06000412 RID: 1042 RVA: 0x0001B8A4 File Offset: 0x00019AA4
		// (set) Token: 0x06000413 RID: 1043 RVA: 0x000064ED File Offset: 0x000046ED
		public bool IsShowGEQ
		{
			get
			{
				return (bool)base.GetValue(Slider.IsShowGEQProperty);
			}
			set
			{
				base.SetValue(Slider.IsShowGEQProperty, value);
			}
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x0001B864 File Offset: 0x00019A64
		private static void OnShowGEQChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Slider slider = d as Slider;
			slider.InvalidateVisual();
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06000415 RID: 1045 RVA: 0x0001B8C8 File Offset: 0x00019AC8
		// (set) Token: 0x06000416 RID: 1046 RVA: 0x00006502 File Offset: 0x00004702
		public bool IsShowGEQStr
		{
			get
			{
				return (bool)base.GetValue(Slider.IsShowGEQStrProperty);
			}
			set
			{
				base.SetValue(Slider.IsShowGEQStrProperty, value);
			}
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x0001B864 File Offset: 0x00019A64
		private static void OnShowGEQStrChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Slider slider = d as Slider;
			slider.InvalidateVisual();
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06000418 RID: 1048 RVA: 0x0001B8EC File Offset: 0x00019AEC
		// (set) Token: 0x06000419 RID: 1049 RVA: 0x00006517 File Offset: 0x00004717
		public SolidColorBrush SliderBackgroung
		{
			get
			{
				return (SolidColorBrush)base.GetValue(Slider.SliderBackgroungProperty);
			}
			set
			{
				base.SetValue(Slider.SliderBackgroungProperty, value);
			}
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x0001B864 File Offset: 0x00019A64
		private static void OnSliderBackgroungChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Slider slider = d as Slider;
			slider.InvalidateVisual();
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x0600041B RID: 1051 RVA: 0x0001B910 File Offset: 0x00019B10
		// (set) Token: 0x0600041C RID: 1052 RVA: 0x00006527 File Offset: 0x00004727
		public SolidColorBrush SliderBorderBrush
		{
			get
			{
				return (SolidColorBrush)base.GetValue(Slider.SliderBorderBrushProperty);
			}
			set
			{
				base.SetValue(Slider.SliderBorderBrushProperty, value);
			}
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x0001B864 File Offset: 0x00019A64
		private static void OnSliderBorderBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Slider slider = d as Slider;
			slider.InvalidateVisual();
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x0600041E RID: 1054 RVA: 0x0001B934 File Offset: 0x00019B34
		// (set) Token: 0x0600041F RID: 1055 RVA: 0x00006537 File Offset: 0x00004737
		public double SliderRadio
		{
			get
			{
				return (double)base.GetValue(Slider.SliderRadioProperty);
			}
			set
			{
				base.SetValue(Slider.SliderRadioProperty, value);
			}
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x0001B864 File Offset: 0x00019A64
		private static void OnSliderRadioChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Slider slider = d as Slider;
			slider.InvalidateVisual();
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x0001B958 File Offset: 0x00019B58
		protected override void OnRender(DrawingContext dc)
		{
			base.OnRender(dc);
			double actualWidth = base.ActualWidth;
			double actualHeight = base.ActualHeight;
			dc.DrawRectangle(Brushes.Transparent, null, new Rect(0.0, 0.0, actualWidth, actualHeight));
			bool flag = !this.IsShowGEQ;
			if (flag)
			{
				bool flag2 = !this.IsVertical;
				if (flag2)
				{
					bool isShowStr = this.IsShowStr;
					if (isShowStr)
					{
						double actualHeight2 = base.ActualHeight;
						double num = 9.0;
						string[] array = this.MarkStr.Split(new char[] { ',' });
						int num2 = array.Length;
						double num3 = (base.ActualHeight - num) / (double)(num2 - 3);
						FormattedText formattedText = new FormattedText(array[0], Slider.CIR, FlowDirection.RightToLeft, new Typeface("Arial"), this.fontSize + 1.0, Brushes.White);
						dc.DrawText(formattedText, new Point(this.markXoffset + 7.0, -num - 1.0));
						for (int i = 0; i < num2 - 2; i++)
						{
							formattedText = new FormattedText(array[i + 1], Slider.CIR, FlowDirection.RightToLeft, new Typeface("Arial"), this.fontSize, Brushes.White);
							dc.DrawText(formattedText, new Point(this.markXoffset, num3 * (double)i));
						}
						formattedText = new FormattedText(array[num2 - 1], Slider.CIR, FlowDirection.RightToLeft, new Typeface("Arial"), this.fontSize, Brushes.White);
						dc.DrawText(formattedText, new Point(this.markXoffset + 7.0, num3 * (double)(num2 - 3) + num + 1.0));
						this.thumb.Width = 21.0;
						this.thumb.Height = 30.0;
						bool flag3 = this.ThumbBackgroundImage != null;
						if (flag3)
						{
							dc.DrawImage(this.ThumbBackgroundImage, new Rect(base.ActualWidth / 2.0 - this.LineWidth / 2.0, 1.0, this.LineWidth, base.ActualHeight - 2.0));
						}
						else
						{
							Pen pen = new Pen(Brushes.LightGray, 1.0);
							pen.Freeze();
							dc.DrawRoundedRectangle(this.BRUSHES, pen, new Rect(base.ActualWidth / 2.0 - this.LineWidth / 2.0, 1.0, this.LineWidth, base.ActualHeight - 2.0), 3.0, 3.0);
						}
						Slider.SliderHeight = base.ActualHeight - this.thumb.Height;
						this.thumb.VerticalAlignment = VerticalAlignment.Top;
						this.thumb.HorizontalAlignment = HorizontalAlignment.Left;
						this.thumb.Margin = new Thickness(base.ActualWidth / 2.0 - this.thumb.Width / 2.0, (double)(this.Maximum - this.Value) * Slider.SliderHeight / (double)(this.Maximum - this.Minimum), 0.0, 0.0);
					}
					else
					{
						this.thumb.Width = 21.0;
						this.thumb.Height = 30.0;
						bool flag4 = this.ThumbBackgroundImage != null;
						if (flag4)
						{
							dc.DrawImage(this.ThumbBackgroundImage, new Rect(base.ActualWidth / 2.0 - this.LineWidth / 2.0, 1.0, this.LineWidth, base.ActualHeight - 2.0));
						}
						else
						{
							Pen pen2 = new Pen(Brushes.LightGray, 1.0);
							pen2.Freeze();
							dc.DrawRoundedRectangle(this.SliderBackgroung, pen2, new Rect(base.ActualWidth / 2.0 - this.LineWidth / 2.0, 1.0, this.LineWidth, base.ActualHeight - 2.0), 3.0, 3.0);
						}
						Slider.SliderHeight = base.ActualHeight - this.thumb.Height;
						this.thumb.VerticalAlignment = VerticalAlignment.Top;
						this.thumb.HorizontalAlignment = HorizontalAlignment.Center;
						this.thumb.Margin = new Thickness(base.ActualWidth / 2.0 - this.thumb.Width / 2.0, (double)(this.Maximum - this.Value) * Slider.SliderHeight / (double)(this.Maximum - this.Minimum), 0.0, 0.0);
					}
				}
				else
				{
					this.thumb.Width = 30.0;
					this.thumb.Height = 20.0;
					Slider.SliderHeight = base.ActualWidth - this.thumb.Width;
					double num4 = (double)(this.Value - this.Minimum) * Slider.SliderHeight / (double)(this.Maximum - this.Minimum);
					bool flag5 = this.ThumbBackgroundImage != null;
					if (flag5)
					{
						dc.DrawImage(this.ThumbBackgroundImage, new Rect(0.0, base.ActualHeight / 2.0 - this.LineWidth / 2.0, base.ActualWidth, this.LineWidth));
					}
					else
					{
						Pen pen3 = new Pen(this.SliderBorderBrush, 1.0);
						pen3.Freeze();
						dc.DrawRoundedRectangle(this.SliderBackgroung, pen3, new Rect(1.0, base.ActualHeight / 2.0 - this.LineWidth / 2.0, base.ActualWidth - 2.0, this.LineWidth), this.SliderRadio, this.SliderRadio);
					}
					this.thumb.VerticalAlignment = VerticalAlignment.Center;
					this.thumb.HorizontalAlignment = HorizontalAlignment.Left;
					this.thumb.Margin = new Thickness(num4, base.ActualHeight / 2.0 - this.thumb.Height / 2.0, 0.0, 0.0);
				}
			}
			else
			{
				this.thumb.Width = 18.0;
				this.thumb.Height = 16.0;
				Slider.SliderHeight = base.ActualHeight - this.thumb.Height;
				this.thumb.VerticalAlignment = VerticalAlignment.Top;
				this.thumb.HorizontalAlignment = HorizontalAlignment.Center;
				this.thumb.Margin = new Thickness(base.ActualWidth / 2.0 - this.thumb.Width / 2.0, (double)(this.Maximum - this.Value) * Slider.SliderHeight / (double)(this.Maximum - this.Minimum), 0.0, 0.0);
				bool flag6 = this.ThumbBackgroundImage != null;
				if (flag6)
				{
					dc.DrawImage(this.ThumbBackgroundImage, new Rect(base.ActualWidth / 2.0 - this.LineWidth / 2.0, 1.0, this.LineWidth, base.ActualHeight - 2.0));
				}
				else
				{
					dc.DrawRectangle(this.GeqBrush, null, new Rect(base.ActualWidth / 2.0 - this.LineWidth / 2.0, this.thumb.Height / 2.0, this.LineWidth, base.ActualHeight - this.thumb.Height));
					dc.DrawRectangle(Brushes.Lime, null, new Rect(base.ActualWidth / 2.0 - this.LineWidth / 2.0, this.thumb.Margin.Top + this.thumb.Height / 2.0, this.LineWidth, Slider.SliderHeight - this.thumb.Margin.Top));
				}
				bool isShowGEQStr = this.IsShowGEQStr;
				if (isShowGEQStr)
				{
					double num5 = 10.0 / (double)(this.Maximum * 5 / 2);
					double actualHeight3 = base.ActualHeight;
					double num6 = Slider.SliderHeight / (double)this.Maximum;
					Pen pen4 = new Pen(Brushes.White, 1.0);
					pen4.Freeze();
					Pen pen5 = new Pen(Brushes.White, 2.0);
					pen4.Freeze();
					for (int j = 0; j < this.Maximum / 2; j++)
					{
						dc.DrawLine(pen4, new Point(base.ActualWidth / 2.0 + 9.0 + 3.0 + num5 * (double)j, this.thumb.Height / 2.0 + (double)j * num6), new Point(base.ActualWidth / 2.0 + 18.0 + 2.0 - num5 * (double)j, this.thumb.Height / 2.0 + (double)j * num6));
					}
					for (int k = this.Maximum / 2; k < this.Maximum + 1; k++)
					{
						dc.DrawLine(pen4, new Point(base.ActualWidth / 2.0 + 9.0 + 3.0 + num5 * (double)(this.Maximum - k), this.thumb.Height / 2.0 + (double)k * num6), new Point(base.ActualWidth / 2.0 + 18.0 + 2.0 - num5 * (double)(this.Maximum - k), this.thumb.Height / 2.0 + (double)k * num6));
					}
					dc.DrawLine(pen5, new Point(base.ActualWidth / 2.0 + 9.0 + 2.0, this.thumb.Height / 2.0), new Point(base.ActualWidth / 2.0 + 19.0 + 2.0, this.thumb.Height / 2.0));
					dc.DrawLine(pen5, new Point(base.ActualWidth / 2.0 + 9.0 + 2.0, this.thumb.Height / 2.0 + (double)(this.Maximum / 2) * num6), new Point(base.ActualWidth / 2.0 + 19.0 + 2.0, this.thumb.Height / 2.0 + (double)(this.Maximum / 2) * num6));
					dc.DrawLine(pen5, new Point(base.ActualWidth / 2.0 + 9.0 + 2.0, this.thumb.Height / 2.0 + (double)this.Maximum * num6), new Point(base.ActualWidth / 2.0 + 19.0 + 2.0, this.thumb.Height / 2.0 + (double)this.Maximum * num6));
				}
			}
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x0001C638 File Offset: 0x0001A838
		private void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
		{
			this.IsDrag = true;
			bool flag = !this.IsVertical;
			if (flag)
			{
				Slider.SliderHeight = base.ActualHeight - this.thumb.Height;
				double num = this.thumb.Margin.Top + e.VerticalChange;
				num = Math.Min(Math.Max(num, 0.0), Slider.SliderHeight);
				int num2 = (int)((Slider.SliderHeight - num) / Slider.SliderHeight * (double)(this.Maximum - this.Minimum) + (double)this.Minimum);
				bool flag2 = this.Value == num2;
				if (!flag2)
				{
					Slider.SliderValueChanged onKaSliderValueChanged = this.OnKaSliderValueChanged;
					if (onKaSliderValueChanged != null)
					{
						onKaSliderValueChanged(this, num2);
					}
				}
			}
			else
			{
				Slider.SliderHeight = base.ActualWidth - this.thumb.Width;
				double num3 = this.thumb.Margin.Left + e.HorizontalChange;
				num3 = Math.Min(Math.Max(num3, 0.0), Slider.SliderHeight);
				int num4 = (int)(num3 / Slider.SliderHeight * (double)(this.Maximum - this.Minimum) + (double)this.Minimum);
				bool flag3 = this.Value == num4;
				if (!flag3)
				{
					Slider.SliderValueChanged onKaSliderValueChanged2 = this.OnKaSliderValueChanged;
					if (onKaSliderValueChanged2 != null)
					{
						onKaSliderValueChanged2(this, num4);
					}
				}
			}
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x0001C79C File Offset: 0x0001A99C
		private void Thumb_MouseWheel(object sender, MouseWheelEventArgs e)
		{
			bool flag = !base.IsFocused;
			if (!flag)
			{
				int num = Math.Min(Math.Max(this.Value + e.Delta / 120, this.Minimum), this.Maximum);
				bool flag2 = this.valueTemp == num;
				if (!flag2)
				{
					this.valueTemp = num;
					this.OnKaSliderValueChanged(this, num);
				}
			}
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x0000654C File Offset: 0x0000474C
		private void Ks_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			base.Opacity = (base.IsEnabled ? 1.0 : 0.23);
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x0001C804 File Offset: 0x0001AA04
		private static void OnIncreaseSmallCommand(object sender, ExecutedRoutedEventArgs e)
		{
			Slider slider = sender as Slider;
			bool flag = slider == null;
			if (!flag)
			{
				slider.OnIncreaseSmall();
			}
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x00006572 File Offset: 0x00004772
		private void OnIncreaseSmall()
		{
			Slider.SliderValueChanged onKaSliderValueChanged = this.OnKaSliderValueChanged;
			if (onKaSliderValueChanged != null)
			{
				onKaSliderValueChanged(this, Math.Min(this.Value + 1, this.Maximum));
			}
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x0001C82C File Offset: 0x0001AA2C
		private static void OnDecreaseSmallCommand(object sender, ExecutedRoutedEventArgs e)
		{
			Slider slider = sender as Slider;
			bool flag = slider == null;
			if (!flag)
			{
				slider.OnDecreaseSmall();
			}
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x0000659B File Offset: 0x0000479B
		private void OnDecreaseSmall()
		{
			Slider.SliderValueChanged onKaSliderValueChanged = this.OnKaSliderValueChanged;
			if (onKaSliderValueChanged != null)
			{
				onKaSliderValueChanged(this, Math.Max(this.Value - 1, this.Minimum));
			}
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x0001C854 File Offset: 0x0001AA54
		private static void OnIncreaseLargeCommand(object sender, ExecutedRoutedEventArgs e)
		{
			Slider slider = sender as Slider;
			bool flag = slider == null;
			if (!flag)
			{
				slider.OnIncreaseLarge();
			}
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x000065C4 File Offset: 0x000047C4
		private void OnIncreaseLarge()
		{
			Slider.SliderValueChanged onKaSliderValueChanged = this.OnKaSliderValueChanged;
			if (onKaSliderValueChanged != null)
			{
				onKaSliderValueChanged(this, Math.Min(this.Value + 10, this.Maximum));
			}
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x0001C87C File Offset: 0x0001AA7C
		private static void OnDecreaseLargeCommand(object sender, ExecutedRoutedEventArgs e)
		{
			Slider slider = sender as Slider;
			bool flag = slider == null;
			if (!flag)
			{
				slider.OnDecreaseLarge();
			}
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x000065EE File Offset: 0x000047EE
		private void OnDecreaseLarge()
		{
			Slider.SliderValueChanged onKaSliderValueChanged = this.OnKaSliderValueChanged;
			if (onKaSliderValueChanged != null)
			{
				onKaSliderValueChanged(this, Math.Max(this.Value - 10, this.Minimum));
			}
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x00006618 File Offset: 0x00004818
		private void Thumb_DragCompleted(object sender, DragCompletedEventArgs e)
		{
			this.IsDrag = false;
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x0600042E RID: 1070 RVA: 0x0001C8A4 File Offset: 0x0001AAA4
		// (set) Token: 0x0600042F RID: 1071 RVA: 0x00006488 File Offset: 0x00004688
		public ImageSource LastUpdateThumb
		{
			get
			{
				return (ImageSource)base.GetValue(Slider.LastUpdateThumbProperty);
			}
			set
			{
				base.SetValue(Slider.thumbBackProperty, value);
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x06000430 RID: 1072 RVA: 0x0001C8C8 File Offset: 0x0001AAC8
		// (set) Token: 0x06000431 RID: 1073 RVA: 0x00006622 File Offset: 0x00004822
		public bool IsLastUpdate
		{
			get
			{
				return (bool)base.GetValue(Slider.IsLastUpdateProperty);
			}
			set
			{
				base.SetValue(Slider.IsLastUpdateProperty, value);
			}
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x0001C8EC File Offset: 0x0001AAEC
		private static void IsLastUpdateChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Slider slider;
			bool flag = (slider = d as Slider) != null;
			if (flag)
			{
				bool isShowGEQ = slider.IsShowGEQ;
				if (isShowGEQ)
				{
					slider.UpdateCs_SliderGroup();
				}
				slider.InvalidateVisual();
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x0001C928 File Offset: 0x0001AB28
		// (set) Token: 0x06000434 RID: 1076 RVA: 0x00006637 File Offset: 0x00004837
		public string GroupName
		{
			get
			{
				return (string)base.GetValue(Slider.GroupNameProperty);
			}
			set
			{
				base.SetValue(Slider.GroupNameProperty, value);
			}
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x06000435 RID: 1077 RVA: 0x00006647 File Offset: 0x00004847
		// (set) Token: 0x06000436 RID: 1078 RVA: 0x0000664E File Offset: 0x0000484E
		public static Dictionary<string, List<Slider>> Cs_SliderGroup { get; set; } = new Dictionary<string, List<Slider>>();

		// Token: 0x06000437 RID: 1079 RVA: 0x0001C94C File Offset: 0x0001AB4C
		private static void GroupNameChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Slider slider;
			bool flag = (slider = d as Slider) != null;
			if (flag)
			{
				string text;
				bool flag2 = (text = e.NewValue as string) != null && !string.IsNullOrWhiteSpace(text);
				if (flag2)
				{
					List<Slider> list;
					bool flag3 = Slider.Cs_SliderGroup.TryGetValue(text, out list);
					if (flag3)
					{
						bool flag4 = !list.Contains(slider);
						if (flag4)
						{
							list.Add(slider);
						}
					}
					else
					{
						Slider.Cs_SliderGroup[text] = new List<Slider> { slider };
					}
				}
				string text2;
				bool flag5 = (text2 = e.OldValue as string) != null && !string.IsNullOrWhiteSpace(text2);
				if (flag5)
				{
					List<Slider> list2;
					bool flag6 = Slider.Cs_SliderGroup.TryGetValue(text2, out list2);
					if (flag6)
					{
						bool flag7 = list2.Contains(slider);
						if (flag7)
						{
							list2.Remove(slider);
						}
					}
				}
			}
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x0001CA34 File Offset: 0x0001AC34
		private void UpdateCs_SliderGroup()
		{
			List<Slider> list;
			bool flag = Slider.Cs_SliderGroup.TryGetValue(this.GroupName, out list) && list.Count != 0;
			if (flag)
			{
				int i = 0;
				while (i < list.Count)
				{
					bool flag2 = list[i] == null;
					if (flag2)
					{
						list.RemoveAt(i);
					}
					else
					{
						bool flag3 = list[i].IsLastUpdate && list[i] != this;
						if (flag3)
						{
							list[i].IsLastUpdate = false;
						}
						i++;
					}
				}
			}
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00003B79 File Offset: 0x00001D79
		private static void LastUpdateThumbChange(DependencyObject obj, DependencyPropertyChangedEventArgs args)
		{
		}

		// Token: 0x0400027E RID: 638
		public static double thumbHeight = 36.0;

		// Token: 0x0400027F RID: 639
		public static double thumbWidth = 20.0;

		// Token: 0x04000280 RID: 640
		public static int DefaultMaximum = 100;

		// Token: 0x04000281 RID: 641
		public static int DefaultMinimum = 0;

		// Token: 0x04000282 RID: 642
		public static int DefaultValueNum = 0;

		// Token: 0x04000283 RID: 643
		public static double SliderHeight;

		// Token: 0x04000284 RID: 644
		private Brush GeqBrush = Brushes.Black;

		// Token: 0x04000285 RID: 645
		public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(int), typeof(Slider), new PropertyMetadata(Slider.DefaultMaximum, null));

		// Token: 0x04000286 RID: 646
		public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum", typeof(int), typeof(Slider), new PropertyMetadata(Slider.DefaultMinimum, null));

		// Token: 0x04000287 RID: 647
		public static readonly DependencyProperty isVerticalSliderProperty = DependencyProperty.Register("IsVerticalSlider", typeof(bool), typeof(Slider), new PropertyMetadata(true));

		// Token: 0x04000288 RID: 648
		public static readonly DependencyProperty IsVerticalProperty = DependencyProperty.Register("IsVertical", typeof(bool), typeof(Slider), new PropertyMetadata(true));

		// Token: 0x04000289 RID: 649
		private const bool DefaultIsShowStr = true;

		// Token: 0x0400028A RID: 650
		public static readonly DependencyProperty isShowStrSliderProperty = DependencyProperty.Register("IsShowStr", typeof(bool), typeof(Slider), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.None, null));

		// Token: 0x0400028B RID: 651
		public static readonly DependencyProperty thumbProperty = DependencyProperty.Register("Imagethumb", typeof(ImageSource), typeof(Slider), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(Slider.OnThumbChange)));

		// Token: 0x0400028C RID: 652
		public static readonly DependencyProperty ThumbImageProperty = DependencyProperty.Register("ThumbImage", typeof(ImageSource), typeof(Slider), new PropertyMetadata(null, new PropertyChangedCallback(Slider.OnThumbChange)));

		// Token: 0x0400028D RID: 653
		public static readonly DependencyProperty thumbBackProperty = DependencyProperty.Register("ImagethumbBack", typeof(ImageSource), typeof(Slider), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(Slider.OnThumbBackChange)));

		// Token: 0x0400028E RID: 654
		public static readonly DependencyProperty ThumbBackgroundImageProperty = DependencyProperty.Register("ThumbBackgroundImage", typeof(ImageSource), typeof(Slider), new PropertyMetadata(null, new PropertyChangedCallback(Slider.OnThumbBackChange)));

		// Token: 0x04000290 RID: 656
		public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(int), typeof(Slider), new PropertyMetadata(Slider.DefaultValueNum, new PropertyChangedCallback(Slider.OnValueChanged)));

		// Token: 0x04000291 RID: 657
		public static readonly DependencyProperty LineWidthPropertyProperty = DependencyProperty.Register("LineWidth", typeof(double), typeof(Slider), new PropertyMetadata(8.0, new PropertyChangedCallback(Slider.OnLineWidthChanged)));

		// Token: 0x04000292 RID: 658
		private const string DefaultMarkStr = " ,  , 10+, 6+, 0, 6-, 9-, 13-, 18-, 25-, 70-,OFF, ";

		// Token: 0x04000293 RID: 659
		public static readonly DependencyProperty MarkStrProperty = DependencyProperty.Register("MarkStr", typeof(string), typeof(Slider), new PropertyMetadata(" ,  , 10+, 6+, 0, 6-, 9-, 13-, 18-, 25-, 70-,OFF, ", new PropertyChangedCallback(Slider.OnMarkChanged)));

		// Token: 0x04000294 RID: 660
		private const bool DefaultIsShowGEQ = false;

		// Token: 0x04000295 RID: 661
		public static readonly DependencyProperty IsShowGEQProperty = DependencyProperty.Register("IsShowGEQ", typeof(bool), typeof(Slider), new PropertyMetadata(false, new PropertyChangedCallback(Slider.OnShowGEQChanged)));

		// Token: 0x04000296 RID: 662
		private const bool DefaultIsShowGEQStr = true;

		// Token: 0x04000297 RID: 663
		public static readonly DependencyProperty IsShowGEQStrProperty = DependencyProperty.Register("IsShowGEQStr", typeof(bool), typeof(Slider), new PropertyMetadata(true, new PropertyChangedCallback(Slider.OnShowGEQStrChanged)));

		// Token: 0x04000298 RID: 664
		private static SolidColorBrush DefaultBackgroung = Brushes.Black;

		// Token: 0x04000299 RID: 665
		public static readonly DependencyProperty SliderBackgroungProperty = DependencyProperty.Register("SliderBackgroung", typeof(SolidColorBrush), typeof(Slider), new PropertyMetadata(Slider.DefaultBackgroung, new PropertyChangedCallback(Slider.OnSliderBackgroungChanged)));

		// Token: 0x0400029A RID: 666
		private static SolidColorBrush DefaultBorderBrush = Brushes.LightGray;

		// Token: 0x0400029B RID: 667
		public static readonly DependencyProperty SliderBorderBrushProperty = DependencyProperty.Register("SliderBorderBrush", typeof(SolidColorBrush), typeof(Slider), new PropertyMetadata(Slider.DefaultBorderBrush, new PropertyChangedCallback(Slider.OnSliderBackgroungChanged)));

		// Token: 0x0400029C RID: 668
		private static double DefaultSliderRadio = 3.0;

		// Token: 0x0400029D RID: 669
		public static readonly DependencyProperty SliderRadioProperty = DependencyProperty.Register("SliderRadio", typeof(double), typeof(Slider), new PropertyMetadata(Slider.DefaultSliderRadio, new PropertyChangedCallback(Slider.OnSliderRadioChanged)));

		// Token: 0x0400029E RID: 670
		private double markXoffset = -12.0;

		// Token: 0x0400029F RID: 671
		private SolidColorBrush BRUSHES = new SolidColorBrush(Color.FromArgb(byte.MaxValue, 0, 0, 0));

		// Token: 0x040002A0 RID: 672
		private double fontSize = 10.0;

		// Token: 0x040002A1 RID: 673
		private static readonly CultureInfo CIR = CultureInfo.CurrentCulture;

		// Token: 0x040002A2 RID: 674
		private int valueTemp;

		// Token: 0x040002A3 RID: 675
		private bool IsDrag = false;

		// Token: 0x040002A4 RID: 676
		public static readonly DependencyProperty LastUpdateThumbProperty = DependencyProperty.Register("LastUpdateThumb", typeof(ImageSource), typeof(Slider), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(Slider.LastUpdateThumbChange)));

		// Token: 0x040002A5 RID: 677
		public static readonly DependencyProperty IsLastUpdateProperty = DependencyProperty.Register("IsLastUpdate", typeof(bool), typeof(Slider), new PropertyMetadata(false, new PropertyChangedCallback(Slider.IsLastUpdateChange)));

		// Token: 0x040002A6 RID: 678
		public static readonly DependencyProperty GroupNameProperty = DependencyProperty.Register("GroupName", typeof(string), typeof(Slider), new PropertyMetadata(null, new PropertyChangedCallback(Slider.GroupNameChange)));

		// Token: 0x02000053 RID: 83
		// (Invoke) Token: 0x0600043E RID: 1086
		public delegate void SliderValueChanged(object sender, int value);
	}
}
