﻿
var myChart;
var myChart2, myChart3, myChart4, myChart5;
var temp = new Array();
var humidity = new Array();
var hum2 = new Array();
var hum10 = new Array();
var timenow = new Array();
var defaultip = "";
(function ($) {
    var chat = $.connection.myHub;
    console.log("connection started 1");
    
   
    //for (i = 0; i < 20; i++) {
    //    temp[i] = 0;
    //    humidity[i] = 0;
    //    hum2[i] = 0;
    //    hum10[i] = 0;
    //    timenow[i] = "";
    //};  
    chat.client.broadcastMessage = function (name, message) {
        //document.getElementById("tempdata").style.display = "block";
        console.log(name);
        //var ipName ="192.168.1.38";  
        var tt = document.getElementById("MainContent_masterchildBody_lbllive").innerHTML;
        if (tt == "Live") {
            updatelivechart(name, message);
        }
    }; 
    $.connection.hub.start({ waitForPageLoad: false }).done(function () {
        console.log("connection started");
        $(document).on("click", "#team-chart", function () {
            
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
            var ctx = $("#tempModalChart").get(0).getContext('2d');
           
            new Chart(ctx, TempModalShow);
            //var myDoughnutChart = new Chart(ctx, {
            //    type: 'doughnut',
            //    data: data,
            //    options: {
            //        rotation: 1 * Math.PI,
            //        circumference: 1 * Math.PI,
            //        legend: {
            //            display: false,
            //        },
                   
            //    }
            //});
            document.getElementById("TempModal").style.display = "flex";
            console.log("modal error");
        });
        $(document).on("click", "#lineChart", function () {
            document.getElementById("HumidModal").style.display = "flex";
        });
        "use strict";
        //Team chart
        Chart.defaults.global.defaultFontColor = "#fff";
        Chart.defaults.scale.gridLines.color = "#f2faf8"

       // CreateAllChart();

        //var now = new Date();
        //var time = now.getHours() + ":" + now.getMinutes() + ":" + now.getSeconds();

        var ctx = document.getElementById("UsedBarChart");
        //ctx.height = 130;
        myChart4 = new Chart(ctx, {
            type: 'bar',
            data: {
                labels: ["投影机", "电脑", "录播", "空调", "中控", "屏幕"],
                datasets: [{
                    label: '# 小时',
                    data: [12, 19, 13, 15, 10, 8],
                    backgroundColor: [
                        'rgba(0,44,237, .9)',
                        'rgba(0,44,237, 0.9)',
                        'rgba(0,44,237, 0.9)',
                        'rgba(0,44,237, 0.9)',
                        'rgba(0,44,237, 0.9)',
                        'rgba(0,44,237, 0.9)'
                    ],
                    borderColor: [
                        'rgba(0,44,237,1)',
                        'rgba(0,44,237, 1)',
                        'rgba(0,44,237, 1)',
                        'rgba(0,44,237, 1)',
                        'rgba(0,44,237, 1)',
                        'rgba(0,44,237, 0.9)'
                    ],
                    borderWidth: 1
                }]
            },
            options: {
                maintainAspectRatio: false,
                zeroLineColor: 'white',
                legend: {
                    display: true,
                    position: 'bottom',
                },
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true,
                            
                        },
                        gridLines: {
                            zeroLineColor: '#fff',
                            display: false,
                        }
                        
                    }],
                    xAxes: [{
                        gridLines: {
                            zeroLineColor: '#fff',
                            display: false,
                        },
                        ticks: {
                            fontSize: 12,
                            fontFamily: "'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
                        }
                    }],
                    
                }
            }

        });

        var ctx = document.getElementById('c1');
       // ctx.height = 130;
        
        chart5 = new Chart(ctx, {
            // The type of chart we want to create
            type: 'doughnut',

            // The data for our dataset
            data: {
                labels: ["No of projectors", ""],
                datasets: [{
                    
                    backgroundColor: ['#2c76b2', 'white'],
                    borderColor: '#fff',
                    data: [20, 5],
                    borderWidth: [0, 0],
                }]
            },

            // Configuration options go here
            options: {
                maintainAspectRatio: false,
                cutoutPercentage: 80,
                title: {
                    display: false,
                    text: 'No. of Projector',
                    position: 'bottom',
                },
                animation: {
                    animateRotete: true,
                },
                legend: {
                    display: false
                },
                
            }
        });

        var ctx = document.getElementById('c2');
       // ctx.height = 130;
        
        chart6 = new Chart(ctx, {
            // The type of chart we want to create
            type: 'doughnut',

            // The data for our dataset
            data: {
                labels: ["Computers", ""],
                datasets: [{

                    backgroundColor: ['#1759d3', 'white'],
                    borderColor: '#fff',
                    data: [110, 10],
                    borderWidth: [0, 0],
                }]
            },

            // Configuration options go here
            options: {
                maintainAspectRatio: false,
                cutoutPercentage: 80,
                title: {
                    display: false,
                    text: 'No. of Computers',
                    
                },
                animation: {
                    animateRotete: true,
                },
                legend: {
                    display: false
                },

            }
        });

        var ctx = document.getElementById('c3');
       // ctx.height = 130;
       
        chart7 = new Chart(ctx, {
            // The type of chart we want to create
            type: 'doughnut',

            // The data for our dataset
            data: {
                labels: ["AC", ""],
                datasets: [{

                    backgroundColor: ['#6140a8', 'white'],
                    borderColor: '#fff',
                    data: [80, 15],
                    borderWidth: [0, 0],
                }]
            },

            // Configuration options go here
            options: {
                maintainAspectRatio: false,
                cutoutPercentage: 80,
                title: {
                    display: false,
                    text: 'No. of AC',
                   
                },
                animation: {
                    animateRotete: true,
                },
                legend: {
                    display: false
                },

            }
        });
        var ctx = document.getElementById('c4');
        //ctx.height = 130;
        
        chart8 = new Chart(ctx, {
            // The type of chart we want to create
            type: 'doughnut',

            // The data for our dataset
            data: {
                labels: ["FreshAir System", ""],
                datasets: [{

                    backgroundColor: ['#fb635a', 'white'],
                    borderColor: '#fff',
                    data: [200, 120],
                    borderWidth: [0, 0],
                }]
            },

            // Configuration options go here
            options: {
                maintainAspectRatio: false,
                cutoutPercentage: 80,
                title: {
                    display: false,
                    text: 'No. of Fresh Air System',
                    
                },
                animation: {
                    animateRotete: true,
                },
                legend: {
                    display: false
                },

            }
        });

        var ctx = document.getElementById('c5');
       // ctx.height = 130;
        
        chart9 = new Chart(ctx, {
            // The type of chart we want to create
            type: 'doughnut',

            // The data for our dataset
            data: {
                labels: ["Centrol Control Machine", ""],
                datasets: [{

                    backgroundColor: ['#da4265', 'white'],
                    borderColor: '#fff',
                    data: [100, 25],
                    borderWidth: [0, 0],
                }]
            },

            // Configuration options go here
            options: {
                maintainAspectRatio: false,
                cutoutPercentage: 80,
                title: {
                    display: false,
                    text: 'No. of Centrol Control Machine',
                    
                },
                animation: {
                    animateRotete: true,
                },
                legend: {
                    display: false
                },

            }
        });
        var ctx = document.getElementById('c6');
        //ctx.height = 130;
        
        chart10 = new Chart(ctx, {
            // The type of chart we want to create
            type: 'doughnut',

            // The data for our dataset
            data: {
                labels: ["Screen", ""],
                datasets: [{

                    backgroundColor: ['#7b4358', 'white'],
                    borderColor: '#fff',
                    data: [80, 15],
                    borderWidth: [0, 0],
                }]
            },

            // Configuration options go here
            options: {
                maintainAspectRatio: false,
                cutoutPercentage: 80,
                title: {
                    display: false,
                    text: 'No. of Digital Screen',
                   
                },
                animation: {
                    animateRotete: true,
                },
                legend: {
                    display: false
                },
                toolTips: {
                    display: true,
                }
            }
        });
      
        var ctx = document.getElementById("brightdonut");
        //ctx.height = 120;
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
                toolTips: {
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
       
        // Chart.types.Doughnut.extend({
        //    name: "DoughnutTextInside",
        //    showTooltip: function () {
        //        this.chart.ctx.save();
        //        Chart.types.Doughnut.prototype.showTooltip.apply(this, arguments);
        //        this.chart.ctx.restore();
        //    },
        //    draw: function () {
        //        Chart.types.Doughnut.prototype.draw.apply(this, arguments);

        //        var width = this.chart.width,
        //            height = this.chart.height;

        //        var fontSize = (height / 114).toFixed(2);
        //        this.chart.ctx.font = fontSize + "em Verdana";
        //        this.chart.ctx.textBaseline = "middle";

        //        var text = "82%",
        //            textX = Math.round((width - this.chart.ctx.measureText(text).width) / 2),
        //            textY = height / 2;

        //        this.chart.ctx.fillText(text, textX, textY);
        //    }
        //});

        //var data = [{
        //    value: 30,
        //    color: "#F7464A"
        //}, {
        //    value: 50,
        //    color: "#E2EAE9"
        //}];

        //var DoughnutTextInsideChart = new Chart($('#c5')[0].getContext('2d')).DoughnutTextInside(data, {
        //    responsive: true
        //});

 
    });
})(jQuery);

