$ = jQuery.noConflict();
$(function () {
    var v = $("#schid").val();
    console.log(v);
    var ar = v.split("&");
    var classname = ar[0].replace("%20", ' ');
    var coursename = ar[1].replace("%20", ' ');
    console.log(classname);
    console.log(coursename);
    GetData(classname, coursename);
})

function GetData(classn, course) {
    var adata = [];
    adata[0] = classn;
    adata[1] = course;
    var jsonData = JSON.stringify({
        name: adata
    });
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetCourseDetails",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
}
function OnSuccess_(response) {
    var idata = response.d;
    console.log(idata);
    FillEditSchedule(idata);
}
function OnErrorCall_(respo) {
    console.log(respo);
}
var usedweek;
var useddays;
var dayslist = ["monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday"];
var weeklist = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22];
function FillEditSchedule(data) {
    var idata = data[0];
    document.getElementById("coursename").innerText = idata[1];
    document.getElementById("location").innerText = idata[7] + "," + idata[2];
    document.getElementById("lessoncount").innerText = idata[6];
    
    document.getElementById("oldweek").innerText = idata[3];
    document.getElementById("oldsession").innerText = idata[5] + " , " + idata[6];
    document.getElementById("beforelocation").innerText = idata[7] + ", " + idata[2];
    document.getElementById("oldteacher").innerText = idata[0];
    var startdate = new Date(2020, 03, 01);
    var today = new Date();
    var diff = Math.abs(startdate.getTime() - today.getTime());
    var DiffDays = Math.ceil(diff / (1000 * 3600 * 24));
     usedweek = Math.round(DiffDays / 7);
     useddays = Math.round(DiffDays % 7);
   
    var inner = [];
    for (i = usedweek; i < weeklist.length; i++) {
        
        inner += '<div class="option"><a>' + weeklist[i] + '</a></div>';
    }
    document.getElementById("weeklist").innerHTML = inner;
    //var innerdays = [];
    //for (j = useddays; j < dayslist.length; j++) {
    //    innerdays += '<div class="option"><a>' + dayslist[j] + '</a></div>';
    //}
    //document.getElementById("daylist").innerHTML = innerdays;
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetBuilding",
        //data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessBuilding,
        error: OnErrorCallBuilding
    });
    GetTeacher(idata[1]);
}


//$("#weekday").off('DOMSubtreeModified').on('DOMSubtreeModified', function () {
//    console.log("clicked on day changed button");
//    //AddNewStudent();
//});


$("#btnSaveTransfer").off('click').on('click', function () {
    console.log("clicked on save button");
    SaveTransfer();
});

function OnSuccess(response) {
    var idata = response.d;
    console.log(idata);
    $("#sec_box").load("window/p-course/002-1.html");
    
}
function OnErrorCall(respo) {
    console.log(respo);
}
function SaveTransfer() {
    var c = document.getElementById("location").innerText.split(",");
    var classname = c[1];
    var coursename = document.getElementById("coursename").innerText;
    var reason = document.getElementById("txtreason").innerText;
    var week = document.getElementById("newweek").innerText;
    var day = $('#weekdays option:selected').val();
    var section = document.getElementById("section").innerText;
    var building = $('#buildinglist option:selected').text();
    var classroom = $('#classlist option:selected').text();
    var teacher = document.getElementById("newteacher").innerText;
    SaveTransferApplication(classname, coursename, reason, week, day, section, building, classroom, teacher);

   // $("#sec_box").load("window/p-course/002-1.html");

}

function GetFreeWeek(idata) {
    if (idata.length > 0) {
        var tabledata = [];
        var classlist = [];
        var endweeklist = [];
        var startweek = [];
        var maxweek = 22;  var minweek = 1;
        for (i = 0; i < idata.length; i++) {
            
            var data = idata[i];
            var start = parseInt(data[1])- minweek;
            if (start > 0) {               
                for (j = 1; j <= start; j++) {
                    if (startweek.indexOf(j)==-1)
                        startweek.push(j);                    
                }
                   
            }
            var end = parseInt(data[2]) + 1;
            if (end < maxweek) {               
                for (k = end; k <= maxweek; k++) {
                    if (startweek.indexOf(k) == -1)
                        startweek.push(k);
                }                    
            }           
        }
        startweek.sort((a, b) => a - b);
        console.log("startweek " + startweek);
        for (l = 0; l < startweek.length; l++)             
            tabledata.push("week " + startweek[l]);      
        console.log("total weeks " + tabledata);
    }
    var jsonData = JSON.stringify({
        name: 3
    });
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetFreeDay",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess1,
        error: OnErrorCall1
    });
}

