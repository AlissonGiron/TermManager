
var t;

window.onload = function () {

    t = new Vue({
        el: "#app",
        data: {
            message: "teste"
        },
        components: {
            numericTextBox: Vue.component('ntb', {
                props: {
                    name:{},
                },
                data: function() {
                    return { 
                        currentValue: 0
                    }
                },
                template: '#numericTextBoxTmpl'
            })
        }
    });
}