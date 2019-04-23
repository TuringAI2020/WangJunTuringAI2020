let vTop = new Vue({
    el: "#top",
    data: {
        app: {
            Name:"应用名称"
        },
        Menu1: [{ ID: "", Name: "新增" }],
        Menu2: [{ ID: "", Name: "新增" },{ ID: "", Name: "注销" }],
    }
});

let vLeft = new Vue({
    el: "#left",
    data: { 
        Menu1: [{ ID: "", Name: "新增" }], 
    }
});


let vNav = new Vue({
    el: "#nav",
    data: {
        func: {
            Name: "功能名称"
        },
        Menu1: [{ ID: "", Name: "新增" }],
    }
});