layout_change('light');
change_box_container('false');
layout_caption_change('true');
layout_rtl_change('false');
preset_change('preset-1');
main_layout_change('vertical');
//dile Değerleri
var adminLng;
function getDil(key) {
    if (adminLng != null && adminLng != "null" && adminLng != "") {
        key = key.replace(/İ/g, 'i').replace(/ı/g, 'i').toLowerCase().replace(/ç/g, 'c').replace(/ö/g, 'o').replace(/ğ/g, 'g').replace(/ü/g, 'u').replace(/ş/g, 's').replace(/[^\w\s]/gi, '').replace(/[^a-zA-Z0-9]/g, '-').substring(0, 100);
        if (adminLng[key] != null && adminLng[key] != "" && typeof adminLng[key] !== 'undefined') {
            return adminLng[key];
        } else {
            return key;
        }
    } else {
        return key;
    }
}
//!dile Değerleri

function adminLngSecim(dil) {
    window.location = location.protocol + "//" + window.location.hostname + window.location.pathname + "?lng=" + dil;
}

window.onload = setInterval(SunucuZamani, 1000);
function SunucuZamani() {
    var d = new Date();
    var date = String("0" + d.getDate()).slice(-2);
    var month = String("0" + (parseInt(d.getMonth()) + 1)).slice(-2);
    var year = d.getFullYear();
    var hour = String("0" + d.getHours()).slice(-2);
    var min = String("0" + d.getMinutes()).slice(-2);
    var sec = String("0" + d.getSeconds()).slice(-2);
    document.getElementById("time").innerHTML = date + "." + month + "." + year + " " + hour + ":" + min + ":" + sec;
}

window.onerror = function (hata, url, satir) {
    return false;
    url = "/";
    if (sessionStorage.getItem("sayfa") != null && sessionStorage.getItem("sayfa") != "" && sessionStorage.getItem("sayfa") != "null") {
        url = sessionStorage.getItem("sayfa");
    }
    $.ajax({
        type: "POST",
        url: 'Scripts/jsHataKayit.php',
        async: true, // NO LONGER ALLOWED TO BE FALSE BY BROWSER
        cache: false,
        data: { 'hata': hata, 'url': url, 'satir': satir }
    });
}

$(".menu-item,.tekliMenu").mousedown(function (ev) {//menüdeki linki kopyalama
    var sayfaBilgiler = location.protocol + "//" + window.location.hostname + window.location.pathname + "?sayfaBilgi=" + ev.currentTarget.outerHTML.split("GetPage('")[1].split("')")[0].replaceAll("','", ",");
    if (ev.which == 1) {//eğer datatable kayıtından farklı bir sayfaya geçiş yapıldıysa datatable setlemeleri sıfırlansın
        if (ev.currentTarget.outerHTML.split("GetPage('")[1].split("')")[0].replaceAll("','", ",").split(",")[1] != sessionStorage.getItem("dLink")) {//eğer tıklanan menü linki ile data table linki farklı ise sıfırlıyor
            sessionStorage.setItem("dSearch", "");
            sessionStorage.setItem("dLink", "");
            sessionStorage.setItem("orderDt", "");
        }
        sessionStorage.setItem("dPage", "");
        sessionStorage.setItem("editId", "");
    }
    else if (ev.which == 3)//sağ tık
    {
        var input = document.createElement("input");
        input.type = "text";
        input.value = sayfaBilgiler;
        document.body.appendChild(input);
        input.focus();
        input.select();
        input.setSelectionRange(0, 99999); // Mobil cihazlar için.
        document.execCommand("copy");
        document.body.removeChild(input);
        toastr.success(getDil("Menü Linki Kopyalandı."));
        return false;
    } else if (ev.which == 2) {//orta tık
        window.open(sayfaBilgiler, "_blank");
    }
});

