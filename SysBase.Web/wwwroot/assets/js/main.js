import './flowbite.min.js'

export function checkTheme() {
    var themeToggleBtns = document.querySelectorAll('.theme-toggle-btn')
    var currentTheme = localStorage.getItem('color-theme')
    var isDarkMode =
        currentTheme === 'dark' ||
        (!currentTheme &&
            window.matchMedia('(prefers-color-scheme: dark)').matches)

    themeToggleBtns.forEach((btn) => {
        var darkIcon = btn.querySelector('.theme-toggle-dark-icon')
        var lightIcon = btn.querySelector('.theme-toggle-light-icon')

        if (isDarkMode) {
            lightIcon.classList.remove('hidden')
        } else {
            darkIcon.classList.remove('hidden')
        }
    })

    function toggleTheme() {
        themeToggleBtns.forEach((btn) => {
            var darkIcon = btn.querySelector('.theme-toggle-dark-icon')
            var lightIcon = btn.querySelector('.theme-toggle-light-icon')

            darkIcon.classList.toggle('hidden')
            lightIcon.classList.toggle('hidden')
        })

        if (localStorage.getItem('color-theme')) {
            if (localStorage.getItem('color-theme') === 'light') {
                document.documentElement.classList.add('dark')
                localStorage.setItem('color-theme', 'dark')
            } else {
                document.documentElement.classList.remove('dark')
                localStorage.setItem('color-theme', 'light')
            }
        } else {
            if (document.documentElement.classList.contains('dark')) {
                document.documentElement.classList.remove('dark')
                localStorage.setItem('color-theme', 'light')
            } else {
                document.documentElement.classList.add('dark')
                localStorage.setItem('color-theme', 'dark')
            }
        }
    }

    themeToggleBtns.forEach((btn) => {
        btn.addEventListener('click', toggleTheme)
    })
}

export function heroSlider() {
    const contentBox = document.querySelectorAll(
        '.hero-slider-item-content-box'
    )
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
        },
    })

    swiper.on('activeIndexChange', function () {
        contentBox.forEach((box) => {
            const subTitle = box.querySelector('div.hero-slider-item-subtitle')
            const title = box.querySelector('div.hero-slider-item-title')
            const btn = box.querySelector('.btn')

            if (subTitle)
                subTitle.classList.remove('fadeInUp', 'hero-subtitle-delay')
            if (title) title.classList.remove('fadeInUp', 'hero-subtitle-delay')
            if (btn) btn.classList.remove('fadeInUp', 'hero-subtitle-delay')
        })

        const activeBox = contentBox[swiper.activeIndex]
        if (activeBox) {
            const activeSubTitle = activeBox.querySelector(
                'div.hero-slider-item-subtitle'
            )
            const activeTitle = activeBox.querySelector(
                'div.hero-slider-item-title'
            )
            const activeBtn = activeBox.querySelector('.btn')

            if (activeSubTitle)
                activeSubTitle.classList.add('fadeInUp', 'hero-subtitle-delay')
            if (activeTitle)
                activeTitle.classList.add('fadeInUp', 'hero-title-delay')
            if (activeBtn) activeBtn.classList.add('fadeInUp', 'hero-btn-delay')
        }
    })
}

export function newsSlider() {
    const sliderWrapper = document.querySelector('.news-slider-wrapper')
    const slides = document.querySelectorAll('.news-slider-slide')
    const slideHeight = slides[0].offsetHeight
    let currentIndex = 0
    let sliderInterval

    const firstSlideClone = slides[0].cloneNode(true)
    sliderWrapper.appendChild(firstSlideClone)

    function startSlider() {
        sliderInterval = setInterval(() => {
            currentIndex++
            sliderWrapper.style.transition = 'transform 0.5s ease-in-out'
            sliderWrapper.style.transform = `translateY(-${slideHeight * currentIndex}px)`

            if (currentIndex >= slides.length) {
                setTimeout(() => {
                    sliderWrapper.style.transition = 'none'
                    sliderWrapper.style.transform = 'translateY(0)'
                    currentIndex = 0
                }, 500)
            }
        }, 3000)
    }

    function stopSlider() {
        clearInterval(sliderInterval)
    }

    startSlider()

    sliderWrapper.addEventListener('mouseover', stopSlider)
    sliderWrapper.addEventListener('mouseout', startSlider)
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
            },
        },
    })
}

