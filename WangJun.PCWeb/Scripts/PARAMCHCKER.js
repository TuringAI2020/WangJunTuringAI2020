var PARAMCHECKER = {

};

PARAMCHECKER.IsValid = function (input) {
    return !(undefined === input || null === input);
}


PARAMCHECKER.IsFunction = function (input)
{
    return typeof (input) === typeof (function () { });
}

