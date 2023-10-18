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

public partial class product : System.Web.UI.Page
{
    public iClass c = new iClass();
    public string navMenu, prodGrid, prodInfo, bCrumb, errMsg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Form.Action = Request.RawUrl;
        cmdSubmit.Attributes.Add("onclick", " this.disabled = true; this.value='Sendiing...'; " + ClientScript.GetPostBackEventReference(cmdSubmit, null) + ";");
        if (!IsPostBack)
        {
            menuMarkup();
        }
        if (Request.QueryString["prodType"] != null)
        {
            if (Request.QueryString["prodId"] != null)
            {
                SingleProduct.Visible = true;

                string[] arrUrl = Request.QueryString["prodId"].ToString().Split('-');

                productDetails(Convert.ToInt32(arrUrl[arrUrl.Length - 1]));
            }
            else
            {

                string catName = Request.QueryString["prodType"].ToString().ToLower().Replace("-", " ");
                showProducts(catName);
                AllProduct.Visible = true;
            }
        }
        else
        {
            showProducts("none");
            AllProduct.Visible = true;
        }
        
    }
    public void showProducts(string categoryX)
    {

        //string catName = Request.QueryString["prodType"].ToString();
        //catName = catName.Replace("-", " ");

        StringBuilder strPrducts = new StringBuilder();
        DataTable dtProducts = new DataTable();
        //string proType = Request.QueryString["prodType"] != null ? Request.QueryString["prodType"].ToString() : "desktop";
        int catId=0;
        if (categoryX == "none")
        {
            //dtProducts = c.getDataTable("Select a.prodId, a.prodName,  a.prodSpecs, b.catName, a.imgName, c.brandName From ProductsData a Inner Join CategoryType b on a.categoryId=b.catId Inner Join BrandNames c on a.brandId=c.brandId Where featured=1");
            dtProducts = c.getDataTable("Select a.prodId, a.prodName,  a.prodSpecs, b.catName, a.imgName, c.brandName From ProductsData a Inner Join CategoryType b on a.categoryId=b.catId Inner Join BrandNames c on a.brandId=c.brandId Where categoryId=1");
        }
        else
        {
            catId = Convert.ToInt32( c.getReqData("CategoryType", "catId", "catName='" + categoryX + "'"));
            dtProducts = c.getDataTable("Select a.prodId, a.prodName,  a.prodSpecs, b.catName, a.imgName, c.brandName From ProductsData a Inner Join CategoryType b on a.categoryId=b.catId Inner Join BrandNames c on a.brandId=c.brandId Where categoryId=" + catId);
        }



        if (categoryX == "none")
        {
            strPrducts.Append("<h2 class=\"HeadTitle\">Featured Products</h2>");
        }
        else
        {
            strPrducts.Append("<h2 class=\"HeadTitle\">" + c.getReqData("CategoryType","catName","catId=" + catId) + "</h2>");
        }

        strPrducts.Append("<div class=\"spacer20\"></div>");

        int count = 1;
        int rowCount = 1;
        int totalCount = 1;
        foreach (DataRow row in dtProducts.Rows)
        {
            if (count == 3 || rowCount== dtProducts.Rows.Count )
            {
                strPrducts.Append("<div class=\"product border-LB border-right border-top\">");
                count = 0;
            }
            else
            {
                strPrducts.Append("<div class=\"product border-LB  border-top\">");
            }

            strPrducts.Append("<div class=\"pad_15\">");

            strPrducts.Append("<div class=\"productPanel\">");
            
            strPrducts.Append("<img src=\"" + Master.routePath +"upload/products/thumb/" +row["imgName"].ToString() + "\" alt=\"" + row["prodName"].ToString() + "\" />");
            strPrducts.Append("</div>");

            strPrducts.Append("<h2 class=\"cl-themeBlue font20 txt_center mrg_b_15\">" + row["brandName"].ToString() + " " + row["prodName"].ToString() + "</h2>");

            strPrducts.Append("<ul class=\"productList\">");
            string[] arrSpecs = row["prodSpecs"].ToString().Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            int i = 0;
            foreach (string spec in arrSpecs)
            {
                if (i < 3)
                {
                    strPrducts.Append("<li>" + spec + "</li>");
                }
                i++;
            }
            strPrducts.Append("</ul>");
            string url = Master.routePath + "product/" + row["catName"].ToString().ToLower().Replace(" ", "-") + "/" + row["brandName"].ToString().ToLower().Replace(" ", "-") + "-" + row["prodName"].ToString().ToLower().Replace(" ", "-") + "-" + row["prodId"].ToString();
            strPrducts.Append("<a href=\"" + url + "\" class=\"prod-anchor themeBlue round3\">Learn more...</a>");
            strPrducts.Append("</div>");
            strPrducts.Append("</div>");
            //strPrducts.Append("</div>");
            count++;
            rowCount++;
            totalCount++;
        }

        prodGrid = strPrducts.ToString();


        //Breadcrumb

        bCrumb = "<li><a href=\"" + Master.routePath + "\">Home</a></li><li class=\"cl-themeBlue\">»</li><li class=\"color-gray\">Product</li>";


        //


    }
    public void menuMarkup()
    {
        DataTable dtMenuItems = new DataTable();
        dtMenuItems = c.getDataTable("Select dvcName, dvcId From DeviceType Order By dvcId");
        DataTable dtSubItems = new DataTable();
        StringBuilder strMarkup = new StringBuilder();
        strMarkup.Append("<ul class=\"catNav\">");
        int i = 1;
        foreach (DataRow row in dtMenuItems.Rows)
        {
            
            if (i != dtMenuItems.Rows.Count)
            {
                strMarkup.Append("<li><a  class=\"pontr\" onclick=\"toggleSpam('navBox" + row["dvcId"].ToString() + "');\">" + row["dvcName"].ToString() + "</a>");
            }
            else
            {
                strMarkup.Append("<li><a class=\"Bborder-none pontr\" onclick=\"toggleSpam('navBox" + row["dvcId"].ToString() + "');\">" + row["dvcName"].ToString() + "</a>");
                //strMarkup.Append("<li><a href=\"#\" class=\"Bborder-none\">" +  + "</a></li>");
            }


            dtSubItems = c.getDataTable("Select * From CategoryType Where dvcId=" + row["dvcId"].ToString());

            strMarkup.Append("<ul Id=\"navBox" + row["dvcId"].ToString() + "\" class=\"subNavBg\">");
            string url;
            foreach (DataRow subRow in dtSubItems.Rows)
            {
                url = Master.routePath + "product/" + subRow["catName"].ToString().ToLower().Replace(" ", "-");
                strMarkup.Append("<li><a href=\"" + url + "\">" + subRow["catName"].ToString() + "</a></li>");
            }
            strMarkup.Append("</ul>");
            strMarkup.Append("</li>");
            i++;
        }

        strMarkup.Append("</ul>");

        navMenu = strMarkup.ToString();

    }
    public void productDetails(int prodIDX)
    {
        DataTable dtProInfo = new DataTable();
        dtProInfo = c.getDataTable("Select a.prodName, a.prodSpecs, a.warranty, a.mrpPrice, a.offerPrice, a.imgName, b.dvcName, c.brandName, a.categoryId  From ProductsData a Inner Join DeviceType b on a.dvcId=b.dvcId Inner Join BrandNames c on a.brandId=c.brandId Where a.prodId=" + prodIDX);

        DataRow row = dtProInfo.Rows[0];
        StringBuilder strMarkup = new StringBuilder();

        this.Title = " Buy " + row["brandName"].ToString() + " " + row["prodName"].ToString() + " " + c.getReqData("CategoryType", "catName", "catId=" + row["categoryId"]).ToString() + " | Evenu Computers Sangli";

        strMarkup.Append("<div class=\"productImg\">");
        strMarkup.Append("<img src=\"" + Master.routePath + "upload/products/" + row["imgName"].ToString() + "\" alt=\"\"  />");
        strMarkup.Append("</div>");
        strMarkup.Append("<div class=\"prod-wrapper\">");
        strMarkup.Append("<h2 class=\"font25 fontUbuntuBold cl-black mrg_b_10\">" + row["brandName"].ToString() + " " + row["prodName"].ToString() + "</h2>");
        strMarkup.Append("<h3 class=\"font16 cl-black\">Company :<span class=\"color-gray mrg_l_10\">" + row["brandName"].ToString() + "</span></h3>");
        strMarkup.Append("<div class=\"spacer15\"></div>");
        strMarkup.Append("<div class=\"line_sp\"></div>");
        strMarkup.Append("<div class=\"spacer15\"></div>");
        strMarkup.Append("<div class=\"product-contList\">");
        strMarkup.Append("<ul class=\"Prod-Listing\">");
        
        //Specification
        string[] arrSpecs = row["prodSpecs"].ToString().Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

        foreach (string spec in arrSpecs)
        {
            if (spec != "" && spec != " ")
            {
                strMarkup.Append("<li>" + spec + "</li>");
            }
        }

        strMarkup.Append("</ul>");
        strMarkup.Append("</div>");
        strMarkup.Append("<div class=\"product-contPrice\">");
        strMarkup.Append("<h3 class=\"font16 fontUbuntuBold color-gray\">Warranty:<span class=\"font12 hd-Gray display-block mrg_t_5\">" + row["warranty"].ToString() + "</span></h3>");
        strMarkup.Append("<div class=\"spacer20\"></div>");

        //Offer /Scheme
        //Remaining Coding

        int mrp, off, savings;

        if (Convert.ToInt32( row["mrpPrice"]) != 0 )
        {
            if (row["offerPrice"] != DBNull.Value || row["offerPrice"].ToString() == "")
            {
                mrp = Convert.ToInt32(row["mrpPrice"]);
                off = Convert.ToInt32(row["offerPrice"]);
                savings = mrp - off;

                strMarkup.Append("<h2 class=\"font20 color-gray fontUbuntuRegular\">Offer Price Rs." + off + "</h2>");
                strMarkup.Append("<h2 class=\"font16 color-gray fontUbuntuRegular strike\">MRP Rs." + mrp + "</h2>");
                strMarkup.Append("<h2 class=\"font16 color-gray fontUbuntuRegular saving\">You Save Rs." + savings + "</h2>");
            }
            else
            {
                strMarkup.Append("<h2 class=\"font20 color-gray fontUbuntuRegular strike\"> MRP Rs." + row["mrpPrice"].ToString() + "</h2>");
            }
        }
        else
        {
            strMarkup.Append("<h2 class=\"font20 color-gray fontUbuntuRegular \">Price Not Mentioned </h2>");
        }
        
        strMarkup.Append("</div>"); 
        strMarkup.Append("</div>");
        strMarkup.Append("<div class=\"float_clear\"></div>");
        strMarkup.Append("");
        strMarkup.Append("");
        strMarkup.Append("");
        strMarkup.Append("");
        strMarkup.Append("");
        strMarkup.Append("");

        prodInfo = strMarkup.ToString();

        bCrumb = "<li><a href=\"" + Master.routePath + "\">Home</a></li><li class=\"cl-themeBlue\">»</li><li><a href=\"" + Master.routePath + "product\">Products</a></li><li class=\"cl-themeBlue\">»</li><li class=\"color-gray\">" + row["brandName"].ToString() + " " + row["prodName"].ToString() + "</li>";

    }
    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        if (txtName.Text == "" )
        {
            errMsg = c.errNotification(2, "Enter Name");
            return;
        }
        if (txtContact.Text == "")
        {
            errMsg = c.errNotification(2, "Enter contact number");
            return;
        }
        if (txtCity.Text == "")
        {
            errMsg = c.errNotification(2, "Enter city");
            return;
        }
        if (txtMsg.Text == "")
        {
            errMsg = c.errNotification(2, "Enter enquiry message");
            return;
        }

        try
        {
            StringBuilder strMail = new StringBuilder();
            strMail.Append("Dear Sir,");
            strMail.Append("<br/>");

            string[] linkSep = Request.QueryString["prodId"].ToString().Split('-');
            int proId = Convert.ToInt32(linkSep[linkSep.Length - 1]);
            string prodName = c.getReqData("ProductsData", "prodName", "prodId=" + proId).ToString();

            strMail.Append("You have new enquiry about <b>" + prodName + "</b> from " + txtName.Text + " ");
            strMail.Append("<br/>");
            strMail.Append("<br/>");
            strMail.Append("<b>Enquiry Details</b>");
            strMail.Append("<br/>");
            strMail.Append("<b>Name : </b>" + txtName.Text + "");
            strMail.Append("<br/>");
            strMail.Append("<b>Email : </b>" + txtEmail.Text + "");
            strMail.Append("<br/>");
            strMail.Append("<b>Contact No : </b>" + txtContact.Text + "");
            strMail.Append("<br/>");
            strMail.Append("<b>City : </b>" + txtCity.Text + "");
            strMail.Append("<br/>");
            strMail.Append("<b>Message : </b>" + txtMsg.Text + "");
            strMail.Append("<br/>");
            strMail.Append("<br/>");

            c.sendMail("info@evenugroup.com", "evenu.computers@gmail.com", strMail.ToString(), "New Product Enquiry", "", true, "", "");
            errMsg = c.errNotification(1, "Your enquiry submitted successfully. We'll contact you soon");
            txtName.Text = txtCity.Text = txtContact.Text = txtEmail.Text = txtMsg.Text = "";
        }
        catch (Exception ex)
        {
            errMsg = c.errNotification(2, ex.Message);

        }
        
    }
}
