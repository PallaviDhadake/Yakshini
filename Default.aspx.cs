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

public partial class _Default : System.Web.UI.Page
{
    public string routePath, latestNews, currentYear;
    public iClass c = new iClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        currentYear = DateTime.Now.Year.ToString();
        // Check and kill Admin session
        if (Request.QueryString["action"] != null)
        {
            if (Request.QueryString["action"] == "logout")
            {
                Session["evenuadmin"] = null;
            }
        }

        routePath = c.returnHttp(0);
        getNews();

    }
    public void getNews()
    {
        DataTable dtNews = new DataTable();
        dtNews = c.getDataTable("Select Top 1 newsId, newsDate, newsTitle, LEFT( newsInfo, 150) as newsData From NewsData Order By newsDate Desc");
        if (dtNews.Rows.Count > 0)
        {
            DataRow row = dtNews.Rows[0];

            StringBuilder strNews = new StringBuilder();

            DateTime newsDate = Convert.ToDateTime(row["newsDate"]);

            strNews.Append("<a href=\"" + routePath + "news\" class=\"news-link\">" + row["newsTitle"].ToString() + "</a>");
            strNews.Append("<span class=\"news-date display-block\">" + newsDate.Day + "-" + newsDate.Month + "-" + newsDate.Year + "</span>");
            strNews.Append("<p class=\"para-txt ptxt-color\">" + row["newsData"].ToString() + "...</p>");

            latestNews = strNews.ToString();
        }
        else
        {
            latestNews = string.Empty;
        }
        //
        //
        //

    }
}
