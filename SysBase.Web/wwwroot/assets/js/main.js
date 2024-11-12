
import './flowbite.min.js';


export function checkTheme() {
    var themeToggleBtns = document.querySelectorAll('.theme-toggle-btn');
    var currentTheme = localStorage.getItem('color-theme');
    var isDarkMode = currentTheme === 'dark' || (!currentTheme && window.matchMedia('(prefers-color-scheme: dark)').matches);


    themeToggleBtns.forEach(btn => {
        var darkIcon = btn.querySelector('.theme-toggle-dark-icon');
        var lightIcon = btn.querySelector('.theme-toggle-light-icon');

        if (isDarkMode) {
            lightIcon.classList.remove('hidden');
        } else {
            darkIcon.classList.remove('hidden');
        }
    });


    function toggleTheme() {
        themeToggleBtns.forEach(btn => {
            var darkIcon = btn.querySelector('.theme-toggle-dark-icon');
            var lightIcon = btn.querySelector('.theme-toggle-light-icon');

            darkIcon.classList.toggle('hidden');
            lightIcon.classList.toggle('hidden');
        });

        if (localStorage.getItem('color-theme')) {
            if (localStorage.getItem('color-theme') === 'light') {
                document.documentElement.classList.add('dark');
                localStorage.setItem('color-theme', 'dark');
            } else {
                document.documentElement.classList.remove('dark');
                localStorage.setItem('color-theme', 'light');
            }
        } else {
            if (document.documentElement.classList.contains('dark')) {
                document.documentElement.classList.remove('dark');
                localStorage.setItem('color-theme', 'light');
            } else {
                document.documentElement.classList.add('dark');
                localStorage.setItem('color-theme', 'dark');
            }
        }
    }


    themeToggleBtns.forEach(btn => {
        btn.addEventListener('click', toggleTheme);
    });
}


export function heroSlider() {
    const contentBox = document.querySelectorAll('.hero-slider-item-content-box')
    const swiper = new Swiper('.hero-slider', {

        direction: 'horizontal',
        loop: true,
        autoplay: {
            delay: 6000,
            pauseOnMouseEnter: true,
        },
        cssMode: true,



        pagination: {
            el: '.swiper-pagination',
            clickable: true,
        },

        navigation: {
            nextEl: '.hero-slider-next',
            prevEl: '.hero-slider-prev',
            disabledClass: '!cursor-not-allowed !opacity-50',
        }
    });

    swiper.on('activeIndexChange', function () {
        contentBox.forEach((box) => {
            const subTitle = box.querySelector('div.hero-slider-item-subtitle');
            const title = box.querySelector('div.hero-slider-item-title');
            const btn = box.querySelector('.btn');

            if (subTitle) subTitle.classList.remove('fadeInUp', 'hero-subtitle-delay');
            if (title) title.classList.remove('fadeInUp', 'hero-subtitle-delay');
            if (btn) btn.classList.remove('fadeInUp', 'hero-subtitle-delay');
        });

        const activeBox = contentBox[swiper.activeIndex];
        if (activeBox) {
            const activeSubTitle = activeBox.querySelector('div.hero-slider-item-subtitle');
            const activeTitle = activeBox.querySelector('div.hero-slider-item-title');
            const activeBtn = activeBox.querySelector('.btn');

            if (activeSubTitle) activeSubTitle.classList.add('fadeInUp', 'hero-subtitle-delay');
            if (activeTitle) activeTitle.classList.add('fadeInUp', 'hero-title-delay');
            if (activeBtn) activeBtn.classList.add('fadeInUp', 'hero-btn-delay');
        }
    });

}

export function newsSlider() {

    const sliderWrapper = document.querySelector('.news-slider-wrapper');
    const slides = document.querySelectorAll('.news-slider-slide');
    const slideHeight = slides[0].offsetHeight;
    let currentIndex = 0;
    let sliderInterval;

    const firstSlideClone = slides[0].cloneNode(true);
    sliderWrapper.appendChild(firstSlideClone);

    function startSlider() {
        sliderInterval = setInterval(() => {
            currentIndex++;
            sliderWrapper.style.transition = 'transform 0.5s ease-in-out';
            sliderWrapper.style.transform = `translateY(-${slideHeight * currentIndex}px)`;

            if (currentIndex >= slides.length) {
                setTimeout(() => {
                    sliderWrapper.style.transition = 'none';
                    sliderWrapper.style.transform = 'translateY(0)';
                    currentIndex = 0;
                }, 500);
            }
        }, 3000);
    }

    function stopSlider() {
        clearInterval(sliderInterval);
    }

    startSlider();

    sliderWrapper.addEventListener('mouseover', stopSlider);
    sliderWrapper.addEventListener('mouseout', startSlider);

}

export function videoSlider() {
    const swiper = new Swiper('.video-slider', {

        direction: 'horizontal',
        loop: false,
        autoplay: {
            delay: 7000,
            pauseOnMouseEnter: true,
        },
        cssMode: true,
        slidePerView: 3,
        spaceBetween: 20,


        navigation: {
            nextEl: '.video-slider-next',
            prevEl: '.video-slider-prev',
            disabledClass: '!cursor-not-allowed !opacity-50',
        },
        breakpoints: {
            0: {
                slidesPerView: 1.5,
            },
            640: {
                slidesPerView: 3,
            },
            1024: {
                slidesPerView: 3,
            }
        }
    });

}

