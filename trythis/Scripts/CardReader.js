$(function () {
    var chat = $.connection.myHub;
    chat.client.confirmRegister = function () {
        alert('Card Successfully Registered!!');
    }    
    chat.client.registerCard = function (name, message) {
        var text1 = document.getElementById("MainContent_masterchildBody_masterBody_info");
        text1.innerHTML = "";
        var mymodal = document.getElementById('myModal');
        mymodal.style.display = 'Flex';
        var tbscan = document.getElementById('tablescan');
        tbscan.style.display = "block";
        var gridmodal = document.getElementById('griddiv');
        gridmodal.style.display = "none";
        var arrayData = message.split(',');
        if (arrayData[0] == 'Reader') {
            if (arrayData[1] == 'Toregister') {
                
                var cc = "";
                cc = document.getElementById("checkcard").value;
                if (!cc.includes(arrayData[2])) {
                        cc = cc + " " + arrayData[2];
                        document.getElementById("checkcard").value = cc;
                        addNewCardID(arrayData[2]);
                    }    
            }
        }
    }
    $.connection.hub.start({ waitForPageLoad: false }).done(function () {
       
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
       
        //Add validation rule for dynamically generated email fields

        //$("#btnselect").click(function () {
        //    alert('btnselect clicked');
        //    GetSelected();
        //});
        //var btn1 = document.getElementById('btnselect');
        //btn1.onclick = function () {
        //    GetSelected();

        //};

    });  
});
function xx() {
    var modal = document.getElementById('myModal');
    modal.style.display = "none";
    var tbscan = document.getElementById('tablescan');
    tbscan.style.display = "none";
    document.getElementById("checkcard").value = "";
    $("#tablescan").find("tr:not(:first)").remove();
}
function trysolve(id, states) {
    var rownum = 0;
    var table = document.getElementById("MainContent_masterchildBody_masterBody_GridView1");
    var tabhide = document.getElementById("MainContent_masterchildBody_masterBody_tabhidden")
    for (i = 1; i < 6; i++) {
       
        if (document.getElementById("MainContent_masterchildBody_masterBody_GridView1").rows[i].cells[3].innerText == "") {
            document.getElementById("MainContent_masterchildBody_masterBody_GridView1").rows[i].cells[3].innerHTML = id;
            table.rows[i].cells[5].innerText = "unregistrerd";
            //table.rows[i].cell[3].getElementsByTagName("span").innerHTML = id;
            //alert('gotlabel');
            rownum = i - 1;
            alert('rownum  ' + rownum + '  i  ' + i);
            break;
        }
        
    }
    return rownum;
}
function getRowIndex(lnk) {
    var row = lnk.parentNode.parentNode;
    var rowIndex = row.rowIndex ;
    var r = document.getElementById('MainContent_masterchildBody_masterBody_indexselect');
    r.value = rowIndex;
    alert(r.value);
    
    return false;
}
//function GetSelected() {
    
//    var childCheckBox = '';
//    var parentCheckBox = '';
//    var chkparent = $('[alt*=Collapse]').closest('tr').find('input[type=checkbox]').next('a').each(function () {
//        parentCheckBox = parentCheckBox + $(this)[0].innerText + ',';
//    });
//    var chkChilds = $("input[type=checkbox]:checked").each(function () {
//        childCheckBox = childCheckBox + $(this).next('a')[0].innerText + ',';
//    });
//    var chkChilds = childCheckBox.substring(0, (childCheckBox.lastIndexOf(','))).split(',');
//    var chkparent = parentCheckBox.substring(0, (parentCheckBox.lastIndexOf(','))).split(',');
//    var result = $.grep(chkChilds, function (el) {
//        return $.inArray(el, chkparent) == -1;
//    });
//    var resultStr = result.join(',');
//    $('[id*=hfSelected]').val(resultStr);
//    alert('Selected Child : ' + resultStr);
//    var indexstring = document.getElementById('MainContent_masterBody_indexselect');
//    var indexvalue = parseInt(indexstring.value);
//    document.getElementById("MainContent_masterBody_GridView1").rows[indexvalue].cells[3].innerHTML = resultStr;
//    document.getElementById("modalAccess").style.display = "none";
//    return false;
//}
function addNewCardID(cardID)
{
    var tble = document.getElementById("cardtable");
    var new1 = tble.insertRow(-1);
    var cell1 = new1.insertCell(0);
    var txt1 = document.createElement("input");
    txt1.type = Text;
    txt1.name = "txtSno";
    cell1.appendChild(txt1);
    
    txt1.onkeypress = function () { return isNumberKey(event) };
    var cell2 = new1.insertCell(1);
    var txt2 = document.createElement("input");
    txt2.type = Text;
    txt2.name = "memID";
    cell2.appendChild(txt2);
    var cell3 = new1.insertCell(2);
    
    var txt3 = document.createElement("input");
    txt3.type = Text;
    txt3.name = "txtname";
    cell3.appendChild(txt3);
    txt3.onkeypress = function () { return isNameKey(event) };
   
    var cell4 = new1.insertCell(3);
    var txt4 = document.createElement("input");
    txt4.type = Text;
    txt4.name = "txtCard";
    txt4.value = cardID;
    txt4.disabled = 'disabled';
    cell4.appendChild(txt4);
   
    var cell5 = new1.insertCell(4);
    var txt5 = document.createElement("input");
    txt5.type = Text;
    txt5.name = "txtcom";
    cell5.appendChild(txt5);
    
}
function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        alert("Please enter a valid number")
        return false;
    }
    return true;
}  
function showGrid() {
    var tbscan = document.getElementById('tablescan');
    tbscan.style.display = "none";
    var gridmodal = document.getElementById('griddiv');
    gridmodal.style.display = "block";
    return false;
}
function hideGrid() {
    document.getElementById("checkcard").value = "";
    var gridmodal = document.getElementById('griddiv');
    gridmodal.style.display = "none";
    var mymodal = document.getElementById('myModal');
    mymodal.style.display = 'none';
    alert("Please check status of card !! ");
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
function isNameKey(evt) {
    var x = (evt.which) ? evt.which : event.keyCode;
    var c = String.fromCharCode(x);
    if (/^[A-Za-z ._-]+$/.test(c)) {
        return true;
    }
    else {
        alert("A name can contain letters, dot, hyphen and underscore only");
        return false;
    }
}
$(document).on('change', "*[name='txtSno']", function () {
    var text = document.getElementsByName("txtSno");    
    var txt;
    outerloop: for (i = 0; i < text.length; i++) {
        for (j = i + 1; j < text.length; j++) {
            if (text[i].value == text[j].value && text[i].value != "" && text[j]!="") {
                alert("Please enter different Serial Number Values!!")
                break outerloop;
            }
        }       
    }
});
$(document).on('change', "*[name='memID']", function () {
    var text = document.getElementsByName("memID");    
    var txt;
    outerloop: for (i = 0; i < text.length; i++) {
        for (j = i + 1; j < text.length; j++) {
            if (text[i].value == text[j].value && text[i].value != "" && text[j] != "") {
                alert("Please enter different Member IDs Values!!")
                break outerloop;
            }
        }
    }
});


