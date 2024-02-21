using BibleViewer.Context;
using BibleViewer.Query;
using BibleViewer.Store;
using LevelDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibleViewer.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DbContextOptionsBuilder<BibleContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<BibleContext>().UseSqlite("Data Source=Bible.sqlite");
            long start = DateTime.Now.ToMilliseconds();
            context = new BibleContext(dbContextOptionsBuilder.Options);
            long end = DateTime.Now.ToMilliseconds();
            Console.WriteLine($"Context Initialized. {TimeSpan.FromMilliseconds(end - start)}");
            displayForm = new DisplayForm(context);
            Task.Run(async () =>
            {
                await Initialize();
            });
        }

        readonly BibleContext context;
        readonly DisplayForm displayForm;
        private readonly DirectoryInfo storeDir = new DirectoryInfo("store");
        private IIndexStore chapterStore;
        private IIndexStore bibleStore;
        private LevelDB.DB levelDb;

        private async Task Initialize()
        {
            long start = DateTime.Now.ToMilliseconds();
            await context.Database.MigrateAsync();
            InitializeStore();
            long end = DateTime.Now.ToMilliseconds();
            Console.WriteLine($"Migrated. {TimeSpan.FromMilliseconds(end - start)}");

            start = DateTime.Now.ToMilliseconds();
            bibleTypeBox.Invoke(() =>
            {
                bibleTypeBox.DataSource = context.BibleType.ToList();
            });
            end = DateTime.Now.ToMilliseconds();
            Console.WriteLine($"BibleType Initialized. {TimeSpan.FromMilliseconds(end - start)}");

            start = DateTime.Now.ToMilliseconds();
            subjectBox.Invoke(() =>
            {
                subjectBox.DataSource = context.BibleSubject.OrderBy(item => item.BibleSubjectKey).ToList();
            });
            end = DateTime.Now.ToMilliseconds();
            Console.WriteLine($"Subject Initialized. {TimeSpan.FromMilliseconds(end - start)}");

            start = DateTime.Now.ToMilliseconds();
            displayBox.Invoke(() =>
            {
                displayBox.DataSource = Screen.AllScreens.ToList();
            });
            end = DateTime.Now.ToMilliseconds();
            Console.WriteLine($"Display Initialized. {TimeSpan.FromMilliseconds(end - start)}");
        }

        private void InitializeStore()
        {
            StoreMigration migration = new StoreMigration();
            migration.Initialize(context);
            Action<StoreMigrationData> act = (d) => { };

            {
                DirectoryInfo rawStoreDir = storeDir.CreateSubdirectory("raw");
                levelDb = new LevelDB.DB(new LevelDB.Options
                {
                    CreateIfMissing = true
                }, rawStoreDir.FullName);
            }

            {
                DirectoryInfo chapterStoreDir = storeDir.CreateSubdirectory("chapter");
                IndexStoreBuilder builder = new IndexStoreBuilder();
                chapterStore = builder.SetReadOnly(chapterStoreDir.Exists && chapterStoreDir.EnumerateFiles().Count() > 0).Build(chapterStoreDir);
                if (!chapterStore.ReadOnly)
                {
                    ChapterStoreMigrator migrator = new ChapterStoreMigrator();
                    migrator.Initialize(chapterStore);
                    act += migrator.Migrate;
                }
            }

            {
                DirectoryInfo bibleStoreDir = storeDir.CreateSubdirectory("bible");
                IndexStoreBuilder builder = new IndexStoreBuilder();
                bibleStore = builder.SetReadOnly(bibleStoreDir.Exists && bibleStoreDir.EnumerateFiles().Count() > 0).Build(bibleStoreDir);
                if (!bibleStore.ReadOnly)
                {
                    BibleStoreMigrator migrator = new BibleStoreMigrator();
                    migrator.Initialize(bibleStore, levelDb);
                    act += migrator.Migrate;
                }
            }

            migration.Migration(act);
            if (!chapterStore.ReadOnly)
            {
                chapterStore.Commit();
                chapterStore.ForceMerge(1);
            }
            if (!bibleStore.ReadOnly)
            {
                bibleStore.Commit();
                bibleStore.ForceMerge(1);
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            long start = DateTime.Now.ToMilliseconds();
            switch ((sender as ComboBox).Tag as string)
            {
                case "1":
                    {
                        List<int> list = new List<int>();
                        int subjectKey = (int)(sender as ComboBox).SelectedValue;
                        chapterStore.Search(new NamedSearchQuery("BibleSubjectKey", new TermSearchQuery($"{subjectKey}")), (doc) =>
                        {
                            int? chapterNumber = doc.GetField("ChapterNumber").GetInt32Value();
                            if (chapterNumber.HasValue)
                                list.Add(chapterNumber.Value);
                        });
                        startChapterBox.DataSource = list;
                    }
                    break;
                case "2":
                    {
                        List<int> lineList = new List<int>();
                        List<AndSearchQuery.AndSearchItem> list = new List<AndSearchQuery.AndSearchItem>();
                        list.Add(new AndSearchQuery.AndSearchItem(false, new NamedSearchQuery("BibleSubjectKey", new TermSearchQuery(subjectBox.SelectedValue.ToString()))));
                        list.Add(new AndSearchQuery.AndSearchItem(false, new NamedSearchQuery("ChapterNumber", new TermSearchQuery(startChapterBox.SelectedValue.ToString()))));
                        AndSearchQuery q = new AndSearchQuery(new NamedSearchQuery("BibleTypeKey", new TermSearchQuery(bibleTypeBox.SelectedValue.ToString())), list);
                        bibleStore.Search(q, (doc) =>
                        {
                            int? lineNumber = doc.GetField("LineNumber").GetInt32Value();
                            if (lineNumber.HasValue)
                                lineList.Add(lineNumber.Value);
                        });
                        startLineBox.DataSource = lineList;
                    }
                    endChapterBox.DataSource = (startChapterBox.DataSource as IEnumerable<int>).Where(item => item >= (int)(sender as ComboBox).SelectedValue).ToList();
                    break;
                case "3":
                case "4":
                    if (endChapterBox.SelectedValue != null && (int)startChapterBox.SelectedValue == (int)endChapterBox.SelectedValue)
                    {
                        endLineBox.DataSource = (startLineBox.DataSource as IEnumerable<int>).Where(item => item >= (int)startLineBox.SelectedValue).ToList();
                    }
                    else if (endChapterBox.SelectedValue != null)
                    {
                        List<int> lineList = new List<int>();
                        List<AndSearchQuery.AndSearchItem> list = new List<AndSearchQuery.AndSearchItem>();
                        list.Add(new AndSearchQuery.AndSearchItem(false, new NamedSearchQuery("BibleSubjectKey", new TermSearchQuery(subjectBox.SelectedValue.ToString()))));
                        list.Add(new AndSearchQuery.AndSearchItem(false, new NamedSearchQuery("ChapterNumber", new TermSearchQuery(endChapterBox.SelectedValue.ToString()))));
                        AndSearchQuery q = new AndSearchQuery(new NamedSearchQuery("BibleTypeKey", new TermSearchQuery(bibleTypeBox.SelectedValue.ToString())), list);
                        bibleStore.Search(q, (doc) =>
                        {
                            int? lineNumber = doc.GetField("LineNumber").GetInt32Value();
                            if (lineNumber.HasValue)
                                lineList.Add(lineNumber.Value);
                        });
                        endLineBox.DataSource = lineList;
                    }
                    break;
            }
            long end = DateTime.Now.ToMilliseconds();
            Console.WriteLine($"ComboBox: {sender} SelectedIndexChanged. {TimeSpan.FromMilliseconds(end - start)}");
        }


        private void Button_Click(object sender, System.EventArgs e)
        {
            if (displayForm.CurrentChapter != null)
            {
                displayForm.CurrentChapter = null;
            }

            LinkedList<BibleChapter> chapters = new LinkedList<BibleChapter>();
            LinkedListNode<BibleChapter> chapterNode = null;
            List<BibleChapter> list = new List<BibleChapter>();

            if (chkSearchMode.Checked)
            {
                SearchQueryParser parser = new SearchQueryParser();
                AndSearchQuery q = AndSearchQuery.And(new NamedSearchQuery("BibleTypeKey", new TermSearchQuery(bibleTypeBox.SelectedValue.ToString())), parser.Parse(txtSearchBox.Text));
                bibleStore.Search(q, (doc) =>
                {
                    string id = doc.GetField(IIndexStore.ID_FIELD_NAME).GetStringValue();
                    string body = levelDb.Get(id);
                    BibleChapter chapter = new BibleChapter();
                    chapter.BibleType = doc.GetField("BibleTypeKey").GetInt32Value().Value;
                    chapter.BibleSubject = doc.GetField("BibleSubjectKey").GetInt32Value().Value;
                    chapter.ChapterNumber = doc.GetField("ChapterNumber").GetInt32Value().Value;
                    chapter.LineNumber = doc.GetField("LineNumber").GetInt32Value().Value;
                    chapter.Body = body;
                    list.Add(chapter);
                });
            }
            else
            {
                AndSearchQuery q = AndSearchQuery.And(new NamedSearchQuery("BibleTypeKey", new TermSearchQuery(bibleTypeBox.SelectedValue.ToString())), new NamedSearchQuery("BibleSubjectKey", new TermSearchQuery(subjectBox.SelectedValue.ToString())));
                if (startChapterBox.SelectedValue.Equals(endChapterBox.SelectedValue))
                {
                    q = AndSearchQuery.And(q, new NamedSearchQuery("ChapterNumber", new TermSearchQuery(startChapterBox.SelectedValue.ToString())));
                    q = AndSearchQuery.And(q, new NamedSearchQuery("LineNumber", new RangeSearchQuery(startLineBox.SelectedValue.ToString(), endLineBox.SelectedValue.ToString(), true, true)));
                }
                else
                {
                    AndSearchQuery l = AndSearchQuery.And(new NamedSearchQuery("ChapterNumber", new TermSearchQuery(startChapterBox.SelectedValue.ToString())), new NamedSearchQuery("LineNumber", new RangeSearchQuery(startLineBox.SelectedValue.ToString(), int.MaxValue.ToString(), true, true)));
                    AndSearchQuery r = AndSearchQuery.And(new NamedSearchQuery("ChapterNumber", new TermSearchQuery(endChapterBox.SelectedValue.ToString())), new NamedSearchQuery("LineNumber", new RangeSearchQuery(0.ToString(), endLineBox.SelectedValue.ToString(), true, true)));
                    q = AndSearchQuery.And(q, OrSearchQuery.Or(l, r));
                }
                bibleStore.Search(q, (doc) =>
                {
                    string id = doc.GetField(IIndexStore.ID_FIELD_NAME).GetStringValue();
                    string body = levelDb.Get(id);
                    BibleChapter chapter = new BibleChapter();
                    chapter.BibleType = doc.GetField("BibleTypeKey").GetInt32Value().Value;
                    chapter.BibleSubject = doc.GetField("BibleSubjectKey").GetInt32Value().Value;
                    chapter.ChapterNumber = doc.GetField("ChapterNumber").GetInt32Value().Value;
                    chapter.LineNumber = doc.GetField("LineNumber").GetInt32Value().Value;
                    chapter.Body = body;
                    list.Add(chapter);
                });
            }

            list.Sort((l, r) =>
            {
                int v = l.BibleSubject - r.BibleSubject;
                if (v != 0)
                    return v;
                v = l.ChapterNumber - r.ChapterNumber;
                if (v != 0)
                    return v;
                return l.LineNumber - r.LineNumber;
            });
            foreach (BibleChapter chapter in list)
            {
                if (chapters.First is null)
                    chapterNode = chapters.AddFirst(chapter);
                else
                    chapterNode = chapters.AddAfter(chapterNode, chapter);
            }

            displayForm.CurrentChapter = chapters.First;
            if (chkFullSize.Checked)
            {
                displayForm.SetDisplaySize(displayBox.SelectedItem as Screen);
                displayForm.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                int x = ((displayBox.SelectedItem as Screen).Bounds.Width / 4);
                int y = ((displayBox.SelectedItem as Screen).Bounds.Height / 4);
                displayForm.SetDisplaySize(x, y, int.Parse(txtXPixel.Text), int.Parse(txtYPixel.Text));
                displayForm.FormBorderStyle = FormBorderStyle.FixedSingle;

            }
            displayForm.SetFontSize((int)fontSizeBox.Value);
            displayForm.TopMost = true;
            displayForm.Show();
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            switch ((sender as CheckBox).Tag)
            {
                case "0":
                    if ((sender as CheckBox).Checked)
                    {
                        txtXPixel.Enabled = false;
                        txtYPixel.Enabled = false;
                    }
                    else
                    {
                        txtXPixel.Enabled = true;
                        txtYPixel.Enabled = true;
                        txtXPixel.Text = (displayBox.SelectedItem as Screen).Bounds.Width.ToString();
                        txtYPixel.Text = (displayBox.SelectedItem as Screen).Bounds.Height.ToString();
                    }
                    break;
                case "1":
                    if ((sender as CheckBox).Checked)
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
                    break;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (levelDb is not null)
                levelDb.Close();

            if (chapterStore is not null)
                chapterStore.Close();

            if (bibleStore is not null)
                bibleStore.Close();

            context.Dispose();
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"BibleViewer: {RevisionUtil.GetRevisoin<BibleViewer.RevisionAttribute>()}", "버전");
        }
    }
}
