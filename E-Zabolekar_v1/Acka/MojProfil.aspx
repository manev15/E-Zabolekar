<%@ Page Title="Мој профил" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MojProfil.aspx.cs" Inherits="Acka.MojProfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
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

    </script>


    <style>
        body {
            background: #EAEAEA;
        }

        .user-details {
            position: relative;
            padding: 0;
        }

            .user-details .user-image {
                position: relative;
                z-index: 1;
                width: 100%;
                text-align: center;
            }

        .user-image img {
            clear: both;
            margin: auto;
            position: relative;
        }

        .user-details .user-info-block {
            width: 100%;
            position: absolute;
            top: 55px;
            background: rgb(255, 255, 255);
            z-index: 0;
            padding-top: 35px;
        }

        .user-info-block .user-heading {
            width: 100%;
            text-align: center;
            margin: 10px 0 0;
        }

        .user-info-block .navigation {
            float: left;
            width: 100%;
            margin: 0;
            padding: 0;
            list-style: none;
            border-bottom: 1px solid #428BCA;
            border-top: 1px solid #428BCA;
        }

        .navigation li {
            float: left;
            margin: 0;
            padding: 0;
        }

            .navigation li a {
                padding: 20px 30px;
                float: left;
            }

            .navigation li.active a {
                background: #428BCA;
                color: #fff;
            }

        .user-info-block .user-body {
            float: left;
            padding: 5%;
            width: 90%;
        }

        .user-body .tab-content > div {
            float: left;
            width: 100%;
        }

        .user-body .tab-content h4 {
            width: 100%;
            margin: 10px 0;
            color: #333;
        }

        tr {
            font-size: 125%;
        }
    </style>
    <div class="container" style="margin-top: 2%">

        <div class="panel panel-primary" style="padding-bottom: 44%">
            <div class="panel-heading">
                <h4 class="panel-title">Мој профил</h4>
            </div>
            <div class="panel-body">
                <div class="container" style="margin-left: 33%">
                    <div class="row">
                        <div class="col-sm-4 col-md-4 user-details">
                            <div class="user-image">
                                <asp:Image ID="Slika" class="img-circle" Style="width: 100px; height: 100px;" runat="server" />
                            </div>
                            <div class="user-info-block">
                                <div class="user-heading">
                                    <asp:PlaceHolder ID="userInfo" runat="server"></asp:PlaceHolder>

                                </div>
                                <ul class="navigation">
                                    <li class="active">
                                        <a data-toggle="tab" href="#information">
                                            <span class="glyphicon glyphicon-user"></span>
                                        </a>
                                    </li>
                                    <li>
                                        <a data-toggle="tab" href="#settings">
                                            <span class="glyphicon glyphicon-cog"></span>
                                        </a>
                                    </li>
                                    <li>
                                        <a data-toggle="tab" href="#email">
                                            <span class="glyphicon glyphicon-envelope"></span>
                                        </a>
                                    </li>
                                    <li>
                                        <a data-toggle="tab" href="#events">
                                            <span class="glyphicon glyphicon-calendar"></span>
                                        </a>
                                    </li>
                                </ul>
                                <div class="user-body">
                                    <div class="tab-content">
                                        <div id="information" class="tab-pane active">
                                            <h4 style="margin-left: 18%;">Податоци за корисник:</h4>
                                            <asp:PlaceHolder ID="AccountInformation" runat="server"></asp:PlaceHolder>

                                        </div>
                                        <div id="settings" class="tab-pane" style="margin-left: 9%;">
                                            <h4>Опции:</h4>
                                            <asp:Button class="btn btn-primary" data-toggle="modal" data-target="#complete-fak" runat="server" Text="Промени корисничко име"></asp:Button>
                                            </br>
                  <asp:Button class="btn btn-primary" data-toggle="modal" data-target="#complete-fak1" Style="width: 87%" runat="server" Text="Промени лозинка"></asp:Button>
                                            </br>
        
                <asp:Button class="btn btn-primary" data-toggle="modal" data-target="#complete-fak2" Style="width: 87%" runat="server" Text="Промени телефон"></asp:Button>
                                            <br />
                                            <asp:Button class="btn btn-primary" data-toggle="modal" data-target="#complete-fak3" Style="width: 87%" runat="server" Text="Промени локација"></asp:Button>
                                            <br />
                                            <asp:Button class="btn btn-primary" data-toggle="modal" data-target="#complete-fak4" Style="width: 87%" runat="server" Text="Промени слика"></asp:Button>

                                        </div>
                                        <div id="email" class="tab-pane">
                                            <h4>Испрати порака:</h4>

                                            <div class="container">
                                                <div class="row">
                                                    <div class="col-sm-4 col-md-4" style="margin-left: -1.5%;">
                                                        <div class="panel panel-default">
                                                            <div class="panel-body">
                                                                <form accept-charset="UTF-8">
                                                                    <asp:TextBox TabIndex="1" Style="max-width: 100%;" placeholder="Наслов" class="form-control" ID="naslov" runat="server"></asp:TextBox>
                                                                    <br />

                                                                    <textarea class="form-control counted" name="message" placeholder="Вашата порака" rows="5" style="margin-bottom: 10px;"></textarea>
                                                                    <h6 class="pull-right" id="counter">320 преостанати букви</h6>
                                                                    <button class="btn btn-primary" type="submit">Испрати ја пораката</button>
                                                                </form>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div id="events" class="tab-pane">
                                            <h4>Events</h4>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:PlaceHolder ID="UserInfoemation" runat="server" Visible="false"></asp:PlaceHolder>


                <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>


            </div>

        </div>



    </div>



    <div id="complete-fak" class="modal fade" tabindex="-1">

        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Промени корисничко име</h4>
                </div>
                <div class="modal-body" style="padding-top: 5%">

                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblStaroIme" runat="server" Text="Старо корисничко име: "></asp:Label>


                            </td>

                            <td>

                                <asp:TextBox TabIndex="1" Style="max-width: 100%;" ReadOnly="true" class="form-control" ID="staroIME" runat="server"></asp:TextBox>

                            </td>

                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblNovoIme" runat="server" Text="Ново корисничко име: "></asp:Label>

                            </td>
                            <td>

                                <asp:TextBox TabIndex="1" Style="max-width: 100%;" class="form-control" ID="novoIME" runat="server"></asp:TextBox>

                            </td>

                        </tr>


                    </table>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Затвори</button>
                    <asp:Button type="button" class="btn btn-primary" OnClick="PromeniIme" runat="server" Text="Промени име"></asp:Button>
                </div>

            </div>
        </div>

    </div>

    <div id="complete-fak1" class="modal fade" tabindex="-1">

        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Промени лозинка</h4>
                </div>
                <div class="modal-body" style="padding-top: 5%">




                    <asp:TextBox TabIndex="1" Style="max-width: 100%;" placeholder="Стара лозинка" class="form-control" type="password" ID="txtStaraLozinka" runat="server"></asp:TextBox>



                    <asp:TextBox TabIndex="1" Style="max-width: 100%;" placeholder="Нова лозинка" class="form-control" type="password" ID="txtNovaLozinka" runat="server"></asp:TextBox>



                    <asp:TextBox TabIndex="1" Style="max-width: 100%;" placeholder="Потврди нова лозинка" class="form-control" type="password" ID="txtPotvrdiNova" runat="server"></asp:TextBox>




                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Затвори</button>
                    <asp:Button type="button" ID="Promeni" class="btn btn-primary" OnClick="promeniPassword" runat="server" Text="Промени лозинка"></asp:Button>
                </div>

            </div>
        </div>

    </div>

    <div id="complete-fak2" class="modal fade" tabindex="-1">

        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Додади новост</h4>
                </div>
                <div class="modal-body" style="padding-top: 5%">

                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Претходен телефонски број : "></asp:Label>


                            </td>

                            <td>

                                <asp:TextBox TabIndex="1" Style="max-width: 100%;" class="form-control" ReadOnly="true" ID="txtStarTelefon" runat="server"></asp:TextBox>

                            </td>

                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Нов телефонски број: "></asp:Label>

                            </td>
                            <td>

                                <asp:TextBox TabIndex="1" Style="max-width: 100%;" class="form-control" ID="txtNovTelefon" runat="server"></asp:TextBox>

                            </td>

                        </tr>


                    </table>


                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Затвори</button>
                    <asp:Button type="button" class="btn btn-primary" OnClick="PromeniTelefon" runat="server" Text="Промени Телефон"></asp:Button>
                </div>

            </div>
        </div>

    </div>

    <div id="complete-fak4" class="modal fade" tabindex="-1">

        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Промени слика</h4>
                </div>
                <div class="modal-body" style="padding-top: 5%">

                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Име: "></asp:Label>


                            </td>

                            <td>

                                <asp:TextBox TabIndex="1" Style="max-width: 100%;" class="form-control" ID="txtImeSlika" runat="server"></asp:TextBox>

                            </td>

                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="Најди слика: "></asp:Label>

                            </td>

                            <td>

                                <asp:FileUpload ID="fajl" text="browse.." runat="server" />
                            </td>

                        </tr>



                    </table>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Затвори</button>
                    <asp:Button type="button" class="btn btn-primary" OnClick="kopceUpload_Click" runat="server" Text="Промени слика"></asp:Button>
                </div>

            </div>
        </div>

    </div>

    <div id="complete-fak3" class="modal fade" tabindex="-1">

        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Промени локација</h4>
                </div>
                <div class="modal-body" style="padding-top: 5%">

                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Претходна локација : "></asp:Label>


                            </td>

                            <td>

                                <asp:TextBox TabIndex="1" Style="max-width: 100%;" class="form-control" ReadOnly="true" ID="txtStaraLokacija" runat="server"></asp:TextBox>

                            </td>

                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Нова локација: "></asp:Label>

                            </td>
                            <td>

                                <asp:TextBox TabIndex="1" Style="max-width: 100%;" class="form-control" ID="txtNovaLokacija" runat="server"></asp:TextBox>

                            </td>

                        </tr>


                    </table>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Затвори</button>
                    <asp:Button type="button" class="btn btn-primary" OnClick="PromeniLokacija" runat="server" Text="Промени локација"></asp:Button>
                </div>

            </div>
        </div>

    </div>

</asp:Content>
