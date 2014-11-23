var main = function() {
	"use strict";

	var albums = [
	    {
	        "Band": "Metallica",
	        "Name": "Master Of Puppets",
	        "Year": 1986,
	        "Image": "http://userserve-ak.last.fm/serve/500/61682269/Master+of+Puppets+cover_masterofpuppets_lg.jpg"
	    },
	    {
	        "Band": "Slayer",
	        "Name": "Reign In Blood",
	        "Year": 1986,
	        "Image": "http://userserve-ak.last.fm/serve/500/46065199/Reign+in+Blood.png"
	    },
	    {
	    	"Band" : "Totalselfhatred",
	    	"Name" : "Totalselfhatred",
	    	"Year" : 2008,
	    	"Image" : "http://userserve-ak.last.fm/serve/500/22875641/Totalselfhatred+80a386ab638d330b9251c2589b694a.jpg"
	    },
	    {
	    	"Band" : "Radiohead",
	    	"Name" : "In Rainbows",
	    	"Year" : 2007,
	    	"Image" : "http://userserve-ak.last.fm/serve/500/47882499/In+Rainbows.png"
	    },
	    {
	    	"Band" : "Jon Hopkins",
	    	"Name" : "Insides",
	    	"Year" : 2008,
	    	"Image" : "http://userserve-ak.last.fm/serve/_/87289153/Insides+DS015D2.png"
	    },
	    {
	    	"Band" : "Rob Dougan",
	    	"Name" : "Furious Angels",
	    	"Year" : 2001,
	    	"Image" : "http://userserve-ak.last.fm/serve/500/45719219/Furious+Angels.png"
	    }
	];

	albums.forEach(addAlbumOnPage);

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

var addAlbumOnPage = function(item)
	{
		var $album = $("<div>").addClass("album").hide();
		$("<p>").text("Band: " + item.Band).appendTo($album);
		$("<p>").text("Album name: " + item.Name).appendTo($album);
		$("<p>").text("Year: " + item.Year).appendTo($album);

		var $imageLink = $("<a>").addClass("fancyBox").attr("rel", "group").attr("href", item.Image).appendTo($album); 
		$("<img>").attr("src", item.Image).appendTo($imageLink);

		$("<button>").text("Подробнее").addClass("showDetails")
			.css("display", "block").css("margin", "auto")
			.appendTo($album);

		$(".main").append($album);
		$album.fadeIn();
	};

$(document).ready(main);