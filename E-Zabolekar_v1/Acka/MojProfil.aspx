<%@ Page Title="Мој профил" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MojProfil.aspx.cs" Inherits="Acka.MojProfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     
    <div class="container" style="margin-top: 2%">

      <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Мој профил</h3>
            </div>
            <div class="panel-body">
     <asp:PlaceHolder ID="UserInfoemation" runat="server"></asp:PlaceHolder>
          </div>
      </div>

         </div>

</asp:Content>
