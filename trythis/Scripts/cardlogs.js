
var chat = $.connection.myHub; 
chat.client.logs = function (newrow) {   
    var newdata = newrow.split(',');    
    var grid = document.getElementById("MainContent_masterchildBody_gv1");    
    var row1 = grid.insertRow(1);
    var cell = row1.insertCell(0);
    cell.innerHTML = newdata[1];
    var cell1 = row1.insertCell(1);
    cell1.innerHTML = newdata[0];
    var cell2 = row1.insertCell(2);
    cell2.innerHTML = newdata[2];
    var cell3 = row1.insertCell(3);    
    cell3.innerHTML = newdata[3];
    var cell4 = row1.insertCell(4);
    cell4.innerHTML = newdata[4];  
};

$.connection.hub.start({ waitForPageLoad: false }).done(function () {
   
});

function sqlToJsDate(sqlDate) {
    //sqlDate in SQL DATETIME format ("yyyy-mm-dd hh:mm:ss.ms")
    var sqlDateArr1 = sqlDate.split("-");
    //format of sqlDateArr1[] = ['yyyy','mm','dd hh:mm:ms']
    var sYear = sqlDateArr1[0];
    var sMonth = (Number(sqlDateArr1[1]) - 1).toString();
    var sqlDateArr2 = sqlDateArr1[2].split(" ");
    //format of sqlDateArr2[] = ['dd', 'hh:mm:ss.ms']
    var sDay = sqlDateArr2[0];
    var sqlDateArr3 = sqlDateArr2[1].split(":");
    //format of sqlDateArr3[] = ['hh','mm','ss.ms']
    var sHour = sqlDateArr3[0];
    var sMinute = sqlDateArr3[1];
    var sqlDateArr4 = sqlDateArr3[2].split(".");
    //format of sqlDateArr4[] = ['ss','ms']
    var sSecond = sqlDateArr4[0];
    var sMillisecond = sqlDateArr4[1];
    alert(new Date(sYear, sMonth, sDay, sHour, sMinute, sSecond, sMillisecond));    
}