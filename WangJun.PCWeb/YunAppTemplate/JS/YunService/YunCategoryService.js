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


option.methods.LoadCategotyList = function () {
    let vThis = this;
    vThis.page.alert.text = "OK124";
 
     
    let ajaxOption = {
        url: "http://localhost:5168/API.ashx",
        method: "POST",
        dataType: "json",
        data: JSON.stringify({
            "TargetClass": "YunRelation",
            "Method": "LoadList",
            "Param": {},
            "InputParamArray": ['F06E86A8-DB7F-4E39-BA1E-C2F620F8D20C']
        })
    };
    $.ajax(ajaxOption)
        .done(function (res1, res2) {
            vThis.page.alert.text = "OK123";
            let zNodes = res1.DATA;
            LoadZtree("#tree1", zNodes);
            LoadZtree("#tree2", zNodes);
            LoadZtree("#tree3", zNodes);

        }).fail(function (res1, res2) {

        }).always(function (res1, res2) { });
}

option.methods.SaveCategory = function () {
    let vThis = this;
    vThis.page.alert.text = "OK124";
    let param = { 
        Name: "汪俊头条2",
        ParentID:"593dfbfd-3b26-470c-b9e5-1017c4074419"
    };
     

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

function LoadZtree(el, zNodes)
{ 
    var zSetting = {

        data: {
            simpleData: {
                enable: true,
                idKey: "ID",
                pIdKey: "ParentID",
                rootPId: 0
            },
            key: {
                name: "Name"
            }
        },
        callback: {
            onClick: function (dat1, dat2, dat3) {

            }
        }
    };
     
    zNodes.forEach(p => { p.open = true; });

    $.fn.zTree.init($(el), zSetting, zNodes);
}
 