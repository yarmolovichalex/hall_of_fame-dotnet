var main = function() {
    "use strict";

    $(".album").fadeIn().css("display", "inline-block");

    $(".menu").css('opacity', 0.3);
    $(".album").hover(
        function() {
            $(this).find('.menu').stop().fadeTo('fast', 1);
        },
        function() {
            $(this).find('.menu').stop().fadeTo('fast', 0.3);
        });

    setFancyBox();
};

var setFancyBox = function()
{
	$(".fancyBox").fancybox({
		arrows: false,
		padding: 0,
		  keys: {
		  	next: null,
		  	prev: null
		  },
		  scrolling: "no",
	      openEffect: "elastic",
	      closeEffect: "elastic",
	      helpers: {
	          overlay: {
	              locked: false
	          }
	      }
	});    
};

var OnSuccessRemoveAlbum = function (data) {
    var album = $('*[data-id=' + data.id + ']');
    album.fadeOut();
};

$(document).ready(main);