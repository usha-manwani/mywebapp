$ = jQuery.noConflict();
$(function GetOrgData() {
    var jsonData = JSON.stringify({
        name: ""
    });
    $.ajax({
        type: "POST",
        url: "../Services/getOrganisationData.asmx/GetOrgDataBuilding",
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
    
    
    $("#orgTable tr:gt(0)").remove();
    var innerhtml = [];
    //$("#orgTable:not(:first)").remove();
    for (i = 0; i < idata.length; i++) {
        var data = idata[i];
        innerhtml += '<tr class="border-bottom hover_btn" style="padding:10px 0;">' +
            '<td class="text-center"><label><input type="checkbox"><i class="fa fa-check jcheckbox"></i></label></td>' +
            '<td class="text-center">' + data[0] + '</td><td class="pl-3">' + data[1] + '</td>' +
            '<td class="pl-3">' + data[2] + '</td>' +
            '<td class="text-left pl-3">' + data[3] + '</td><td class="text-left pl-3">' + data[4] + '</td>' +
            '<td class="pl-3">' + data[5] + '</td><td class="pl-3">' + data[6] + '</td>' +
            '<td></td>'+ // column for showing floor
            '<td class="pl-3 hover_btn_td">' +
            '<a class=" jbtn_xs hover_blue show_jmodal JURL" j-page-href="window/alert/data/EditOrganisation.html?index=' + data[0] +
            '" j-page-box="#jcontent"><i class="fa fa-pencil"></i></a>' +
            '<a class="JURL jbtn_xs hover_red show_jmodal" j-page-href="window/alert/DeleteOrg.html?index=' + data[0] +
            '" j-page-box="#jcontent"><i class="fa fa-trash"></i></a></td></tr>'
        //var row1 = document.createElement("tr");
        //row1.classList = "border-bottom hover_btn ";
        //row1.style = "padding:10px 0;";
        //var column0 = row1.insertCell(0);
        //column0.classList = "text-center";
        //column0.innerHTML = '<label><input type="checkbox"><i class="fa fa-check jcheckbox"></i></label>';
        
        //var column1 = row1.insertCell(1);
        //column1.classList = "text-center";
        //column1.innerText = col1[i];
        //var column2 = row1.insertCell(2);
        //column2.classList = "pl-3";
        //column2.innerText = col2[i];
        //var column3 = row1.insertCell(3);
        //column3.classList = "text-left pl-3";
        //column3.innerText = col3[i];
        //var column4 = row1.insertCell(4);
        //column4.classList = "pl-3";
        //column4.innerText = col4[i];
        //var column5 = row1.insertCell(5);
        //column5.classList = "text-left pl-3";
        //column5.innerText = col5[i];
        //var column6 = row1.insertCell(6);
        //column6.classList = "text-left pl-3";
        //column6.innerText = col6[i];
        //var column7 = row1.insertCell(7);
        //column7.classList = "pl-3";
        //column7.innerText = col7[i];
        //var column8 = row1.insertCell(8);
        //column8.classList = "pl-3";
        //column8.innerText = col8[i];

        //var column9 = row1.insertCell(9);
        //column9.classList = "pl-3 hover_btn_td";
        //column9.innerHTML = '<a class=" jbtn_xs hover_blue show_jmodal JURL" j-page-href="window/alert/data/EditOrganisation.html?index='+col1[i]+'" j-page-box="#jcontent"><i class="fa fa-pencil"></i></a>' +
        //    '<a class="JURL jbtn_xs hover_red show_jmodal" j-page-href="window/alert/DeleteOrg.html?index=' + col1[i] +'" j-page-box="#jcontent"><i class="fa fa-trash"></i></a>';

        //console.log("got org data " + i);
       
    }

    $("#orgTable").find('tbody').append(innerhtml);

}