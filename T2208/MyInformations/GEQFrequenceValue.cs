using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using JayLib.JaySerialization;
using JayLib.WPF.BasicClass;

namespace T2208.MyInformations
{
	// Token: 0x02000060 RID: 96
	[Serializable]
	public class GEQFrequenceValue : NotificationObject, ISerializable
	{
		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000501 RID: 1281 RVA: 0x0001E760 File Offset: 0x0001C960
		// (set) Token: 0x06000502 RID: 1282 RVA: 0x0000712B File Offset: 0x0000532B
		public string FrequenceName
		{
			get
			{
				return this._FrequenceName;
			}
			set
			{
				this._FrequenceName = value;
				this.OnPropertyChanged<string>(() => this.FrequenceName);
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06000503 RID: 1283 RVA: 0x0001E778 File Offset: 0x0001C978
		// (set) Token: 0x06000504 RID: 1284 RVA: 0x0000716B File Offset: 0x0000536B
		public int GainValue
		{
			get
			{
				return this._GainValue;
			}
			set
			{
				this._GainValue = value;
				this.OnPropertyChanged<int>(() => this.GainValue);
			}
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06000505 RID: 1285 RVA: 0x000071AB File Offset: 0x000053AB
		// (set) Token: 0x06000506 RID: 1286 RVA: 0x000071B3 File Offset: 0x000053B3
		public int Index { get; set; }

		// Token: 0x06000507 RID: 1287 RVA: 0x000071BC File Offset: 0x000053BC
		public GEQFrequenceValue()
		{
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x000070E7 File Offset: 0x000052E7
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			SerializerHelper.SerializationPropertyHelper(info, this, new Type[0]);
			SerializerHelper.SerializationFieldHelper(info, this);
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x000071CE File Offset: 0x000053CE
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		protected GEQFrequenceValue(SerializationInfo info, StreamingContext context)
		{
			SerializerHelper.DeserializtionPropertyHelper(info, this, new Type[0]);
			SerializerHelper.DeSerializationFieldHelper(info, this);
		}

		// Token: 0x04000302 RID: 770
		private string _FrequenceName;

		// Token: 0x04000303 RID: 771
		private int _GainValue = 24;
	}
}
