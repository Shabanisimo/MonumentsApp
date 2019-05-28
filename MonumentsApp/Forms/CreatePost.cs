using MaterialSkin;
using MaterialSkin.Controls;
using System;
using MonumentsApp.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonumentsApp.Functions
{
    public partial class CreatePost : MaterialForm
    {
        public CreatePost()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme =
                new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void MaterialFlatButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MaterialFlatButton1_Click(object sender, EventArgs e)
        {
            Monument newMonument = new Monument();
            newMonument.Name = materialSingleLineTextField1.Text;
            newMonument.Country = materialSingleLineTextField3.Text;
            newMonument.City = materialSingleLineTextField4.Text;
            newMonument.Year = materialSingleLineTextField5.Text;
            newMonument.Street = materialSingleLineTextField2.Text;
            newMonument.Info = richTextBox1.Text;
            newMonument.Img = openFileDialog1.FileName;
            DataBaseFunctions.createMonument(newMonument);
            this.Close();
        }

        private void MaterialFlatButton3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            openFileDialog1.ShowDialog();
            string fileName = openFileDialog1.FileName;
            pictureBox1.Image = Image.FromFile(fileName);
        }

        private void CreatePost_Load(object sender, EventArgs e)
        {

        }
    }
}
