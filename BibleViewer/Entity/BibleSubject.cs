namespace BibleViewer.Entity
{
	public sealed class BibleSubject
	{
		public BibleSubject() { }
		public BibleSubject(int index, string code, string shortName, string name)
		{
			Index = index;
			Code = code;
			ShortName = shortName;
			Name = name;
		}

		public int Index { get; set; }
		public string Code { get; set; }
		public string ShortName { get; set; }
		public string Name { get; set; }
	}
}
