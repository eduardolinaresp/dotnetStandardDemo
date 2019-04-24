using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsCampusApp.Services;

namespace WinFormsCampusApp.Forms
{
    public partial class FrmLogin : Form
    {
        private FrmMain gv_FrmMain;
        private AuthService _Auth =  new AuthService();

        public FrmLogin()
        {
            InitializeComponent();
        }

        public FrmLogin(FrmMain i_FrmMain)
        {
            InitializeComponent();
            gv_FrmMain = i_FrmMain;

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // if (!_Auth.Authenticate(txtEmail.Text, txtPassword.Text))
            // {
            //     MessageBox.Show("Error");
            // }
            //;

            this.gv_FrmMain.panelForms.Controls.Clear();


        }
    }
}
