using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FiddlerForward
{
    public partial class ForwardWin : Form
    {
        private DataGridViewRow row;
        private string win;
        public ForwardWin(string[] labelTexts)
        {
            InitializeComponent();
            this.label1.Text = labelTexts[0];
            this.label2.Text = labelTexts[1];
        }
        private void ForwardWin_confirm(object sender, EventArgs e)
        {
            this.row.Cells[1].Value = this.Match.Text.Trim();
            this.row.Cells[2].Value = this.Action.Text.Trim();
            this.Hide();
            
        }
        private void Forward_cancel(object sender, EventArgs e)
        {
            if (this.win == "add") {
                this.row.DataGridView.Rows.Remove(this.row);
            }
            this.Hide();
        }

        internal void editRow(DataGridViewRow r)
        {
            this.row = r;
            this.win = "edit";

            string match = r.Cells[1].Value.ToString();
            string action = r.Cells[2].Value.ToString();

            this.Match.Text = match;
            this.Action.Text = action;

            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Show();
             
        }
        internal void addRow(DataGridViewRow r)
        {
            this.row = r;
            this.win = "add";

            this.Match.Text = "";
            this.Action.Text = "";

            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Show();

        }
    }
}
