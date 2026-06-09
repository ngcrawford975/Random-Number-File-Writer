using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Random_Number_File_Writer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (!int.TryParse(AmountTxt.Text, out int amount) || amount <= 0)
                {
                    MessageBox.Show("Please enter a valid positive number.");
                    return;
                }

                // Configure SaveFileDialog
                saveFileDialog1.Title = "Save Random Numbers";
                saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog1.FileName;

                    Random rand = new Random();

                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        for (int i = 0; i < amount; i++)
                        {
                            int number = rand.Next(1, 101); // 1–100
                            writer.WriteLine(number);
                        }
                    }

                    MessageBox.Show("Random numbers saved successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
