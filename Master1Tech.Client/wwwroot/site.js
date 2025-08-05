function saveAsFile(filename, bytesBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + bytesBase64;
    document.body.appendChild(link); // Needed for Firefox
    link.click();
    document.body.removeChild(link);
}

window.scrollToElement = (elementId) => {
    const el = document.getElementById(elementId);
    if (el) {
        // Get the height of the sticky header (adjust selector if needed)
        const header = document.querySelector('.nav-tabs');
        const offset = header ? header.offsetHeight : 0;

        // Get the element's position relative to the document
        const elementPosition = el.getBoundingClientRect().top + window.pageYOffset;

        // Scroll to the element minus the header offset
        window.scrollTo({
            top: elementPosition - offset - 16, // 16px extra spacing for comfort
            behavior: 'smooth'
        });
    }
};

window.initializeScrollSpy = () => {
    const sections = document.querySelectorAll('[data-section]');
    const navTabs = document.querySelectorAll('.nav-tab');

    function onScroll() {
        let currentSection = sections[0];
        let scrollPosition = window.scrollY + 620; // adjust offset for sticky nav

        for (let section of sections) {
            if (section.offsetTop <= scrollPosition) {
                currentSection = section;
            }
        }

        navTabs.forEach(tab => {
            tab.classList.remove('active');
            if (tab.getAttribute('data-target') === currentSection.id) {
                tab.classList.add('active');
            }
        });
    }

    window.addEventListener('scroll', onScroll, { passive: true });

    // Initial call to set the correct tab on load
    onScroll();
};

function updateActiveTabOnScroll() {
    const sections = document.querySelectorAll('.section[data-section]');
    const navTabs = document.querySelectorAll('.nav-tab[data-target]');
    const navHeight = document.querySelector('.nav-tabs').offsetHeight;
    const scrollPosition = window.scrollY + navHeight + 100;

    for (let i = sections.length - 1; i >= 0; i--) {
        const section = sections[i];
        if (section.offsetTop <= scrollPosition) {
            const sectionId = section.getAttribute('data-section');

            navTabs.forEach(tab => {
                tab.classList.remove('active');
                if (tab.getAttribute('data-target') === sectionId) {
                    tab.classList.add('active');
                }
            });

            break;
        }
    }
}

// Handle browser back/forward navigation
window.addEventListener('hashchange', function (e) {
    const hash = window.location.hash.substring(1);
    if (hash) {
        window.scrollToElement(hash);
    }
});


window.observeSections = function (dotnetHelper) {
    const sections = document.querySelectorAll("[data-section]");

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                const id = entry.target.getAttribute("data-section");
                dotnetHelper.invokeMethodAsync("UpdateSection", id);
            }
        });
    }, {
        rootMargin: "0px 0px -60% 0px",
        threshold: 0.2
    });

    sections.forEach(sec => observer.observe(sec));
};