function ShowMessagePopup(caption, message, type) {
    if (type) {
        swal({ title: caption, text: message, icon: type, closeOnClickOutside: false, closeOnEsc: false }


        );
    }
    else
    {
        swal({ title: caption, text: message, closeOnClickOutside: false, closeOnEsc: false });
    }
};

//swal({ title: "Successful", text: response.StatusMessage, type: "success" },
//    function () {
//        var url = taxSmart.pageSettings.serverVars.curl + '/' + response.ReferenceNumber + '/' + response.ResponseObject;
//        $(location).attr('href', url);
//    });

function amountRoundToTwo(num) {
    return +(Math.round(num + "e+2") + "e-2");
}

function formatMoney(n, currency) {
    //return currency + " " + n.toFixed(2).replace(/./g, function (c, i, a) {
    //    return i > 0 && c !== "." && (a.length - i) % 3 === 0 ? "," + c : c;
    //});
    return currency + "" + (amountRoundToTwo(n) + '').replace(/./g, function (c, i, a) {
        return i > 0 && c !== "." && (a.length - i) % 3 === 0 ? "," + c : c;
    });
}

Date.prototype.formatDate = function(format) {
    var date = this;
    if (!format)
        format = "MM/dd/yyyy";

    var month = date.getMonth() + 1;
    var year = date.getFullYear();

    format = format.replace("MM", month.toString().padL(2, "0"));

    if (format.indexOf("yyyy") > -1)
        format = format.replace("yyyy", year.toString());
    else if (format.indexOf("yy") > -1)
        format = format.replace("yy", year.toString().substr(2, 2));

    format = format.replace("dd", date.getDate().toString().padL(2, "0"));

    var hours = date.getHours();
    if (format.indexOf("t") > -1) {
        if (hours > 11)
            format = format.replace("t", "pm")
        else
            format = format.replace("t", "am")
    }
    if (format.indexOf("HH") > -1)
        format = format.replace("HH", hours.toString().padL(2, "0"));
    if (format.indexOf("hh") > -1) {
        if (hours > 12) hours - 12;
        if (hours === 0) hours = 12;
        format = format.replace("hh", hours.toString().padL(2, "0"));
    }
    if (format.indexOf("mm") > -1)
        format = format.replace("mm", date.getMinutes().toString().padL(2, "0"));
    if (format.indexOf("ss") > -1)
        format = format.replace("ss", date.getSeconds().toString().padL(2, "0"));
    return format;
};

//function ajaxLoading() {
//    //console.log('ajax loading');
//    $(document)
//        .ajaxStart(function () {
//            //$("#ajaxSpinnerImage").show();
//            $.blockUI({ message: $('#divLoading') });
//        }).ajaxError(function () {
//            //$("#ajaxSpinnerImage").hide();
//            $.unblockUI();
//        }).ajaxStop(function () {
//            //$("#ajaxSpinnerImage").hide();
//            $.unblockUI();
//        });
//}

//String.repeat = function (chr, count) {
//    var str = "";
//    for (var x = 0; x < count; x++) { str += chr };
//    return str;
//}
//String.prototype.padL = function (width, pad) {
//    if (!width || width < 1)
//        return this;

//    if (!pad) pad = " ";
//    var length = width - this.length
//    if (length < 1) return this.substr(0, width);

//    return (String.repeat(pad, length) + this).substr(0, width);
//}
//String.prototype.padR = function (width, pad) {
//    if (!width || width < 1)
//        return this;

//    if (!pad) pad = " ";
//    var length = width - this.length
//    if (length < 1) this.substr(0, width);

//    return (this + String.repeat(pad, length)).substr(0, width);
//} 

//var tSmart = tSmart || {};

//(function ($) {
//    /* Application paths *****************************************/

//    //Current application root path (including virtual directory if exists).
//    tSmart.appPath = tSmart.appPath || '/';

//    tSmart.pageLoadTime = new Date();

//    //Converts given path to absolute path using tSmart.appPath variable.
//    tSmart.toAbsAppPath = function (path) {
//        if (path.indexOf('/') === 0) {
//            path = path.substring(1);
//        }

//        return tSmart.appPath + path;
//    };

//    ajaxLoading();
//    //browserBack();

//})(jQuery);
