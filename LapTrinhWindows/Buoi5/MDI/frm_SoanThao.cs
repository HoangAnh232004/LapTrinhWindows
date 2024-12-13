using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LapTrinhWindows.Buoi5.MDI
{
    public partial class frm_SoanThao : Form
    {
        public frm_SoanThao()
        {
            InitializeComponent();
            newFileItem.Click += NewFile;
            openFileItem.Click += OpenFile;
            saveFileItem.Click += SaveFile;
            exitItem.Click += ExitApplication;
            fontComboBox.SelectedIndexChanged += fontComboBox_SelectedIndexChanged;
            sizeComboBox.SelectedIndexChanged += sizeComboBox_SelectedIndexChanged;
            fontComboBox.SelectedIndexChanged += (s, e) => ChangeFont(fontComboBox.Text);
            sizeComboBox.SelectedIndexChanged += (s, e) => ChangeFontSize(Convert.ToInt32(sizeComboBox.Text));
            boldButton.Click += (s, e) => ToggleBold();
            italicButton.Click += (s, e) => ToggleItalic();
            underlineButton.Click += (s, e) => ToggleUnderline();
        }
        private void fontComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBox.SelectionFont != null)
            {
                Font currentFont = richTextBox.SelectionFont;
                Font newFont = new Font(fontComboBox.Text, currentFont.Size, currentFont.Style);
                richTextBox.SelectionFont = newFont;
            }
        }

        private void sizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBox.SelectionFont != null)
            {
                Font currentFont = richTextBox.SelectionFont;
                float newSize = float.Parse(sizeComboBox.Text);
                Font newFont = new Font(currentFont.FontFamily, newSize, currentFont.Style);
                richTextBox.SelectionFont = newFont;
            }
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            this.Close();
        }
        private void NewFile(object sender, EventArgs e)
        {
            richTextBox.Clear();
        }
        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf|Text Files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FilterIndex == 1)
                {
                    richTextBox.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.RichText);
                }
                else if (openFileDialog.FilterIndex == 2)
                {
                    richTextBox.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void SaveFile(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf|Text Files (*.txt)|*.txt";
            saveFileDialog.DefaultExt = "rtf"; // Đặt mặc định là RTF

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (saveFileDialog.FilterIndex == 1) // Lưu ở định dạng RTF
                    {
                        richTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                    }
                    else if (saveFileDialog.FilterIndex == 2) // Lưu ở định dạng TXT
                    {
                        richTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ChangeFont(string fontName)
        {
            if (richTextBox.SelectionFont != null)
            {
                Font currentFont = richTextBox.SelectionFont;
                Font newFont = new Font(fontName, currentFont.Size, currentFont.Style);
                richTextBox.SelectionFont = newFont;
            }
        }

        private void ChangeFontSize(int fontSize)
        {
            if (richTextBox.SelectionFont != null)
            {
                Font currentFont = richTextBox.SelectionFont;
                Font newFont = new Font(currentFont.FontFamily, fontSize, currentFont.Style);
                richTextBox.SelectionFont = newFont;
            }
        }
       
        private void ToggleBold()
        {
            if (richTextBox.SelectionFont != null)
            {
                Font currentFont = richTextBox.SelectionFont;
                FontStyle newStyle = currentFont.Style ^ FontStyle.Bold;
                richTextBox.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newStyle);
            }
        }

        private void ToggleItalic()
        {
            if (richTextBox.SelectionFont != null)
            {
                Font currentFont = richTextBox.SelectionFont;
                FontStyle newStyle = currentFont.Style ^ FontStyle.Italic;
                richTextBox.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newStyle);
            }
        }

        private void ToggleUnderline()
        {
            if (richTextBox.SelectionFont != null)
            {
                Font currentFont = richTextBox.SelectionFont;
                FontStyle newStyle = currentFont.Style ^ FontStyle.Underline;
                richTextBox.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newStyle);
            }
        }

        private void frm_SoanThao_Load(object sender, EventArgs e)
        {
            fontComboBox.Text = "Time New Roman";
            sizeComboBox.Text = "14";
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                fontComboBox.Items.Add(font.Name);
            }

          
            List<int> listSize = new List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in listSize)
            {
                sizeComboBox.Items.Add(s);
            }
        }
    }
}
