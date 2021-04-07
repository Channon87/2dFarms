/* Random JS Code */

/** Scroll Spy - Quick and Dirty @Adam 
	Update URL in address bar with #Ancor 
	Triggered by Boostraps built in scrollspy
	events
**/
$(window).on('activate.bs.scrollspy', function(e) {
    history.replaceState({}, "", $('.nav-item .active').attr("href"));
});

/** Smooth Scrolling **/
/** w3schools example **/
$(document).ready(function(){
  // Add smooth scrolling to all links
  $("a").on('click', function(event) {

    // Make sure this.hash has a value before overriding default behavior
    if (this.hash !== "") {
      // Prevent default anchor click behavior
      event.preventDefault();

      // Store hash
      var hash = this.hash;

      // Using jQuery's animate() method to add smooth page scroll
      // The optional number (800) specifies the number of milliseconds it takes to scroll to the specified area
      $('html, body').animate({
        scrollTop: $(hash).offset().top
      }, 800, function(){

        // Add hash (#) to URL when done scrolling (default click behavior)
        window.location.hash = hash;
      });
    } // End if
  });
});

/* RedButton/GreenButton - Just for fun */
/* Adam Mutimer */
function greenbuttonFunction(link) {
	if (link == 0) {
		// first button push - turn on
		alert("You Again!\r\nI'm Starting To Think You Just Enjoy Pushing RANDOM\ Buttons....\r\n\r\nWait 15 seconds to push button to disable.\r\n");
		document.body.style.backgroundImage = "url('images/bling.gif')";
		document.body.style.cursor = "url('images/smiley.jpg'), auto";
		document.getElementById("green-button").setAttribute("onclick","return greenbuttonFunction(3);");
		
		// Lock button for 15 seconds
		setTimeout(function (){
			document.getElementById("green-button").setAttribute("onclick","return greenbuttonFunction(1);");
		}, 15000);
	
	} else if (link == 3) {
		alert("Time is a monster that cannot be reasoned with.\r\nIt responds like a snail to our impatience,\r\nthen it races like a gazelle when you can't catch a breath.\r\n\r\n - Jim Carrey\r\n");
		
	} else {
		// Second button push - turn off
		document.getElementById("green-button").setAttribute("onclick","return greenbuttonFunction(0);");
		document.body.style.backgroundImage = "";
		document.body.style.cursor = "auto";
	}

	return false;
}

/** JS Complex/Bulk Data Fetcher **/
/** Adam Mutimer **/
function JSFetch (nav,req,dest,graphobj) {
	if (!req || !dest) {
		
	} else {
		// Adam: Added Array of Requests - 13/10/20
		if (Array.isArray(req)) {
			var keys = req.keys(); // Get request/reg Array Keys for Ordering and Process Loop
			var PageContent = new Array(); // Create Empty Array

			for (x of keys) {
				var preq = req[x];
				
				$.ajax({url:'data/' + preq + '.html', async: false, success: 
					function (data){
						if (data.length < 0) {
							data = "Error: No Data Found";
						} else {
							// Create Array Object
							var obj = {data: data, location: 'data/' + preq + '.html '};
							// Enter Array Object Using ORDER key of request/req
							PageContent[x] = obj;
						}
					}
				});
			}
			// Wait until array is fully populated
			$.when(PageContent).done(function(results){
				// Loop Though the Array
				PageContent.forEach(function(data) {
					// Add content to the targets on each run
					document.getElementById(dest).innerHTML += data.data;
					document.getElementById(dest + '-location').innerHTML += data.location;
				});
			});
		} else {
			// Use ajax to fetch the html file and process that data
			$.ajax({url:'data/' + req + '.html', success: 
				function (data){
					if (data.length < 0) {
						data = "Error: No Data Found";
					} else {			
						// Push Data into destination
						var filepath = "<div class=\"row\">\n<div class=\"col\">\n<p class=\"pt-5\"><strong>File Location:</strong><span class=\"font-weight-light font-italic\"> data/" + req + ".html</span></p></div></div>";
						document.getElementById(dest).innerHTML = data + filepath;

						// Patch for JsCharts
						if (graphobj) {
							// Adam - Added Array Iteration 
							// Channon needed multiple graphs
							graphobj.forEach(JSFetchGraph);
						}
					}
				}
			});
			if (nav !== null) {
				// Update Sub Nav Tab
				var navitem = req.substring(req.indexOf("/") + 1); // Drop data in string before "/" 
				// Search for current Nav Menu + Active class and remove active class
				document.getElementsByClassName(nav + " nav-link active")[0].classList.remove("active");
				// use stipped navitem to set current selected menu item as active
				document.getElementById(navitem).classList.add("active");
			}			
		}
	}
	return false;
}

/* Scroll to Top - Floating Button */
$(document).ready(function(){
	$(window).scroll(function () {
			if ($(this).scrollTop() > 50) {
				$('#back-to-top').fadeIn();
			} else {
				$('#back-to-top').fadeOut();
			}
		});
		// scroll body to 0px on click
		$('#back-to-top').click(function () {
			$('body,html').animate({
				scrollTop: 0
			}, 800);
			return false;
		});
});	