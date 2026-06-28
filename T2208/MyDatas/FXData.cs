using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using T2208.MyInformations;
using T2208.ViewModels;

namespace T2208.MyDatas
{
	// Token: 0x0200006F RID: 111
	public static class FXData
	{
		// Token: 0x17000290 RID: 656
		// (get) Token: 0x060006EF RID: 1775 RVA: 0x00008AC1 File Offset: 0x00006CC1
		// (set) Token: 0x060006F0 RID: 1776 RVA: 0x00008AC8 File Offset: 0x00006CC8
		public static byte[,] FXEffectStartingValues { get; private set; } = new byte[,]
		{
			{
				0, 1, 1, 1, 0, 0, 0, 0, 0, 0,
				0, 0
			},
			{
				0, 1, 1, 1, 0, 0, 0, 0, 0, 0,
				0, 0
			},
			{
				0, 1, 1, 1, 0, 0, 0, 0, 0, 0,
				0, 0
			},
			{
				0, 1, 1, 0, 0, 0, 0, 0, 0, 0,
				0, 0
			},
			{
				0, 0, 1, 1, 1, 0, 0, 0, 0, 0,
				0, 0
			},
			{
				1, 1, 1, 0, 0, 0, 0, 0, 0, 0,
				0, 0
			},
			{
				1, 1, 1, 0, 0, 0, 0, 0, 0, 0,
				0, 0
			},
			{
				1, 0, 1, 0, 0, 0, 0, 0, 0, 0,
				0, 0
			},
			{
				0, 1, 1, 1, 0, 0, 1, 1, 0, 0,
				0, 0
			},
			{
				0, 1, 1, 1, 0, 0, 0, 1, 1, 1,
				0, 0
			},
			{
				0, 1, 1, 1, 0, 1, 1, 1, 0, 0,
				0, 0
			},
			{
				0, 1, 1, 1, 0, 1, 0, 1, 0, 0,
				0, 0
			}
		};

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x060006F1 RID: 1777 RVA: 0x00008AD0 File Offset: 0x00006CD0
		// (set) Token: 0x060006F2 RID: 1778 RVA: 0x00008AD7 File Offset: 0x00006CD7
		public static byte[,] FXEffectEndingValues { get; private set; } = new byte[,]
		{
			{
				240, 99, 99, 99, 99, 99, 0, 0, 0, 0,
				0, 0
			},
			{
				240, 99, 99, 99, 99, 99, 0, 0, 0, 0,
				0, 0
			},
			{
				240, 99, 99, 99, 99, 99, 0, 0, 0, 0,
				0, 0
			},
			{
				240, 99, 99, 99, 99, 0, 0, 0, 0, 0,
				0, 0
			},
			{
				240, 240, 99, 99, 99, 99, 99, 0, 0, 0,
				0, 0
			},
			{
				99, 48, 99, 99, 99, 0, 0, 0, 0, 0,
				0, 0
			},
			{
				99, 48, 99, 99, 99, 0, 0, 0, 0, 0,
				0, 0
			},
			{
				99, 48, 99, 99, 99, 0, 0, 0, 0, 0,
				0, 0
			},
			{
				240, 99, 99, 99, 99, 240, 99, 99, 99, 99,
				0, 0
			},
			{
				240, 99, 99, 99, 99, 240, 240, 99, 99, 99,
				99, 99
			},
			{
				240, 99, 99, 99, 99, 99, 48, 99, 99, 99,
				0, 0
			},
			{
				240, 99, 99, 99, 99, 99, 48, 99, 99, 99,
				0, 0
			}
		};

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x060006F3 RID: 1779 RVA: 0x00008ADF File Offset: 0x00006CDF
		// (set) Token: 0x060006F4 RID: 1780 RVA: 0x00008AE6 File Offset: 0x00006CE6
		public static byte PresentFxIndex
		{
			get
			{
				return FXData.s_presentFxIndex;
			}
			set
			{
				FXData.s_presentFxIndex = value;
				ViewModelMessager.Messeager.Notify(ViewModelMessager.UpdateDSPGEQFXIndex);
			}
		}

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x060006F5 RID: 1781 RVA: 0x00008AFF File Offset: 0x00006CFF
		// (set) Token: 0x060006F6 RID: 1782 RVA: 0x00008B06 File Offset: 0x00006D06
		public static FXInfo<FXItem> FX1 { get; set; } = new FXInfo<FXItem>
		{
			GroupName = "FX1",
			FXIndex = 0
		};

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x060006F7 RID: 1783 RVA: 0x00008B0E File Offset: 0x00006D0E
		// (set) Token: 0x060006F8 RID: 1784 RVA: 0x00008B15 File Offset: 0x00006D15
		public static FXInfo<FXItem> FX2 { get; set; } = new FXInfo<FXItem>
		{
			GroupName = "FX2",
			FXIndex = 1
		};