Chart.defaults.global.animation.duration = 0;

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
        "current": 35,
    },
    "options": {
        "panel": {
            "min": 0,
            "max": 100,
            "tickInterval": 1,
            "tickColor": "rgb(255, 255, 255)",
            "tickOuterRadius": 99,
            "tickInnerRadius": 95,
            "scales": [0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100],
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
        "current": 90,
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
            "text": "当前",
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

function func() {
    console.log("function worked");
    var machineonline = document.getElementById("MainContent_masterchildBody_machineStatus").innerText; 
    var machineoffline = document.getElementById("MainContent_masterchildBody_machineStatus1").innerText;
    var work = document.getElementById("MainContent_masterchildBody_work").innerText;
    var work1 = document.getElementById("MainContent_masterchildBody_work1").innerText;
    if (machineonline != "" && parseInt(machineonline, 10) != NaN) {
        cccc.series[0].setData([[parseInt(machineonline, 10)], [parseInt(machineoffline, 10)]]);
        cccc.series[1].setData([[parseInt(work1, 10)], [parseInt(work, 10)]]);
        ccc.series[0].setData([[Math.random()], [Math.random()]]);
    }
    else {
        console.log("no values");
    }

    
};
setInterval(func, 30 * 1000);
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
    var ctx = document.getElementById("tempModalChart");
    var myDoughnutChart = new Chart(ctx, {
        type: 'doughnut',
        data: data,
        options: {
            rotation: 1 * Math.PI,
            circumference: 1 * Math.PI
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

        aData = response.d;
        var alabel = aData[0];
        var temperature = aData[1];
        var humid = aData[2];
        var pm25 = aData[3];
        var pm10 = aData[4];
        var temptick = Math.ceil(Math.min.apply(null, temperature));
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
        url: "Services/ChartData.asmx/GetCustomData",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
    function OnSuccess_(response) {

        aData = response.d;
        aData = response.d;
        var alabel = aData[0];
        var temperature = aData[1];
        var humid = aData[2];
        var pm25 = aData[3];
        var pm10 = aData[4];
        var temptick = Math.ceil(Math.min.apply(null, temperature));
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
    function OnErrorCall_(respo) {
        console.log(respo);
    }
}

function updatelivechart(name, message) {

    var ipName = document.getElementById("MainContent_masterchildBody_ipgraph").value;
    if (defaultip == "") {
        defaultip = ipName;
        timenow.length = 20;
        temp.length = 20;
        humidity.length = 20;
        hum10.length = 20;
        hum2.length = 20;
        
        for (i = 0; i < 20; i++) {
            temp[i] = 0;
            humidity[i] = 0;
            hum2[i] = 0;
            hum10[i] = 0;
            timenow[i] = "";
        }
    }
    else {
        if (defaultip != ipName) {
            defaultip = ipName;
            timenow.length = 20;
            temp.length = 20;
            humidity.length = 20;
            hum10.length = 20;
            hum2.length = 20;
            pm10 = 0;
            pm25 = 0;
            for (i = 0; i < 20; i++) {
                temp[i] = 0;
                humidity[i] = 0;
                hum2[i] = 0;
                hum10[i] = 0;
                timenow[i] = "";
            }                
        }
    }
    if (name == defaultip) {
        var arraydata = message.split(',');
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
        };
    };
}