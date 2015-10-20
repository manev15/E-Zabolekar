<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MoiTerminiAdmin.aspx.cs" Inherits="Acka.MoiTerminiAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function najdi(terminid,korisnikid,zaboekar_id) {
          
            document.getElementById("ace").innerHTML = terminid;
            document.getElementById('<%= pregledid.ClientID %>').innerHTML = terminid;
            document.getElementById('<%= korisnikid.ClientID %>').innerHTML = korisnikid;
            document.getElementById('<%= zabolekarid.ClientID %>').innerHTML = zaboekar_id;
         
        }
        </script>

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

               

                <br />
                <br />
                <br />
                <br />
                

               

            </div>
        </div>

    </div>


                 <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog modal-lg">
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Заврши го прегледот</h4>
        </div>
        <div class="modal-body">
          <p id="ace">е тука да са измисле убаво как шо, ама со ке са мисле требе да са заврше прегледо :D.</p>
            <asp:Label ID="pregledid" runat="server"></asp:Label>
            <asp:Label ID="korisnikid" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="zabolekarid" runat="server" Text="Label"></asp:Label>
            </br>
            <asp:Label ID="Label3" runat="server" Text="Детали за прегледот:"></asp:Label>
             </br>
             </br>
            <asp:TextBox ID="TextBox1" TextMode="multiline" runat="server" Height="300px" Width="400px"></asp:TextBox>
            </br>
            </br>
            <asp:Button ID="zavrsiPregled" runat="server" OnClick="zavrsiPregled_click" Text="Заврши го прегледот" Width="200px" />
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Затвори</button>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