		// Token: 0x17000295 RID: 661
		// (get) Token: 0x060006F9 RID: 1785 RVA: 0x00008B1D File Offset: 0x00006D1D
		// (set) Token: 0x060006FA RID: 1786 RVA: 0x00008B24 File Offset: 0x00006D24
		public static List<FXInfo<FXItem>> FXs { get; private set; } = new List<FXInfo<FXItem>>();

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x060006FB RID: 1787 RVA: 0x00008B2C File Offset: 0x00006D2C
		// (set) Token: 0x060006FC RID: 1788 RVA: 0x00008B33 File Offset: 0x00006D33
		private static ObservableCollection<EffectInfo> Hall
		{
			get
			{
				return FXData.s_hall;
			}
			set
			{
				FXData.s_hall = value;
			}
		}

		// Token: 0x17000297 RID: 663
		// (get) Token: 0x060006FD RID: 1789 RVA: 0x00008B3B File Offset: 0x00006D3B
		// (set) Token: 0x060006FE RID: 1790 RVA: 0x00008B42 File Offset: 0x00006D42
		private static ObservableCollection<EffectInfo> Room
		{
			get
			{
				return FXData.s_room;
			}
			set
			{
				FXData.s_room = value;
			}
		}

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x060006FF RID: 1791 RVA: 0x00008B4A File Offset: 0x00006D4A
		// (set) Token: 0x06000700 RID: 1792 RVA: 0x00008B51 File Offset: 0x00006D51
		private static ObservableCollection<EffectInfo> Plate
		{
			get
			{
				return FXData.s_plate;
			}
			set
			{
				FXData.s_plate = value;
			}
		}

		// Token: 0x17000299 RID: 665
		// (get) Token: 0x06000701 RID: 1793 RVA: 0x00008B59 File Offset: 0x00006D59
		// (set) Token: 0x06000702 RID: 1794 RVA: 0x00008B60 File Offset: 0x00006D60
		private static ObservableCollection<EffectInfo> Delay
		{
			get
			{
				return FXData.s_delay;
			}
			set
			{
				FXData.s_delay = value;
			}
		}

		// Token: 0x1700029A RID: 666
		// (get) Token: 0x06000703 RID: 1795 RVA: 0x00008B68 File Offset: 0x00006D68
		// (set) Token: 0x06000704 RID: 1796 RVA: 0x00008B6F File Offset: 0x00006D6F
		private static ObservableCollection<EffectInfo> StDelay
		{
			get
			{
				return FXData.s_stDelay;
			}
			set
			{
				FXData.s_stDelay = value;
			}
		}

		// Token: 0x1700029B RID: 667
		// (get) Token: 0x06000705 RID: 1797 RVA: 0x00008B77 File Offset: 0x00006D77
		// (set) Token: 0x06000706 RID: 1798 RVA: 0x00008B7E File Offset: 0x00006D7E
		private static ObservableCollection<EffectInfo> Tremolo
		{
			get
			{
				return FXData.s_tremolo;
			}
			set
			{
				FXData.s_tremolo = value;
			}
		}

		// Token: 0x1700029C RID: 668
		// (get) Token: 0x06000707 RID: 1799 RVA: 0x00008B86 File Offset: 0x00006D86
		// (set) Token: 0x06000708 RID: 1800 RVA: 0x00008B8D File Offset: 0x00006D8D
		private static ObservableCollection<EffectInfo> Flanger
		{
			get
			{
				return FXData.s_flanger;
			}
			set
			{
				FXData.s_flanger = value;
			}
		}

