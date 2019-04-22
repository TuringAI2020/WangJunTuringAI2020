var PARAMCHECKER = {

};

PARAMCHECKER.IsValid = function (input) {
    return !(undefined === input || null === input);
}


PARAMCHECKER.IsFunction = function (input)
{
    return typeof (input) === typeof (function () { });
}

PARAMCHECKER.GetUrlQuery = function (keyName) {
    var query = window.location.search;
    var queryData = {};
    query.replace('?', '').split(/&/g).forEach(p => {
        var arr = p.split(/=/g);
        if (2 === arr.length) {
            queryData[arr[0]] = arr[1];
        }
    });
    if (true == PARAMCHECKER.IsValid(keyName)) {
        return queryData[keyName];
    }
    return queryData;
    
}

var PARAM_UTINITY = {};
PARAM_UTINITY.FormatDate = function (input,type) {
    return input.substring(0, 16).replace("T", " ");
}
