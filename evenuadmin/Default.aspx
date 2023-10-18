<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="evenuadmin_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login form | Evenu Group</title>
    <link href="css/shahadmin.css" rel="stylesheet" type="text/css" />
    <link href="css/sd-fluid.css" rel="stylesheet" type="text/css" />
    <script src="js/shahadmin.js" type="text/javascript"></script>
</head>

<body class="bg-white">
    <form id="form1" runat="server">
        <div id="wrapper_login">
            <a href="#"><img src="../images/evenu-logo.png" alt="" class="img_logo" /></a>
            <div class="clrFlt"></div>
            <div class="login">
                <label class="login-label">UserName:</label>
                <asp:TextBox ID="txtUsername"  CssClass="login-txtbox p100 round3 mar-B-15" runat="server"></asp:TextBox>

                <label class="login-label">Password:</label>
                <asp:TextBox ID="txtPassword"  CssClass="login-txtbox p100 round3 mar-B-10" TextMode="Password" runat="server"></asp:TextBox>
                 <asp:ImageButton ID="cmdLogin" runat="server" CssClass="login-btn" 
                    ImageUrl="images/log-in.png" onclick="cmdLogin_Click" />
                <a href="forgot-password.aspx" class="forgt-pass">Forgot Password?</a>
                <div class="clrFlt"></div>
            </div>
            <div class="spacer"></div>
            <%=errMsg %>
        </div>
    </form>
</body>
</html>
