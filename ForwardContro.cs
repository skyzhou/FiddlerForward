using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace FiddlerForward
{
    public partial class ForwardContro : UserControl
    {
        //
        private string path = Application.StartupPath + "\\Scripts\\FiddlerForward\\";

        //配置
        //private string[] rules;

        public ArrayList rules = new ArrayList();
        public Dictionary<string,string> setting = new Dictionary<string,string>();
        public string note;

        //combo符号
        public string combo = "/c/=";

        //配置行符号
        private char row = '^';
        private string rowString = "^";

        //配置列符
        private char col = '>';


        //版本
        private string version = "0.0.1";

        //menu
        private Dictionary<string, string[]> menu = new Dictionary<string, string[]>();

        public ForwardContro()
        {
            InitializeComponent();

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            this.fileToRules(); 
            this.fileToSetting();
            this.fileToNote();
            this.fileToMenu("");
        }

        private void ForwardContro_Load(object sender, EventArgs e)
        {

        }
        private void updateData()
        {
            ArrayList list = new ArrayList();
            Boolean adding = false;
            foreach(DataGridViewRow row in dataGridView.Rows){
                //有可能还没初始化
                if ((row.Cells[0].Value is object) && (row.Cells[1].Value is object) && (row.Cells[2].Value is object))
                {
                    string checkVal = (Boolean)row.Cells[0].EditedFormattedValue ? "1" : "0";
                    string match = row.Cells[1].Value.ToString();
                    string action = row.Cells[2].Value.ToString();
                    list.Add(new string[] { checkVal, match, action }); 
                }
                else
                {
                    adding = true;
                }
            }
            if (!adding) {
                this.rules = list;
            }
        }
        internal void resizeWin(int p1, int p2)
        {
            this.Width = p1;
            this.Height = p1+300;

            this.TextNote.Width = this.Width - 20;
            this.TextNote.Height = this.Height - 40;

            //this.tabControl.Width = p1;
            //this.tabControl.Height = p1;
        }
        internal void setDataView()
        {
            foreach (string[] row in this.rules)
            {
                dataGridView.Rows.Add(row);
            }


            this.checkBoxDownLoadSync.Checked = this.setting["DownLoadSync"] == "yes" ? true : false;
            this.checkBoxMenuCopy.Checked = this.setting["MenuCopy"] == "yes" ? true : false;
            this.checkBoxEditorEnable.Checked = this.setting["EditorEnable"] == "yes" ? true : false;

            this.checkBoxDownLoadSync.ForeColor = this.setting["DownLoadSync"] == "yes" ? Color.Black : Color.Gray;
            this.checkBoxMenuCopy.ForeColor = this.setting["MenuCopy"] == "yes" ? Color.Black : Color.Gray;
            this.checkBoxEditorEnable.ForeColor = this.setting["EditorEnable"] == "yes" ? Color.Black : Color.Gray;  

            this.EditorFilePath.Text = this.setting["EditorFilePath"];
            this.TextNote.Text = this.note;

            this.FWversion.Text = this.version;

            this.setMenuDataView(true);
            
        }
        private void setMenuDataView(Boolean init) {
            this.contextMenuStrip.Items.Clear();
            string text = "";
            foreach (KeyValuePair<string, string[]> p in this.menu)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();

                text += p.Value[0] + "\t" + p.Value[1] + "\r\n";

                if (string.IsNullOrEmpty(p.Value[1]) || p.Value[0].IndexOf("#") ==0)
                {
                    continue;
                }
                else
                {
                    item.Text = p.Value[0];
                    item.Tag = p.Value[1];
                    item.Click += this.custom_Click;
                    this.contextMenuStrip.Items.Add(item);
  
                }
                
            }

            //this.menuText.ForeColor = Color.Green;
            this.menuText.BackColor = Color.White;

            if (init) {
                this.menuText.Text = text;
                this.menuText.TextChanged += this.menuText_TextChanged;
                
            }
        }
        public void rulesToFile()
        {
            string data = "";
            foreach (string[] row in this.rules) {
                if (!string.IsNullOrEmpty(row[1].ToString().Trim()) && !string.IsNullOrEmpty(row[2].ToString().Trim()))
                {
                    
                    data += string.Join(this.col.ToString(),row)+this.row;
                }
                
            }

            string rulesFileName = this.path + "rules.ini";
            File.WriteAllText(rulesFileName, data);

        }
        public void settingToFile()
        {
            string data = "";
            foreach (KeyValuePair<string, string> p in this.setting)
            {
                data += p.Key+this.col+p.Value + this.row;
            }

            string settingFileName = this.path + "setting.ini";
            File.WriteAllText(settingFileName, data);

        }
        public void noteToFile()
        {
            string noteFileName = this.path + "note.txt";
            File.WriteAllText(noteFileName, this.TextNote.Text);

        }
        private void fileToRules()
        {
            string rulesFileName = this.path + "rules.ini";

            if (!File.Exists(rulesFileName))
            {
                File.WriteAllText(rulesFileName, "");
            }

            string text = File.ReadAllText(rulesFileName);

            //初始化配置
            string[] rows = text.Split(this.row);

            foreach (string txt in rows)
            {
                string[] row = txt.Split(this.col);
                if(row.Length >2){
                    this.rules.Add(row);
                }
            }
            if (this.rules.Count < 1) {
                string[] empty = { "0", "", "" };
                this.rules.Add(empty);
            }
        }
        private string menuToFile() {
            string data = "";
            string text = this.menuText.Text.Replace("\r\n","\n");

            string[] rows = Regex.Split(text,"\\n+");

            foreach (string row in rows) {
                string[] cells = Regex.Split(row, "\\t+");
                if (cells.Length == 2) {
                    data += string.Join(this.col.ToString(), cells) + this.row;
                }
            }

            string menuFileName = this.path + "menu.ini";
            File.WriteAllText(menuFileName, data);
            return data;
        }
        private void fileToMenu(string menuText)
        {
            this.menu.Clear();
            string text = menuText;
            if (string.IsNullOrEmpty(text))
            {

                string menuFileName = this.path + "menu.ini";

                if (!File.Exists(menuFileName))
                {
                    string[] defaultMenu = {
                                       "打开"+this.col+"open",
                                       "编辑"+this.col+"edit",
                                       "删除"+this.col+"del",
                                       "粘贴"+this.col+"paste",
                                       "新增"+this.col+"add",
                                       "复制"+this.col+"copy",
                                       "#运行"+this.col+"cmd  /k  dir",
                                       "#浏览"+this.col+"chrome {match}"
                                       };
                    File.WriteAllText(menuFileName, string.Join(this.rowString, defaultMenu));
                }
                text = File.ReadAllText(menuFileName);
            }


            //初始化配置
            string[] rows = text.Split(this.row);

            int i = 0;
            foreach (string txt in rows)
            {
                i++;
                if (txt.Trim().Length > 0)
                {
                    string[] row = txt.Split(this.col);
                    if (row.Length > 1)
                    {
                        this.menu.Add("ffmenuItem"+i,row);
                    }
                }
            }

            if (this.menu.Count < 1) {
                string[] empty = {"运行","cmd"};
                this.menu.Add("ffmenuItem0", empty);
            }
        }
        private void fileToSetting() {
            string settingFileName = this.path + "setting.ini";

            if (!File.Exists(settingFileName))
            {
                string[] defaultRows = {
                                       "DownLoadSync"+this.col+"no",
                                       "MenuCopy"+this.col+"yes",
                                       "EditorEnable"+this.col+"no",
                                       "EditorFilePath"+this.col+""
                                       };
                File.WriteAllText(settingFileName, string.Join(this.rowString,defaultRows));
            }

            string text = File.ReadAllText(settingFileName);

            //初始化配置
            string[] rows = text.Split(this.row);

            foreach (string txt in rows)
            {
                if (txt.Trim().Length > 0) {
                    string[] row = txt.Split(this.col);
                    if (row.Length > 1)
                    {
                        this.setting.Add(row[0], row[1]);
                    }
                }
            }
        }
        private void fileToNote()
        {
            string noteFileName = this.path + "note.txt";

            if (!File.Exists(noteFileName))
            {
                File.WriteAllText(noteFileName, "<!--输入记事-->");
            }

            string text = File.ReadAllText(noteFileName);

            this.note = text;
        }
        private void dataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dataGridView.Rows[e.RowIndex].Selected == false)
                    {
                        dataGridView.ClearSelection();
                        dataGridView.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dataGridView.SelectedRows.Count == 1)
                    {
                        dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    contextMenuStrip.Show(MousePosition.X, MousePosition.Y);
                }
            }
            else {
                DataGridViewCell cell = dataGridView.CurrentCell;
                if (cell is DataGridViewCheckBoxCell) {
                    this.updateData();
                }
            }
        }
        private void copyTxtToRow() {
            string message = Convert.ToString(Clipboard.GetDataObject().GetData(DataFormats.Text)).Trim();
            if (!string.IsNullOrEmpty(message))
            {
                string[] data = Regex.Split(message, "\\s+");
                if (data.Length > 1)
                {
                    string[] row = { data[0], data[1] };
                    this.addNewRow(row);
                    
                }
            }
        }
        private string[] copyRowToTxt() {
            DataGridViewRow row = dataGridView.CurrentRow;
            string match = row.Cells[1].Value.ToString().Trim();
            string action = row.Cells[2].Value.ToString().Trim();
            string[] ret = { match, action };
            Clipboard.SetDataObject(match + "\t" + action);
            return ret;
        }
        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.C) {
                    this.copyRowToTxt();
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.V) {
                    this.copyTxtToRow();
                    e.Handled = true;
                }
            }  
        }

        private void custom_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            string hdl = (string)item.Tag;

            DataGridViewRow crow = dataGridView.CurrentRow;

            string match = crow.Cells[1].Value.ToString().Trim();
            string action = crow.Cells[2].Value.ToString().Trim();

            string[] labelTexts = { "Match", "Action" };

            if (string.IsNullOrEmpty(hdl)) {
                return;
            }
            if (hdl == "copy") {
                string[] data = this.copyRowToTxt();
                if (this.setting["MenuCopy"] == "yes")
                {
                    this.addNewRow(data);
                }
            }
            else if (hdl == "edit")
            {
                ForwardWin dialog = new ForwardWin(labelTexts);
                dialog.editRow(crow);
            }
            else if (hdl == "del")
            {
                if (dataGridView.Rows.Count > 1)
                {
                    dataGridView.Rows.Remove(crow);
                }
                else
                {
                    MessageBox.Show("已经是最后一条记录了，请编辑！");
                }
            }
            else if (hdl == "paste")
            {
                this.copyTxtToRow();
            }
            else if (hdl == "add")
            {
                string[] data = { "", "" };
                DataGridViewRow row = this.addNewRow(data);

                ForwardWin dialog = new ForwardWin(labelTexts);
                dialog.addRow(row);
            }
            else if (hdl == "open")
            {
                

                //如果设置了编辑器
                if (this.setting["EditorEnable"] == "yes" && File.Exists(this.setting["EditorFilePath"]))
                {
                    System.Diagnostics.Process.Start(this.setting["EditorFilePath"], action);
                }
                else
                {
                    if (Directory.Exists(action))
                    {
                        Process.Start("explorer.exe", action);
                    }
                    else
                    {
                        Process.Start("notepad.exe", action);
                    }

                }
            }
            else {
                   try   
                   {
                       string[] arr = Regex.Split(hdl, "\\s+");
                       string fileName = arr[0];
                       arr[0] = "";
                       string argv = string.Join("\t", arr).Replace("{match}", match).Replace("{action}", action);
                       
                       Process p = new Process();

                       if (Directory.Exists(action)) {
                           p.StartInfo.WorkingDirectory = action;
                       }

                       p.StartInfo.FileName = fileName;
                       p.StartInfo.Arguments = argv;
                       p.Start();
                   }   
                   catch(Exception   e0)   
                   {   
                        MessageBox.Show("启动应用程序时出错！原因："   +   e0.Message);   
                   }   
            }
        }
       
        private DataGridViewRow addNewRow(string[] data)
        {
            int index = this.dataGridView.Rows.Add();
            this.dataGridView.Rows[index].Cells[0].Value = "1";
            this.dataGridView.Rows[index].Cells[1].Value = data[0];
            this.dataGridView.Rows[index].Cells[2].Value = data[1];

            return this.dataGridView.Rows[index];
        }
        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            this.updateData();
        }

        private void dataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.updateData();
        }

        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.updateData();
        }
        private void checkBoxDownLoad_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox) sender;
            
            this.setting["DownLoadSync"] = box.Checked?"yes":"no";
            box.ForeColor = box.Checked ? Color.Black : Color.Gray;
        }
        private void checkBoxMenu_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            this.setting["MenuCopy"] = box.Checked ? "yes" : "no";
            box.ForeColor = box.Checked ? Color.Black : Color.Gray;
        }
        private void checkBoxEditorEnable_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            this.setting["EditorEnable"] = box.Checked ? "yes" : "no";
            box.ForeColor = box.Checked ? Color.Black : Color.Gray;
            this.EditorFilePath.Enabled = box.Checked;
        }
        private void buttonOpenFileDialog_Click(object sender, EventArgs e)
        {
            //猜用户编辑器路径
            ArrayList maybe = new ArrayList();
            maybe.Add("c:\\Program Files\\Sublime Text 2");
            maybe.Add("d:\\Program Files\\Sublime Text 2");
            maybe.Add("e:\\Program Files\\Sublime Text 2");

            foreach (string path in maybe) {
                if (Directory.Exists(path))
                {
                    this.openFileDialog.InitialDirectory = path;
                    break;
                }
            }

            this.openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {            
            OpenFileDialog dialog = sender as OpenFileDialog;
            if (!dialog.FileName.EndsWith(".exe"))
            {
                MessageBox.Show("无效的文件路径或名称");
                e.Cancel = true;
            }
            else {
                this.EditorFilePath.Text = dialog.FileName;
                this.setting["EditorFilePath"] = dialog.FileName;   
            }
        }

        private void TextNote_TextChanged(object sender, EventArgs e)
        {
            this.noteToFile();
        }
        private void EditorFilePath_TextChanged(object sender, EventArgs e)
        {
            this.setting["EditorFilePath"] = this.EditorFilePath.Text;  
        }

       

        private void UpdateVersion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请RTX联系skyzhou获取最新版本");
        }


        private void dataGridView_DragDrop(object sender, DragEventArgs e)
        {

        }
        private void dataGridView_DragOver(object sender, DragEventArgs e)
        {



        }
        private void dataGridView_DragEnter(object sender, DragEventArgs e)
        {



        }


        private void menuText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.S)
                {
                    string text = this.menuToFile();
                    this.fileToMenu(text);
                    this.setMenuDataView(false);
                    e.Handled = true;
                }
            }  
            
        }

        private void menuText_TextChanged(object sender, EventArgs e)
        {
            this.menuText.BackColor = Color.AliceBlue;
        }
        /**
        [Flags()]

        public enum KeyModifiers
        {

            None = 0,

            Alt = 1,

            Ctrl = 2,

            Shift = 4,

            WindowsKey = 8

        }

        [DllImport("user32.dll", SetLastError = true)]

        public static extern bool RegisterHotKey(

            IntPtr hWnd,                 //要定义热键的窗口的句柄

            int id,                      //定义热键ID（不能与其它ID重复）         

            KeyModifiers fsModifiers,    //标识热键是否在按Alt、Ctrl、Shift、Windows等键时才会生效

            Keys vk                      //定义热键的内容

       );*/
    }
}
