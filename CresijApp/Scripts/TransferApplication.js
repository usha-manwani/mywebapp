$ = jQuery.noConflict();
$(function () {
    var v = $("#schid").val();
    console.log(v);
    var ar = v.split("&");
    var classname = ar[0].replace("%20", ' ');
    var coursename = ar[1].replace("%20", ' ');
    console.log(classname);
    console.log(coursename);

})