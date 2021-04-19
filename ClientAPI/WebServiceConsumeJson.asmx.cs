using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;

namespace ClientAPI
{
    /// <summary>
    /// Summary description for WebServiceConsumeJson
    /// </summary>
    [WebService(Namespace = "http://plantplaces.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceConsumeJson : System.Web.Services.WebService
    {
        
        [WebMethod]
        public string ConvertCommonToGenus(string common)
        {
            //default value of returning value
            string returnValue = "No record found";

            //collection of plants from JSON
            PlantCollection plantCollection;

            //Dictionary of genera and count
            IDictionary<String, Int32> generaCount = new Dictionary<String, Int32>();

            //read the raw JSOn data
            using (var webClient = new WebClient())
            {
                string rawData = webClient.DownloadString("https://www.plantplaces.com/perl/mobile/viewplantsjson.pl?Combined_Name=" + common);
                plantCollection = JsonConvert.DeserializeObject<PlantCollection>(rawData);

            }

            //accumulate genera Counts
            foreach (Plant plant in plantCollection.Plants)
            {
                if (generaCount.ContainsKey(plant.Genus))
                {
                    int currentCount = generaCount[plant.Genus];
                    currentCount++;
                    generaCount[plant.Genus] = currentCount;
                }
                else
                {
                    //genera does not exist add it with a default count of "1"
                    generaCount.Add(plant.Genus, 1);
                }
            }

            //find the most common genus
            int highWaterMark = 0;
            foreach (string genus in generaCount.Keys)
            {
                int currentFrequency = generaCount[genus];
                if (currentFrequency > highWaterMark)
                {
                    //a new top genus with the most frequency
                    returnValue = genus;
                    highWaterMark = currentFrequency;
                }
            }

            return returnValue;
        }
    }
}
