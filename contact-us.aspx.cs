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
public partial class contact_us : System.Web.UI.Page
{
    public iClass c = new iClass();
    public string errMsg;

    protected void Page_Load(object sender, EventArgs e)
    {
        Form.Action = Request.RawUrl;
        cmdSend.Attributes.Add("onclick", " this.disabled = true; this.value='Sendiing...'; " + ClientScript.GetPostBackEventReference(cmdSend, null) + ";");
    }
    protected void cmdSend_Click(object sender, EventArgs e)
    {
        if (txtEmail.Text == "" || txtMsg.Text == "" | txtName.Text == "" || txtPhone.Text == "")
        {
            errMsg = c.errNotification(2, "All * marked fields are mendatory");
            return;
        }
        try
        {
            StringBuilder strMail = new StringBuilder();
            strMail.Append("<br/>");
            strMail.Append("Dear Sir,");
            strMail.Append("<br/>");
            strMail.Append("You have new feedback from <b>" + txtName.Text + "</b>.");
            strMail.Append("<br/>");
            strMail.Append("<br/>");

            strMail.Append("<b>Name</b> : " + txtName.Text + "");
            strMail.Append("<br/>");
            strMail.Append("<b>Email</b> : " + txtEmail.Text + "");
            strMail.Append("<br/>");
            strMail.Append("<b>Phone</b> : " + txtPhone.Text + "");
            strMail.Append("<br/>");
            strMail.Append("<b>Message</b> : " + txtMsg.Text + "");
            strMail.Append("<br/>");
            strMail.Append("<br/>");

            c.sendMail("info@evenugroup.com", "evenu.computers@gmail.com", strMail.ToString(), "New Feedback", "", true, "", "");
            errMsg = c.errNotification(1, "Thank you for your valuable feedback.");
            txtEmail.Text = txtMsg.Text = txtName.Text = txtPhone.Text = "";
        }
        catch (Exception ex)
        {
            errMsg = c.errNotification(2, ex.Message);
        }
    }
    protected void cmdClear_Click(object sender, EventArgs e)
    {
        txtEmail.Text = txtMsg.Text = txtName.Text = txtPhone.Text = "";
    }
}
