//function connectHub() {
//    
//    //chat = $.connection.myHub;
//    console.log("hubs object chat ");
//    var ip = $("#controlip").val();
//    console.log("ip of control Equip control: " + ip);
    
//};

//connectHub();
function reload_js(src) {
    console.log("reloading");
    $('script[src="' + src + '"]').remove();
    $('<script>').attr('src', src).appendTo('body');
}
reload_js('../../../Scripts/GroupControlMachine.js');

$(document).ready(function () {


    var adata;
    adata = $("#controlip").val();
    //adata[1] = $('#floorlist option:selected').text();
    var jsonData = JSON.stringify({
        data: adata
    });
    $.ajax({
        type: "POST",
        url: "../Services/GetOrganisationData.asmx/GetClassByIP",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessClassIp,
        error: OnErrorCall_
    });
    
    console.log("document done");
    console.log("sssist " + $("#assistdivnumber").val());
    var div = $("#assistdivnumber").val();
    if (div == 1) {
        var div = document.getElementsByName("envdiv")[0];
        div.style.display = "none";
        var div1 = document.getElementsByName("assistdiv")[0];
        div1.style.display = "block";
    }
    else if (div == 2) {
        var div = document.getElementsByName("envdiv")[0];
        div.style.display = "block";
        var div1 = document.getElementsByName("assistdiv")[0];
        div1.style.display = "none";
    }

    
})

function OnSuccessClassIp(response) {
    var data = response.d;
    var classname = data[0];
    $("#classforip").val(classname);
    var classforip = $("#classforip").val();
    $("#classnameequipmenu02").text(classforip);
    $("#classnameright").text(classforip);
    $("#spanclass002").text(classforip);
    $("#spanip002").text($("#controlip").val());
}
function OnErrorCall_(respo) {
    console.log(respo);
}