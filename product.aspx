<%@ Page Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="product.aspx.cs" Inherits="product" Title="Dell, Lenovo, HP, Laptops and Desktops, CCTV Camera sales - Evenu Computers sangli" %>
<%@ MasterType VirtualPath="~/MasterParent.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHParent" Runat="Server">
<!--Breadcrum starts-->
<div id="breadBox">
    <div class="pad_tb-15">
        <h1 class="HeadTitle cl-black">Product</h1>
        <ul class="breadcrum">
            <%--<li><a href="#">Home</a></li>
            <li class="cl-themeBlue">»</li>
            <li class="color-gray">Product</li>--%>
            <%=bCrumb %>
        </ul>
        <div class="float_clear"></div>
    </div>
</div>
<!--Breadcrum Ends-->
<div class="spacer25"></div>
<!--Products Starts-->
<div class="offsetSidebar">
    <div class="col-330">
        <div class="themeBlue font20 cl-white pad_15">Categories</div>
        <%=navMenu %>
        <%--<ul class="catNav">
            <li><a href="#">Desktops & All in one</a></li>
            <li><a href="#">Laptops & Ultrabooks</a></li>
            <li><a href="#">Gadgets</a></li>
            <li><a href="#">Input Devices</a></li>
            <li><a href="#">Output Devices</a></li>
            <li><a href="#">Network Devices</a></li>
            <li><a href="#" class="Bborder-none">Storage Devices</a></li>
        </ul>--%>
        
    </div>
</div>
<div class="col-840">

<div id="SingleProduct" runat="server" visible="false">

<%=prodInfo %>
<%--<div class="productImg">
   <img src="images/computer_pc.jpg" alt="" width="100%" />
</div>
<div class="prod-wrapper">
    <h2 class="font25 fontUbuntuBold cl-black mrg_b_10">Dell Inspiron 15 3542 Notebook (4th Gen Ci3/ 4GB/ 500GB/ Win8.1)</h2>
   <h3 class="font16 cl-black">Company :<span class="color-gray mrg_l_10">Dell</span></h3>
   <div class="spacer15"></div>
   <div class="line_sp"></div>
   <div class="spacer15"></div>
   <div class="product-contList">
        <ul class="Prod-Listing">
            <li>Intel Core i3</li>
            <li>4 GB DDR3 RAM</li>
            <li>500 GB HDD</li>
            <li>Windows 8.1</li>
        </ul>
   </div>
   <div class="product-contPrice">
        <h3 class="font16 fontUbuntuBold color-gray">Warranty:<span class="font12 hd-Gray display-block mrg_t_5">1 Year Accidental Damages Service</span></h3>
        <div class="spacer20"></div>
        <h2 class="font25 color-gray fontUbuntuRegular">Rs.33,390<span class="font12 hd-Gray display-block mrg_t_5">Selling Price</span></h2>
   </div>
   <div class="float_clear"></div>
</div>--%>
<div class="prod-wrapper">
   <div class="spacer20"></div>
   <div class="themeBlue pad_10 font18 cl-white round3 mrg_b_15">Post Enquiry</div>
   <asp:TextBox ID="txtName" runat="server" CssClass="txt_regg border-color round3 prodTxt" placeholder="Name"></asp:TextBox>
   <asp:TextBox ID="txtEmail" runat="server" CssClass="txt_regg border-color round3 prodTxt" placeholder="Email"></asp:TextBox>
   <asp:TextBox ID="txtContact" runat="server" CssClass="txt_regg border-color round3 prodTxt" placeholder="Contact no."></asp:TextBox>
   <asp:TextBox ID="txtCity" runat="server" CssClass="txt_regg border-color round3 prodTxt" placeholder="City"></asp:TextBox>
   <asp:TextBox ID="txtMsg" runat="server" CssClass="txt_regg border-color round3 prodTxt nonResize" placeholder="Message" TextMode="MultiLine" Height="100px"></asp:TextBox>
   <div class="spacer20"></div>
   <%=errMsg %>
   <div class="spacer20"></div>
   <asp:Button ID="cmdSubmit" runat="server" Text="Submit" 
        CssClass="anchor themeBlue cl-white round3" onclick="cmdSubmit_Click"/>
</div> 
<div class="float_clear"></div>
</div>



<div id="AllProduct" runat="server" visible="false">
    <%--<div class="line_sp"></div>--%>
    
    
    
   <%=prodGrid %>
   
    <div class="float_clear"></div>
</div>
</div>
<div class="float_clear"></div>
<!--Products Ends-->
</asp:Content>

