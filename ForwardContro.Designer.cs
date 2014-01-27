namespace FiddlerForward
{
    partial class ForwardContro
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Enable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Match = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.UpdateVersion = new System.Windows.Forms.Button();
            this.FWversion = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxEditorEnable = new System.Windows.Forms.CheckBox();
            this.buttonOpenFileDialog = new System.Windows.Forms.Button();
            this.EditorFilePath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxMenuCopy = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxDownLoadSync = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.TextNote = new System.Windows.Forms.RichTextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.menuText = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(893, 826);
            this.tabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.dataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(885, 800);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "规则";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowDrop = true;
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Enable,
            this.Match,
            this.Action});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(3, 3);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(879, 794);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseUp);
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            this.dataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView_RowsAdded);
            this.dataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView_RowsRemoved);
            this.dataGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragDrop);
            this.dataGridView.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragEnter);
            this.dataGridView.DragOver += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragOver);
            this.dataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_KeyDown);
            // 
            // Enable
            // 
            this.Enable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Enable.FalseValue = "0";
            this.Enable.HeaderText = "Enable";
            this.Enable.Name = "Enable";
            this.Enable.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Enable.TrueValue = "1";
            this.Enable.Width = 47;
            // 
            // Match
            // 
            this.Match.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Match.HeaderText = "Match";
            this.Match.Name = "Match";
            this.Match.ReadOnly = true;
            this.Match.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Action
            // 
            this.Action.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            this.Action.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(885, 800);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "设置";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.UpdateVersion);
            this.groupBox4.Controls.Add(this.FWversion);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox4.Location = new System.Drawing.Point(17, 354);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(405, 72);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "版本信息";
            // 
            // UpdateVersion
            // 
            this.UpdateVersion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UpdateVersion.Location = new System.Drawing.Point(323, 24);
            this.UpdateVersion.Name = "UpdateVersion";
            this.UpdateVersion.Size = new System.Drawing.Size(59, 23);
            this.UpdateVersion.TabIndex = 1;
            this.UpdateVersion.Text = "更新";
            this.UpdateVersion.UseVisualStyleBackColor = true;
            this.UpdateVersion.Click += new System.EventHandler(this.UpdateVersion_Click);
            // 
            // FWversion
            // 
            this.FWversion.AutoSize = true;
            this.FWversion.Location = new System.Drawing.Point(19, 35);
            this.FWversion.Name = "FWversion";
            this.FWversion.Size = new System.Drawing.Size(39, 20);
            this.FWversion.TabIndex = 0;
            this.FWversion.Text = "0.0.0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxEditorEnable);
            this.groupBox3.Controls.Add(this.buttonOpenFileDialog);
            this.groupBox3.Controls.Add(this.EditorFilePath);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox3.Location = new System.Drawing.Point(17, 222);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 98);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "编辑器路径";
            // 
            // checkBoxEditorEnable
            // 
            this.checkBoxEditorEnable.AutoSize = true;
            this.checkBoxEditorEnable.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.checkBoxEditorEnable.Location = new System.Drawing.Point(19, 26);
            this.checkBoxEditorEnable.Name = "checkBoxEditorEnable";
            this.checkBoxEditorEnable.Size = new System.Drawing.Size(126, 24);
            this.checkBoxEditorEnable.TabIndex = 3;
            this.checkBoxEditorEnable.Text = "启用本地编辑器";
            this.checkBoxEditorEnable.UseVisualStyleBackColor = true;
            this.checkBoxEditorEnable.CheckedChanged += new System.EventHandler(this.checkBoxEditorEnable_CheckedChanged);
            // 
            // buttonOpenFileDialog
            // 
            this.buttonOpenFileDialog.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonOpenFileDialog.Location = new System.Drawing.Point(323, 53);
            this.buttonOpenFileDialog.Name = "buttonOpenFileDialog";
            this.buttonOpenFileDialog.Size = new System.Drawing.Size(59, 23);
            this.buttonOpenFileDialog.TabIndex = 1;
            this.buttonOpenFileDialog.Text = "浏 览";
            this.buttonOpenFileDialog.UseVisualStyleBackColor = true;
            this.buttonOpenFileDialog.Click += new System.EventHandler(this.buttonOpenFileDialog_Click);
            // 
            // EditorFilePath
            // 
            this.EditorFilePath.Enabled = false;
            this.EditorFilePath.Location = new System.Drawing.Point(19, 54);
            this.EditorFilePath.Name = "EditorFilePath";
            this.EditorFilePath.Size = new System.Drawing.Size(288, 26);
            this.EditorFilePath.TabIndex = 0;
            this.EditorFilePath.TextChanged += new System.EventHandler(this.EditorFilePath_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxMenuCopy);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox2.Location = new System.Drawing.Point(17, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(405, 72);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "右键菜单";
            // 
            // checkBoxMenuCopy
            // 
            this.checkBoxMenuCopy.AutoSize = true;
            this.checkBoxMenuCopy.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.checkBoxMenuCopy.Location = new System.Drawing.Point(19, 29);
            this.checkBoxMenuCopy.Name = "checkBoxMenuCopy";
            this.checkBoxMenuCopy.Size = new System.Drawing.Size(336, 24);
            this.checkBoxMenuCopy.TabIndex = 2;
            this.checkBoxMenuCopy.Text = "复制操作时候复制数据的同时以当前数据添加新行";
            this.checkBoxMenuCopy.UseVisualStyleBackColor = true;
            this.checkBoxMenuCopy.CheckedChanged += new System.EventHandler(this.checkBoxMenu_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxDownLoadSync);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox1.Location = new System.Drawing.Point(17, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 63);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "远程数据同步";
            // 
            // checkBoxDownLoadSync
            // 
            this.checkBoxDownLoadSync.AutoSize = true;
            this.checkBoxDownLoadSync.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.checkBoxDownLoadSync.Location = new System.Drawing.Point(19, 29);
            this.checkBoxDownLoadSync.Name = "checkBoxDownLoadSync";
            this.checkBoxDownLoadSync.Size = new System.Drawing.Size(406, 24);
            this.checkBoxDownLoadSync.TabIndex = 1;
            this.checkBoxDownLoadSync.Text = "当本地文件不存在时同步远程文件到本地（只支持文本文件）";
            this.checkBoxDownLoadSync.UseVisualStyleBackColor = true;
            this.checkBoxDownLoadSync.CheckedChanged += new System.EventHandler(this.checkBoxDownLoad_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.TextNote);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(885, 800);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "记事本";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // TextNote
            // 
            this.TextNote.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextNote.Location = new System.Drawing.Point(6, 6);
            this.TextNote.Name = "TextNote";
            this.TextNote.Size = new System.Drawing.Size(873, 472);
            this.TextNote.TabIndex = 0;
            this.TextNote.Text = "";
            this.TextNote.TextChanged += new System.EventHandler(this.TextNote_TextChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "程序(*exe)|*.exe|所有文件(*.*)|*.*";
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.menuText);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(885, 793);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "功能键";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // menuText
            // 
            this.menuText.AcceptsTab = true;
            this.menuText.BackColor = System.Drawing.SystemColors.Window;
            this.menuText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuText.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuText.ForeColor = System.Drawing.SystemColors.Desktop;
            this.menuText.Location = new System.Drawing.Point(0, 0);
            this.menuText.Multiline = true;
            this.menuText.Name = "menuText";
            this.menuText.Size = new System.Drawing.Size(885, 793);
            this.menuText.TabIndex = 0;
            this.menuText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.menuText_KeyUp);
            // 
            // ForwardContro
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl);
            this.MaximumSize = new System.Drawing.Size(1440, 2000);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "ForwardContro";
            this.Size = new System.Drawing.Size(893, 826);
            this.Load += new System.EventHandler(this.ForwardContro_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Enable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Match;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxMenuCopy;
        private System.Windows.Forms.CheckBox checkBoxDownLoadSync;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonOpenFileDialog;
        private System.Windows.Forms.TextBox EditorFilePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.CheckBox checkBoxEditorEnable;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox TextNote;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button UpdateVersion;
        private System.Windows.Forms.Label FWversion;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox menuText;


    }
}
