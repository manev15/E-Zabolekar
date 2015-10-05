﻿<%@ Page Title="ZakaziPregled" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ZakaziPregled.aspx.cs" Inherits="Acka.ZakaziPregled" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container" style="margin-top: 2%">




        <%--          <asp:PlaceHolder ID="imgHolder" runat="server"></asp:PlaceHolder>


        <ul class="dropdown-menu" aria-labelledby="dropdownMenu4">
  <li><a href="#">Regular link</a></li>
  <li><a href="#">Disabled link</a></li>
  <li><a href="#">Another link</a></li>
</ul>--%>


        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Информации за прегледот</h3>
            </div>
            <div class="panel-body">
                <table class="nav-justified">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Избери заболекар: "></asp:Label>
                            <asp:DropDownList ID="zabolekari" runat="server"></asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="container">
                                <!-- Trigger the modal with a button -->
                                <button type="button" class="btn btn-info btn-sm" data-toggle="modal" data-target="#myModal">Избери датум</button>
                                </br  >
                                 <asp:Label ID="datum" runat="server" Text=""></asp:Label>

                                <!-- Modal -->
                                <div class="modal fade" id="myModal" role="dialog">
                                    <div class="modal-dialog modal-sm">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                <h4 class="modal-title">Избери датум</h4>
                                            </div>
                                            <div class="modal-body">
                                                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>

                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-default" data-dismiss="modal">Затвори</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            </br>
                            <asp:Label ID="Label2" runat="server" Text="Избери термин:"></asp:Label>
                            </br>
                            <asp:RadioButtonList ID="termini" runat="server" style="margin-left:45%">
                                <asp:ListItem>08:00 - 09:00</asp:ListItem>
                                <asp:ListItem>09:00 - 10:00</asp:ListItem>
                                <asp:ListItem>10:00 - 11:00</asp:ListItem>
                                <asp:ListItem>11:00 - 12:00</asp:ListItem>
                                <asp:ListItem>12:00 - 13:00</asp:ListItem>
                                <asp:ListItem>13:00 - 14:00</asp:ListItem>
                                <asp:ListItem>14:00 - 15:00</asp:ListItem>
                                <asp:ListItem>15:00 - 16:00</asp:ListItem>
                            </asp:RadioButtonList>
                          
                              <%--  <div class="list-group" >
                                    <button type="button" class="list-group-item" style="margin-left:45%">08:00 - 09:00</button>
                                    <button type="button" class="list-group-item" style="margin-left:45%">08:00 - 09:00</button>
                                    <button type="button" class="list-group-item" style="margin-left:45%">08:00 - 09:00</button>
                                    <button type="button" class="list-group-item" style="margin-left:45%">08:00 - 09:00</button>
                                    <button type="button" class="list-group-item" style="margin-left:45%">08:00 - 09:00</button>
                             
                            </div>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="Button1" runat="server" Text="Закажи" OnClick="Button1_Click" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblporaka" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>



            </div>
        </div>


    </div>




</asp:Content>