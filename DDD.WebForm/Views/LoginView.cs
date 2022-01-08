using DDD.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDD.WebForm.Views
{
    public partial class LoginView : BaseForm
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            Shared.LoginId = LoginTextBox.Text;

            using (var f = new LatestView())
            {
                f.ShowDialog();
            }
        }
    }
}
