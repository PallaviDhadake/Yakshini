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

public partial class news : System.Web.UI.Page
{
    public iClass c = new iClass();
    public string newsData, newsInfo;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["newsId"] != null)
        {
            string[] urlSplit = Request.QueryString["newsId"].ToString().Split('-');

            newsDetails(Convert.ToInt32( urlSplit[urlSplit.Length-1] ));
            allNews.Visible = false;
            detailNews.Visible = true;
        }
        else
        {
            getAllNews();
            allNews.Visible = true;
            detailNews.Visible = false;
        }
    }
    public void getAllNews()
    {
        DataTable dtNewsData = new DataTable();
        dtNewsData = c.getDataTable("Select newsId, newsDate, newsTitle, Left(newsInfo, 100) as newsDetails, newsPhoto From NewsData Where delMark=0 Order By newsDate Desc");
        StringBuilder strNews = new StringBuilder();
        if (dtNewsData.Rows.Count > 0)
        {
            foreach (DataRow row in dtNewsData.Rows)
            {
                strNews.Append("<div class=\"pressCont\">");

                if (row["newsPhoto"].ToString() != "no-img.png")
                {
                    strNews.Append("<a href=\"" + Master.routePath +"news/" + row["newsId"].ToString() + "\"><img src=\"" + Master.routePath + "upload/news/thumb/" + row["newsPhoto"].ToString() + "\" alt=\"" + row["newsTitle"].ToString() + "\" class=\"news-img\"/></a>");
                    strNews.Append("<div class=\"news-cont\">");
                    strNews.Append("");
                }

                strNews.Append("<a href=\"" + Master.routePath + "news/" + row["newsId"].ToString() + "\" class=\"news-Tag\">" + row["newsTitle"].ToString() + "</a>");
                DateTime nDate = new DateTime();
                nDate = Convert.ToDateTime(row["newsDate"].ToString());
                strNews.Append("<span class=\"post\">" + nDate.Day + "-" + nDate.Month + "-" + nDate.Year + " | Evenu Computers</span>");
                strNews.Append("<p class=\"para-txt ptxt-color mrg_b_15\">" + row["newsDetails"].ToString().Replace("\r\n", "<br/>") + "</p>");
                string url = row["newsTitle"].ToString().ToLower() + "-" + row["newsId"].ToString();
                url = c.urlGenerator(url);
                strNews.Append("<a href=\"" + Master.routePath + "news/" + url + "\" class=\"Rmore\">Read more...</a>");

                if (row["newsPhoto"].ToString() != "no-img.png")
                {
                    strNews.Append("</div>");
                    strNews.Append("<div class=\"float_clear\"></div>");
                }
                strNews.Append("</div>");
            }
        }
        newsData = strNews.ToString();
    }
    public void newsDetails( int newsId )
    {
        DataTable dtNews = new DataTable();
        dtNews = c.getDataTable("Select * From NewsData Where newsId=" + newsId);
        DataRow row = dtNews.Rows[0];

        StringBuilder strMarkup = new StringBuilder();
        strMarkup.Append("<div class=\"pressCont\">");
        if( row["newsPhoto"].ToString() != "no-img.png" )
        {
            strMarkup.Append("<img src=\""+ Master.routePath + "upload/news/" + row["newsPhoto"].ToString() + "\" alt=\"" + row["newsTitle"].ToString() + "\" class=\" mrg_b_15\"/>");
        }
        strMarkup.Append("<h2 class=\"news-heading\">" + row["newsTitle"].ToString() + "</h2>");
        DateTime nDate = new DateTime();
        nDate = Convert.ToDateTime (row["newsDate"].ToString());
        strMarkup.Append("<span class=\"news-post\">" + nDate.Day + "-" + nDate.Month + "-" + nDate.Year + " | Evenu Computers</span>");
        strMarkup.Append("<p class=\"para-txt ptxt-color mrg_b_15\">" + row["newsInfo"].ToString().Replace("\r\n","<br/>") + "</p>");
        strMarkup.Append("</div>");

        newsInfo = strMarkup.ToString();
    }

}
