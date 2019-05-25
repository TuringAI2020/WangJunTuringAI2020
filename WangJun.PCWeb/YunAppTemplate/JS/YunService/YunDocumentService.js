let API_URL = "http://192.168.0.168:80/API.ashx";
let option = {}
option.el = "#page";
option.data = {
    page: {
        alert: { text: "OK" }
    },
    api: {
        url: API_URL,
    }, 
    content: "",
    title: "",
    ParentNode: { ID: "", Name: "" },
    RootNode: { ID: "F06E86A8-DB7F-4E39-BA1E-C2F620F8D20C" },
    FormList: [],
    CurrentShowFormList:[],
    Pager1: {
        PageIndex: 0,
        PageSize: 5,
        TotalCount: 0,
        PagerArray:[]
    },
    ShowEle: "",


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
        url: API_URL,
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

option.methods.LoadForm = function (id) {

    this.ShowEle = "editor";
    var um = UM.getEditor('myEditor');
    um.setWidth(1033);
    if (false === PARAMCHECKER.IsNotEmptyString(id)) {
        id = PARAM_UTINITY.GetUrlQuery("id");
    }
     
    if (false === PARAMCHECKER.IsNotEmptyString(id)) {
        return false;
    }
     
    let vThis = this;
    vThis.page.alert.text = "OK124";
    let param = { };
 

    let ajaxOption = {
        url: API_URL,
        method: "POST",
        dataType: "json",
        data: JSON.stringify({
            "TargetClass": "YunForm",
            "Method": "Load",
            "Param": param,
            "InputParamArray": [id]
        })
    };
    $.ajax(ajaxOption)
        .done(function (res1, res2) {
            vThis.title = res1.DATA.Title;
            UM.getEditor('myEditor').setContent(res1.DATA.ValueS01);
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

option.methods.LoadFormList = function (item, index) {
    this.ShowEle = "table";

    if (!PARAMCHECKER.IsValid(item)) {
        item = { Index: 0, Status: 1 };
    }

    let vThis = this;

    let ajaxOption = {
        url: vThis.api.url,
        method: "POST",
        dataType: "json",
        data: JSON.stringify({
            "TargetClass": "YunForm",
            "Method": "LoadList_Article",
            "Param": {},
            ///string filter, string keyword, string parentNodeID,string permissionGroupID ,string sourceID, string createTime ,string updateTime, long pageIndex,long pageSize , long formType,long status,string columnArray,string orderby
            "InputParamArray": [null, null, '5B6EE16F-702F-48F9-B1F2-3D3C032E068D', null, null, null, null, item.Index, 10, parseInt("0x0301", 16), item.Status,null,"desc"]
        })
    };
    $.ajax(ajaxOption)
        .done(function (res1, res2) {
            res1.DATA.forEach(p => {
                p.CreateTime = PARAM_UTINITY.FormatDate(p.CreateTime);
            });

            vThis.FormList = vThis.FormList.concat(res1.DATA);
            vThis.CurrentShowFormList = res1.DATA; 
            vThis.Pager1.PagerArray = [];
            for (var k = 0; k < res1.PageCount; k++) {
                vThis.Pager1.PagerArray.push({ Index: k });
            }


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

