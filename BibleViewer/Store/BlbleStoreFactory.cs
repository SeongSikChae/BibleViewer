using System.IO;

namespace BibleViewer.Store
{
	using Entity;

	public static class BlbleStoreFactory
	{
		public static IBibleStore Create(DirectoryInfo storeDir, BibleType bibleType, BibleSubject bibleSubject)
		{
			return new IBibleStore.BibleStore(storeDir, bibleType.Code, bibleSubject.Code);
		}
	}
}
