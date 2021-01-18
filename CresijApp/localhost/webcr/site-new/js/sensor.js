// JavaScript Document
$(document).ready(function(){
	console.log("1111111111");
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

	// //range
	// $(".range").mousemove(function(){
	// 	var value = $(this).val();
	// 	$(this).css("background","linear-gradient(90deg, #67b930 " + value + "%, #d4d4d4 " + value + "%)");
	// });
	// $(".range").click(function(){
	// 	var value = $(this).val();
	// 	$(this).css("background","linear-gradient(90deg, #67b930 " + value + "%, #d4d4d4 " + value + "%)");
	// });
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
		var pannelurl = $(this).attr("j-pannel-href");
		var pannelbox = $(this).attr("j-pannel-box");
		if( typeof menuurl == "string"){
			$(menubox).load(menuurl);
			console.log("菜单加载：" + menuurl + " => 目标:"+menubox);
			setTimeout(function(){
				$(pagebox).load(pageurl);
				// console.log("页面加载：" + pageurl);
			},30);
		}else{
		}
		if( typeof pageurl == "string"){
			$(pagebox).load(pageurl);
			console.log("页面加载："+pageurl+" => 目标:"+pagebox);
		}else{
		}
		if( typeof pannelurl == "string"){
			$(pannelbox).load(pannelurl);
			console.log("page:"+pannelurl+" => 目标:"+pannelbox);
		}else{
		}
	});
	//传递按钮状态至新加载页面
	// $("body").on("click",".JCHANMENU",function(){
	// 	$(this).parents(".JCHANNAV").children(".JCHANMENU").removeClass("active");
	// 	$(this).addClass("active");
	// 	var menuorder = $(this).attr("j-sub-order");
	// 	setTimeout(function(){
	// 			$(".JPAGENAV-01 a").removeClass("active");
	// 			$(".JPAGENAV-01 a").eq(menuorder).addClass("active");
	//
	// 	},20);
	// });
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
		$(this).children(".jactive").removeClass("jactive");
	});
	$("body").on("click",".option",function(){
		$(this).addClass("selected");
		$(this).children("input").attr("checked","true");
		$(this).parent(".list").fadeOut("fast");
		var name = $(this).text();
		var dropTarget = $(this).attr("drop-target");
		$(this).parents(".searchbox2").find(".name").text(name);
		$(this).parents(".searchbox2").next(".searchbox2").find(".drop_statu").css("display","none");
		$(this).parents(".searchbox2").next(".searchbox2").find("." + dropTarget).css("display","block");
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
		$(this).parents("div").find(".jtab_box").css("display","none");
		$(this).parents("div").find(".jtab_box").eq(tabno).css("display","inherit");
		$(this).parents("div").find(".jtab_box").eq(tabno).find("img").addClass("active");
	});
	//设备控制选项卡
	$("body").on("click",".tabbox-2",function(){
		var tabno2 = $(this).attr("jtab-order");
	  console.log(tabno2);
		$(this).parents(".jtab-comp").find(".tabbox-2").removeClass("active");
		$(this).addClass("active");
		$(this).parents(".jtab-comp").find(".jtab-box-2").css("display","none");
		$(this).parents(".jtab-comp").find(".jtab-box-2").eq(tabno2).css("display","inherit");
		$(this).parents(".jtab-comp").find(".jtab-box-2").eq(tabno2).find("img").addClass("active");
	});
	//常规下拉菜单
	$("body").on("click",".jdropdown2",function(){
		$(this).children(".jdropdown2-list").css("display","block");
		$(this).mouseleave(function(){
			$(this).children(".jdropdown2-list").fadeOut("fast");
		});
		$(this).children(".jdropdown2-list").children("label").click(function(){
			var select_option = $(this).html();
			$(this).parents(".jdropdown2").children(".jdropdown2-box").html(select_option);
			$(this).parents(".jdropdown2-list").fadeOut("fast");
		})
	});

	//全选-table
	$("body").on("click",".check_all_table",function(){
		$(this).addClass("check_all_table_active white bg_green");
		$(this).removeClass("check_all_table");
		$(this).parents("table").find("input[type='checkbox']").not(".j-single").prop("checked",true);
	});
	$("body").on("click",".check_all_table_active",function(){
		$(this).addClass("check_all_table");
		$(this).removeClass("check_all_table_active white bg_green");
		$(this).parents("table").find("input[type='checkbox']").not(".j-single").prop("checked",false);
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
	//手动自动审核
	$("body").on("click",".J-AM",function(){
		if( $(".J-A").hasClass("d-none") ){
			$(".J-A").removeClass("d-none");
			$(".J-M").addClass("d-none");
		}else{
			$(".J-A").addClass("d-none");
			$(".J-M").removeClass("d-none");
		}
	});
	//播放控制
	$("body").on("mousedown",".j-play-contrlo a",function(){
		$(this).css({backgroundColor:"#3AC4F3",color:"#fff"});
	});
	$("body").on("mouseup",".j-play-contrlo a",function(){
		$(this).css({backgroundColor:"#f5f5f5",color:"#8D8D8D"});
	});
	//播放列表
	$("body").on("click",".j-play-list a",function(){
		$(".j-play-list a").removeClass("active");
		$(this).addClass("active");
	});
	//三级菜单隐藏指定容器
	$("body").on("click",".j-t-show-01",function(){
		setTimeout(function(){
			$(".j-t-box-01").css("display","block");
		},20);
	});
	$("body").on("click",".j-t-hidden-01",function(){
		setTimeout(function(){
			$(".j-t-box-01").css("display","none");
		},20);
	});
	//设备参数设置
	$("body").on("click",".j-ctrl-btn",function(){
		if( $(this).parents(".j-ctrl-box").hasClass("j-set") ){
			$(this).parents(".j-ctrl-box").removeClass("j-set");
			$(this).parents(".j-ctrl-box").addClass("j-open");
		}else{
			$(this).parents(".j-ctrl-box").removeClass("j-open");
			$(this).parents(".j-ctrl-box").addClass("j-set");
		}
	});
	//按钮下拉菜单
	$("body").on("click",".j-dropbox-btn3",function(){
		$(this).next(".j-dropbox3").fadeIn("fast");
	});
	$("body").on("click",".j-dropbox-close3",function(){
		$(this).parents(".j-dropbox3").fadeOut("fast");
	});
	//播放器控制
	$("body").on("click",".j-ctrl-play",function(){
		if( $(this).hasClass("fa-pause-circle") ){
			$(this).removeClass("fa-pause-circle");
			$(this).addClass("fa-play-circle");
		}else{
			$(this).removeClass("fa-play-circle");
			$(this).addClass("fa-pause-circle");
		}
	});
	$("body").on("click",".j-video-mode",function(){
		$(".j-video-mode").removeClass("this");
		$(this).addClass("this");
	});
	$("body").on("click",".j-position .selection",function(){
		if( $(this).hasClass("active") ){
			$(this).removeClass("active");
			return false;
		}else{
			$(this).addClass("active");
			return false;
		}
	});
	$("body").on("click",".j-position-radio .selection",function(){
		$(this).parents(".j-position-radio").children(".selection").removeClass("active");
		$(this).addClass("active");
	});
	//云台控制效果
	$("body").on("mousedown",".yuntai-btn",function(){
		$(this).css("text-shadow","0 0 15px #3AC4F3");
	});
	$("body").on("mouseup",".yuntai-btn",function(){
		$(this).css("text-shadow","none");
	});
	//active状态控制 (active status control)
	$("body").on("click",".j-active-control-btn",function(){
		$(this).parents(".j-active-control").children(".j-active-control-btn").removeClass("active");
		$(this).addClass("active");
	});
	//视频窗布局激活 video layerout CTRL
	$("body").on("click",".j-thumb01",function(){
		$(this).parents(".j-thumb-opt").children("div").children(".j-thumb01").removeClass("active");
		$(this).addClass("active");
	});
	//视频语音控制
	$("body").on("click",".j-sound-btn",function(){
		if( $(this).hasClass("active") ){
			if( $(this).hasClass("call") ){
				$(this).children("span").text("呼叫");
				$(this).removeClass("active");
			}else{
				$(this).removeClass("active");
			}
		}else{
			if( $(this).hasClass("call") ){
				$(".j-sound-btn").removeClass("active");
				$(this).children("span").text("挂断");
				$(this).addClass("active");
			}else{
				$(".j-sound-btn").removeClass("active");
				$(this).addClass("active");
				$(".call").children("span").text("呼叫");
			}
		}
	});
	// 左侧菜单控制
	// --校区
	$("body").on("click",".left-menu-head",function(){
		$(".left-menu-head").next(".left-menu-dropbox").css("display","none");
		$(".left-menu-head").removeClass("active");
		$(this).next(".left-menu-dropbox").css("display","block");
		$(this).addClass("active");
	});
	// --楼栋
	$("body").on("click",".L-CTRL-01",function(){
		if( $(this).hasClass("fa-minus-square") ){
			$(this).removeClass("fa-minus-square");
			$(this).addClass("fa-plus-square");
			$(this).parents(".left-menu-building").next(".left-menu-building-dropbox").css("display","none");
		}else{
			$(".L-CTRL-01").removeClass("fa-minus-square");
			$(".L-CTRL-01").removeClass("fa-plus-square");
			$(".L-CTRL-01").addClass("fa-plus-square");
			$(this).removeClass("fa-plus-square");
			$(this).addClass("fa-minus-square");
			$(".left-menu-building-dropbox").css("display","none");
			$(this).parents(".left-menu-building").next(".left-menu-building-dropbox").css("display","table");
		}
	});
	// --楼层
	$("body").on("click",".L-CTRL-02",function(){
		if( $(this).hasClass("fa-minus-square") ){
			$(this).removeClass("fa-minus-square");
			$(this).addClass("fa-plus-square");
			$(this).parents(".left-menu-level").next(".left-menu-room").css("display","none");
		}else{
			$(".L-CTRL-02").removeClass("fa-minus-square");
			$(".L-CTRL-02").removeClass("fa-plus-square");
			$(".L-CTRL-02").addClass("fa-plus-square");
			$(this).removeClass("fa-plus-square");
			$(this).addClass("fa-minus-square");
			$(".left-menu-room").css("display","none");
			$(this).parents(".left-menu-level").next(".left-menu-room").css("display","table");
		}
	});
	// --全选
  // ----全选楼栋
	$("body").on("click",".check-building",function(){
		if( $(this).parents(".left-menu-building").hasClass("building-unchecked") ){
			$(this).parents(".left-menu-building").removeClass("building-unchecked");
			$(this).parents(".left-menu-building").addClass("building-checked");
			$(this).parents(".left-menu-building").next(".left-menu-building-dropbox").find("input[type='checkbox']").prop("checked",true);
			$(this).parents(".left-menu-building").next(".left-menu-building-dropbox").find(".check-level").parents(".left-menu-level").removeClass("level-unchecked");
			$(this).parents(".left-menu-building").next(".left-menu-building-dropbox").find(".check-level").parents(".left-menu-level").addClass("level-checked");
		}else{
			$(this).parents(".left-menu-building").removeClass("building-checked");
			$(this).parents(".left-menu-building").addClass("building-unchecked");
			$(this).parents(".left-menu-building").next(".left-menu-building-dropbox").find("input[type='checkbox']").prop("checked",false);
			$(this).parents(".left-menu-building").next(".left-menu-building-dropbox").find(".check-level").parents(".left-menu-level").removeClass("level-checked");
			$(this).parents(".left-menu-building").next(".left-menu-building-dropbox").find(".check-level").parents(".left-menu-level").addClass("level-unchecked");
		}
	});
	// ----全选楼层
	$("body").on("click",".check-level",function(){
		if( $(this).parents(".left-menu-level").hasClass("level-unchecked") ){
			$(this).parents(".left-menu-level").removeClass("level-unchecked");
			$(this).parents(".left-menu-level").addClass("level-checked");
			$(this).parents(".left-menu-level").next(".left-menu-room").find("input[type='checkbox']").prop("checked",true);
			console.log("check done");
		}else{
			$(this).parents(".left-menu-level").removeClass("level-checked");
			$(this).parents(".left-menu-level").addClass("level-unchecked");
			$(this).parents(".left-menu-level").next(".left-menu-room").find("input[type='checkbox']").prop("checked",false);
			console.log("check done");
		}
	});
	//顶部导航链接初始化   top menu
	$("body").on("click",".T-NAV",function(){
		setTimeout(function(){
			if( $(this).hasClass("T-NAV-00") ){
				$("#sec_box").load("");
			}else if( $(this).hasClass("T-NAV-01") ){
				$("#sec_box").load("window/p-equipment/001.html");
			}else if( $(this).hasClass("T-NAV-02") ){
				$("#sec_box").load("window/pages/course.html");
			}else if( $(this).hasClass("T-NAV-03") ){
				$("#sec_box").load("window/pages/course.html");
			}else if( $(this).hasClass("T-NAV-04") ){
				$("#sec_box").load("window/pages/course.html");
			}else if( $(this).hasClass("T-NAV-05") ){
				$("#sec_box").load("window/pages/course.html");
			}
		},100);
	});
	//楼栋选择
	$("body").on("click",".building_table td",function(){
		if($(this).hasClass("active")){
			$(this).removeClass("active");
		}else{
			$(this).addClass("active");
		}
	});
	$("body").on("click",".building_table .level",function(){
		if($(this).hasClass("active")){
			$(this).removeClass("active");
			$(this).closest("tr").children("td").removeClass("active");
		}else{
			$(this).addClass("active");
			$(this).closest("tr").children("td").addClass("active");
		}
	});
	$("body").on("click",".building_table .building",function(){
		if($(this).hasClass("active")){
			// $(this).removeClass("active");
			$(this).closest("table").find("td").removeClass("active");
			$(this).closest("table").find("th").removeClass("active");
		}else{
			// $(this).addClass("active");
			$(this).closest("table").find("td").addClass("active");
			$(this).closest("table").find("th").addClass("active");
		}
	});
	$("body").on("click",".chose-font-color",function(){
		$(this).closest("td").children(".chose-font-color").removeClass("active");
		$(this).addClass("active");
	});
	//设备控制按钮组
	$("body").on("click",".j-ctrl-btn",function(){
		$(this).parents(".j-ctrl-btn-group").find(".j-ctrl-btn").removeClass("active");
		$(this).addClass("active");
	});
	//静音
	$("body").on("click",".j-single-icon-btn",function(){
		if( $(this).hasClass("active") ){
			$(this).removeClass("active");
		}else{
			$(this).addClass("active");
		}
	});


//新建策略设备激活
// $("body").on("click",".j-forb",function(){
// 	if( $(this).hasClass("active") ){
// 		$(this).removeClass("active");
// 		$(this).closest(".stat-card").find(".j-mask2").css("display","none");
// 		$(this).closest(".stat-card").find(".j-ctrl-pannel").removeClass("forb-opc");
// 		$(this).closest(".stat-card").find(".bg_status").removeClass("forb");
// 		j-ctrl-pannel
// 	}else{
// 		$(this).addClass("active");
// 		$(this).closest(".stat-card").find(".j-mask2").css("display","block");
// 		$(this).closest(".stat-card").find(".j-ctrl-pannel").addClass("forb-opc")
// 		$(this).closest(".stat-card").find(".bg_status").addClass("forb");
// 	}
//
// });


	// $("body").on("click",".J_AM",function(){
	// 	if( $(this).find("input").prop("checked",false) ){
	// 		$(this).find("input").prop("checked",true);
	// 		// $(this).parents("table").children(".J-M").css("display","block");
	// 		// console.log( $(this).parents("table").children(".J-M").attr("class") );
	// 		// $(this).parents("table").children(".J-A").css("display","none");
	// 	}else{
	// 		// $(this).parents("table").children(".J-M").css("display","block");
	// 		// $(this).parents("table").children(".J-A").css("display","none");
	// 		$(this).find("input").prop("checked",false);
	// 	}
	//
	// });
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
