using BibleViewer.Context;
using BibleViewer.Entity;
using BibleViewer.Store;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Revision;
using System.Text.RegularExpressions;

namespace BibleViewer.Forms
{
	public partial class MainForm : Form
	{
		public MainForm(BibleContext context, IServiceProvider serviceProvider, ILogger<MainForm> logger)
		{
			this.context = context;
			this.serviceProvider = serviceProvider;
			this.logger = logger;
			InitializeComponent();
			displayBox.DataSource = Screen.AllScreens.ToList();
			_ = InitializeAsync();
		}

		private readonly BibleContext context;
		private readonly IServiceProvider serviceProvider;
		private readonly ILogger<MainForm> logger;
		private static readonly Regex SearchPattern = new Regex("(?<Subject>\\S+) (?<Chapter>\\d+):(?<StartLine>\\d+)-(?<EndLine>\\d+)");
		private static readonly Regex SearchPattern2 = new Regex("(?<Subject>\\S+) (?<Chapter>\\d+):(?<Line>\\d+)");

		private async Task InitializeAsync()
		{
			{
				List<BibleType> list = await context.BibleType.OrderBy(p => p.Index).ToListAsync();
				bibleTypeBox.DataSource = list;
			}

			{
				List<BibleSubject> list = await context.BibleSubject.OrderBy(p => p.Index).ToListAsync();
				subjectBox.DataSource = list;
			}
		}

		private void ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			MessageBox.Show($"BibleViewer: {RevisionUtil.GetRevision<RevisionAttribute>()}", "버전");
		}

		private void SearchMode_CheckedChanged(object sender, EventArgs e)
		{
			if (chkSearchMode.Checked)
			{
				txtSearchBox.Enabled = true;
				subjectBox.Enabled = false;
				startChapterBox.Enabled = false;
				endChapterBox.Enabled = false;
				startLineBox.Enabled = false;
				endLineBox.Enabled = false;
			}
			else
			{
				txtSearchBox.Enabled = false;
				subjectBox.Enabled = true;
				startChapterBox.Enabled = true;
				endChapterBox.Enabled = true;
				startLineBox.Enabled = true;
				endLineBox.Enabled = true;
			}
		}

