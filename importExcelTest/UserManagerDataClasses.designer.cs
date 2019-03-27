﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace negar
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Mali")]
	public partial class UserManagerDataClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCityTable(CityTable instance);
    partial void UpdateCityTable(CityTable instance);
    partial void DeleteCityTable(CityTable instance);
    partial void InsertUserTable(UserTable instance);
    partial void UpdateUserTable(UserTable instance);
    partial void DeleteUserTable(UserTable instance);
    #endregion
		
		public UserManagerDataClassesDataContext() : 
				base("Data Source=.;Initial Catalog=Mali;Integrated Security=True", mappingSource)
		{
			OnCreated();
		}
		
		public UserManagerDataClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public UserManagerDataClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public UserManagerDataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public UserManagerDataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<CityTable> CityTables
		{
			get
			{
				return this.GetTable<CityTable>();
			}
		}
		
		public System.Data.Linq.Table<UserTable> UserTables
		{
			get
			{
				return this.GetTable<UserTable>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CityTable")]
	public partial class CityTable : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _Id;
		
		private string _CityName;
		
		private EntityRef<UserTable> _UserTable;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(long value);
    partial void OnIdChanged();
    partial void OnCityNameChanging(string value);
    partial void OnCityNameChanged();
    #endregion
		
		public CityTable()
		{
			this._UserTable = default(EntityRef<UserTable>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					if (this._UserTable.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CityName", DbType="NVarChar(MAX)")]
		public string CityName
		{
			get
			{
				return this._CityName;
			}
			set
			{
				if ((this._CityName != value))
				{
					this.OnCityNameChanging(value);
					this.SendPropertyChanging();
					this._CityName = value;
					this.SendPropertyChanged("CityName");
					this.OnCityNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="UserTable_CityTable", Storage="_UserTable", ThisKey="Id", OtherKey="City", IsForeignKey=true)]
		public UserTable UserTable
		{
			get
			{
				return this._UserTable.Entity;
			}
			set
			{
				UserTable previousValue = this._UserTable.Entity;
				if (((previousValue != value) 
							|| (this._UserTable.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._UserTable.Entity = null;
						previousValue.CityTables.Remove(this);
					}
					this._UserTable.Entity = value;
					if ((value != null))
					{
						value.CityTables.Add(this);
						this._Id = value.City;
					}
					else
					{
						this._Id = default(long);
					}
					this.SendPropertyChanged("UserTable");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UserTable")]
	public partial class UserTable : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _User;
		
		private string _Password;
		
		private long _City;
		
		private string _Name;
		
		private string _Family;
		
		private System.Nullable<bool> _Permission;
		
		private string _Messages;
		
		private System.Nullable<bool> _Update;
		
		private System.Nullable<bool> _AdminVersion;
		
		private System.Nullable<int> _Version;
		
		private EntitySet<CityTable> _CityTables;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnUserChanging(string value);
    partial void OnUserChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnCityChanging(long value);
    partial void OnCityChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnFamilyChanging(string value);
    partial void OnFamilyChanged();
    partial void OnPermissionChanging(System.Nullable<bool> value);
    partial void OnPermissionChanged();
    partial void OnMessagesChanging(string value);
    partial void OnMessagesChanged();
    partial void OnUpdateChanging(System.Nullable<bool> value);
    partial void OnUpdateChanged();
    partial void OnAdminVersionChanging(System.Nullable<bool> value);
    partial void OnAdminVersionChanged();
    partial void OnVersionChanging(System.Nullable<int> value);
    partial void OnVersionChanged();
    #endregion
		
		public UserTable()
		{
			this._CityTables = new EntitySet<CityTable>(new Action<CityTable>(this.attach_CityTables), new Action<CityTable>(this.detach_CityTables));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[User]", Storage="_User", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string User
		{
			get
			{
				return this._User;
			}
			set
			{
				if ((this._User != value))
				{
					this.OnUserChanging(value);
					this.SendPropertyChanging();
					this._User = value;
					this.SendPropertyChanged("User");
					this.OnUserChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_City", DbType="BigInt NOT NULL")]
		public long City
		{
			get
			{
				return this._City;
			}
			set
			{
				if ((this._City != value))
				{
					this.OnCityChanging(value);
					this.SendPropertyChanging();
					this._City = value;
					this.SendPropertyChanged("City");
					this.OnCityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Family", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Family
		{
			get
			{
				return this._Family;
			}
			set
			{
				if ((this._Family != value))
				{
					this.OnFamilyChanging(value);
					this.SendPropertyChanging();
					this._Family = value;
					this.SendPropertyChanged("Family");
					this.OnFamilyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Permission", DbType="Bit")]
		public System.Nullable<bool> Permission
		{
			get
			{
				return this._Permission;
			}
			set
			{
				if ((this._Permission != value))
				{
					this.OnPermissionChanging(value);
					this.SendPropertyChanging();
					this._Permission = value;
					this.SendPropertyChanged("Permission");
					this.OnPermissionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Messages", DbType="NVarChar(MAX)")]
		public string Messages
		{
			get
			{
				return this._Messages;
			}
			set
			{
				if ((this._Messages != value))
				{
					this.OnMessagesChanging(value);
					this.SendPropertyChanging();
					this._Messages = value;
					this.SendPropertyChanged("Messages");
					this.OnMessagesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Update]", Storage="_Update", DbType="Bit")]
		public System.Nullable<bool> Update
		{
			get
			{
				return this._Update;
			}
			set
			{
				if ((this._Update != value))
				{
					this.OnUpdateChanging(value);
					this.SendPropertyChanging();
					this._Update = value;
					this.SendPropertyChanged("Update");
					this.OnUpdateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AdminVersion", DbType="Bit")]
		public System.Nullable<bool> AdminVersion
		{
			get
			{
				return this._AdminVersion;
			}
			set
			{
				if ((this._AdminVersion != value))
				{
					this.OnAdminVersionChanging(value);
					this.SendPropertyChanging();
					this._AdminVersion = value;
					this.SendPropertyChanged("AdminVersion");
					this.OnAdminVersionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Version", DbType="Int")]
		public System.Nullable<int> Version
		{
			get
			{
				return this._Version;
			}
			set
			{
				if ((this._Version != value))
				{
					this.OnVersionChanging(value);
					this.SendPropertyChanging();
					this._Version = value;
					this.SendPropertyChanged("Version");
					this.OnVersionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="UserTable_CityTable", Storage="_CityTables", ThisKey="City", OtherKey="Id")]
		public EntitySet<CityTable> CityTables
		{
			get
			{
				return this._CityTables;
			}
			set
			{
				this._CityTables.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_CityTables(CityTable entity)
		{
			this.SendPropertyChanging();
			entity.UserTable = this;
		}
		
		private void detach_CityTables(CityTable entity)
		{
			this.SendPropertyChanging();
			entity.UserTable = null;
		}
	}
}
#pragma warning restore 1591
