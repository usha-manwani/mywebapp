(function ($) {
    var myChart;
    var myChart2;
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
    var chat = $.connection.myHub;
    chat.client.broadcastMessage = function (name, message) {
        //document.getElementById("tempdata").style.display = "block";
     
        var ipName = $("#ipgraph").val();
        var ip1 = document.getElementById("MainContent_masterchildBody_lblip");
        var ips = '<%= session["ipforgraph"].ToString()%>';

        if (name == ipName)
        {                    
        var arraydata = message.split(',');
            if (arraydata[0] == "Temp") {
                document.getElementById("tempvalue").innerText = arraydata[1];
                document.getElementById("humidvalue").innerText = arraydata[2];
                document.getElementById("hum25value").innerText = arraydata[3];
                document.getElementById("hum10value").innerText = arraydata[4];
                
            var today = new Date();              
            var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds() ;
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
                            display: true,
                            drawBorder: true
                        },
                        scaleLabel: {
                            display: true,
                            labelString: 'Time',
                            fontSize: 20,
                        },
                        ticks: {
                            fontSize: 9,
                        }
                    }],
                    yAxes: [{
                        display: true,
                        gridLines: {
                            display: true,
                            drawBorder: true
                        },
                        scaleLabel: {
                            display: true,
                            labelString: 'Temperature (°C)',

                        },
                        ticks: {
                            min: tempo - 8,
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
                            display: true,
                            drawBorder: true
                            },
                            scaleLabel: {
                            display: true,
                            labelString: 'Time',
                            fontSize: 20,
                            },
                            ticks: {
                            fontSize: 9,
                            }
                        }],
                        yAxes: [{
                            display: true,
                            gridLines: {
                            display: true,
                            drawBorder: true
                            },
                            scaleLabel: {
                            display: true,
                            labelString: 'Value'
                            },
                            ticks: {
                            min: mini-8,
                            stepSize: 5,
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
        alert("connected");
        updateChart();
        $(document).on("change", "select", function () {
            $('#nameip').text = $(this).val();
            document.getElementById("tempvalue").innerText = 0;
            document.getElementById("humidvalue").innerText = 0;
            document.getElementById("hum25value").innerText = 0;
            document.getElementById("hum10value").innerText = 0;
            document.getElementById("team-chart").remove();
            document.getElementById("sales-chart").remove();
            document.getElementById("lineChart").remove();
            var c1 = document.createElement("canvas");
            c1.id = "team-chart";
            document.getElementById("teamdiv").appendChild(c1);
            var c2 = document.createElement("canvas");
            c2.id = "sales-chart";
            document.getElementById("humdiv1").appendChild(c2);
            var c3 = document.createElement("canvas");
            c3.id = "lineChart";
            document.getElementById("humdiv").appendChild(c3);
            "use strict";
            //Team chart
            var ctx = document.getElementById("team-chart");
            var now = new Date();
            var time = now.getHours() + ":" + now.getMinutes() + ":" + now.getSeconds();
            ctx.height = 150;
             myChart = new Chart(ctx, {
                type: 'line',
                data: {
                    labels: [time],
                    type: 'line',
                    defaultFontFamily: 'Montserrat',
                    datasets: [{
                        //data: [0, 7, 3, 5, 2, 8, 6],
                        label: "Temprature",
                        backgroundColor: 'rgba(0,200,155,.3)',
                        borderColor: 'rgba(0,200,155,0.70)',
                        borderWidth: 1,
                        pointStyle: 'circle',
                        pointRadius: 2,
                        //pointBorderColor: 'transparent',
                        //pointBackgroundColor: 'rgba(0,200,155,0.60)',
                        pointHighlightStroke: "rgba(0,200,155,1)",
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
                                display: true,
                                drawBorder: true
                            },
                            scaleLabel: {
                                display: true,
                                labelString: 'Time',
                                fontSize: 20,
                            },
                            ticks: {
                                fontSize: 9,
                            }
                        }],
                        yAxes: [{
                            display: true,
                            gridLines: {
                                display: true,
                                drawBorder: true
                            },
                            scaleLabel: {
                                display: true,
                                labelString: 'Temperature (°C)',
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
            //Sales 
            var ctx = document.getElementById("sales-chart");
            ctx.height = 150;
            var myChart1 = new Chart(ctx, {
                type: 'line',
                data: {
                    labels: [time],
                    type: 'line',
                    defaultFontFamily: 'Montserrat',
                    datasets: [{
                        label: "Humidity",
                        //data: [0, 30, 15, 110, 50, 63, 120],
                        backgroundColor: 'transparent',
                        borderColor: 'rgba(145,109,59,0.75)',
                        borderWidth: 3,
                        pointStyle: 'circle',
                        pointRadius: 5,
                        pointBorderColor: 'transparent',
                        pointBackgroundColor: 'rgba(145,109,59,0.75)',
                    }, {
                        label: "PM2.5(µg/m3)",
                        //data: [0, 50, 40, 80, 35, 99, 80],
                        backgroundColor: 'transparent',
                        borderColor: 'rgba(85,115,124,0.75)',
                        borderWidth: 3,
                        pointStyle: 'circle',
                        pointRadius: 5,
                        pointBorderColor: 'transparent',
                        pointBackgroundColor: 'rgba(85,115,124,0.75)',
                    }, {
                        label: "PM10(µg/m3)",
                        //data: [0, 50, 40, 80, 35, 99, 80],
                        backgroundColor: 'transparent',
                        borderColor: 'rgba(102,187,106,0.75)',
                        borderWidth: 3,
                        pointStyle: 'circle',
                        pointRadius: 5,
                        pointBorderColor: 'transparent',
                        pointBackgroundColor: 'rgba(102,187,106,0.75)',
                    }]
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
                        labels: {
                            usePointStyle: true,
                            fontFamily: 'Montserrat',
                        },
                    },
                    scales: {
                        xAxes: [{
                            display: true,
                            gridLines: {
                                display: true,
                                drawBorder: true
                            },
                            scaleLabel: {
                                display: true,
                                labelString: 'time'
                            }
                        }],
                        yAxes: [{
                            display: true,
                            gridLines: {
                                display: false,
                                drawBorder: false
                            },
                            scaleLabel: {
                                display: true,
                                labelString: 'Value'
                            },
                            ticks: {
                                min: 20,
                                stepSize: 5,
                            }
                        }]
                    },
                    title: {
                        display: true,
                        text: 'Humidity'
                    }
                }
            });

            //line chart
            var ctx = document.getElementById("lineChart");
            ctx.height = 150;
             myChart2 = new Chart(ctx, {
                type: 'line',
                data: {
                    labels: [time],
                    datasets: [
                        {
                            label: "Humidity",
                            borderColor: "rgba(115,99,148,.9)",
                            borderWidth: "1",
                            backgroundColor: "rgba(115,99,148,.4)",
                            pointStyle: 'circle',
                            pointRadius: 0
                            // data: [20, 47, 35, 43, 65, 45, 35]
                        },
                        {
                            label: "PM2.5(µg/m3)",
                            borderColor: "rgba(0,200,155, 0.9)",
                            borderWidth: "1",
                            backgroundColor: "rgba(0,200,155, 0.4)",
                            pointHighlightStroke: "rgba(0,200,155,1)",
                            pointStyle: 'circle',
                            pointRadius: 0
                            // data: [16, 32, 18, 27, 42, 33, 44]
                        },
                        {
                            label: "PM10(µg/m3)",
                            borderColor: "rgba(219,120,118, 0.9)",
                            borderWidth: "1",
                            backgroundColor: "rgba(219,120,118, 0.4)",
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
                                display: true,
                                drawBorder: true
                            },
                            scaleLabel: {
                                display: true,
                                labelString: 'Time',
                                fontSize: 20,
                            },
                            ticks: {
                                fontSize: 9,
                            }
                        }],
                        yAxes: [{
                            display: true,
                            gridLines: {
                                display: true,
                                drawBorder: true
                            },
                            scaleLabel: {
                                display: true,
                                labelString: 'Value'
                            },
                            ticks: {
                                min: 0,
                                stepSize: 5,
                                fontSize: 7,
                            }
                        }]
                    },

                }
            });
        });
       
    });
})(jQuery);

function updateChart() {
    var ctx = document.getElementById("myChart").getContext('2d');
    var myChart4 = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: ["Red", "Blue", "Yellow", "Green", "Purple", "Orange"],
            datasets: [{
                label: '# of Power',
                data: [12, 19, 3, 5, 2, 3],
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 206, 86, 0.2)',
                    'rgba(75, 192, 192, 0.2)',
                    'rgba(153, 102, 255, 0.2)',
                    'rgba(255, 159, 64, 0.2)'
                ],
                borderColor: [
                    'rgba(255,99,132,1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)',
                    'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)',
                    'rgba(255, 159, 64, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
   
    var ctx1 = document.getElementById("myChart1").getContext('2d');
    var myChart5 = new Chart(ctx1, {
        type: 'bar',
        data: {
            labels: ["Red", "Blue", "Yellow", "Green", "Purple", "Orange"],
            datasets: [{
                label: '# of Voltage',
                data: [12, 19, 13, 15, 10, 17],
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 206, 86, 0.2)',
                    'rgba(75, 192, 192, 0.2)',
                    'rgba(153, 102, 255, 0.2)',
                    'rgba(255, 159, 64, 0.2)'
                ],
                borderColor: [
                    'rgba(255,99,132,1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)',
                    'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)',
                    'rgba(255, 159, 64, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
    var ctx2 = document.getElementById("myChart2").getContext('2d');
    var myChart6 = new Chart(ctx2, {
        type: 'bar',
        data: {
            labels: ["Red", "Blue", "Yellow", "Green", "Purple", "Orange"],
            datasets: [{
                label: '# of Hours',
                data: [2, 9, 3, 5, 2, 3],
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 206, 86, 0.2)',
                    'rgba(75, 192, 192, 0.2)',
                    'rgba(153, 102, 255, 0.2)',
                    'rgba(255, 159, 64, 0.2)'
                ],
                borderColor: [
                    'rgba(255,99,132,1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)',
                    'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)',
                    'rgba(255, 159, 64, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
    var ctx3 = document.getElementById("myChart3").getContext('2d');
    var myChart7 = new Chart(ctx3, {
        type: 'bar',
        data: {
            labels: ["Red", "Blue", "Yellow", "Green", "Purple", "Orange"],
            datasets: [{
                label: '# of Hours',
                data: [2, 7, 6, 12, 9, 3],
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 206, 86, 0.2)',
                    'rgba(75, 192, 192, 0.2)',
                    'rgba(153, 102, 255, 0.2)',
                    'rgba(255, 159, 64, 0.2)'
                ],
                borderColor: [
                    'rgba(255,99,132,1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)',
                    'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)',
                    'rgba(255, 159, 64, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
   
}




