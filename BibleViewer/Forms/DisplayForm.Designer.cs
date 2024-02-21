
namespace BibleViewer.Forms
{
  partial class DisplayForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.viewLabel = new System.Windows.Forms.Label();
      this.panel4 = new System.Windows.Forms.Panel();
      this.panel3 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.SuspendLayout();
      // 
      // viewLabel
      // 
      this.viewLabel.AutoEllipsis = true;
      this.viewLabel.BackColor = System.Drawing.Color.Black;
      this.viewLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.viewLabel.ForeColor = System.Drawing.Color.White;
      this.viewLabel.Location = new System.Drawing.Point(24, 34);
      this.viewLabel.Name = "viewLabel";
      this.viewLabel.Size = new System.Drawing.Size(239, 258);
      this.viewLabel.TabIndex = 9;
      // 
      // panel4
      // 
      this.panel4.BackColor = System.Drawing.Color.Black;
      this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel4.Location = new System.Drawing.Point(24, 292);
      this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(239, 34);
      this.panel4.TabIndex = 8;
      // 
      // panel3
      // 
      this.panel3.BackColor = System.Drawing.Color.Black;
      this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
      this.panel3.Location = new System.Drawing.Point(263, 34);
      this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(21, 292);
      this.panel3.TabIndex = 7;
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.Color.Black;
      this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel2.Location = new System.Drawing.Point(0, 34);
      this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(24, 292);
      this.panel2.TabIndex = 6;
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.Black;
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(284, 34);
      this.panel1.TabIndex = 5;
      // 
      // DisplayForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(284, 326);
      this.Controls.Add(this.viewLabel);
      this.Controls.Add(this.panel4);
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "DisplayForm";
      this.Text = "DisplayForm";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DisplayForm_KeyDown);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label viewLabel;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Panel panel1;
  }
}