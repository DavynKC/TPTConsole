using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;
using System.Configuration;

namespace TPTConsole.Model
{
	public partial class TPTEntities
	{
		EntityConnectionStringBuilder _builder;
		private EntityConnectionStringBuilder EntityConnStrBuilder
		{
			get
			{
				if (_builder == null)
				{
					_builder = new EntityConnectionStringBuilder(Connection.ConnectionString);
					if (!String.IsNullOrWhiteSpace(_builder.Name))
						_builder = new EntityConnectionStringBuilder(
							ConfigurationManager.ConnectionStrings[_builder.Name].ConnectionString);
				}
				return _builder;
			}
		}

		public string ProviderName
		{
			get { return EntityConnStrBuilder.Provider; }
		}

		public string ProviderConnectionString
		{
			get { return EntityConnStrBuilder.ProviderConnectionString; }
		}
	}
}
