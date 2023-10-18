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
public partial class services : System.Web.UI.Page
{
    public iClass c = new iClass();
    public string newsMarkup, routePath;
    protected void Page_Load(object sender, EventArgs e)
    {
        routePath = c.returnHttp(0);

        latestNews();

    }
    public void latestNews()
    {
        DataTable dtNews = new DataTable();
        dtNews = c.getDataTable("SELECT TOP 2 newsId, newsDate, newsTitle, LEFT(newsInfo, 50) AS newsDetails FROM NewsData ORDER BY newsDate DESC");
        StringBuilder strMarkup = new StringBuilder();

        if (dtNews.Rows.Count > 0)
        {
            foreach (DataRow row in dtNews.Rows)
            {
                strMarkup.Append("<a href=\"" + routePath + "news" + "\" class=\"news-link\">" + row["newsTitle"].ToString() + "</a>");
                DateTime newsDate = Convert.ToDateTime(row["newsDate"]);
                strMarkup.Append("<span class=\"news-date display-block\">" + newsDate.Day + "-" + newsDate.Month + "-" + newsDate.Year + "</span>");
                strMarkup.Append("<p class=\"para-txt ptxt-color mrg_b_15\">" + row["newsDetails"].ToString() + "...</p>");
            }

            newsMarkup = strMarkup.ToString();

        }
        else
        {
            newsMarkup = string.Empty;
        }
           
    }
}
