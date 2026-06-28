using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Windows.Input;
using JayLib.JaySerialization;
using JayLib.WPF.BasicClass;

namespace T2208.MyInformations
{
	// Token: 0x02000061 RID: 97
	[Serializable]
	public class GroupInfo<T> : NotificationObject, ISerializable
	{
		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x0600050A RID: 1290 RVA: 0x0001E790 File Offset: 0x0001C990
		// (set) Token: 0x0600050B RID: 1291 RVA: 0x0001E7A8 File Offset: 0x0001C9A8
		public string GroupName
		{
			get
			{
				return this._GroupName;
			}
			set
			{
				this._GroupName = value;
				this.OnPropertyChanged<string>(() => this.GroupName);
			}
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x0600050C RID: 1292 RVA: 0x0001E7F8 File Offset: 0x0001C9F8
		// (set) Token: 0x0600050D RID: 1293 RVA: 0x0001E810 File Offset: 0x0001CA10
		public ObservableCollection<T> GroupCollection
		{
			get
			{
				return this._GroupCollection;
			}
			set
			{
				this._GroupCollection = value;
				this.OnPropertyChanged<ObservableCollection<T>>(() => this.GroupCollection);
			}
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x000071F6 File Offset: 0x000053F6
		public virtual void Add(T newItem)
		{
			ObservableCollection<T> groupCollection = this.GroupCollection;
			if (groupCollection != null)
			{
				groupCollection.Add(newItem);
			}
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x0600050F RID: 1295 RVA: 0x0001E860 File Offset: 0x0001CA60
		// (set) Token: 0x06000510 RID: 1296 RVA: 0x0001E878 File Offset: 0x0001CA78
		public bool HasAllPost
		{
			get
			{
				return this._HasAllPost;
			}
			set
			{
				this._HasAllPost = value;
				this.OnPropertyChanged<bool>(() => this.HasAllPost);
			}
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x0000720C File Offset: 0x0000540C
		public GroupInfo()
		{
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x000047F1 File Offset: 0x000029F1
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

		// Token: 0x06000513 RID: 1299 RVA: 0x0001E8C8 File Offset: 0x0001CAC8
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		protected GroupInfo(SerializationInfo info, StreamingContext context)
		{
			SerializerHelper.DeserializtionPropertyHelper(info, this, new Type[]
			{
				typeof(RelayCommand),
				typeof(RelayCommand<int>),
				typeof(ICommand)
			});
			SerializerHelper.DeSerializationFieldHelper(info, this);
		}

		// Token: 0x04000305 RID: 773
		private string _GroupName;

		// Token: 0x04000306 RID: 774
		private ObservableCollection<T> _GroupCollection = new ObservableCollection<T>();

		// Token: 0x04000307 RID: 775
		private bool _HasAllPost;
	}
}
