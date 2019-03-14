function showGrid() {
    var tbscan = document.getElementById('tablescan');
    tbscan.style.display = "none";
    var gridmodal = document.getElementById('griddiv');
    gridmodal.style.display = "block";
    return false;
}
function hideGrid() {
    document.getElementById("checkcard").value = "";    
    var mymodal = document.getElementById('myModal');
    mymodal.style.display = 'none';
    var message = ' <%=Resources.Resource.AlertCardStatus%>'
    alert(message);
    return false;
}
function HideTree() {
    var modal = document.getElementById('modalAccess');
    modal.style.display = "none";
    inputs = document.getElementsByTagName("input");
    for (i = 0; i < inputs.length; i++) {
        if (inputs[i].type == "checkbox") {
            inputs[i].checked = false;
        }
    }
}
function xx() {
    var modal = document.getElementById('myModal');
    modal.style.display = "none";      
}
$(document).on("click", ".close1", function () {
    var modal = document.getElementById('modalAccess');
    modal.style.display = "none";
    inputs = document.getElementsByTagName("input");
    for (i = 0; i < inputs.length; i++) {
        if (inputs[i].type == "checkbox") {
            inputs[i].checked = false;
        }
    }
});
$(document).on("click", ".linkcursor", function () {
    var modal = document.getElementById('modalAccess');
    modal.style.display = "block";
});

window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

$(document).on("click", '<%#btnToSelect.ClientID%>', function () {

    var modal = document.getElementById('modalAccess');
    modal.style.display = "none";
    inputs = document.getElementsByTagName("input");
    for (i = 0; i < inputs.length; i++) {
        if (inputs[i].type == "checkbox") {
            inputs[i].checked = false;
        }
    }
});

$(document).on("change", "input:checkbox", function () {

    //});
    //$("[id*=TreeView1] input[type=checkbox]").bind("click", function () {
    var table = $(this).closest("table");
    if (table.next().length > 0 && table.next()[0].tagName == "DIV") {
        //Is Parent CheckBox
        var childDiv = table.next();
        var isChecked = $(this).is(":checked");
        $("input[type=checkbox]", childDiv).each(function () {
            if (isChecked) {
                $(this).attr("checked", "checked");
            } else {
                $(this).removeAttr("checked");
            }
        });
    } else {
        //Is Child CheckBox
        var parentDIV = $(this).closest("DIV");
        if ($("input[type=checkbox]", parentDIV).length == $("input[type=checkbox]:checked", parentDIV).length) {
            $("input[type=checkbox]", parentDIV.prev()).attr("checked", "checked");
        } else {
            $("input[type=checkbox]", parentDIV.prev()).removeAttr("checked");
        }
    }
});


   