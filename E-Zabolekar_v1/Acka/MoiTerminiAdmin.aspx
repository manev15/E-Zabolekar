<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MoiTerminiAdmin.aspx.cs" Inherits="Acka.MoiTerminiAdmin" %>
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


                 <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog modal-lg">
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Modal Header</h4>
        </div>
        <div class="modal-body">
          <p>This is a large modal.</p>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
