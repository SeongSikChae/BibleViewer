using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace BibleViewer
{
	using Context;
	using Forms;
	using Store;
	using Store.Migrations;

	static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			using Mutex mutex = new(true, "BibleViewer5b72bd33-3e78-4647-b10a-d1a54e1ace1b", out bool flag);
			if (flag)
			{
				DirectoryInfo storeDir = new DirectoryInfo(IBibleStore.STORE_PATH);

				HostApplicationBuilder builder = Host.CreateApplicationBuilder();
				builder.Services.AddDbContext<BibleContext>(optionsAction: builder =>
				{
					builder.UseSqlite($"Data Source={IBibleStore.STORE_PATH}\\{BibleContext.FILE_PATH}");
				});
				builder.Services.AddSingleton<MainForm>();
				builder.Services.AddSingleton<DisplayForm>();

				Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);

				using (IHost host = builder.Build())
				{
					try
					{
						Migrator.Migrate(storeDir, host.Services);

						MainForm mainForm = host.Services.GetRequiredService<MainForm>();
						Application.Run(mainForm);
					}
					finally 
					{
						mutex.ReleaseMutex();
					}
				}				
			}
			else
				MessageBox.Show("이미 실행중입니다.");
		}
	}
}
