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
    FillClassData(idata);
}
function OnErrorCall_(respo) {
    console.log(respo);
}

function FillOrgData(idata) {

    var col1 = idata[0], col2 = idata[1], col3 = idata[2],
        col4 = idata[3], col5 = idata[4], col6 = idata[5],
        col7 = idata[6], col8 = idata[7], col9 = idata[8],
        col10 = idata[9], col11 = idata[10];
    $("#classtable tr:gt(0)").remove();
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
        column1.innerText = col2[i];
        var column2 = row1.insertCell(2);
        column2.classList = "pl-3";
        column2.innerText = col3[i];
        var column3 = row1.insertCell(3);
        column3.classList = "text-left pl-3";
        column3.innerText = col4[i];
        var column4 = row1.insertCell(4);
        column4.classList = "pl-3";
        column4.innerText = col5[i];
        var column5 = row1.insertCell(5);
        column5.classList = "text-left pl-3";
        //column5.innerText = col5[i];
        column5.innerHTML = ' <span class="jshowinfo">'+
            '<i class="fa fa-ellipsis-v"></i>'+col6[i]+
            '<div class="jinfo"><div class="arr_blue_up"></div>'+
            '<table style="width:280px;"><tr><td><b>MAC:</b> 5D 6R 3S 1W</td>'+
            '<td class="pl-3"><b>IP: </b> 192.168.100.112:3306</td></tr>'+
            '<tr><td><b>???: </b> zhangsf001</td>' +
            '<td class="pl-3"><b>??:</b> ok2001</td></tr></table></div></span>';
        var column6 = row1.insertCell(6);
        column6.classList = "text-left pl-3";
        //column6.innerText = col6[i];
        column6.innerHTML = ' <span class="jshowinfo">' +
            '<i class="fa fa-ellipsis-v"></i>' + col7[i] +
            '<div class="jinfo"><div class="arr_blue_up"></div>' +
            '<table style="width:280px;"><tr><td><b>MAC:</b> 5D 6R 3S 1W</td>' +
            '<td class="pl-3"><b>IP: </b> 192.168.100.112:3306</td></tr>' +
            '<tr><td><b>???: </b> zhangsf001</td>' +
            '<td class="pl-3"><b>??:</b> ok2001</td></tr></table></div></span>';
        var column7 = row1.insertCell(7);
        column7.classList = "text-left pl-3";
       // column7.innerText = col7[i];
        column7.innerHTML = ' <span class="jshowinfo">' +
            '<i class="fa fa-ellipsis-v"></i>' + col8[i] +
            '<div class="jinfo"><div class="arr_blue_up"></div>' +
            '<table style="width:280px;"><tr><td><b>MAC:</b> 5D 6R 3S 1W</td>' +
            '<td class="pl-3"><b>IP: </b> 192.168.100.112:3306</td></tr>' +
            '<tr><td><b>???: </b> zhangsf001</td>' +
            '<td class="pl-3"><b>??:</b> ok2001</td></tr></table></div></span>';
        var column8 = row1.insertCell(8);
        column8.classList = "text-left pl-3";
       // column8.innerText = col8[i];
        column8.innerHTML = ' <span class="jshowinfo">' +
            '<i class="fa fa-ellipsis-v"></i>' + col9[i] +
            '<div class="jinfo"><div class="arr_blue_up"></div>' +
            '<table style="width:280px;"><tr><td><b>MAC:</b> 5D 6R 3S 1W</td>' +
            '<td class="pl-3"><b>IP: </b> 192.168.100.112:3306</td></tr>' +
            '<tr><td><b>???: </b> zhangsf001</td>' +
            '<td class="pl-3"><b>??:</b> ok2001</td></tr></table></div></span>';
        var column9 = row1.insertCell(9);
        column9.classList = 'text-left pl-3';
        column9.innerHTML = ' <span class="jshowinfo">' +
            '<i class="fa fa-ellipsis-v"></i>' + col10[i] +
            '<div class="jinfo"><div class="arr_blue_up"></div>' +
            '<table style="width:280px;"><tr><td><b>MAC:</b> 5D 6R 3S 1W</td>' +
            '<td class="pl-3"><b>IP: </b> 192.168.100.112:3306</td></tr>' +
            '<tr><td><b>???: </b> zhangsf001</td>' +
            '<td class="pl-3"><b>??:</b> ok2001</td></tr></table></div></span>';
        var column10 = row1.insertCell(10);
        column10.classList = 'text-left pl-3';
        column10.innerHTML =  col11[i] ;

        var column11 = row1.insertCell(11);
        column11.classList = "pl-3 hover_btn_td";
        column11.innerHTML = '<a class="JURL jbtn_xs hover_blue show_jmodal" j-page-href="window/alert/data/edit.html" j-page-box="#jcontent"><i class="fa fa-pencil"></i></a>' +
            '<a class="JURL jbtn_xs hover_red show_jmodal" j-page-href="window/alert/confer_delete.html" j-page-box="#jcontent"><i class="fa fa-trash"></i></a>';
        console.log("got data " + i);
        $("#classtable").find('tbody').append($(row1));
    }

}

