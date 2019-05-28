using MaterialSkin;
using MaterialSkin.Controls;
using MonumentsApp.Models;
using MonumentsApp.Functions;
using System;
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
    public partial class MainForm : MaterialForm
    {
        private User _user;
        //private int id;

        public MainForm(User user)
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme =
                new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            _user = user;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            List<Monument> data = DataBaseFunctions.GetAllMonuments();
            dataGridView1.DataSource = data;
        }

        private void MaterialFlatButton3_Click(object sender, EventArgs e)
        {
                CreatePost form = new CreatePost();
            form.Show();
        }

        private void MaterialFlatButton1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
            MonumentInfo form = new MonumentInfo(id);
            form.Show();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
            MonumentInfo form = new MonumentInfo(id);
            form.Show();
        }

        private void MaterialFlatButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MaterialFlatButton4_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            List<Monument> data = DataBaseFunctions.GetAllMonuments();
            dataGridView1.DataSource = data;
        }
    }
}
