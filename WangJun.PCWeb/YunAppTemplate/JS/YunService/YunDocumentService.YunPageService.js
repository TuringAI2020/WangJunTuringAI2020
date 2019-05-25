let vTop = new Vue({
    el: "#top",
    data: {
        app: {
            Name:"文档服务"
        },
        Menu1: [{ ID: "", Name: "其他" }],
        Menu2: [{ ID: "", Name: "注销" }],
    }
});

let vLeft = new Vue({
    el: "#left",
    data: { 
        Menu1: [{ ID: "新文档", Name: "新文档"  }, { ID: "草稿箱", Name: "草稿箱", Status: 2 }, { ID: "已发布", Name: "已发布", Status: 1 }, { ID: "全部文档", Name: "全部文档", Status: 0 }, { ID: "友情链接", Name: "友情链接" }, { ID: "更多", Name: "更多" }], 
    },
    methods: {
        MenuItem_Click: function (item,index) {
            if (true === PARAMCHECKER.IsValid(vue) && true === PARAMCHECKER.IsInt(item.Status)) {
                vue.LoadFormList({ Index: 1, Status: item.Status });
                vNav.LoadMenu(item);
            }
            else {
                vue.LoadForm();
            }
        }
    }
});


let vNav = new Vue({
    el: "#nav",
    data: {
        func: {
            Name: "功能名称"
        },
        Menu1: [{ ID: "已发布", Name: "菜单一" }],
        FuncMenu: {
            "已发布": { ID: "已发布", Name: "已发布", ButtonArray: [{ ID: "新增", Name: "新增" }, { ID: "删除", Name: "删除" }, { ID: "移动到", Name: "移动到" }, { ID: "复制到", Name: "复制到" }, { ID: "编辑", Name: "编辑" }]}
        }
    },
    methods: {
        LoadMenu(leftMenu) {
            let id = leftMenu.ID;
            let selMenu = this.FuncMenu[id];
            this.func.Name = selMenu.Name;
            this.Menu1 = selMenu.ButtonArray;
        },
        MenuItem_Click: function (item, index) {
            if ("新增" == item.ID) {
                vue.LoadForm();
            }
        }
    }
});


window.document.title = vTop.app.Name;