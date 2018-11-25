var YunFav = {};
YunFav.VUE = null;
YunFav.Config = {
    API:"http://localhost:5168/API.ashx"
}
///创建表单
YunFav.BuildForm = function (option) {
 
    YunFav.VUE = app;
     
}
 

///保存变化
YunFav.SaveChanges = function () {
    var msg = {
        TargetClass: "YunFav",
        Method: "SaveToTask",
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
        url: YunFav.Config.API,
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

YunFav.BuildForm();

var app = new Vue({
    el: '#form',
    data: {
        showform: false,
        btn1Text: '收藏',
    },
    methods: {
        SaveChanges:YunFav.SaveChanges
    }
});