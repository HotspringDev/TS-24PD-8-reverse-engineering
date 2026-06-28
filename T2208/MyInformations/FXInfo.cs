using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using JayLib.JaySerialization;
using JayLib.WPF.BasicClass;

namespace T2208.MyInformations
{
	// Token: 0x0200005A RID: 90
	[Serializable]
	public class FXInfo<T> : GroupInfo<T>, ISerializable
	{
		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x060004CD RID: 1229 RVA: 0x0001E360 File Offset: 0x0001C560
		// (set) Token: 0x060004CE RID: 1230 RVA: 0x0001E378 File Offset: 0x0001C578
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

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x060004CF RID: 1231 RVA: 0x0001E3C8 File Offset: 0x0001C5C8
		// (set) Token: 0x060004D0 RID: 1232 RVA: 0x0001E3E0 File Offset: 0x0001C5E0
		public int PresentFXIndex
		{
			get
			{
				return this._PresentFXIndex;
			}
			set
			{
				this._PresentFXIndex = value;
				this.OnPropertyChanged<int>(() => this.PresentFXIndex);
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x060004D1 RID: 1233 RVA: 0x0001E430 File Offset: 0x0001C630
		// (set) Token: 0x060004D2 RID: 1234 RVA: 0x0001E448 File Offset: 0x0001C648
		public int FXIndex
		{
			get
			{
				return this._FXIndex;
			}
			set
			{
				this._FXIndex = value;
				this.OnPropertyChanged<int>(() => this.FXIndex);
			}
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x00006CDD File Offset: 0x00004EDD
		public FXInfo()
		{
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x00006CE7 File Offset: 0x00004EE7
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		protected FXInfo(SerializationInfo info, StreamingContext context)
		{
			SerializerHelper.DeserializtionPropertyHelper(info, this, new Type[]
			{
				typeof(RelayCommand),
				typeof(RelayCommand<int>)
			});
			SerializerHelper.DeSerializationFieldHelper(info, this);
		}

		// Token: 0x040002EA RID: 746
		private int _PresetIndex;

		// Token: 0x040002EB RID: 747
		private int _PresentFXIndex;

		// Token: 0x040002EC RID: 748
		private int _FXIndex;
	}
}
