using System.Text;

namespace BibleViewer.Forms
{
	using Entity;

	public partial class DisplayForm : Form
	{
		public DisplayForm()
		{
			InitializeComponent();
		}

		readonly StringBuilder builder = new StringBuilder();
		public LinkedListNode<BibleBody> CurrentNode { get; set; }
		public BibleSubject Subject { get; set; }

		enum PageFlag
		{
			Previous,
			Next
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
					if (CurrentNode.Next is not null && CurrentNode.Next.Next is not null)
					{
						CurrentNode = CurrentNode.Next.Next;
						DisplayChapter();
					}
					break;
				case PageFlag.Previous:
					if (CurrentNode.Previous is not null && CurrentNode.Previous.Previous is not null)
					{
						CurrentNode = CurrentNode.Previous.Previous;
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
			if (CurrentNode is not null)
			{
				AppendChapterLine(builder, CurrentNode.Value);

				if (CurrentNode.Next is not null)
				{
					builder.AppendLine();
					AppendChapterLine(builder, CurrentNode.Next.Value);
				}

				viewLabel.Text = builder.ToString();
				builder.Clear();
			}
		}

		private void AppendChapterLine(StringBuilder builder, BibleBody body)
		{
			builder.AppendLine($"{Subject.Name} {body.Chapter}:{body.Line}");
			builder.AppendLine($"{body.Body}");
		}

		public void SetFontSize(int fontSize)
		{
			try
			{
				viewLabel.Font = new Font(viewLabel.Font.Name, fontSize);
			}
			catch { }
		}
	}
}
