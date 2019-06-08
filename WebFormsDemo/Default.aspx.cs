using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsDemo.Service;

namespace WebFormsDemo
{
    public partial class _Default : Page
    {

        PollitoService _ps = new PollitoService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();

            }
        }

        private void CargarDatos()
        {

            GridView1.DataSource = _ps.ObtenerPollitos().ToList();
            GridView1.DataBind();

        }

        private void ExportGrid(string fileName, string contenType)
        {


            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachement;filename"+ fileName);

            Response.Charset = "";
            Response.ContentType = contenType;

            StringWriter Sw = new StringWriter();
            HtmlTextWriter Hw = new HtmlTextWriter(Sw);

            GridView1.RenderControl(Hw);
           // Response.Write(true);
            Response.Output.Write(Sw.ToString());

            Response.Flush();
            Response.Close();
            Response.End();

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void Botón1_Click(object sender, EventArgs e)
        {
            ExportGrid("Pollos.doc","application/vnd.ms-word");


        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            ExportGrid("Pollos.xls", "application/vnd.ms-excel");
        }
    }
}