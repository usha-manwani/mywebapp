
function saveandhideDevices() {
    var proj = document.getElementById('MainContent_masterchildBody_masterBody_projtb').value;
    var pc = document.getElementById('MainContent_masterchildBody_masterBody_pctb').value;
    var recorder = document.getElementById('MainContent_masterchildBody_masterBody_recordtb').value;
    var ac = document.getElementById('MainContent_masterchildBody_masterBody_actb').value;
    var screen = document.getElementById('MainContent_masterchildBody_masterBody_screentb').value;
    var loc = $('#MainContent_masterchildBody_masterBody_ddlInstitute').val();
    var name =[];
    name[0] = proj;
    name[1] = pc;
    name[2] = recorder;
    name[3] = ac;
    name[4] = screen;
    name[5] = loc;
    var jsonData = JSON.stringify({
        name: name
    });
    $.ajax({
        type: "POST",
        url: "Services/ChartData.asmx/SaveDevicesCount",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
    function OnSuccess_(response) {

        console.log("saved");
    }
    function OnErrorCall_(respo) {
        console.log(respo);
    }

}
function displaydevicesPopup() {
    document.getElementById("addeditdevices").style.display = 'inline-block';
}
function hidedevicesDiv() {
    document.getElementById("addeditdevices").style.display = 'none';
}
function displayUnivPopup() {
    document.getElementById("idAddUniv").style.display = 'inline-block';
}
function hideUnivDiv() {
    document.getElementById("idAddUniv").style.display = 'none';
}
function displayGrade() {
    document.getElementById('idGrade').style.display = 'inline-block';
}
function displayClass() {
    document.getElementById('idClass').style.display = 'inline-block';
}
function displayCam() {
    document.getElementById('idCamera').style.display = 'inline-block';
}
function displayPopup() {
    document.getElementById('id01').style.display = 'inline-block';
}
function xx() {
    document.getElementById('idGrade').style.display = 'none';
}
function xx1() {
    document.getElementById('id01').style.display = 'none';
}
function hideClass() {
    document.getElementById('idClass').style.display = 'none';
}
function hideCam() {
    document.getElementById('idCamera').style.display = 'none';
}
function duplicateIP() {
    var message = ' <%=Resources.Resource.AlertErrorIP%>'
    alert(message);
}
function CamIns() {
    var message = ' <%=Resources.Resource.NoMoreCam%>'
    alert(message);
}
function camError() {
    var message = ' <%=Resources.Resource.AlertError%>'
    alert(message);
}

//Get Modal for Ins Grade


function GetDynamicTextBoxIns(value) {
    return '<div class="form-group">' + '<asp:Label runat="server" Text="<%$Resources:Resource, Grade %>" CssClass="col-sm-2 control-label" Font-Bold="True"/>' +
        '<div class="col-sm-10"><input name = "DynamicTextBox" class="form-control" type="text" value = "' + value + '" /></div></div>'
}

function AddTextGrade1() {
    var div = document.createElement('DIV');
    div.innerHTML = GetDynamicTextBoxIns("");
    document.getElementById("TextBoxContainer1").appendChild(div);
}

// Get the modal
function GetDynamicTextBox(value) {
    return '<div class="form-group row  margintop">' + '<asp:Label runat="server" Text="<%$Resources:Resource, Grade %>" CssClass="col-md-5 control-label labelpadding" Font-Bold="True"/>' +
        '<div class="col-md-7"><input name = "DynamicTextBox" class="form-control" type="text" value = "' + value + '" /></div></div>'
}

function AddTextGrade() {
    var div = document.createElement('DIV');
    div.innerHTML = GetDynamicTextBox("");
    document.getElementById("TextBoxContainer").appendChild(div);

}

function GetDynamicTextClass(value) {
    return '<div class="form-group row  margintop">' + '<asp:Label runat="server" Text="<%$Resources:Resource, Class %>" CssClass="col-md-5 control-label labelpadding" Font-Bold="True"/>' +
        '<div class="col-md-7"><input name = "DynamicTextClass" class="form-control" type="text" value = "' + value + '" /></div></div>' +
        '<div class="form-group row  margintop">' + '<asp:Label runat="server" Text="<%$Resources:Resource, CCIPAddress %>" CssClass="col-md-5 control-label labelpadding" Font-Bold="True"/>' +
        '<div class="col-md-7"><input name = "DynamicIP" class="form-control" type="text" value = "' + value + '" /></div></div>';
}

function AddTextClass() {
    var div = document.createElement('DIV');
    div.innerHTML = GetDynamicTextClass("");
    document.getElementById("TextContainer").appendChild(div);
}


//Edit Devices Scripts


function Rename() {
    document.getElementById('DivRename').style.display = 'Flex';
}
function EditCam() {
    document.getElementById('edit').style.display = 'Flex';
}
function hideEdit() {
    document.getElementById('edit').style.display = 'none';
}
function hideRename() {
    document.getElementById('DivRename').style.display = 'none';
}
function DeviceNotEdit() {
    var message = '<%=Resources.Resource.AlertEditIP%>'
    alert(message);
}
function donothing() {
    var message = '<%=Resources.Resource.AlertEditNot%>'
    alert(message);
}


//Delete Devices

function ConfirmDel() {
    document.getElementById('del').style.display = 'Flex';
}
function hideDelConfirm() {
    document.getElementById('del').style.display = 'none';
}
function hideDelNot() {
    document.getElementById('delnot').style.display = 'none';
}
function nodelete() {
    var message = '<%=Resources.Resource.AlertDelete%>';
    alert(message);
}

var c = document.getElementById('idClass');
var modal = document.getElementById('id01');
var m = document.getElementById('idGrade');
var cam = document.getElementById('idCamera');
var del = document.getElementById('del');
var dn = document.getElementById('delnot');
var ec = document.getElementById('edit');

// When the user clicks anywhere outside of the modal, close it
document.body.onclick = function (event) {
    if (event.target == del) {
        del.style.display = "none";
    }

    else if (event.target == cam) {

        cam.style.display = "none";

    }
    else if (event.target == modal) {
        modal.style.display = "none";
    }
    else if (event.target == m) {
        m.style.display = "none";
    }
    else if (event.target == c) {
        c.style.display = "none";
    }
    else if (event.target == dn) {
        dn.style.display = "none";
    }
    else if (event.target == ec) {
        ec.style.display = 'none';
    }
}
function closeframe() {
    document.getElementById('id01').style.display = "none";
}


