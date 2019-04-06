let option = {}
option.el = "#page";
option.data = {
    page: {
        alert: { text: "OK" }
    },
    data: {
        content: "",
        title:""
    }
};
option.methods = {};
option.created = function () { }


option.methods.LoadCategoty = function () {
    let vThis = this;
    vThis.page.alert.text = "OK124";
    let param = {
        FormType: parseInt("0x0301", 16),
        Title: vThis.data.title,
        ValueS01: UM.getEditor('myEditor').getContent(),
        ValueS02: UM.getEditor('myEditor').getContentTxt()
    };

    param.ValueS03 = (150 <= param.ValueS02.length) ? param.ValueS02.substring(0, 150) : param.ValueS02;



    let ajaxOption = {
        url: "http://localhost:5168/API.ashx",
        method: "POST",
        dataType: "json",
        data: JSON.stringify({
            "TargetClass": "YunRelation",
            "Method": "Save",
            "Param": param,
            "InputParamArray": []
        })
    };
    $.ajax(ajaxOption)
        .done(function (res1, res2) {
            vThis.page.alert.text = "OK123";
        }).fail(function (res1, res2) {

        }).always(function (res1, res2) { });
}

option.methods.SaveDocument = function () {
    let vThis = this;
    vThis.page.alert.text = "OK124";
    let param = {
        FormType: parseInt("0x0301", 16),
        Title: vThis.data.title,
        ValueS01: UM.getEditor('myEditor').getContent(),
        ValueS02: UM.getEditor('myEditor').getContentTxt()
    };

    param.ValueS03 = (150 <= param.ValueS02.length) ? param.ValueS02.substring(0, 150) : param.ValueS02;



    let ajaxOption = {
        url: "http://localhost:5168/API.ashx",
        method: "POST",
        dataType :"json",
        data: JSON.stringify({
            "TargetClass": "YunRelation",
            "Method": "Save",
            "Param": param,
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
 