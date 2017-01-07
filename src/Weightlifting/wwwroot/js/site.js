$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();

  
    $(".nav").find(".active").removeClass("active");
    var active = window.location.pathname;

    var a = $(".nav a[href|='" + active + "']");
    if (active === '/Workout') {
        a = $(".nav a[href|='/Home']");
    }

    a.parent().addClass("active");
  
});