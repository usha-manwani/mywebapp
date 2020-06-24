$ = jQuery.noConflict();
$(function GetOrgData() {
    var jsonData = JSON.stringify({
        name: ""
    });
    $.ajax({
        type: "POST",
        url: "../Services/getOrganisationData.asmx/GetClassData",
        //data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
});
function OnSuccess_(response) {
    var idata = response.d;
    console.log(idata);
    FillInformation(idata);
}
function OnErrorCall_(respo) {
    console.log(respo);
}

function FillInformation(idata) {
    console.log("fill class info");
    var rowsHtml = [];
    $("#classtable tr:gt(0)").remove();
  
    for (i = 0; i < idata.length; i++) {
        var data1 = idata[i];
        rowsHtml += '<tr class="border-bottom hover_btn" style="padding:10px 0;">' +
            '<td class="text-center"><label><input type="checkbox"><i class="fa fa-check jcheckbox"></i></label></td>' +
            '<td class="pl-3">' + data1[1] + '</td><td class="pl-3">' + data1[2] +
            '</td><td class="text-left pl-3">' + data1[3] + '</td><td class="pl-3">' + data1[4] + '</td>' +

            '<td class="text-left pl-3"><span class="jshowinfo"><i class="fa fa-ellipsis-v"></i>' + data1[12] +
            '<div class="jinfo"><div class="arr_blue_up"></div> <table style="width:280px;"><tr>' +
            '<td><b>MAC:</b> ' + data1[13] + '</td><td class="pl-3"><b>IP: </b> ' + data1[12]+ 
            '</td></tr></table></div></span></td>' +

            '<td class="text-left pl-3"><span class="jshowinfo"><i class="fa fa-ellipsis-v"></i>' + data1[5] +
            '<div class="jinfo"><div class="arr_blue_up"></div> <table style="width:280px;"><tr>' +
            '<td><b>MAC:</b> ' + data1[7] + '</td><td class="pl-3"><b>IP: </b> ' + data1[5] + ':'
            + data1[9] + '</td></tr><tr><td><b>用户名: </b> ' + data1[10] + '</td>' +
            '<td class="pl-3"><b>密码：</b> ' + data1[11] + '</td></tr></table></div></span></td>' +

            '<td class="text-left pl-3"><span class="jshowinfo"><i class="fa fa-ellipsis-v"></i>' + data1[6] +
            '<div class="jinfo"><div class="arr_blue_up"></div> <table style="width:280px;"><tr>' +
            '<td><b>MAC:</b> ' + data1[8] + '</td><td class="pl-3"><b>IP: </b> ' + data1[6] + ':'
            + data1[9] + '</td></tr><tr><td><b>用户名: </b> ' + data1[10] + '</td>' +
            '<td class="pl-3"><b>密码：</b> ' + data1[11] + '</td></tr></table></div></span></td>' +
            
            '<td class="text-left pl-3"><span class="jshowinfo"><i class="fa fa-ellipsis-v"></i>' + data1[14]+
            '<div class="jinfo"><div class="arr_blue_up"></div> <table style="width:280px;"><tr>' +
            '<td><b>MAC:</b> ' + data1[15] + '</td><td class="pl-3"><b>IP: </b> ' + data1[14] + 
             '</td></tr></table></div></span></td>' +
            
            '<td class="text-left pl-3"><span class="jshowinfo"><i class="fa fa-ellipsis-v"></i>' + data1[16] +
            '<div class="jinfo"><div class="arr_blue_up"></div> <table style="width:280px;"><tr>' +
            '<td><b>MAC:</b> ' + data1[17] + '</td><td class="pl-3"><b>IP: </b> ' + data1[16] +
            '</td></tr></table></div></span></td>' +

            '<td class="text-left pl-3"><span class="jshowinfo"><i class="fa fa-ellipsis-v"></i>' + data1[18] +
            '<div class="jinfo"><div class="arr_blue_up"></div> <table style="width:280px;"><tr>' +
            '<td><b>MAC:</b> ' + data1[19] + '</td><td class="pl-3"><b>IP: </b> ' + data1[18] +
            '</td></tr></table></div></span></td>' +
            
            '<td class="pl-3 hover_btn_td">'+
            '<a class="JURL jbtn_xs hover_blue show_jmodal" j-page-href="window/alert/data/Edit_Classroom.html?index=' + data1[0]+ '" j-page-box="#jcontent"><i class="fa fa-pencil"></i></a>' +
            '<a class="JURL jbtn_xs hover_red show_jmodal"  j-page-href="window/alert/DeleteClassroom.html?index=' + data1[0] + '" j-page-box="#jcontent"><i class="fa fa-trash"></i></a>' +
            '</td></tr>'
    }
    $("#classtable").find('tbody').append(rowsHtml);
}

