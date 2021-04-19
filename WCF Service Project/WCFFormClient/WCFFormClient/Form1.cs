using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCFFormClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //client içine hangi protokolün kullanılacağı argümanını pass ederiz.
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client("NetTcpBinding_IService1");
            label2.Text = client.GetMessage(textBox1.Text);
        }
    }
}