function SaveTransferApplication(classname, coursename, reason,week,day,section,building,classroom,teacher) {
    var adata = [];
    adata[0] = classname;
    adata[1] = coursename;
    adata[2] = reason;
    adata[3] = week;
    adata[4] = day; adata[5] = section; adata[6] = building;
    adata[7] = classroom; adata[8] = teacher; adata[9] = "pending";
    var jsonData = JSON.stringify({
        name: adata
    });
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/SaveTransferSchedule",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        error: OnErrorCall
    });
}

function GetFreeDay(idata) {
    if (idata.length > 0) {
        var daylist = [];
        var section = [];
        var daysandsection = [];
        var sections = "";
        for (i = 0; i < idata.length; i++) {
            var data = idata[0];
            var r = data[1];
            var day = "";
            for (j = 1; j <= 11;) {
                if (r.indexOf(j)==-1) {
                    section.push(j);
                    if (daylist.indexOf(data[0]) == -1) {
                        var day = data[0];
                        daylist.push(data[0]);
                    }
                                     
                }
                j = j + 2;
            }
            for (k = 0; j <= section.length; k++) {
                sections = day+ sections + section[k] + ",";
            }
            daysandsection.push(sections);
            sections = "";
        }
        console.log("day and section" + daysandsection);
    }
}

function OnSuccess1(response) {
    var idata = response.d;
    console.log(idata);
    GetFreeDay(idata);

}
function OnErrorCall1(respo) {
    console.log(respo);
}

function OnSuccessBuilding(response) {
    var data = response.d;
    var inner = [];
    for (i = 0; i < data.length; i++) {

        inner += '<option class="option" value="'+data[i]+'">' + data[i] + '</option>';
    }
    document.getElementById("buildinglist").innerHTML = inner;
    
}
function OnErrorCallBuilding(respo) {
    console.log(respo);
}

$("#buildinglist").off("change").on("change",  function () {
    var adata = [];
    console.log($('#buildinglist option:selected').text());
    adata[1] = $('#buildinglist option:selected').text();
    adata[0] = document.getElementById("newweek").innerText;
    var jsonData = JSON.stringify({
        name: adata
    });
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetAvailClasses",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessClass,
        error: OnErrorCallClass
    });

});

function OnSuccessClass(response) {
    var data = response.d;
    var inner = [];
    for (i = 0; i < data.length; i++) {
        inner += '<option class="option" value="'+data[i]+'">' + data[i] + '</option>';
    }
    document.getElementById("classlist").innerHTML = inner;
}
function OnErrorCallClass(respo) {
    console.log(respo);
}

$("#classlist").off("change").on("change", function () {
    var adata = [];
    
    adata[1] = $('#classlist option:selected').text();
    adata[0] = document.getElementById("newweek").innerText;
    var jsonData = JSON.stringify({
        name: adata
    });
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetAvailDay",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessDay,
        error: OnErrorCallDay
    });

});

var sections = [];
function OnSuccessDay(response) {
    var data1 = response.d;
    var inner = [];
    sections = [];
    for (i = 0; i < data1.length; i++) {
        var data = data1[i];
        var day = data["Day"];
        var sec = data["Section"];
        var dayname = "";
        sections.push(sec);
        switch (day) {
            case 1:
                dayname = "Monday";
                break;
            case 2:
                dayname = "Tuesday";
                break;
            case 3:
                dayname = "Wednesday";
                break;
            case 4:
                dayname = "Thursday";
                break;
            case 5:
                dayname = "Friday";
                break;
            case 6:
                dayname = "Saturday";
                break;
            case 7:
                dayname = "Sunday";
                break;
        }
        inner += '<option class="option" value = "' + day + '">' + dayname + '</option>';
    }
    document.getElementById("weekdays").innerHTML = inner;
}
function OnErrorCallDay(respo) {
    console.log(respo);
}

$("#weekdays").off("change").on("change", function () {
    
    console.log(document.getElementById("weekdays").innerText);
    var day = $('#weekdays option:selected').val();
    var inner = [];
    var currentsec = sections[parseInt(day) - 1];
    for (i = 0; i < currentsec.length; i++) {
        inner += '<div class="option sectionlist"><a>' + currentsec[i] + '</a></div>';
    }
    document.getElementById("sectionlist").innerHTML = inner;
});


function GetTeacher(coursename) {
    
    var jsonData = JSON.stringify({
        name: coursename
    });
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetTeacherDetail",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessteacher,
        error: OnErrorCallteacher
    });
}

function OnSuccessteacher(response) {
    var data = response.d;
    var inner = [];
    for (i = 0; i < data.length; i++) {
       
        
        inner += '<div class="option teacherlist"><a>' + data[i] + '</a></div>';
    }
    document.getElementById("teacherlist").innerHTML = inner;
}
function OnErrorCallteacher(respo) {
    console.log(respo);
}