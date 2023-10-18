using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Text;
using System.Net;
using System.Net.Security;
using System.Net.Mail;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for iClass
/// </summary>
public class iClass
{
	public iClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string openConnection()
    {
        string strConnection = null;
        strConnection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Yakshini"].ConnectionString;
        return strConnection;
    }
    /// <summary>
    /// Executes a SQL Query
    /// </summary>
    /// <param name="strQuery">SQL Query as String</param>
    public void ExecuteQuery(string strQuery)
    {
        try
        {
            SqlConnection con = new SqlConnection(openConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            con = null;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    /// <summary>
    /// Used to check if record exists or not
    /// </summary>
    /// <param name="strQuery">SQL Query as string</param>
    /// <returns>True/False</returns>
    public bool isRecordExist(string strQuery)
    {
        try
        {

            bool rValue = false;
            SqlConnection con = new SqlConnection(openConnection());
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = default(SqlDataReader);

            cmd.CommandText = strQuery;
            dr = cmd.ExecuteReader();

            rValue = dr.HasRows;
            dr.Close();
            cmd.Dispose();
            con.Close();
            con = null;

            return rValue;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    /// <summary>
    /// Gets next Id in column(Integer)
    /// </summary>
    /// <param name="tableName">Name of Table in Databse</param>
    /// <param name="fieldName">Name of Column</param>
    /// <returns>Next value in column</returns>
    public int nextId(string tableName, string fieldName)
    {
        try
        {
            int retValue = 1;
            SqlConnection con = new SqlConnection(openConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr = default(SqlDataReader);
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select MAX(" + fieldName + ") as maxNo From " + tableName;
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if ((dr["maxNo"]) != System.DBNull.Value)
                    {
                        retValue = Convert.ToInt32(dr["maxNo"]) + 1;
                    }
                    else
                    {
                        retValue = 1;
                    }
                }
            }
            else
            {
                retValue = 1;
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            con = null;
            return retValue;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Used to get single value from databse table
    /// </summary>
    /// <param name="tableName">Name of Database Table</param>
    /// <param name="fieldName">Naem of Column</param>
    /// <param name="whereCon">Where Condition</param>
    /// <returns>Value as object</returns>
    public object getReqData(string tableName, string fieldName, string whereCon)
    {
        try
        {
            object retValue = null;
            SqlConnection con = new SqlConnection(openConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = default(SqlDataReader);
            cmd.CommandText = whereCon == "" ? "Select " + fieldName + " as colName From " + tableName : "Select " + fieldName + " as colName From " + tableName + " Where " + whereCon;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["colName"] == DBNull.Value)
                {
                    retValue = null;
                }
                else
                {
                    retValue = dr["colName"];
                }

            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            con = null;
            return retValue;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Used to get aggregate value of single column
    /// </summary>
    /// <param name="strQuery">SQL Query as string</param>
    /// <returns>value</returns>
    public long returnAggregate(string strQuery)
    {
        try
        {
            long rValue = 0;
            SqlConnection con = new SqlConnection(openConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;

            object result = cmd.ExecuteScalar();

            if (result.GetType() != typeof(DBNull))
            {
                rValue = Convert.ToInt32(result);
            }
            else
            {
                rValue = 0;

            }

            con.Close();
            con = null;
            cmd.Dispose();
            return rValue;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Used to display error Messagge on Client Side
    /// </summary>
    /// <param name="errType">Error Type as byte 1 for Succes/2 for Warning/3 for Error</param>
    /// <param name="errMsgStr">Message to display</param>
    /// <returns>Markup as string</returns>
    public string errNotification(byte errType, string errMsgStr)
    {
        try
        {
            string rValue = "";

            switch (errType)
            {
                case 1:
                    rValue = "<span class='success'><b>Success:</b> " + errMsgStr + "</span>";
                    break;
                case 2:
                    rValue = "<span class='warning'><b>Warning:</b> " + errMsgStr + "</span>";
                    break;
                case 3:
                    rValue = "<span class='error'><b>Error:</b> " + errMsgStr + "</span>";
                    break;
            }

            return rValue;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Optimizes the uploaded image
    /// </summary>
    /// <param name="imgName">Image Name</param>
    /// <param name="srcPath">Path of source file</param>
    /// <param name="destPath">Path where u want to save the optimized file</param>
    /// <param name="widthLimit">Target width limit</param>
    /// <param name="imageProportion">Either to maintain proportion of Width and height</param>
    public void imageOptimizer(string imgName, string srcPath, string destPath, float widthLimit, bool imageProportion)
    {
        try
        {
            string src = HttpContext.Current.Server.MapPath(srcPath + imgName);
            FileStream fs = new FileStream(src, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            System.Drawing.Image image = System.Drawing.Image.FromStream(fs, true, false);

            float srcWidth = image.Width;
            float srcHeight = image.Height;
            image.Dispose();
            fs.Close();

            float percentWidth = 0;
            float percentHeight = 0;
            float thumbWidth = widthLimit;
            float thumbHeight;

            if (imageProportion == true)
            {
                if (srcWidth >= srcHeight)
                {
                    thumbHeight = 0;
                }
                else
                {
                    thumbWidth = 0;
                    thumbHeight = widthLimit;
                    goto heightProcess;
                }
            }


            if (srcWidth > widthLimit)
            {
                //float tvar1 = (100 * widthLimit) / srcWidth;
                //percentWidth = Convert.ToInt32( Math.Round(tvar1));
                ////percentWidth = Convert.ToInt32( Math.Round(percentWidth));
                //thumbWidth = (srcWidth * percentWidth) / 100;

                //New
                percentWidth = (100 * widthLimit) / srcWidth;
                thumbWidth = (srcWidth * percentWidth) / 100;



                //float tvar2 = (thumbWidth * srcHeight) / srcWidth;
                //thumbHeight = Convert.ToInt32(Math.Round(tvar2));
                thumbHeight = (thumbWidth * srcHeight) / srcWidth;

                //thumbprocess
                thumbnailProcessor(imgName, srcPath, destPath, Convert.ToInt32(thumbWidth), Convert.ToInt32(thumbHeight));
            }
            else
            {

                thumbWidth = srcWidth;
                thumbHeight = srcHeight;
                //thumbprocess
                thumbnailProcessor(imgName, srcPath, destPath, Convert.ToInt32(thumbWidth), Convert.ToInt32(thumbHeight));
            }
            return;



        heightProcess:
            if (srcHeight > widthLimit)
            {
                //float tvar3 = (100 * widthLimit) / srcHeight;
                //percentHeight = Convert.ToInt32( Math.Round( tvar3 ));
                percentHeight = (100 * widthLimit) / srcHeight;

                thumbHeight = (srcHeight * percentHeight) / 100;

                //float tvar4 = (thumbHeight * srcWidth) / srcHeight;
                //thumbWidth = Convert.ToInt32( Math.Round(tvar4) );

                thumbWidth = (thumbHeight * srcWidth) / srcHeight;

                //thumbnailprocessor
                thumbnailProcessor(imgName, srcPath, destPath, Convert.ToInt32(thumbWidth), Convert.ToInt32(thumbHeight));
            }
            else
            {
                thumbWidth = srcWidth;
                thumbHeight = srcHeight;

                //thumbnailprocessor
                thumbnailProcessor(imgName, srcPath, destPath, Convert.ToInt32(thumbWidth), Convert.ToInt32(thumbHeight));
            }
            return;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void thumbnailProcessor(string imgName, string testPath, string deployImgPath, int thumbWidth, int thumbHeight)
    {
        try
        {
            //string sImageName = imgName;

            // ORIGINAL WIDTH AND HEIGHT.
            //Bitmap bitmap = new Bitmap(Server.MapPath("~/" + Path.GetFileName(hpf.FileName)));
            Bitmap bitmap = new Bitmap(HttpContext.Current.Server.MapPath(testPath + imgName));
            string extn = Path.GetExtension(testPath + imgName);

            int iwidth = thumbWidth;
            int iheight = thumbHeight;

            bitmap.Dispose();

            // CREATE AN IMAGE OBJECT USING ORIGINAL WIDTH AND HEIGHT.
            // ALSO DEFINE A PIXEL FORMAT (FOR RICH RGB COLOR).

            System.Drawing.Image objOptImage = new System.Drawing.Bitmap(iwidth, iheight, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);

            // GET THE ORIGINAL IMAGE.
            using (System.Drawing.Image objImg = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath(testPath + imgName)))
            {

                // RE-DRAW THE IMAGE USING THE NEWLY OBTAINED PIXEL FORMAT.
                using (System.Drawing.Graphics oGraphic = System.Drawing.Graphics.FromImage(objOptImage))
                {
                    var _1 = oGraphic;
                    System.Drawing.Rectangle oRectangle = new System.Drawing.Rectangle(0, 0, iwidth, iheight);

                    _1.DrawImage(objImg, oRectangle);
                }

                // SAVE THE OPTIMIZED IMAGE.
                switch (extn.ToLower())
                {
                    case ".jpg":

                        objOptImage.Save(HttpContext.Current.Server.MapPath(deployImgPath + imgName), System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case ".jpeg":
                        objOptImage.Save(HttpContext.Current.Server.MapPath(deployImgPath + imgName), System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case ".png":
                        objOptImage.Save(HttpContext.Current.Server.MapPath(deployImgPath + imgName), System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    case ".gif":
                        objOptImage.Save(HttpContext.Current.Server.MapPath(deployImgPath + imgName), System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }

                objImg.Dispose();

            }

            objOptImage.Dispose();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Crops the image & maintains the center
    /// </summary>
    /// <param name="imageName">Name of Image</param>
    /// <param name="srcPath">Source path of target image</param>
    /// <param name="destPath">Path where you want to save the cropeed image</param>
    /// <param name="targetW">Target width</param>
    /// <param name="targetH">Target height</param>
    public void CenterCropImage(string imageName, string srcPath, string destPath, int targetW, int targetH)
    {
        try
        {
            string src = HttpContext.Current.Server.MapPath(srcPath + imageName);
            string dest = HttpContext.Current.Server.MapPath(destPath + imageName);

            FileStream fsCrop = new FileStream(src, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            System.Drawing.Image imgPhoto = System.Drawing.Image.FromStream(fsCrop, true, false);

            int targetX = (imgPhoto.Width - targetW) / 2;
            int targetY = (imgPhoto.Height - targetH) / 2;

            System.Drawing.Bitmap bmPhoto = new Bitmap(targetW, targetH, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            bmPhoto.SetResolution(72, 72);
            System.Drawing.Graphics grPhoto = System.Drawing.Graphics.FromImage(bmPhoto);

            grPhoto.SmoothingMode = SmoothingMode.AntiAlias;
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality;

            grPhoto.Clear(System.Drawing.Color.FromArgb(255, 255, 255, 255));
            grPhoto.DrawImage(imgPhoto, new System.Drawing.Rectangle(0, 0, targetW, targetH), targetX, targetY, targetW, targetH, System.Drawing.GraphicsUnit.Pixel);

            EncoderParameters ep = new EncoderParameters(1);
            ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, Convert.ToInt64(100));

            imgPhoto.Dispose();
            grPhoto.Dispose();
            grPhoto = null;
            bmPhoto.Save(dest);
            bmPhoto.Dispose();
            bmPhoto = null;

            fsCrop.Dispose();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Sends an Email
    /// </summary>
    /// <param name="fromEmail">Sender Email Id</param>
    /// <param name="toEmail">Receipant Email Id</param>
    /// <param name="msgData">Message Details</param>
    /// <param name="mailSubject">Subject Line</param>
    /// <param name="bccEmail">BCC Email Id</param>
    /// <param name="isHtmlEmail">True/False</param>
    /// <param name="attachStr">path of attachment file</param>
    /// <param name="documentName">Name of document</param>
    public void sendMail(string fromEmail, string toEmail, string msgData, string mailSubject, string bccEmail, bool isHtmlEmail, string attachStr, string documentName)
    {
        try
        {
            MailMessage msg = new MailMessage();
            string totalMessage;
            msg.From = new MailAddress(fromEmail, "Evenu Group");
            msg.To.Add(toEmail);
            msg.Subject = mailSubject;

            totalMessage = msgData + Environment.NewLine + Environment.NewLine + "Evenu Group, Sangli";

            if (bccEmail != "")
            {
                msg.Bcc.Add(bccEmail);
            }

            msg.Body = (totalMessage.ToString()).Trim();
            msg.IsBodyHtml = isHtmlEmail;

            if (attachStr != "")
            {
                FileStream fs = new FileStream(attachStr, FileMode.Open, FileAccess.Read);
                Attachment file = new Attachment(fs, documentName);
                msg.Attachments.Add(file);
            }

            SmtpClient smtp = new SmtpClient("smtp.zoho.com", 587);
            smtp.Credentials = new NetworkCredential("info@evenugroup.com", "iamEvenu@2015");
            smtp.EnableSsl = true;

            //SmtpClient smtp = new SmtpClient("mail.evenugroup.com", 25);
            //smtp.Credentials = new NetworkCredential("info@evenugroup.com", "evenu@2015");

            smtp.Send(msg);
            msg = null;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public bool EmailAddressCheck(string emailAddress)
    {
        try
        {
            bool rValue = false;
            string pattern = "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$";
            Match emailAddressMatch = Regex.Match(emailAddress, pattern);


            if (emailAddressMatch.Success)
            {
                rValue = true;
            }
            else
            {
                rValue = false;
            }

            return rValue;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public string Encryptdata(string originalStr)
    {
        try
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[originalStr.Length];
            encode = Encoding.UTF8.GetBytes(originalStr);
            strmsg = Convert.ToBase64String(encode);
            strmsg = strmsg.Replace("=", "");
            return strmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable getDataTable(string strQuery)
    {
        try
        {
            SqlConnection con = new SqlConnection(openConnection());

            SqlDataAdapter da = new SqlDataAdapter(strQuery, con);
            DataTable dt = new DataTable();

            da.Fill(dt);

            con.Close();
            con = null;

            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public string returnHttp(byte reqType)
    {
        try
        {
            string rValue = null;
            string domain = "http://" + HttpContext.Current.Request.ServerVariables["HTTP_HOST"];
            string localFolder;
                //= domain.IndexOf("localhost") == 0 ? "/" : "/Shah-Developers/";
            if (domain.Contains("localhost") == true)
            {
                localFolder = "/";
                //localFolder = "/EVENU/";
            }
            else
            {
                localFolder = "/";
            }

            switch (reqType)
            {
                case 0:
                    rValue = domain + localFolder;
                    break;
                case 1:
                    rValue = domain + localFolder + "css";
                    break;
                case 2:
                    rValue = domain + localFolder + "js";
                    break;
            }

            return rValue;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool isDate(string date)
    {
        try
        {
            DateTime dt = DateTime.Parse(date);
            return true;
        }
        catch
        {
            return false;
        }
    }
    /// <summary>
    /// Used to fill DropDownList
    /// </summary>
    /// <param name="fieldStr">Display Contents(Column Name)</param>
    /// <param name="fieldVal">Value Content(Column Name)</param>
    /// <param name="tableName">Database Table Name</param>
    /// <param name="whereCond">Specific Condition (SQL Where Condition)</param>
    /// <param name="myComboBox">Name of DropDownList</param>
    public void fillComboBox(string fieldStr, string fieldVal, string tableName, string whereCond, DropDownList myComboBox)
    {
        try
        {
            SqlConnection con = new SqlConnection(openConnection());
            string strSql = "";
            if (whereCond == "")
            {
                strSql = "SELECT " + fieldStr + ", " + fieldVal + " From " + tableName;
            }
            else
            {
                strSql = "SELECT " + fieldStr + ", " + fieldVal + " From " + tableName + " Where " + whereCond;
            }
            SqlDataAdapter da = new SqlDataAdapter(strSql, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "myCombo");
            myComboBox.DataSource = ds.Tables[0];
            myComboBox.DataTextField = ds.Tables[0].Columns[fieldStr].ColumnName.ToString();
            myComboBox.DataValueField = ds.Tables[0].Columns[fieldVal].ColumnName.ToString();
            myComboBox.DataBind();

            myComboBox.Items.Insert(0, "<-Select->");
            myComboBox.Items[0].Value = "0";

            con.Close();
            con = null;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public string projectSidebar()
    {
        string rValue;
        DataTable dtSideProjects = new DataTable();
        dtSideProjects = getDataTable("Select Top 2 a.projId, a.projTitle, a.projPhoto, a.cityName, b.proTypeName From ProjectData a Inner Join ProjectTypes b On a.projCategory=b.proTypeId Where delMark=0 Order By projDate Desc");
        StringBuilder strSProj = new StringBuilder();
        string routePath = returnHttp(0);
        int i = 1;
        string url;
        foreach (DataRow row in dtSideProjects.Rows)
        {
            url = routePath + "project-listings/" + row["proTypeName"].ToString().ToLower().Replace(" ", "-") + "-in-" + row["cityName"].ToString().ToLower().Replace(" ", "-") + "-" + row["projTitle"].ToString().ToLower().Replace(" ", "-") + "-" + row["projId"].ToString();
            strSProj.Append("<a href=\"" + url + "\"><img src=\"" + routePath + "upload/projects/thumb/" + row["projPhoto"].ToString() + "\" alt=\"" + row["projTitle"].ToString() + " - Shah Developers \" class=\"mrg_b_20 proj-img\"/></a>");
            strSProj.Append("<a href=\"" + url + "\" class=\"sidebar-anchor\">" + row["projTitle"].ToString() + "</a>");
            strSProj.Append("<span class=\"sidebar-subTitle\">" + row["cityName"].ToString() + "</span>");
            if (i < 2)
            {
                strSProj.Append("<div class=\"sidebar-line\"></div>");
                strSProj.Append("<div class=\"space20\"></div>");
            }
            i++;
        }
        rValue = strSProj.ToString();
        return rValue;
    }

    //Reduced & Optimize Image File size keeping its Height & Width as it is.

    public void ResizeMySize(string requestImgPath, string imgFileName, string dstnPath)
    {
                string sImageName = imgFileName;
                       
                // ORIGINAL WIDTH AND HEIGHT.
                //Bitmap bitmap = new Bitmap(Server.MapPath("~/" + Path.GetFileName(hpf.FileName)));
                Bitmap bitmap = new Bitmap(HttpContext.Current.Server.MapPath(requestImgPath + imgFileName));
                string extn = Path.GetExtension(requestImgPath + imgFileName);

                int iwidth = bitmap.Width;
                int iheight = bitmap.Height;

                iwidth = iwidth / 3;
                iheight = iheight / 3;
                             
                bitmap.Dispose();
                
                // CREATE AN IMAGE OBJECT USING ORIGINAL WIDTH AND HEIGHT.
                // ALSO DEFINE A PIXEL FORMAT (FOR RICH RGB COLOR).

                System.Drawing.Image objOptImage = new System.Drawing.Bitmap(iwidth, iheight, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);

                // GET THE ORIGINAL IMAGE.
                using (System.Drawing.Image objImg = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath(requestImgPath + sImageName)))
                {

                    // RE-DRAW THE IMAGE USING THE NEWLY OBTAINED PIXEL FORMAT.
                    using (System.Drawing.Graphics oGraphic = System.Drawing.Graphics.FromImage(objOptImage))
                    {
                        var _1 = oGraphic;
                        System.Drawing.Rectangle oRectangle = new System.Drawing.Rectangle(0, 0, iwidth, iheight);

                        _1.DrawImage(objImg, oRectangle);
                    }

                    // SAVE THE OPTIMIZED IMAGE.
                    switch (extn.ToLower())
                    {
                        case ".jpg":
                            objOptImage.Save(HttpContext.Current.Server.MapPath(dstnPath + sImageName), System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case ".jpeg":
                            objOptImage.Save(HttpContext.Current.Server.MapPath(dstnPath + sImageName), System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case ".png":
                            objOptImage.Save(HttpContext.Current.Server.MapPath(dstnPath + sImageName), System.Drawing.Imaging.ImageFormat.Png);
                            break;
                        case ".gif":
                            objOptImage.Save(HttpContext.Current.Server.MapPath(dstnPath + sImageName), System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                    }
                    
                    objImg.Dispose();
                    
                }
                        
                objOptImage.Dispose();
    }

    //CROP IMAGES
    public void CropImage(int Width, int Height, string imgName, string sourceFilePath, string saveFilePath)
    {
        // variable for percentage resize 
        float percentageResize = 0;
        float percentageResizeW = 0;
        float percentageResizeH = 0;

        // variables for the dimension of source and cropped image 
        int sourceX = 0;
        int sourceY = 0;
        int destX = 0;
        int destY = 0;

        // Create a bitmap object file from source file 
        Bitmap sourceImage = new Bitmap(HttpContext.Current.Server.MapPath(sourceFilePath + imgName));

        // Set the source dimension to the variables 
        int sourceWidth = sourceImage.Width;
        int sourceHeight = sourceImage.Height;

        // Calculate the percentage resize 
        percentageResizeW = ((float)Width / (float)sourceWidth);
        percentageResizeH = ((float)Height / (float)sourceHeight);

        // Checking the resize percentage 
        if (percentageResizeH < percentageResizeW)
        {
            percentageResize = percentageResizeW;
            destY = System.Convert.ToInt16((Height - (sourceHeight * percentageResize)) / 2);
        }
        else
        {
            percentageResize = percentageResizeH;
            destX = System.Convert.ToInt16((Width - (sourceWidth * percentageResize)) / 2);
        }

        // Set the new cropped percentage image
        int destWidth = (int)Math.Round(sourceWidth * percentageResize);
        int destHeight = (int)Math.Round(sourceHeight * percentageResize);

        // Create the image object 
        using (Bitmap objBitmap = new Bitmap(Width, Height))
        {
            objBitmap.SetResolution(sourceImage.HorizontalResolution, sourceImage.VerticalResolution);
            using (Graphics objGraphics = Graphics.FromImage(objBitmap))
            {
                // Set the graphic format for better result cropping 
                objGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                objGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                objGraphics.DrawImage(sourceImage, new Rectangle(destX, destY, destWidth, destHeight), new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight), GraphicsUnit.Pixel);

                // Save the file path, note we use png format to support png file 
                objBitmap.Save(HttpContext.Current.Server.MapPath(saveFilePath + imgName), ImageFormat.Jpeg);
            }
        }
    }

    public string urlGenerator(string oldUrl)
    {
        try
        {
            if (oldUrl.Contains("$") == true)
            {
                oldUrl = oldUrl.Replace("$", "");
            }
            if (oldUrl.Contains(" ") == true)
            {
                oldUrl = oldUrl.Replace(" ", "-");
            }
            if (oldUrl.Contains("+") == true)
            {
                oldUrl = oldUrl.Replace("+", "");
            }
            if (oldUrl.Contains(";") == true)
            {
                oldUrl = oldUrl.Replace(";", "");
            }
            if (oldUrl.Contains("=") == true)
            {
                oldUrl = oldUrl.Replace("=", "");
            }
            if (oldUrl.Contains("?") == true)
            {
                oldUrl = oldUrl.Replace("?", "");
            }
            if (oldUrl.Contains("@") == true)
            {
                oldUrl = oldUrl.Replace("@%", "");
            }
            if (oldUrl.Contains("<") == true)
            {
                oldUrl = oldUrl.Replace("<", "");
            }
            if (oldUrl.Contains('"') == true)
            {
                oldUrl = oldUrl.Replace('"', '-');
            }
            if (oldUrl.Contains(">") == true)
            {
                oldUrl = oldUrl.Replace(">", "");
            }
            if (oldUrl.Contains("#") == true)
            {
                oldUrl = oldUrl.Replace("#", "");
            }
            if (oldUrl.Contains("{") == true)
            {
                oldUrl = oldUrl.Replace("{", "");
            }
            if (oldUrl.Contains("}") == true)
            {
                oldUrl = oldUrl.Replace("}", "");
            }
            if (oldUrl.Contains("|") == true)
            {
                oldUrl = oldUrl.Replace("|", "");
            }
            if (oldUrl.Contains("\\") == true)
            {
                oldUrl = oldUrl.Replace("\\", "");
            }
            if (oldUrl.Contains("^") == true)
            {
                oldUrl = oldUrl.Replace("^", "");
            }
            if (oldUrl.Contains("~") == true)
            {
                oldUrl = oldUrl.Replace("~", "");
            }
            if (oldUrl.Contains("[") == true)
            {
                oldUrl = oldUrl.Replace("[", "");
            } if (oldUrl.Contains("]") == true)
            {
                oldUrl = oldUrl.Replace("]", "");
            } if (oldUrl.Contains("`") == true)
            {
                oldUrl = oldUrl.Replace("`", "");
            }
            if (oldUrl.Contains("%") == true)
            {
                oldUrl = oldUrl.Replace("%", "percent");
            }
            if (oldUrl.Contains("&") == true)
            {
                oldUrl = oldUrl.Replace("&", "and");
            }
            if (oldUrl.Contains(":") == true)
            {
                oldUrl = oldUrl.Replace(":", "");
            }
            if (oldUrl.Contains(".") == true)
            {
                oldUrl = oldUrl.Replace(".", "");
            }
            if (oldUrl.Contains(",") == true)
            {
                oldUrl = oldUrl.Replace(",", "-");
            }
            if (oldUrl.Contains("/") == true)
            {
                oldUrl = oldUrl.Replace("/", "");
            }
            if (oldUrl.Contains(".") == true)
            {
                oldUrl = oldUrl.Replace(".", "");
            }
            if (oldUrl.Contains("--") == true)
            {
                oldUrl = oldUrl.Replace("--", "-");
            }
            if (oldUrl.EndsWith("-") == true)
            {
                oldUrl = oldUrl.Substring(0, oldUrl.Length - 1);
            }
            //if (oldUrl.Contains("/") == true)
            //{
            //    oldUrl = oldUrl.Replace("/", "");
            //}
            return oldUrl;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }



}
