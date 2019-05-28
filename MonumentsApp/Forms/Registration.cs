using MaterialSkin;
using MaterialSkin.Controls;
using MonumentsApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonumentsApp.Functions
{
    public partial class Registration : MaterialForm
    {
        public Registration()
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
            Application.Exit();
        }

        private void MaterialFlatButton1_Click(object sender, EventArgs e)
        {
            string err = null;
            if (materialSingleLineTextField1.TextLength < 4)
                err += "Логин должен состоять минимум из 5 символов" + Environment.NewLine;
            if (materialSingleLineTextField3.TextLength < 6)
                err += "Пароль должен состоять больше, чем из 6 символов" + Environment.NewLine;

                if (err == null)
                {
                    if (!Functions.DataBaseFunctions.UserOnBase(materialSingleLineTextField1.Text))
                    {
                        User user = new User
                        {
                            Login = materialSingleLineTextField1.Text,
                            Password = materialSingleLineTextField3.Text,
                            isAdmin = false
                        };
                        Functions.DataBaseFunctions.Registration(user);
                        MainForm form = new MainForm(user);
                        form.Show();
                        this.Visible = false;
                    }
                    else MessageBox.Show("Данный логин или e-mail занят.");
                }
                else MessageBox.Show(err);
        }
    }
}
