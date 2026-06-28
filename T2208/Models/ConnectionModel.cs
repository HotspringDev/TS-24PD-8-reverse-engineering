using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Windows;
using System.Windows.Threading;
using CommLibrary;
using JayLib.WPF.BasicClass;
using T2208.DeviceCommuncation;
using T2208.ViewModels;

namespace T2208.Models
{
	// Token: 0x020000A2 RID: 162
	public class ConnectionModel
	{
		// Token: 0x17000307 RID: 775
		// (get) Token: 0x06000846 RID: 2118 RVA: 0x00009B75 File Offset: 0x00007D75
		// (set) Token: 0x06000847 RID: 2119 RVA: 0x00009B7D File Offset: 0x00007D7D
		public string ConnectingIP { get; private set; }

		// Token: 0x17000308 RID: 776
		// (get) Token: 0x06000848 RID: 2120 RVA: 0x00009B86 File Offset: 0x00007D86
		// (set) Token: 0x06000849 RID: 2121 RVA: 0x00009B8E File Offset: 0x00007D8E
		public bool IsConnected { get; private set; }

		// Token: 0x17000309 RID: 777
		// (get) Token: 0x0600084A RID: 2122 RVA: 0x00009B97 File Offset: 0x00007D97
		// (set) Token: 0x0600084B RID: 2123 RVA: 0x00009B9F File Offset: 0x00007D9F
		public ConnectionMessager Messager { get; private set; }

		// Token: 0x1700030A RID: 778
		// (get) Token: 0x0600084C RID: 2124 RVA: 0x00009BA8 File Offset: 0x00007DA8
		// (set) Token: 0x0600084D RID: 2125 RVA: 0x00009BB0 File Offset: 0x00007DB0
		public DeviceScaner DeviceScaner { get; private set; }

		// Token: 0x0600084E RID: 2126 RVA: 0x0002596C File Offset: 0x00023B6C
		public ConnectionModel()
		{
			this.InitializeProperty();
			this.InitializeDeviceScaner();
			this.InitialConnectSocket();
			this.InitializeHighFrequencyReceive();
		}

		// Token: 0x0600084F RID: 2127 RVA: 0x00009BB9 File Offset: 0x00007DB9
		public void InitializeProperty()
		{
			this.DeviceScaner = new DeviceScaner(MainWindow.IP);
			this.DeviceScaner.isSupportUSB = true;
			this.Messager = new ConnectionMessager();
		}