export function stickyHeader() {
    const header = document.querySelector('.header')
    const scrollUp = 'scroll-up'
    const scrollDown = 'scroll-down'
    let lastScroll = 0
    const body = document.body
    const detailHeaderLogo = document.querySelector('.detail-header-logo')
    const basketIcon = document.querySelector('.basketIcon')
    const basketIconValue = document.querySelector('.basketIconValue')

    window.addEventListener('scroll', () => {
        const currentScroll = window.pageYOffset

        if (currentScroll <= 100) {
            body.classList.remove(scrollUp)
            if (header) {
                header.classList.remove(
                    'animated-background',
                    'bg-gradient-to-r',
                    'from-primary-red',
                    'via-red-800',
                    'to-red-900'
                )
            }
            if (detailHeaderLogo) {
                detailHeaderLogo.src = '/assets/images/logo-red@2x.png'
            }
            if (basketIcon) {
                basketIcon.classList.remove('text-white')
            }
            if (basketIconValue) {
                basketIconValue.classList.remove(
                    'bg-white',
                    '!text-primary-red'
                )
            }
            return
        }

        if (
            currentScroll > lastScroll &&
            !body.classList.contains(scrollDown)
        ) {
            // down
            body.classList.remove(scrollUp)
            body.classList.add(scrollDown)
            if (header) {
                header.classList.add(
                    'animated-background',
                    'bg-gradient-to-r',
                    'from-primary-red',
                    'via-red-800',
                    'to-red-900'
                )
            }
            if (detailHeaderLogo) {
                detailHeaderLogo.src = '/assets/images/logo@2x.png'
            }
            if (basketIcon) {
                basketIcon.classList.add('text-white')
            }
            if (basketIconValue) {
                basketIconValue.classList.add('bg-white', '!text-primary-red')
            }
        } else if (
            currentScroll < lastScroll &&
            body.classList.contains(scrollDown)
        ) {
            // up
            body.classList.remove(scrollDown)
            body.classList.add(scrollUp)
        }
        lastScroll = currentScroll
    })
}

export function showMore() {
    const showMoreBtn = document.querySelectorAll('.show-more-btn')
    const contentText = document.querySelectorAll('.content-text')

    showMoreBtn.forEach((btn, index) => {
        btn.addEventListener('click', function () {
            contentText[index].classList.toggle('line-clamp-2')
            btn.querySelector('span.icon').classList.toggle('-rotate-90')
        })
    })
}

export function customTab() {
    document.querySelectorAll('.tab-container').forEach((container) => {
        const tabButtons = container.querySelectorAll('.tab-button')
        const tabPanes = container.querySelectorAll('.tab-pane')

        tabButtons.forEach((button) => {
            button.addEventListener('click', function () {
                const targetTab = this.getAttribute('data-tab')

                tabButtons.forEach((btn) => btn.classList.remove('active'))
                tabPanes.forEach((pane) => pane.classList.remove('active'))

                this.classList.add('active')
                document.getElementById(targetTab).classList.add('active')
                AOS.refresh(console.log('active'))
            })
        })
    })

    showMore()
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
            },
        },
        navigation: {
            nextEl: '.brand-slider-next',
            prevEl: '.brand-slider-prev',
            disabledClass: '!cursor-not-allowed !opacity-50',
        },
    })
}

export function mobileSubMenu() {
    const menuItems = document.querySelectorAll(
        '#mobileMenuDrawer .mobile-menu .menu-item'
    )

    menuItems.forEach((item) => {
        const subMenuButton = item.querySelector('.sub-menu-button')

        if (subMenuButton) {
            subMenuButton.addEventListener('click', function (e) {
                e.preventDefault()

                menuItems.forEach((menuItem) => {
                    if (menuItem !== item) {
                        menuItem.classList.remove('open')
                        const subMenu = menuItem.querySelector('.sub-menu')
                        if (subMenu) {
                            subMenu.style.maxHeight = null
                            subMenu.style.opacity = 0
                        }
                    }
                })

                item.classList.toggle('open')

                const subMenu = item.querySelector('.sub-menu')
                if (subMenu) {
                    if (item.classList.contains('open')) {
                        subMenu.style.maxHeight = subMenu.scrollHeight + 'px'
                        subMenu.style.opacity = 1
                    } else {
                        subMenu.style.maxHeight = null
                        subMenu.style.opacity = 0
                    }
                }
            })
        }
    })
}

