using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TimelessTreasuresWeb1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            ServiceReference1.Service1Client SC = new ServiceReference1.Service1Client();

            string dynamicChart = "";

         
            dynamicChart += $@"<img src=""Charts/{selectedChart}.cshtml"">";

            report_chart.InnerHtml = dynamicChart;
        }
    }
}