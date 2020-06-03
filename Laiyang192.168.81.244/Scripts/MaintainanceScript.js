

var dropdown = document.getElementsByClassName("dropdown-btn");
var i;

for (i = 0; i < dropdown.length; i++) {
    dropdown[i].addEventListener("click", function () {
        this.classList.toggle("active");
        var dropdownContent = this.nextElementSibling;
        if (dropdownContent.style.display === "block") {
            dropdownContent.style.display = "none";
        } else {
            dropdownContent.style.display = "block";
        }
    });
}
$(document).on("click", "#inspection", function () {

    displayNone();
    document.getElementById("inspectionLogs").style.display = "block";
});

$(document).on("click", "#maintainanceMgmt", function () {
    displayNone();
    document.getElementById("mainStats").style.display = "block";
});

$(document).on("click", "#faultinfo", function () {
    displayNone();
    document.getElementById("faultinfos").style.display = "block";
});

$(document).on("click", "#statistics", function () {
    displayNone();
    document.getElementById("stats").style.display = "block";
    openIssueStats();
})
function displayNone() {
    document.getElementById("inspectionLogs").style.display = "none";
    document.getElementById("faultinfos").style.display = "none";
    document.getElementById("stats").style.display = "none";
    document.getElementById("mainStats").style.display = "none";
}

function displayModalnow() {
    document.getElementById("editDetailtoAssign").style.display = "block";
    return false;
}

function noModal() {
    document.getElementById("editDetailtoAssign").style.display = "none";
}

var pieColors = (function () {
    var colors = [],
        base = Highcharts.getOptions().colors[0],
        i;

    for (i = 0; i < 10; i += 1) {
        // Start out with a darkened base color (negative brighten), and end
        // up with a much brighter color
        colors.push(Highcharts.Color(base).brighten((i - 3) / 7).get());
    }
    return colors;
}());
var ccc = Highcharts.chart('issueStats1', {
    chart: {
        backgroundColor: 'transparent',
        plotBackgroundColor: 'transparent',
        type: 'pie',
        animation: {
            duration: 1000
        },
        options3d: {
            enabled: true,
            alpha: 45,
            beta: 0
        }
    },
    title: {
        text: '',
        style: {
            color: '#E0E0E3',
            textTransform: 'uppercase',
            fontSize: '16px',
            fontWeight: 'bold'
        }
    },
    tooltip: {
        pointFormat: ' <b>{point.percentage: .1f}%</b>'
    },
    plotOptions: {
        pie: {
            allowPointSelect: true,
            colors: pieColors,
            innerSize: 70,
            cursor: 'pointer',
            depth: 30,
            dataLabels: {
                enabled: true,
                format: '{point.name}'
            }
        }
    },
    credits: {
        enabled: false
    },
    series: [{
        type: 'pie',
        name: 'Issues Status',
        data: [
            ['已处理', 60.4],

            {
                name: '未处理',
                y: 39.6,
                sliced: true,
                selected: true
            },

        ]
    }],
    scrollbar: {
        // dont call setExtremes with each move of the scrollbar
        liveRedraw: false
    }
});

function func() {
    console.log("function worked");
    ccc.series[0].setData([[Math.random()], [Math.random()]]);
};
setInterval(func, 60 * 1000);

function openIssueStats() {

    document.getElementById("issueStats").style.display = "block";
    document.getElementById("Tokyo").style.display = "none";
    document.getElementById("Paris").style.display = "none";
    return false;
};
function openParis() {
    openIssueStats();
    return false;
}
function OpenTokyo() {
    openIssueStats();
    return false;
}
var modal = document.getElementById("editDetailtoAssign");
window.onclick = function (event) {
    if (event.target == modal) {
        noModal();
    }
}

function GetAllIssues(insid) {
    var aData;
    var jsonData = JSON.stringify({

        name: insid
    });
    $.ajax({
        type: "POST",
        url: "Services/MaintainanceWebService.asmx/GetFaultInfos",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
    function OnSuccess_(response) {
        aData = response.d;
        document.getElementById("progressdiv").innerHTML = "";
        for (i = 0; i < aData.length; i++) {
            var data = aData[i].split(',');
            var per = (data[2] / data[1]) * 100;
            var resolved = data[2];
            var color = get_random_color();
            var bar = '<div class="row styling" style="border-bottom:1px solid #3b3f39;">' +
                '<div style ="width:100%;" ><div style="width: 20%; float: left;">'
                + data[0] + '</div>' +
                '<div style="width: 60%; height: 100%; float: left;"><div class="progressbar">' +
                '<div style="background-color: ' + color + '; width:' + per + '%;"></div>' +
                '</div></div><div style="width: 10%; float: left;"></div>' +
                '<div style="width: 10%; float: left;">' + 
                '<span style="background-color:' + color + '; border-radius: 6px;' +
                ' padding: 1px 10px 1px 10px">' + resolved + "</span></div></div ></div >";
            var div = document.createElement("DIV");
            div.innerHTML = bar;
            document.getElementById("progressdiv").appendChild(div);
            
            
        }
        
    }
    function OnErrorCall_(respo) {
        console.log(respo);
    }

   
}
function get_random_color() {
    function c() {
        var hex = Math.floor(Math.random() * 250).toString(16);
        return ("0" + String(hex)).substr(-2); // pad with zero
    }
    return "#" + c() + c() + c();
}
$(document).ready(function () {
    var aData;
    var jsonData = JSON.stringify({

        name: ""
    });
    $.ajax({
        type: "POST",
        url: "Services/MaintainanceWebService.asmx/GetFaultCount",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
    function OnSuccess_(response) {
        aData = response.d;
        var issuecount = aData[0];
        var pending = aData[1];
        var resolved = aData[2];
        var fixedtoday = aData[3];
        document.getElementById("FaultyDevices").innerText = issuecount;
        document.getElementById("UnresolvedIssues").innerText = pending;
        document.getElementById("totalResolved").innerText = resolved;
        document.getElementById("fixedToday").innerText = fixedtoday;
    }
    function OnErrorCall_(respo) {
        console.log(respo);
    }
    var ddl = document.getElementById("MainContent_ddlInstitute");
    var insid = ddl.options[ddl.selectedIndex].value;

    GetAllIssues(insid);
});



