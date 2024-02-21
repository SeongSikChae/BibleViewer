using BibleViewer.Context;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BibleViewer.Forms
{
    public partial class DisplayForm : Form
  {
    public DisplayForm(BibleContext context)
    {
      InitializeComponent();
      this.context = context;
    }

    readonly BibleContext context;
    readonly StringBuilder builder = new StringBuilder();

    public LinkedListNode<BibleChapter> CurrentChapter { get; set; }

    enum PageFlag
    {
      Previous, Next
    }

    private void DisplayForm_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Escape:
          Hide();
          break;
        case Keys.Up:
        case Keys.Left:
        case Keys.PageUp:
          ChangeView(PageFlag.Previous);
          break;
        case Keys.Down:
        case Keys.Right:
        case Keys.PageDown:
          ChangeView(PageFlag.Next);
          break;
      }
    }

    private void ChangeView(PageFlag flag)
    {
      switch (flag)
      {
        case PageFlag.Next:
          if (!(CurrentChapter.Next is null) && !(CurrentChapter.Next.Next is null))
          {
            CurrentChapter = CurrentChapter.Next.Next;
            DisplayChapter();
          }
          break;
        case PageFlag.Previous:
          if (!(CurrentChapter.Previous is null) && !(CurrentChapter.Previous.Previous is null))
          {
            CurrentChapter = CurrentChapter.Previous.Previous;
            DisplayChapter();
          }
          break;
      }
    }

    public void SetDisplaySize(Screen screen)
    {
      builder.Clear();

      Left = screen.Bounds.X;
      Top = screen.Bounds.Y;
      StartPosition = FormStartPosition.Manual;
      Location = screen.Bounds.Location;
      Width = screen.Bounds.Size.Width;
      Height = screen.Bounds.Size.Height;

      DisplayChapter();
    }
    public void SetDisplaySize(int x, int y, int width, int height)
    {
        builder.Clear();

        Left = x;
        Top = y;
        StartPosition = FormStartPosition.Manual;
        Location = new Point(x, y);
        Width = width;
        Height = height;

        DisplayChapter();
    }

        private void DisplayChapter()
    {
      if (!(CurrentChapter is null))
      {
        AppendChapterLine(builder, CurrentChapter.Value);

        if (!(CurrentChapter.Next is null))
        {
          builder.AppendLine();
          AppendChapterLine(builder, CurrentChapter.Next.Value);
        }

        viewLabel.Text = builder.ToString();
        builder.Clear();
      }
    }

    private void AppendChapterLine(StringBuilder builder, BibleChapter chapter)
    {
      BibleSubject subject = context.BibleSubject.Where(item => item.BibleSubjectKey == chapter.BibleSubject).Single();
      builder.AppendLine($"{subject.BibleSubjectDescription} {chapter.ChapterNumber}:{chapter.LineNumber}");
      builder.AppendLine($"{chapter.Body}");
    }

    public void SetFontSize(int fontSize)
    {
      try
      {
        viewLabel.Font = new System.Drawing.Font(viewLabel.Font.Name, fontSize);
      }
      catch { }
    }
  }
}
