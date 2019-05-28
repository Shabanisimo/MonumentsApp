using MaterialSkin;
using MaterialSkin.Controls;
using MonumentsApp.Functions;
using System;
using System.Windows.Forms;

namespace MonumentsApp
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = 
                new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void MaterialFlatButton1_Click(object sender, EventArgs e)
        {
            string login = materialSingleLineTextField1.Text;
            string password = materialSingleLineTextField2.Text;
            var user = DataBaseFunctions.Auth(login, password);
            if (user != null)
            {
                MainForm form = new MainForm(user);
                form.Show();
                this.Visible = false;
            }
            else
            {
              MessageBox.Show("Неправильный логин или пароль");
            }

        }

        private void MaterialFlatButton2_Click(object sender, EventArgs e)
        {
            Registration form = new Registration();
            form.Show();
            this.Visible = false;
        }
    }
}
