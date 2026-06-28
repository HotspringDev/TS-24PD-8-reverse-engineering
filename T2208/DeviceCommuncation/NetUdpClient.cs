using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using CommLibrary;

namespace T2208.DeviceCommuncation
{
	// Token: 0x020000B9 RID: 185
	public class NetUdpClient : Cilent
	{
		// Token: 0x0600096C RID: 2412 RVA: 0x0000A0B8 File Offset: 0x000082B8
		public NetUdpClient()
		{
			this.InitSocket();
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x0002A280 File Offset: 0x00028480
		protected override void Finalize()
		{
			try
			{
				bool flag = this._client == null;
				if (!flag)
				{
					try
					{
						this._client.Close();
					}
					catch
					{
					}
				}
			}
			finally
			{
				base.Finalize();
			}
		}

		// Token: 0x1700036A RID: 874
		// (get) Token: 0x0600096E RID: 2414 RVA: 0x0000A0E0 File Offset: 0x000082E0
		// (set) Token: 0x0600096F RID: 2415 RVA: 0x0000A0E8 File Offset: 0x000082E8
		public bool Connected { get; set; }

		// Token: 0x06000970 RID: 2416 RVA: 0x0000A0F1 File Offset: 0x000082F1
		public void ReceiveMulticast(string IP = "")
		{
			this.changeNIC(IP);
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x0000A0FC File Offset: 0x000082FC
		public void ExitMulticast()
		{
			this._client.DropMulticastGroup(IPAddress.Parse(NetUdpClient.MulcaticastIp));
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x0002A2DC File Offset: 0x000284DC
		public static NetUdpClient shareClient()
		{
			bool flag = NetUdpClient.netUdpClient == null;
			if (flag)
			{
				NetUdpClient.netUdpClient = new NetUdpClient();
			}
			return NetUdpClient.netUdpClient;
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x0002A30C File Offset: 0x0002850C
		public void InitSocket()
		{
			UdpClient udpClient = new UdpClient(0);
			Debug.WriteLine("UDP port : " + ((IPEndPoint)udpClient.Client.LocalEndPoint).Port.ToString());
			bool flag = this._client == null;
			if (flag)
			{
				try
				{
					this._client = new UdpClient(NetUdpClient.MulcaticasPort);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Port " + NetUdpClient.MulcaticasPort + " is in used. ");
					Environment.Exit(0);
				}
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000974 RID: 2420 RVA: 0x0002A3AC File Offset: 0x000285AC
		// (remove) Token: 0x06000975 RID: 2421 RVA: 0x0002A3E4 File Offset: 0x000285E4
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event NetUdpClient.OnDataReceive DataReceiveEvent;

		// Token: 0x06000976 RID: 2422 RVA: 0x0002A41C File Offset: 0x0002861C
		protected override void beginReceive()
		{
			bool flag = !this.isjoin;
			if (flag)
			{
				this._client.JoinMulticastGroup(IPAddress.Parse(NetUdpClient.MulcaticastIp));
			}
			this.isjoin = true;
			this._client.BeginReceive(new AsyncCallback(this.ReceiveCallback), this._client);
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x0002A474 File Offset: 0x00028674
		protected void changeNIC(string address)
		{
			this._client.DropMulticastGroup(IPAddress.Parse(NetUdpClient.MulcaticastIp));
			this._client.JoinMulticastGroup(IPAddress.Parse(NetUdpClient.MulcaticastIp), IPAddress.Parse(address));
			this._client.BeginReceive(new AsyncCallback(this.ReceiveCallback), this._client);
		}

		// Token: 0x06000978 RID: 2424 RVA: 0x0002A4D4 File Offset: 0x000286D4
		private void ReceiveCallback(IAsyncResult async)
		{
			UdpClient udpClient = (UdpClient)async.AsyncState;
			IPEndPoint ipendPoint = (IPEndPoint)udpClient.Client.LocalEndPoint;
			byte[] array;
			try
			{
				array = udpClient.EndReceive(async, ref ipendPoint);
			}
			catch
			{
				return;
			}
			try
			{
				udpClient.BeginReceive(new AsyncCallback(this.ReceiveCallback), udpClient);
			}
			catch
			{
				return;
			}
			bool flag = array.Length >= 4 && ipendPoint.Address.ToString() != IPProces.getIPAddress() && array[array.Length - 4] != 9 && array[array.Length - 3] != 108;
			if (flag)
			{
				NetUdpClient.OnDataReceive dataReceiveEvent = this.DataReceiveEvent;
				if (dataReceiveEvent != null)
				{
					dataReceiveEvent(ipendPoint.Address.ToString(), array);
				}
			}
		}

		// Token: 0x06000979 RID: 2425
		[DllImport("IpHlpApi.dll")]
		private static extern int SendARP(int dest, int host, ref long mac, ref int length);

		// Token: 0x0600097A RID: 2426
		[DllImport("ws2_32.dll")]
		private static extern int inet_addr(string ip);

		// Token: 0x0600097B RID: 2427 RVA: 0x0002A578 File Offset: 0x00028778
		public static string getRemoteMac(string remoteIP)
		{
			return BitConverter.ToString(NetUdpClient.getMacByIPAddress(IPAddress.Parse(remoteIP)));
		}

		// Token: 0x0600097C RID: 2428 RVA: 0x0002A59C File Offset: 0x0002879C
		public static byte[] getMacByIPAddress(IPAddress ip)
		{
			long num = 0L;
			int num2 = 6;
			int num3 = NetUdpClient.SendARP(BitConverter.ToInt32(ip.GetAddressBytes(), 0), 0, ref num, ref num2);
			bool flag = num3 != 0;
			if (flag)
			{
				Debug.WriteLine("IP不存在");
			}
			byte[] array = new byte[6];
			Array.Copy(BitConverter.GetBytes(num), array, 6);
			return array;
		}

		// Token: 0x0600097D RID: 2429 RVA: 0x0000A115 File Offset: 0x00008315
		public override void clear()
		{
			base.clear();
		}

		// Token: 0x0600097E RID: 2430 RVA: 0x0002A5F8 File Offset: 0x000287F8
		public override bool isConnected()
		{
			return true;
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x0002A60C File Offset: 0x0002880C
		public void sendMulticast(byte[] data)
		{
			IPEndPoint ipendPoint = new IPEndPoint(this.MulticastAddress, this.MulticastPort);
			try
			{
				this._client.Send(data, data.Length, ipendPoint);
				this._client.Close();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
			}
		}

		// Token: 0x06000980 RID: 2432 RVA: 0x0002A670 File Offset: 0x00028870
		public void sendMulticast(byte[] data, IPAddress address, int port)
		{
			IPEndPoint ipendPoint = new IPEndPoint(address, port);
			try
			{
				this._client.Send(data, data.Length, ipendPoint);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
			}
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x0002A6BC File Offset: 0x000288BC
		public void sendBroadCast(byte[] data, int port)
		{
			IPEndPoint ipendPoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), port);
			try
			{
				this._client.Send(data, data.Length, ipendPoint);
				this._client.Close();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
			}
		}

		// Token: 0x06000982 RID: 2434 RVA: 0x0000A11F File Offset: 0x0000831F
		public override void sendByte(byte[] sdata)
		{
			this.sendMulticast(sdata, IPAddress.Parse(NetUdpClient.MulcaticastIp), NetUdpClient.MulcaticasPort);
		}

		// Token: 0x06000983 RID: 2435 RVA: 0x0002A720 File Offset: 0x00028920
		private void dealPort()
		{
			int num = 9000;
			Process process = new Process();
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.RedirectStandardInput = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.CreateNoWindow = true;
			List<int> pidByPort = NetUdpClient.GetPidByPort(process, num);
			List<string> processNameByPid = NetUdpClient.GetProcessNameByPid(process, pidByPort);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Port " + num + " is used by process:\r\n");
			foreach (string text in processNameByPid)
			{
				stringBuilder.Append(text + "\r\n");
			}
			MessageBox.Show(string.Concat(stringBuilder));
		}

		// Token: 0x06000984 RID: 2436 RVA: 0x0002A820 File Offset: 0x00028A20
		private static List<int> GetPidByPort(Process p, int port)
		{
			p.Start();
			p.StandardInput.WriteLine("netstat -ano|find \"{0}\"", port);
			p.StandardInput.WriteLine("exit");
			StreamReader standardOutput = p.StandardOutput;
			string text = standardOutput.ReadLine();
			List<int> list = new List<int>();
			while (!standardOutput.EndOfStream)
			{
				text = text.Trim();
				bool flag = text.Length > 0 && (text.Contains("TCP") || text.Contains("UDP"));
				if (flag)
				{
					Regex regex = new Regex("\\s+");
					string[] array = regex.Split(text);
					bool flag2 = array.Length >= 4;
					if (flag2)
					{
						int num;
						bool flag3 = int.TryParse(array[3], out num);
						bool flag4 = flag3 && !list.Contains(num);
						if (flag4)
						{
							list.Add(num);
						}
					}
				}
				text = standardOutput.ReadLine();
			}
			p.WaitForExit();
			standardOutput.Close();
			p.Close();
			return list;
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x0002A93C File Offset: 0x00028B3C
		private static List<string> GetProcessNameByPid(Process p, List<int> list_pid)
		{
			p.Start();
			List<string> list = new List<string>();
			foreach (int num in list_pid)
			{
				p.StandardInput.WriteLine("tasklist |find \"{0}\"", num);
				p.StandardInput.WriteLine("exit");
				StreamReader standardOutput = p.StandardOutput;
				string text = standardOutput.ReadLine();
				while (!standardOutput.EndOfStream)
				{
					text = text.Trim();
					bool flag = text.Length > 0 && text.Contains(".exe");
					if (flag)
					{
						Regex regex = new Regex("\\s+");
						string[] array = regex.Split(text);
						bool flag2 = array.Length != 0;
						if (flag2)
						{
							list.Add(array[0]);
						}
					}
					text = standardOutput.ReadLine();
				}
				p.WaitForExit();
				standardOutput.Close();
			}
			p.Close();
			return list;
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x0002AA64 File Offset: 0x00028C64
		private static void PidKill(Process p, List<int> list_pid)
		{
			p.Start();
			foreach (int num in list_pid)
			{
				p.StandardInput.WriteLine("taskkill /pid " + num + " /f");
				p.StandardInput.WriteLine("exit");
			}
			p.Close();
		}

		// Token: 0x040004C9 RID: 1225
		public static string MulcaticastIp = "239.254.50.123";

		// Token: 0x040004CA RID: 1226
		public static int MulcaticasPort = 9000;

		// Token: 0x040004CB RID: 1227
		public static NetUdpClient netUdpClient;

		// Token: 0x040004CC RID: 1228
		private UdpClient _client;

		// Token: 0x040004CD RID: 1229
		private byte[] _mRecData = new byte[8192];

		// Token: 0x040004CE RID: 1230
		private IPAddress MulticastAddress;

		// Token: 0x040004CF RID: 1231
		private int MulticastPort;

		// Token: 0x040004D0 RID: 1232
		public Socket UdpSocket;

		// Token: 0x040004D2 RID: 1234
		private bool havReceive;

		// Token: 0x040004D3 RID: 1235
		private bool isjoin = false;

		// Token: 0x020000BA RID: 186
		// (Invoke) Token: 0x06000989 RID: 2441
		public delegate void OnDataReceive(string ipAddress, byte[] data);
	}
}
