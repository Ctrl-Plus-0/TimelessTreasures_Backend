using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimelessTreasuresWeb1.ServiceReference1;

namespace TimelessTreasuresWeb1
{
    public partial class Invoices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillTable();
        }
        private void FillTable()
        {
            Service1Client SC = new Service1Client();

            //get user id from string
            int Uid = int.Parse(Session["UserId"].ToString());
            dynamic temp = SC.GetInvoices(Uid);

            foreach(InvoiceWrapper IW in temp)
            {
                TableRow TR = new TableRow();

                //ID
                TableCell InvID = new TableCell();
                InvID.Attributes["style"] = "font-weight: bold; color: black;";
                InvID.Text =IW.id.ToString();

                TR.Controls.Add(InvID);
                //total
                TableCell InvTotal = new TableCell();
                InvTotal.Attributes["style"] = "font-weight: bold; color: black;";
                InvTotal.Text ="R"+IW.Price.ToString();
                TR.Controls.Add(InvTotal);

                //Date Made
                TableCell InvDate = new TableCell();
                InvDate.Attributes["style"] = "font-weight: bold; color: black;";
                InvDate.Text = IW.D.ToString();
                TR.Controls.Add(InvDate);

                //View More
                TableCell InvViewMore = new TableCell();
                InvViewMore.Attributes["style"] = "font-weight: bold; color: black;";
                InvViewMore.Text = $@"<a href=""Gift.aspx?{IW.id}"">View More </a>";
                TR.Controls.Add(InvViewMore);

                InvoiceHolder.Controls.Add(TR);

            }
        }
    }
}