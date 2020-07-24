var chat;
$(document).ready(function () {
    console.log("system setting config page");
    //$.ajax({
    //    type: "POST",
    //    url: "../Services/ScheduleData.asmx/GetBuilding",
    //    //data: jsonData,
    //    contentType: "application/json; charset=utf-8",
    //    dataType: "json",
    //    success: OnSuccessBuilding,
    //    error: OnErrorCall_
    //});
   
    chat = $.connection.myHub;
    $.connection.hub.start({ waitForPageLoad: false }).done(function () {
        

    });
    $("#btnwriteConfig").off("click").on('click', function () {
        var slist = [];
        $('input[name="classlist"]').each(function () {
            if (this.checked) {
                slist.push("'" + $(this).parent().text().trim() + "'");
            }

        });
        var clist = slist.join(',');
        var jsonData = JSON.stringify({
            classlist: clist
        });
        $.ajax({
            type: "POST",
            url: "../Services/GetSetSystemConfigInfo.asmx/GetIpByClass",
            data: jsonData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessIP,
            error: OnErrorCall_
        });
        console.log("click write button");
        var data1 = "8b b9 ";
        var data = "00 1E 03 03 ";

        var delaymins = document.getElementById('delaymin');
        data = data + $("delaymin").text() + " ";

        if (document.getElementById('cb3').checked == true) {
            data = data + "01 ";
        }
        else {
            data = data + "00 ";
        }
        if (document.getElementById('cb1').checked == true) {
            data = data + "01 ";
        }
        else {
            data = data + "00 ";
        }
        if (document.getElementById('cb2').checked == true) {
            data = data + "01 ";
        }
        else {
            data = data + "00 ";
        }
        if (document.getElementById('cb4').checked == true) {
            data = data + "01 ";
        }
        else {
            data = data + "00 ";
        }
        if (document.getElementById('cb5').checked == true) {
            data = data + "01 ";
        }
        else {
            data = data + "00 ";
        }
        if (document.getElementById('cb6').checked == true) {
            data = data + "01 ";
        }
        else {
            data = data + "00 ";
        }
        if (document.getElementById('cb7').checked == true) {
            data = data + "01 ";
        }
        else {
            data = data + "00 ";
        }
        if (document.getElementById('cb8').checked == true) {
            data = data + "01 ";
        }
        else {
            data = data + "00 ";
        }
        if (document.getElementById('cb9').checked == true) {
            data = data + "01 ";
        }
        else {
            data = data + "00 ";
        }
        if (document.getElementById('cb10').checked == true) {
            data = data + "01 ";
        }
        else {
            data = data + "00 ";
        }
        if (document.getElementById('cb11').checked == true) {
            data = data + "01 ";
        }
        else {
            data = data + "00 ";
        }
        if (document.getElementById('cb14').checked == true) {
            data = data + "01 ";
        }
        else {
            data = data + "00 ";
        }
        if (document.getElementById('cb12').checked == true) {
            data = data + "01 ";
        }
        else {
            data = data + "00 ";
        }
        if (document.getElementById('cb13').checked == true) {
            data = data + "01 ";
        }
        else {
            data = data + "00 ";
        }
        if (document.getElementById('cb15').checked == true) {
            data = data + "01 ";
        }
        else {
            data = data + "00 ";
        }
        if (document.getElementById('cb16').checked == true) {
            data = data + "01 ";
        }
        else {
            data = data + "00 ";
        }
        if (document.getElementById('cb17').checked == true) {
            data = data + "01 ";
        }
        else {
            data = data + "00 ";
        }
        if (document.getElementById('cb18').checked == true) {
            data = data + "01 ";
        }
        else {
            data = data + "00 ";
        }
        var delaysecs = document.getElementById("delaysec");
        data = data + $("delaysec").text() + " ";
        if (document.getElementById('cb19').checked == true) {
            data = data + "01 ";
        }
        else {
            data = data + "00 ";
        }
        if (document.getElementById('cb20').checked == true) {
            data = data + "01 ";
        }
        else {
            data = data + "00 ";
        }
        if (document.getElementById('cb21').checked == true) {
            data = data + "01 ";
        }
        else {
            data = data + "00 ";
        }
        //***alarm values***//

        data = data + "00" + " ";

        data = data + "00" + " ";

        data = data + "00" + " ";

        data = data + "00" + " ";
        //***calculate checksum***//
        var chk = data.split(' ');
        var chksum = 0;
        for (i = 0; i < chk.length - 1; i++) {
            chksum = chksum + parseInt(chk[i], 16);
        };
        chksum = chksum & 255;
        var checksum = chksum.toString(16);
        data = data1 + data + checksum;

    });
});

