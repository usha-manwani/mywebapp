$ = jQuery.noConflict();
$(function GetOrgData() {
    var jsonData = JSON.stringify({
        name: ""
    });
    $.ajax({
        type: "POST",
        url: "../Services/getOrganisationData.asmx/GetClassData",
        data: JSON.stringify({data:{ pageIndex:"1",pageSize:"50"}}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var idata = response.d.value;  
            /*
            data1[0]=id,data1[1]=Classname,data1[2]=Building,data1[3]=Floor, data1[4]=Seat, data1[5]=CamipT,
            data1[6]=CamIpS,data1[7]=CamTmac,data1[8]=CamSmac,data1[9]=Camport,data1[10]=Camuserid,
            data1[11] =CamPass, data1[12]=CcIp,data1[13=Ccmac,data1[14]=Desktopip,data1[15]=Desktopmac, data1[16]=Recorderip,data1[17]=recordermac,data1[18]=calhelpip,data1[19]=callhelpmac
            Building: "Building 3"
Ccmac: "12:22:22:23"
CallHelpIP: "12121221"
CallHelpmac: ""
Camport: "1200"
CamSmac: "12:22:22:12"
CamTmac: "12:22:22:22"
CamIpS: "172.168.31.13"
CamipT: "172.168.31.13"
CamPass: "admin123"
Camuserid: "admin"
CcIp: "172.168.32.13"
Classid: "2"
Classname: "3-101"
Desktopip: "172.168.31.14"
Desktopmac: "12:22:54:42"
Floor: "2nd"
Recorderip: "172.168.31.15"
Recordermac: "12:12:32:11"
Seat: "50"
            */
            for (i = 0; i < idata.length; i++) {
                console.log(idata[i]["Building"], 22222222222)
                var row1 = document.createElement("tr");
                row1.classList = "border-bottom hover_btn ";
                row1.style = "padding:10px 0;";
                var column0 = row1.insertCell(0);
                column0.classList = "text-center";
                column0.innerHTML = '<label><input type="checkbox"><i class="fa fa-check jcheckbox"></i></label>';
                var column1 = row1.insertCell(1);
                column1.classList = "text-center";
                column1.innerText = idata[i]["Building"];
                var column2 = row1.insertCell(2);
                column2.classList = "pl-3";
                column2.innerText = idata[i]["Floor"];
                var column3 = row1.insertCell(3);
                column3.classList = "text-left pl-3";
                column3.innerText = idata[i]["Seat"];
                var column4 = row1.insertCell(4);
                column4.classList = "pl-3";
                column4.innerText = idata[i]["CamipT"];
                var column5 = row1.insertCell(5);
                column5.classList = "text-left pl-3";
                //column5.innerText = idata[i]["CamipT"];
                column5.innerHTML = ' <span class="jshowinfo">'+
                    '<i class="fa fa-ellipsis-v"></i>'+idata[i]["CamIpS"]+
                    '<div class="jinfo"><div class="arr_blue_up"></div>'+
                    '<table style="width:280px;"><tr><td><b>MAC:</b> 5D 6R 3S 1W</td>'+
                    '<td class="pl-3"><b>IP: </b> 192.168.100.112:3306</td></tr>'+
                    '<tr><td><b>???: </b> zhangsf001</td>' +
                    '<td class="pl-3"><b>??:</b> ok2001</td></tr></table></div></span>';
                var column6 = row1.insertCell(6);
                column6.classList = "text-left pl-3";
                //column6.innerText = idata[i]["CamIpS"];
                column6.innerHTML = ' <span class="jshowinfo">' +
                    '<i class="fa fa-ellipsis-v"></i>' + idata[i]["CamTmac"] +
                    '<div class="jinfo"><div class="arr_blue_up"></div>' +
                    '<table style="width:280px;"><tr><td><b>MAC:</b> 5D 6R 3S 1W</td>' +
                    '<td class="pl-3"><b>IP: </b> 192.168.100.112:3306</td></tr>' +
                    '<tr><td><b>???: </b> zhangsf001</td>' +
                    '<td class="pl-3"><b>??:</b> ok2001</td></tr></table></div></span>';
                var column7 = row1.insertCell(7);
                column7.classList = "text-left pl-3";
               // column7.innerText = idata[i]["CamTmac"];
                column7.innerHTML = ' <span class="jshowinfo">' +
                    '<i class="fa fa-ellipsis-v"></i>' + idata[i]["CamSmac"] +
                    '<div class="jinfo"><div class="arr_blue_up"></div>' +
                    '<table style="width:280px;"><tr><td><b>MAC:</b> 5D 6R 3S 1W</td>' +
                    '<td class="pl-3"><b>IP: </b> 192.168.100.112:3306</td></tr>' +
                    '<tr><td><b>???: </b> zhangsf001</td>' +
                    '<td class="pl-3"><b>??:</b> ok2001</td></tr></table></div></span>';
                var column8 = row1.insertCell(8);
                column8.classList = "text-left pl-3";
               // column8.innerText = idata[i]["CamSmac"];
                column8.innerHTML = ' <span class="jshowinfo">' +
                    '<i class="fa fa-ellipsis-v"></i>' + idata[i]["Camport"] +
                    '<div class="jinfo"><div class="arr_blue_up"></div>' +
                    '<table style="width:280px;"><tr><td><b>MAC:</b> 5D 6R 3S 1W</td>' +
                    '<td class="pl-3"><b>IP: </b> 192.168.100.112:3306</td></tr>' +
                    '<tr><td><b>???: </b> zhangsf001</td>' +
                    '<td class="pl-3"><b>??:</b> ok2001</td></tr></table></div></span>';
                var column9 = row1.insertCell(9);
                column9.classList = 'text-left pl-3';
                column9.innerHTML = ' <span class="jshowinfo">' +
                    '<i class="fa fa-ellipsis-v"></i>' + idata[i]["Camuserid"] +
                    '<div class="jinfo"><div class="arr_blue_up"></div>' +
                    '<table style="width:280px;"><tr><td><b>MAC:</b> 5D 6R 3S 1W</td>' +
                    '<td class="pl-3"><b>IP: </b> 192.168.100.112:3306</td></tr>' +
                    '<tr><td><b>???: </b> zhangsf001</td>' +
                    '<td class="pl-3"><b>??:</b> ok2001</td></tr></table></div></span>';
                var column10 = row1.insertCell(10);
                column10.classList = 'text-left pl-3';
                column10.innerHTML =  idata[i]["CamPass"] ;
        
                var column11 = row1.insertCell(11);
                column11.classList = "pl-3 hover_btn_td";
                column11.innerHTML = '<a class="JURL jbtn_xs hover_blue show_jmodal" j-page-href="window/alert/data/edit.html" j-page-box="#jcontent"><i class="fa fa-pencil"></i></a>' +
                    '<a class="JURL jbtn_xs hover_red show_jmodal" j-page-href="window/alert/confer_delete.html" j-page-box="#jcontent"><i class="fa fa-trash"></i></a>';
                console.log("got data " + i);
                $("#classtable").append($(row1));
            }
        
        },
        error: OnErrorCall_
    });
});
function OnErrorCall_(respo) {
    console.log(respo);
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
        var index = getIndexOfIp(data1[i]["CcIp"], data2);
        column5.innerHTML = '<span class="jshowinfo">' +
                '<i class="fa fa-ellipsis-v"></i>' + data1[i]["CcIp"] +
                '<div class="jinfo"><div class="arr_blue_up"></div>' +
                '<table style="width:280px;"><tr><td><b>MAC:</b> ' + data2[index]["Mac"] + '</td>' +
                '<td class="pl-3"><b>IP: </b> ' + data2[index]["Ip"] + ':' + data2[index]["Port"] + '</td></tr>' +
                '<tr><td><b>???: </b> ' + data2[index]["Userid"] + '</td>' +
                '<td class="pl-3"><b>??:</b> ' + data2[index]["Pass"] + '</td></tr></table></div></span>';

        var column6 = row1.insertCell(6);
        column6.classList = "text-left pl-3";
        index = getIndexOfIp(data1[i]["CamIpS"], data2);
        column6.innerHTML = '<span class="jshowinfo">' +
            '<i class="fa fa-ellipsis-v"></i>' + data1[i]["CamIpS"] +
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
        index = getIndexOfIp(data1[i]["Desktopip"], data2);
        column8.innerHTML = '<span class="jshowinfo">' +
            '<i class="fa fa-ellipsis-v"></i>' + data1[i]["Desktopip"] +
            '<div class="jinfo"><div class="arr_blue_up"></div>' +
            '<table style="width:280px;"><tr><td><b>MAC:</b> ' + data2[index]["Mac"] + '</td>' +
            '<td class="pl-3"><b>IP: </b> ' + data2[index]["Ip"] + ':' + data2[index]["Port"] + '</td></tr>' +
            '<tr><td><b>???: </b> ' + data2[index]["Userid"] + '</td>' +
            '<td class="pl-3"><b>??:</b> ' + data2[index]["Pass"] + '</td></tr></table></div></span>';

        var column9 = row1.insertCell(9);
        column9.classList = 'text-left pl-3';
        index = getIndexOfIp(data1[i]["Recorderip"], data2);
        column9.innerHTML = '<span class="jshowinfo">' +
            '<i class="fa fa-ellipsis-v"></i>' + data1[i]["Recorderip"] +
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
        $("#classtable").append($(row1));
    }

}

function getIndexOfIp(ip, data) {
    for (j = 0; j < data.length; j++) {
        if (data[j]["Ip"] == ip) {
            return j;
        }
    }
}
