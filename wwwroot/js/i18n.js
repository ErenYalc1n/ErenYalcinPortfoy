window.getLang = function () {
    return localStorage.getItem("lang") || "tr";
};

window.setLang = function (lang) {
    localStorage.setItem("lang", lang);
};
