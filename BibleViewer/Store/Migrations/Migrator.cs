using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace BibleViewer.Store.Migrations
{
	using Context;

	public static class Migrator
	{
		public static void Migrate(DirectoryInfo dir, IServiceProvider serviceProvider)
		{
			FileInfo migrateInfoFile = dir.GetFileInfo(MigrateInfo.FILE_PATH);
			MigrateInfo newMigrateInfo = new MigrateInfo();
			if (migrateInfoFile.Exists)
			{
				YamlDotNet.Serialization.Deserializer deserializer = new YamlDotNet.Serialization.Deserializer();
				using (StreamReader reader = migrateInfoFile.OpenText())
				{
					MigrateInfo currentMigrateInfo = deserializer.Deserialize<MigrateInfo>(reader);
					if (currentMigrateInfo.Version.Equals(newMigrateInfo.Version))
						return;
				}
			}

			if (dir.Exists)
				dir.Delete(true);
			else 
				dir.Create();

			BibleContext context = serviceProvider.GetRequiredService<BibleContext>();
			context.Database.MigrateAsync();

			YamlDotNet.Serialization.Serializer serializer = new YamlDotNet.Serialization.Serializer();
			using (StreamWriter writer = migrateInfoFile.CreateText())
			{
				serializer.Serialize(writer, newMigrateInfo);
			}
		}
	}
}
