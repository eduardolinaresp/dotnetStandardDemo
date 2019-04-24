using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsCampusApp.Forms.Usuario
{
    public partial class FrmUserCreate : Form
    {
        private FrmMain gv_FrmMain;
        
        public FrmUserCreate()
        {
            InitializeComponent();
        }

        public FrmUserCreate(FrmMain i_FrmMain)
        {
            InitializeComponent();
            gv_FrmMain = i_FrmMain;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            using (ApplicationDBcontext db = new ApplicationDBcontext())
            {
                try
                {
                    user lv_user = db.Users.FirstOrDefault(c => c.email == txtUsuario.Text.Trim());
                    string Encrypted = lv_user.password.Trim();

                    txtPassword.Text = lv_user.password.Trim();

                    txtFechaCreacion.Text = lv_user.created_at.ToString().Trim();
                    txtFechaActualizacion.Text = lv_user.updated_at.ToString().Trim();



                    string Key = "TcTFsNgBWME4f8rq3oisDuWXKUqB2H3nFxjX8Nciywc";

                    // string clave =  Aes256CbcEncrypter.Decrypt(Encrypted, Key);
                    //string clave = Aes256CbcEncrypter.Decryptphp(Encrypted, Key);


                    // MessageBox.Show(clave);

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error", ex.Message);
                }




            }





        }

         private void BtnGrabar_Click(object sender, EventArgs e)
        {

            using (ApplicationDBcontext db = new ApplicationDBcontext())
            {
                try
                {
                    user lv_user = new user();


                    lv_user.name = txtName.Text.Trim();
                    lv_user.email = txtUsuario.Text.Trim();
                    lv_user.password = txtPassword.Text.Trim();
                    lv_user.created_at = DateTime.Now;
                    lv_user.updated_at = DateTime.Now;
                    db.Users.Add(lv_user);
                    db.SaveChanges();

                    MessageBox.Show("ok");

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error", ex.Message);
                }




            }

        }

    }
}
