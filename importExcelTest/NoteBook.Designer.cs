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
            this.NoteBookDataGridView = new System.Windows.Forms.DataGridView();
            this.notebookGroupBox = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.فایلToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ذخیرهبهعنوانToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.فایلاکسلToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.فایلمتنیToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.خروجToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ویرایشToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.حذفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.حذفToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.NoteBookDataGridView)).BeginInit();
            this.notebookGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NoteBookDataGridView
            // 
            this.NoteBookDataGridView.AllowUserToAddRows = false;
            this.NoteBookDataGridView.AllowUserToDeleteRows = false;
            this.NoteBookDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.NoteBookDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.NoteBookDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NoteBookDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NoteBookDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.NoteBookDataGridView.Location = new System.Drawing.Point(3, 16);
            this.NoteBookDataGridView.Name = "NoteBookDataGridView";
            this.NoteBookDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.NoteBookDataGridView.Size = new System.Drawing.Size(870, 365);
            this.NoteBookDataGridView.TabIndex = 0;
            this.NoteBookDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.NoteBookDataGridView_CellMouseClick);
            this.NoteBookDataGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.NoteBookDataGridView_CellMouseDown);
            this.NoteBookDataGridView.SelectionChanged += new System.EventHandler(this.NoteBookDataGridView_SelectionChanged);
            this.NoteBookDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NoteBookDataGridView_KeyDown);
            // 
            // notebookGroupBox
            // 
            this.notebookGroupBox.Controls.Add(this.NoteBookDataGridView);
            this.notebookGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notebookGroupBox.Location = new System.Drawing.Point(0, 24);
            this.notebookGroupBox.Name = "notebookGroupBox";
            this.notebookGroupBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.notebookGroupBox.Size = new System.Drawing.Size(876, 384);
            this.notebookGroupBox.TabIndex = 1;
            this.notebookGroupBox.TabStop = false;
            this.notebookGroupBox.Text = "دفتر";
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
            this.ذخیرهبهعنوانToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ذخیرهبهعنوانToolStripMenuItem.Text = "ذخیره به عنوان";
            // 
            // فایلاکسلToolStripMenuItem
            // 
            this.فایلاکسلToolStripMenuItem.Image = global::negar.Properties.Resources.excel;
            this.فایلاکسلToolStripMenuItem.Name = "فایلاکسلToolStripMenuItem";
            this.فایلاکسلToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.فایلاکسلToolStripMenuItem.Text = "فایل اکسل";
            this.فایلاکسلToolStripMenuItem.Click += new System.EventHandler(this.فایلاکسلToolStripMenuItem_Click);
            // 
            // فایلمتنیToolStripMenuItem
            // 
            this.فایلمتنیToolStripMenuItem.Image = global::negar.Properties.Resources.note;
            this.فایلمتنیToolStripMenuItem.Name = "فایلمتنیToolStripMenuItem";
            this.فایلمتنیToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.فایلمتنیToolStripMenuItem.Text = "فایل متنی";
            this.فایلمتنیToolStripMenuItem.Click += new System.EventHandler(this.فایلمتنیToolStripMenuItem_Click);
            // 
            // خروجToolStripMenuItem
            // 
            this.خروجToolStripMenuItem.Name = "خروجToolStripMenuItem";
            this.خروجToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
            // حذفToolStripMenuItem1
            // 
            this.حذفToolStripMenuItem1.Image = global::negar.Properties.Resources.if_sign_error_299045;
            this.حذفToolStripMenuItem1.Name = "حذفToolStripMenuItem1";
            this.حذفToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.حذفToolStripMenuItem1.Text = "حذف";
            this.حذفToolStripMenuItem1.Click += new System.EventHandler(this.حذفToolStripMenuItem1_Click);
            // 
            // NoteBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 408);
            this.Controls.Add(this.notebookGroupBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "NoteBook";
            this.Text = "دفتر";
            ((System.ComponentModel.ISupportInitialize)(this.NoteBookDataGridView)).EndInit();
            this.notebookGroupBox.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView NoteBookDataGridView;
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
    }
}