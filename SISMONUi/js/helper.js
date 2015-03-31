function GetRadWindow() {
    try {
        var oWindow = null;
        if (window.radWindow)
            oWindow = window.RadWindow; //Will work in Moz in all cases, including clasic dialog      
        else if (window.frameElement.radWindow)
            oWindow = window.frameElement.radWindow; //IE (and Moz as well)      
        return oWindow;
    } catch (e) {
        alert('error');
    }
}

function UpperCase(myfield, e) {
    if (upperCase == true) {
        tecla = (document.all) ? e.keyCode : e.which;
        var char = String.fromCharCode(tecla);
        if (/[a-z]/.test(char)) {
            if (e.which) {
                e.preventDefault();
                $(myfield).val($(myfield).val() + char.toUpperCase());
            }
            else { e.keyCode = char.toUpperCase().charCodeAt(0); }
        }
    }
}
function selectRadTab(tabScript, tab) {
    var tabStrip = $find(tabScript);
    var tab = tabStrip.findTabByValue(tab);
    tab.set_selected(true);
}
function TeclaEnter(e) {
    var keyPressed;
    if (document.all) {
        //Browser used: Internet Explorer 6
        keyPressed = e.keyCode;
    }
    else {
        keyPressed = e.which; //Browser used: Firefox
    }
    return keyPressed;
}

//****************************************************************************************************//
//Especificamos a jQuery los navegadores (Útil para diferenciar Safari de Chrome).
var userAgent = navigator.userAgent.toLowerCase();
jQuery.browser = {
    version: (userAgent.match(/.+(?:rv|it|ra|ie|me)[\/: ]([\d.]+)/) || [])[1],
    chrome: /chrome/.test(userAgent),
    safari: /webkit/.test(userAgent) && !/chrome/.test(userAgent),
    opera: /opera/.test(userAgent),
    msie: /msie/.test(userAgent) && !/opera/.test(userAgent),
    mozilla: /mozilla/.test(userAgent) && !/(compatible|webkit)/.test(userAgent)
};