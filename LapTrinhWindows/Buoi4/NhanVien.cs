using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LapTrinhWindows.Buoi4
{
    public partial class ListView : Form
    {
        private BindingSource bindingSource = new BindingSource();

        public ListView()
        {
            InitializeComponent();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("MSNV", typeof(string));
            dataTable.Columns.Add("Tên NV", typeof(string));
            dataTable.Columns.Add("Lương CB", typeof(decimal));
            bindingSource.DataSource = dataTable;
            dataGridView1.DataSource = bindingSource;
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataRow row = ((DataRowView)dataGridView1.CurrentRow.DataBoundItem).Row;
                row.Delete();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo");
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NVPopup formNhanVien = new NVPopup();

        
            formNhanVien.UpdateData = (maNV, tenNV, luongCB) =>
            {
                DataTable dataTable = (DataTable)bindingSource.DataSource;
                dataTable.Rows.Add(maNV, tenNV, luongCB);
            };

            formNhanVien.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataRow row = ((DataRowView)dataGridView1.CurrentRow.DataBoundItem).Row;

               
                NVPopup formNhanVien = new NVPopup(
                    row["MSNV"].ToString(),
                    row["Tên NV"].ToString(),
                    Convert.ToDecimal(row["Lương CB"])
                );

                formNhanVien.UpdateData = (maNV, tenNV, luongCB) =>
                {
                    row["MSNV"] = maNV;
                    row["Tên NV"] = tenNV;
                    row["Lương CB"] = luongCB;
                };

                formNhanVien.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!", "Thông báo");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           this.Close();
        }
    }
}
