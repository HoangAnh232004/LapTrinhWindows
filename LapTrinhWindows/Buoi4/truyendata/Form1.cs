using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LapTrinhWindows.TruyenData
{
    public partial class Form1 : Form
    {
        public  delegate void delData(TextBox t);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            delData d = new delData(frm.setData);
            d(this.textBox1);
            frm.Show(); 
        }
    }
}
