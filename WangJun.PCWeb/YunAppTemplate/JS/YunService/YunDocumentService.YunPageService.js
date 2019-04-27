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
        Menu1: [{ ID: "", Name: "草稿箱" }, { ID: "", Name: "已发布" }, { ID: "", Name: "全部文档" }, { ID: "", Name: "友情链接" }, { ID: "", Name: "更多" }], 
    },
    methods: {
        MenuItem_Click: function (item,index) {
            $('#exampleModal').modal({ show: true });
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