<%@ Page Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="services.aspx.cs" Inherits="services" Title="Branded computers laptops cctv camera antivirus sales and service - Evenu Computers Sangli" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHParent" Runat="Server">
<!--Breadcrum starts-->
<div id="breadBox">
    <div class="pad_tb-15">
        <h1 class="HeadTitle cl-black">Computer Sales Services</h1>
        <ul class="breadcrum">
            <li><a href="#">Home</a></li>
            <li class="cl-themeBlue">&raquo;</li>
            <li class="color-gray">Services</li>
        </ul>
        <div class="float_clear"></div>
    </div>
</div>
<!--Breadcrum Ends-->
<div class="spacer25"></div>
<!--Services Starts-->
<div class="col70p">
    <h2 class="font25 cl-black fontUbuntuRegular mrg_b_20">Computer Hardware Sales and Services</h2>
    <img src="upload/products/computer-pc1.jpg" alt="" class="serviceImg"/>
    <div class="service">
        <ul class="serviceList">
            <li>Totally computer repairing and servicing</li>
            <li>Network related solutions</li>
            <li>Annual maintenance contract/ Preventive maintenance services</li>
            <li>Repair and spare supply facility</li>
        </ul>
    </div>
    <div class="float_clear"></div>
    <div class="spacer30"></div>
    <h2 class="font25 cl-black fontUbuntuRegular mrg_b_20">Surveillance System &amp; All type of security</h2>
    <img src="upload/products/cctv-camera-evenu.jpg" alt="" class="serviceImg"/>
    <div class="service">
        <ul class="serviceList">
            <li>CCTV/ surveillance system installation and repair</li>
            <li>All other security solutions including Biometric time & attendance machine, Door Alarm System, Protector Fire Alarm System, Tel/GSM Auto dialler</li>
        </ul>
    </div>
    <div class="float_clear"></div>
    <div class="spacer30"></div>
    <h2 class="font25 cl-black fontUbuntuRegular mrg_b_20">Core Competencies</h2>
    <img src="upload/products/software-evenu.jpg" alt="" class="serviceImg"/>
    <div class="service">
        <ul class="serviceList">
            <li>Total Networking Solutions</li>
            <li>Tally Software Solutions</li>
            <li>Path-Sanstha / Society / Accounting / Inventory Software Solutions</li>
            <li>School Products / Hospital software’s / Industries software</li>
        </ul>
    </div>
    <div class="float_clear"></div>    
</div>
<div class="sidebar-Offset">
    <div class="col30p">
        <div class="pad_lr-15">
            <h2 class="sidebar-tag">Latest News</h2>
            <%=newsMarkup %>
            
        </div>
    </div>
</div>
<div class="float_clear"></div>
<!--Services Ends-->
</asp:Content>

