
var myChart;
var myChart2;
var myChart3;
 var myChart5; var chart9;

var temp = new Array();
var humidity = new Array();
var hum2 = new Array();
var hum10 = new Array();
var timenow = new Array();
var co2array = new Array();
var defaultip = "";
(function ($) {
    
    var chat = $.connection.myHub;   

    for (i = 0; i < 20; i++) {
        temp[i] = 0;
        humidity[i] = 0;
        hum2[i] = 0;
        hum10[i] = 0;
        timenow[i] = "";
        co2array[i] = 0;
    };  
    chat.client.broadcastMessage = function (name, message) {
        //document.getElementById("tempdata").style.display = "block";
        //console.log(name);
        //var ipName ="192.168.1.38";  
        var arrayData = message.split(",");
        if (arrayData[1] == "Heartbeat") {

        }
        var tt = document.getElementById("MainContent_masterchildBody_lbllive").innerHTML;
        if (tt == "Live") {
            updatelivechart(name, message);
        }
    }; 

    //chat.client.totalCount = function (count) {
    //    var e = document.getElementById("MainContent_masterchildBody_ddlInstitute");
    //    var v = e.options[e.selectedIndex].value;
    //    CreateAllChart(v);
        
    //};
    chat.client.machineCounts = function (counts) {
        var data = counts.split(',');
        var compoff = parseInt(data[2]) - parseInt(data[0]);
        var projoff = parseInt(data[2]) - parseInt(data[1]);
        compchart.series[0].setData([parseInt(data[0], 10), parseInt(compoff, 10)]);
        compchart.update({
            tooltip: {
                style: {
                    display: "block",
                }
            }
        });
        projchart.series[0].setData([parseInt(data[1], 10), parseInt(projoff)]);
        projchart.update({
            tooltip: {
                style: {
                    display: "block",
                }
            }
        });
    }
    $.connection.hub.start({ waitForPageLoad: false }).done(function () {
        // console.log("connection started");
       
        $(document).on("click", "#team-chart", function () {            
            var classvalue = $('#MainContent_masterchildBody_ddlClass').val();
            if (classvalue.includes("Cla")) {
                $.ajax({
                    type: "POST",
                    url: "Services/ChartData.asmx/GetTempChartDataAll",
                    data: classvalue,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess,
                    error: OnErrorCall
                });
            }
            else {
                var gradevalue = $('#MainContent_masterchildBody_ddlGrade').val();
                if (gradevalue.includes("Gra")) {

                }
                else {
                    var insvalue = $('#MainContent_masterchildBody_ddlInstitute').val();
                }
            }
            var data = {
                labels: [
                    "Temperature", "Temperature", "Temperature", "Temperature",
                    "Temperature", "Temperature", "Temperature", "Temperature",

                ],
                datasets: [
                    {
                        data: [-10,0,10,20,30,40,50],
                        backgroundColor: [
                            "#add8e6",
                            "#add8e6",
                            "#add8e6",
                            "#008000",
                            "#008000",
                            "#e59400",
                            "#990000"
                        ],
                        hoverBackgroundColor: [
                            "#add8e6",
                            "#add8e6",
                            "#add8e6",
                            "#008000",
                            "#008000",
                            "#e59400",
                            "#990000"
                        ],
                        borderWidth: 0,
                    }],
               
            };
            var ctx = $("#tempModalChartMonth").get(0).getContext('2d');
            
            new Chart(ctx, TempModalShow);
            var ctx = $("#tempModalChartDate").get(0).getContext('2d');
           

            new Chart(ctx, TempModalShow1);
            var ctx = $("#tempModalChartLive").get(0).getContext('2d');
            
            new Chart(ctx, TempModalShow2);
                       
            document.getElementById("TempModal").style.display = "flex";
           
        });
        $(document).on("click", "#lineChart", function () {
            document.getElementById("HumidModal").style.display = "flex";
        });
        "use strict";
        //Team chart
        Chart.defaults.global.defaultFontColor = "#fff";
        Chart.defaults.scale.gridLines.color = "#f2faf8"        

        var ctx = document.getElementById("brightdonut");
        myChart12 = new Chart(ctx, {
            type: 'doughnut',
            data: {
                labels: ["光照度", ""],
                datasets: [
                    {
                        label: "光照度",
                        backgroundColor: ["#002bfe", "white"],
                        data: [60, 20],
                        borderWidth: [0, 0],
                    }
                ]
            },
            options: {
                maintainAspectRatio: false,
                cutoutPercentage: 65,
                title: {
                    display: false,
                    text: '光照度',
                },
                animation: {
                    animateRotete: true,
                },
                legend: {
                    display: true,
                    position:'bottom',
                },
                tooltips: {
                    display: true,
                }
            }

        });

       // var ctx = document.getElementById("carbondonut");
        var ctx = $("#carbondonut").get(0).getContext('2d');
        var gradientStroke = ctx.createLinearGradient(500, 0, 100, 0);
        gradientStroke.addColorStop(0, '#f49080');
        gradientStroke.addColorStop(1, '#80b6f4');

        var gradientFill = ctx.createLinearGradient(500, 0, 100, 0);
        gradientFill.addColorStop(0, "rgba(244, 144, 128, 0.6)");
        gradientFill.addColorStop(1, "rgba(128, 182, 244, 0.6)"); 
        myChart13 = new Chart(ctx, {
            type: 'line',
            
            data: {
                labels: ['10:00', '10:20', '10:30', '10:45', '11:00', '11:20', '11:30','12:00','12:15','12:30','12:45','13:00','13:15','13:30','13:45'],
                datasets: [{
                    data: [350, 200, 450, 300, 250, 400, 350,250,150,400,200,450,350,150,400],
                    label: "co2",
                    backgroundColor: gradientFill,
                    borderColor: 'rgba(213,154,168,0.70)',
                    borderWidth: 2,
                    pointStyle: 'circle',
                    pointRadius: 1,
                    borderColor: gradientStroke,
                    pointBorderColor: gradientStroke,
                    pointBackgroundColor: gradientStroke,
                    pointHoverBackgroundColor: gradientStroke,
                    pointHoverBorderColor: gradientStroke,
                },
                ]
            },
            options: {
                maintainAspectRatio: false,
                responsive: true,
                tooltips: {
                    mode: 'index',
                    titleFontSize: 12,
                    titleFontColor: '#000',
                    bodyFontColor: '#000',
                    backgroundColor: '#fff',
                    titleFontFamily: 'Montserrat',
                    bodyFontFamily: 'Montserrat',
                    cornerRadius: 3,
                    intersect: false,
                },
                legend: {
                    display: false,
                    position: 'top',
                    labels: {
                        usePointStyle: true,
                        fontFamily: 'Montserrat',
                    },
                },
                scales: {
                    xAxes: [{
                        display: true,
                        gridLines: {
                            display: false,
                        },
                        scaleLabel: {
                            display: true,
                            labelString: '时间',
                            fontSize: 16,

                        },
                        ticks: {
                            fontSize: 9,

                        }
                    }],
                    yAxes: [{
                        display: true,
                        gridLines: {
                            display: false,
                            zeroLineColor: '#fff',
                        },
                        scaleLabel: {
                            display: true,
                            labelString: '数值(ppm)',
                        },
                        ticks: {
                            min: 100,
                            stepSize: 100,
                            fontSize: 10,
                        }
                    }]
                },
            }
        });

       
    });
    CreateAllChart("All");
})(jQuery);

