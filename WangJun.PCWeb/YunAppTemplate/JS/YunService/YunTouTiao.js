let option = {}
option.el = "#page";
option.data = {
    page: {
        alert: { text: "OK" }
    },
    api: {
        url: "http://localhost:5168/API.ashx",
    },
    ParentNode: { ID: "", Name: "" },
    CurrentNode: { ID: "", Name: "" },
    RootNode: { ID: "F06E86A8-DB7F-4E39-BA1E-C2F620F8D20C" },
    CategoryList: [],
    FormList: [],
    CurrentForm: {}


};
option.methods = {};
option.created = function () {
 
}


option.methods.LoadCategotyList = function () {
    let vThis = this; 
  
    let ajaxOption = {
        url: vThis.api.url,
        method: "POST",
        dataType: "json",
        data: JSON.stringify({
            "TargetClass": "YunRelation",
            "Method": "LoadList",
            "Param": {},
            "InputParamArray": [vThis.RootNode.ID]
        })
    };
    $.ajax(ajaxOption)
        .done(function (res1, res2) {
            vThis.page.alert.text = "OK123";
            vThis.CategoryList = res1.DATA;
        }).fail(function (res1, res2) {

        }).always(function (res1, res2) { });
}

option.methods.LoadFormList = function () {
    let vThis = this;

    let ajaxOption = {
        url: vThis.api.url,
        method: "POST",
        dataType: "json",
        data: JSON.stringify({
            "TargetClass": "YunForm",
            "Method": "LoadList",
            "Param": {},
            "InputParamArray": [769]
        })
    };
    $.ajax(ajaxOption)
        .done(function (res1, res2) { 
            vThis.FormList = res1.DATA;
        }).fail(function (res1, res2) {

        }).always(function (res1, res2) { });
}

option.methods.LoadForm = function () {
    let vThis = this;
    var id = PARAMCHECKER.GetUrlQuery("id");
    let ajaxOption = {
        url: vThis.api.url,
        method: "POST",
        dataType: "json",
        data: JSON.stringify({
            "TargetClass": "YunForm",
            "Method": "Load",
            "Param": {},
            "InputParamArray": [id]
        })
    };
    $.ajax(ajaxOption)
        .done(function (res1, res2) {
            vThis.CurrentForm = res1.DATA;
        }).fail(function (res1, res2) {

        }).always(function (res1, res2) { });
}



let vue = new Vue(option);
 