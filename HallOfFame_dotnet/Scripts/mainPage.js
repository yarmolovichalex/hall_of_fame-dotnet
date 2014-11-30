var main = function() {
    "use strict";

    $(".album").fadeIn().css("display", "inline-block");

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

$(document).ready(main);