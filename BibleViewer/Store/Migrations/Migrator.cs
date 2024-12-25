using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace BibleViewer.Store.Migrations
{
	using BibleViewer.Entity;
	using Context;
	using System.IO.Compression;
	using System.Linq;

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

			if (!dir.Exists)
				dir.Create();
			else
			{
				foreach (DirectoryInfo childDir in dir.GetDirectories("*", SearchOption.TopDirectoryOnly))
					childDir.Delete(true);
				foreach (FileInfo f in dir.GetFiles("*", SearchOption.TopDirectoryOnly))
				{
					if (!f.Name.EndsWith(".zip"))
						f.Delete();
				}
			}

			BibleContext context = serviceProvider.GetRequiredService<BibleContext>();
			context.Database.MigrateAsync();

			foreach (BibleType bibleType in context.BibleType.ToList())
			{
				FileInfo dataFile = dir.GetFileInfo($"{bibleType.Code}.zip");
				if (dataFile.Exists)
					ZipFile.ExtractToDirectory(dataFile.FullName, dir.GetChildDirectoryInfo(bibleType.Code).FullName);
			}

			YamlDotNet.Serialization.Serializer serializer = new YamlDotNet.Serialization.Serializer();
			using (StreamWriter writer = migrateInfoFile.CreateText())
			{
				serializer.Serialize(writer, newMigrateInfo);
			}
		}
	}
}
