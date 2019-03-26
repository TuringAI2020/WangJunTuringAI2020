let option = {}
option.el = "#page";
option.data = {
    page: {
        alert: { text: "OK" }
    },
    data: {
        content:""
    }
};
option.methods = {};
option.created = function () { }


option.methods.SaveDocument = function () {
    let vThis = this;
    vThis.page.alert.text = "OK124";
    let ajaxOption = {
        url: "http://localhost:5168/API.ashx",
        method: "POST",
        dataType :"json",
        data: JSON.stringify({
            "TargetClass": "YunForm",
            "Method": "Save",
            "Param": { "ValueS01": UM.getEditor('myEditor').getContent()},
            "InputParamArray": []
        })
    };
    $.ajax(ajaxOption)
    .done(function (res1, res2) {
        vThis.page.alert.text = "OK123";
    }).fail(function (res1, res2) {
    
    }).always(function (res1, res2) { });
}



let vue = new Vue(option);
 