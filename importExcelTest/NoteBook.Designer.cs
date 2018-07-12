namespace negar
{
    partial class NoteBook
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteBook));
            this.notebookGroupBox = new System.Windows.Forms.GroupBox();
            this.NoteBookDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TextExportButton = new System.Windows.Forms.Button();
            this.excelExportButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.فایلToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ذخیرهبهعنوانToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.فایلاکسلToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.فایلمتنیToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.خروجToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ویرایشToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.حذفToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.حذفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notebookGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NoteBookDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notebookGroupBox
            // 
            this.notebookGroupBox.AutoSize = true;
            this.notebookGroupBox.Controls.Add(this.NoteBookDataGridView);
            this.notebookGroupBox.Controls.Add(this.groupBox1);
            this.notebookGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notebookGroupBox.Location = new System.Drawing.Point(0, 24);
            this.notebookGroupBox.Name = "notebookGroupBox";
            this.notebookGroupBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.notebookGroupBox.Size = new System.Drawing.Size(876, 456);
            this.notebookGroupBox.TabIndex = 1;
            this.notebookGroupBox.TabStop = false;
            this.notebookGroupBox.Text = "دفتر";
            // 
            // NoteBookDataGridView
            // 
            this.NoteBookDataGridView.AllowUserToAddRows = false;
            this.NoteBookDataGridView.AllowUserToDeleteRows = false;
            this.NoteBookDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.NoteBookDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.NoteBookDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.NoteBookDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.NoteBookDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NoteBookDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NoteBookDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.NoteBookDataGridView.Location = new System.Drawing.Point(3, 82);
            this.NoteBookDataGridView.Name = "NoteBookDataGridView";
            this.NoteBookDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.NoteBookDataGridView.Size = new System.Drawing.Size(870, 371);
            this.NoteBookDataGridView.TabIndex = 7;
            this.NoteBookDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.NoteBookDataGridView_CellMouseClick_1);
            this.NoteBookDataGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.NoteBookDataGridView_CellMouseDown_1);
            this.NoteBookDataGridView.SelectionChanged += new System.EventHandler(this.NoteBookDataGridView_SelectionChanged_1);
            this.NoteBookDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NoteBookDataGridView_KeyDown_1);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.TextExportButton);
            this.groupBox1.Controls.Add(this.excelExportButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(870, 66);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // TextExportButton
            // 
            this.TextExportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextExportButton.Image = global::negar.Properties.Resources.copy_16;
            this.TextExportButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TextExportButton.Location = new System.Drawing.Point(657, 16);
            this.TextExportButton.Name = "TextExportButton";
            this.TextExportButton.Size = new System.Drawing.Size(101, 31);
            this.TextExportButton.TabIndex = 2;
            this.TextExportButton.Text = "خروجی متنی";
            this.TextExportButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TextExportButton.UseVisualStyleBackColor = true;
            this.TextExportButton.Click += new System.EventHandler(this.TextExportButton_Click);
            // 
            // excelExportButton
            // 
            this.excelExportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.excelExportButton.Image = global::negar.Properties.Resources.excel;
            this.excelExportButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.excelExportButton.Location = new System.Drawing.Point(764, 16);
            this.excelExportButton.Name = "excelExportButton";
            this.excelExportButton.Size = new System.Drawing.Size(103, 31);
            this.excelExportButton.TabIndex = 1;
            this.excelExportButton.Text = "خروجی اکسل";
            this.excelExportButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.excelExportButton.UseVisualStyleBackColor = true;
            this.excelExportButton.Click += new System.EventHandler(this.excelExportButton_Click_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.فایلToolStripMenuItem,
            this.ویرایشToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(876, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // فایلToolStripMenuItem
            // 
            this.فایلToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ذخیرهبهعنوانToolStripMenuItem,
            this.خروجToolStripMenuItem});
            this.فایلToolStripMenuItem.Name = "فایلToolStripMenuItem";
            this.فایلToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.فایلToolStripMenuItem.Text = "فایل";
            this.فایلToolStripMenuItem.Click += new System.EventHandler(this.فایلToolStripMenuItem_Click);
            // 
            // ذخیرهبهعنوانToolStripMenuItem
            // 
            this.ذخیرهبهعنوانToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.فایلاکسلToolStripMenuItem,
            this.فایلمتنیToolStripMenuItem});
            this.ذخیرهبهعنوانToolStripMenuItem.Image = global::negar.Properties.Resources.f3d48a1d;
            this.ذخیرهبهعنوانToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.ذخیرهبهعنوانToolStripMenuItem.Name = "ذخیرهبهعنوانToolStripMenuItem";
            this.ذخیرهبهعنوانToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.ذخیرهبهعنوانToolStripMenuItem.Text = "ذخیره به عنوان";
            // 
            // فایلاکسلToolStripMenuItem
            // 
            this.فایلاکسلToolStripMenuItem.Image = global::negar.Properties.Resources.excel;
            this.فایلاکسلToolStripMenuItem.Name = "فایلاکسلToolStripMenuItem";
            this.فایلاکسلToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.فایلاکسلToolStripMenuItem.Text = "فایل اکسل";
            this.فایلاکسلToolStripMenuItem.Click += new System.EventHandler(this.فایلاکسلToolStripMenuItem_Click);
            // 
            // فایلمتنیToolStripMenuItem
            // 
            this.فایلمتنیToolStripMenuItem.Image = global::negar.Properties.Resources.note;
            this.فایلمتنیToolStripMenuItem.Name = "فایلمتنیToolStripMenuItem";
            this.فایلمتنیToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.فایلمتنیToolStripMenuItem.Text = "فایل متنی";
            this.فایلمتنیToolStripMenuItem.Click += new System.EventHandler(this.فایلمتنیToolStripMenuItem_Click);
            // 
            // خروجToolStripMenuItem
            // 
            this.خروجToolStripMenuItem.Name = "خروجToolStripMenuItem";
            this.خروجToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.خروجToolStripMenuItem.Text = "خروج";
            this.خروجToolStripMenuItem.Click += new System.EventHandler(this.خروجToolStripMenuItem_Click);
            // 
            // ویرایشToolStripMenuItem
            // 
            this.ویرایشToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.حذفToolStripMenuItem1});
            this.ویرایشToolStripMenuItem.Name = "ویرایشToolStripMenuItem";
            this.ویرایشToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ویرایشToolStripMenuItem.Text = "ویرایش";
            // 
            // حذفToolStripMenuItem1
            // 
            this.حذفToolStripMenuItem1.Image = global::negar.Properties.Resources.if_sign_error_299045;
            this.حذفToolStripMenuItem1.Name = "حذفToolStripMenuItem1";
            this.حذفToolStripMenuItem1.Size = new System.Drawing.Size(95, 22);
            this.حذفToolStripMenuItem1.Text = "حذف";
            this.حذفToolStripMenuItem1.Click += new System.EventHandler(this.حذفToolStripMenuItem1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.حذفToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(96, 26);
            // 
            // حذفToolStripMenuItem
            // 
            this.حذفToolStripMenuItem.Image = global::negar.Properties.Resources.if_sign_error_299045;
            this.حذفToolStripMenuItem.Name = "حذفToolStripMenuItem";
            this.حذفToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.حذفToolStripMenuItem.Text = "حذف";
            this.حذفToolStripMenuItem.Click += new System.EventHandler(this.حذفToolStripMenuItem_Click);
            // 
            // NoteBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 480);
            this.Controls.Add(this.notebookGroupBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "NoteBook";
            this.Text = "دفتر";
            this.notebookGroupBox.ResumeLayout(false);
            this.notebookGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NoteBookDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox notebookGroupBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem فایلToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ذخیرهبهعنوانToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem فایلاکسلToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem فایلمتنیToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem خروجToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ویرایشToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem حذفToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem حذفToolStripMenuItem1;
        private System.Windows.Forms.Button excelExportButton;
        private System.Windows.Forms.Button TextExportButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView NoteBookDataGridView;
    }
}