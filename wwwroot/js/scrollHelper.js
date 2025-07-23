window.scrollToSection = function (id) {
    setTimeout(function () {
        var el = document.getElementById(id);
        var navbar = document.querySelector('.navbar.sticky-top');
        var navbarHeight = navbar ? navbar.offsetHeight : 0;
        if (el) {
            var top = el.getBoundingClientRect().top + window.scrollY - navbarHeight;
            window.scrollTo({ top: top, behavior: "smooth" });
        }
    }, 20);
};