export function drawerControl() {
    const $targetEl = document.getElementById('mobileMenuDrawer')

    const options = {
        placement: 'left',
        backdrop: true,
        bodyScrolling: false,
        backdropClasses:
            'bg-gray-900/50 dark:bg-gray-900/80 fixed inset-0 z-40',
        onHide: () => {
            const menuItems = document.querySelectorAll(
                '#mobileMenuDrawer .mobile-menu .menu-item'
            )
            menuItems.forEach((menuItem) => {
                menuItem.classList.remove('open')
                const subMenu = menuItem.querySelector('.sub-menu')
                if (subMenu) {
                    subMenu.style.maxHeight = null
                    subMenu.style.opacity = 0
                }
            })
        },
        onShow: () => { },
        onToggle: () => { },
    }

    const instanceOptions = {
        id: 'mobileMenuDrawer',
        override: true,
    }
    const drawer = new Drawer($targetEl, options, instanceOptions)

    const mobileMenuBtn = document.getElementById('showMobileMenuDrawer')

    mobileMenuBtn.addEventListener('click', () => {
        drawer.show()
    })
}

export function productItemSelect() {
    const productItems = document.querySelectorAll('.product-item')
    const goToMusteriBilgileri = document.getElementById('goToMusteriBilgileri')

    productItems.forEach((item) => {
        item.addEventListener('click', function (event) {
            productItems.forEach((el) =>
                el.classList.remove('product-item-selected')
            )

            item.classList.add('product-item-selected')

            if (goToMusteriBilgileri) {
                goToMusteriBilgileri.disabled = false
            }

            const radioInput = item.querySelector('input[type="radio"]');
            if (radioInput) {
                radioInput.checked = true;
                SepetList(radioInput.value)
            }
            /*
            const selectedRadio = document.querySelector('input[type="radio"]:checked');
            if (selectedRadio) {
                const selectedValue = selectedRadio.value;
                console.log('Seçili değer:', selectedValue);
            }
            */

            event.stopPropagation()
        })
    })

    document.addEventListener('click', () => {
        productItems.forEach((el) =>
            el.classList.remove('product-item-selected')
        )
        if (goToMusteriBilgileri) {
            goToMusteriBilgileri.disabled = true
        }
    })
}

