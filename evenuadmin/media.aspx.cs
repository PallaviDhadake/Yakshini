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

public partial class shahadmin_news : System.Web.UI.Page
{
    public string errMsg;
    public iClass c = new iClass();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["action"] != null)
        {
            if (Request.QueryString["action"] == "new")
            {
                editNews.Visible = true;
                showNews.Visible = false;
                cmdReset.Visible = true;
                cmdDelete.Visible = false;
                cmdSave.Text = "Save";
                txtDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            }
            else if (Request.QueryString["action"] == "edit")
            {
                editNews.Visible = true;
                showNews.Visible = false;
                cmdSave.Text = "Modify";
                cmdDelete.Visible = true;
                cmdReset.Visible = false;
                if (!IsPostBack)
                {
                    getNews(Convert.ToInt32(Request.QueryString["id"]));
                }
            }
        }
        else
        {
            editNews.Visible = false;
            showNews.Visible = true;
            fillGrid();
        }
    }
    protected void cmdSave_Click(object sender, EventArgs e)
    {
        try
        {
            int maxId;
            string fileExt, imgName;
            string[] nDate;
            DateTime newsDate = new DateTime();

            nDate = txtDate.Text.Split('/');
            if (c.isDate(nDate[1] + "/" + nDate[0] + "/" + nDate[2]) == false)
            {
                errMsg = c.errNotification(2, "Invalid Date");
                return;
            }
            else
            {
                newsDate = Convert.ToDateTime(nDate[1] + "/" + nDate[0] + "/" + nDate[2]);
            }

            if (txtTitle.Text == "" || txtNDetails.Text == "")
            {
                errMsg = c.errNotification(2, "All * marked fields are mendatory");
                return;
            }

            txtTitle.Text = txtTitle.Text.Trim().Replace("'", "");
            txtNDetails.Text = txtNDetails.Text.Trim().Replace("'", "");

            maxId = c.nextId("NewsData", "newsId");

            if (flpPhoto.HasFile)
            {
                fileExt = Path.GetExtension(flpPhoto.FileName).ToLower();
                if (fileExt == ".jpg" || fileExt == ".png" || fileExt == ".jpeg")
                {
                    if (Request.QueryString["action"] == "new")
                    {
                        imgName = "img-news-" + maxId.ToString() + Path.GetExtension(flpPhoto.PostedFile.FileName);
                    }
                    else
                    {
                        imgName = "img-news-" + Request.QueryString["id"].ToString() + Path.GetExtension(flpPhoto.PostedFile.FileName);
                    }
                }
                else
                {
                    errMsg = c.errNotification(2, "Only png & jpg files are allowed");
                    return;
                }
            }
            else
            {
                imgName = "no-img.png";
            }

            if (Request.QueryString["action"] == "new")
            {
                c.ExecuteQuery("Insert Into NewsData (newsId, newsDate, newsTitle, newsInfo, newsPhoto, readCount, delMark) Values (" + maxId + ", '" + newsDate + "', '" + txtTitle.Text + "', '" + txtNDetails.Text + "', '" + imgName + "', 0, 0)");
            }
            else
            {
                if (flpPhoto.HasFile)
                {
                    c.ExecuteQuery("Update NewsData Set newsDate='" + newsDate + "', newsTitle='" + txtTitle.Text + "', newsInfo='" + txtNDetails.Text + "', newsPhoto='" + imgName + "' Where newsId=" + Request.QueryString["id"].ToString());
                }
                else
                {
                    c.ExecuteQuery("Update NewsData Set newsDate='" + newsDate + "', newsTitle='" + txtTitle.Text + "', newsInfo='" + txtNDetails.Text + "' Where newsId=" + Request.QueryString["id"].ToString());
                }
            }
            if (flpPhoto.HasFile)
            {
                imageUploadProcess(imgName);
            }
            txtDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            txtTitle.Text = txtNDetails.Text = "";
            errMsg = c.errNotification(1, "Record Saved");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Javascript", "javascript:waitAndMove('media.aspx', 2000);", true);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void imageUploadProcess(string imageName)
    {
        try
        {
            string origImgPath = "~/upload/news/original/";
            string normalImgPath = "~/upload/news/";
            string thumbImgPath = "~/upload/news/thumb/";
           // string destImgPath = "~/upload/news/raw/";


            flpPhoto.SaveAs(Server.MapPath(origImgPath) + imageName);

            c.imageOptimizer(imageName, origImgPath, normalImgPath, 840, true);
            c.imageOptimizer(imageName, normalImgPath, thumbImgPath, 320, true);

            File.Delete(Server.MapPath(origImgPath + imageName));
            // Reduce File Sizes of Images
           // c.ResizeMySize(origImgPath, imageName, destImgPath);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void getNews(int newsId)
    {
        try
        {
            DataTable dtNews = new DataTable();
            string strQuery = "Select newsDate, newsTitle, newsInfo, newsPhoto From NewsData Where delMark=0 and newsId=" + newsId;
            dtNews = c.getDataTable(strQuery);
            DataRow newsRow = dtNews.Rows[0];
            txtTitle.Text = newsRow["newsTitle"].ToString();
            txtNDetails.Text = newsRow["newsInfo"].ToString();
            DateTime newsDate = Convert.ToDateTime(newsRow["newsDate"]);
            txtDate.Text = newsDate.ToString("dd/MM/yyyy");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void fillGrid()
    {
        try
        {
            DataTable gvNewsTable = new DataTable();
            gvNewsTable = c.getDataTable("Select newsId, CONVERT(varchar,newsDate,103) as newsDateChr, newsTitle From NewsData");
            gvNews.DataSource = gvNewsTable;
            gvNews.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvNews_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal myLtr = new Literal();
                myLtr = (Literal)e.Row.FindControl("litAnch");
                myLtr.Text = "<a href='media.aspx?action=edit&id=" + e.Row.Cells[0].Text + "' class=\"gAnch\" >Edit</a>";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void cmdReset_Click(object sender, EventArgs e)
    {
        try
        {
            txtDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            txtTitle.Text = txtNDetails.Text = "";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void cmdCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("media.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void cmdDelete_Click(object sender, EventArgs e)
    {
        try
        {
            c.ExecuteQuery("Delete From NewsData Where newsId=" + Request.QueryString["id"].ToString());
            //Page.ClientScript.RegisterStartupScript(Me.[GetType](), "RedirectMe", "waitAndMove('media.aspx', 2000);", True);
            txtNDetails.Text = txtTitle.Text = "";
            txtDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            errMsg = c.errNotification(1, "Record Deleted");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Javascript", "javascript:waitAndMove('media.aspx', 2000);", true);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
