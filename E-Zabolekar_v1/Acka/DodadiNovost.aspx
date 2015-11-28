<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="DodadiNovost.aspx.cs" Inherits="Acka.DodadiNovost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(document).ready(function () {
            $("#btndodadi").click(function () {
                $("#txtNaslov").prop('required', true);
                $("#txtOpis").prop('required', true);

            });
        });
    </script>
     <div class="container" style="padding-top:5%">
             <div class="container" style="margin-left:23%">
       
            <div class="col-lg-6">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Последни новости</h3>
                    </div>
                    
                        
                        <div class="list-group">
                                <asp:PlaceHolder ID="placeZanovosti" runat="server"></asp:PlaceHolder>
                        </div>
                    
                </div>
            </div>
            </div>


     <asp:button class="btn btn-primary" data-toggle="modal" data-target="#complete-fak"  runat="server" Text="Додади новост" ></asp:button>
   

        <div id="complete-fak" class="modal fade" tabindex="-1">

            <div class="modal-dialog">
                <div class="modal-content">

                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title" >Додади новост</h4>
                    </div>
                    <div class="modal-body" style="padding-top: 5%">

                          <div class="form-group">
                            <asp:TextBox TabIndex="1" style=" max-width: 100%;"  class="form-control" placeholder="Наслов" ID="txtNaslov" runat="server"></asp:TextBox>

                        </div>
                        <div class="form-group">
                            <asp:TextBox TabIndex="1"  style=" max-width: 100%;"  class="form-control" placeholder="Опис" ID="txtOpis" runat="server"></asp:TextBox>

                        </div>
                            

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Затвори</button>
                        <asp:button ID="btndodadi" type="button" class="btn btn-primary" OnClick="dodadiNovost" runat="server" Text="Додади новост"></asp:button>
                    </div>

                </div>
            </div>

        </div>
 </div>
</asp:Content>
