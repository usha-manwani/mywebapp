
    // Declare a proxy to reference the hub.
var chat = $.connection.myHub;

chat.client.TotalCount = function (count) {
    var counts = document.getElementById("TotalMachines");
    counts.innerText = count;
};
$.connection.hub.start().done(function () {
    chat.server.countTotal();
});
   
$(document).ready(function () {
    
    var jsonData = JSON.stringify({
        
        name: 'chart'
    });
    $.ajax({
        type: "POST",
        url: "Services/ChartData.asmx/GetLineChartData",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
    function OnSuccess_(response) {
        console.log(response.d);
        var aData = response.d;
        var aLabels = aData[1];
        var aDatasets1 = aData[0];

        var ctx = $("#myChart").get(0).getContext('2d');
        //ctx.canvas.height = 350;  // setting height of canvas
       // ctx.canvas.width = 500; // setting width of canvas
        var gradientStroke = ctx.createLinearGradient(500, 0, 100, 0);
        gradientStroke.addColorStop(0, '#80b6f4');
        gradientStroke.addColorStop(1, '#f49080');

        var gradientFill = ctx.createLinearGradient(500, 0, 100, 0);
        gradientFill.addColorStop(0, "rgba(128, 182, 244, 0.6)");
        gradientFill.addColorStop(1, "rgba(244, 144, 128, 0.6)");

        var data1 = {
            labels: aLabels,
            datasets: [{
                label: "User Activities",
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
                data: aDatasets1
            }],
        }

        var data2 = {
            labels: aLabels,
            datasets: [{
                data: aDatasets1,
            }],
        }
        var lineChart = new Chart(ctx, {
            type: 'line',
            data: data1,
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
                            labelString: 'Type of Activities',
                            fontSize: 16,
                            fontColor:'Gold',

                        },
                        ticks: {
                            fontSize: 10,
                            fontColor:'white',
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
                            labelString: '# of Activities',
                            fontSize: 16,
                            fontColor: 'Gold',
                        },
                        ticks: {
                            min: 0,
                            stepSize: 50,
                            fontSize: 12,
                            fontColor:'white',
                        }
                    }]
                },
            }
        });
        doughnut(aLabels, aDatasets1);
    }
    function OnErrorCall_(respo) {
        alert(respo);
    }
    
    function doughnut(alabels, datas) {
        
        var ctx = $("#pieChart").get(0).getContext('2d');
        //ctx.canvas.height = 200;
        chart = new Chart(ctx, {
            type: 'pie',
            data: {
                labels: alabels,
                datasets: [{
                    data: datas,
                }],
            },
            options: {
                maintainAspectRatio: false,
                legend: {
                    position: 'bottom',
                    fontColor:'white',
                },
            },
        });
        chartColors("cool");
    }
});
function chartColors(palette) {
    var currentPalette = "cool";
    if (!palette) palette = currentPalette;
    currentPalette = palette;

    /*Gradients
      The keys are percentage and the values are the color in a rgba format.
      You can have as many "color stops" (%) as you like.
      0% and 100% is not optional.*/
    var gradient;
    switch (palette) {
        case 'cool':
            gradient = {
                0: [255, 255, 255, 1],
                20: [220, 237, 200, 1],
                45: [66, 179, 213, 1],
                65: [26, 39, 62, 1],
                100: [0, 0, 0, 1]
            };
            break;
        case 'warm':
            gradient = {
                0: [255, 255, 255, 1],
                20: [254, 235, 101, 1],
                45: [228, 82, 27, 1],
                65: [77, 52, 47, 1],
                100: [0, 0, 0, 1]
            };
            break;
        case 'neon':
            gradient = {
                0: [255, 255, 255, 1],
                20: [255, 236, 179, 1],
                45: [232, 82, 133, 1],
                65: [106, 27, 154, 1],
                100: [0, 0, 0, 1]
            };
            break;
    }

    //Get a sorted array of the gradient keys
    var gradientKeys = Object.keys(gradient);
    gradientKeys.sort(function (a, b) {
        return +a - +b;
    });

    //Find datasets and length
    var chartType = chart.config.type;
    switch (chartType) {
        case "pie":
        case "doughnut":
            var datasets = chart.config.data.datasets[0];
            var setsCount = datasets.data.length;
            break;
        case "bar":
        case "line":
            var datasets = chart.config.data.datasets;
            var setsCount = datasets.length;
            break;
    }

    //Calculate colors
    var chartColors = [];
    for (i = 0; i < setsCount; i++) {
        var gradientIndex = (i + 1) * (100 / (setsCount + 1)); //Find where to get a color from the gradient
        for (j = 0; j < gradientKeys.length; j++) {
            var gradientKey = gradientKeys[j];
            if (gradientIndex === +gradientKey) { //Exact match with a gradient key - just get that color
                chartColors[i] = 'rgba(' + gradient[gradientKey].toString() + ')';
                break;
            } else if (gradientIndex < +gradientKey) { //It's somewhere between this gradient key and the previous
                var prevKey = gradientKeys[j - 1];
                var gradientPartIndex = (gradientIndex - prevKey) / (gradientKey - prevKey); //Calculate where
                var color = [];
                for (k = 0; k < 4; k++) { //Loop through Red, Green, Blue and Alpha and calculate the correct color and opacity
                    color[k] = gradient[prevKey][k] - ((gradient[prevKey][k] - gradient[gradientKey][k]) * gradientPartIndex);
                    if (k < 3) color[k] = Math.round(color[k]);
                }
                chartColors[i] = 'rgba(' + color.toString() + ')';
                break;
            }
        }
    }

    //Copy colors to the chart
    for (i = 0; i < setsCount; i++) {
        switch (chartType) {
            case "pie":
            case "doughnut":
                if (!datasets.backgroundColor) datasets.backgroundColor = [];
                datasets.backgroundColor[i] = chartColors[i];
                if (!datasets.borderColor) datasets.borderColor = [];
                datasets.borderColor[i] = "rgba(255,255,255,1)";
                break;
            case "bar":
                datasets[i].backgroundColor = chartColors[i];
                datasets[i].borderColor = "rgba(255,255,255,0)";
                break;
            case "line":
                datasets[i].borderColor = chartColors[i];
                datasets[i].backgroundColor = "rgba(255,255,255,0)";
                break;
        }
    }

    //Update the chart to show the new colors
    chart.update();
}



