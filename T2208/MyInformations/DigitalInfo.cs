using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Windows.Input;
using JayLib.JaySerialization;
using JayLib.WPF.BasicClass;

namespace T2208.MyInformations
{
	// Token: 0x02000057 RID: 87
	[Serializable]
	public class DigitalInfo : NotificationObject, ISerializable
	{
		// Token: 0x1700018A RID: 394
		// (get) Token: 0x06000484 RID: 1156 RVA: 0x0001DD8C File Offset: 0x0001BF8C
		// (set) Token: 0x06000485 RID: 1157 RVA: 0x00006759 File Offset: 0x00004959
		public bool IsEnable
		{
			get
			{
				return this._IsEnable;
			}
			set
			{
				this._IsEnable = value;
				this.OnPropertyChanged<bool>(() => this.IsEnable);
			}
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x06000486 RID: 1158 RVA: 0x0001DDA4 File Offset: 0x0001BFA4
		// (set) Token: 0x06000487 RID: 1159 RVA: 0x0001DDBC File Offset: 0x0001BFBC
		public int Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				this._Value = value;
				this.SendValue = (byte)value;
				this.OnPropertyChanged<int>(() => this.Value);
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06000488 RID: 1160 RVA: 0x0001DE10 File Offset: 0x0001C010
		// (set) Token: 0x06000489 RID: 1161 RVA: 0x00006799 File Offset: 0x00004999
		public byte SendValue
		{
			get
			{
				return this._SendValue;
			}
			set
			{
				this._SendValue = value;
				this.OnPropertyChanged<byte>(() => this.SendValue);
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x0600048A RID: 1162 RVA: 0x0001DE28 File Offset: 0x0001C028
		// (set) Token: 0x0600048B RID: 1163 RVA: 0x000067D9 File Offset: 0x000049D9
		public bool IsFrontSet
		{
			get
			{
				return this._IsFrontSet;
			}
			set
			{
				this._IsFrontSet = value;
				this.OnPropertyChanged<bool>(() => this.IsFrontSet);
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x0600048C RID: 1164 RVA: 0x0001DE40 File Offset: 0x0001C040
		// (set) Token: 0x0600048D RID: 1165 RVA: 0x00006819 File Offset: 0x00004A19
		public string ChannelName
		{
			get
			{
				return this._ChannelName;
			}
			set
			{
				this._ChannelName = value;
				this.OnPropertyChanged<string>(() => this.ChannelName);
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x0600048E RID: 1166 RVA: 0x0001DE58 File Offset: 0x0001C058
		// (set) Token: 0x0600048F RID: 1167 RVA: 0x00006859 File Offset: 0x00004A59
		public ICommand CommonCommand
		{
			get
			{
				return this._CommonCommand;
			}
			set
			{
				this._CommonCommand = value;
				this.OnPropertyChanged<ICommand>(() => this.CommonCommand);
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06000490 RID: 1168 RVA: 0x00006899 File Offset: 0x00004A99
		// (set) Token: 0x06000491 RID: 1169 RVA: 0x000068A1 File Offset: 0x00004AA1
		public bool TempInputIsFrontSet
		{
			get
			{
				return this._TempIsFrontSet;
			}
			set
			{
				this._TempIsFrontSet = value;
			}
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x000047E7 File Offset: 0x000029E7
		public DigitalInfo()
		{
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x000047F1 File Offset: 0x000029F1
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			SerializerHelper.SerializationPropertyHelper(info, this, new Type[]
			{
				typeof(RelayCommand),
				typeof(RelayCommand<int>),
				typeof(ICommand)
			});
			SerializerHelper.SerializationFieldHelper(info, this);
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x00013488 File Offset: 0x00011688
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		protected DigitalInfo(SerializationInfo info, StreamingContext context)
		{
			SerializerHelper.DeserializtionPropertyHelper(info, this, new Type[]
			{
				typeof(RelayCommand),
				typeof(RelayCommand<int>),
				typeof(ICommand)
			});
			SerializerHelper.DeSerializationFieldHelper(info, this);
		}

		// Token: 0x040002CB RID: 715
		private bool _IsEnable;

		// Token: 0x040002CC RID: 716
		private int _Value;

		// Token: 0x040002CD RID: 717
		private byte _SendValue;

		// Token: 0x040002CE RID: 718
		private bool _IsFrontSet;

		// Token: 0x040002CF RID: 719
		private string _ChannelName;

		// Token: 0x040002D0 RID: 720
		[NonSerialized]
		private ICommand _CommonCommand;

		// Token: 0x040002D1 RID: 721
		private bool _TempIsFrontSet;
	}
}
