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
    FillInformation(idata);
}
function OnErrorCall_(respo) {
    console.log(respo);
}

function FillInformation(idata) {
    var data1 = idata;
    var rowsHtml = [];
    $("#classtable tr:gt(0)").remove();
  
    for (i = 0; i < data1.length; i++) {
        rowsHtml += '<tr class="border-bottom hover_btn" style="padding:10px 0;">' +
            '<td class="text-center"><label><input type="checkbox"><i class="fa fa-check jcheckbox"></i></label></td>' +
            '<td class="pl-3">' + data1[i]["Classname"] + '</td><td class="pl-3">' + data1[i]["Building"] +
            '</td><td class="text-left pl-3">' + data1[i]["Floor"] + '</td><td class="pl-3">' + data1[i]["Seat"] + '</td>' +

            '<td class="text-left pl-3"><span class="jshowinfo"><i class="fa fa-ellipsis-v"></i>' + data1[i]["Ccip"] +
            '<div class="jinfo"><div class="arr_blue_up"></div> <table style="width:280px;"><tr>' +
            '<td><b>MAC:</b> ' + data1[i]["CCmac"] + '</td><td class="pl-3"><b>IP: </b> ' + data1[i]["Ccip"] + ':'
            + data1[i]["CCPort"] + '</td></tr><tr><td><b>用户名: </b> ' + data1[i]["CCuserid"] + '</td>' +
            '<td class="pl-3"><b>密码：</b> ' + data1[i]["CCpass"] + '</td></tr></table></div></span></td>' +

            '<td class="text-left pl-3"><span class="jshowinfo"><i class="fa fa-ellipsis-v"></i>' + data1[i]["CamipS"] +
            '<div class="jinfo"><div class="arr_blue_up"></div> <table style="width:280px;"><tr>' +
            '<td><b>MAC:</b> ' + data1[i]["CamSmac"] + '</td><td class="pl-3"><b>IP: </b> ' + data1[i]["CamipS"] + ':'
            + data1[i]["CamSPort"] + '</td></tr><tr><td><b>用户名: </b> ' + data1[i]["CamSuserid"] + '</td>' +
            '<td class="pl-3"><b>密码：</b> ' + data1[i]["CamSpass"] + '</td></tr></table></div></span></td>' +

            '<td class="text-left pl-3"><span class="jshowinfo"><i class="fa fa-ellipsis-v"></i>' + data1[i]["CamipN"] +
            '<div class="jinfo"><div class="arr_blue_up"></div> <table style="width:280px;"><tr>' +
            '<td><b>MAC:</b> ' + data1[i]["CamNmac"] + '</td><td class="pl-3"><b>IP: </b> ' + data1[i]["CamipN"] + ':'
            + data1[i]["CamNPort"] + '</td></tr><tr><td><b>用户名: </b> ' + data1[i]["CamNuserid"] + '</td>' +
            '<td class="pl-3"><b>密码：</b> ' + data1[i]["CamNpass"] + '</td></tr></table></div></span></td>' +
            
            '<td class="text-left pl-3"><span class="jshowinfo"><i class="fa fa-ellipsis-v"></i>' + data1[i]["DesktopIp"] +
            '<div class="jinfo"><div class="arr_blue_up"></div> <table style="width:280px;"><tr>' +
            '<td><b>MAC:</b> ' + data1[i]["Deskmac"] + '</td><td class="pl-3"><b>IP: </b> ' + data1[i]["DesktopIp"] + ':'
            + data1[i]["DeskPort"] + '</td></tr><tr><td><b>用户名: </b> ' + data1[i]["Deskuserid"] + '</td>' +
            '<td class="pl-3"><b>密码：</b> ' + data1[i]["Deskpass"] + '</td></tr></table></div></span></td>' +
            
            '<td class="text-left pl-3"><span class="jshowinfo"><i class="fa fa-ellipsis-v"></i>' + data1[i]["RecorderIp"] +
            '<div class="jinfo"><div class="arr_blue_up"></div> <table style="width:280px;"><tr>' +
            '<td><b>MAC:</b> ' + data1[i]["Recordermac"] + '</td><td class="pl-3"><b>IP: </b> ' + data1[i]["RecorderIp"] + ':'
            + data1[i]["RecorderPort"] + '</td></tr><tr><td><b>用户名: </b> ' + data1[i]["Recorderuserid"] + '</td>' +
            '<td class="pl-3"><b>密码：</b> ' + data1[i]["Recorderpass"] + '</td></tr></table></div></span></td>' +
            
            '<td class="text-left pl-3">' + data1[i]["CallHelp"] + '</td><td class="pl-3 hover_btn_td">' +
            '<a class="JURL jbtn_xs hover_blue show_jmodal" j-page-href="window/alert/data/Edit_Classroom.html?index=' + data1[i]["Classid"] + '" j-page-box="#jcontent"><i class="fa fa-pencil"></i></a>' +
            '<a class="JURL jbtn_xs hover_red show_jmodal"  j-page-href="window/alert/DeleteClassroom.html?index='+ data1[i]["Classid"] +'" j-page-box="#jcontent"><i class="fa fa-trash"></i></a>'            
    }
    $("#classtable").find('tbody').append(rowsHtml);
}

