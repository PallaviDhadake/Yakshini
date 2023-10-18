<%@ Page Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="news" Title="News | Evenu Computers" %>
<%@ MasterType VirtualPath="~/MasterParent.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHParent" Runat="Server">
<!--Breadcrum starts-->
<div id="breadBox">
    <div class="pad_tb-15">
        <h1 class="HeadTitle cl-black">Latest News</h1>
        <ul class="breadcrum">
            <li><a href="#">Home</a></li>
            <li class="cl-themeBlue">&raquo;</li>
            <li class="color-gray">Latest News</li>
        </ul>
        <div class="float_clear"></div>
    </div>
</div>
<div class="spacer25"></div>
<!--Breadcrum Ends-->
<!--News Starts-->
<div id="allNews" runat="server">
    <div class="col70p">
        <%=newsData %>
    </div>
    <div class="sidebar-Offset">
    <div class="col30p">
       <a href="<%=Master.routePath + "services" %>"><img src="<%= Master.routePath + "images/evenu-services.png" %>" alt=""/></a>
    </div>
</div>
</div>

<%--<div class="sidebar-Offset">
    <div class="col30p">
        <div class="pad_lr-15">
            <a href="services.aspx"><img src="images/evenu-services.png" alt=""/></a>
        </div>
    </div>
</div>--%>
<div class="float_clear"></div>
<!--News Ends-->
<!--News Details Starts-->
<div id="detailNews" runat="server">
    <div class="col70p">
        <%=newsInfo %>
    </div>
    <div class="sidebar-Offset">
    <div class="col30p">
       <a href="<%=Master.routePath + "services" %>"><img src="<%= Master.routePath + "images/evenu-services.png" %>" alt=""/></a>
    </div>
</div>
</div>
<%--<div class="sidebar-Offset">
    <div class="col30p">
         <a href="services.aspx"><img src="images/evenu-services.png" alt=""/></a>
    </div>
</div>--%>
<div class="float_clear"></div>
<!--News Details Ends-->
</asp:Content>

