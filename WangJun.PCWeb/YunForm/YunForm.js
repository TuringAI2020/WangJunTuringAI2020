var YunForm = {};
YunForm.VUE = null;
YunForm.Config = {
    API:"http://localhost:5168/API.ashx"
}
///创建表单
YunForm.BuildForm = function (option) {
 
    YunForm.VUE = app;
     
}
 

///保存变化
YunForm.SaveChanges = function (data) {
    alert("OK");
    var msg = {
        TargetClass: "YunForm",
        Method: "Save",
        IsStaticClass: false,
        IsStaticMethod: false,
        Param:null
    };
    var param = {};
    $('[data-group="1"]').each(function () {
        var property = $(this).attr("data-property");
        var val = $(this).val();
        param[property] = val;
    });

    msg.Param = param;

    var option = {
        url: YunForm.Config.API,
        method: "POST",
        data:JSON.stringify( msg),
        error: function () { },
        success: function (data, textStatus) {
            console.log(data);
        },
        timeout: function () { },

    };
    $.ajax(option);
}

YunForm.BuildForm();

var app = new Vue({
    el: '#form',
    data: {
        showform: false,
        message: 'Hello Vue!',
    },
    methods: {
        SaveChanges:YunForm.SaveChanges
    }
});