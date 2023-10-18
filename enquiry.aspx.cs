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
public partial class enquiry : System.Web.UI.Page
{
    public string errMsg;
    public iClass c = new iClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        Form.Action = Request.RawUrl;

        cmdSubmit.Attributes.Add("onclick", " this.disabled = true; this.value='Sendiing...'; " + ClientScript.GetPostBackEventReference(cmdSubmit, null) + ";");
       
    }
    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        if (ddlEnqFor.SelectedIndex == 0)
        {
            errMsg = c.errNotification(2, "Select enquiry type");
            return;

        }
        if (txtName.Text == "" || txtContact.Text == "" || txtCity.Text == "" || txtMsg.Text == "")
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
            strMail.Append("You have a new enquiry for " + ddlEnqFor.SelectedItem + "");
            strMail.Append("<br/>");
            strMail.Append("<br/>");
            strMail.Append("<b>Enquiry Details</b>");
            strMail.Append("<b>Name : </b>" + txtName.Text + "");
            strMail.Append("<br/>");
            strMail.Append("<b>Email : </b>" + txtEmail.Text + "");
            strMail.Append("<br/>");
            strMail.Append("<b>Contact No.: </b>" + txtContact.Text + "");
            strMail.Append("<br/>");
            strMail.Append("<b>City : </b>" + txtCity.Text + "");
            strMail.Append("<br/>");
            strMail.Append("<b>Message : </b>" + txtMsg.Text + "");
            strMail.Append("<br/>");
            strMail.Append("<br/>");

            c.sendMail("info@evenugroup.com", "evenu.computers@gmail.com", strMail.ToString(), "New Enquiry", "", true, "", "");

            txtCity.Text = txtContact.Text = txtEmail.Text = txtMsg.Text = txtName.Text = "";
            ddlEnqFor.SelectedIndex = 0;
            errMsg = c.errNotification(1, "Enquiry submitted. We'll contact you soon");
        }
        catch (Exception ex)
        {
            errMsg = c.errNotification(2, ex.Message);
        }
    }
}