export function formTabControl() {
    const goToMusteriBilgileri = document.getElementById('goToMusteriBilgileri')
    const goToDogrulamaEkrani = document.getElementById('goToDogrulamaEkrani')
    const goToOdemeBilgileri = document.getElementById('goToOdemeBilgileri')

    const odemeBilgileri = document.getElementById('odeme-bilgileri')

    if (goToMusteriBilgileri) {
        goToMusteriBilgileri.addEventListener('click', () => {
            const urunSecimi = document.getElementById('urun-secimi')
            const urunSecimiTab = document.getElementById('urun-secimi-tab')
            const musteriBilgileri =
                document.getElementById('musteri-bilgileri')
            const musteriBilgileriTab = document.getElementById(
                'musteri-bilgileri-tab'
            )

            musteriBilgileri.classList.add('active')
            musteriBilgileriTab.classList.add('active')
            urunSecimi.classList.remove('active')
            urunSecimiTab.classList.remove('active')
            urunSecimiTab.classList.add(
                'cursor-not-allowed',
                'pointer-events-none'
            )
        })
    }

    if (goToDogrulamaEkrani) {
        goToDogrulamaEkrani.addEventListener('click', () => {
            TcDogrulama();
        })
    }

    if (goToOdemeBilgileri) {
        goToOdemeBilgileri.addEventListener('click', () => {
            const dogrulamaEkrani = document.getElementById('dogrulama-ekrani')
            const dogrulamaEkraniTab = document.getElementById(
                'dogrulama-ekrani-tab'
            )
            const odemeBilgileri = document.getElementById('odeme-bilgileri')
            const odemeBilgileriTab = document.getElementById(
                'odeme-bilgileri-tab'
            )

            odemeBilgileri.classList.add('active')
            odemeBilgileriTab.classList.add('active')
            dogrulamaEkrani.classList.remove('active')
            dogrulamaEkraniTab.classList.remove('active')
            dogrulamaEkraniTab.classList.add(
                'cursor-not-allowed',
                'pointer-events-none'
            )
        })
    }


    const eDevletLogo = document.getElementById('edevlet-logo')
    const vipLogo = document.getElementById('vip-logo')

    if (eDevletLogo && vipLogo) {
        eDevletLogo.addEventListener('click', () => {
            const eDevletRadioButton = document.getElementById('edevlet')
            const vipRadioButton = document.getElementById('vip')

            eDevletRadioButton.checked = true
            vipRadioButton.checked = false
        })

        vipLogo.addEventListener('click', () => {
            const eDevletRadioButton = document.getElementById('edevlet')
            const vipRadioButton = document.getElementById('vip')

            vipRadioButton.checked = true
            eDevletRadioButton.checked = false
        })
    }

    const bireyselTabBtn = document.getElementById('bireysel-btn')
    const kurumsalTabBtn = document.getElementById('kurumsal-btn')
    const krediKartTabBtn = document.getElementById('kredi-kart-btn')
    const havaleTabBtn = document.getElementById('havale-btn')

    const bireyselTabContent = document.getElementById('bireysel-tab-content')
    const kurumsalTabContent = document.getElementById('kurumsal-tab-content')

    const krediKartTabContent = document.getElementById(
        'kredi-kart-tab-content'
    )
    const havaleTabContent = document.getElementById('havale-tab-content')

    bireyselTabBtn.addEventListener('click', () => {
        bireyselTabBtn.classList.add('active')
        kurumsalTabBtn.classList.remove('active')
        bireyselTabContent.classList.remove('hidden')
        kurumsalTabContent.classList.add('hidden')

        kurumsalTabErrorMsgs.forEach((msg) => {
            msg.classList.add('hidden')
            kurumsalTabInputs.forEach((input) => {
                input.classList.remove('!border-red-500')
            })
        })
    })

    kurumsalTabBtn.addEventListener('click', () => {
        kurumsalTabBtn.classList.add('active')
        bireyselTabBtn.classList.remove('active')
        kurumsalTabContent.classList.remove('hidden')
        bireyselTabContent.classList.add('hidden')
    })

    krediKartTabBtn.addEventListener('click', () => {
        krediKartTabBtn.classList.add('active')
        havaleTabBtn.classList.remove('active')
        krediKartTabContent.classList.remove('hidden')
        havaleTabContent.classList.add('hidden')
    })

    havaleTabBtn.addEventListener('click', () => {
        havaleTabBtn.classList.add('active')
        krediKartTabBtn.classList.remove('active')
        havaleTabContent.classList.remove('hidden')
        krediKartTabContent.classList.add('hidden')
    })

    document.querySelectorAll('.add-product-quantity').forEach((button) => {
        button.addEventListener('click', function () {
            const productItem = this.closest('.product-in-basket-item')
            if (productItem) {
                const quantityInput =
                    productItem.querySelector('.product-quantity')
                if (quantityInput) {
                    let quantity = parseInt(quantityInput.value, 10) || 0
                    quantity += 1
                    quantityInput.value = quantity
                }
            }
        })
    })

    document.querySelectorAll('.remove-product-quantity').forEach((button) => {
        button.addEventListener('click', function () {
            const productItem = this.closest('.product-in-basket-item')
            if (productItem) {
                const quantityInput =
                    productItem.querySelector('.product-quantity')
                if (quantityInput) {
                    let quantity = parseInt(quantityInput.value, 10) || 0
                    quantity = Math.max(1, quantity - 1)
                    quantityInput.value = quantity
                }
            }
        })
    })
}

