document.addEventListener("DOMContentLoaded", function () {
    // Function to check if the viewport width is for mobile
    function isMobile() {
        return window.innerWidth <= 1023; // Mobile screen size threshold (adjust as needed)
    }

    // Array of classes to exclude from dropdown behavior
    // منوهایی که قرار است روی آن از تگ
    // <NavLink>
    // استفاده شود باید کلاسش در این آرایه زیر قرار بگیرد که دو خط زیر باعث اختلال نشود
    // event.preventDefault();
    // event.stopPropagation();
    // دهنم بابت نوشتن این کدها سرویس شد!
    const exclusionClasses = ['exclude-dropdown'];

    // Flag to track mobile mode
    let isMobileMode = isMobile(); // Initial check for mobile mode based on current screen size

    // Initialize dropdown behavior based on current screen size
    function initializeDropdownBehavior() {
        if (isMobile()) {
            document.querySelectorAll(".nav2-navbar > li > a").forEach(function (parentLink) {
                if (!hasExclusionClass(parentLink)) {
                    parentLink.addEventListener("click", handleClick);
                }
            });

            document.addEventListener("click", handleOutsideClick);
            document.querySelectorAll(".nav2-dropdown-menu").forEach(function (dropdown) {
                dropdown.addEventListener("mouseleave", handleMouseLeave);
            });
        }
    }

    // Remove event listeners when not in mobile mode
    function cleanupDropdownBehavior() {
        document.querySelectorAll(".nav2-navbar > li > a").forEach(function (parentLink) {
            if (!hasExclusionClass(parentLink)) {
                parentLink.removeEventListener("click", handleClick);
            }
        });

        document.removeEventListener("click", handleOutsideClick);

        document.querySelectorAll(".nav2-dropdown-menu").forEach(function (dropdown) {
            dropdown.removeEventListener("mouseleave", handleMouseLeave);
        });
    }

    function handleClick(event) {
        event.preventDefault();
        event.stopPropagation();

        let dropdown = this.nextElementSibling;

        document.querySelectorAll(".nav2-dropdown-menu").forEach(function (menu) {
            if (menu !== dropdown) {
                menu.classList.remove("active");
            }
        });

        if (dropdown && dropdown.classList.contains("nav2-dropdown-menu")) {
            dropdown.classList.toggle("active");
        }
    }

    function handleOutsideClick() {
        document.querySelectorAll(".nav2-dropdown-menu").forEach(function (menu) {
            menu.classList.remove("active");
        });
    }

    function handleMouseLeave() {
        this.classList.remove("active");
    }

    function hasExclusionClass(element) {
        return exclusionClasses.some(function (exclusionClass) {
            return element.classList.contains(exclusionClass);
        });
    }

    // Initial setup based on current screen size
    initializeDropdownBehavior();

    // Watch for window resize events to adjust behavior
    window.addEventListener('resize', function () {
        if (isMobile() !== isMobileMode) {
            isMobileMode = !isMobileMode;  // Toggle the mode

            if (isMobileMode) {
                // Mobile mode: add event listeners
                initializeDropdownBehavior();
            } else {
                // Desktop mode: cleanup event listeners
                cleanupDropdownBehavior();
            }
        }
    });
});
