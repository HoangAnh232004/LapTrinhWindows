using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LapTrinhWindows.Buoi4
{
    public partial class NVPopup : Form
    {
        public delegate void UpdateDataDelegate(string maNV, string tenNV, decimal luongCB);
        public UpdateDataDelegate UpdateData;

        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public decimal LuongCB { get; set; }
        public NVPopup()
        {
            InitializeComponent();
        }
        public NVPopup(string maNV = "", string tenNV = "", decimal luongCB = 0)
        {
            InitializeComponent();

         
            MaNV = maNV;
            TenNV = tenNV;
            LuongCB = luongCB;

            textBox1.Text = MaNV;
            textBox2.Text = TenNV;
            textBox3.Text = LuongCB.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UpdateData != null)
            {
                UpdateData(textBox1.Text, textBox2.Text, decimal.Parse(textBox3.Text));
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
    }

    
    }
}
