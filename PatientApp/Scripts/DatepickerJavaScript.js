

$(function () {

    $("#dateTimePicker").datetimepicker({
        format: 'd/m/Y H:i',
        step: 5,
        autoclose: true,
        todayBtn: true,

        changeMonth: true,
        changeYear: true,
        changeTime: true,
        
        minDate: new Date(2019, 0, 1),
        maxDate: new Date(2020, 0, 1),
        showOn: "both",

        // yearRange: "2019:2020",
        //or yearRange:"-10:+10"
        //buttonText: "Select",
        //buttonText: "<i class='glyphicon glyphicon-calendar'></i>"
    });

});