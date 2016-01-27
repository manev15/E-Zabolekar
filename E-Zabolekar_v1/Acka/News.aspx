<%@ Page Title="Новости" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Acka.News" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="padding-top:1%">
         <h2 class="section-heading">Новости</h2>
     <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource2">


        <ItemTemplate>
         
               <div class="span8">
    <h3><%# Eval("naslov") %></h3>
    <p><%# Eval("opis") %></p>
    <div>
        <span class="badge badge-success">Датум: <%# Eval("datum") %></span>
    </div> 
    <hr style="background:black">

        </ItemTemplate>
    </asp:Repeater>

    <asp:SqlDataSource
        ConnectionString="<%$ ConnectionStrings:mojaKonekcija %>"
        ID="SqlDataSource2" runat="server"
        SelectCommand="SELECT * FROM [Novosti] order by datum desc"></asp:SqlDataSource>

  </div>

    </asp:Content>