function SendConfigToMachine(iplist) {
    console.log(iplist);
    var data1 = "8b b9 ";
    var data = "00 1E 03 03 ";

    
    //data = data + $("#delaymin").text() + " ";
    var minutes = $("#delaymin").text().trim();
    
    data = data + minutes + " ";

    if (document.getElementById('cb3').checked == true) {
        data = data + "01 ";
    }
    else {
        data = data + "00 ";
    }
    if (document.getElementById('cb1').checked == true) {
        data = data + "01 ";
    }
    else {
        data = data + "00 ";
    }
    if (document.getElementById('cb2').checked == true) {
        data = data + "01 ";
    }
    else {
        data = data + "00 ";
    }
    if (document.getElementById('cb4').checked == true) {
        data = data + "01 ";
    }
    else {
        data = data + "00 ";
    }
    if (document.getElementById('cb5').checked == true) {
        data = data + "01 ";
    }
    else {
        data = data + "00 ";
    }
    if (document.getElementById('cb6').checked == true) {
        data = data + "01 ";
    }
    else {
        data = data + "00 ";
    }
    if (document.getElementById('cb7').checked == true) {
        data = data + "01 ";
    }
    else {
        data = data + "00 ";
    }
    if (document.getElementById('cb8').checked == true) {
        data = data + "01 ";
    }
    else {
        data = data + "00 ";
    }
    if (document.getElementById('cb9').checked == true) {
        data = data + "01 ";
    }
    else {
        data = data + "00 ";
    }
    if (document.getElementById('cb10').checked == true) {
        data = data + "01 ";
    }
    else {
        data = data + "00 ";
    }
    if (document.getElementById('cb11').checked == true) {
        data = data + "01 ";
    }
    else {
        data = data + "00 ";
    }
    if (document.getElementById('cb14').checked == true) {
        data = data + "01 ";
    }
    else {
        data = data + "00 ";
    }
    if (document.getElementById('cb12').checked == true) {
        data = data + "01 ";
    }
    else {
        data = data + "00 ";
    }
    if (document.getElementById('cb13').checked == true) {
        data = data + "01 ";
    }
    else {
        data = data + "00 ";
    }
    if (document.getElementById('cb15').checked == true) {
        data = data + "01 ";
    }
    else {
        data = data + "00 ";
    }
    if (document.getElementById('cb16').checked == true) {
        data = data + "01 ";
    }
    else {
        data = data + "00 ";
    }
    if (document.getElementById('cb17').checked == true) {
        data = data + "01 ";
    }
    else {
        data = data + "00 ";
    }
    if (document.getElementById('cb18').checked == true) {
        data = data + "01 ";
    }
    else {
        data = data + "00 ";
    }
    var seconds = $("#delaysec").text().trim();
    
    data = data + seconds + " ";
    if (document.getElementById('cb19').checked == true) {
        data = data + "01 ";
    }
    else {
        data = data + "00 ";
    }
    if (document.getElementById('cb20').checked == true) {
        data = data + "01 ";
    }
    else {
        data = data + "00 ";
    }
    if (document.getElementById('cb21').checked == true) {
        data = data + "01 ";
    }
    else {
        data = data + "00 ";
    }
    //***alarm values***//

    data = data + "00" + " ";

    data = data + "00" + " ";

    data = data + "00" + " ";

    data = data + "00" + " ";
    //***calculate checksum***//
    var chk = data.split(' ');
    var chksum = 0;
    for (i = 0; i < chk.length - 1; i++) {
        chksum = chksum + parseInt(chk[i], 16);
    };
    chksum = chksum & 255;
    var checksum = chksum.toString(16);
    data = data1 + data + checksum;
    for (i = 0; i < iplist.length; i++) {
        var ip = iplist[i];
       
        chat.server.sendControlKeys(ip[0], data);
    }
}
function OnErrorCall_(respo) {
    console.log(respo);
    console.log(respo.d);
}
//function OnSuccessBuilding(response) {
//    var data = response.d;
//    $("#buildingtable tr:gt(0)").remove();
//    for (i = 0; i < data.length; i++) {
//        var dd = data[i];
//        console.log(dd);
//        var jsonData = JSON.stringify({
//            building: dd[0]
//        });
//        $.ajax({
//            type: "POST",
//            url: "../Services/GetSetSystemConfigInfo.asmx/GetFloorClassByBuilding",
//            data: jsonData,
//            contentType: "application/json; charset=utf-8",
//            dataType: "json",
//            success: OnSuccessFloorClassroom,
//            error: OnErrorCall_
//        });        
//    }
//}
//function OnSuccessFloorClassroom(response) {
//    var data = response.d;
//    var html = [];
//    if (data.length > 1) {
//        html += '<tr><td class="th-1"><i class="ROOM_CTRL fa fa-minus-circle"></i><b><i class="fa fa-check jcheckbox check_all_tr"></i> ' + data[0] + '</b></td>' +
//            '<td><table class="jroom_box" style="display:block;">';
//        for (i = 1; i < data.length; i++) {
//            var data1 = data[i];
//            var classnames = data1[1].split(',');
//            html += '<tr><td class="th-2"><b><i class="fa fa-check jcheckbox check_all_td"></i> ' + data1[0] + '</b></td><td>';
//            for (j = 0; j < classnames.length; j++) {
//                html += '<span><label><input type="checkbox" name="classlist"><i class="fa fa-check jcheckbox"></i> ' + classnames[j] + '</label></span>';
//            }
//            html += '</td></tr>';
//        }
//        html += '</table></td></tr>';
       
//        $("#buildingtable").append(html);
//    }

//}



function OnSuccessIP(response) {
    var data = response.d;
    SendConfigToMachine(data);
}
function bin2hex(b) {
    return b.match(/.{1,4}/g).reduce(function (acc, i) {
        return acc + parseInt(i, 2).toString(16);
    }, '');
}
function hex2bin(h) {
    return ('00000000' + parseInt(h, 16).toString(2)).substr(-8);
}
function uncheckall() {
    var check = document.getElementsByName("systemconfig");
    for (i = 0; i < check.length; i++) {
        if (check[i].type == "checkbox") {
            check[i].checked = false;
        }
    }
}

function isHex(h) {
    return !isNaN(parseInt(h, 16))
    //var re = /[0-9A-Fa-f]{6}/g;

    //if (re.test(h)) {
    //    re.lastIndex = 0;
    //    return true;
    //} else {
    //    re.lastIndex = 0;
    //    return false;
    //} 
}