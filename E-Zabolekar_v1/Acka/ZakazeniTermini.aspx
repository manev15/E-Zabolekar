<%@ Page Title="Закажени термини" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ZakazeniTermini.aspx.cs" Inherits="Acka.ZakazeniTermini" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="margin-top: 2%">

        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Закажени термини</h3>
            </div>
            <div class="panel-body" style="margin-left:25%">
                <div style="margin-left:-34%">
                 <asp:Label ID="poraka" runat="server" Font-Size="Larger"></asp:Label>
                </div>
                <asp:PlaceHolder ID="zakazanitermini" runat="server"></asp:PlaceHolder>

               

            </div>
        </div>

    </div>

</asp:Content>
