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
    public partial class UpdateMount : MaterialForm
    {
        private int _id;
        public UpdateMount(int id)
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme =
                new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            _id = id;
        }

        private void UpdateMount_Load(object sender, EventArgs e)
        {
            Monument monument = new Monument();
            monument = DataBaseFunctions.getMonumentInfoById(_id);
            materialSingleLineTextField1.Text = monument.Name;
            materialSingleLineTextField3.Text = monument.Country;
            materialSingleLineTextField4.Text = monument.City;
            materialSingleLineTextField5.Text = monument.Year;
            materialSingleLineTextField2.Text = monument.Street;
            richTextBox1.Text = monument.Info;
            string img = monument.Img;
            if (img != null)
            {
               pictureBox1.Image = Image.FromFile(img);
            }
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
            if (openFileDialog1.FileName != null)
            {
                string fileName = openFileDialog1.FileName;
                newMonument.Img = fileName;
            }
            DataBaseFunctions.updateMonument(_id, newMonument);
            this.Close();
        }

        private void MaterialFlatButton3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            openFileDialog1.ShowDialog();
            string fileName = openFileDialog1.FileName;
            pictureBox1.Image = Image.FromFile(fileName);
        }
    }
}