Chart.defaults.global.animation.duration = 0;
Chart.defaults.global.tooltips.enabled = true;


var configSpeed = {
   
    "type": "gauge",
    "data": {
        "datasets": [
            {
                "data": [],
                "backgroundColor": [],
                "borderWidth": 0,
                "hoverBackgroundColor": [],
                "hoverBorderWidth": 0
            }
        ],
        "current": 220,
    },
    "options": {
        "panel": {
            "min": 0,
            "max": 300,
            "tickInterval": 3,
            "tickColor": "rgb(255, 255, 255)",
            "tickOuterRadius": 99,
            "tickInnerRadius": 95,
            "scales": [0, 30, 60, 90, 120, 150, 180, 210, 240, 270, 300],
            "scaleColor": "rgb(255, 255, 255)",
            "scaleBackgroundColor": "rgb(252,114,131)",
            "scaleTextRadius": 70,
            "scaleTextSize": 9,
            "scaleTextColor": "rgba(255, 255, 255, 1)",
            "scaleOuterRadius": 99,
            "scaleInnerRadius": 93,
        },
        "needle": {
            "lengthRadius": 90,
            "circleColor": "rgba(0,114,231, 1)",
            "color": "rgba(0,114,231, 0.8)",
            "circleRadius": 4,
            "width": 3,
        },
        "cutoutPercentage": 85,
        "rotation": (1 / 2 + 1 / 3) * Math.PI,
        "circumference": 2 * Math.PI * 2 / 3,
        "legend": {
            "display": false,
            "text": "legend",
        },
        "tooltips": {
            "enabled": false,
            "label": "voltage",
        },
        "title": {
            "display": true,
            "text": "总能耗",
            "position": "bottom",
            "fontColor": "white",
            "fontWeight": "normal",
        },
        "animation": {
            "animateRotate": true,
            "animateScale": false
        },
        "hover": {
            "mode": null
        },
        
    }
};

