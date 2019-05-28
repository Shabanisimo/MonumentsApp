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
    public partial class MonumentInfo : MaterialForm
    {
        private int _id;
        public MonumentInfo(int id)
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme =
                new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            _id = id;
        }

        private void MaterialFlatButton3_Click(object sender, EventArgs e)
        {
            UpdateMount form = new UpdateMount(_id);
            form.Show();
        }

        private void MonumentInfo_Load(object sender, EventArgs e)
        {
            Monument monument = DataBaseFunctions.getMonumentInfoById(_id);
            materialLabel2.Text = monument.Name;
            materialLabel3.Text = monument.Country;
            materialLabel5.Text = monument.City;
            materialLabel9.Text = monument.Year;
            materialLabel7.Text = monument.Street;
            richTextBox1.Text = monument.Info;
            string img = monument.Img;
            if (img != null)
            {
                pictureBox1.Image = Image.FromFile(img);
            }
        }

        private void MaterialFlatButton2_Click(object sender, EventArgs e)
        {
            DataBaseFunctions.removeMonument(_id);
            this.Close();
        }

        private void MaterialFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
