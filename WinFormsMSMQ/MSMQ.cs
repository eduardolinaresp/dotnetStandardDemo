using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Messaging;

namespace WinFormsMSMQ
{
    public partial class MSMQ : Form
    {
        public System.Messaging.MessageQueue mq;
        public static Int32 Contador = 0;


        public MSMQ()
        {
            InitializeComponent();

            if (MessageQueue.Exists(@".\Private$\ColaEjemplo1"))
            {
                mq = new MessageQueue(@".\Private$\ColaEjemplo1");
            }
            else
            {
                mq = MessageQueue.Create(@".\Private$\ColaEjemplo1");
            }


        }

        private void MSMQ_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            System.Messaging.Message msj_sender = new System.Messaging.Message();
            msj_sender.Body = "Ejemplo" + Contador.ToString();
            msj_sender.Label = "msg" + Contador.ToString();
            Contador++;
            mq.Send(msj_sender);

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            System.Messaging.Message msj_receiver;
            string mensaje;

            try
            {
                msj_receiver = mq.Receive(new TimeSpan(0,0,3));
                msj_receiver.Formatter = new XmlMessageFormatter(new string[] { "System.String, mscorlib" });
                mensaje = msj_receiver.Body.ToString();

            }
            catch (Exception ex)
            {
                mensaje = "Sin Mensajes";
                Console.WriteLine(ex.Message);
                
            }

            MessageBox.Show(mensaje.ToString());  



        }
    }
}
