<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="newsAdmin.aspx.cs" Inherits="Acka.newsAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    
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
