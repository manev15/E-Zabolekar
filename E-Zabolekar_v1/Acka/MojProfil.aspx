<%@ Page Title="Мој профил" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MojProfil.aspx.cs" Inherits="Acka.MojProfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<style>

         body {background: #EAEAEA;}
.user-details {position: relative; padding: 0;}
.user-details .user-image {position: relative;  z-index: 1; width: 100%; text-align: center;}
 .user-image img { clear: both; margin: auto; position: relative;}

.user-details .user-info-block {width: 100%; position: absolute; top: 55px; background: rgb(255, 255, 255); z-index: 0; padding-top: 35px;}
 .user-info-block .user-heading {width: 100%; text-align: center; margin: 10px 0 0;}
 .user-info-block .navigation {float: left; width: 100%; margin: 0; padding: 0; list-style: none; border-bottom: 1px solid #428BCA; border-top: 1px solid #428BCA;}
  .navigation li {float: left; margin: 0; padding: 0;}
   .navigation li a {padding: 20px 30px; float: left;}
   .navigation li.active a {background: #428BCA; color: #fff;}
 .user-info-block .user-body {float: left; padding: 5%; width: 90%;}
  .user-body .tab-content > div {float: left; width: 100%;}
  .user-body .tab-content h4 {width: 100%; margin: 10px 0; color: #333;}
         </style>
    <div class="container" style="margin-top: 2%">

      <div class="panel panel-primary" style="padding-bottom:30%">
            <div class="panel-heading">
                <h3 class="panel-title">Мој профил</h3>
            </div>
            <div class="panel-body">
                <div class="container" style="margin-left:33%">
	<div class="row">
		<div class="col-sm-4 col-md-4 user-details">
            <div class="user-image">
                <img src="images/ace.jpg" class="img-circle" style="width:100px;height:100px;">
            </div>
            <div class="user-info-block">
                <div class="user-heading">
                    <asp:PlaceHolder ID="userInfo" runat="server">

                    </asp:PlaceHolder>
                   
                </div>
                <ul class="navigation">
                    <li class="active">
                        <a data-toggle="tab" href="#information">
                            <span class="glyphicon glyphicon-user"></span>
                        </a>
                    </li>
                    <li>
                        <a data-toggle="tab" href="#settings">
                            <span class="glyphicon glyphicon-cog"></span>
                        </a>
                    </li>
                    <li>
                        <a data-toggle="tab" href="#email">
                            <span class="glyphicon glyphicon-envelope"></span>
                        </a>
                    </li>
                    <li>
                        <a data-toggle="tab" href="#events">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </a>
                    </li>
                </ul>
                <div class="user-body">
                    <div class="tab-content">
                        <div id="information" class="tab-pane active">
                            <h4>Account Information</h4>
                            <asp:PlaceHolder ID="AccountInformation" runat="server"></asp:PlaceHolder>

                        </div>
                        <div id="settings" class="tab-pane">
                            <h4>Settings</h4>
                        </div>
                        <div id="email" class="tab-pane">
                            <h4>Send Message</h4>
                        </div>
                        <div id="events" class="tab-pane">
                            <h4>Events</h4>
                        </div>
                    </div>
                </div>
            </div>
        </div>
	</div>
</div>
     <asp:PlaceHolder ID="UserInfoemation" runat="server" Visible="false"></asp:PlaceHolder>


          </div>

      </div>

        

         </div>

</asp:Content>
