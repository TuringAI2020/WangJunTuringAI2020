let option = {}
option.el = "#page";
option.data = {
    page: {
        alert: { text: "OK" }
    },
    api: {
        url:"http://localhost:5168/API.ashx",
    }, 
        ParentNode: { ID: "", Name: "" },
        CurrentNode: { ID: "", Name: "" },
        RootNode: { ID:"F06E86A8-DB7F-4E39-BA1E-C2F620F8D20C"}
 
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
            let zNodes = res1.DATA;
            LoadZtree("#tree1", zNodes,{
                onClick: function (dat1, dat2, dat3, dat4) {
                    vThis.CurrentNode.Name = dat3.Name;
                    vThis.CurrentNode.ID = dat3.ID;
                }
            });
            LoadZtree("#tree2", zNodes, {
                onClick: function (dat1,dat2,dat3,dat4) {
                    vThis.ParentNode.Name = dat3.Name;
                    vThis.ParentNode.ID = dat3.ID;
                }
            });
            LoadZtree("#tree3", zNodes, {
                onClick: function (dat1, dat2, dat3, dat4) {
                    vThis.ParentNode.Name = dat3.Name;
                    vThis.ParentNode.ID = dat3.ID;
                }
            });

        }).fail(function (res1, res2) {

        }).always(function (res1, res2) { });
}

option.methods.SaveCategory = function () {
    let vThis = this; 
    let param = { 
        Name: vThis.CurrentNode.Name,
        ParentID: vThis.ParentNode.ID,
        RootID: vThis.RootNode.ID
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
        
    }).fail(function (res1, res2) {
        }).always(function (res1, res2) {
            vThis.LoadCategotyList();
        });
}

option.methods.Clear = function () {
    let vThis = this;
    vThis.CurrentNode = { ID: "", Name: "" };
    vThis.ParentNode = { ID: "", Name: "" };
    vThis.RootNode = { ID: "", Name: "" };
}



let vue = new Vue(option);

function LoadZtree(el, zNodes,option)
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
            onClick: function (dat1, dat2, dat3,dat4) {
                if (true === PARAMCHECKER.IsFunction(option.onClick)) {
                    option.onClick(dat1, dat2, dat3,dat4);
                }
            }
        }
    };
     
    zNodes.forEach(p => { p.open = true; });

    $.fn.zTree.init($(el), zSetting, zNodes);
}
 