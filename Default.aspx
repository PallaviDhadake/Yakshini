<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title><%--Dell, Lenovo, HP, Toshiba Laptops and Desktops, Computer sales service in Sangli--%> - Yakshini Micro Systems</title>
    <meta name="msvalidate.01" content="B026CD126DEC2AF2DAF4FB17D7972F6E" />
    <meta content="IE=edge" http-equiv="X-UA-Compatible" /><meta http-equiv="Content-Type" content="text/html; charset=utf-8" /><meta name="viewport" content="width=device-width,initial-scale=1.0,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta name="description" content="Computer showroom Laptops, Desktops, Tablet pcs, computer peripherals and computer accessories in Sangli. Computer repairs and amc service.  Computer shop and service station is Sangli" />
    <meta name="keywords" content="Evenu Computers, Computer Sales, Computer Repairs, Desktop in Sangli, Laptop in Sangli, Harddisk in Sangli." />
    <link href="css/yakshini.css" rel="stylesheet" type="text/css" />
    <link href="css/yakshini.fonts.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" />
  
    <link href="css/responsiveslides.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="js/responsiveslides.js" type="text/javascript"></script>
    <script src="js/responsiveslides.min.js" type="text/javascript"></script>
     <style type="text/css">
        #slideshow {
		    position: relative;
			overflow:visible;
			height:475px;
        }
        .slideImg {
			top: 0;
			left: 0;
			width: 100%;
			max-width: 840px;
			height: auto;
			position: absolute;
		}
    </style>
    
    <script type="text/javascript">
    // You can also use "$(window).load(function() {"
    $(function () {

      // Slideshow 1
      $("#slideshow").responsiveSlides({
        maxwidth: 840,
        speed: 800
      });
    });
  </script>
