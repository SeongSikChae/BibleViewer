using BibleViewer.Forms;
using System;
using System.Threading;
using System.Windows.Forms;

namespace BibleViewer
{
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
				Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
				mutex.ReleaseMutex();
			}
			else
				MessageBox.Show("이미 실행중입니다.");
		}
	}
}
