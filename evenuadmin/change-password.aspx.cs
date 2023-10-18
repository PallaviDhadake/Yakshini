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

public partial class evenuadmin_change_password : System.Web.UI.Page
{
    public string errMsg;
    public iClass c = new iClass();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void cmdCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("media.aspx");
    }
    protected void cmdSave_Click(object sender, EventArgs e)
    {
        if (txtOldPwd.Text == "" || txtNewPwd.Text == "" || txtConfirmPwd.Text == "")
        {
            errMsg = c.errNotification(2, "Enter Old And New Password");
            return;
        }
        string oldPassword = c.getReqData("Users", "userPwd", "userId=1").ToString();
        if (txtOldPwd.Text != oldPassword)
        {
            errMsg = c.errNotification(2, "Old password did not match");
            return;
        }
        if (txtNewPwd.Text != txtConfirmPwd.Text)
        {
            errMsg = c.errNotification(2, "New password confirmation failed");
            return;
        }


        c.ExecuteQuery("Update Users set userPwd='" + txtNewPwd.Text + "' Where userId=1");
        errMsg = c.errNotification(1, "Password changed succesfully");
        txtOldPwd.Text = txtNewPwd.Text = txtConfirmPwd.Text = "";
    }
}
