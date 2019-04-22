let option = {}
option.el = "#page";
option.data = {
    page: {
        alert: { text: "OK" }
    },
    api: {
        url: "http://localhost:5168/API.ashx",
    },
    app: {
        Name: "汪俊头条"
    }, 
    user: {
        Name: "汪俊",
        Description:"自我介绍"
    },
    ParentNode: { ID: "", Name: "" },
    CurrentNode: { ID: "", Name: "" },
    CurrentLeftMenu: {    },
    RootNode: { ID: "F06E86A8-DB7F-4E39-BA1E-C2F620F8D20C" },
    CategoryList: [],
    FormList: [],
    CurrentForm: {}


};
option.methods = {};
option.created = function () {
    document.title = this.app.Name;
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
            vThis.CategoryList = res1.DATA;
            if (0 < vThis.CategoryList) {
                vThis.CurrentLeftMenu = vThis.CategoryList[0];
            }
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
            res1.DATA.forEach(p => {
                p.CreateTime = PARAM_UTINITY.FormatDate(p.CreateTime);
            });

            vThis.FormList = vThis.FormList.concat( res1.DATA);
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


option.methods.LeftMenuClick = function (item,index) {
    this.CurrentLeftMenu = item;
}


let vue = new Vue(option);
 