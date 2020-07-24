console.log("userlogs.js");
$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "../Services/UserLogs.asmx/GetLogGraphData",
        //data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessChartData,
        error: OnErrorCall_
    });
    
    $.ajax({
        type: "POST",
        url: "../Services/UserLogs.asmx/GetUserLogDetails",
        //data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessLogs,
        error: OnErrorCall_
    });

});

function OnSuccessChartData(response) {
    var data = response.d;
    var aLabels = [];
    var aDatasets1 = [];
    for (i = 0; i < data.length; i++) {
        var dd = data[i];
        
        aLabels.push(dd[0]);
        
        aDatasets1.push(dd[1]);
    }
  
    var cHeight = $("#myChart06").width();
    $("#myChart06").css("height", cHeight);
    var ctx = document.getElementById('myChart06').getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'doughnut',
        data: {
            labels: aLabels,
            //[
            //    '登录',
            //    '登出',
            //    '开系统',
            //    '关系统',
            //    '开讲台窗帘',
            //    '关讲台窗帘'
            //],
            datasets: [
                {
                    data: aDatasets1,
                    //    [
                    //    12,
                    //    19,
                    //    3,
                    //    11,
                    //    7,
                    //    5
                    //],
                    backgroundColor: [
                        'rgba(223, 107, 107, 1)'
                        //'rgba(255, 190, 61, 1)',
                        //'rgba(102, 186, 68, 1)',
                        //'rgba(58, 196, 243, 1)',
                        //'rgba(63, 188, 184, 1)',
                        //'rgba(150, 48, 186, 1)'
                    ],
                    hoverBackgroundColor: [
                        'rgba(223, 107, 107, 0.6)'
                        //'rgba(255, 190, 61, 0.6)',
                        //'rgba(102, 186, 68, 0.6)',
                        //'rgba(58, 196, 243, 0.6)',
                        //'rgba(63, 188, 184, 0.6)',
                        //'rgba(150, 48, 186, 0.6)'
                    ],
                    borderWidth: 0
                }
            ]
        },
        options: {
            legend: {
                display: false
            }
        }
    });

}
function OnSuccessLogs(response) {
    var data = response.d;
    $("#userlogtable tr:gt(0)").remove();
    var rowhtml = [];
    for (i = 0; i < data.length; i++) {
        var dd = data[i];       
        var current_datetime = new Date(parseInt(dd[5].substr(6)));
        
        var date = current_datetime.getFullYear() + "年" + (current_datetime.getMonth() + 1) + "月" + current_datetime.getDate() + "日 "
            + current_datetime.getHours().toString().padStart(2, "0") + ":" +
            current_datetime.getMinutes().toString().padStart(2, "0") + ":" +
            current_datetime.getSeconds().toString().padStart(2, "0");
        rowhtml += '<tr class="border-bottom hover_btn" style="padding:10px 0;">' +
            '<td class="pl-3">'+(i+1)+'</td><td class="pl-3">'+dd[0]+'</td><td class="text-left pl-3">'+dd[1]+'</td><td class="pl-3">'+dd[2]+'</td>' +
            '<td class="pl-3">'+dd[3]+'</td><td class="pl-3">'+dd[4]+'</td><td class="pl-3">'+date+'</td></tr>';
    }
    $("#userlogtable").find('tbody').append($(rowhtml));
}
function OnErrorCall_(respo) {
    console.log(respo);
}
