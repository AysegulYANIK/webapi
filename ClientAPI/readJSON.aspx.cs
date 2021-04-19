using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientAPI
{
    public partial class readJSON : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            using (var webClient = new WebClient())
            {
                //get a string representation of our JSON
                string rawData = webClient.DownloadString("https://www.plantplaces.com/perl/mobile/viewplantsjson.pl?Combined_Name=Oak" );
                
                //convert the JSON string into series of objects
                PlantCollection plantCollection = JsonConvert.DeserializeObject<PlantCollection>(rawData);

                //do some computation
                Console.WriteLine("Result is : " + plantCollection.Plants.Count);

            }

        }
    }
}