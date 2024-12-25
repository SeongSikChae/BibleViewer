using System.IO;

namespace BibleViewer.Store
{
	using Entity;
	using System.Windows.Forms;

	public static class BlbleStoreFactory
	{
		public static IBibleStore Create(DirectoryInfo storeDir, BibleType bibleType, BibleSubject bibleSubject)
		{
			DirectoryInfo typeDir = storeDir.GetChildDirectoryInfo(bibleType.Code);
			if (!typeDir.Exists)
			{
				MessageBox.Show($"{bibleType.Name} 데이터가 존재하지 않습니다.");
				return new IBibleStore.NullBibleStore();
			}
			return new IBibleStore.BibleStore(storeDir, bibleType.Code, bibleSubject.Code);
		}
	}
}
