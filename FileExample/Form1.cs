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

namespace FileExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //This Method allows the user to choose a jpg file to display in the Picture Box
            
            //Show the Open File Dialog box to allow the user to select an image
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg";

            
            if (openFileDialog.ShowDialog() == DialogResult.OK) //If the user selects a file display it in the picture box
            {
                //Save the file path the user chose in a variable called selectedFile
                string selectedFile = openFileDialog.FileName;
                lblOutput.Text = selectedFile; //Display the file path in a label

                //Show the file in the picture box
                picImage.Image = Image.FromFile(selectedFile);
                picImage.SizeMode = PictureBoxSizeMode.StretchImage;  //size the image to fit
            }
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            //Adds the string in the textbox to the list box
            lstItems.Items.Add(txtNewItem.Text);
            txtNewItem.Text = string.Empty;
        }

        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files |*.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = saveFileDialog.FileName;
                lblOutput.Text = "Saved to " + selectedFile;

                StreamWriter writer;   //Create a streamwriter named writer
                writer = new StreamWriter(selectedFile);  //Associate writer with the file the user chooses

                for (int i = 0; i < lstItems.Items.Count; i++)  //Write each item in the list to the text file
                {
                    writer.WriteLine(lstItems.Items[i].ToString());
                }
                writer.Close();
            }
        }
    }
}
