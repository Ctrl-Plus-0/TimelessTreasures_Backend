using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimelessTreasuresWeb1.ServiceReference1;

namespace TimelessTreasuresWeb1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Service1Client client = new Service1Client();

            

            client.Close();
        }

        protected void btnGetChart_Click(object sender, EventArgs e)
        {
            string selectedChart = "";

            foreach (ListItem item in chart_name.Items)
            {
                if (item.Selected)
                {
                    selectedChart = item.Value;
                    break;
                }
            }

            string chartType = "";

            foreach (ListItem item in chart_type.Items)
            {
                if (item.Selected)
                {
                    chartType = item.Value;
                    break;
                }
            }

            String dynamicChart = "";


            dynamicChart += $"<img src=\"Charts/Bar/{selectedChart}\"/>";

            report_chart.InnerHtml = dynamicChart;
             
        }
    }
}