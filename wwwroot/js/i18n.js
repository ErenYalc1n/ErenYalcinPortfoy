window.getLang = function () {
    return localStorage.getItem("lang") || "tr";
};

window.setLang = function (lang) {
    localStorage.setItem("lang", lang);
};

window.setMeta = (title, description, url = window.location.href) => {
    document.title = title;

    const setOrUpdate = (name, attr, value) => {
        let element = document.querySelector(`${name}`);
        if (!element) {
            element = document.createElement("meta");
            document.head.appendChild(element);
        }
        element.setAttribute(attr, value);
    };

    setOrUpdate("meta[name='description']", "content", description);
    setOrUpdate("meta[property='og:title']", "content", title);
    setOrUpdate("meta[property='og:description']", "content", description);
    setOrUpdate("meta[property='og:url']", "content", url);
};


