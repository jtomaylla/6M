
var menuIconWidth = 20;
var topMargin = null;
var openImage = '<div class="open_image"></div>';
var closeImage = '<div class="close_image"></div>';
var floatingDiv = "#floating";
var accordionDiv = "#accordion";


var menuLoading = {
    load: function () {
        $("#closeOpen").html(openImage);
        topMargin = parseInt($(floatingDiv).css("top").substring(0, $(floatingDiv).css("top").indexOf("px")))
        $(floatingDiv).css({ left: menuIconWidth - $(floatingDiv).width() });
        $(floatingDiv).mouseenter(function () {
            $(this).stop().animate({ left: 0 }, "slow");
            $("#closeOpen").html(closeImage);
        }).mouseleave(function () {
            $(this).stop().animate({ left: menuIconWidth - $(this).width() }, "slow");
            $("#closeOpen").html(openImage);
        });
        $(accordionDiv + ' > li a.head').click(function () {
            if ($(this).parent().hasClass('current')) {
                $(this).siblings('ul').slideUp(300, function () {
                    $(this).parent().removeClass('current');
                });
            } else {
                $(accordionDiv + ' li.current ul').slideUp(300, function () {
                    $(this).parent().removeClass('current');
                });
                $(this).siblings('ul').slideToggle(300, function () {
                    $(this).parent().toggleClass('current');
                });
            }
            return false;
        });
    }
}


var init = {
    funciones: function () {
        try {
            if ($("#floating").size() != 0) { menuLoading.load(0); }
            $.ifixpng('../img/blank.gif');
            $("img[src$=.png], .logomov a, .tpSubMenu, #accordionMenu .bottom_accordion").ifixpng();
            $("input[type='image']").ifixpng().css('cursor', 'pointer');

            $('#container-3').tabs({ navClass: 'tabs-nav2', containerClass: 'tabs-container2' });

            Cufon.replace('.contenido_titulosLeft', { fontFamily: 'Movistar Headline', hover: true });
            Cufon.replace('.gestion_cabeceraleft, .cont_head h2, .gestion_cabeceraleft h2 ', { fontFamily: 'Movistar Headline Bold', hover: true });
        } catch (e) {

        }
    }
}


function overrideAlertFront() {
    window.alert = function (message) {
        jAlert(message);
        $('#popup_ok').val('').blur();
        $('#popup_content').before('<div class="bot_top_close"><a onclick="$.alerts._hide()" class="tex">cerrar</a></div>')
    };
};

function override() {
    ValidationSummaryOnSubmit = function (validationGroup) {
        if (typeof (Page_ValidationSummaries) == "undefined") return;
        var summary, sums, s;
        var headerSep, first, pre, post, end;
        for (sums = 0; sums < Page_ValidationSummaries.length; sums++) {
            summary = Page_ValidationSummaries[sums];
            summary.style.display = "none";
            if (!Page_IsValid && IsValidationGroupMatch(summary, validationGroup)) {
                var i;
                if (typeof (summary.displaymode) != "string") { summary.displaymode = "BulletList"; }
                switch (summary.displaymode) {
                    case "List": headerSep = "<br>"; first = ""; pre = ""; post = "<br>"; end = ""; break;
                    case "BulletList": default: headerSep = ""; first = "<ul>"; pre = "<li>"; post = "</li>"; end = "</ul>"; break;
                    case "SingleParagraph": headerSep = " "; first = ""; pre = ""; post = " "; end = "<br>"; break;
                }
                s = first;
                for (i = 0; i < Page_Validators.length; i++) {
                    if (!Page_Validators[i].isvalid && typeof (Page_Validators[i].errormessage) == "string") {
                        s += pre + Page_Validators[i].errormessage + post;
                    }
                }
                s += end;
                if (summary.showmessagebox == "True") {
                    jAlert(s, summary.headertext);
                }
                if (summary.showsummary != "False") {
                    summary.style.display = "";
                    if (typeof (summary.headertext) == "string") { s = summary.headertext + headerSep + s; }
                    summary.innerHTML = s;
                }
            }
        }
    }
}

$(document).ready(function () {
    init.funciones();
    override();
    overrideAlertFront();
    if (typeof (Sys) != 'undefined') Sys.WebForms.PageRequestManager.getInstance().add_endRequest(overrideAlertFront);
});
