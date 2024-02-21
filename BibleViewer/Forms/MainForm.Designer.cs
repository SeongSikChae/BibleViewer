
namespace BibleViewer.Forms
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            endChapterBox = new System.Windows.Forms.ComboBox();
            startChapterBox = new System.Windows.Forms.ComboBox();
            label7 = new System.Windows.Forms.Label();
            endLineBox = new System.Windows.Forms.ComboBox();
            label8 = new System.Windows.Forms.Label();
            showButton = new System.Windows.Forms.Button();
            label6 = new System.Windows.Forms.Label();
            fontSizeBox = new System.Windows.Forms.NumericUpDown();
            label5 = new System.Windows.Forms.Label();
            displayBox = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            startLineBox = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            subjectBox = new System.Windows.Forms.ComboBox();
            bibleTypeBox = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            chkFullSize = new System.Windows.Forms.CheckBox();
            label9 = new System.Windows.Forms.Label();
            txtXPixel = new System.Windows.Forms.TextBox();
            txtYPixel = new System.Windows.Forms.TextBox();
            chkSearchMode = new System.Windows.Forms.CheckBox();
            txtSearchBox = new System.Windows.Forms.TextBox();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)fontSizeBox).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // endChapterBox
            // 
            endChapterBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            endChapterBox.FormattingEnabled = true;
            endChapterBox.Location = new System.Drawing.Point(59, 159);
            endChapterBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            endChapterBox.Name = "endChapterBox";
            endChapterBox.Size = new System.Drawing.Size(53, 23);
            endChapterBox.TabIndex = 26;
            endChapterBox.Tag = "4";
            endChapterBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            // 
            // startChapterBox
            // 
            startChapterBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            startChapterBox.FormattingEnabled = true;
            startChapterBox.Location = new System.Drawing.Point(59, 127);
            startChapterBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            startChapterBox.Name = "startChapterBox";
            startChapterBox.Size = new System.Drawing.Size(53, 23);
            startChapterBox.TabIndex = 22;
            startChapterBox.Tag = "2";
            startChapterBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(118, 163);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(30, 15);
            label7.TabIndex = 27;
            label7.Text = "절 : ";
            // 
            // endLineBox
            // 
            endLineBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            endLineBox.FormattingEnabled = true;
            endLineBox.Location = new System.Drawing.Point(153, 159);
            endLineBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            endLineBox.Name = "endLineBox";
            endLineBox.Size = new System.Drawing.Size(53, 23);
            endLineBox.TabIndex = 28;
            endLineBox.Tag = "5";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(24, 163);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(30, 15);
            label8.TabIndex = 25;
            label8.Text = "장 : ";
            // 
            // showButton
            // 
            showButton.Location = new System.Drawing.Point(9, 325);
            showButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            showButton.Name = "showButton";
            showButton.Size = new System.Drawing.Size(194, 36);
            showButton.TabIndex = 33;
            showButton.Text = "화면에 표시";
            showButton.UseVisualStyleBackColor = true;
            showButton.Click += Button_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(7, 294);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(78, 15);
            label6.TabIndex = 31;
            label6.Text = "폰트사이즈 : ";
            // 
            // fontSizeBox
            // 
            fontSizeBox.Location = new System.Drawing.Point(90, 292);
            fontSizeBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            fontSizeBox.Name = "fontSizeBox";
            fontSizeBox.Size = new System.Drawing.Size(113, 23);
            fontSizeBox.TabIndex = 32;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(34, 196);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(54, 15);
            label5.TabIndex = 29;
            label5.Text = "모니터 : ";
            // 
            // displayBox
            // 
            displayBox.DisplayMember = "DeviceName";
            displayBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            displayBox.FormattingEnabled = true;
            displayBox.Location = new System.Drawing.Point(93, 192);
            displayBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            displayBox.Name = "displayBox";
            displayBox.Size = new System.Drawing.Size(113, 23);
            displayBox.TabIndex = 30;
            displayBox.ValueMember = "DeviceName";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(118, 131);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(30, 15);
            label4.TabIndex = 23;
            label4.Text = "절 : ";
            // 
            // startLineBox
            // 
            startLineBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            startLineBox.FormattingEnabled = true;
            startLineBox.Location = new System.Drawing.Point(153, 127);
            startLineBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            startLineBox.Name = "startLineBox";
            startLineBox.Size = new System.Drawing.Size(53, 23);
            startLineBox.TabIndex = 24;
            startLineBox.Tag = "3";
            startLineBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(24, 131);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(30, 15);
            label3.TabIndex = 21;
            label3.Text = "장 : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(22, 98);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(66, 15);
            label2.TabIndex = 20;
            label2.Text = "성경주제 : ";
            // 
            // subjectBox
            // 
            subjectBox.DisplayMember = "BibleSubjectDescription";
            subjectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            subjectBox.FormattingEnabled = true;
            subjectBox.Location = new System.Drawing.Point(93, 95);
            subjectBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            subjectBox.Name = "subjectBox";
            subjectBox.Size = new System.Drawing.Size(113, 23);
            subjectBox.TabIndex = 19;
            subjectBox.Tag = "1";
            subjectBox.ValueMember = "BibleSubjectKey";
            subjectBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            // 
            // bibleTypeBox
            // 
            bibleTypeBox.DisplayMember = "BibleTypeName";
            bibleTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            bibleTypeBox.FormattingEnabled = true;
            bibleTypeBox.Location = new System.Drawing.Point(93, 12);
            bibleTypeBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            bibleTypeBox.Name = "bibleTypeBox";
            bibleTypeBox.Size = new System.Drawing.Size(113, 23);
            bibleTypeBox.TabIndex = 18;
            bibleTypeBox.Tag = "0";
            bibleTypeBox.ValueMember = "BibleTypeKey";
            bibleTypeBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(22, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(66, 15);
            label1.TabIndex = 17;
            label1.Text = "성경종류 : ";
            // 
            // chkFullSize
            // 
            chkFullSize.AutoSize = true;
            chkFullSize.Checked = true;
            chkFullSize.CheckState = System.Windows.Forms.CheckState.Checked;
            chkFullSize.Location = new System.Drawing.Point(12, 222);
            chkFullSize.Name = "chkFullSize";
            chkFullSize.Size = new System.Drawing.Size(74, 19);
            chkFullSize.TabIndex = 34;
            chkFullSize.Tag = "0";
            chkFullSize.Text = "전체화면";
            chkFullSize.UseVisualStyleBackColor = true;
            chkFullSize.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(9, 244);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(43, 15);
            label9.TabIndex = 35;
            label9.Text = "해상도";
            // 
            // txtXPixel
            // 
            txtXPixel.Enabled = false;
            txtXPixel.Location = new System.Drawing.Point(12, 262);
            txtXPixel.Name = "txtXPixel";
            txtXPixel.Size = new System.Drawing.Size(89, 23);
            txtXPixel.TabIndex = 36;
            // 
            // txtYPixel
            // 
            txtYPixel.Enabled = false;
            txtYPixel.Location = new System.Drawing.Point(107, 262);
            txtYPixel.Name = "txtYPixel";
            txtYPixel.Size = new System.Drawing.Size(99, 23);
            txtYPixel.TabIndex = 37;
            // 
            // chkSearchMode
            // 
            chkSearchMode.AutoSize = true;
            chkSearchMode.Location = new System.Drawing.Point(24, 42);
            chkSearchMode.Name = "chkSearchMode";
            chkSearchMode.Size = new System.Drawing.Size(74, 19);
            chkSearchMode.TabIndex = 38;
            chkSearchMode.Tag = "1";
            chkSearchMode.Text = "검색모드";
            chkSearchMode.UseVisualStyleBackColor = true;
            chkSearchMode.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // txtSearchBox
            // 
            txtSearchBox.Enabled = false;
            txtSearchBox.Location = new System.Drawing.Point(22, 65);
            txtSearchBox.Name = "txtSearchBox";
            txtSearchBox.Size = new System.Drawing.Size(181, 23);
            txtSearchBox.TabIndex = 39;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItem1 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            toolStripMenuItem1.Text = "버전";
            toolStripMenuItem1.Click += ToolStripMenuItem1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(217, 370);
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(txtSearchBox);
            Controls.Add(chkSearchMode);
            Controls.Add(txtYPixel);
            Controls.Add(txtXPixel);
            Controls.Add(label9);
            Controls.Add(chkFullSize);
            Controls.Add(endChapterBox);
            Controls.Add(startChapterBox);
            Controls.Add(label7);
            Controls.Add(endLineBox);
            Controls.Add(label8);
            Controls.Add(showButton);
            Controls.Add(label6);
            Controls.Add(fontSizeBox);
            Controls.Add(label5);
            Controls.Add(displayBox);
            Controls.Add(label4);
            Controls.Add(startLineBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(subjectBox);
            Controls.Add(bibleTypeBox);
            Controls.Add(label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "성경뷰어";
            FormClosing += MainForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)fontSizeBox).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox endChapterBox;
        private System.Windows.Forms.ComboBox startChapterBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox endLineBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown fontSizeBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox displayBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox startLineBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox subjectBox;
        private System.Windows.Forms.ComboBox bibleTypeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkFullSize;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtXPixel;
        private System.Windows.Forms.TextBox txtYPixel;
        private System.Windows.Forms.CheckBox chkSearchMode;
        private System.Windows.Forms.TextBox txtSearchBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}