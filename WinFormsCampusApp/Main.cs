using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;
using WinFormsCampusApp.Forms;
using WinFormsCampusApp.Forms.Usuario;

namespace WinFormsCampusApp
{
    public partial class FrmMain : Form
    {
        

        public FrmMain()
        {
            InitializeComponent();
            LoadChilds();

        }

        private void LoadChilds()
        {

            if (System.Windows.Forms.Application.OpenForms["FrmLogin"] as FrmLogin != null)
            {
                FrmLogin myForm = Application.OpenForms["FrmLogin"] as FrmLogin;
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                this.panelForms.Controls.Clear();
                this.panelForms.Controls.Add(myForm);
                myForm.Show();


            }
            else
            {
                FrmLogin myForm = new FrmLogin(this);
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                this.panelForms.Controls.Clear();
                this.panelForms.Controls.Add(myForm);
                myForm.Show();
            }


        }


        private void Button1_Click(object sender, EventArgs e)
        {
            FrmUserIndex _FrmUserIndex = new FrmUserIndex(this);
            _FrmUserIndex.TopLevel = false;
            _FrmUserIndex.AutoScroll = true;
            this.panelForms.Controls.Clear();
            this.panelForms.Controls.Add(_FrmUserIndex);
            _FrmUserIndex.Show();
        }
    }
}
