using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LapTrinhWindows.Buoi5.MDI
{
    public partial class Form2 : Form
    {
        public Form2(string imgFile)
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(imgFile);
            Text = imgFile.Substring(imgFile.LastIndexOf('\\') + 1);
        }
        public Form2()
        {
            InitializeComponent();
        }
    }
}
