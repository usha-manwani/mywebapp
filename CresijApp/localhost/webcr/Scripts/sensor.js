// JavaScript Document
$(document).ready(function(){
	$(".range").mousemove(function(){
		var value = $(this).val();
		$(this).css("background","linear-gradient(90deg, #67b930 " + value + "%, #d4d4d4 " + value + "%)")
	});
	$(".range").click(function(){
		var value = $(this).val();
		$(this).css("background","linear-gradient(90deg, #67b930 " + value + "%, #d4d4d4 " + value + "%)")
	});
	
});
	
