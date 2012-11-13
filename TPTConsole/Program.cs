using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TPTConsole.Model;
using Dapper;
using System.Data.Common;

namespace TPTConsole
{
	class Program
	{
		#region LoadWithCustomSQL
		static void LoadWithCustomSQL()
		{
			using (var context = new TPTEntities())
			{
				// Load one relation with LINQ. Could also load Imperial, but there isn't as much data for them.
				var allegiance = context.Allegiances.Where(a => a.Name == "Rebel").First();
				var factory = DbProviderFactories.GetFactory(context.ProviderName);

				// Custom loading
				using (var connection = factory.CreateConnection())
				{
					connection.ConnectionString = context.ProviderConnectionString;
					connection.Open();
					var sql = @"
select * from dbo.Sentient a join dbo.Droid b on a.id = b.id
select * from dbo.Sentient a join dbo.Jedi b on a.id = b.id
select * from dbo.Sentient a join dbo.Other b on a.id = b.id";
					using (var multi = connection.QueryMultiple(sql))
					{
						var droids = multi.Read<Droid>().ToList();
						var jedis = multi.Read<Jedi>().ToList();
						var others = multi.Read<Other>().ToList();

						Console.WriteLine("Droids: {0}", droids.Count);
						Console.WriteLine("Jedis: {0}", jedis.Count);
						Console.WriteLine("Others: {0}", others.Count);

						foreach (var jedi in jedis)
							context.Sentients.Attach(jedi);
						foreach (var droid in droids)
							context.Sentients.Attach(droid);
						foreach (var other in others)
							context.Sentients.Attach(other);

						// Show that the relationships of the entities loaded with LINQ work with the custom attached ones
						foreach (var sentient in allegiance.Sentients)
							Console.WriteLine(sentient.Describe());
					}
					connection.Close();
				}
			}
		}
		#endregion LoadWithCustomSQL

		#region LoadWithEF
		static void LoadWithEF()
		{
			using (var context = new TPTEntities())
			{
				foreach (var sentient in context.Sentients)
					Console.WriteLine(sentient.Describe());
			}
		}
		#endregion LoadWithEF

		static void Main(string[] args)
		{
			// Flip this switch to observe the difference in generated SQL using SQL Profiler
			bool customLoading = false;
			if (customLoading)
				LoadWithCustomSQL();
			else
				LoadWithEF();
			Console.ReadLine();
		}
	}
}
