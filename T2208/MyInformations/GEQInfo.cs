using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;
using JayLib.JaySerialization;
using JayLib.WPF.BasicClass;
using T2208.ViewModels;

namespace T2208.MyInformations
{
	// Token: 0x0200005F RID: 95
	[Serializable]
	public class GEQInfo : NotificationObject, ISerializable
	{
		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x060004F2 RID: 1266 RVA: 0x0001E688 File Offset: 0x0001C888
		// (set) Token: 0x060004F3 RID: 1267 RVA: 0x00006F96 File Offset: 0x00005196
		public string ChannnelName
		{
			get
			{
				return this._ChannnelName;
			}
			set
			{
				this._ChannnelName = value;
				this.OnPropertyChanged<string>(() => this.ChannnelName);
			}
		}

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x060004F4 RID: 1268 RVA: 0x0001E6A0 File Offset: 0x0001C8A0
		// (set) Token: 0x060004F5 RID: 1269 RVA: 0x00006FD6 File Offset: 0x000051D6
		public List<GEQFrequenceValue> GEQArray
		{
			get
			{
				return this._GEQArray;
			}
			set
			{
				this._GEQArray = value;
				this.OnPropertyChanged<List<GEQFrequenceValue>>(() => this.GEQArray);
			}
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x060004F6 RID: 1270 RVA: 0x0001E6B8 File Offset: 0x0001C8B8
		// (set) Token: 0x060004F7 RID: 1271 RVA: 0x00007016 File Offset: 0x00005216
		public bool Bypass
		{
			get
			{
				return this._Bypass;
			}
			set
			{
				this._Bypass = value;
				this.OnPropertyChanged<bool>(() => this.Bypass);
			}
		}

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x060004F8 RID: 1272 RVA: 0x0001E6D0 File Offset: 0x0001C8D0
		// (set) Token: 0x060004F9 RID: 1273 RVA: 0x00007056 File Offset: 0x00005256
		public bool IsSelected
		{
			get
			{
				return this._IsSelected;
			}
			set
			{
				this._IsSelected = value;
				this.OnPropertyChanged<bool>(() => this.IsSelected);
			}
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x060004FA RID: 1274 RVA: 0x0001E6E8 File Offset: 0x0001C8E8
		// (set) Token: 0x060004FB RID: 1275 RVA: 0x00007096 File Offset: 0x00005296
		public int PresetIndex
		{
			get
			{
				return this._PresetIndex;
			}
			set
			{
				this._PresetIndex = value;
				this.OnPropertyChanged<int>(() => this.PresetIndex);
			}
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x060004FC RID: 1276 RVA: 0x000070D6 File Offset: 0x000052D6
		// (set) Token: 0x060004FD RID: 1277 RVA: 0x000070DE File Offset: 0x000052DE
		public int Index { get; set; }

		// Token: 0x060004FE RID: 1278 RVA: 0x0001E700 File Offset: 0x0001C900
		public GEQInfo()
		{
			for (int i = 0; i < Const.GEQFrequenceStrings.Length; i++)
			{
				this.GEQArray.Add(new GEQFrequenceValue
				{
					FrequenceName = Const.GEQFrequenceStrings[i],
					Index = i
				});
			}
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x000070E7 File Offset: 0x000052E7
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			SerializerHelper.SerializationPropertyHelper(info, this, new Type[0]);
			SerializerHelper.SerializationFieldHelper(info, this);
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x00007100 File Offset: 0x00005300
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		protected GEQInfo(SerializationInfo info, StreamingContext context)
		{
			SerializerHelper.DeserializtionPropertyHelper(info, this, new Type[0]);
			SerializerHelper.DeSerializationFieldHelper(info, this);
		}

		// Token: 0x040002FC RID: 764
		private string _ChannnelName;

		// Token: 0x040002FD RID: 765
		private List<GEQFrequenceValue> _GEQArray = new List<GEQFrequenceValue>();

		// Token: 0x040002FE RID: 766
		private bool _Bypass;

		// Token: 0x040002FF RID: 767
		private bool _IsSelected;

		// Token: 0x04000300 RID: 768
		private int _PresetIndex;
	}
}