$(window).on('mousedown', function (e) {
    if (e.which == 1) {//sol tık // data table ise table setleme bilgilerini alıyor
        if (e.target.className.indexOf("edit-button") > 0 || (e.target.parentElement != null && e.target.parentElement.className.indexOf("edit-button") > 0)) {
            if (typeof table !== 'undefined' && table != null && table != "" && table != "null") {//düzenlemeye tıklandığında eğer data table ise table setleme bilgilerini alır
                var pageInfo = table.page.info();
                var dSearch = table.search();
                if (typeof pageInfo !== 'undefined') {
                    sessionStorage.setItem("dPage", pageInfo["page"]);
                    sessionStorage.setItem("dSearch", dSearch);
                    sessionStorage.setItem("orderDt", dtOrder());
                }
            }
            sessionStorage.setItem("dLink", _sayfa);
            if (e.target.className.indexOf("edit-button") > 0) {
                sessionStorage.setItem("editId", e.target.onclick.toString().split("GetPage('")[1].split("')")[0].replaceAll("','", ",").split(",")[2]);
            } else if (e.target.parentElement.className.indexOf("edit-button") > 0) {
                sessionStorage.setItem("editId", e.target.parentElement.onclick.toString().split("GetPage('")[1].split("')")[0].replaceAll("','", ",").split(",")[2]);
            }
        }
    }
    else if (e.which == 2) {//orta tık
        if (e.target.className.indexOf("edit-button") > 0) {
            var sayfaBilgiler = location.protocol + "//" + window.location.hostname + window.location.pathname + "?sayfaBilgi=" + e.target.onclick.toString().split("GetPage('")[1].split("')")[0].replaceAll("','", ",");
            window.open(sayfaBilgiler, "_blank");
        }
    }
});

function dtOrder() {
    var orderDt = [];
    if (document.querySelector("#listTable > thead > tr") != null) {
        var basliklar = document.querySelector("#listTable > thead > tr").cells;
        for (var i = 0; i < basliklar.length; i++) {
            if (basliklar[i].className == "sorting_asc") {
                orderDt = [i, 'asc'];
            } else if (basliklar[i].className == "sorting_desc") {
                orderDt = [i, 'desc'];
            }
        }
    }
    return orderDt;
}

$(document).ready(function () {
    var sayfaBilgi = new URLSearchParams(window.location.search).get('sayfaBilgi');
    if (sayfaBilgi != null && sayfaBilgi != "null" && sayfaBilgi != "") {
        GetPage(sayfaBilgi.split(",")[0], sayfaBilgi.split(",")[1], sayfaBilgi.split(",")[2]);
        return false;
    }
    if (sessionStorage.getItem("menuId") != null && sessionStorage.getItem("menuId") != "" && sessionStorage.getItem("menuId") != "null" && sessionStorage.getItem("sayfa") != null && sessionStorage.getItem("sayfa") != "" && sessionStorage.getItem("sayfa") != "null") {
        GetPage(sessionStorage.getItem("menuId"), sessionStorage.getItem("sayfa"), sessionStorage.getItem("Id"));
    } else {
        GetPage('31', '/Admin/Project/List', '');//varsayılan anasayfa
    }
});

$('#menuAra').keyup(function () {
    // Arama terimini büyük harfe çevirin
    var searchText = $(this).val().toLocaleUpperCase('tr-TR');
    // Tüm menü elemanlarını al
    var $allListElements = $('li.pc-hasmenu');

    // Arama kutusu boşsa, sadece ana menüleri göster, alt menüleri gizle
    if (searchText === '') {
        $allListElements.show(); // Ana menüleri göster
        $allListElements.find('ul.pc-submenu').hide(); // Alt menüleri gizle
        return; // İşlemi sonlandır
    }

    // Filtreleme işlemi
    $allListElements.each(function () {
        var $this = $(this);
        var listItemText = $this.find('.pc-link .pc-mtext').text().toLocaleUpperCase('tr-TR');

        if (~listItemText.indexOf(searchText)) {
            $this.show(); // Eşleşen öğeleri göster
            $this.find('ul.pc-submenu').show(); // Alt menüleri göster
        } else {
            $this.hide(); // Eşleşmeyen öğeleri gizle
        }
    });
});