var configDirection = {
    "type": "gauge",
    "data": {
        "datasets": [
            {
                "data": [],
                "backgroundColor": [],
                "borderWidth": 0,
                "hoverBackgroundColor": [],
                "hoverBorderWidth": 0
            }
        ],
        "current": 1,
    },
    "options": {
        "panel": {
            "min": 0,
            "max": 10,
            "tickInterval": 0.10,
            "tickColor": "rgb(0, 0, 0)",
            "tickOuterRadius": 99,
            "tickInnerRadius": 95,
            "scales": [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
            "scaleColor": "rgb(0, 0, 0)",
            "scaleBackgroundColor": "rgb(111,238,147)",
            "scaleTextRadius": 70,
            "scaleTextSize": 9,
            "scaleTextColor": "rgba(255, 255, 255, 1)",
            "scaleOuterRadius": 99,
            "scaleInnerRadius": 93,
        },
        "needle": {
            "lengthRadius": 90,
            "circleColor": "rgba(0,114,231, 1)",
            "color": "rgba(0,114,231, 0.8)",
            "circleRadius": 4,
            "width": 3,
        },
        "cutoutPercentage": 85,
        "rotation": (1 / 2 + 1 / 3) * Math.PI,
        "circumference": 2 * Math.PI * 2 / 3,
        //"rotation": -Math.PI,
        //"circumference": Math.PI,
        "legend": {
            "display": false,
            "text": "legend"
        },
        "tooltips": {
            "enabled": false
        },
        "title": {
            "display": true,
            "text": "当前(w)",
            "position": "bottom"
        },
        "animation": {
            "animateRotate": true,
            "animateScale": false
        },
        "hover": {
            "mode": null
        }
    }
};

var Carbon = {

    "type": "gauge",
    "data": {
        "datasets": [
            {
                "data": [],
                "backgroundColor": [],
                "borderWidth": 0,
                "hoverBackgroundColor": [],
                "hoverBorderWidth": 0
            }
        ],
        "current": 45,
    },
    "options": {
        "panel": {
            "min": 0,
            "max": 100,
            "tickInterval": 1,
            "tickColor": "rgb(0, 0, 0)",
            "tickOuterRadius": 99,
            "tickInnerRadius": 95,
            "scales": [0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100],
            "scaleColor": "rgb(0, 0, 0)",
            "scaleBackgroundColor": "rgb(238,170,185)",
            "scaleTextRadius": 70,
            "scaleTextSize": 5,
            "scaleTextColor": "rgba(255, 255, 255, 1)",
            "scaleOuterRadius": 99,
            "scaleInnerRadius": 93,
        },
        "needle": {
            "lengthRadius": 90,
            "circleColor": "rgba(0,114,231, 1)",
            "color": "rgba(0,114,231, 0.8)",
            "circleRadius": 4,
            "width": 3,
        },
        "cutoutPercentage": 85,
        "rotation": (1 / 2 + 1 / 3) * Math.PI,
        "circumference": 2 * Math.PI * 2 / 3,
        "legend": {
            "display": false,
            "text": "legend"
        },
        "tooltips": {
            "enabled": false
        },
        "title": {
            "display": true,
            "text": "总能耗",
            "position": "bottom",
            "fontColor": "white",
        },
        "animation": {
            "animateRotate": true,
            "animateScale": false
        },
        "hover": {
            "mode": null
        },

    }
};

window.onload = function () {
    var ctx = document.getElementById('Speedometer').getContext('2d');
   // ctx.height = 150;
   
    window.speed = new Chart(ctx, configSpeed);
    var ctx = document.getElementById('Speedometer1').getContext('2d');
  
    window.direction = new Chart(ctx, configDirection);
    //var ctx = document.getElementById('carbondonut').getContext('2d');
    //window.direction = new Chart(ctx, Carbon);
   
};


$(window).on('load', setWidth);
$(window).on('resize', setWidth);

function setWidth() {
    var width = $(window).width();
    console.log("homepage width " + width);
    if (width > 1180 && width < 1500) {
        $('.fullWidth1').removeClass('col-xl-5').addClass('col-xl-6');
        $('.fullWidth2').removeClass('col-xl-4').addClass('col-xl-6');
        $('.fullWidth3').removeClass('col-xl-10').addClass('col-xl-12');
        
    }
    else {
        $('.fullWidth2').removeClass('col-xl-6').addClass('col-xl-4');
        $('.fullWidth1').removeClass('col-xl-6').addClass('col-xl-5');
        $('.fullWidth3').removeClass('col-xl-12').addClass('col-xl-10');
        
    }
    //if (width < 990) {
    //    $('#Speedometer').Height = "130";
    //    $('#Speedometer').Width = "130";
    //    $('#Speedometer1').Height = "130";
    //    $('#Speedometer1').Width = "130";
        

    //}
    
    //else if (width > 1279 && width <= 768) {
    //    $('.fullWidth').removeClass('col-md-6').addClass('col-md-12');
    //    $('.fullWidth').removeClass('col-md-4').addClass('col-md-12');

    //}
    //else if (width > 1600) {
    //    $('.fullWidth').removeClass('col-lg-12').addClass('col-lg-5');
    //    $('.fullWidth').removeClass('col-lg-11').addClass('col-lg-4');
    //}
    //else if (width < 768) {

    //}
    console.log("homepage width " + width);
}

function ShowTempModal() {
    var data = {
        labels: [
            "Red",
            "Blue",
            "Yellow"
        ],
        datasets: [
            {
                data: [300, 50, 100],
                backgroundColor: [
                    "#FF6384",
                    "#36A2EB",
                    "#FFCE56"
                ],
                hoverBackgroundColor: [
                    "#FF6384",
                    "#36A2EB",
                    "#FFCE56"
                ]
            }]
    };
    var ctx = document.getElementById("tempModalChartMonth");
    var myDoughnutChart = new Chart(ctx, {
        type: 'doughnut',
        data: data,
        options: {
            maintainAspectRatio: false,
            rotation: 1 * Math.PI,
            circumference: 1 * Math.PI,
            postion: center,
        }
    });
}

document.onclick = function (event) {
    var modal = document.getElementById("TempModal");
    var humidmodal = document.getElementById("HumidModal")
    if (event.target == modal) {
        modal.style.display = "none";
    }
    if (event.target == humidmodal) {
        humidmodal.style.display = "none";
    }
};

var TempModalShow = {

    "type": "gauge",
    "data": {
        "datasets": [
            {
                "data": [-10, 0, 10, 20, 30, 40, 50],
                "backgroundColor":[],
                "borderWidth": 0,
                "hoverBackgroundColor":[],
                "hoverBorderWidth": 0
            }
        ],
        "current": 25,
    },
    "options": {
        "panel": {
            "min": -10,
            "max": 50,
            "tickInterval": 10,
            "tickColor": "rgb(255, 255, 255)",
            "tickOuterRadius": 99,
            "tickInnerRadius": 95,
            "scales": [-10,0, 10, 20, 30, 40, 50],
            "scaleColor": "rgb(255, 255, 255)",
            "scaleBackgroundColor": "rgb(252,114,131)",
            "scaleTextRadius": 70,
            "scaleTextSize": 12,
            "scaleTextColor": "rgba(255, 255, 255, 1)",
            "scaleOuterRadius": 99,
            "scaleInnerRadius": 93,
        },
        "needle": {
            "lengthRadius": 90,
            "circleColor": "rgba(0,114,231, 1)",
            "color": "rgba(0,114,231, 0.8)",
            "circleRadius": 4,
            "width": 3,
        },
        "cutoutPercentage": 85,
        "rotation": 1 * Math.PI,
        "circumference": 1 * Math.PI,
        "legend": {
            "display": false,
            "text": "legend"
        },
        "tooltips": {
            "enabled": false
        },
        "title": {
            "display": true,
            "text": "Temperature",
            "position": "bottom",
            "fontColor": "white",
            "fontWeight": "normal",
        },
        "animation": {
            "animateRotate": true,
            "animateScale": false
        },
        "hover": {
            "mode": null
        },

    }
};

function CreateChart() {
    var now = new Date();
    var time = now.getHours() + ":" + now.getMinutes() + ":" + now.getSeconds();
    var ctx = document.getElementById("team-chart");
    ctx.height = 130;
    myChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: [time],
            type: 'line',
            defaultFontFamily: 'Montserrat',
            datasets: [{
                //data: [0, 7, 3, 5, 2, 8, 6],
                label: "Temprature",
                backgroundColor: 'rgba(0,44,237,0.3)',
                borderColor: 'rgba(213,154,168,0.70)',
                borderWidth: 2,
                pointStyle: 'circle',
                pointRadius: 1,
                pointBorderColor: "rgba(255,255,255,1)",
                pointBackgroundColor: 'rgba(255,255,255,1)',
                pointHighlightStroke: "rgba(255,255,255,1)",
            },
            ]
        },
        options: {
            maintainAspectRatio: false,
            responsive: true,
            tooltips: {
                mode: 'index',
                titleFontSize: 12,
                titleFontColor: '#000',
                bodyFontColor: '#000',
                backgroundColor: '#fff',
                titleFontFamily: 'Montserrat',
                bodyFontFamily: 'Montserrat',
                cornerRadius: 3,
                intersect: false,
            },
            legend: {
                display: false,
                position: 'top',
                labels: {
                    usePointStyle: true,
                    fontFamily: 'Montserrat',
                },
            },
            scales: {
                xAxes: [{
                    display: true,
                    gridLines: {
                        display: false,
                    },
                    scaleLabel: {
                        display: true,
                        labelString: '时间',
                        fontSize: 16,

                    },
                    ticks: {
                        fontSize: 9,

                    }
                }],
                yAxes: [{
                    display: true,
                    gridLines: {
                        display: false,
                        zeroLineColor: '#fff',
                    },
                    scaleLabel: {
                        display: true,
                        labelString: '温度 (°C)',
                    },
                    ticks: {
                        min: -10,
                        stepSize: 1,
                        fontSize: 9,
                    }
                }]
            },
        }
    });

    //line chart
    var ctx = document.getElementById("lineChart");
    ctx.height = 130;
    myChart2 = new Chart(ctx, {
        type: 'line',
        data: {
            labels: [time],
            datasets: [
                {
                    label: "湿度",
                    borderColor: "rgba(115,99,148,.9)",
                    borderWidth: "2",
                    backgroundColor: "rgba(233,221,255,.4)",
                    pointStyle: 'circle',
                    pointRadius: 0
                    // data: [20, 47, 35, 43, 65, 45, 35]
                },
                {
                    label: "PM2.5(µg/m3)",
                    borderColor: "rgba(0,200,155, 0.9)",
                    borderWidth: "2",
                    backgroundColor: "rgba(212,248,240, .4)",
                    pointHighlightStroke: "rgba(0,200,155,1)",
                    pointStyle: 'circle',
                    pointRadius: 0
                    // data: [16, 32, 18, 27, 42, 33, 44]
                },
                {
                    label: "PM10(µg/m3)",
                    borderColor: "rgba(219,120,118, 0.9)",
                    borderWidth: "2",
                    backgroundColor: "rgba(241,196,195, .4)",
                    pointHighlightStroke: "rgba(219,120,118,1)",
                    pointStyle: 'circle',
                    pointRadius: 0
                    // data: [16, 32, 18, 27, 42, 33, 44]
                }
            ]
        },
        options: {
            maintainAspectRatio: false,
            responsive: true,
            tooltips: {
                mode: 'index',
                intersect: false
            },
            hover: {
                mode: 'nearest',
                intersect: true
            },
            scales: {
                xAxes: [{
                    display: true,
                    gridLines: {
                        display: false,
                        drawBorder: true
                    },
                    scaleLabel: {
                        display: true,
                        labelString: '时间',
                        fontSize: 16,

                    },
                    ticks: {
                        fontSize: 9,
                    }
                }],
                yAxes: [{
                    display: true,
                    gridLines: {
                        display: false,
                        drawBorder: true
                    },
                    scaleLabel: {
                        display: true,
                        labelString: '数值'
                    },
                    ticks: {
                        min: 0,
                        stepSize: 10,
                        fontSize: 9,

                    }
                }]
            },
        }
    });
}

