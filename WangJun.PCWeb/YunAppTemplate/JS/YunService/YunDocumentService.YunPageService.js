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
        Menu1: [{ ID: "", Name: "菜单一" }],
    }
});


window.document.title = vTop.app.Name;