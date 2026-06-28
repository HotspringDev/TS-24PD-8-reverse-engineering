using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Windows.Input;
using JayLib.JaySerialization;
using JayLib.WPF.BasicClass;

namespace T2208.ViewModels
{
	// Token: 0x0200002E RID: 46
	[Serializable]
	public class DCAItem : NotificationObject, ISerializable
	{
		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060001C6 RID: 454 RVA: 0x00013428 File Offset: 0x00011628
		// (set) Token: 0x060001C7 RID: 455 RVA: 0x000046E7 File Offset: 0x000028E7
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				this._Name = value;
				this.OnPropertyChanged<string>(() => this.Name);
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060001C8 RID: 456 RVA: 0x00013440 File Offset: 0x00011640
		// (set) Token: 0x060001C9 RID: 457 RVA: 0x00004727 File Offset: 0x00002927
		public ICommand Command
		{
			get
			{
				return this._Command;
			}
			set
			{
				this._Command = value;
				this.OnPropertyChanged<ICommand>(() => this.Command);
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060001CA RID: 458 RVA: 0x00013458 File Offset: 0x00011658
		// (set) Token: 0x060001CB RID: 459 RVA: 0x00004767 File Offset: 0x00002967
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

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060001CC RID: 460 RVA: 0x00013470 File Offset: 0x00011670
		// (set) Token: 0x060001CD RID: 461 RVA: 0x000047A7 File Offset: 0x000029A7
		public bool IsMute
		{
			get
			{
				return this._IsMute;
			}
			set
			{
				this._IsMute = value;
				this.OnPropertyChanged<bool>(() => this.IsMute);
			}
		}

		// Token: 0x060001CE RID: 462 RVA: 0x000047E7 File Offset: 0x000029E7
		public DCAItem()
		{
		}

		// Token: 0x060001CF RID: 463 RVA: 0x000047F1 File Offset: 0x000029F1
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

		// Token: 0x060001D0 RID: 464 RVA: 0x00013488 File Offset: 0x00011688
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		protected DCAItem(SerializationInfo info, StreamingContext context)
		{
			SerializerHelper.DeserializtionPropertyHelper(info, this, new Type[]
			{
				typeof(RelayCommand),
				typeof(RelayCommand<int>),
				typeof(ICommand)
			});
			SerializerHelper.DeSerializationFieldHelper(info, this);
		}

		// Token: 0x040000F0 RID: 240
		private string _Name;

		// Token: 0x040000F1 RID: 241
		private ICommand _Command;

		// Token: 0x040000F2 RID: 242
		private bool _IsSelected;

		// Token: 0x040000F3 RID: 243
		private bool _IsMute;
	}
}
