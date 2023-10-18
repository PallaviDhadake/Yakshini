<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forgot-password.aspx.cs" Inherits="evenuadmin_forgot_password" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Forgot Password | Evenu Group</title>
     <link href="css/shahadmin.css" rel="stylesheet" type="text/css" />
    <link href="css/sd-fluid.css" rel="stylesheet" type="text/css" />
    <script src="js/shahadmin.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper_forgtpass">
             <a href="#"><img src="../images/evenu-logo.png" alt="" class="img_logo" /></a>
             <div class="clrFlt"></div>
             <div class="bg-white">
                <div class="for-pwd">
                    <label class="login-label">Email:</label>
                    <asp:TextBox ID="txtEmail"  CssClass="login-txtbox p100 round3 mar-B-24" runat="server"></asp:TextBox>
                    <a href="Default.aspx" class="forgt-pass">Back to Login</a>
                    <asp:Button ID="cmdPwd" runat="server" Text="Get Password" CssClass="achor round3 right themeBlue" onclick="cmdPwd_Click"/>
                    <div class="clrFlt"></div>
                </div>
             </div>
             <div class="spacer"></div>
                <%=errMsg %>
        </div>
    </form>
</body>
</html>
