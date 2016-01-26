<%@ Page Title="Заболекари" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Acka.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

  
   <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <h2 class="section-heading">Нашиот тим</h2>
                    <h3 class="section-subheading text-muted">Заболекаре со тапија</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <ul class="timeline">

                        <asp:PlaceHolder ID="dodadiZabolekari" runat="server"></asp:PlaceHolder>

                    </ul>
                </div>
            </div>
        </div>
</asp:Content>