export function stickyHeader() {
    const header = document.querySelector('.header');
    const scrollUp = "scroll-up";
    const scrollDown = "scroll-down";
    let lastScroll = 0;
    const body = document.body;
    const detailHeaderLogo = document.querySelector('.detail-header-logo');
    const basketIcon = document.querySelector('.basketIcon');
    const basketIconValue = document.querySelector('.basketIconValue');

    window.addEventListener("scroll", () => {
        const currentScroll = window.pageYOffset;

        if (currentScroll <= 100) {
            body.classList.remove(scrollUp);
            if (header) {
                header.classList.remove('animated-background', 'bg-gradient-to-r', 'from-primary-red', 'via-red-800', 'to-red-900');
            }
            if (detailHeaderLogo) {
                detailHeaderLogo.src = 'assets/images/logo-red@2x.png';
            }
            if (basketIcon) {
                basketIcon.classList.remove('text-white');
            }
            if (basketIconValue) {
                basketIconValue.classList.remove('bg-white', '!text-primary-red');
            }
            return;
        }

        if (currentScroll > lastScroll && !body.classList.contains(scrollDown)) {
            // down
            body.classList.remove(scrollUp);
            body.classList.add(scrollDown);
            if (header) {
                header.classList.add('animated-background', 'bg-gradient-to-r', 'from-primary-red', 'via-red-800', 'to-red-900');
            }
            if (detailHeaderLogo) {
                detailHeaderLogo.src = 'assets/images/logo@2x.png';
            }
            if (basketIcon) {
                basketIcon.classList.add('text-white');
            }
            if (basketIconValue) {
                basketIconValue.classList.add('bg-white', '!text-primary-red');
            }
        } else if (
            currentScroll < lastScroll &&
            body.classList.contains(scrollDown)
        ) {
            // up
            body.classList.remove(scrollDown);
            body.classList.add(scrollUp);
        }
        lastScroll = currentScroll;
    });


}

export function showMore() {
    const showMoreBtn = document.querySelectorAll('.show-more-btn');
    const contentText = document.querySelectorAll('.content-text');

    showMoreBtn.forEach((btn, index) => {
        btn.addEventListener('click', function () {
            contentText[index].classList.toggle('line-clamp-2');
            btn.querySelector('span.icon').classList.toggle('-rotate-90')
        });
    });
}


export function customTab() {
    document.querySelectorAll('.tab-container').forEach(container => {
        const tabButtons = container.querySelectorAll('.tab-button');
        const tabPanes = container.querySelectorAll('.tab-pane');

        tabButtons.forEach(button => {
            button.addEventListener('click', function () {
                const targetTab = this.getAttribute('data-tab');


                tabButtons.forEach(btn => btn.classList.remove('active'));
                tabPanes.forEach(pane => pane.classList.remove('active'));


                this.classList.add('active');
                document.getElementById(targetTab).classList.add('active');
                AOS.refresh(console.log('active'));
            });
        });

    });

    showMore();
}


export function brandSlider() {
    const swiper = new Swiper('.brand-slider', {
        slidesPerView: 5,
        spaceBetween: 30,
        slidesPerGroup: 1,
        loop: true,
        autoplay: {
            delay: 5000,
            pauseOnMouseEnter: true,
        },
        cssMode: true,
        breakpoints: {
            0: {
                slidesPerView: 2,
            },
            640: {
                slidesPerView: 3,
            },
            1024: {
                slidesPerView: 4,
            }
        },
        navigation: {
            nextEl: '.brand-slider-next',
            prevEl: '.brand-slider-prev',
            disabledClass: '!cursor-not-allowed !opacity-50',
        }
    });

}

export function mobileSubMenu() {
    const menuItems = document.querySelectorAll("#mobileMenuDrawer .mobile-menu .menu-item");

    menuItems.forEach((item) => {
        const subMenuButton = item.querySelector(".sub-menu-button");

        if (subMenuButton) {
            subMenuButton.addEventListener("click", function (e) {
                e.preventDefault();


                menuItems.forEach((menuItem) => {
                    if (menuItem !== item) {
                        menuItem.classList.remove("open");
                        const subMenu = menuItem.querySelector('.sub-menu');
                        if (subMenu) {
                            subMenu.style.maxHeight = null;
                            subMenu.style.opacity = 0;
                        }
                    }
                });


                item.classList.toggle("open");

                const subMenu = item.querySelector('.sub-menu');
                if (subMenu) {
                    if (item.classList.contains("open")) {
                        subMenu.style.maxHeight = subMenu.scrollHeight + "px";
                        subMenu.style.opacity = 1;
                    } else {
                        subMenu.style.maxHeight = null;
                        subMenu.style.opacity = 0;
                    }
                }
            });
        }
    });

}

export function drawerControl() {

    const $targetEl = document.getElementById('mobileMenuDrawer');


    const options = {
        placement: 'left',
        backdrop: true,
        bodyScrolling: false,
        backdropClasses:
            'bg-gray-900/50 dark:bg-gray-900/80 fixed inset-0 z-40',
        onHide: () => {
            const menuItems = document.querySelectorAll("#mobileMenuDrawer .mobile-menu .menu-item");
            menuItems.forEach((menuItem) => {
                menuItem.classList.remove("open");
                const subMenu = menuItem.querySelector('.sub-menu');
                if (subMenu) {
                    subMenu.style.maxHeight = null;
                    subMenu.style.opacity = 0;
                }
            });
        },
        onShow: () => {
        },
        onToggle: () => {
        },
    };

    const instanceOptions = {
        id: 'mobileMenuDrawer',
        override: true
    };
    const drawer = new Drawer($targetEl, options, instanceOptions);

    const mobileMenuBtn = document.getElementById('showMobileMenuDrawer');

    mobileMenuBtn.addEventListener('click', () => {
        drawer.show();
    });
}




