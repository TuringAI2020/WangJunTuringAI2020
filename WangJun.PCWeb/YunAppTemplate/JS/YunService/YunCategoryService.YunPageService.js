let vTop = new Vue({
    el: "#top",
    data: {
        app: {
            Name:"目录服务"
        },
        Menu1: [{ ID: "", Name: "其他" }],
        Menu2: [{ ID: "", Name: "注销" }],
    }
});

let vLeft = new Vue({
    el: "#left",
    data: { 
        Menu1: [{ ID: "", Name: "+新增应用" }, { ID: "", Name: "汪俊头条" }, { ID: "", Name: "汪俊云笔记" }, { ID: "", Name: "汪俊便签" }, { ID: "", Name: "云权限" }, { ID: "", Name: "汪俊网盘" }, { ID: "", Name: "汪俊文档库" }], 
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