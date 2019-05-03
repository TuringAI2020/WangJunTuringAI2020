let option = {}
option.el = "#page";
option.data = {
    page: {
        alert: { text: "OK" }
    },
    api: {
        url: "http://localhost:5168/API.ashx",
    }, 
    content: "",
    title: "",
    ParentNode: { ID: "", Name: "" },
    RootNode: { ID: "F06E86A8-DB7F-4E39-BA1E-C2F620F8D20C" },
    FormList: [],


};
option.methods = {};
option.created = function () { }


option.methods.SaveDocument = function () {
    let vThis = this;
    vThis.page.alert.text = "OK124";
    let param = {
        FormType: parseInt("0x0301", 16),
        Title: vThis.title,
        ParentNodeID:vThis.ParentNode.ID,
        ValueS01: UM.getEditor('myEditor').getContent(),
        ValueS02: UM.getEditor('myEditor').getContentTxt()
    };

    param.ValueS03 = (150 <= param.ValueS02.length) ? param.ValueS02.substring(0, 150) : param.ValueS02;



    let ajaxOption = {
        url: "http://localhost:5168/API.ashx",
        method: "POST",
        dataType :"json",
        data: JSON.stringify({
            "TargetClass": "YunForm",
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
            let zNodes = res1.DATA;
            LoadZtree("#tree1", zNodes, {
                onClick: function (dat1, dat2, dat3, dat4) {
                    vThis.ParentNode.Name = dat3.Name;
                    vThis.ParentNode.ID = dat3.ID;
                }
            }); 

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

            vThis.FormList = vThis.FormList.concat(res1.DATA);
        }).fail(function (res1, res2) {

        }).always(function (res1, res2) { });
}

let vue = new Vue(option);


function LoadZtree(el, zNodes, option) {
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
            onClick: function (dat1, dat2, dat3, dat4) {
                if (true === PARAMCHECKER.IsFunction(option.onClick)) {
                    option.onClick(dat1, dat2, dat3, dat4);
                }
            }
        }
    };

    zNodes.forEach(p => { p.open = true; });

    $.fn.zTree.init($(el), zSetting, zNodes);
}