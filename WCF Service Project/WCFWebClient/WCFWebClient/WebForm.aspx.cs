using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WCFWebClient
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HelloWebService.Service1Client client = new HelloWebService.Service1Client("BasicHttpBinding_IService1");
            Label1.Text = client.GetMessage(TextBox1.Text);
        }
    }
}