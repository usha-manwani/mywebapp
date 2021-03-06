﻿$ = jQuery.noConflict();
$(document).ready(function GetOrgData() {
    var jsonData = JSON.stringify({
        name: ""
    });
    $.ajax({
        type: "POST",
        url: "../Services/getOrganisationData.asmx/GetUserData",
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
    var userid = sessionStorage.getItem("LoginId");
    var col1 = idata[0], col2 = idata[1], col3 = idata[2],
        col4 = idata[3], col5 = idata[4], col6 = idata[5],
        col7 = idata[6], col8 = idata[7]; col9= idata[8]
    $("#usertable tr:gt(0)").remove();
    console.log("got user data ");
    //$("#orgTable:not(:first)").remove();
    for (i = 0; i < col1.length; i++) {
        var row1 = document.createElement("tr");
        row1.classList = "border-bottom hover_btn ";
        row1.style = "padding:10px 0;";
        var column0 = row1.insertCell(0);
        column0.classList = "text-center";
        column0.innerHTML = '<label><input type="checkbox"><i class="fa fa-check jcheckbox"></i></label>';
        var column1 = row1.insertCell(1);
        column1.classList = "text-center";
        column1.innerText = i + 1;
        var column2 = row1.insertCell(2);
        column2.classList = "pl-3";
        column2.innerText = col2[i];
        var column3 = row1.insertCell(3);
        column3.classList = "text-left pl-3";
        column3.innerText = col3[i];
        var column4 = row1.insertCell(4);
        column4.classList = "pl-3";
        column4.innerText = col4[i];
        var column5 = row1.insertCell(5);
        column5.classList = "text-left pl-3";
        column5.innerText = col5[i];
        var column6 = row1.insertCell(6);
        column6.classList = "text-left pl-3 ";
        column6.innerText = col6[i];
        var column7 = row1.insertCell(7);
        column7.classList = "pl-3";
        column7.innerText = col7[i];
        var column8 = row1.insertCell(8);
        column8.classList = "pl-3";
        column8.innerText = col8[i];

        var linktext = '';
        if (col2[i] == userid) {
            linktext = ' <a class="jbtn_xs hover_orange" j-page-box="#jcontent"><i class="fa fa-cog"></i></a> ' +
                '<a class="jbtn_xs hover_red" j-page-box="#jcontent"><i class="fa fa-trash"></i></a>';
        }
        else {
            linktext = ' <a class="JURL jbtn_xs hover_orange show_jmodal" j-page-href="window/alert/data/userAuthSetting.html?Index=' + col2[i] + '" j-page-box="#jcontent"><i class="fa fa-cog"></i></a>' +
                '<a class="JURL jbtn_xs hover_red show_jmodal" j-page-href="window/alert/Delete_User.html?Index=' + col2[i] + '" j-page-box="#jcontent"><i class="fa fa-trash"></i></a>';
        }
        var column9 = row1.insertCell(9);
        column9.classList = "pl-3 hover_btn_td";
        column9.innerHTML = '<a class="JURL jbtn_xs hover_blue show_jmodal" j-page-href="window/alert/data/Edit_UserInfo.html?Index='+col2[i]+'" j-page-box="#jcontent"><i class="fa fa-pencil"></i></a>' +
            '<a class="JURL jbtn_xs hover_blue show_jmodal" j-page-href="window/alert/data/synchro.html" j-page-box="#jcontent"><i class="fa fa-refresh"></i></a> ' +
            linktext;
        
        $("#usertable").find('tbody').append($(row1));
    }

}