/*---LEFT BAR ACCORDION----*/
$(function () {
   
  //$('#nav-accordion').dcAccordion({
  //  eventType: 'click',
  //  autoClose: true,
  //  saveState: true,
  //  disableLink: true,
  //  speed: 'slow',
  //  showCount: false,
  //  autoExpand: true,
  //  //        cookie: 'dcjq-accordion-1',
  //  classExpand: 'dcjq-current-parent'
  //});
});

var Script = function () {
    //    sidebar dropdown menu auto scrolling

    jQuery('#sidebar .sub-menu > a').click(function () {
        var o = ($(this).offset());
        diff = 250 - o.top;
        if (diff > 0)
            $("#sidebar").scrollTo("-=" + Math.abs(diff), 500);
        else
            $("#sidebar").scrollTo("+=" + Math.abs(diff), 500);
    });

    function responsiveView()
        {
            console.log("Window width " +$(window).width());
            console.log("Document width " + $(document).width());
            console.log("Document Hieght " + $(document).height()); 
            var wSize = $(window).width();            
            if (wSize <= 768) {
                $('#container').addClass('sidebar-close');                
                $('#sidebar > ul').hide();
                $('#sidebar').width = '100%';
            }

            if (wSize > 768) {
                $('#container').removeClass('sidebar-close');              
                $('#sidebar > ul').show();
            }
            if (wSize > 1000 && wSize < 1300)
            {
                $('body').css('font-size', "14px");
                console.log("font decresed");
            }
            
            //else if (wSize > 1300) {
            //    $('div').css('font-size', "16px");
            //    console.log("font incresed");
            //}
            else if (wSize<1000)
            {
                $('body').css('font-size', "12px");
                console.log("font smallest");
            }
        }

    $(window).on('load', responsiveView);
    $(window).on('resize', responsiveView);
    //    sidebar toggle
    $(document).on('click', '.fa-bars', function () {
        if ($('#sidebar > ul').is(":visible") === true) {
            $('#main-content').css({
                'margin-left': '0px'
            });
            $('#sidebar').css({
                'margin-left': '-250px'
            });
            $('#sidebar > ul').hide();
            $("#container").addClass("sidebar-closed");
        }
        else {

            $('#main-content').css({
                'margin-left': '250px'
            });
            $('#sidebar > ul').show();
            $('#sidebar').css({
                'margin-left': '0'
            });
            $("#container").removeClass("sidebar-closed");
        }
        
    });

    //$(document).ready(function () {
    //    $("#sidebar").niceScroll({
    //        styler: "fb",
    //        cursorcolor: "#4ECDC4",
    //        cursorwidth: '1',
    //        cursorborderradius: '1px',
    //        background: '#404040',
    //        spacebarenabled: false,
    //        cursorborder: ''
    //    });
    //    });
   //custom scrollbar
  
  // $("html").niceScroll({styler:"fb",cursorcolor:"#4ECDC4", cursorwidth: '6', cursorborderradius: '10px', background: '#404040', spacebarenabled:false,  cursorborder: '', zindex: '1000'});

  // widget tools

  jQuery('.panel .tools .fa-chevron-down').click(function() {
    var el = jQuery(this).parents(".panel").children(".panel-body");
    if (jQuery(this).hasClass("fa-chevron-down")) {
      jQuery(this).removeClass("fa-chevron-down").addClass("fa-chevron-up");
      el.slideUp(200);
    } else {
      jQuery(this).removeClass("fa-chevron-up").addClass("fa-chevron-down");
      el.slideDown(200);
    }
  });

  jQuery('.panel .tools .fa-times').click(function() {
    jQuery(this).parents(".panel").parent().remove();
  });


  //    tool tips

  $('.tooltips').tooltip();

  //    popovers

  $('.popovers').popover();



  // custom bar chart

  //if ($(".custom-bar-chart")) {
  //  $(".bar").each(function() {
  //    var i = $(this).find(".value").html();
  //    $(this).find(".value").html("");
  //    $(this).find(".value").animate({
  //      height: i
  //    }, 2000)
  //  })
  //}

}();

//jQuery(document).ready(function( $ ) {

//  // Go to top
//  $('.go-top').on('click', function(e) {
//    e.preventDefault();
//    $('html, body').animate({scrollTop : 0},500);
//    });
   
//});

