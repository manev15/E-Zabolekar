<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="zazakazenipregledi.aspx.cs" Inherits="Acka.zazakazenipregledi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <style>

        .modal  {
            /*   display: block;*/
            padding-right: 0px;
            background-color: rgba(4, 4, 4, 0.8); 
        }
   
        .modal-dialog {
            top: 20%;
            width: 100%;
            position: absolute;
        }
        .modal-content {
            border-radius: 0px;
            border: none;
            top: 40%;
        }
        .modal-body {
            background-color: #0f8845;
            color: white;
        }
               
    </style>
    <script>
        function najdi() {

            zamodal.click();


        }
    </script>


 

    <div class="container">
 
    
    <div class="row">
        <!-- Large modal -->
<asp:button id="zamodal" type="button" data-toggle="modal" data-target=".bs-example-modal-lg"> </asp:button>

<div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
  <div class="modal-dialog modal-lg">
    <div class="modal-content">
    
      <div class="modal-body">
     
      <H2>Не си најавен!</H2>
      <h4>За да ги видете вашите закажени термини мора да сте најавени!</h4>
      <asp:Button ID="btnnajava" class="btn btn-info"  runat="server" Text="Најава" OnClick="btn_click" />


      </div>
    </div>
  </div>
</div>
    </div>
    
    
</div>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>

</asp:Content>
