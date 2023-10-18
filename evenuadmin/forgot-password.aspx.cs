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
using System.Text;

public partial class evenuadmin_forgot_password : System.Web.UI.Page
{
    public string errMsg;
    public iClass c = new iClass();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void cmdPwd_Click(object sender, EventArgs e)
    {
        if (txtEmail.Text == "")
        {
            errMsg = c.errNotification(2, "Enter email to get the password");
            return;
        }
        if (c.isRecordExist("Select userId From Users Where userEmail='" + txtEmail.Text.Trim() + "'") == false)
        {
            errMsg = c.errNotification(3, "Invalid email address");
            return;
        }
        passwordRecovery();
        errMsg = c.errNotification(1, "Username and Password has been sent to your email address");
    }
    public void passwordRecovery()
    {
        StringBuilder strMail = new StringBuilder();
        string userName = c.getReqData("Users", "userName", "userEmail='" + txtEmail.Text + "'").ToString();
        string userPwd = c.getReqData("Users", "userPwd", "userEmail='" + txtEmail.Text + "'").ToString();

        strMail.Append("Please login using following credentials...");
        strMail.Append("<br/><br/><br/>");
        strMail.Append("<b>UserName :</b>" + userName);
        strMail.Append("<br/>");
        strMail.Append("<b>Password :</b>" + userPwd);
        strMail.Append("<br/><br/><br/>");

        c.sendMail("info@evenugroup.com", txtEmail.Text.Trim(), strMail.ToString(), "Password Recovery", "", false, "", "");

    }
}
