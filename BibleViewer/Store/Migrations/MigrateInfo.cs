using System;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace BibleViewer.Store.Migrations
{
	public sealed class MigrateInfo
	{
		public const string FILE_PATH = "migrate_info.yml";

		public string Version { get; set; } = "1.0.0";
	}
}