</head>
<body>
    <div class="width100">
    <!--- Header Starts --->
        <div class="bg-white">
            <div class="column_1200">
               <div id="header">
                    <div class="pad_tb-15">
                        <%--<a href="#"><img src="images/evenu-logo.png" alt="" class="float_left" /></a>--%>
                        <a href="#"><img src="images/yakshini-logo.png" alt="Yakshini Micro Systems" class="float_left mrg_t_10" /></a>
                        <h2 class="contact_no">+91-9225821110</h2>
                        <div class="float_clear"></div>
                        <div class="social-links">
                            <a href="#" class="fb" title="Facebook"></a>
                            <a href="#" class="tweet" title="Twitter"></a>
                            <a href="#" class="lkd" title="Linkedin"></a>
                        </div>
                    </div>
               </div>
            </div>
        </div>
    <!--- Header Ends--->
    <!--- Navigation Starts--->
        <div id="navTop">
           <div class="column_1200">
                <ul class="nav">
                    <li><a href="<%=routePath %>">Home</a></li>
                    <li><a href="about-us">About Us</a></li>
                    <li><a href="product">Products</a></li>
                    <li><a href="services">Services</a></li>
                    <li><a href="news">News</a></li>
                    <li><a href="enquiry">Enquiry</a></li>
                    <li><a href="contact-us" class="noSep-Img">Contact Us</a></li>
                </ul>
           </div>
        </div>
         <!--- Navigation Ends--->
          <!--- Banner Starts--->
        <div id="banner">
            <div class="column_1200">
                <div class="col345">
                   <div class="ban-offset">
                        <h2 class="font32 fontUbuntuBold hd-Gray mrg_b_15">Providing Professional Computer Services</h2>
                        <p class="para-txt ptxt-color mrg_b_10">We provide all types of Desktop computers and Laptops with their all accessories sales and service under one roof.</p>
                        <a href="<%=routePath + "services" %>"  class="readMore">Read more...</a>
                   </div>
                </div>
                <div class="col840">
                   <ul class="rslides" id="slideshow">
                        <li><img src="images/banner/banner-1.jpg" alt="" class="slideImg"/></li>
                        <li><img src="images/banner/banner-2.jpg" alt="" class="slideImg"/></li>
                        <li><img src="images/banner/banner-3.jpg" alt="" class="slideImg"/></li>
                  </ul>
                </div>
                <div class="float_clear"></div>
            </div>
        </div>
         <!--- Banner Ends--->
          <!--- Message Starts--->
        <div class="bg-white">
            <div class="pad_tb_50">
                <div class="column_1200 txt_center">
                    <h2 class="font48 cl-black fontUbuntuRegular mrg_b_20">We'll diagnose and repair any problem</h2>
                    <p class="para-txt ptxt-color mrg_b_25">Evenu is formed with an expert team, who has wonderful skill of problem solving. Providing end to end perfect service and solution to our customers is our aim. Our quick hardware problems diagnose ability and fast solution finding expertise helps us to save valuable time of our customers.</p>
                    <div class="column_340">
                         <a href="<%=routePath + "about-us" %>" class="blue-Rmore">Read more about us</a>
                    </div>
                </div>
            </div>
        </div>
          <!--- Message Ends--->
          <!--- Services Starts--->
        <div id="bigBg">
            <div class="pad_tb_50">
                <div class="column_1200">
                    <h2 class="fontUbuntuBold font36 cl-white mrg_b_20 txt_center">Our Services</h2>
                <div class="services">
                    <div class="pad_15">
                        <img src="images/tag-computer.png" alt="" class="ourServiceImg"/>
                        <h3 class="font25 fontUbuntuBold cl-white mrg_b_15 txt_center">Computer</h3>
                        <p class="para-txt cl-white">All types of Desktop, All in one and Laptop sales and service under one roof. We always suggest the most relevant products to our clients as per their exact usage need and their available budget. We have wide range of Computers and Laptops for domestic and commercial usage.</p>
                    </div>
                </div>
                <div class="services">
                    <div class="pad_15">
                        <img src="images/tag-security.png" alt="" class="ourServiceImg"/>
                        <h3 class="font25 fontUbuntuBold cl-white mrg_b_15 txt_center">Security</h3>
                        <p class="para-txt cl-white">We sale the most intelligent security systems devices to our customers of various popular brands.  CCTV Cameras, Video door phones, Home alarm systems and many other devices to keep your home and office more safe and alert.</p>
                    </div>
                </div>
                <div class="services">
                    <div class="pad_15">
                        <img src="images/tag-software.png" alt="" class="ourServiceImg"/>
                        <h3 class="font25 fontUbuntuBold cl-white mrg_b_15 txt_center">Software</h3>
                        <p class="para-txt cl-white">We not only sale hardware but also provide intelligence to your computers and laptops. We have a software solution like Operating Systems, Antivirus, Microsoft Office, Tally ERP and many more. We too provide customized software solution for your businesses.</p>
                    </div>
                </div>
                <div class="float_clear"></div>
                </div>
                <div class="spacer20"></div>
                 <div class="column_340">
                      <a href="<%=routePath + "services" %>" class="white-Rmore" title="Computer Laptop Sales Repair services">See all services</a>
                 </div>
            </div>
        </div>
          <!--- Services Ends--->
          <!--- Latest news Starts--->
        <div class="bg-white">
            <div class="pad_tb_50">
                <div class="column_1200">
                    <div class="about">
                        <div class="pad_15">
                            <h3 class="font25 fontUbuntuRegular mrg_b_20 cl-themeBlue">About Us</h3>
                            <p class="para-txt ptxt-color mrg_b_10">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages Ipsum.</p>
                            <a href="<%=routePath + "about-us" %>" class="readMore" title="About profile of Evenu Computers">Read more...</a>
                        </div>
                    </div>
                    <div class="news">
                        <div class="pad_15">
                            <h3 class="font25 fontUbuntuRegular mrg_b_20 cl-themeBlue">Latest News</h3>
                            <%=latestNews %>
                            <%--<a href="news" class="news-link">Contrary to popular belief</a>
                            <span class="news-date display-block">18-3-15</span>
                            <p class="para-txt ptxt-color">Lorem ipsum dolor sit amet conse ctetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>--%>
                        </div>
                    </div>
                    <div class="float_clear"></div>
                </div>
            </div>
        </div>
         <!--- Latest news Ends--->
          <!--- Footer Starts--->
        <div id="footer">
            <div class="pad_tb-20">
                <div class="column_1200">
                    <ul class="fnav">
                        <li><a href="<%=routePath %>">Home</a></li>
                        <li><a href="about-us">About Us</a></li>
                        <li><a href="product">Products</a></li>
                        <li><a href="services">Services</a></li>
                        <li><a href="enquiry">Enquiry</a></li>
                        <li><a href="contact-us">Contact Us</a></li>
                        <li><a href="#">Sitemap</a></li>
                    </ul>
                   
                    <div class="addCol">
                        <h4 class="mrg_b_15 cl-white font25">Our Location</h4>
                        <span class="addData">
                            Near Zilla parishad,                            Opp.of Modak Hospital,                            Mangaldham shop. Center sangli-416416
                        </span>
                         <span class="copy-right">&copy; <%=currentYear %> | Yakshini Micro Systems</span>
                    </div>
                     <div class="float_clear"></div>
                </div>
            </div>
            <div class="bgdarkgrey" style="margin-bottom:0 !important">
                <div class="column_1200 txt_center">
                    <div class="pad_15">
                         <span class="cl-white small fontRegular">Website By <a href="http://www.intellect-systems.com" target="_blank" class="intellect" title="Website DesignS and Development Service By Intellect Systems">Intellect Systems</a></span>
                    </div>
                </div>
            </div>
        </div>
         <!--- Footer endss--->
    </div>
</body>

</html>
