function GetInstitutes() {
    var jsonData = JSON.stringify({
        
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
        ListInstitute(response);
    }
    function OnErrorCall_(respo) {
        console.log(respo);
    }
}

function ListInstitute(response) {
    var data = response.d;
    var insid = data[0];
    var insname = data[1];
}