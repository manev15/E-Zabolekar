<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Anketi.aspx.cs" Inherits="Acka.Anketi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script>

        function najdi(porakaID) {

            var porID = porakaID;
            var pageId = "<%=  Page.ClientID %>";
            __doPostBack(pageId, porID);


        }
        (function ($) {
            /**
             * attaches a character counter to each textarea element in the jQuery object
             * usage: $("#myTextArea").charCounter(max, settings);
             */

            $.fn.charCounter = function (max, settings) {
                max = max || 100;
                settings = $.extend({
                    container: "<span></span>",
                    classname: "charcounter",
                    format: "(%1 преостанати букви)",
                    pulse: true,
                    delay: 0
                }, settings);
                var p, timeout;

                function count(el, container) {
                    el = $(el);
                    if (el.val().length > max) {
                        el.val(el.val().substring(0, max));
                        if (settings.pulse && !p) {
                            pulse(container, true);
                        };
                    };
                    if (settings.delay > 0) {
                        if (timeout) {
                            window.clearTimeout(timeout);
                        }
                        timeout = window.setTimeout(function () {
                            container.html(settings.format.replace(/%1/, (max - el.val().length)));
                        }, settings.delay);
                    } else {
                        container.html(settings.format.replace(/%1/, (max - el.val().length)));
                    }
                };

                function pulse(el, again) {
                    if (p) {
                        window.clearTimeout(p);
                        p = null;
                    };
                    el.animate({ opacity: 0.1 }, 100, function () {
                        $(this).animate({ opacity: 1.0 }, 100);
                    });
                    if (again) {
                        p = window.setTimeout(function () { pulse(el) }, 200);
                    };
                };

                return this.each(function () {
                    var container;
                    if (!settings.container.match(/^<.+>$/)) {
                        // use existing element to hold counter message
                        container = $(settings.container);
                    } else {
                        // append element to hold counter message (clean up old element first)
                        $(this).next("." + settings.classname).remove();
                        container = $(settings.container)
                                        .insertAfter(this)
                                        .addClass(settings.classname);
                    }
                    $(this)
                        .unbind(".charCounter")
                        .bind("keydown.charCounter", function () { count(this, container); })
                        .bind("keypress.charCounter", function () { count(this, container); })
                        .bind("keyup.charCounter", function () { count(this, container); })
                        .bind("focus.charCounter", function () { count(this, container); })
                        .bind("mouseover.charCounter", function () { count(this, container); })
                        .bind("mouseout.charCounter", function () { count(this, container); })
                        .bind("paste.charCounter", function () {
                            var me = this;
                            setTimeout(function () { count(me, container); }, 10);
                        });
                    if (this.addEventListener) {
                        this.addEventListener('input', function () { count(this, container); }, false);
                    };
                    count(this, container);
                });
            };

        })(jQuery);

        $(function () {
            $(".counted").charCounter(320, { container: "#counter" });
        });

   

        $(document).ready(function () {
            $('.form-control').floatlabel({
                labelClass: 'float-label',
                labelEndTop: 5
            });
        });

        </script>
    <style>
        @import url(http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,400,300,600,700);

        body {
            background-color: #F7F7F7;
            font-family: 'Open Sans', sans-serif;
        }
        /*Navbar*/
        .navbar-default {
            background-color: #fff;
            border-bottom-color: #E3E3E3;
        }

            .navbar-default .navbar-nav > .active > a,
            .navbar-default .navbar-nav > .active > a:hover,
            .navbar-default .navbar-nav > .active > a:focus {
                background-color: transparent !important;
            }

            .navbar-default .btn-compose {
                padding-right: 10px;
                border-right: 1px solid #F0F0F0;
            }
        /*Forms setup*/
        .form-control {
            border-radius: 0;
            box-shadow: none;
            height: auto;
            width: 100%;
        }

        .float-label {
            font-size: 10px;
        }

        input[type="text"].form-control,
        input[type="search"].form-control {
            border: none;
            border-bottom: 1px dotted #CFCFCF;
        }

        textarea {
            border: 1px dotted #CFCFCF !important;
            height: 130px !important;
        }
        /*Content Container*/
        .content-container {
            background-color: #fff;
            padding: 35px 20px;
            margin-bottom: 20px;
        }

        h1.content-title {
            font-size: 32px;
            font-weight: 300;
            text-align: center;
            margin-top: 0;
            margin-bottom: 20px;
            font-family: 'Open Sans', sans-serif !important;
        }
        /*Compose*/
        .btn-send {
            text-align: center;
            margin-top: 20px;
        }
        /*mail list*/

        ul.mail-list {
            padding: 0;
            margin: 0;
            list-style: none;
            margin-top: 30px;
        }

            ul.mail-list li a {
                display: block;
                border-bottom: 1px dotted #CFCFCF;
                padding: 20px;
                text-decoration: none;
            }

            ul.mail-list li:last-child a {
                border-bottom: none;
            }

            ul.mail-list li a:hover {
                background-color: #DBF9FF;
            }

            ul.mail-list li span {
                display: block;
            }

                ul.mail-list li span.mail-sender {
                    font-weight: 600;
                    color: #8F8F8F;
                }

                ul.mail-list li span.mail-subject {
                    color: #8C8C8C;
                }

                ul.mail-list li span.mail-message-preview {
                    display: block;
                    color: #A8A8A8;
                }

        .mail-search {
            border-bottom-color: #7FBCC9 !important;
        }
     body { margin-top:20px; }