		// Token: 0x1700029D RID: 669
		// (get) Token: 0x06000709 RID: 1801 RVA: 0x00008B95 File Offset: 0x00006D95
		// (set) Token: 0x0600070A RID: 1802 RVA: 0x00008B9C File Offset: 0x00006D9C
		private static ObservableCollection<EffectInfo> Chorus
		{
			get
			{
				return FXData.s_chorus;
			}
			set
			{
				FXData.s_chorus = value;
			}
		}

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x0600070B RID: 1803 RVA: 0x00008BA4 File Offset: 0x00006DA4
		// (set) Token: 0x0600070C RID: 1804 RVA: 0x00008BAB File Offset: 0x00006DAB
		private static ObservableCollection<EffectInfo> DelayRev
		{
			get
			{
				return FXData.s_delayRev;
			}
			set
			{
				FXData.s_delayRev = value;
			}
		}

		// Token: 0x1700029F RID: 671
		// (get) Token: 0x0600070D RID: 1805 RVA: 0x00008BB3 File Offset: 0x00006DB3
		// (set) Token: 0x0600070E RID: 1806 RVA: 0x00008BBA File Offset: 0x00006DBA
		private static ObservableCollection<EffectInfo> StDelayRev
		{
			get
			{
				return FXData.s_stDelayRev;
			}
			set
			{
				FXData.s_stDelayRev = value;
			}
		}

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x0600070F RID: 1807 RVA: 0x00008BC2 File Offset: 0x00006DC2
		// (set) Token: 0x06000710 RID: 1808 RVA: 0x00008BC9 File Offset: 0x00006DC9
		private static ObservableCollection<EffectInfo> FlangerRev
		{
			get
			{
				return FXData.s_flangerRev;
			}
			set
			{
				FXData.s_flangerRev = value;
			}
		}

		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x06000711 RID: 1809 RVA: 0x00008BD1 File Offset: 0x00006DD1
		// (set) Token: 0x06000712 RID: 1810 RVA: 0x00008BD8 File Offset: 0x00006DD8
		private static ObservableCollection<EffectInfo> ChorusRev
		{
			get
			{
				return FXData.s_chorusRev;
			}
			set
			{
				FXData.s_chorusRev = value;
			}
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x00021B30 File Offset: 0x0001FD30
		static FXData()
		{
			FXData.Hall.Add(new EffectInfo
			{
				Name = "PreDelay",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.millisecond, 240, 0, 1),
				EffectIndex = FXData.Hall.Count,
				DefaultEffectValue = 4
			});
			FXData.Hall.Add(new EffectInfo
			{
				Name = "Decay",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 1, 1),
				EffectIndex = FXData.Hall.Count,
				DefaultEffectValue = 32
			});
			FXData.Hall.Add(new EffectInfo
			{
				Name = "RoomSize",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 99, 1, 1),
				EffectIndex = FXData.Hall.Count,
				DefaultEffectValue = 32
			});
			FXData.Hall.Add(new EffectInfo
			{
				Name = "HiDamp",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 99, 1, 1),
				EffectIndex = FXData.Hall.Count,
				DefaultEffectValue = 12
			});
			FXData.Hall.Add(new EffectInfo
			{
				Name = "EfxOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 0, 1),
				EffectIndex = FXData.Hall.Count,
				DefaultEffectValue = 64
			});
			FXData.Hall.Add(new EffectInfo
			{
				Name = "DryOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 0, 1),
				EffectIndex = FXData.Hall.Count,
				DefaultEffectValue = 32
			});
			FXData.Room.Add(new EffectInfo
			{
				Name = "PreDelay",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.millisecond, 240, 0, 1),
				EffectIndex = FXData.Room.Count,
				DefaultEffectValue = 72
			});
			FXData.Room.Add(new EffectInfo
			{
				Name = "Decay",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 1, 1),
				EffectIndex = FXData.Room.Count,
				DefaultEffectValue = 32
			});
			FXData.Room.Add(new EffectInfo
			{
				Name = "RoomSize",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 99, 1, 1),
				EffectIndex = FXData.Room.Count,
				DefaultEffectValue = 32
			});
			FXData.Room.Add(new EffectInfo
			{
				Name = "HiDamp",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 99, 1, 1),
				EffectIndex = FXData.Room.Count,
				DefaultEffectValue = 12
			});
			FXData.Room.Add(new EffectInfo
			{
				Name = "EfxOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 0, 1),
				EffectIndex = FXData.Room.Count,
				DefaultEffectValue = 64
			});
			FXData.Room.Add(new EffectInfo
			{
				Name = "DryOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 0, 1),
				EffectIndex = FXData.Room.Count,
				DefaultEffectValue = 32
			});
			FXData.Plate.Add(new EffectInfo
			{
				Name = "PreDelay",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.millisecond, 240, 0, 1),
				EffectIndex = FXData.Plate.Count,
				DefaultEffectValue = 4
			});
			FXData.Plate.Add(new EffectInfo
			{
				Name = "Decay",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 1, 1),
				EffectIndex = FXData.Plate.Count,
				DefaultEffectValue = 32
			});
			FXData.Plate.Add(new EffectInfo
			{
				Name = "RoomSize",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 99, 1, 1),
				EffectIndex = FXData.Plate.Count,
				DefaultEffectValue = 32
			});
			FXData.Plate.Add(new EffectInfo
			{
				Name = "HiDamp",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 99, 1, 1),
				EffectIndex = FXData.Plate.Count,
				DefaultEffectValue = 12
			});
			FXData.Plate.Add(new EffectInfo
			{
				Name = "EfxOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 0, 1),
				EffectIndex = FXData.Plate.Count,
				DefaultEffectValue = 64
			});
			FXData.Plate.Add(new EffectInfo
			{
				Name = "DryOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 0, 1),
				EffectIndex = FXData.Plate.Count,
				DefaultEffectValue = 32
			});
			FXData.Delay.Add(new EffectInfo
			{
				Name = "Time",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.millisecond, 240, 0, 10),
				EffectIndex = FXData.Delay.Count,
				DefaultEffectValue = 120
			});
			FXData.Delay.Add(new EffectInfo
			{
				Name = "Decay",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 99, 1, 1),
				EffectIndex = FXData.Delay.Count,
				DefaultEffectValue = 48
			});
			FXData.Delay.Add(new EffectInfo
			{
				Name = "HiDamp",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 99, 1, 1),
				EffectIndex = FXData.Delay.Count,
				DefaultEffectValue = 12
			});
			FXData.Delay.Add(new EffectInfo
			{
				Name = "EfxOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 99, 0, 1),
				EffectIndex = FXData.Delay.Count,
				DefaultEffectValue = 64
			});
			FXData.Delay.Add(new EffectInfo
			{
				Name = "DryOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 99, 0, 1),
				EffectIndex = FXData.Delay.Count,
				DefaultEffectValue = 32
			});
			FXData.StDelay.Add(new EffectInfo
			{
				Name = "LTime",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.millisecond, 240, 0, 10),
				EffectIndex = FXData.StDelay.Count,
				DefaultEffectValue = 120
			});
			FXData.StDelay.Add(new EffectInfo
			{
				Name = "RTime",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.millisecond, 240, 0, 10),
				EffectIndex = FXData.StDelay.Count,
				DefaultEffectValue = 120
			});
			FXData.StDelay.Add(new EffectInfo
			{
				Name = "LDecay",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 99, 1, 1),
				EffectIndex = FXData.StDelay.Count,
				DefaultEffectValue = 48
			});
			FXData.StDelay.Add(new EffectInfo
			{
				Name = "RDecay",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 99, 1, 1),
				EffectIndex = FXData.StDelay.Count,
				DefaultEffectValue = 48
			});
			FXData.StDelay.Add(new EffectInfo
			{
				Name = "HiDamp",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 1, 1),
				EffectIndex = FXData.StDelay.Count,
				DefaultEffectValue = 12
			});
			FXData.StDelay.Add(new EffectInfo
			{
				Name = "EfxOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 0, 1),
				EffectIndex = FXData.StDelay.Count,
				DefaultEffectValue = 64
			});
			FXData.StDelay.Add(new EffectInfo
			{
				Name = "DryOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 0, 1),
				EffectIndex = FXData.StDelay.Count,
				DefaultEffectValue = 12
			});
			FXData.Tremolo.Add(new EffectInfo
			{
				Name = "FeedBack",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 1, 1),
				EffectIndex = FXData.Tremolo.Count,
				DefaultEffectValue = 32,
				IsEnabled = false
			});
			FXData.Tremolo.Add(new EffectInfo
			{
				Name = "Depth",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 48, 1, 1),
				EffectIndex = FXData.Tremolo.Count,
				DefaultEffectValue = 32,
				IsEnabled = false
			});
			FXData.Tremolo.Add(new EffectInfo
			{
				Name = "ModFreq",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 1, 1),
				EffectIndex = FXData.Tremolo.Count,
				DefaultEffectValue = 32
			});
			FXData.Tremolo.Add(new EffectInfo
			{
				Name = "EfxOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 0, 1),
				EffectIndex = FXData.Tremolo.Count,
				DefaultEffectValue = 32
			});
			FXData.Tremolo.Add(new EffectInfo
			{
				Name = "DryOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 0, 1),
				EffectIndex = FXData.Tremolo.Count,
				DefaultEffectValue = 24
			});
			FXData.Flanger.Add(new EffectInfo
			{
				Name = "FeedBack",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 1, 1),
				EffectIndex = FXData.Flanger.Count,
				DefaultEffectValue = 32
			});
			FXData.Flanger.Add(new EffectInfo
			{
				Name = "Depth",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 48, 1, 1),
				EffectIndex = FXData.Flanger.Count,
				DefaultEffectValue = 32
			});
			FXData.Flanger.Add(new EffectInfo
			{
				Name = "ModFreq",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 1, 1),
				EffectIndex = FXData.Flanger.Count,
				DefaultEffectValue = 24
			});
			FXData.Flanger.Add(new EffectInfo
			{
				Name = "EfxOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 0, 1),
				EffectIndex = FXData.Flanger.Count,
				DefaultEffectValue = 64
			});
			FXData.Flanger.Add(new EffectInfo
			{
				Name = "DryOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 0, 1),
				EffectIndex = FXData.Flanger.Count,
				DefaultEffectValue = 32
			});
			FXData.Chorus.Add(new EffectInfo
			{
				Name = "FeedBack",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 1, 1),
				EffectIndex = FXData.Chorus.Count,
				DefaultEffectValue = 32
			});
			FXData.Chorus.Add(new EffectInfo
			{
				Name = "Depth",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 48, 0, 1),
				EffectIndex = FXData.Chorus.Count,
				DefaultEffectValue = 32
			});
			FXData.Chorus.Add(new EffectInfo
			{
				Name = "ModFreq",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 1, 1),
				EffectIndex = FXData.Chorus.Count,
				DefaultEffectValue = 24
			});
			FXData.Chorus.Add(new EffectInfo
			{
				Name = "EfxOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 0, 1),
				EffectIndex = FXData.Chorus.Count,
				DefaultEffectValue = 64
			});
			FXData.Chorus.Add(new EffectInfo
			{
				Name = "DryOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 0, 1),
				EffectIndex = FXData.Chorus.Count,
				DefaultEffectValue = 32
			});
			FXData.DelayRev.Add(new EffectInfo
			{
				Name = "PreDelay",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.millisecond, 240, 0, 1),
				EffectIndex = FXData.DelayRev.Count,
				DefaultEffectValue = 4
			});
			FXData.DelayRev.Add(new EffectInfo
			{
				Name = "RevDecay",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 1, 1),
				EffectIndex = FXData.DelayRev.Count,
				DefaultEffectValue = 32
			});
			FXData.DelayRev.Add(new EffectInfo
			{
				Name = "RoomSize",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 99, 1, 1),
				EffectIndex = FXData.DelayRev.Count,
				DefaultEffectValue = 32
			});
			FXData.DelayRev.Add(new EffectInfo
			{
				Name = "RevHi",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 99, 1, 1),
				EffectIndex = FXData.DelayRev.Count,
				DefaultEffectValue = 12
			});
			FXData.DelayRev.Add(new EffectInfo
			{
				Name = "RevOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 0, 1),
				EffectIndex = FXData.DelayRev.Count,
				DefaultEffectValue = 64
			});
			FXData.DelayRev.Add(new EffectInfo
			{
				Name = "EchoTime",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.millisecond, 240, 0, 10),
				EffectIndex = FXData.DelayRev.Count,
				DefaultEffectValue = 120
			});
			FXData.DelayRev.Add(new EffectInfo
			{
				Name = "EchoFB",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 1, 1),
				EffectIndex = FXData.DelayRev.Count,
				DefaultEffectValue = 32
			});
			FXData.DelayRev.Add(new EffectInfo
			{
				Name = "EchoHi",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 99, 1, 1),
				EffectIndex = FXData.DelayRev.Count,
				DefaultEffectValue = 12
			});
			FXData.DelayRev.Add(new EffectInfo
			{
				Name = "EchoOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 0, 1),
				EffectIndex = FXData.DelayRev.Count,
				DefaultEffectValue = 64
			});
			FXData.DelayRev.Add(new EffectInfo
			{
				Name = "DryOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 0, 1),
				EffectIndex = FXData.DelayRev.Count,
				DefaultEffectValue = 32
			});
			FXData.StDelayRev.Add(new EffectInfo
			{
				Name = "PreDelay",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.millisecond, 240, 0, 1),
				EffectIndex = FXData.StDelayRev.Count,
				DefaultEffectValue = 4
			});
			FXData.StDelayRev.Add(new EffectInfo
			{
				Name = "RevDecay",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 1, 1),
				EffectIndex = FXData.StDelayRev.Count,
				DefaultEffectValue = 32
			});
			FXData.StDelayRev.Add(new EffectInfo
			{
				Name = "RoomSize",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 99, 1, 1),
				EffectIndex = FXData.StDelayRev.Count,
				DefaultEffectValue = 32
			});
			FXData.StDelayRev.Add(new EffectInfo
			{
				Name = "RevHi",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 99, 1, 1),
				EffectIndex = FXData.StDelayRev.Count,
				DefaultEffectValue = 12
			});
			FXData.StDelayRev.Add(new EffectInfo
			{
				Name = "RevOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 0, 1),
				EffectIndex = FXData.StDelayRev.Count,
				DefaultEffectValue = 64
			});
			FXData.StDelayRev.Add(new EffectInfo
			{
				Name = "LTime",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.millisecond, 240, 0, 10),
				EffectIndex = FXData.StDelayRev.Count,
				DefaultEffectValue = 120
			});
			FXData.StDelayRev.Add(new EffectInfo
			{
				Name = "RTime",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.millisecond, 240, 0, 10),
				EffectIndex = FXData.StDelayRev.Count,
				DefaultEffectValue = 120
			});
			FXData.StDelayRev.Add(new EffectInfo
			{
				Name = "LDecay",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 1, 1),
				EffectIndex = FXData.StDelayRev.Count,
				DefaultEffectValue = 48
			});
			FXData.StDelayRev.Add(new EffectInfo
			{
				Name = "RDecay",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 1, 1),
				EffectIndex = FXData.StDelayRev.Count,
				DefaultEffectValue = 48
			});
			FXData.StDelayRev.Add(new EffectInfo
			{
				Name = "EchoHi",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 99, 1, 1),
				EffectIndex = FXData.StDelayRev.Count,
				DefaultEffectValue = 12
			});
			FXData.StDelayRev.Add(new EffectInfo
			{
				Name = "EchoOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 0, 1),
				EffectIndex = FXData.StDelayRev.Count,
				DefaultEffectValue = 64
			});
			FXData.StDelayRev.Add(new EffectInfo
			{
				Name = "DryOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 0, 1),
				EffectIndex = FXData.StDelayRev.Count,
				DefaultEffectValue = 32
			});
			FXData.FlangerRev.Add(new EffectInfo
			{
				Name = "PreDelay",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.millisecond, 240, 0, 1),
				EffectIndex = FXData.FlangerRev.Count,
				DefaultEffectValue = 4
			});
			FXData.FlangerRev.Add(new EffectInfo
			{
				Name = "RevDecay",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 1, 1),
				EffectIndex = FXData.FlangerRev.Count,
				DefaultEffectValue = 32
			});
			FXData.FlangerRev.Add(new EffectInfo
			{
				Name = "RoomSize",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 99, 1, 1),
				EffectIndex = FXData.FlangerRev.Count,
				DefaultEffectValue = 32
			});
			FXData.FlangerRev.Add(new EffectInfo
			{
				Name = "RevHi",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 99, 1, 1),
				EffectIndex = FXData.FlangerRev.Count,
				DefaultEffectValue = 12
			});
			FXData.FlangerRev.Add(new EffectInfo
			{
				Name = "RevOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 0, 1),
				EffectIndex = FXData.FlangerRev.Count,
				DefaultEffectValue = 64
			});
			FXData.FlangerRev.Add(new EffectInfo
			{
				Name = "ModF.8",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 1, 1),
				EffectIndex = FXData.FlangerRev.Count,
				DefaultEffectValue = 32
			});
			FXData.FlangerRev.Add(new EffectInfo
			{
				Name = "ModDepth",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 48, 1, 1),
				EffectIndex = FXData.FlangerRev.Count,
				DefaultEffectValue = 32
			});
			FXData.FlangerRev.Add(new EffectInfo
			{
				Name = "ModFreq",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 1, 1),
				EffectIndex = FXData.FlangerRev.Count,
				DefaultEffectValue = 24
			});
			FXData.FlangerRev.Add(new EffectInfo
			{
				Name = "ModOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 0, 1),
				EffectIndex = FXData.FlangerRev.Count,
				DefaultEffectValue = 64
			});
			FXData.FlangerRev.Add(new EffectInfo
			{
				Name = "DryOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 0, 1),
				EffectIndex = FXData.FlangerRev.Count,
				DefaultEffectValue = 32
			});
			FXData.ChorusRev.Add(new EffectInfo
			{
				Name = "PreDelay",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.millisecond, 240, 0, 1),
				EffectIndex = FXData.ChorusRev.Count,
				DefaultEffectValue = 4
			});
			FXData.ChorusRev.Add(new EffectInfo
			{
				Name = "RevDecay",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 1, 1),
				EffectIndex = FXData.ChorusRev.Count,
				DefaultEffectValue = 32
			});
			FXData.ChorusRev.Add(new EffectInfo
			{
				Name = "RoomSize",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 99, 1, 1),
				EffectIndex = FXData.ChorusRev.Count,
				DefaultEffectValue = 32
			});
			FXData.ChorusRev.Add(new EffectInfo
			{
				Name = "RevHi",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 99, 1, 1),
				EffectIndex = FXData.ChorusRev.Count,
				DefaultEffectValue = 12
			});
			FXData.ChorusRev.Add(new EffectInfo
			{
				Name = "RevOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 0, 1),
				EffectIndex = FXData.ChorusRev.Count,
				DefaultEffectValue = 64
			});
			FXData.ChorusRev.Add(new EffectInfo
			{
				Name = "ModF.B",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 1, 1),
				EffectIndex = FXData.ChorusRev.Count,
				DefaultEffectValue = 32
			});
			FXData.ChorusRev.Add(new EffectInfo
			{
				Name = "ModDepth",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.none, 48, 0, 1),
				EffectIndex = FXData.ChorusRev.Count,
				DefaultEffectValue = 32
			});
			FXData.ChorusRev.Add(new EffectInfo
			{
				Name = "ModFreq",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 1, 1),
				EffectIndex = FXData.ChorusRev.Count,
				DefaultEffectValue = 24
			});
			FXData.ChorusRev.Add(new EffectInfo
			{
				Name = "ModOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 0, 1),
				EffectIndex = FXData.ChorusRev.Count,
				DefaultEffectValue = 64
			});
			FXData.ChorusRev.Add(new EffectInfo
			{
				Name = "DryOut",
				EffectValueCollection = FXGenerator.InfoGenerator(FXValueType.percentage, 99, 0, 1),
				EffectIndex = FXData.ChorusRev.Count,
				DefaultEffectValue = 32
			});
			FXData.InitialFX(FXData.FX1);
			FXData.InitialFX(FXData.FX2);
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x0002349C File Offset: 0x0002169C
		public static byte GetEffectIndexFromDevice(byte fxIndex, byte effectIndex, byte deviceValue)
		{
			return Math.Min(FXData.FXEffectEndingValues[(int)fxIndex, (int)effectIndex], deviceValue - FXData.FXEffectStartingValues[(int)fxIndex, (int)effectIndex]);
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x000234D0 File Offset: 0x000216D0
		public static byte GetEffectIndexFromUi(byte fxIndex, byte effectIndex, byte uiValue)
		{
			return Math.Min(FXData.FXEffectEndingValues[(int)fxIndex, (int)effectIndex], uiValue + FXData.FXEffectStartingValues[(int)fxIndex, (int)effectIndex]);
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x00023504 File Offset: 0x00021704
		private static void InitialFX(FXInfo<FXItem> fx)
		{
			fx.Add(new FXItem
			{
				Name = "Hall",
				Effect = FXData.CopyEffectInfo(FXData.Hall)
			});
			fx.Add(new FXItem
			{
				Name = "Room",
				Effect = FXData.CopyEffectInfo(FXData.Room)
			});
			fx.Add(new FXItem
			{
				Name = "Plate",
				Effect = FXData.CopyEffectInfo(FXData.Plate)
			});
			fx.Add(new FXItem
			{
				Name = "Delay",
				Effect = FXData.CopyEffectInfo(FXData.Delay)
			});
			fx.Add(new FXItem
			{
				Name = "StDelay",
				Effect = FXData.CopyEffectInfo(FXData.StDelay)
			});
			fx.Add(new FXItem
			{
				Name = "Tremolo",
				Effect = FXData.CopyEffectInfo(FXData.Tremolo)
			});
			fx.Add(new FXItem
			{
				Name = "Flanger",
				Effect = FXData.CopyEffectInfo(FXData.Flanger)
			});
			fx.Add(new FXItem
			{
				Name = "Chorus",
				Effect = FXData.CopyEffectInfo(FXData.Chorus)
			});
			fx.Add(new FXItem
			{
				Name = "DelayRev",
				Effect = FXData.CopyEffectInfo(FXData.DelayRev)
			});
			fx.Add(new FXItem
			{
				Name = "StDelayRev",
				Effect = FXData.CopyEffectInfo(FXData.StDelayRev)
			});
			fx.Add(new FXItem
			{
				Name = "FlangerRev",
				Effect = FXData.CopyEffectInfo(FXData.FlangerRev)
			});
			fx.Add(new FXItem
			{
				Name = "ChorusRev",
				Effect = FXData.CopyEffectInfo(FXData.ChorusRev)
			});
			FXData.FXs.Add(fx);
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x0002370C File Offset: 0x0002190C
		private static ObservableCollection<EffectInfo> CopyEffectInfo(ObservableCollection<EffectInfo> effectInfos)
		{
			ObservableCollection<EffectInfo> observableCollection = new ObservableCollection<EffectInfo>();
			foreach (EffectInfo effectInfo in effectInfos)
			{
				observableCollection.Add(new EffectInfo
				{
					EffectIndex = effectInfo.EffectIndex,
					EffectValue = effectInfo.EffectValue,
					DefaultEffectValue = effectInfo.DefaultEffectValue,
					EffectValueCollection = effectInfo.EffectValueCollection,
					CommonCommand = effectInfo.CommonCommand,
					Name = effectInfo.Name,
					IsEnabled = effectInfo.IsEnabled
				});
			}
			return observableCollection;
		}

		// Token: 0x040003D6 RID: 982
		private static ObservableCollection<EffectInfo> s_hall = new ObservableCollection<EffectInfo>();

		// Token: 0x040003D7 RID: 983
		private static ObservableCollection<EffectInfo> s_room = new ObservableCollection<EffectInfo>();

		// Token: 0x040003D8 RID: 984
		private static ObservableCollection<EffectInfo> s_plate = new ObservableCollection<EffectInfo>();

		// Token: 0x040003D9 RID: 985
		private static ObservableCollection<EffectInfo> s_delay = new ObservableCollection<EffectInfo>();

		// Token: 0x040003DA RID: 986
		private static ObservableCollection<EffectInfo> s_stDelay = new ObservableCollection<EffectInfo>();

		// Token: 0x040003DB RID: 987
		private static ObservableCollection<EffectInfo> s_tremolo = new ObservableCollection<EffectInfo>();

		// Token: 0x040003DC RID: 988
		private static ObservableCollection<EffectInfo> s_flanger = new ObservableCollection<EffectInfo>();

		// Token: 0x040003DD RID: 989
		private static ObservableCollection<EffectInfo> s_chorus = new ObservableCollection<EffectInfo>();

		// Token: 0x040003DE RID: 990
		private static ObservableCollection<EffectInfo> s_delayRev = new ObservableCollection<EffectInfo>();

		// Token: 0x040003DF RID: 991
		private static ObservableCollection<EffectInfo> s_stDelayRev = new ObservableCollection<EffectInfo>();

		// Token: 0x040003E0 RID: 992
		private static ObservableCollection<EffectInfo> s_flangerRev = new ObservableCollection<EffectInfo>();

		// Token: 0x040003E1 RID: 993
		private static ObservableCollection<EffectInfo> s_chorusRev = new ObservableCollection<EffectInfo>();

		// Token: 0x040003E2 RID: 994
		private static byte s_presentFxIndex;
	}
}
