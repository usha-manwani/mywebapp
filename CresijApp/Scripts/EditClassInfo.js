$("#EditClassDetail").off('click').on('click', function () {
    console.log("clicked on save button");
    EditClassData();
});

function OnSuccess(response) {
    var idata = response.d;
    console.log("saved class successfully " + idata);
    $(".jmodal").fadeOut("fast");
    $("#sec_box").load("window/p-data/003.html");
}
function OnErrorCall(respo) {
    console.log(respo);
}
function EditClassData() {
    var myarray = new Array();
    myarray[0] = document.getElementById("className").value;
    myarray[1] = $('input[name=building]:checked').attr("value");
    myarray[2] = $('input[name=floor]:checked').attr("value");
    myarray[3] = document.getElementById("tbseat").value;
    myarray[4] = document.getElementById("ccip").value;
    myarray[5] = document.getElementById("camsip").value;
    myarray[6] = document.getElementById("camnip").value;
    myarray[7] = document.getElementById("deskip").value;
    myarray[8] = document.getElementById("recip").value;
    myarray[9] = document.getElementById("ccmac").value;
    myarray[10] = document.getElementById("ccport").value;
    myarray[11] = document.getElementById("cclogin").value;
    myarray[12] = document.getElementById("ccpass").value;
    myarray[13] = document.getElementById("camsmac").value;
    myarray[14] = document.getElementById("camsport").value;
    myarray[15] = document.getElementById("camslogin").value;
    myarray[16] = document.getElementById("camspass").value;
    myarray[17] = document.getElementById("camnmac").value;
    myarray[18] = document.getElementById("camnport").value;
    myarray[19] = document.getElementById("camnlogin").value;
    myarray[20] = document.getElementById("camnpass").value;
    myarray[21] = document.getElementById("deskmac").value;
    myarray[22] = document.getElementById("deskport").value;
    myarray[23] = document.getElementById("desklogin").value;
    myarray[24] = document.getElementById("deskpass").value;
    myarray[25] = document.getElementById("recmac").value;
    myarray[26] = document.getElementById("recport").value;
    myarray[27] = document.getElementById("reclogin").value;
    myarray[28] = document.getElementById("recpass").value;
    myarray[29] = document.getElementById("callhelp").value;
    myarray[30] = document.getElementById("classid").value;
    var jsonData = JSON.stringify({
        classdata: myarray
    });
    $.ajax({
        type: "POST",
        url: "../Services/SaveOrganisationData.asmx/UpdateClassData",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        error: OnErrorCall
    });

}