.panel-body:not(.two-col) { padding:0px }
.glyphicon { margin-right:5px; }
.glyphicon-new-window { margin-left:5px; }
.panel-body .radio,.panel-body .checkbox {margin-top: 0px;margin-bottom: 0px;}
.panel-body .list-group {margin-bottom: 0;}
.margin-bottom-none { margin-bottom: 0; }
.panel-body .radio label,.panel-body .checkbox label { display:block; }
    </style>

    <nav class="navbar navbar-default navbar-static-top" role="navigation" style="margin-top: 2%">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
        
            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
             
                <ul class="nav navbar-nav">

                      <li><a href="#prateni" role="tab" data-toggle="tab" target="_blank" >Креирај Анкета</a>

                    </li>

                    <li>
                        <a href="#inbox" role="tab" data-toggle="tab" target="_blank">Мои анкети
                        </a>
                    </li>
                  

                </ul>

            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container-fluid -->
    </nav>




    <div class="tab-content">
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        <div class="tab-pane " id="inbox">

            <div class="container">
                <div class="content-container clearfix">
                    <div class="col-md-12">
                        <h1 class="content-title">Мои анкети</h1>
                            <asp:PlaceHolder ID="placePrimeni" runat="server"></asp:PlaceHolder>

                      
                    </div>
                </div>
            </div>

        </div>


        <div class="tab-pane active" id="prateni">

            <div class="container">
                <div class="content-container clearfix">
                    <div class="col-md-12">
                        <h1 class="content-title">Креирај Анкета</h1>
                          <div class="form-group">

                            <input type="text" class="form-control" placeholder="Наслов" runat="server" id="txtAnketa" style="max-width: 100%" />
                        </div>

                                             <asp:PlaceHolder ID="placePrasanja" runat="server"></asp:PlaceHolder>
                     

                    </div>
                </div>
                
     <asp:button class="btn btn-primary" data-toggle="modal" data-target="#complete-fak"  runat="server" Text="Додади прашање" ></asp:button>
     <asp:button class="btn btn-primary" runat="server" Text="Креирај Анкета" OnClick="Unnamed_Click"></asp:button>

        <div id="complete-fak" class="modal fade" tabindex="-1">

            <div class="modal-dialog">
                <div class="modal-content">

                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title" >Додади прашање</h4>
                    </div>
                    <div class="modal-body" style="padding-top: 5%">

                          <div class="form-group">
                            <asp:TextBox TabIndex="1" style=" max-width: 100%;"  class="form-control" placeholder="Прашање" ID="txtPrasanje" runat="server"></asp:TextBox>

                        </div>
                        <div class="form-group">
                            <asp:TextBox TabIndex="1"  style=" max-width: 100%;"  class="form-control" placeholder="1.Одговор" ID="txtOdgovor1" runat="server"></asp:TextBox>

                        </div>
                               <div class="form-group">
                            <asp:TextBox TabIndex="1"  style=" max-width: 100%;"  class="form-control" placeholder="2.Одговор" ID="txtOdgovor2" runat="server"></asp:TextBox>

                        </div>
                           <div class="form-group">
                            <asp:TextBox TabIndex="1"  style=" max-width: 100%;"  class="form-control" placeholder="3.Одговор" ID="txtOdgovor3" runat="server"></asp:TextBox>

                        </div>
                           <div class="form-group">
                            <asp:TextBox TabIndex="1"  style=" max-width: 100%;"  class="form-control" placeholder="4.Одговор" ID="txtOdgovor4" runat="server"></asp:TextBox>

                        </div>
                           <div class="form-group">
                            <asp:TextBox TabIndex="1"  style=" max-width: 100%;"  class="form-control" placeholder="5.Одговор" ID="txtOdgovor5" runat="server"></asp:TextBox>

                        </div>
                           <div class="form-group">
                            <asp:TextBox TabIndex="1"  style=" max-width: 100%;"  class="form-control" placeholder="6.Одговор" ID="txtOdgovor6" runat="server"></asp:TextBox>

                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Затвори</button>
                        <asp:button ID="btndodadi" type="button" OnClick="btndodadi_Click" class="btn btn-primary"  runat="server" Text="Додади прашање"></asp:button>
                           </div>

                </div>
            </div>

        </div>
            </div>

        </div>




    </div>

</asp:Content>