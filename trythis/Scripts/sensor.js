// JavaScript Document
$h = jQuery.noConflict();
$h(document).ready(function(){
	$h(".range").mousemove(function(){
		var value = $(this).val();
		$h(this).css("background","linear-gradient(90deg, #67b930 " + value + "%, #d4d4d4 " + value + "%)")
	});
	$h(".range").click(function(){
		var value = $h(this).val();
		$h(this).css("background","linear-gradient(90deg, #67b930 " + value + "%, #d4d4d4 " + value + "%)")
	});
	
});
	