function FillClassData(idata) {

    var data1 = idata[0];
    var data2 = idata[1];
    console.log("got classroom data");
    $("#classtable tr:gt(0)").remove();
    for (i = 0; i < data1.length; i++) {
        var row1 = document.createElement("tr");
        row1.classList = "border-bottom hover_btn ";
        row1.style = "padding:10px 0;";
        var column0 = row1.insertCell(0);
        column0.classList = "text-center";
        column0.innerHTML = '<label><input type="checkbox"><i class="fa fa-check jcheckbox"></i></label>';
        var column1 = row1.insertCell(1);
        column1.classList = "text-center";
        column1.innerText = data1[i]["Classname"];
        var column2 = row1.insertCell(2);
        column2.classList = "pl-3";
        column2.innerText = data1[i]["Building"];
        var column3 = row1.insertCell(3);
        column3.classList = "text-left pl-3";
        column3.innerText = data1[i]["Floor"];
        var column4 = row1.insertCell(4);
        column4.classList = "pl-3";
        column4.innerText = data1[i]["Seat"];

        var column5 = row1.insertCell(5);
        column5.classList = "text-left pl-3";
        var index = getIndexOfIp(data1[i]["Ccip"], data2);
        column5.innerHTML = '<span class="jshowinfo">' +
                '<i class="fa fa-ellipsis-v"></i>' + data1[i]["Ccip"] +
                '<div class="jinfo"><div class="arr_blue_up"></div>' +
                '<table style="width:280px;"><tr><td><b>MAC:</b> ' + data2[index]["Mac"] + '</td>' +
                '<td class="pl-3"><b>IP: </b> ' + data2[index]["Ip"] + ':' + data2[index]["Port"] + '</td></tr>' +
                '<tr><td><b>???: </b> ' + data2[index]["Userid"] + '</td>' +
                '<td class="pl-3"><b>??:</b> ' + data2[index]["Pass"] + '</td></tr></table></div></span>';

        var column6 = row1.insertCell(6);
        column6.classList = "text-left pl-3";
        index = getIndexOfIp(data1[i]["CamipS"], data2);
        column6.innerHTML = '<span class="jshowinfo">' +
            '<i class="fa fa-ellipsis-v"></i>' + data1[i]["CamipS"] +
            '<div class="jinfo"><div class="arr_blue_up"></div>' +
            '<table style="width:280px;"><tr><td><b>MAC:</b> ' + data2[index]["Mac"] + '</td>' +
            '<td class="pl-3"><b>IP: </b> ' + data2[index]["Ip"] + ':' + data2[index]["Port"] + '</td></tr>' +
            '<tr><td><b>???: </b> ' + data2[index]["Userid"] + '</td>' +
            '<td class="pl-3"><b>??:</b> ' + data2[index]["Pass"] + '</td></tr></table></div></span>';

        var column7 = row1.insertCell(7);
        column7.classList = "text-left pl-3";
        index = getIndexOfIp(data1[i]["CamipN"], data2);
        column7.innerHTML = '<span class="jshowinfo">' +
            '<i class="fa fa-ellipsis-v"></i>' + data1[i]["CamipN"] +
            '<div class="jinfo"><div class="arr_blue_up"></div>' +
            '<table style="width:280px;"><tr><td><b>MAC:</b> ' + data2[index]["Mac"] + '</td>' +
            '<td class="pl-3"><b>IP: </b> ' + data2[index]["Ip"] + ':' + data2[index]["Port"] + '</td></tr>' +
            '<tr><td><b>???: </b> ' + data2[index]["Userid"] + '</td>' +
            '<td class="pl-3"><b>??:</b> ' + data2[index]["Pass"] + '</td></tr></table></div></span>';

        var column8 = row1.insertCell(8);
        column8.classList = "text-left pl-3";
        index = getIndexOfIp(data1[i]["DesktopIp"], data2);
        column8.innerHTML = '<span class="jshowinfo">' +
            '<i class="fa fa-ellipsis-v"></i>' + data1[i]["DesktopIp"] +
            '<div class="jinfo"><div class="arr_blue_up"></div>' +
            '<table style="width:280px;"><tr><td><b>MAC:</b> ' + data2[index]["Mac"] + '</td>' +
            '<td class="pl-3"><b>IP: </b> ' + data2[index]["Ip"] + ':' + data2[index]["Port"] + '</td></tr>' +
            '<tr><td><b>???: </b> ' + data2[index]["Userid"] + '</td>' +
            '<td class="pl-3"><b>??:</b> ' + data2[index]["Pass"] + '</td></tr></table></div></span>';

        var column9 = row1.insertCell(9);
        column9.classList = 'text-left pl-3';
        index = getIndexOfIp(data1[i]["RecorderIp"], data2);
        column9.innerHTML = '<span class="jshowinfo">' +
            '<i class="fa fa-ellipsis-v"></i>' + data1[i]["RecorderIp"] +
            '<div class="jinfo"><div class="arr_blue_up"></div>' +
            '<table style="width:280px;"><tr><td><b>MAC:</b> ' + data2[index]["Mac"] + '</td>' +
            '<td class="pl-3"><b>IP: </b> ' + data2[index]["Ip"] + ':' + data2[index]["Port"] + '</td></tr>' +
            '<tr><td><b>???: </b> ' + data2[index]["Userid"] + '</td>' +
            '<td class="pl-3"><b>??:</b> ' + data2[index]["Pass"] + '</td></tr></table></div></span>';

        var column10 = row1.insertCell(10);
        column10.classList = 'text-left pl-3';
        column10.innerHTML = data1[i]["CallHelp"];
        var column11 = row1.insertCell(11);
        column11.classList = "pl-3 hover_btn_td";
        column11.innerHTML = '<a class="JURL jbtn_xs hover_blue show_jmodal" j-page-href="window/alert/data/edit.html" j-page-box="#jcontent"><i class="fa fa-pencil"></i></a>' +
            '<a class="JURL jbtn_xs hover_red show_jmodal" j-page-href="window/alert/confer_delete.html" j-page-box="#jcontent"><i class="fa fa-trash"></i></a>';
        console.log("got data " + i);
        $("#classtable").find('tbody').append($(row1));
    }

}

function getIndexOfIp(ip, data) {
    for (j = 0; j < data.length; j++) {
        if (data[j]["Ip"] == ip) {
            return j;
        }
    }
}
