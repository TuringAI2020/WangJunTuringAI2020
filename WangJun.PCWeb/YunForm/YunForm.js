var YunForm = {};
YunForm.VUE = null;
YunForm.BuildForm = function (option) {
 
    YunForm.VUE = app;
}

YunForm.BuildForm();

var app = new Vue({
    el: '#form',
    data: {
        showform: false,
        message: 'Hello Vue!'
    }
});