export const videoPlayerShow = () => {
    const videoPlayer = document.getElementById('main-video-player')
    const videoItems = document.querySelectorAll('.video-item')
    const videoPlayerIframe = document.getElementById('main-video-iframe')
    const videoModalTitle = document.getElementById('video-modal-title')

    videoItems.forEach((item) => {
        item.addEventListener('click', () => {
            const videoId = item.getAttribute('data-video-id')
            const videoTitle = item.getAttribute('data-title')
            videoModalTitle.innerText = videoTitle
            if (videoPlayer && videoPlayerIframe && videoId) {
                videoPlayer.classList.remove('hidden')
                videoPlayerIframe.src = `https://www.youtube.com/embed/${videoId}?autoplay=1`
            }
        })
    })

    const $videoTargetEl = document.getElementById('video-modal')
    const videoDialogOptions = {
        placement: 'center',
        backdrop: true,
        bodyScrolling: false,
        backdropClasses:
            'bg-gray-900/50 dark:bg-gray-900/80 fixed inset-0 z-40',
        closable: true,
        onHide: () => {
            console.log('hide')
            const iframe = document.getElementById('main-video-iframe')
            if (iframe) {
                iframe.src = ' '
            }
            const backdropDiv = document.getElementsByClassName(
                'bg-gray-900/50 dark:bg-gray-900/80 fixed inset-0 z-40'
            )[0]
            if (backdropDiv) {
                backdropDiv.remove()
            }
        },
        onShow: () => {
            console.log('show')
        },
        onToggle: () => {
            console.log('toggle')
        },
    }

    const modal = new Modal($videoTargetEl, videoDialogOptions)

    window.addEventListener('keydown', (e) => {
        if (e.key === 'Escape') {
            modal.hide()
        }
    })

    window.addEventListener('click', (e) => {
        if (e.target === $videoTargetEl) {
            modal.hide()
        }
    })

    const closeModalBtn = document.getElementById('close-video-modal')
    if (closeModalBtn) {
        closeModalBtn.addEventListener('click', () => {
            modal.hide()
        })
    }
}