function CreateAllChart(value) {
    if (myChart != null) {
        myChart.destroy();
    }
    if (myChart2 != null) {
        myChart2.destroy();
    }
    var aData;
    var jsonData = JSON.stringify({
        name: value
    });
    $.ajax({
        type: "POST",
        url: "Services/ChartData.asmx/GetTempChartDataAll",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });

    
    function OnSuccess_(response) {
        // chart9.destroy();
        clearCharts();
        aData = response.d;
        var alabel = aData[0];
        var temperature = aData[1];
        var humid = aData[2];
        var pm25 = aData[3];
        var pm10 = aData[4];
        var workinghours = aData[9];
        var donutcharts = aData[10];
        if (workinghours.length == 0) {
            usedhourchart.series[0].setData([0, 0, 0]);

        }
        else if (workinghours.length > 0) {
            usedhourchart.series[0].setData([parseFloat(workinghours[0], 10), parseFloat(workinghours[1], 10), parseFloat(workinghours[4], 10)]);
        }

        if (workinghours.length == 0) {
            usedhourchart.series[0].setData([0, 0, 0, 0, 0, 0]);

        }
        else if (workinghours.length > 0) {
            usedhourchart.series[0].setData([parseFloat(workinghours[0], 10), parseFloat(workinghours[1], 10), parseFloat(workinghours[2], 10),
            parseFloat(workinghours[3], 10), parseFloat(workinghours[4], 10), parseFloat(workinghours[5], 10)]);
        }
        var temptick;
        if (temperature.length > 0)
            temptick = Math.ceil(Math.min.apply(null, temperature));
        else
            temptick = 10;
        var ctx = document.getElementById("team-chart");
        ctx.height = 130;
        myChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: alabel,
                type: 'line',
                defaultFontFamily: 'Montserrat',
                datasets: [{
                    data: temperature,
                    label: "Temprature",
                    backgroundColor: 'rgba(0,44,237,0.3)',
                    borderColor: 'rgba(213,154,168,0.70)',
                    borderWidth: 2,
                    pointStyle: 'circle',
                    pointRadius: 1,
                    pointBorderColor: "rgba(255,255,255,1)",
                    pointBackgroundColor: 'rgba(255,255,255,1)',
                    pointHighlightStroke: "rgba(255,255,255,1)",
                },
                ]
            },
            options: {
                maintainAspectRatio: false,
                responsive: true,
                tooltips: {
                    mode: 'index',
                    titleFontSize: 12,
                    titleFontColor: '#000',
                    bodyFontColor: '#000',
                    backgroundColor: '#fff',
                    titleFontFamily: 'Montserrat',
                    bodyFontFamily: 'Montserrat',
                    cornerRadius: 3,
                    intersect: false,
                },
                legend: {
                    display: false,
                    position: 'top',
                    labels: {
                        usePointStyle: true,
                        fontFamily: 'Montserrat',
                    },
                },
                scales: {
                    xAxes: [{
                        display: true,
                        gridLines: {
                            display: false,
                        },
                        scaleLabel: {
                            display: true,
                            labelString: '时间',
                            fontSize: 16,

                        },
                        ticks: {
                            fontSize: 9,

                        }
                    }],
                    yAxes: [{
                        display: true,
                        gridLines: {
                            display: false,
                            zeroLineColor: '#fff',
                        },
                        scaleLabel: {
                            display: true,
                            labelString: '温度 (°C)',
                        },
                        ticks: {
                            min: temptick - 5,
                            stepSize: 2,
                            fontSize: 9,
                        }
                    }]
                },
            }
        });
        //line chart
        var ctx = document.getElementById("lineChart");
        ctx.height = 130;
        myChart2 = new Chart(ctx, {
            type: 'line',
            data: {
                labels: alabel,
                datasets: [
                    {
                        label: "湿度",
                        borderColor: "rgba(115,99,148,.9)",
                        borderWidth: "2",
                        backgroundColor: "rgba(233,221,255,.4)",
                        pointStyle: 'circle',
                        pointRadius: 0,
                        data: humid,
                    },
                    {
                        label: "PM2.5(µg/m3)",
                        borderColor: "rgba(0,200,155, 0.9)",
                        borderWidth: "2",
                        backgroundColor: "rgba(212,248,240, .4)",
                        pointHighlightStroke: "rgba(0,200,155,1)",
                        pointStyle: 'circle',
                        pointRadius: 0,
                        data: pm25,
                    },
                    {
                        label: "PM10(µg/m3)",
                        borderColor: "rgba(219,120,118, 0.9)",
                        borderWidth: "2",
                        backgroundColor: "rgba(241,196,195, .4)",
                        pointHighlightStroke: "rgba(219,120,118,1)",
                        pointStyle: 'circle',
                        pointRadius: 0,
                        data: pm10,
                    }
                ]
            },
            options: {
                maintainAspectRatio: false,
                responsive: true,
                tooltips: {
                    mode: 'index',
                    intersect: false
                },
                hover: {
                    mode: 'nearest',
                    intersect: true
                },
                scales: {
                    xAxes: [{
                        display: true,
                        gridLines: {
                            display: false,
                            drawBorder: true
                        },
                        scaleLabel: {
                            display: true,
                            labelString: '时间',
                            fontSize: 16,

                        },
                        ticks: {
                            fontSize: 9,
                        }
                    }],
                    yAxes: [{
                        display: true,
                        gridLines: {
                            display: false,
                            drawBorder: true
                        },
                        scaleLabel: {
                            display: true,
                            labelString: '数值'
                        },
                        ticks: {
                            min: 0,
                            stepSize: 10,
                            fontSize: 9,

                        }
                    }]
                },

            }
        });   

        var val = String(value);
        if (val.includes("Ins") || val.includes("All")) {
            for (i = 0; i < donutcharts.length; i++) {
                if (donutcharts[i] == null) {
                    donutcharts[i] = 0;
                }
            }
            if (donutcharts.length > 0) {
                var tt = "<br/>" + donutcharts[1] + "<br/> 电脑";
                compchart.setTitle({ text: tt });
                tt = "<br/>" + donutcharts[0] + "<br/> 投影机";
                projchart.setTitle({ text: tt });
                tt = "<br/>" + donutcharts[2] + "<br/> 录播";
                c3chart.setTitle({ text: tt });
                tt = "<br/>" + donutcharts[3] + "<br/> 空调";
                c4chart.setTitle({ text: tt });
                tt = "<br/>" + donutcharts[4] + "<br/> 屏幕";
                c6chart.setTitle({ text: tt });
            }
            else {
                compchart.setTitle({ text: 0 });
                
                projchart.setTitle({ text: 0 });
                
                c3chart.setTitle({ text: 0 });
                
                c4chart.setTitle({ text: 0 });
               
                c6chart.setTitle({ text: 0 });
            }
            var machineonline = aData[5];
            var machineoffline = aData[6];
            var workopen = aData[7];
            var workclose = aData[8];
            if (workopen == workclose && parseInt(workopen, 10) == 0) {
                if (parseInt(machineonline, 10) == 0) {
                    workclose = machineoffline;
                }                    
                else
                {
                    workclose = machineonline 
                }
            }           
            //var type = Number(machineonline);            
            var n = parseInt(machineonline) + parseInt(machineoffline);
            if (n == 0) {
                //document.getElementById("systemspan").innerHTML = 0;
                cccc.series[0].setData([]);                
                cccc.series[1].setData([]);                
                //donutchartsystem(machineonline, machineoffline);
               //chart9.data.datasets[0].data = [0, 1];
               //chart9.update(0);
            }
            else if (typeof Number(machineonline) == 'number')
            {              
                //document.getElementById("systemspan").innerHTML = parseInt(machineonline) + parseInt(machineoffline);
                //if (syschart != undefined)
                    
               // syschart.title.text = n + " 中控";
               //systemOnline(parseInt(machineonline), parseInt(machineoffline));
                cccc.series[0].setData([['在线', parseInt(machineonline, 10)], ['离线',parseInt(machineoffline,10)]]);
                cccc.series[1].setData([['待机', parseInt(workclose, 10)], ['使用中', parseInt(workopen, 10)]]);
                syschart.series[0].setData([[parseInt(machineonline, 10)], [parseInt(machineoffline, 10)]]);
                var tt = "<br/>" + n + "<br/> 中控";
                syschart.setTitle({ text: tt });
               // donutchartsystem(machineonline, machineoffline);                
            }
            else {
                    console.log("no values");
                 }
        }        
    }
    function OnErrorCall_(respo) {
        console.log(respo);
    }
}

