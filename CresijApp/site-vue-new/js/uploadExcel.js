﻿function Upload() {
    //Reference the FileUpload element.
    var fileUpload = document.getElementById("fileUpload");

    //Validate whether File is valid Excel file.
    var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.xls|.xlsx)$/;
    if (regex.test(fileUpload.value.toLowerCase())) {
        if (typeof (FileReader) != "undefined") {
            var reader = new FileReader();
            //For Browsers other than IE.
            if (reader.readAsBinaryString) {
                reader.onload = function (e) {
                    ProcessExcel(e.target.result);
                };
                reader.readAsBinaryString(fileUpload.files[0]);
            } else {
                //For IE Browser.
                reader.onload = function (e) {
                    var data = "";
                    var bytes = new Uint8Array(e.target.result);
                    for (var i = 0; i < bytes.byteLength; i++) {
                        data += String.fromCharCode(bytes[i]);
                    }
                    ProcessExcel(data);
                };
                reader.readAsArrayBuffer(fileUpload.files[0]);
            }
        } else {
            alert("This browser does not support HTML5.");
        }
    } else {
        alert("Please upload a valid Excel file.");
    }
};
function ProcessExcel(data) {
    //Read the Excel File data.
    var workbook = XLSX.read(data, {
        type: 'binary'
    });

    //Fetch the name of First Sheet.
    var firstSheet = workbook.SheetNames[0];

    //Read all rows from First Sheet into an JSON array.
    var excelRows = XLSX.utils.sheet_to_row_object_array(workbook.Sheets[firstSheet]);

    //Create a HTML Table element.
    var table = document.createElement("table");
    table.border = "1";
    var rowshtml = [];
    rowshtml += '<th class=""><label><i class="fa fa-check jcheckbox check_all_table"></i></label></th>'+
        '<th class="text-left pl-3">设备名称</th>'+
        '<th class="text-left pl-3">资产编号</th>'+
        '<th class="text-left pl-3">型号</th>'+
        '<th class="pl-3 text-left">规格</th>'+
        '<th class="text-left pl-3">设备类型</th>'+
        '<th class="text-left pl-3">购置价</th>'+
        '<th class="text-left pl-3">厂家</th>'+
        '<th class="text-left pl-3">出厂日期</th>'+
        '<th class="text-left pl-3">购置日期</th>'+
        '<th class="text-left pl-3">交付使用日期</th>'+
        '<th class="text-left pl-3">保质期</th>'+
        '<th class="text-left pl-3">位置类型</th>'+
        '<th class="pl-3 text-left">设备状态</th>'
    ////Add the header row.
    //var row = table.insertRow(-1);

    ////Add the header cells.
    //var headerCell = document.createElement("TH");
    //headerCell.innerHTML = "Device Name";
    //row.appendChild(headerCell);

    //headerCell = document.createElement("TH");
    //headerCell.innerHTML = "Asset Number";
    //row.appendChild(headerCell);

    //headerCell = document.createElement("TH");
    //headerCell.innerHTML = "Model";
    //row.appendChild(headerCell);

    //Add the data rows from Excel file.
    for (var i = 0; i < excelRows.length; i++) {
        //Add the data row.
        var row = table.insertRow(-1);

        //Add the data cells.
        var cell = row.insertCell(-1);
        cell.innerHTML = excelRows[i].Id;

        cell = row.insertCell(-1);
        cell.innerHTML = excelRows[i].Name;

        cell = row.insertCell(-1);
        cell.innerHTML = excelRows[i].Country;
    }

    var dvExcel = document.getElementById("dvExcel");
    dvExcel.innerHTML = "";
    dvExcel.appendChild(table);
};