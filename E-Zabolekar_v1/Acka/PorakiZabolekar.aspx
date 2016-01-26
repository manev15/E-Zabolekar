<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="PorakiZabolekar.aspx.cs" Inherits="Acka.PorakiZabolekar" %>

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

        !function (a, b) { function g(b, c) { this.$element = a(b), this.settings = a.extend({}, f, c), this.init() } var e = "floatlabel", f = { slideInput: !0, labelStartTop: "20px", labelEndTop: "10px", paddingOffset: "10px", transitionDuration: .3, transitionEasing: "ease-in-out", labelClass: "", typeMatches: /text|password|email|number|search|url/ }; g.prototype = { init: function () { var a = this, c = this.settings, d = c.transitionDuration, e = c.transitionEasing, f = this.$element, g = { "-webkit-transition": "all " + d + "s " + e, "-moz-transition": "all " + d + "s " + e, "-o-transition": "all " + d + "s " + e, "-ms-transition": "all " + d + "s " + e, transition: "all " + d + "s " + e }; if ("INPUT" === f.prop("tagName").toUpperCase() && c.typeMatches.test(f.attr("type"))) { var h = f.attr("id"); h || (h = Math.floor(100 * Math.random()) + 1, f.attr("id", h)); var i = f.attr("placeholder"), j = f.data("label"), k = f.data("class"); k || (k = ""), i && "" !== i || (i = "You forgot to add placeholder attribute!"), j && "" !== j || (j = i), this.inputPaddingTop = parseFloat(f.css("padding-top")) + parseFloat(c.paddingOffset), f.wrap('<div class="floatlabel-wrapper" style="position:relative"></div>'), f.before('<label for="' + h + '" class="label-floatlabel ' + c.labelClass + " " + k + '">' + j + "</label>"), this.$label = f.prev("label"), this.$label.css({ position: "absolute", top: c.labelStartTop, left: f.css("padding-left"), display: "none", "-moz-opacity": "0", "-khtml-opacity": "0", "-webkit-opacity": "0", opacity: "0" }), c.slideInput || f.css({ "padding-top": this.inputPaddingTop }), f.on("keyup blur change", function (b) { a.checkValue(b) }), b.setTimeout(function () { a.$label.css(g), a.$element.css(g) }, 100), this.checkValue() } }, checkValue: function (a) { if (a) { var b = a.keyCode || a.which; if (9 === b) return } var c = this.$element, d = c.data("flout"); "" !== c.val() && c.data("flout", "1"), "" === c.val() && c.data("flout", "0"), "1" === c.data("flout") && "1" !== d && this.showLabel(), "0" === c.data("flout") && "0" !== d && this.hideLabel() }, showLabel: function () { var a = this; a.$label.css({ display: "block" }), b.setTimeout(function () { a.$label.css({ top: a.settings.labelEndTop, "-moz-opacity": "1", "-khtml-opacity": "1", "-webkit-opacity": "1", opacity: "1" }), a.settings.slideInput && a.$element.css({ "padding-top": a.inputPaddingTop }), a.$element.addClass("active-floatlabel") }, 50) }, hideLabel: function () { var a = this; a.$label.css({ top: a.settings.labelStartTop, "-moz-opacity": "0", "-khtml-opacity": "0", "-webkit-opacity": "0", opacity: "0" }), a.settings.slideInput && a.$element.css({ "padding-top": parseFloat(a.inputPaddingTop) - parseFloat(this.settings.paddingOffset) }), a.$element.removeClass("active-floatlabel"), b.setTimeout(function () { a.$label.css({ display: "none" }) }, 1e3 * a.settings.transitionDuration) } }, a.fn[e] = function (b) { return this.each(function () { a.data(this, "plugin_" + e) || a.data(this, "plugin_" + e, new g(this, b)) }) } }(jQuery, window, document);


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
    </style>
       <div id="complete-fak" class="modal fade" tabindex="-1">

        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Состави порака</h4>
                </div>
                <div class="modal-body" style="padding-top: 5%">

                    <div class="col-md-12">
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="Избери пациент: "></asp:Label>
                            <asp:DropDownList ID="listaKorisnici" runat="server"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <input type="text" class="form-control" placeholder="Наслов" runat="server" id="naslovPoraka" style="max-width: 100%" />
                        </div>
                        <textarea class="form-control" runat="server" id="opisPoraka" placeholder="Содржина..."></textarea>
                         <div class="btn-send">
                             <asp:Button ID="Button1" class="btn btn-success btn-lg" runat="server" Text="Испрати"  OnClick="Button1_Click"/>
                
            </div>
                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Затвори</button>
                   
                </div>

            </div>
        </div>

    </div>


    <nav class="navbar navbar-default navbar-static-top" role="navigation" style="margin-top: 2%">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>

                </button>
            </div>
            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <div class="btn-compose pull-left">
                    <a type="button" class="btn btn-danger navbar-btn" href="#" role="tab" data-toggle="modal" data-target="#complete-fak"><span class="glyphicon glyphicon-pencil"></span>Состави порака</a>
                </div>
                <ul class="nav navbar-nav">
                    <li>
                        <a href="#inbox" role="tab" data-toggle="tab">Примени пораки <span class="label label-success">10</span>
                        </a>
                    </li>
                    <li><a href="#prateni" role="tab" data-toggle="tab">Испратени пораки</a>

                    </li>

                </ul>

            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container-fluid -->
    </nav>




    <div class="tab-content">
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        <div class="tab-pane active" id="inbox">

            <div class="container">
                <div class="content-container clearfix">
                    <div class="col-md-12">
                        <h1 class="content-title">Примени пораки</h1>



                        <ul class="mail-list">
                            <asp:PlaceHolder ID="placePrimeni" runat="server"></asp:PlaceHolder>
                        </ul>
                    </div>
                </div>
            </div>

        </div>


        <div class="tab-pane" id="prateni">

            <div class="container">
                <div class="content-container clearfix">
                    <div class="col-md-12">
                        <h1 class="content-title">Пратени пораки</h1>



                        <ul class="mail-list">
                            <asp:PlaceHolder ID="placePrateni" runat="server"></asp:PlaceHolder>
                        </ul>
                    </div>
                </div>
            </div>

        </div>




    </div>
 


</asp:Content>