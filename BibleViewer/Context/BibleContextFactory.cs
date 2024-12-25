using BibleViewer.Store;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BibleViewer.Context
{
	public class BibleContextFactory : IDesignTimeDbContextFactory<BibleContext>
	{
		public BibleContext CreateDbContext(string[] args)
		{
			DbContextOptionsBuilder<BibleContext> builder = new DbContextOptionsBuilder<BibleContext>().UseSqlite($"Data Source={IBibleStore.STORE_PATH}\\{BibleContext.FILE_PATH}");
			return new BibleContext(builder.Options);
		}
	}
}