var stackMenu = [];
var stackSayfa = [];
var stackDuzenleId = [];
stackMenu.shift();
stackSayfa.shift();
stackDuzenleId.shift();
function GetPage(menuId, sayfa, Id) {
    if (menuId == "undefined" || menuId == "null" || menuId == null) {
        menuId = "";
    }
    if (sayfa == "undefined" || sayfa == "null" || sayfa == null) {
        sayfa = "";
    }
    if (Id == "undefined" || Id == "null" || Id == null) {
        Id = "";
    }
    if (sayfa == "") {
        return false;
    }
    $('#Pages').html('<img src="/Images/loading.gif" style="position:relative;left:50%;margin-top:10%;width:64px">');
    _menuId = menuId;
    _sayfa = sayfa;
    _Id = Id;
    sessionStorage.setItem("menuId", menuId);//son sayfa oturuma aktarılıyor
    sessionStorage.setItem("sayfa", sayfa);//son sayfa oturuma aktarılıyor
    sessionStorage.setItem("Id", Id);//son sayfa oturuma aktarılıyor
    if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) && document.getElementsByClassName('sidenav-overlay d-block').length == 1) {
        $('#mobilmenu').click();//mobilde menu açık kalmasın diye
    }
    $.ajax({
        type: "GET",
        url: sayfa,
        async: true, // NO LONGER ALLOWED TO BE FALSE BY BROWSER
        cache: false,
        data: { 'menuId': menuId, 'Id': Id },
        success: function (res) {
            $('#Pages').html(res);
        },
        error: function (jqXHR, status, errorThrown) {
            alert("Result: " + status + " Status: " + jqXHR.status);
        }
    });
    stackPush(menuId, sayfa, Id);
}

function geriback() {
    var i1 = stackMenu[stackMenu.length - 2];
    var i2 = stackSayfa[stackSayfa.length - 2];
    var i3 = stackDuzenleId[stackDuzenleId.length - 2];
    if (stackSayfa.length == "1" || stackSayfa.length == "0") {
        window.location.href = 'index.php';
    } else {
        stackMenu.pop();
        stackSayfa.pop();
        stackDuzenleId.pop();
        GetPage(i1, i2, i3);
    }
}

function stackPush(menuStack, sayfaStack, IdStack) {
    if (sayfaStack != stackSayfa[stackSayfa.length - 1]) {
        stackMenu.push(menuStack);
        stackSayfa.push(sayfaStack);
        stackDuzenleId.push(IdStack);
    }
}

function SayfaYenile() {
    if (typeof _menuId === 'undefined') {
        return false;
    }
    $('#Pages').html('<img src="/Images/loading.gif" style="position:relative;left:50%;margin-top:10%;width:64px">');
    if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) && document.getElementsByClassName('sidenav-overlay d-block').length == 1) {
        $('#mobilmenu').click();//mobilde menu açık kalmasın diye
    }
    GetPage(_menuId, _sayfa, _Id);
}

function YeniEkle(yeniEkleMenuId, yeniEkleSayfa) {
    GetPage(yeniEkleMenuId, yeniEkleSayfa, "");
}

function UserTableAdd(menuId, data) {
    $.ajax({
        type: "POST",
        url: "/Admin/UserTable/UserTableAdd",
        async: true, // NO LONGER ALLOWED TO BE FALSE BY BROWSER
        cache: false,
        data: { menuId, data },
    });
}

function UserTableList(menuId, callback) {
    var closeSutun = 0;
    $.ajax({
        type: "POST",
        url: '/Admin/UserTable/UserTableList',
        async: true, // NO LONGER ALLOWED TO BE FALSE BY BROWSER
        cache: false,
        data: { menuId: menuId },
        success: function (res) {
            var Data
            if (res != null && res != "") {
                Data = JSON.parse(res);
                delete Data["start"];
                delete Data["length"];
                Data.time = new Date().getTime();
                for (const column in Data.columns) {
                    if (Data.columns[column].visible == "true") {
                        Data.columns[column].visible = true;
                    } else {
                        Data.columns[column].visible = false;
                        closeSutun++;
                    }
                    delete Data.columns[column].search;
                }
                callback(Data);
            } else {
                callback(Data);
            }
        },
        error: function (error) {
            console.error("UserTableList başarısız:", error);
        }
    });
    return closeSutun;
}

