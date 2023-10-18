<%@ Page Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="enquiry.aspx.cs" Inherits="enquiry" Title="Buy Enquiry for Computers Laptops and CCTV Camera - Evenu Computers Sangli" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHParent" Runat="Server">
<!--Breadcrum starts-->
<div id="breadBox">
    <div class="pad_tb-15">
        <h1 class="HeadTitle cl-black">Enquiry</h1>
        <ul class="breadcrum">
            <li><a href="#">Home</a></li>
            <li class="cl-themeBlue">»</li>
            <li class="color-gray">Enquiry</li>
        </ul>
        <div class="float_clear"></div>
    </div>
</div>
<div class="spacer25"></div>
<!--Breadcrum Ends-->
<!--Enquiry Starts-->
<div class="col70p">
    <label for="name" class="label cl-black">Enquiry for:</label>
    <asp:DropDownList ID="ddlEnqFor" runat="server" CssClass="cmb_regg drpList border-color round3">
        <asp:ListItem Value="0"><-Select-></asp:ListItem>
        <asp:ListItem Value="1">Computer</asp:ListItem>
        <asp:ListItem Value="2">Laptop</asp:ListItem>
        <asp:ListItem Value="3">Tablet</asp:ListItem>
        <asp:ListItem Value="4">Other</asp:ListItem>
    </asp:DropDownList>
    
    
    <label for="name" class="label cl-black">Name:<span class="greyStar">*</span></label>
    <asp:TextBox ID="txtName" runat="server" CssClass="txt_regg border-color round3 p100"></asp:TextBox>
    
    <label for="name" class="label cl-black">Email:<span class="greyStar">*</span></label>
    <asp:TextBox ID="txtEmail" runat="server" CssClass="txt_regg border-color round3 p100"></asp:TextBox>
    
    <label for="name" class="label cl-black">Contact no.:<span class="greyStar">*</span></label>
    <asp:TextBox ID="txtContact" runat="server" CssClass="txt_regg border-color round3 p100"></asp:TextBox>
    
    <label for="name" class="label cl-black">City:<span class="greyStar">*</span></label>
    <asp:TextBox ID="txtCity" runat="server" CssClass="txt_regg border-color round3 p100"></asp:TextBox>
    
    <label for="name" class="label cl-black">Message:<span class="greyStar">*</span></label>
    <asp:TextBox ID="txtMsg" runat="server" CssClass="txt_regg border-color round3 p100" Height="150px" TextMode="MultiLine"></asp:TextBox>
    
     <div class="spacer25"></div>
     <%=errMsg %>
     <div class="spacer25"></div>
     <asp:Button ID="cmdSubmit" runat="server" Text="Submit" 
        CssClass="anchor themeBlue cl-white round3" onclick="cmdSubmit_Click"/>
</div>
<div class="sidebar-Offset">
    <div class="col30p">
        <a href="services"><img src="images/evenu-services.png" alt=""/></a>
    </div>
</div>
<div class="float_clear"></div>
<!--Enquiry Ends-->
</asp:Content>

