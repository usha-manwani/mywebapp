
$(function () {
    var jsonData = JSON.stringify({
        name: ""
    });
    $.ajax({
        type: "POST",
        url: "../Services/GetSideMenu.asmx/GetInstitute",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
});

function OnSuccess_(response) {
  
    ListInstitute(response);
    
}
function OnErrorCall_(respo) {
    console.log(respo);
}
function ListInstitute(response) {
    var data = response.d;
    var insid = data[0];
    var insname = data[1];
    var inner = '';
    var menuleft = document.getElementById("menu-left");
    for (i = 0; i < insid.length; i++) {
        var divs = document.createElement('div');
        divs.className = 'card';     
        menuleft.appendChild(divs);
        var div1 = document.createElement('div');
        div1.className = 'card-header';
        $(div1).attr('data-toggle', 'collapse');
        $(div1).attr('data-target', '#' + insid[i]);
        divs.appendChild(div1);       
        div1.innerHTML = '<i class="fa fa-folder-open" aria-hidden="ture"></i>' + insname[i];
        var div2 = document.createElement('div');
        //div2.classList = 'collapse no-gutters institute';
        $(div2).addClass('collapse no-gutters institute');
        if (i == 0) {
            $(div2).addClass('collapse no-gutters show institute');
            //div2.classList = 'collapse no-gutters show institute';

        }
        div2.id = insid[i];
        $(div2).attr('data-parent', '#menu-left');
        divs.appendChild(div2);
        var div3 = document.createElement('div');
        //div3.classList = 'card-body no-gutter';
        $(div3).addClass('card-body no-gutter');
        div2.appendChild(div3);
        var div4 = document.createElement('div');
       // div4.classList = 'btn-group-vertical col-12 no-gutter insertgrade';
        $(div4).addClass('insertgrade btn-group-vertical col-12 no-gutter');
        div3.appendChild(div4);
        
        GetGrade(insid[i]);
    }    
}

function GetGrade(insid) {
    var jsonData = JSON.stringify({
        name: insid
    });
    $.ajax({
        type: "POST",
        url: "../Services/GetSideMenu.asmx/GetGrades",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
    function OnSuccess_(response) {
        ListGrade(response,insid);
    }
    function OnErrorCall_(respo) {
        console.log(respo);
    }
}
function ListGrade(response,insid) {
    var data = response.d;
    var gradeid = data[0];
    var name = data[1];
    var parentid = ('#' + insid).toString();
    //var parentid = document.getElementById(insid);
    var maindiv = $(parentid).find('.insertgrade');
    
    if (gradeid.length > 0) {
        for (i = 0; i < gradeid.length; i++) {
            var div1 = document.createElement('div');
            //div1.classList = 'btn-group no-gutters';
            $(div1).addClass('btn-group no-gutters');
            maindiv[0].appendChild(div1);
            var div2 = document.createElement('div');
            //div2.classList = 'menu-item btn-block text-left small';
            $(div2).addClass('menu-item btn-block text-left small');
            $(div2).attr('data-toggle', 'dropdown');
            div1.appendChild(div2);            
            div2.innerHTML = '<i class="fa grade fa-th" aria-hidden="ture"></i>' + name[i];
            var ul1 = document.createElement('ul');
           // ul1.classList = 'dropdown-menu small';
            $(ul1).addClass('dropdown-menu small');
            ul1.style.marginLeft = '99%';
            ul1.style.marginTop = '-40px';
            div1.appendChild(ul1);
            GetClass(gradeid[i], ul1);
        }
    }
}

function GetClass(gradeid,ul1) {
    var jsonData = JSON.stringify({
        name: gradeid
    });
    $.ajax({
        type: "POST",
        url: "../Services/GetSideMenu.asmx/GetClasses",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
    function OnSuccess_(response) {
        ListClass(response,ul1);
    }
    function OnErrorCall_(respo) {
        console.log(respo);
    }
}
function ListClass(response, ul1) {
    var data = response.d;
    var classid = data[0];
    var name = data[1];
    if (classid.length > 0) {
        for (i = 0; i < classid.length; i++) {
            var li1 = document.createElement('li');
            li1.id = classid[i];
            $(li1).addClass('getclassid');
            ul1.appendChild(li1);
            var link = document.createElement('span');
            // link.href = "";
            $(link).addClass('dropdown-item');
            //link.className = 'dropdown-item getclassid';
            link.innerHTML = '<i class="fa fa-angle-double-right" aria-hidden="true"></i>' + name[i];
            li1.appendChild(link);
        }
    }
}







