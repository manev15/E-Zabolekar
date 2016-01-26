<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="TimZabolekari.aspx.cs" Inherits="Acka.TimZabolekari" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    
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
    <asp:GridView ID="gvZabolekari" runat="server"  AutoGenerateColumns="false" OnRowEditing="gv1_RowEditing" OnRowUpdating="gv1_RowUpdating" OnRowCancelingEdit="gv1_RowCancelingEdit" OnRowDeleting="gv1_RowDeleting" CssClass="gridview" OnPageIndexChanging="gv1_PageIndexChanging" PageSize="3" AllowPaging="true" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
          <Columns>  
                        <asp:TemplateField>  
                            <HeaderStyle CssClass="hdrow" />  
                            <HeaderTemplate>  
                                <asp:Label ID="hlbleid" runat="server" Text="Zabolekar Id"></asp:Label>  
                            </HeaderTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="lblZabolekarID" runat="server" Text='<%# Eval("zabolekar_ID") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>  
                        <asp:TemplateField>  
                            <HeaderStyle CssClass="hdrow" />  
                            <HeaderTemplate>  
                                <asp:Label ID="hlblename" runat="server" Text="Ime i Prezime"></asp:Label>  
                            </HeaderTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="lblime" runat="server" Text='<%# Eval("ime_prezime") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                            <EditItemTemplate>  
                                <asp:TextBox ID="txtzabolekarIme" runat="server" Text='<%# Eval("ime_prezime") %>'>  
                                </asp:TextBox>  
                            </EditItemTemplate>  
                        </asp:TemplateField>  
                        <asp:TemplateField>  
                            <HeaderStyle CssClass="hdrow" />  
                            <HeaderTemplate>  
                                <asp:Label ID="hlblemid" runat="server" Text="Opis"></asp:Label>  
                            </HeaderTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="lblopis" runat="server" Text='<%# Eval("opis") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                            <EditItemTemplate>  
                                <asp:TextBox ID="txtOpis" runat="server" Text='<%# Eval("opis") %>'>  
                                </asp:TextBox>  
                            </EditItemTemplate>  
                        </asp:TemplateField>  
                 <asp:TemplateField>  
                            <HeaderStyle CssClass="hdrow" />  
                            <HeaderTemplate>  
                                <asp:Label ID="hlblemid" runat="server" Text="Telefon"></asp:Label>  
                            </HeaderTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="lbltelefon" runat="server" Text='<%# Eval("telefon") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                            <EditItemTemplate>  
                                <asp:TextBox ID="txtTelefon" runat="server" Text='<%# Eval("telefon") %>'>  
                                </asp:TextBox>  
                            </EditItemTemplate>  
                        </asp:TemplateField>  
                        <asp:TemplateField>  
                            <HeaderStyle CssClass="hdrow" />  
                            <HeaderTemplate>  
                                <asp:Label ID="hempnumber" runat="server" Text="user_name"></asp:Label>  
                            </HeaderTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="lbluser" runat="server" Text='<%# Eval("user_name") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                            <EditItemTemplate>  
                                <asp:TextBox ID="txtUser" runat="server" Text='<%# Eval("user_name") %>'>  
                                </asp:TextBox>  
                            </EditItemTemplate>  
                        </asp:TemplateField>   
                <asp:TemplateField>  
                            <HeaderStyle CssClass="hdrow" />  
                            <HeaderTemplate>  
                                <asp:Label ID="hempnumber" runat="server" Text="Lokacija"></asp:Label>  
                            </HeaderTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="lblLokacija" runat="server" Text='<%# Eval("lokacija") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                            <EditItemTemplate>  
                                <asp:TextBox ID="txtLokacija" runat="server" Text='<%# Eval("lokacija") %>'>  
                                </asp:TextBox>  
                            </EditItemTemplate>  
                        </asp:TemplateField> 
                        <asp:TemplateField>  
                            <HeaderStyle CssClass="hdrow" />  
                            <HeaderTemplate>  
                                <asp:Label ID="hlblimg" runat="server" Text="Slika"></asp:Label>  
                            </HeaderTemplate>  
                            <ItemTemplate>  
                                 <asp:Image ID="img1" runat="server" ImageUrl='  
                                    <%# Eval("imageUrl") %>' Height="100px" Width="100px" />  
                                </ItemTemplate>  
                                <EditItemTemplate>  
                                    <asp:FileUpload ID="fu1" runat="server" />  
                                </EditItemTemplate>  
                            </asp:TemplateField>  
                            <asp:TemplateField>  
                                <HeaderStyle CssClass="hdrow" />  
                                <ItemTemplate>  
                                    <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="Edit" />  
                                    <asp:Button ID="btndelete" runat="server" Text="Delete" CommandName="Delete" />  
                                </ItemTemplate>  
                                <EditItemTemplate>  
                                    <asp:Button ID="btnupdate" runat="server" Text="Update" CommandName="Update" />  
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" />  
                                </EditItemTemplate>  
                            </asp:TemplateField>  
                        </Columns>  
    </asp:GridView>
</asp:Content>
