

(function ($) {
    var chat = $.connection.myHub;
    console.log("connection started 1");
    var myChart;
    var myChart2, myChart3, myChart4, myChart5;
    var temp = new Array(20);
    var humidity = new Array(20);
    var hum2 = new Array(20);
    var hum10 = new Array(20);
    var timenow = new Array(20);
    for (i = 0; i < 20; i++) {
        temp[i] = 0;
        humidity[i] = 0;
        hum2[i] = 0;
        hum10[i] = 0;
        timenow[i] = "";
    }
  //  chat.client.broadcastMessage = function (name, message) { };
 chat.client.broadcastMessage = function (name, message) {
        //document.getElementById("tempdata").style.display = "block";
        console.log(name);
        var ipName ="192.168.1.38";
        //var ip1 = document.getElementById("MainContent_masterchildBody_lblip");
        //var ips = '<%= session["ipforgraph"].ToString()%>';

        if (name == ipName) {
            var arraydata = message.split(',');
            if (arraydata[0] == "Temp") {
                //document.getElementById("tempvalue").innerText = arraydata[1];
                //document.getElementById("humidvalue").innerText = arraydata[2];
                //document.getElementById("hum25value").innerText = arraydata[3];
                //document.getElementById("hum10value").innerText = arraydata[4];

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
    }; 
    $.connection.hub.start({ waitForPageLoad: false }).done(function () {
        console.log("connection started");
       
        "use strict";
        //Team chart
        Chart.defaults.global.defaultFontColor = "#fff";
        Chart.defaults.scale.gridLines.color = "#f2faf8"
       
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

        var ctx = document.getElementById("UsedBarChart");
        ctx.height = 120;
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
                zeroLineColor: 'white',
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
                        }
                    }],
                    
                }
            }

        });

        var ctx = document.getElementById('c1');
        ctx.height = 70;
        var chart5 = new Chart(ctx, {
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
        ctx.height = 70;
        var chart6 = new Chart(ctx, {
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
        ctx.height = 70;
        var chart7 = new Chart(ctx, {
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
        ctx.height = 70;
        var chart8 = new Chart(ctx, {
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
        ctx.height = 70;
        var chart9 = new Chart(ctx, {
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
        ctx.height = 70;
        var chart10 = new Chart(ctx, {
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
                },
                toolTips: {
                    display: true,
                }
            }

        });
        var ctx = document.getElementById("carbondonut");
        
        myChart13 = new Chart(ctx, {
            type: 'line',
            
            data: {
                labels: ['10:00', '10:20', '10:30', '10:45', '11:00', '11:20', '11:30','12:00','12:15','12:30','12:45','13:00','13:15','13:30','13:45'],
                datasets: [{
                    data: [350, 200, 450, 300, 250, 400, 350,250,150,400,200,450,350,150,400],
                    label: "co2",
                    borderColor: "#3e95cd",
                    fill: false
                },
                ]
            },
            options: {
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
             "fontColor":"white",
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
//document.getElementById('randomizeData').addEventListener('click', function () {
//    configSpeed.data.current = Math.round(Math.random() * 240);
//    window.speed.update();
//    configDirection.data.current = Math.round(Math.random() * 180);
//    window.direction.update();
//});



