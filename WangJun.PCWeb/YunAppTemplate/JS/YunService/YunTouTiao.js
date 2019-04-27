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
    CurrentForm: {},
    CurrentAuthor: {
        Name: "汪俊",
        Description: "自我介绍"
    },
    HotFormList1: [],
    LinkList1: [],
    LinkList2: [],
    SubMenu: {
        "Test": [{ ID: "", Name: "子菜单1" }, { ID: "", Name: "子菜单1" }, { ID: "", Name: "子菜单1" }, { ID: "", Name: "子菜单1" }]
    },
    LeftButtonArray: [{ ID: "", Name: "观点" }, { ID: "", Name: "收藏" }, { ID: "", Name: "分享" }],
    CommentList:[]


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

            vThis.FormList = vThis.FormList.concat(res1.DATA);
        }).fail(function (res1, res2) {

        }).always(function (res1, res2) { });
}

option.methods.LoadHotFormList1 = function () {
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
            var count = 0;
            res1.DATA.forEach(p => {
                if (count <= 5) {
                    vThis.HotFormList1.push(res1.DATA[count++]);
                }
            });
            
         }).fail(function (res1, res2) {

        }).always(function (res1, res2) { });
}

option.methods.LoadLinkList1 = function () {
    let vThis = this;
    vThis.LinkList1 = [{ ID: "", Name: "相关链接", Target: "" }, { ID: "", Name: "相关链接", Target: "" }, { ID: "", Name: "相关链接", Target: "" }, { ID: "", Name: "相关链接", Target: "" }, { ID: "", Name: "相关链接", Target: "" }, { ID: "", Name: "相关链接", Target: "" }, { ID: "", Name: "相关链接", Target: "" }];
}

option.methods.LoadLinkList2 = function () {
    let vThis = this;
    vThis.LinkList2 = [{ ID: "", Name: "相关链接", Target: "" }, { ID: "", Name: "相关链接", Target: "" }, { ID: "", Name: "相关链接", Target: "" }, { ID: "", Name: "相关链接", Target: "" }, { ID: "", Name: "相关链接", Target: "" }, { ID: "", Name: "相关链接", Target: "" }, { ID: "", Name: "相关链接", Target: "" }];

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


option.methods.LoadCommentList = function () {
    let vThis = this;
    var sourceID = PARAMCHECKER.GetUrlQuery("id");

    let ajaxOption = {
        url: vThis.api.url,
        method: "POST",
        dataType: "json",
        data: JSON.stringify({
            "TargetClass": "YunForm",
            "Method": "LoadList_Comment",
            "Param": {},
            "InputParamArray": [sourceID]
        })
    };
    $.ajax(ajaxOption)
        .done(function (res1, res2) { 
            vThis.CommentList = res1.DATA;
        }).fail(function (res1, res2) {

        }).always(function (res1, res2) { });
}

option.methods.SaveComment = function () {
    let vThis = this;
    var sourceID = PARAMCHECKER.GetUrlQuery("id");
    let param = {
        FormType: parseInt("0x0901", 16),
        ValueS01: $("#comment_input").val(),
        SourceID: sourceID
    };


    let ajaxOption = {
        url: "http://localhost:5168/API.ashx",
        method: "POST",
        dataType: "json",
        data: JSON.stringify({
            TargetClass: "YunForm",
            Method: "Save",
            Param: param,
            InputParamArray: []
        })
    };
    $.ajax(ajaxOption)
        .done(function (res1, res2) {
            $("#comment_input").val("")
        }).fail(function (res1, res2) {
        }).always(function (res1, res2) {
            vThis.LoadCategotyList();
        });
}


option.methods.LeftMenuClick = function (item,index) {
    this.CurrentLeftMenu = item;
}


let vue = new Vue(option);
 