$ = jQuery.noConflict();
$(function GetOrgData() {
    var jsonData = JSON.stringify({
        name: ""
    });
    $.ajax({
        type: "POST",
        url: "../Services/getOrganisationData.asmx/GetOpedata",
        //data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
});
function OnSuccess_(response) {
    var idata = response.d;
    FillOrgData(idata);
}
function OnErrorCall_(respo) {
    console.log(respo);
}

function FillOrgData(idata) {
    $("#capitaltable tr:gt(0)").remove();
    console.log("got user data ");   
    var rowshtml = [];
    for (i = 0; i < idata.length; i++) {
        var col = idata[i];
        rowshtml += '<tr class="border-bottom hover_btn" style="padding:10px 0;">' +
            '<td class="text-center"><label><input type="checkbox"><i class="fa fa-check jcheckbox"></i></label></td>' +
            '<td class="pl-3 text-left">' + col["Devicename"] + '</td><td class="pl-3 text-left">' + col["Assetno"] + '</td>' +
            '<td class="pl-3 text-left">' + col["Model"] + '</td><td class="pl-3 text-left">' + col["Spec"] + '</td>' +
            '<td class="pl-3 text-left">' + col["Devicetype"] + '</td><td class="pl-3 text-left">' + col["Price"] + '</td>' +
            '<td class="pl-3 text-left">' + col["Factory"] + '</td><td class="pl-3 text-left">' + col["Mfd"] + '</td>' +
            '<td class="pl-3 text-left">' + col["Dopurchase"] + '</td><td class="pl-3 text-left">' + col["Dod"] + '</td>' +
            '<td class="pl-3 text-left">' + col["Warrantytime"] + '</td><td class="pl-3 text-left">' + col["Locationtype"] + '</td>' +
            '<td class="pl-3 text-left"><i class="fa fa-circle"></i> ' + col["EquipStat"]+'</td>';
    }
    $("#capitaltable").find('tbody').append(rowshtml);
}