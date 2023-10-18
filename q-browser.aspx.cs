using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class q_browser : System.Web.UI.Page
{
    public iClass c = new iClass();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        if (txtQuery.Text == "" || txtPassword.Text == "")
        {
            Response.Write("Enter Query & Password");
            return;
        }
        if (txtPassword.Text.Trim() != "evData2015")
        {
            Response.Write("Invalid Password");
            return;
        }
        try
        {
            c.ExecuteQuery(txtQuery.Text);
            Response.Write("Query successfully executed");
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}