		private void SubjectBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			BibleType bibleType = (BibleType)bibleTypeBox.SelectedItem;
			BibleSubject bibleSubject = (BibleSubject)subjectBox.SelectedItem;
			using IBibleStore store = BlbleStoreFactory.Create(new System.IO.DirectoryInfo(IBibleStore.STORE_PATH), bibleType, bibleSubject);
			startChapterBox.DataSource = store.GetChaters().ToList();
		}

		private void StartChapterBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			List<BibleChapter> list = (List<BibleChapter>)startChapterBox.DataSource;
			BibleChapter bibleChapter = (BibleChapter)startChapterBox.SelectedItem;
			startLineBox.DataSource = bibleChapter.Lines.ToList();
			endChapterBox.DataSource = list.Where(item => item.Value >= bibleChapter.Value).ToList();
		}

		private void EndChapterBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			BibleChapter startBibleChater = (BibleChapter)startChapterBox.SelectedItem;
			BibleChapter endBibleChater = (BibleChapter)endChapterBox.SelectedItem;
			if (startBibleChater.Value == endBibleChater.Value)
				StartLineBox_SelectedIndexChanged(startLineBox, e);
			else
				endLineBox.DataSource = endBibleChater.Lines.ToList();
		}

		private void StartLineBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			BibleChapter startBibleChater = (BibleChapter)startChapterBox.SelectedItem;
			BibleChapter endBibleChater = (BibleChapter)endChapterBox.SelectedItem;
			if (endBibleChater is not null && startBibleChater.Value == endBibleChater.Value)
			{
				List<int> list = (List<int>)startLineBox.DataSource;
				endLineBox.DataSource = list.Where(item => item >= (int)startLineBox.SelectedItem).ToList();
			}
		}

		private void FullScreenMode_CheckedChanged(object sender, EventArgs e)
		{
			if (chkFullSize.Checked)
			{
				txtXPixel.Enabled = false;
				txtYPixel.Enabled = false;
			}
			else
			{
				txtXPixel.Enabled = true;
				txtYPixel.Enabled = true;
				Screen screen = (Screen)displayBox.SelectedItem;
				txtXPixel.Text = screen.Bounds.Width.ToString();
				txtYPixel.Text = screen.Bounds.Height.ToString();
			}
		}

		private void ShowButton_Click(object sender, EventArgs e)
		{
			SortedSet<BibleBody> bibleBodies = new SortedSet<BibleBody>();
			BibleSubject bibleSubject = null;
			if (chkSearchMode.Checked)
			{
				Match match = SearchPattern.Match(txtSearchBox.Text);
				Match match2 = SearchPattern2.Match(txtSearchBox.Text);
				if (match.Success)
				{
					BibleType bibleType = (BibleType)bibleTypeBox.SelectedItem;
					bibleSubject = context.BibleSubject.FirstOrDefault(item => item.ShortName.Equals(match.Groups["Subject"].Value) || item.Name.Equals(match.Groups["Subject"].Value));
					if (bibleSubject is null)
					{
						logger.Error("BibleSubject NotFound : {0}", match.Groups["Subject"].Value);
						return;
					}
					int chapter = int.Parse(match.Groups["Chapter"].Value);
					int startLine = int.Parse(match.Groups["StartLine"].Value);
					int endLine = int.Parse(match.Groups["EndLine"].Value);
					ISearchQuery q = new ISearchQuery.NamedQuery(IBibleStore.CHAPTER_FIELD_NAME, new ISearchQuery.RangeQuery(chapter, chapter, true, true));
					q = new ISearchQuery.BooleanAndQuery(q, new ISearchQuery.NamedQuery(IBibleStore.LINE_FIELD_NAME, new ISearchQuery.RangeQuery(startLine, endLine, true, true)));
					using IBibleStore store = BlbleStoreFactory.Create(new System.IO.DirectoryInfo(IBibleStore.STORE_PATH), bibleType, bibleSubject);
					bibleBodies = store.Search(q);
				}
				else if (match2.Success)
				{
					BibleType bibleType = (BibleType)bibleTypeBox.SelectedItem;
					bibleSubject = context.BibleSubject.FirstOrDefault(item => item.ShortName.Equals(match2.Groups["Subject"].Value) || item.Name.Equals(match2.Groups["Subject"].Value));
					if (bibleSubject is null)
					{
						logger.Error("BibleSubject NotFound : {0}", match2.Groups["Subject"].Value);
						return;
					}
					int chapter = int.Parse(match2.Groups["Chapter"].Value);
					int line = int.Parse(match2.Groups["Line"].Value);
					ISearchQuery q = new ISearchQuery.NamedQuery(IBibleStore.CHAPTER_FIELD_NAME, new ISearchQuery.RangeQuery(chapter, chapter, true, true));
					q = new ISearchQuery.BooleanAndQuery(q, new ISearchQuery.NamedQuery(IBibleStore.LINE_FIELD_NAME, new ISearchQuery.RangeQuery(line, line, true, true)));
					using IBibleStore store = BlbleStoreFactory.Create(new System.IO.DirectoryInfo(IBibleStore.STORE_PATH), bibleType, bibleSubject);
					bibleBodies = store.Search(q);
				}
			}
			else
			{
				ISearchQuery q;
				if (startChapterBox.SelectedValue.Equals(endChapterBox.SelectedValue))
				{
					q = new ISearchQuery.NamedQuery(IBibleStore.CHAPTER_FIELD_NAME, new ISearchQuery.RangeQuery((int)startChapterBox.SelectedValue, (int)startChapterBox.SelectedValue, true, true));
					q = new ISearchQuery.BooleanAndQuery(q, new ISearchQuery.NamedQuery(IBibleStore.LINE_FIELD_NAME, new ISearchQuery.RangeQuery((int)startLineBox.SelectedItem, (int)endLineBox.SelectedItem, true, true)));
				}
				else
				{
					int startChapter = ((BibleChapter)startChapterBox.SelectedItem).Value;
					int endChapter = ((BibleChapter)endChapterBox.SelectedItem).Value;

					{
						ISearchQuery l = new ISearchQuery.NamedQuery(IBibleStore.CHAPTER_FIELD_NAME, new ISearchQuery.RangeQuery(startChapter, startChapter, true, true));
						ISearchQuery r = new ISearchQuery.NamedQuery(IBibleStore.LINE_FIELD_NAME, new ISearchQuery.RangeQuery((int)startLineBox.SelectedValue, null, true, false));
						q = new ISearchQuery.BooleanAndQuery(l, r);
					}

					for (int chapter = startChapter + 1; chapter < endChapter; chapter++)
						q = new ISearchQuery.BooleanOrQuery(q, new ISearchQuery.NamedQuery(IBibleStore.CHAPTER_FIELD_NAME, new ISearchQuery.RangeQuery(chapter, chapter, true, true)));

					{
						ISearchQuery l = new ISearchQuery.NamedQuery(IBibleStore.CHAPTER_FIELD_NAME, new ISearchQuery.RangeQuery(endChapter, endChapter, true, true));
						ISearchQuery r = new ISearchQuery.NamedQuery(IBibleStore.LINE_FIELD_NAME, new ISearchQuery.RangeQuery(null, (int)endLineBox.SelectedValue, false, true));
						q = new ISearchQuery.BooleanOrQuery(q, new ISearchQuery.BooleanAndQuery(l, r));
					}
				}

				BibleType bibleType = (BibleType)bibleTypeBox.SelectedItem;
				bibleSubject = (BibleSubject)subjectBox.SelectedItem;
				using IBibleStore store = BlbleStoreFactory.Create(new System.IO.DirectoryInfo(IBibleStore.STORE_PATH), bibleType, bibleSubject);
				bibleBodies = store.Search(q);
			}

			logger.Information("Bible Search Result : {0}", bibleBodies.Count);
			if (bibleBodies.Count == 0)
				return;
			LinkedList<BibleBody> list = new LinkedList<BibleBody>();
			LinkedListNode<BibleBody> node = null;
			foreach (BibleBody b in bibleBodies)
			{
				if (list.First is null)
					node = list.AddFirst(b);
				else
					node = list.AddAfter(node, b);
			}

			DisplayForm displayForm = serviceProvider.GetRequiredService<DisplayForm>();
			displayForm.CurrentNode = list.First;
			displayForm.Subject = bibleSubject;
			Screen screen = (Screen)displayBox.SelectedItem;
			if (chkFullSize.Checked)
			{
				displayForm.SetDisplaySize(screen);
				displayForm.FormBorderStyle = FormBorderStyle.None;
			}
			else
			{
				int x = screen.Bounds.Width / 4;
				int y = screen.Bounds.Height / 4;
				displayForm.SetDisplaySize(x, y, int.Parse(txtXPixel.Text), int.Parse(txtYPixel.Text));
				displayForm.FormBorderStyle = FormBorderStyle.FixedSingle;
			}
			displayForm.SetFontSize((int)fontSizeBox.Value);
			displayForm.TopMost = true;
			displayForm.ShowDialog();
		}
	}
}
