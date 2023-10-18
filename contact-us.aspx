<%@ Page Language="C#" MasterPageFile="~/MasterParent.master" AutoEventWireup="true" CodeFile="contact-us.aspx.cs" Inherits="contact_us" Title="Contact location - Evenu Computers Sangli" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
     #map-canvas {width:100%; height: 350px; margin: 0; padding: 0;}
</style>
 <!-- Google Maps scripts -->
  <script type="text/javascript"
      src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCvO0AHfg1cuND1KXbw3t5xZr5p4PVrEk4">
    </script>
    <script type="text/javascript">
      function initialize() {
        var myLatlng = new google.maps.LatLng(16.854150, 74.579224);
        
        var mapOptions = {
        center: myLatlng,
        zoom: 15, scrollwheel: true, draggable: false,
        };
        
        var map = new google.maps.Map(document.getElementById("map-canvas"), mapOptions);
        
        // To add the marker to the map, use the 'map' property
        var marker = new google.maps.Marker({
        position: myLatlng,
        map: map,
        title:"Evenu Computers, Sangli"
        });
      
      }
      google.maps.event.addDomListener(window, 'load', initialize);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHParent" Runat="Server">
<!--Breadcrum starts-->
<div id="breadBox">
    <div class="pad_tb-15">
        <h1 class="HeadTitle cl-black">Contact Us</h1>
        <ul class="breadcrum">
            <li><a href="#">Home</a></li>
            <li class="cl-themeBlue">»</li>
            <li class="color-gray">Contact us</li>
        </ul>
        <div class="float_clear"></div>
    </div>
</div>
<!--Breadcrum Ends-->
<div class="spacer25"></div>
<!--Map starts-->
<div class="pad_15">
     <div id="map-canvas"></div>     
</div>
<!--Map Ends-->
<!--Contact Starts-->
<div class="address">
    <div class="pad_15">
        <h2 class="font30 cl-themeBlue fontUbuntuRegular mrg_b_15">Address</h2>
        <h3 class="font25 cl-themeBlue mrg_b_15">Evenu Computers</h3>
        <h4 class="add-Title1">Office Address 1:</h4>
        <p class="add-Subtitle mrg_b_20">E-Venu Computers, Plot no 139,<br />
            Vasantdada Industrial Estate,<br />
            Sangli-416416</p>
           
        <h4 class="add-Title2">Phone no. :</h4>
        <p class="add-Subtitle mrg_b_20">0233-311110</p>

        <h4 class="add-Title1">Office Address 2:</h4>
        <p class="add-Subtitle mrg_b_20">Shop No. 7, Mangaldham Shop Centre,<br />
            Opp. Modak Hospital, near Zilla Parishad,<br />
            Sangli-416416</p>
           
        <h4 class="add-Title2">Phone no. :</h4>
        <p class="add-Subtitle mrg_b_20">26604111, 9225821110</p>
        
        <%--<h4 class="add-Title">Mobile no. :</h4>
        <p class="add-Subtitle mrg_b_20">9860701110 / 9225821110</p>--%>
        
        <h4 class="add-Title1">Email Id :</h4>
            <p class="add-Subtitle">evenu.computers@gmail.com</p>
            <p class="add-Subtitle">Chetan@evenugroup.com </p>
            <p class="add-Subtitle mrg_b_20">support@evenugroup.com</p>

        <h4 class="add-Title1">Website :</h4>
        <p class="add-Subtitle">www.evenugroup.com</p>
    </div>
</div>
<div class="feedback">
     <div class="pad_15">
        <h2 class="font30 cl-themeBlue fontUbuntuRegular mrg_b_15">Feedback</h2>
        <div class="form-col270">
            <div class="pad_10">
                <label for="name" class="label cl-black">Name:<span class="greyStar">*</span></label>
                <asp:TextBox ID="txtName" runat="server" CssClass="textbox border-color round3 p100"></asp:TextBox>
            </div>
        </div>
        <div class="form-col270">
            <div class="pad_10">
                <label for="name" class="label cl-black">Email:<span class="greyStar">*</span></label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox border-color round3 p100"></asp:TextBox>
            </div>
        </div>
        <div class="form-col270">
            <div class="pad_10">
                <label for="name" class="label cl-black">Phone no.:<span class="greyStar">*</span></label>
                <asp:TextBox ID="txtPhone" runat="server" CssClass="textbox border-color round3 p100"></asp:TextBox>
            </div>
        </div>
        <div class="float_clear"></div>
        <div class="pad_10">
            <label for="name" class="label cl-black">Message:<span class="greyStar">*</span></label>
             <asp:TextBox ID="txtMsg" runat="server" CssClass="textbox border-color round3 msgp100" Height="200px" TextMode="MultiLine"></asp:TextBox>
             
            <div class="spacer25"></div>
            <%=errMsg %>
            <div class="spacer25"></div>
            <asp:Button ID="cmdClear" runat="server" Text="Clear" 
                CssClass="anchor themeGray cl-black round3 float_right" 
                onclick="cmdClear_Click"/>
            <asp:Button ID="cmdSend" runat="server" Text="Send" 
                CssClass="anchor themeBlue cl-white round3 float_right mrg_r_10" 
                onclick="cmdSend_Click"/>
            <div class="float_clear"></div>
        </div>
    </div>
</div>
<div class="float_clear"></div>
<!--Contact Ends-->
</asp:Content>

