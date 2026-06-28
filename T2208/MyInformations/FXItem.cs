using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Security.Permissions;
using JayLib.JaySerialization;
using JayLib.WPF.BasicClass;

namespace T2208.MyInformations
{
	// Token: 0x0200005B RID: 91
	[Serializable]
	public class FXItem : NotificationObject, ISerializable
	{
		// Token: 0x170001AC RID: 428
		// (get) Token: 0x060004D5 RID: 1237 RVA: 0x0001E498 File Offset: 0x0001C698
		// (set) Token: 0x060004D6 RID: 1238 RVA: 0x00006D21 File Offset: 0x00004F21
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

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x060004D7 RID: 1239 RVA: 0x00006D61 File Offset: 0x00004F61
		// (set) Token: 0x060004D8 RID: 1240 RVA: 0x00006D69 File Offset: 0x00004F69
		public bool IsSelected
		{
			get
			{
				return this._isSelected;
			}
			set
			{
				this._isSelected = value;
				this.OnPropertyChanged<bool>(() => this.IsSelected);
			}
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x060004D9 RID: 1241 RVA: 0x0001E4B0 File Offset: 0x0001C6B0
		// (set) Token: 0x060004DA RID: 1242 RVA: 0x00006DA9 File Offset: 0x00004FA9
		public ObservableCollection<EffectInfo> Effect
		{
			get
			{
				return this._Effect;
			}
			set
			{
				this._Effect = value;
				this.OnPropertyChanged<ObservableCollection<EffectInfo>>(() => this.Effect);
			}
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x000047E7 File Offset: 0x000029E7
		public FXItem()
		{
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x00006CAA File Offset: 0x00004EAA
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			SerializerHelper.SerializationPropertyHelper(info, this, new Type[]
			{
				typeof(RelayCommand),
				typeof(RelayCommand<int>)
			});
			SerializerHelper.SerializationFieldHelper(info, this);
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x00006DE9 File Offset: 0x00004FE9
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		protected FXItem(SerializationInfo info, StreamingContext context)
		{
			SerializerHelper.DeserializtionPropertyHelper(info, this, new Type[]
			{
				typeof(RelayCommand),
				typeof(RelayCommand<int>)
			});
			SerializerHelper.DeSerializationFieldHelper(info, this);
		}

		// Token: 0x040002ED RID: 749
		private string _Name;

		// Token: 0x040002EE RID: 750
		private bool _isSelected;

		// Token: 0x040002EF RID: 751
		private ObservableCollection<EffectInfo> _Effect;
	}
}