function clearCharts() {
    console.log("inside clear chart");
    if (myChart != null) {
        myChart.destroy();
        myChart2.destroy();
        console.log("destroyed chart");
    }
    
}

function ddlIndexChange(value) {
   
    var jsonData = JSON.stringify({
        name: value
    });
    $.ajax({
        type: "POST",
        url: "Services/ChartData.asmx/getDataforClass",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
    function OnSuccess_(response) {
        
        designChart(response);        
    }
    function OnErrorCall_(respo) {
        console.log(respo);
    }
}

function ddltimeclass(time, loc) {
    var obj = {};
    obj.name = time;
    obj.location = loc;    
    $.ajax({
        type: "POST",
        url: "Services/ChartData.asmx/GetCustomData",
        data: JSON.stringify(obj),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
    function OnSuccess_(response) {
        designChart(response);
    }
    function OnErrorCall_(respo) {
        console.log(respo);
    }
}

function updatelivechart(name, message) {
    var ipName = document.getElementById("MainContent_masterchildBody_ipgraph").value;    
    
    if (name == ipName) {
        console.log(name);
        var arraydata = message.split(',');
        console.log(message);
        if (arraydata[0] == "Temp") {
            var today = new Date();
            var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();            
            timenow.shift();
            timenow.push(time);

            //temp chart update
            temp.shift();
            temp.push(arraydata[1]);
            var tempo = Math.ceil(arraydata[1]);
            myChart.options.scales = {
                xAxes: [{
                    display: true,
                    gridLines: {
                        display: false,
                        zeroLineColor: '#fff',
                    },
                    scaleLabel: {
                        display: true,
                        labelString: '时间',
                        fontSize: 20,
                    },
                    ticks: {
                        fontSize: 9,
                    }
                }],
                yAxes: [{
                    display: true,
                    gridLines: {
                        display: false,
                        zeroLineColor: '#fff',
                    },
                    scaleLabel: {
                        display: true,
                        labelString: '温度 (°C)',

                    },
                    ticks: {
                        min: tempo - 5,
                        stepSize: 1,
                        fontSize: 9,
                    }
                }]
            };
            myChart.data.datasets[0].data = temp;
            myChart.data.labels = timenow;
            myChart.update(0);

            //Humidity Chart
            humidity.shift();
            humidity.push(arraydata[2]);
            hum2.shift();
            hum2.push(arraydata[3]);
            hum10.shift();
            hum10.push(arraydata[4]);
            if (arraydata[4] > 90) {
                var mini;
                if (arraydata[2] > arraydata[3]) {
                    mini = Math.ceil(arraydata[3]);
                }
                else
                    mini = Math.ceil(arraydata[2]);
                myChart2.options.scales = {
                    xAxes: [{
                        display: true,
                        gridLines: {
                            display: false,
                            zeroLineColor: '#fff',
                        },
                        scaleLabel: {
                            display: true,
                            labelString: '时间',
                            fontSize: 20,
                        },
                        ticks: {
                            fontSize: 9,
                        }
                    }],
                    yAxes: [{
                        display: true,
                        gridLines: {
                            display: false,
                            zeroLineColor: '#fff',
                        },
                        scaleLabel: {
                            display: true,
                            labelString: 'Value'
                        },
                        ticks: {
                            min: mini - 8,
                            stepSize: 10,
                            fontSize: 7,
                        }
                    }]
                }
            }

            //2nd Chart               
            myChart2.data.datasets[0].data = humidity;
            myChart2.data.datasets[1].data = hum2;
            myChart2.data.datasets[2].data = hum10;
            myChart2.data.labels = timenow;
            myChart2.update(0);
            //
            var cc = window.speed;
            cc.data.current = arraydata[5];
            console.log(cc.data.current);
            cc.update(0);
            //
            myChart13.data.labels = timenow;
            co2array.shift();
            co2array.push(arraydata[10]);
            myChart13.data.datasets[0].data = co2array;
            myChart13.update(0);
            //
            if (arraydata[6] != '--') {
                var cc1 = window.direction;
                cc1.data.current = (((arraydata[6] / 1000.00) * arraydata[5])).toFixed(3);
                console.log((arraydata[6] / 1000.00) * arraydata[5] / 1000);
                cc1.update(0);
                var co2 = document.getElementById("co2value");
                co2.innerText = arraydata[10] + " ";
                var bright = document.getElementById("brightness");
                bright.innerText = arraydata[13] + " ";
                var methanol = document.getElementById("FormalDehydevalue");
                methanol.innerText = arraydata[11] + " mg/m3";
                var volt = document.getElementById("voltage");
                volt.innerText = arraydata[5] + " V";
                var elec = document.getElementById("Electricity");
                elec.innerText = (((arraydata[6] / 1000.00) * arraydata[5])).toFixed(3) + " w";
            }            
        };
    };
}

var TempModalShow1 = {
    "type": "gauge",
    "data": {
        "datasets": [
            {
                "data": [-10, 0, 10, 20, 30, 40, 50],
                "backgroundColor": [],
                "borderWidth": 0,
                "hoverBackgroundColor": [],
                "hoverBorderWidth": 0
            }
        ],
        "current": 25,
    },
    "options": {
        "panel": {
            "min": -10,
            "max": 50,
            "tickInterval": 10,
            "tickColor": "rgb(255, 255, 255)",
            "tickOuterRadius": 99,
            "tickInnerRadius": 95,
            "scales": [-10, 0, 10, 20, 30, 40, 50],
            "scaleColor": "rgb(255, 255, 255)",
            "scaleBackgroundColor": "rgb(252,114,131)",
            "scaleTextRadius": 70,
            "scaleTextSize": 12,
            "scaleTextColor": "rgba(255, 255, 255, 1)",
            "scaleOuterRadius": 99,
            "scaleInnerRadius": 93,
        },
        "needle": {
            "lengthRadius": 90,
            "circleColor": "rgba(0,114,231, 1)",
            "color": "rgba(0,114,231, 0.8)",
            "circleRadius": 4,
            "width": 3,
        },
        "cutoutPercentage": 85,
        "rotation": 1 * Math.PI,
        "circumference": 1 * Math.PI,
        "legend": {
            "display": false,
            "text": "legend"
        },
        "tooltips": {
            "enabled": false
        },
        "title": {
            "display": true,
            "text": "Temperature",
            "position": "bottom",
            "fontColor": "white",
            "fontWeight": "normal",
        },
        "animation": {
            "animateRotate": true,
            "animateScale": false
        },
        "hover": {
            "mode": null
        },
    }
};

function ShowTempModal1() {
    var data = {
        labels: [
            "Red",
            "Blue",
            "Yellow"
        ],
        datasets: [
            {
                data: [300, 50, 100],
                backgroundColor: [
                    "#FF6384",
                    "#36A2EB",
                    "#FFCE56"
                ],
                hoverBackgroundColor: [
                    "#FF6384",
                    "#36A2EB",
                    "#FFCE56"
                ]
            }]
    };
    var ctx = document.getElementById("tempModalChartDate");
    var myDoughnutChart = new Chart(ctx, {
        type: 'doughnut',
        data: data,
        options: {
            maintainAspectRatio: false,
            rotation: 1 * Math.PI,
            circumference: 1 * Math.PI
        }
    });
}

var TempModalShow2 = {

    "type": "gauge",
    "data": {
        "datasets": [
            {
                "data": [-10, 0, 10, 20, 30, 40, 50],
                "backgroundColor": [],
                "borderWidth": 0,
                "hoverBackgroundColor": [],
                "hoverBorderWidth": 0
            }
        ],
        "current": 25,
    },
    "options": {
        "panel": {
            "min": -10,
            "max": 50,
            "tickInterval": 10,
            "tickColor": "rgb(255, 255, 255)",
            "tickOuterRadius": 99,
            "tickInnerRadius": 95,
            "scales": [-10, 0, 10, 20, 30, 40, 50],
            "scaleColor": "rgb(255, 255, 255)",
            "scaleBackgroundColor": "rgb(252,114,131)",
            "scaleTextRadius": 70,
            "scaleTextSize": 12,
            "scaleTextColor": "rgba(255, 255, 255, 1)",
            "scaleOuterRadius": 99,
            "scaleInnerRadius": 93,
        },
        "needle": {
            "lengthRadius": 90,
            "circleColor": "rgba(0,114,231, 1)",
            "color": "rgba(0,114,231, 0.8)",
            "circleRadius": 4,
            "width": 3,
        },
        "cutoutPercentage": 85,
        "rotation": 1 * Math.PI,
        "circumference": 1 * Math.PI,
        "legend": {
            "display": false,
            "text": "legend"
        },
        "tooltips": {
            "enabled": false
        },
        "title": {
            "display": true,
            "text": "Temperature",
            "position": "bottom",
            "fontColor": "white",
            "fontWeight": "normal",
        },
        "animation": {
            "animateRotate": true,
            "animateScale": false
        },
        "hover": {
            "mode": null
        },

    }
};
function ShowTempModal2() {
    var data = {
        labels: [
            "Red",
            "Blue",
            "Yellow"
        ],
        datasets: [
            {
                data: [300, 50, 100],
                backgroundColor: [
                    "#FF6384",
                    "#36A2EB",
                    "#FFCE56"
                ],
                hoverBackgroundColor: [
                    "#FF6384",
                    "#36A2EB",
                    "#FFCE56"
                ]
            }]
    };
    var ctx = document.getElementById("tempModalChartLive");
    var myDoughnutChart = new Chart(ctx, {
        type: 'doughnut',
        data: data,
        options: {
            maintainAspectRatio: false,
            rotation: 1 * Math.PI,
            circumference: 1 * Math.PI
        }
    });
}

$(document).ready(function () {
    CreateAllChart("All");  
});

function designChart(response) {
    aData = response.d;
    aData = response.d;
    var alabel = aData[0];
    var temperature = aData[1];
    var humid = aData[2];
    var pm25 = aData[3];
    var pm10 = aData[4];
    var workinghours = aData[5];
    if (workinghours.length == 0) {
        usedhourchart.series[0].setData([0, 0, 0]);

    }
    else if (workinghours.length > 0) {
        usedhourchart.series[0].setData([parseFloat(workinghours[0], 10), parseFloat(workinghours[1], 10),
        parseFloat(workinghours[4], 10)]);
    }
    if (workinghours.length == 0) {
        usedhourchart.series[0].setData([0, 0, 0, 0, 0, 0]);

    }
    else if (workinghours.length > 0) {
        usedhourchart.series[0].setData([parseFloat(workinghours[0], 10), parseFloat(workinghours[1], 10), parseFloat(workinghours[2], 10),
        parseFloat(workinghours[3], 10), parseFloat(workinghours[4], 10), parseFloat(workinghours[5], 10)]);
    }
    var temptick;
    if (temperature.length > 0)
        temptick = Math.ceil(Math.min.apply(null, temperature));
    else
        temptick = 10;
    clearCharts();
    var ctx = document.getElementById("team-chart");
    ctx.height = 130;
    myChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: alabel,
            type: 'line',
            defaultFontFamily: 'Montserrat',
            datasets: [{
                data: temperature,
                label: "Temprature",
                backgroundColor: 'rgba(0,44,237,0.3)',
                borderColor: 'rgba(213,154,168,0.70)',
                borderWidth: 2,
                pointStyle: 'circle',
                pointRadius: 1,
                pointBorderColor: "rgba(255,255,255,1)",
                pointBackgroundColor: 'rgba(255,255,255,1)',
                pointHighlightStroke: "rgba(255,255,255,1)",
            },
            ]
        },
        options: {
            maintainAspectRatio: false,
            responsive: true,
            tooltips: {
                mode: 'index',
                titleFontSize: 12,
                titleFontColor: '#000',
                bodyFontColor: '#000',
                backgroundColor: '#fff',
                titleFontFamily: 'Montserrat',
                bodyFontFamily: 'Montserrat',
                cornerRadius: 3,
                intersect: false,
            },
            legend: {
                display: false,
                position: 'top',
                labels: {
                    usePointStyle: true,
                    fontFamily: 'Montserrat',
                },
            },
            scales: {
                xAxes: [{
                    display: true,
                    gridLines: {
                        display: false,
                    },
                    scaleLabel: {
                        display: true,
                        labelString: '时间',
                        fontSize: 16,

                    },
                    ticks: {
                        fontSize: 9,

                    }
                }],
                yAxes: [{
                    display: true,
                    gridLines: {
                        display: false,
                        zeroLineColor: '#fff',
                    },
                    scaleLabel: {
                        display: true,
                        labelString: '温度 (°C)',
                    },
                    ticks: {
                        min: temptick - 5,
                        stepSize: 2,
                        fontSize: 9,
                    }
                }]
            },
        }
    });
    //line chart
    var ctx = document.getElementById("lineChart");
    ctx.height = 130;
    myChart2 = new Chart(ctx, {
        type: 'line',
        data: {
            labels: alabel,
            datasets: [
                {
                    label: "湿度",
                    borderColor: "rgba(115,99,148,.9)",
                    borderWidth: "2",
                    backgroundColor: "rgba(233,221,255,.4)",
                    pointStyle: 'circle',
                    pointRadius: 0,
                    data: humid,
                },
                {
                    label: "PM2.5(µg/m3)",
                    borderColor: "rgba(0,200,155, 0.9)",
                    borderWidth: "2",
                    backgroundColor: "rgba(212,248,240, .4)",
                    pointHighlightStroke: "rgba(0,200,155,1)",
                    pointStyle: 'circle',
                    pointRadius: 0,
                    data: pm25,
                },
                {
                    label: "PM10(µg/m3)",
                    borderColor: "rgba(219,120,118, 0.9)",
                    borderWidth: "2",
                    backgroundColor: "rgba(241,196,195, .4)",
                    pointHighlightStroke: "rgba(219,120,118,1)",
                    pointStyle: 'circle',
                    pointRadius: 0,
                    data: pm10,
                }
            ]
        },
        options: {
            maintainAspectRatio: false,
            responsive: true,
            tooltips: {
                mode: 'index',
                intersect: false
            },
            hover: {
                mode: 'nearest',
                intersect: true
            },
            scales: {
                xAxes: [{
                    display: true,
                    gridLines: {
                        display: false,
                        drawBorder: true
                    },
                    scaleLabel: {
                        display: true,
                        labelString: '时间',
                        fontSize: 16,

                    },
                    ticks: {
                        fontSize: 9,
                    }
                }],
                yAxes: [{
                    display: true,
                    gridLines: {
                        display: false,
                        drawBorder: true
                    },
                    scaleLabel: {
                        display: true,
                        labelString: '数值'
                    },
                    ticks: {
                        min: 0,
                        stepSize: 10,
                        fontSize: 9,

                    }
                }]
            },

        }
    });
}

function computerOnline(total, data) {
    $('#c2').replaceWith($('<canvas id="c2" height="100%" style="width:100px!important;min-width:50px!important"></canvas>'));
    var ctx = document.getElementById('c2');
    chart6 = new Chart(ctx, {
        // The type of chart we want to create
        type: 'doughnut',

        // The data for our dataset
        data: {
            labels: ["On", "Off"],
            datasets: [{
                backgroundColor: ['#1759d3', 'white'],
                borderColor: '#fff',
                data: [total, data],
                borderWidth: [0, 0],
            }]
        },

        // Configuration options go here
        options: {
           
            maintainAspectRatio: false,
            cutoutPercentage: 80,
            //title: {
            //    display: false,
            //    text: 'No. of Computers',
            //},
            animation: {
                animateRotete: true,
            },
            legend: {
                display:false,
            },
           
        }
    });
}




