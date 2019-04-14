let vTop = new Vue({
    el: "#top",
    data: {
        app: {
            Name:"应用名称"
        },
        Menu1: [{ ID: "", Name: "菜单一" }],
        Menu2: [{ ID: "", Name: "注销" }],
    }
});

let vLeft = new Vue({
    el: "#left",
    data: { 
        Menu1: [{ ID: "", Name: "菜单一" }], 
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