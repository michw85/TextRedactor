using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TextRedactor
{
    public partial class Form1 : Form
    {
        public string filePath { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void создатьToolStripButton_Click(object sender, EventArgs e)
        {
            
        }

        private void открытьToolStripButton_Click(object sender, EventArgs e)
        {
            using (var f = new OpenFileDialog())
            {
                f.ShowDialog();
                if (f.FileName != null)
                {
                    filePath = f.FileName;
                    StreamReader fp = new StreamReader(f.FileName);
                    richTextBox1.Text = fp.ReadToEnd();
                    fp.Close();
                }
            }
        }

        private void сохранитьToolStripButton_Click(object sender, EventArgs e)
        {
            // Configure save file dialog box
            /*Microsoft.Win32.*/
            SaveFileDialog dlg = new /*Microsoft.Win32.*/SaveFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show save file dialog box
            DialogResult result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == DialogResult.OK)
            {
                // Save document
                string filename = dlg.FileName;
                File.WriteAllText(filename, richTextBox1.Text);
            }
        }

        private void вырезатьToolStripButton_Click(object sender, EventArgs e)
        {
            // Ensure that text is currently selected in the text box.   
            if (richTextBox1.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                richTextBox1.Cut();
        }

        private void копироватьToolStripButton_Click(object sender, EventArgs e)
        {
            // Ensure that text is selected in the text box.   
            if (richTextBox1.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                richTextBox1.Copy();
        }

        private void вставкаToolStripButton_Click(object sender, EventArgs e)
        {
            // Determine if there is any text in the Clipboard to paste into the text box.
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (richTextBox1.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        richTextBox1.SelectionStart = richTextBox1.SelectionStart + richTextBox1.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                richTextBox1.Paste();
            }
        }

        private void выделитьвсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void отменадействияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void отменадействияToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void опрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var a = new AboutBox1();
            a.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void справкаToolStripButton_Click(object sender, EventArgs e)
        {
            
        }
        //public void loadFont()
        //{
        //    System.Drawing.Text.InstalledFontCollection fonts = new System.Drawing.Text.InstalledFontCollection();
        //    foreach (FontFamily font in fonts.Families)
        //    {
        //        toolStripComboBox1.Items.Add(font.Name);
        //    }
        //    toolStripComboBox1.SelectedItem = richTextBox1.Font.Name;

        //    for (int i = 6; i < 48; i = i + 2)
        //    {
        //        toolStripComboBox2.Items.Add(i.ToString());
        //    }
        //    toolStripComboBox2.SelectedItem = Convert.ToInt32(richTextBox1.Font.Size).ToString();
        //}

        //public void doChangeFont()
        //{

        //    if (Convert.ToInt32(toolStripComboBox2.SelectedItem) == 0) return;
        //    if (toolStripComboBox1.SelectedItem.ToString().Length < 1) return;
        //    if (richTextBox1.SelectedText.Length < 1) return;
        //    MessageBox.Show("Change Font: " + toolStripComboBox1.SelectedItem.ToString() + " " + Convert.ToInt32(toolStripComboBox2.SelectedItem));
        //    Font f = new Font(toolStripComboBox1.SelectedItem.ToString(), Convert.ToInt32(toolStripComboBox2.SelectedItem));
        //    richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(), Convert.ToInt32(toolStripComboBox2.SelectedItem));

        //}

        //private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    doChangeFont();
        //}

        //private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    doChangeFont();
        //}

        //private void toolStripComboBox2_TextUpdate(object sender, EventArgs e)
        //{
        //    doChangeFont();
        //}

        //private void toolStripComboBox2_Click(object sender, EventArgs e)
        //{

        //}

        //private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}
    }
}