export var formValidation = () => {
    const tabs = ['musteri-bilgileri', 'odeme-bilgileri']
    const buttons = {
        'musteri-bilgileri': document.getElementById('goToDogrulamaEkrani'),
        'siparisi-tamamla': document.getElementById('completePayment'),
    }

    document.querySelectorAll('.error-msg').forEach((msg) => {
        msg.classList.add('hidden')
    })
    document.querySelectorAll('[required]').forEach((input) => {
        input.classList.remove('!border-red-500')
    })

    const validateInput = (input, showError = false) => {
        const errorElement = input.nextElementSibling
        const value = input.value.trim()
        let isEmpty = value === ''

        if (input.type === 'checkbox' || input.type === 'radio') {
            const tabId = input.getAttribute('data-input-tab')
            const inputGroup = document.querySelectorAll(
                `[required][data-input-tab="${tabId}"][type="${input.type}"]`
            )
            isEmpty = ![...inputGroup].some((input) => input.checked)

            const lastInput = inputGroup[inputGroup.length - 1]
            const groupErrorElement = lastInput.nextElementSibling

            if (isEmpty && showError) {
                if (
                    groupErrorElement &&
                    groupErrorElement.classList.contains('error-msg')
                ) {
                    groupErrorElement.classList.remove('hidden')
                }
                inputGroup.forEach((input) =>
                    input.classList.add('!border-red-500')
                )
            } else {
                if (
                    groupErrorElement &&
                    groupErrorElement.classList.contains('error-msg')
                ) {
                    groupErrorElement.classList.add('hidden')
                }
                inputGroup.forEach((input) =>
                    input.classList.remove('!border-red-500')
                )
            }

            return !isEmpty
        }

        if (isEmpty && showError) {
            input.classList.add('!border-red-500')
            if (errorElement && errorElement.classList.contains('error-msg')) {
                errorElement.classList.remove('hidden')
            }
        } else {
            input.classList.remove('!border-red-500')
            if (errorElement && errorElement.classList.contains('error-msg')) {
                errorElement.classList.add('hidden')
            }
        }

        return !isEmpty
    }

    const validateTab = (tabId, showErrors = false) => {
        const tabElement = document.getElementById(tabId)
        if (!tabElement) return false

        const requiredInputs = tabElement.querySelectorAll(
            `[required][data-input-tab="${tabId}"]`
        )
        let isValid = true

        requiredInputs.forEach((input) => {
            const inputIsValid = validateInput(
                input,
                showErrors && input.dataset.touched === 'true'
            )
            if (!inputIsValid) {
                isValid = false
            }
        })

        const button = buttons[tabId]
        if (button) {
            button.disabled = !isValid
        }

        return isValid
    }

    tabs.forEach((tabId) => {
        const tabElement = document.getElementById(tabId)
        if (!tabElement) return

        const requiredInputs = tabElement.querySelectorAll(
            `[required][data-input-tab="${tabId}"]`
        )

        requiredInputs.forEach((input) => {
            input.dataset.touched = 'false'

            input.addEventListener('blur', () => {
                input.dataset.touched = 'true'
                validateInput(input, true)
                validateTab(tabId, true)
            })

            input.addEventListener('input', () => {
                if (input.dataset.touched === 'true') {
                    validateInput(input, true)
                }
                validateTab(tabId, true)
            })
        })

        validateTab(tabId, false)
    })

    const bireyselTabBtn = document.getElementById('bireysel-btn')
    const kurumsalTabBtn = document.getElementById('kurumsal-btn')

    const bireyselTabInputs = document.querySelectorAll('.bireysel-tab-input')
    const kurumsalTabInputs = document.querySelectorAll('.kurumsal-tab-input')

    // Input'ların başlangıç required durumlarını saklamak için Map'ler
    const bireyselRequiredInputs = new Map()
    const kurumsalRequiredInputs = new Map()

    // Başlangıçta required olan input'ları sakla
    bireyselTabInputs.forEach((input) => {
        if (input.hasAttribute('required')) {
            bireyselRequiredInputs.set(input.id || input.name, {
                id: input.id,
                name: input.name,
                'data-input-tab': input.getAttribute('data-input-tab'),
            })
        }
    })

    kurumsalTabInputs.forEach((input) => {
        if (input.hasAttribute('required')) {
            kurumsalRequiredInputs.set(input.id || input.name, {
                id: input.id,
                name: input.name,
                'data-input-tab': input.getAttribute('data-input-tab'),
            })
        }
    })

    const handleTabChange = (isKurumsal) => {
        // Önce tüm hata mesajlarını ve borderları temizle
        const allInputs = [...bireyselTabInputs, ...kurumsalTabInputs]
        allInputs.forEach((input) => {
            input.value = ''
            input.classList.remove('!border-red-500')
            input.dataset.touched = 'false'
            const errorMsg = input.nextElementSibling
            if (errorMsg?.classList.contains('error-msg')) {
                errorMsg.classList.add('hidden')
            }
        })

        if (isKurumsal) {
            // Bireysel tab'deki required'ları kaldır
            bireyselTabInputs.forEach((input) => {
                input.removeAttribute('required')
                input.removeAttribute('data-input-tab')
            })

            // Kurumsal tab'de saklanmış required'ları geri ekle
            kurumsalTabInputs.forEach((input) => {
                const inputKey = input.id || input.name
                if (kurumsalRequiredInputs.has(inputKey)) {
                    const originalState = kurumsalRequiredInputs.get(inputKey)
                    input.setAttribute('required', '')
                    input.setAttribute(
                        'data-input-tab',
                        originalState['data-input-tab']
                    )
                }
            })
        } else {
            // Kurumsal tab'deki required'ları kaldır
            kurumsalTabInputs.forEach((input) => {
                input.removeAttribute('required')
                input.removeAttribute('data-input-tab')
            })

            // Bireysel tab'de saklanmış required'ları geri ekle
            bireyselTabInputs.forEach((input) => {
                const inputKey = input.id || input.name
                if (bireyselRequiredInputs.has(inputKey)) {
                    const originalState = bireyselRequiredInputs.get(inputKey)
                    input.setAttribute('required', '')
                    input.setAttribute(
                        'data-input-tab',
                        originalState['data-input-tab']
                    )
                }
            })
        }

        // Tab değişiminden sonra validasyonu tekrar çalıştır
        validateTab('odeme-bilgileri', false)
    }

    bireyselTabBtn.addEventListener('click', () => handleTabChange(false))
    kurumsalTabBtn.addEventListener('click', () => handleTabChange(true))

    // Sayfa yüklendiğinde bireysel tab aktif olarak başlasın
    handleTabChange(false)

    return true
}
