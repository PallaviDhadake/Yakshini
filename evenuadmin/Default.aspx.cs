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

public partial class evenuadmin_Default : System.Web.UI.Page
{
    public string errMsg;
    public iClass c = new iClass();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void cmdLogin_Click(object sender, ImageClickEventArgs e)
    {
        if (txtUsername.Text == "" || txtPassword.Text == "")
        {
            errMsg = c.errNotification(2, "Enter Username and Password");
            return;
        }
        if (c.isRecordExist("Select userId From Users Where userName='" + txtUsername.Text.Trim() + "'") == false)
        {
            errMsg = c.errNotification(3, "Invalid Username");
            return;
        }
        string password = c.getReqData("Users", "userPwd", "userName='" + txtUsername.Text + "'").ToString();
        if (password != txtPassword.Text.Trim())
        {
            errMsg = c.errNotification(3, "Username and Password does not match");
            return;
        }

        Session["evenuadmin"] = "active";
        Response.Redirect("media.aspx");
    }
}
