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
using WinFormsCampusApp.Services.Implementation;

namespace WinFormsCampusApp.Forms.Usuario
{
    public partial class FrmUserIndex : Form
    {
        private FrmMain gv_FrmMain;
        private UsuarioService  _service = new UsuarioService();
        public FrmUserIndex()
        {
            InitializeComponent();
          
        }

        public FrmUserIndex(FrmMain i_FrmMain)
        {
            InitializeComponent();
            gv_FrmMain = i_FrmMain;
            CargarGrid();
        }

        

        private void CargarGrid()
        {

            dataGridView1.DataSource = _service.Get()
                                               .Select(C => new { Id = C.id, Nombre = C.name, mail = C.email })
                                               .ToList();
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            FrmUserCreate _Frm = new FrmUserCreate(this.gv_FrmMain);
            _Frm.TopLevel = false;
            _Frm.AutoScroll = true;
            this.gv_FrmMain.panelForms.Controls.Clear();
            this.gv_FrmMain.panelForms.Controls.Add(_Frm);
            _Frm.Show();
        }
    }
}