function DataTableSet(url) {
    if (url.indexOf(sessionStorage.getItem("dLink"))) {
        setTimeout(function () {
            if (sessionStorage.getItem("dPage") != null && sessionStorage.getItem("dPage") != "" && sessionStorage.getItem("dPage") != "null") {
                table.page(parseInt(sessionStorage.getItem("dPage"))).draw(false);
            }
            if (sessionStorage.getItem("editId") != "" && sessionStorage.getItem("editId") != null) {
                if ($("#trSatir-" + sessionStorage.getItem("editId")).offset() != null) {
                    $('html, body').animate({
                        scrollTop: $("#trSatir-" + sessionStorage.getItem("editId")).offset().top - 200
                    }, 300);
                }
            }
            setTimeout(function () {
                if (document.getElementById("trSatir-" + sessionStorage.getItem("editId")) != null) {
                    document.getElementById("trSatir-" + sessionStorage.getItem("editId")).classList.add("editSatir");
                }
            }, 300);
        }, 300);
    }

    setTimeout(function () {
        $(".dataTables_paginate").click(function () {
            var pageInfo = table.page.info();
            var dSearch = table.search();
            //console.log(pageInfo["page"]);
            sessionStorage.setItem("dPage", pageInfo["page"]);
            sessionStorage.setItem("dSearch", dSearch);
            sessionStorage.setItem("dLink", _sayfa);
        });
    }, 500);
}


function MenuVideoButtonDurum() {
    if (document.getElementById("menuVideoButton") != null) {
        var menuVideoId = document.getElementById("menuVideoButton").getAttribute("menuVideoId");
        if (menuVideoId == "") {
            document.getElementById("menuVideoButton").style.display = "none";
            document.getElementById("menuVideoDiv").innerHTML = "";
        } else {
            document.getElementById("menuVideoButton").style.display = "inline-block";
        }
    }
}


function NotifacitionList() {
    $.ajax({
        type: "POST",
        url: "/Admin/Notification/NotificationList",
        success: function (res) {
            $('#NotifacitionList').html(res);
            UnseenNotificationCount();
            setTimeout(function () { NotifacitionList(); }, 10000);
        },
        error: function (jqXHR, status, errorThrown) {
            alert("Result: " + status + " Status: " + jqXHR.status);
        }
    });
}

function UnseenNotificationCount() {
    $.ajax({
        url: "/Admin/Notification/UnseenNotificationCount",
        type: 'GET',
        success: function (res) {
            //console.log(res); // Yanıtı kontrol edin
            if (res && res.unseenNotificationCount !== undefined) {
                $('#UnseenNotificationCount').text(res.unseenNotificationCount);
            } else {
                console.warn('UnseenNotificationCount bulunamadı');
            }
        },
        error: function (xhr, status, error) {
            alert("Result: " + status + " Status: " + jqXHR.status);
        }
    });
}

function NotificationRead() {
    $.ajax({
        type: "POST",
        url: "/Admin/Notification/NotificationRead",
        success: function (res) {
            if (res == 1) {
                NotifacitionList();
            }
        },
        error: function (jqXHR, status, errorThrown) {
            alert("Result: " + status + " Status: " + jqXHR.status);
        }
    });
}

function NotificationSingleRead(Id) {
    $.ajax({
        type: "POST",
        url: "/Admin/Notification/NotificationSingleRead", // URL'in başına '/' ekleyerek tam yol sağladığınızdan emin olun
        data: { id: Id },
        success: function (res) {
            if (res === 1) {
                NotifacitionList(); // İşlem başarılı ise NotifacitionList fonksiyonunu çağır
            }
        },
        error: function (jqXHR, status, errorThrown) {
            alert("Result: " + status + " Status: " + jqXHR.status);
        }
    });
}

NotifacitionList();

document.getElementById('notificationSwitch').addEventListener('change', function () {
    if (this.checked) {
        var data = true;
    } else {
        var data = false;
    }

    $.ajax({
        type: "POST",
        url: "/Admin/User/UserNotificationChangeStatus", // URL'in başına '/' ekleyerek tam yol sağladığınızdan emin olun
        data: { data: data },
        success: function (res) {
            if (res === 1) {
                location.reload();
            }
        },
        error: function (jqXHR, status, errorThrown) {
            alert("Result: " + status + " Status: " + jqXHR.status);
        }
    });
});