		// Token: 0x06000850 RID: 2128 RVA: 0x000259F4 File Offset: 0x00023BF4
		private void InitializeDeviceScaner()
		{
			this.DeviceScaner.onUDPBeginScanEvent += this.DeviceScaner_OnUDPBeginScanEvent;
			this.DeviceScaner.onScanChangedEvent += this.DeviceScaner_OnScanChangedEvent;
			this.DeviceScaner.onUDPStopScanEvent += this.DeviceScaner_OnUDPStopScanEvent;
			this._ScanTimer.Elapsed += this._ScanTimer_Elapsed;
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x00025A64 File Offset: 0x00023C64
		private void _ScanTimer_Elapsed(object sender, ElapsedEventArgs e)
		{
			bool flag = this._RouterInfoStack.Count != 0 && this._DuringScanDevice && !this._HasGetDeviceName;
			if (flag)
			{
				this._PresentRouterInfo = this._RouterInfoStack.Pop();
				NetCilent.netCilent.connect(this._PresentRouterInfo.RouterAddr);
			}
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x00009BE6 File Offset: 0x00007DE6
		private void DeviceScaner_OnUDPStopScanEvent(object sender, EventArgs e)
		{
			this._ScanTimer.Stop();
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x00009BF5 File Offset: 0x00007DF5
		private void DeviceScaner_OnScanChangedEvent(object sender, RouterInfo rpinfo, EventArgs e)
		{
			this._RouterInfoStack.Push(rpinfo);
			ViewModelMessager.Messeager.Notify(ViewModelMessager.FindNewDevice, rpinfo);
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x00025ACC File Offset: 0x00023CCC
		private void DeviceScaner_OnUDPBeginScanEvent(object sender, EventArgs e)
		{
			bool isConnected = this.IsConnected;
			if (isConnected)
			{
				Cilent cilent = ConnectionModel.GetCilent();
				if (cilent != null)
				{
					cilent.disConnect();
				}
			}
			this._DuringScanDevice = true;
			this._HasGetDeviceName = false;
			this._RouterInfoStack.Clear();
			this._ScanTimer.Start();
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x00025B24 File Offset: 0x00023D24
		private void InitialConnectSocket()
		{
			NetCilent.shareCilent(0);
			NetCilent.netCilent.ReceiveByteEvent += this.OnCommuteReceiveByte;
			NetCilent.netCilent.onConnectedEvent += this.OnCommuteConnected;
			NetCilent.netCilent.onDisconnectEvent += this.OnCommuteDisconnected;
			ComCilent.shareCilent();
			ComCilent.comCilent.ReceiveByteEvent += this.OnCommuteReceiveByte;
			ComCilent.comCilent.onConnectedEvent += this.OnCommuteConnected;
			ComCilent.comCilent.onDisconnectEvent += this.OnCommuteDisconnected;
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x00025BCC File Offset: 0x00023DCC
		private void OnCommuteDisconnected(int SocketIndex, string addr, EventArgs e)
		{
			bool flag = !this._DuringScanDevice;
			if (flag)
			{
				this.IsConnected = false;
				ViewModelMessager.Messeager.Notify(ViewModelMessager.UpdateConnectionState, this.IsConnected);
				this._PresentRouterInfo = null;
				this._HasGetDeviceName = false;
			}
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x00025C20 File Offset: 0x00023E20
		private void OnCommuteConnected(int SocketIndex, string conIP, EventArgs e)
		{
			bool duringScanDevice = this._DuringScanDevice;
			if (duringScanDevice)
			{
				UpStreamCommand.SendReadDeviceName();
			}
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x00025C44 File Offset: 0x00023E44
		private void OnCommuteReceiveByte(int SocketIndex, string addr, byte[] m_rData, int dlen, EventArgs e)
		{
			for (int i = 0; i < dlen; i++)
			{
				this.RecByte(m_rData[i], addr);
			}
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x00025C70 File Offset: 0x00023E70
		private void RecByte(byte ch, string ip)
		{
			bool flag = this._ReceivePackage.Count<byte>() == 0 && ch != 1;
			if (flag)
			{
				this._ReceivePackage.Clear();
			}
			else
			{
				bool flag2 = this._ReceivePackage.Count<byte>() == 1 && ch != 32;
				if (flag2)
				{
					this._ReceivePackage.Clear();
				}
				else
				{
					bool flag3 = this._ReceivePackage.Count<byte>() == 2 && ch != 3;
					if (flag3)
					{
						this._ReceivePackage.Clear();
					}
					else
					{
						this._ReceivePackage.Add(ch);
						bool flag4 = this._ReceivePackage.Count<byte>() >= 11;
						if (flag4)
						{
							byte b = this._ReceivePackage[10];
							int num = (int)this._ReceivePackage[3] * 256 + (int)this._ReceivePackage[4];
							bool flag5 = num == 245;
							if (flag5)
							{
								num = 4715;
							}
							else
							{
								bool flag6 = num == 247;
								if (flag6)
								{
									num = 397;
								}
								else
								{
									bool flag7 = num == 248;
									if (flag7)
									{
										num = 781;
									}
									else
									{
										bool flag8 = num == 249;
										if (flag8)
										{
											num = 1677;
										}
										else
										{
											bool flag9 = num == 250;
											if (flag9)
											{
												num = 781;
											}
										}
									}
								}
							}
							bool flag10 = this._ReceivePackage.Count > num && CommandConst.DataTypeLengthDictionary.ContainsKey(num);
							if (flag10)
							{
								num = CommandConst.DataTypeLengthDictionary[num];
							}
							bool flag11 = this._ReceivePackage.Count<byte>() == num && this._ReceivePackage[num - 1] == 64;
							if (flag11)
							{
								byte[] array = this._ReceivePackage.ToArray();
								this._ReceivePackage.Clear();
								this._Package = array.ToList<byte>();
								this.ConvertData(this._Package, ip);
							}
							else
							{
								bool flag12 = this._ReceivePackage.Count > num;
								if (flag12)
								{
									this._ReceivePackage.Clear();
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600085A RID: 2138 RVA: 0x00009C18 File Offset: 0x00007E18
		private void InitializeHighFrequencyReceive()
		{
			DownStream.HighFrequencyAction = delegate(byte[] data)
			{
				Application application = Application.Current;
				if (application != null)
				{
					Dispatcher dispatcher = application.Dispatcher;
					if (dispatcher != null)
					{
						dispatcher.Invoke(delegate
						{
							bool flag = data != null;
							if (flag)
							{
								MainData.ConnectionModel.Messager.Notify(1, 1, (int)data[10], data);
							}
						});
					}
				}
			};
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x00025E90 File Offset: 0x00024090
		private void ConvertData(List<byte> package, string ip)
		{
			byte[] array = package.ToArray();
			bool flag = array[10] == 22;
			if (flag)
			{
				IPProces.printAryByte("Reveice data: ", array);
			}
			bool duringScanDevice = this._DuringScanDevice;
			if (duringScanDevice)
			{
				bool flag2 = package[10] == CommandConst.CMD_ReadDeviceName;
				if (flag2)
				{
					this._DuringScanDevice = false;
					this._HasGetDeviceName = true;
					UpStream.SendCMD_Recall();
					this.IsConnected = true;
					this.ConnectingIP = this._PresentRouterInfo.RouterAddr;
					Application.Current.Dispatcher.Invoke(delegate
					{
						ViewModelMessager.Messeager.Notify(ViewModelMessager.UpdateConnectionState, this.IsConnected);
						ViewModelMessager.Messeager.Notify(ViewModelMessager.FindT2208, package.ToArray());
						MainData.ConnectionModel.Messager.Notify(1, 1, (int)package[10], package.ToArray());
					});
				}
			}
			else
			{
				byte b = package[10];
				if (b != 40)
				{
					if (b != 41)
					{
						Application.Current.Dispatcher.Invoke(delegate
						{
							MainData.ConnectionModel.Messager.Notify(1, 1, (int)package[10], package.ToArray());
						});
					}
					else
					{
						DownStream.StartTimer();
						DownStream.PushData(package[10], package.ToArray());
					}
				}
				else
				{
					DownStream.StartTimer();
					DownStream.PushData(package[10], package.ToArray());
				}
			}
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x00025FE0 File Offset: 0x000241E0
		public static Cilent GetCilent()
		{
			bool flag = NetCilent.netCilent.isConnected();
			Cilent cilent;
			if (flag)
			{
				cilent = NetCilent.netCilent;
			}
			else
			{
				bool flag2 = ComCilent.comCilent.isConnected();
				if (flag2)
				{
					cilent = ComCilent.comCilent;
				}
				else
				{
					cilent = null;
				}
			}
			return cilent;
		}

		// Token: 0x04000492 RID: 1170
		private List<byte> _ReceivePackage = new List<byte>();

		// Token: 0x04000493 RID: 1171
		private List<byte> _Package = new List<byte>();

		// Token: 0x04000494 RID: 1172
		private Timer _ScanTimer = new Timer(300.0);

		// Token: 0x04000495 RID: 1173
		private volatile bool _DuringScanDevice = false;

		// Token: 0x04000496 RID: 1174
		private volatile bool _HasGetDeviceName = false;

		// Token: 0x04000497 RID: 1175
		private volatile Stack<RouterInfo> _RouterInfoStack = new Stack<RouterInfo>();

		// Token: 0x04000498 RID: 1176
		private volatile RouterInfo _PresentRouterInfo = new RouterInfo();
	}
}
