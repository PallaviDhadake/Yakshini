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
using System.IO;

public partial class evenuadmin_ProductSpecs : System.Web.UI.Page
{
    public iClass c = new iClass();
    public string errMsg;
    public string routePath;
    protected void Page_Load(object sender, EventArgs e)
    {
        routePath = c.returnHttp(0);

        if (!IsPostBack)
        {
            fillDDr();
            if (Request.QueryString["action"] != null)
            {
                viewProducts.Visible = false;
                editProducts.Visible = true;

                if (Request.QueryString["action"] == "new")
                {
                    cmdSave.Text = "Save";
                    cmdDelete.Visible = false;
                }
                else if (Request.QueryString["action"] == "edit")
                {
                    cmdSave.Text = "Modify";
                    cmdDelete.Visible = true;
                    getProductInfo(Convert.ToInt32(Request.QueryString["proId"]));
                }

            }
            else
            {
                viewProducts.Visible = true;
                editProducts.Visible = false;
                DataTable dtProducts = new DataTable();
                dtProducts = c.getDataTable("Select a.prodId, a.prodName, b.brandName From ProductsData a Inner Join BrandNames b on a.brandId=b.brandId Order By a.prodId");
                gvProducts.DataSource = dtProducts;
                gvProducts.DataBind();
            }
        }

    }
    public void fillDDr()
    {
        c.fillComboBox("dvcName", "dvcId", "DeviceType", "", ddrDevice);

        c.fillComboBox("brandName", "brandId", "BrandNames", "", ddrBrand);
    }
    protected void cmdSave_Click(object sender, EventArgs e)
    {
        if (ddrDevice.SelectedIndex == 0)
        {
            errMsg = c.errNotification(2, "Select Device type");
            return;
        }
        if (ddrCategory.SelectedIndex == 0)
        {
            errMsg = c.errNotification(2, "Select Category");
            return;
        }
        if (ddrBrand.SelectedIndex == 0)
        {
            errMsg = c.errNotification(2, "Select Brand Name");
            return;
        }
        if (txtName.Text == "" || txtSpecs.Text == "" || txtWarranty.Text == "")
        {
            errMsg = c.errNotification(2, "All * marked fields are mendatory");
            return;
        }
        string ext = "";

        if (Request.QueryString["action"] == "new")
        {
            if (flpPhoto.FileName == "")
            {
                errMsg = c.errNotification(2, "Select Image file");
                return;
            }
            else
            {
                ext = Path.GetExtension(flpPhoto.FileName).ToLower();
                if (ext != ".jpg" && ext != ".jpeg" && ext != ".png")
                {
                    errMsg = c.errNotification(2, "Only .jpg, .jpeg and .png files are allowed");
                    return;
                }
            }
        }
        else
        {
            ext = Path.GetExtension(flpPhoto.FileName).ToLower();
            if (flpPhoto.HasFile)
            {
                if (ext != ".jpg" && ext != ".jpeg" && ext != ".png")
                {
                    errMsg = c.errNotification(2, "Only .jpg, .jpeg and .png files are allowed");
                    return;
                }
            }
        }

        int maxId = c.nextId("ProductsData", "prodId");
        string fileName;
        if (Request.QueryString["action"] == "new")
        {
            fileName = "pro-" + maxId + ext;
        }
        else
        {
            fileName = "pro-" + Request.QueryString["proId"].ToString() + ext;
        }
        int mrpPrice = 0;
        int offerPrice = 0;
        if (txtMrp.Text != "")
        {
            mrpPrice = Convert.ToInt32(txtMrp.Text);
        }
        if (txtOffer.Text != "")
        {
            offerPrice = Convert.ToInt32(txtOffer.Text);
        }
        if (Request.QueryString["action"] == "new")
        {
            c.ExecuteQuery("Insert Into ProductsData(prodId, dvcId, categoryId, brandId, prodName, prodSpecs, warranty, mrpPrice, offerPrice, imgName, viewCount, delMark) Values(" + maxId + ",'" + ddrDevice.SelectedValue + "', '" + ddrCategory.SelectedValue + "', '" + ddrBrand.SelectedValue + "', '" + txtName.Text + "', '" + txtSpecs.Text + "', '" + txtWarranty.Text + "', " + mrpPrice + ", " + offerPrice + ", '" + fileName + "', 0, 0)");
        }
        else
        {
            if (flpPhoto.HasFile)
            {
                c.ExecuteQuery("Update ProductsData Set dvcId='" + ddrDevice.SelectedValue + "', categoryId='" + ddrCategory.SelectedValue + "', brandId='" + ddrBrand.SelectedValue + "', prodName='" + txtName.Text + "', prodSpecs='" + txtSpecs.Text + "', warranty='" + txtWarranty.Text + "', mrpPrice=" + mrpPrice + ", offerPrice=" + offerPrice + ", imgName='" + fileName + "' Where prodId=" + Request.QueryString["proId"]);
            }
            else
            {
                c.ExecuteQuery("Update ProductsData Set dvcId='" + ddrDevice.SelectedValue + "', categoryId='" + ddrCategory.SelectedValue + "', brandId='" + ddrBrand.SelectedValue + "', prodName='" + txtName.Text + "', prodSpecs='" + txtSpecs.Text + "', warranty='" + txtWarranty.Text + "', mrpPrice=" + mrpPrice + ", offerPrice=" + offerPrice + " Where prodId=" + Request.QueryString["proId"]);
            }
        }
        if (flpPhoto.HasFile)
        {
            imageUploadProcess(fileName);
        }
        clrctrls();
        errMsg = c.errNotification(1, "Record Saved");
    }
    public void imageUploadProcess(string imgName)
    {
        string origPath = "~/upload/products/original/";
        string thumbPath ="~/upload/products/thumb/";
        string imgPath = "~/upload/products/";

        flpPhoto.SaveAs(Server.MapPath(origPath) + imgName);
        c.imageOptimizer(imgName, origPath, imgPath, 500, true);
        c.imageOptimizer(imgName, origPath, thumbPath, 248, true);
        File.Delete(Server.MapPath(origPath + imgName));
    }
    protected void cmdReset_Click(object sender, EventArgs e)
    {
        clrctrls();
    }
    public void clrctrls()
    {
        ddrDevice.SelectedIndex = 0;
        ddrCategory.SelectedIndex = 0;
        ddrBrand.SelectedIndex = 0;
        txtName.Text = txtSpecs.Text = txtWarranty.Text = txtMrp.Text = txtOffer.Text = "";
    }
    protected void cmdDelete_Click(object sender, EventArgs e)
    {
        c.ExecuteQuery("Delete From ProductsData Where prodId=" + Request.QueryString["proId"].ToString());
        Response.Redirect("specifications.aspx");
    }
    protected void gvProducts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal myLtr = new Literal();
                myLtr = (Literal)e.Row.FindControl("litAnch");
                myLtr.Text = "<a href='specifications.aspx?action=edit&proId=" + e.Row.Cells[0].Text + "' class=\"gAnch\" >Edit</a>";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void getProductInfo(int prodId)
    {
        DataTable dtProduct = new DataTable();
        dtProduct = c.getDataTable("Select * From ProductsData Where prodId=" + prodId);
        DataRow row = dtProduct.Rows[0];
        ddrDevice.SelectedValue = row["dvcId"].ToString();

        c.fillComboBox("catName", "catId", "CategoryType", "dvcId=" + row["dvcId"].ToString(), ddrCategory);

        //ddrCategory.SelectedValue = row["categoryId"].ToString();

        ddrCategory.SelectedValue = row["categoryId"].ToString();

        ddrBrand.SelectedValue = row["brandId"].ToString();
        txtName.Text = row["prodName"].ToString();
        txtSpecs.Text = row["prodSpecs"].ToString();
        txtWarranty.Text = row["warranty"].ToString();
        txtMrp.Text = (row["mrpPrice"] != DBNull.Value) ? row["mrpPrice"].ToString() : "";
        txtOffer.Text = (row["offerPrice"] != DBNull.Value) ? row["offerPrice"].ToString() : "";
    }
    protected void cmdCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("specifications.aspx");
    }
    protected void ddrDevice_SelectedIndexChanged(object sender, EventArgs e)
    {
        c.fillComboBox("catName", "catId", "CategoryType", "dvcId=" + ddrDevice.SelectedValue, ddrCategory);
    }
}
