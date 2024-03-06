/* Set the width of the side navigation to 250px and the left margin of the page content to 250px */
var state = false;
function openNav() {
    var ViewItem = document.getElementById("mySidenav"); 
    var IconItem = document.getElementById("MenuIcon"); 
    if (state) {
        ViewItem.style.width = "0";
        state = false;
    }
    else {
        ViewItem.style.width = "250px"; 
        state = true;
    }
    IconItem.classList.toggle("change");
    //document.getElementById("main").style.marginLeft = "250px";
}