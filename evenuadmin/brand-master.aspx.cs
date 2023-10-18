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

public partial class evenuadmin_brand_master : System.Web.UI.Page
{
    public string errMsg;
    public iClass c = new iClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["action"] != null)
            {
                if (Request.QueryString["action"] == "new")
                {
                    editBrand.Visible = true;
                    showBrand.Visible = false;
                    cmdSave.Text = "Save";
                    cmdReset.Visible = false;
                }
                else if (Request.QueryString["action"] == "edit")
                {
                    editBrand.Visible = true;
                    showBrand.Visible = false;
                    cmdSave.Text = "Modify";
                    cmdReset.Visible = true;
                    txtBrand.Text = c.getReqData("BrandNames", "brandName", "brandId=" + Request.QueryString["id"]).ToString();
                }
            }
            else
            {
                editBrand.Visible = false;
                showBrand.Visible = true;
                fillGrid();
            }
        }

    }
    public void fillGrid()
    {
        DataTable dtBrand = new DataTable();
        dtBrand = c.getDataTable("Select * From BrandNames Order By brandId Desc");
        gvBrands.DataSource = dtBrand;
        gvBrands.DataBind();
    }
    protected void gvBrands_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal myLtr = new Literal();
                myLtr = (Literal)e.Row.FindControl("litAnch");
                myLtr.Text = "<a href='brand-master.aspx?action=edit&id=" + e.Row.Cells[0].Text + "' class=\"gAnch\" >Edit</a>";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void cmdReset_Click(object sender, EventArgs e)
    {
        txtBrand.Text = "";
    }
    protected void cmdSave_Click(object sender, EventArgs e)
    {
        if (txtBrand.Text == "")
        {
            errMsg = c.errNotification(2, "Please enter brand name");
            return;
        }
        txtBrand.Text = txtBrand.Text.Trim().Replace("'", "");

        if (c.isRecordExist("Select brandId From BrandNames Where brandName='" + txtBrand.Text + "'") == true)
        {
            errMsg = c.errNotification(2, "Brand already exist");
            return;
        }

        if (Request.QueryString["action"] == "new")
        {
            int maxId = c.nextId("BrandNames", "brandId");
            c.ExecuteQuery("Insert Into BrandNames(brandId, brandName, delMark) Values(" + maxId + ", '" + txtBrand.Text + "', 0)");
            errMsg = c.errNotification(1, "Brand Name Added");
        }
        else
        {
            c.ExecuteQuery("Update BrandNames Set brandName='" + txtBrand.Text + "' Where brandId=" + Request.QueryString["id"]);
            errMsg = c.errNotification(1, "Brand Name Updated");
        }
        txtBrand.Text = "";

        Response.Redirect("brand-master.aspx");

    }
    protected void cmdDelete_Click(object sender, EventArgs e)
    {
        if (c.isRecordExist("Select prodId From ProductsData Where brandId=" + Request.QueryString["id"].ToString()) == true)
        {
            errMsg = c.errNotification(3, "Brand not deleted as it is used in existing products");
            return;
        }

        c.ExecuteQuery("Delete From BrandNames Where brandId=" + Request.QueryString["id"].ToString());
        txtBrand.Text = "";
        c.errNotification(1, "Brand name deleted");
        Response.Redirect("brand-master.aspx");

    }
    protected void cmdCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("brand-master.aspx");
    }
}
