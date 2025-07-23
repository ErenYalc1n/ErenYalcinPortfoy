window.redirectToMatchingSlug = (currentLang, targetLang, currentSlug) => {
    Promise.all([
        fetch(`/data/blog.${currentLang}.json`).then(res => res.json()),
        fetch(`/data/blog.${targetLang}.json`).then(res => res.json())
    ]).then(([currentData, targetData]) => {
        const currentItem = currentData.find(b => b.slug === currentSlug);
        if (!currentItem) return;

        const matchInTarget = targetData.find(b => b.id === currentItem.id);
        if (!matchInTarget) return;
        window.location.href = `/blog/${matchInTarget.slug}`;
    });
};
