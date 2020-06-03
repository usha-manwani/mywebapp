// JavaScript Document
$(document).ready(function(){
	//框架初始化
	$("#left_menu").load("components/left_menu.html");
	$("#top_menu").load("components/top_menu.html");
	$("#main_box").load("window/pages/course.html");
	//弹窗定位
	$("body").on("click",".show_jmodal",function(){
		setTimeout(function(){
			var jw = $(".jw-1").width();
			var jh = $(".jw-1").height();
			var ml = -1 * jw * 0.5 + "px";
			var mt =  -1 * jh * 0.5 + "px";
			$(".jw-1").css({
				"margin-left" : ml,
				"margin-top" : mt
			});
			console.log(ml)
		},20);
	})
	$("body").on("click",".alert_jmodal",function(){
		setTimeout(function(){
			var jw = $(".jw-1").width();
			var jh = $(".jw-1").height();
			var ml = -1 * jw * 0.5 + "px";
			var mt =  -1 * jh * 0.5 + "px";
			$(".jw-1").css({
				"margin-left" : ml,
				"margin-top" : mt
			});
			console.log(ml)
		},20);
	})

	//range
	$(".range").mousemove(function(){
		var value = $(this).val();
		$(this).css("background","linear-gradient(90deg, #67b930 " + value + "%, #d4d4d4 " + value + "%)");
	});
	$(".range").click(function(){
		var value = $(this).val();
		$(this).css("background","linear-gradient(90deg, #67b930 " + value + "%, #d4d4d4 " + value + "%)");
	});
	//弹窗控制
	$("body").on("click",".show_jmodal",function(){
		$(".jmodal").fadeIn("fast");
	});
	$("body").on("click",".close_jmodal",function(){
		$(".jmodal").fadeOut("fast");
	});

	//超链接动作
	$("body").on("click",".JURL",function(){
		var menuurl = $(this).attr("j-menu-href");
		var menubox = $(this).attr("j-menu-box");
		var pageurl = $(this).attr("j-page-href");
        var pagebox = $(this).attr("j-page-box");
        
		if( typeof menuurl == "string"){
            $(menubox).load(menuurl);
            
			//setTimeout(function(){
			//	$(pagebox).load(pageurl);
			//},30);
		}else{
		}
        if (typeof pageurl == "string") {
            if (pageurl.includes("EditOrganisation.html")) {
                console.log(pageurl.substring(46));
                $("#orgsno").attr('value', pageurl.substring(46));
            }
            else if (pageurl.includes("Edit_Teacher.html")) {
                console.log(pageurl.substring(42));
                $("#teacherid").attr('value', pageurl.substring(42));
            }
            else if (pageurl.includes("Edit_Student.html")) {
                console.log(pageurl.substring(42));
                $("#studentid").attr('value', pageurl.substring(42));
            }
            else if (pageurl.includes("DeleteOrg.html")) {
                console.log(pageurl.substring(34));
                $("#orgsno").attr('value', pageurl.substring(34));
            }
            else if (pageurl.includes("DeleteTeacher.html")) {
                console.log("teache id "+pageurl.substring(38));
                $("#teacherid").attr('value', pageurl.substring(38));
            }
            else if (pageurl.includes("DeleteStudent.html")) {
                console.log("stu id " +pageurl.substring(38));
                $("#studentid").attr('value', pageurl.substring(38));
            }
            else if (pageurl.includes("Edit_Classroom.html")) {
                console.log("Class id " + pageurl.substring(44));
                $("#classid").attr('value', pageurl.substring(44));
            }
            else if (pageurl.includes("DeleteClassroom.html")) {
                console.log("Class id " + pageurl.substring(40));
                $("#classid").attr('value', pageurl.substring(40));
            }
            else if (pageurl.includes("Edit_UserInfo.html")) {
                
                $("#userId").attr('value', pageurl.substring(43));
                console.log($("#userId").val());
            }
            else if (pageurl.includes("Delete_User.html")) {
                console.log("user id " + pageurl.substring(36));
                $("#userId").attr('value', pageurl.substring(36));
            }
            else if (pageurl.includes("002-1-1.html")) {
                console.log("sch id " + pageurl.substring(35));
                $("#schid").attr('value', pageurl.substring(35));
            }
            else if (pageurl.includes("003-1-1.html")) {
                var d = pageurl.substring(37);
                var strng = d.split('&');
                var section = strng[0];
                var classname = strng[1].substring(6);
                
                $("#section").attr('value', section);
                $("#classroom").attr('value', classname);
            }
			$(pagebox).load(pageurl);
			console.log("page:"+pageurl+"***box:"+pagebox);
		}else{
		}
	});
	//传递按钮状态至新加载页面
	$("body").on("click",".JCHANMENU",function(){
		$(this).parents(".JCHANNAV").children(".JCHANMENU").removeClass("active");
		$(this).addClass("active");
		var menuorder = $(this).attr("j-sub-order");
		setTimeout(function(){
				$(".JPAGENAV-01 a").removeClass("active");
				$(".JPAGENAV-01 a").eq(menuorder).addClass("active");

		},20);
	});
	$("body").on("click",".JPAGEMENU",function(){
		$(this).parents(".JPAGENAV").children(".JPAGEMENU").removeClass("active");
		$(this).addClass("active");
	});
	//导航组件控制
	$("body").on("click",".nav_page .jbtn",function(){
		$(".nav_page .jbtn").removeClass("active");
		$(this).addClass("active");
	});
	$("body").on("mousemove",".jdropdown",function(){
		$(this).children(".jnavdrop").fadeIn("fast");
		$(this).mouseleave(function(){
			$(this).children(".jnavdrop").fadeOut("fast");
		});
		$(this).children("a").click(function(){
			$(".jbtn").removeClass("active");
			$(this).addClass("active");
			$(this).parents(".jnavdrop").fadeOut("fast");
		});
	});
	//课表调课按钮动作course box btns
	$("body").on("mousemove",".coursebox.tk",function(){
		$(this).children(".action").fadeIn("fast");
		$(this).mouseleave(function(){
			$(this).children(".action").fadeOut("fast");
		});
	});
	//搜索框下拉菜单for bar01
	$("body").on("click",".searchbox2 .name",function(){
		$(this).next(".list").fadeIn("fast");
		$(this).addClass("jactive");
	});
	$("body").on("mouseleave",".searchbox2",function(){
		$(this).find(".list").fadeOut("fast");
		$(this).children(".jactive").removeClass("jactive")
	});
    $("body").on("click", ".option", function () {
        
		$(this).addClass("selected");
		$(this).children("input").attr("checked","true");
		$(this).parent(".list").fadeOut("fast");
		var name = $(this).text();
		$(this).parents(".searchbox2").find(".name").text(name);
	});
	//分页
	$("body").on("click",".JPAGE",function(){
		$(this).parents(".jpager").children(".CTRL").removeClass("disable");
		$(this).parents(".jpager").find(".JPAGER_CTRL").children(".JPAGE").removeClass("active");
		$(this).addClass("active");
		var numb = $(this).parents(".jpager").find(".JPAGER_CTRL").children(".JPAGE").length;
		if( $(this).index() == 0 ){
			$(this).parents(".jpager").children(".CTRL").removeClass("disable");
			$(this).parents(".jpager").children(".FIRST").addClass("disable");
			$(this).parents(".jpager").children(".PREV").addClass("disable");
		}else if( $(this).index() == numb - 1 ){
			$(this).parents(".jpager").children(".CTRL").removeClass("disable");
			$(this).parents(".jpager").children(".LAST").addClass("disable");
			$(this).parents(".jpager").children(".NEXT").addClass("disable");
		}else{ return false;}
	});
	$("body").on("click",".FIRST",function(){
		$(this).parents(".jpager").children(".CTRL").removeClass("disable");
		$(this).parents(".jpager").find(".JPAGER_CTRL").children(".JPAGE").removeClass("active");
		$(this).addClass("disable");
		$(this).parents(".jpager").children(".PREV").addClass("disable");
		$(this).parents(".jpager").find(".JPAGER_CTRL").children(".JPAGE").eq(0).addClass("active");
	});
	$("body").on("click",".LAST",function(){
		$(this).parents(".jpager").children(".CTRL").removeClass("disable");
		$(this).parents(".jpager").children(".JPAGE").removeClass("active");
		$(this).addClass("disable");
		$(this).parents(".jpager").children(".NEXT").addClass("disable");
		$(this).parents(".jpager").find(".JPAGER_CTRL").last(".JPAGE").addClass("active");
	});

	$("body").on("click",".NEXT",function(){
		if( $(this).parents(".jpager").find(".active").index(".JPAGE") != $(this).parents(".jpager").find(".JPAGER_CTRL").children(".JPAGE").length - 1 ){
			var now = $(this).parents(".jpager").find(".active").index(".JPAGE") + 1;
			$(this).parents(".jpager").find(".JPAGER_CTRL").children(".JPAGE").removeClass("active");
			$(this).parents(".jpager").find(".JPAGER_CTRL").children(".JPAGE").eq(now).addClass("active");
		}else{return false;}
	});

	$("body").on("click",".PREV",function(){
		if($(this).parents(".jpager").find(".active").index(".JPAGE") != 0){
			var now = $(this).parents(".jpager").find(".active").index(".JPAGE") - 1;
			$(this).parents(".jpager").find(".JPAGER_CTRL").children(".JPAGE").removeClass("active");
			$(this).parents(".jpager").find(".JPAGER_CTRL").children(".JPAGE").eq(now).addClass("active");
		}else{
			$(this).parents(".jpager").children(".CTRL").removeClass("disable");
			$(this).parents(".jpager").children(".FIRST").addClass("disable");
			$(this).parents(".jpager").children(".PREV").addClass("disable");
			return false;
		}
	});
	$("body").on("click",".ROOM_CTRL",function(){
		$(".ROOM_CTRL").removeClass("fa-minus-circle");
		$(".ROOM_CTRL").addClass("fa-plus-circle");
		$(this).removeClass("fa-plus-circle");
		$(this).addClass("fa-minus-circle");
		$(".jroom_box").css("display","none");
		$(this).parents("td").next("td").children(".jroom_box").css("display","block");
	});
	//选项卡
	$("body").on("click",".tabbox",function(){
		var tabno = $(this).index();
		$(".tabbox").removeClass("active");
		$(this).addClass("active");
		$(".jtab_box").css("display","none");
		$(".jtab_box").eq(tabno).css("display","block");
	});
	//常规下拉菜单
	$("body").on("click",".jdropdown2",function(){
		$(this).children(".jdropdown2-list").css("display","block");
		$(this).mouseleave(function(){
			$(this).children(".jdropdown2-list").fadeOut("fast");
		});
		$(this).children(".jdropdown2-list").children("label").click(function(){
			var select_option = $(this).text();
			$(this).parents(".jdropdown2").children(".jdropdown2-box").text(select_option);
			$(this).parents(".jdropdown2-list").fadeOut("fast");
		})
	});

	//全选-table
	$("body").on("click",".check_all_table",function(){
		$(this).addClass("check_all_table_active white bg_green");
		$(this).removeClass("check_all_table");
		$(this).parents("table").find("input[type='checkbox']").prop("checked",true);
	});
	$("body").on("click",".check_all_table_active",function(){
		$(this).addClass("check_all_table");
		$(this).removeClass("check_all_table_active white bg_green");
		$(this).parents("table").find("input[type='checkbox']").prop("checked",false);
	});
	//全选-tr
	$("body").on("click",".check_all_tr",function(){
		$(this).addClass("check_all_tr_active white bg_green");
		$(this).removeClass("check_all_tr");
		$(this).parents("tr").find("input[type='checkbox']").prop("checked",true);
	});
	$("body").on("click",".check_all_tr_active",function(){
		$(this).addClass("check_all_tr");
		$(this).removeClass("check_all_tr_active white bg_green");
		$(this).parents("tr").find("input[type='checkbox']").prop("checked",false);
	});
	//全选-td
	$("body").on("click",".check_all_td",function(){
		$(this).addClass("check_all_td_active white bg_green");
		$(this).removeClass("check_all_td");
		$(this).parents("td").next("td").find("input[type='checkbox']").prop("checked",true);
	});
	$("body").on("click",".check_all_td_active",function(){
		$(this).addClass("check_all_td");
		$(this).removeClass("check_all_td_active white bg_green");
		$(this).parents("td").next("td").find("input[type='checkbox']").prop("checked",false);
	});
	//码流锁定状态
	$("body").on("click",".jlock",function(){
		if( $(this).hasClass("fa-lock") ){
			$(this).removeClass("fa-lock");
			$(this).addClass("fa-unlock");
			$(this).attr("data-lock","unlock");
		}else{
			$(this).removeClass("fa-unlock");
			$(this).addClass("fa-lock");
			$(this).attr("data-lock","locked");
		}
	});

	//表格提示框
    $("body").on("mousemove",".jshowinfo",function(){
        $(this).children(".jinfo").fadeIn("fast");
		$(this).on("mouseleave",function(){
			$(this).children(".jinfo").fadeOut("fast");
		})
    });
    //$(document).off("mousemove").on("mousemove", ".jshowinfo", function () {
    //    $(this).children(".jinfo").fadeIn("fast");
    //    $(this).on("mouseleave", function () {
    //        $(this).children(".jinfo").fadeOut("fast");
    //    })
    //}); 

		// if( $(this).children("input[type='checkbox']").prop("checked") ){
		// 	$(this).parents("table").find("input[type='checkbox']").prop("checked");
		// }else{
		// 	$(this).parents("table").find("input[type='checkbox']").removeProp("checked");
		// }
		// $("input[type='checkbox']").attr("checked");

		// if($(this).attr("checked")){
		// 	$(this).parents("table").find("input[name='checkbox']").attr("checked");
		// 	console.log("checked");
		// }else{
		// 	$(this).parents("table").find("input[name='checkbox']").removeAttr("checked");
		// }

		// var before;
		// if($(this).hasClass("FIRST")){
		// 	$(this).parents(".jpager").find(".JPAGER_CTRL").children(".page").removeClass("active");
		// 	$(this).parents(".jpager").find(".JPAGER_CTRL").children(".page").eq(0).addClass("active");
		// 	$(this).addClass("disable");
		// 	$(this).parents(".jpager").find(".PREV").addClass("disable");
		// 	var before = 0;
		// 	console.log(before);
		// }else if($(this).hasClass("PREV")){
		// 	var before = $(this).parents(".jpager").find(".active").index(".page");
		// 	// alert("before0:"+before);
		// 	if(before != 0){
		// 		var after = before - 1;
		// 		// alert("after:"+after);
		//
		// 		// alert("before prev:"+before);
		// 		$(this).parents(".jpager").children(".JPAGER_CTRL").children("a").removeClass("active");
		// 		$(this).parents(".jpager").children(".JPAGER_CTRL").children("a").eq(after).addClass("active");
		// 		var before = after;
		// 		console.log(before);
		// 	}else{
		// 		$(this).addClass("disable");
		// 		var before = 0;
		// 		console.log(before);
		// 	}
		//
		//
		// }
		// else if($(this).hasClass("NEXT")){
		// 	var before = $(this).parents(".jpager").find(".active").index(".page");
		// 	var after = before + 1;
		// 	var before = after;
		// 	$(this).parents(".jpager").children(".JPAGER_CTRL").children("a").removeClass("active");
		// 	$(this).parents(".jpager").children(".JPAGER_CTRL").children("a").eq(after).addClass("active");
		// 	console.log(before);
		// }
		// else if($(this).hasClass("LAST")){
		// 	console.log(before);
		// }else{
		// 	if($(this).index() > 0){
		// 		$(this).parents(".jpager").find(".PREV").removeClass("disable");
		// 		$(this).parents(".jpager").find(".FIRST").removeClass("disable");
		// 		var before = $(this).index();
		// 		console.log(before);
		// 	}else{}
		// }
		// $(this).parents(".JPAGER_CTRL").children("a").removeClass("active");
		// $(this).addClass("active");



});
