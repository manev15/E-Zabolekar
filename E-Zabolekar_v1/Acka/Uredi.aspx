<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Uredi.aspx.cs" Inherits="Acka.TimZabolekari" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <br />
    <br />
    <div class="container">
 
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
     </div>

      <br />
    <br />
        <div class="container">

<asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="false" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" CssClass="gridview" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="10" AllowPaging="true" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                                <asp:Label ID="hlblTermin" runat="server" Text="Termin_ID"></asp:Label>  
                            </HeaderTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="lblTermin" runat="server" Text='<%# Eval("termin_id") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>  
                        <asp:TemplateField>  
                            <HeaderStyle CssClass="hdrow" />  
                            <HeaderTemplate>  
                                <asp:Label ID="hlblkorisnik" runat="server" Text="korisnik_id"></asp:Label>  
                            </HeaderTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="lblkorisnik" runat="server" Text='<%# Eval("korisnik_id") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                            <EditItemTemplate>  
                                <asp:TextBox ID="txtKorisnik" runat="server" Text='<%# Eval("korisnik_id") %>'>  
                                </asp:TextBox>  
                            </EditItemTemplate>  
                        </asp:TemplateField>  
               <asp:TemplateField>  
                            <HeaderStyle CssClass="hdrow" />  
                            <HeaderTemplate>  
                                <asp:Label ID="hlblZabolekar" runat="server" Text="zabolekar_id"></asp:Label>  
                            </HeaderTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="lblZabolekar" runat="server" Text='<%# Eval("zabolekar_id") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                            <EditItemTemplate>  
                                <asp:TextBox ID="txtZabolekar" runat="server" Text='<%# Eval("zabolekar_id") %>'>  
                                </asp:TextBox>  
                            </EditItemTemplate>  
                        </asp:TemplateField>  
                        <asp:TemplateField>  
                            <HeaderStyle CssClass="hdrow" />  
                            <HeaderTemplate>  
                                <asp:Label ID="hlblOd" runat="server" Text="od"></asp:Label>  
                            </HeaderTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="lblod" runat="server" Text='<%# Eval("od") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                            <EditItemTemplate>  
                                <asp:TextBox ID="txtOd" runat="server" Text='<%# Eval("od") %>'>  
                                </asp:TextBox>  
                            </EditItemTemplate>  
                        </asp:TemplateField>  
              
                        <asp:TemplateField>  
                            <HeaderStyle CssClass="hdrow" />  
                            <HeaderTemplate>  
                                <asp:Label ID="hlblDo" runat="server" Text="do"></asp:Label>  
                            </HeaderTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="lblDo" runat="server" Text='<%# Eval("do") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                            <EditItemTemplate>  
                                <asp:TextBox ID="txtDo" runat="server" Text='<%# Eval("do") %>'>  
                                </asp:TextBox>  
                            </EditItemTemplate>  
                        </asp:TemplateField>   
                <asp:TemplateField>  
                            <HeaderStyle CssClass="hdrow" />  
                            <HeaderTemplate>  
                                <asp:Label ID="Datum" runat="server" Text="Datum"></asp:Label>  
                            </HeaderTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="lblDatum" runat="server" Text='<%# Eval("datum") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                            <EditItemTemplate>  
                                <asp:TextBox ID="txtDatum" runat="server" Text='<%# Eval("datum") %>'>  
                                </asp:TextBox>  
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
    </div>

</asp:Content>