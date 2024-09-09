if (!(typeof CKEDITOR === 'undefined' || CKEDITOR === null)) {
    CKEDITOR.config.allowedContent = true;
    CKEDITOR.config.autoParagraph = false;
    CKEDITOR.dtd.$removeEmpty['i'] = false;
}
//hangi inputa yazılacak ise o input id parametre gönserilir ör:onkeyup="toSeo('kategorilerAdi','kategorilerSeo')"
function toSeo(metininput, seoinput) {
    document.getElementById(metininput).value = document.getElementById(metininput).value.replace(/^\s+/, "");
    yazi = document.getElementById(metininput).value.replace(/İ/g, 'i').replace(/ı/g, 'i').toLowerCase().replace(/ç/g, 'c').replace(/ö/g, 'o').replace(/ğ/g, 'g').replace(/ü/g, 'u').replace(/ş/g, 's').replace(/[^\w\s]/gi, '');
    yazi = boslukAl(yazi);
    yazi = yazi.replace(/[^a-zA-Z0-9]/g, '-')
    yazi = cokluTireAl(yazi);
    document.getElementById(seoinput).value = yazi;
}

function boslukAl(yazi) {
    for (var i = 0; i < yazi.length; i++) {
        if (yazi.charAt(i) == " " && yazi.charAt(i + 1) == " ") {
            yazi = yazi.substr(0, i) + "" + yazi.substr(i + 1);
            yazi = boslukAl(yazi);
        }
    }
    if (yazi.charAt(yazi.length - 1) == " ") {
        yazi = yazi.substr(0, yazi.length - 1)
    }
    return yazi;
}

function cokluTireAl(yazi) {
    for (var i = 0; i < yazi.length; i++) {
        if (yazi.charAt(i) == "-" && yazi.charAt(i + 1) == "-" && yazi.charAt(i + 2) == "-") {
            yazi = yazi.substr(0, i) + "" + yazi.substr(i + 2);
            yazi = boslukAl(yazi);
        }
        if (yazi.charAt(i) == "-" && yazi.charAt(i + 1) == "-") {
            yazi = yazi.substr(0, i) + "" + yazi.substr(i + 1);
            yazi = boslukAl(yazi);
        }
    }
    if (yazi.charAt(yazi.length - 1) == "-") {
        yazi = yazi.substr(0, yazi.length - 1)
    }
    return yazi;
}
//////!toSeo

function TirnakSil(e) {
    e.value = e.value.replaceAll('\"', '\'');
}

////ulke İl fonksiyonu
function ulkeIl(ulke, il) {
    var ulke = $('#' + ulke).val();
    if (ulke == "") {
        return false;
    }
    $.ajax({
        type: "POST",
        url: "Scripts/ulkeil.php",
        data: {
            'ulke': ulke
        },
        success: function (data) {
            $('#' + il).empty();
            $('#' + il).append(data);
        }
    });
}
////!ulke İl fonksiyonu

////il illçe fonksiyonu
function ilIlce(il, ilce) {
    var il = $('#' + il).val();
    if (il == "") {
        return false;
    }
    $.ajax({
        type: "POST",
        url: "Scripts/ililce.php",
        data: {
            'il': il
        },
        success: function (data) {
            $('#' + ilce).empty();
            $('#' + ilce).append(data);
        }
    });
}
////!il illçe fonksiyonu


////ülke il fonksiyonu standart olan
$('#ulke').change(function () {
    var ulke = $('#ulke').val();
    if (ulke == "") {
        return false;
    }
    $('#il').empty();
    $.ajax({
        type: "POST",
        url: "Scripts/ulkeil.php",
        data: {
            'ulke': ulke
        },
        success: function (data) {
            $('#il').append(data);
        }
    });
});
////ülke il fonksiyonu  standart olan

////il illçe fonksiyonu standart olan
$('#il').change(function () {
    var il = $('#il').val();
    if (il == "") {
        return false;
    }
    $('#ilce').empty();
    $.ajax({
        type: "POST",
        url: "Scripts/ililce.php",
        data: {
            'il': il
        },
        success: function (data) {
            $('#ilce').append(data);
        }
    });
});
////il illçe fonksiyonu  standart olan


//ilk harfi büyük yapma
function toCapitalize(Id) {
    var input = document.getElementById(Id);
    var string = input.value;
    input.value = string[0].toUpperCase() + string.slice(1);
}

//file inputlarını temizleme
function fileInputTemizle(Id) {
    document.getElementById(Id).value = "";
    document.getElementsByName(Id)[1].innerText = getDil("Dosya Seçiniz");
}

//file inputlarını temizleme
function fileInputTemizleMulti(Id) {
    document.getElementById(Id).value = "";
    document.getElementsByName(Id)[0].innerText = getDil("Dosya Seçiniz");
}

//manuel olarak inputların dolu olup olmadığını kontrol ediyor
function ManuelFormKontrol(divId) {
    var dolumu = true;
    var inputs = document.getElementById(divId).getElementsByTagName("input");
    for (var i = 0; i < inputs.length; i++) {
        if (!inputs[i].required) {
            continue;
        }
        if (inputs[i].type == "radio") {
            var rates = document.querySelectorAll('input[name="' + inputs[i].name + '"]');
            var rBosmu = true;
            for (const r of rates) {
                if (r.checked) {
                    rBosmu = false;
                }
            }
            if (rBosmu) {
                inputs[i].style.borderBottom = "1px solid #ef0b0b";
                dolumu = false;
            } else {
                inputs[i].style.borderBottom = "1px solid #3E3E3E21";
            }
        } else if (inputs[i].type == "checkbox") {
            if (!inputs[i].checked) {
                inputs[i].style.borderBottom = "1px solid #ef0b0b";
                dolumu = false;
            } else {
                inputs[i].style.borderBottom = "1px solid #3E3E3E21";
            }
        } else {
            if (inputs[i].value == "") {
                dolumu = false;
                inputs[i].style.borderBottom = "1px solid #ef0b0b";
            } else {
                inputs[i].style.borderBottom = "1px solid #3E3E3E21";
            }
        }
    }
    return dolumu;
}

//onchange="youtubeConvert('etkinlikAlbumVideo','540','350');"
function youtubeLinkToEmbed(Id, width, height) {
    url = document.getElementById(Id).value;
    if (url == "") {
        return false;
    }
    var regExp = /^.*(youtu.be\/|v\/|u\/\w\/|embed\/|watch\?v=|\&v=)([^#\&\?]*).*/;
    var match = url.match(regExp);
    if (match && match[2].length == 11) {
        document.getElementById(Id).value = '<iframe width="' + width + '" height="' + height + '" src="//www.youtube.com/embed/' + match[2] + '" frameborder="0" allowfullscreen></iframe>';
    } else {
        document.getElementById(Id).value = 'error';
    }
}

//onkeyup="iframeToLink(id);"
function iframeToLink(id) {
    var text = document.getElementById(id).value;
    if (text.indexOf("iframe") != -1) {
        var src = text.split('src=')[1].split(/[ >]/)[0];
        document.getElementById(id).value = src.replace(/\"/g, "");;
    }
}

//tipi 1 ise input,2 ise html,3 ise veri
function kopyala(kopyaId, tipi) {
    if (tipi == 1) {
        var text = $('#' + kopyaId).val();
    } else if (tipi == 2) {
        var text = $('#' + kopyaId).text();
    } else if (tipi == 3) {
        var text = $('#' + kopyaId).html();
    }
    navigator.clipboard.writeText(text);
    toastr.success(getDil("Kopyalandı"));
    //document.getElementById(kopyaId).setAttribute('style', 'border: 3px solid #1ce589!important;');
}

//formId görnderilir ve durumda ise 1,0 gönderilir. 0 disabled,1 enabled ( submitButKontrol(this.id,0); ),( submitButKontrol("prosesPost",1) );
var buttonYazi = "";
function submitButKontrol(formId, durum) {
    var inputs = document.getElementById(formId).elements;
    for (var i = 0; i < inputs.length; i++) {
        if (inputs[i].type.toLowerCase() == "submit") {
            if (durum == 1) {
                inputs[i].disabled = false;
                inputs[i].innerHTML = buttonYazi;
            }
            else {
                buttonYazi = inputs[i].innerHTML;
                inputs[i].innerHTML = "<i class='fa fa-circle-o-notch fa-spin'></i>";
                inputs[i].disabled = true;
            }
        }
    }
}

//date-time inputunu istenen miktarda saat ekleyip hedef inputa yazdırır
function SaatEkle(kaynak, hedef, saat) {
    var basTarih = document.getElementById(kaynak).value;
    var d = new Date(basTarih);
    d.setHours(d.getHours() + saat);
    d.setMinutes(d.getMinutes() - d.getTimezoneOffset());
    document.getElementById(hedef).value = d.toISOString().slice(0, 16);
}

//sayfadaki tüm  leri sıfırlar => resetRecaptchas()
function resetRecaptchas() {
    var recList = document.getElementsByClassName("g-recaptcha");
    for (var i = 0; i < recList.length; i++) {
        var widgetId;
        var onloadCallback = function () {
            widgetId = grecaptcha.render(recList[i], {
                'sitekey': recList[i].getAttribute("data-sitekey")
            });
        };
        grecaptcha.reset(i);
    }
}

function resetS3Recaptcha(publicRecaptcha, action, tokenId, formId) {
    submitButKontrol(formId, 0);
    grecaptcha.execute(publicRecaptcha, { action: action })
        .then(function (token) {
            document.getElementById(tokenId).value = token;
            submitButKontrol(formId, 1);
        });
}

function renderTurnstiles() {
    var recList = document.getElementsByClassName("cf-turnstile");
    for (var i = 0; i < recList.length; i++) {
        var widgetId = turnstile.render(recList[i], {
            sitekey: recList[i].getAttribute("data-sitekey")
        });
        recList[i].setAttribute("data-widget-id", widgetId);
    }
}

function resetCloudflareRecaptchas() {
    var recList = document.getElementsByClassName("cf-turnstile");
    for (var i = 0; i < recList.length; i++) {
        var widgetId = recList[i].getAttribute("data-widget-id");
        if (widgetId) {
            turnstile.reset(widgetId);
        }
    }
}

$(document).ready(function () {
    renderTurnstiles();
});

//datatable export loglama
$(document).ready(function () {
    $('.buttons-copy').click(function () {
        dataTableExport("Kopyala");
    });
});
$(document).ready(function () {
    $('.buttons-excel').click(function () {
        dataTableExport("Excel");
    });
});
$(document).ready(function () {
    $('.buttons-pdf').click(function () {
        dataTableExport("Pdf");
    });
});
$(document).ready(function () {
    $('.buttons-print').click(function () {
        dataTableExport("Print");
    });
});
function dataTableExport(tipi) {
    var exportBasliklar = [];
    var basliklar = document.querySelector("#listTable > thead > tr").cells;
    for (var i = 0; i < basliklar.length; i++) {
        exportBasliklar.push(basliklar[i].innerHTML);
    }
    $.ajax({
        type: "POST",
        url: "Pages/dataTableExport.php",
        data: { 'tipi': tipi, 'exportBasliklar': exportBasliklar },
        success: function (res) {

        },
        error: function (jqXHR, status, errorThrown) {
            alert("Result: " + status + " Status: " + jqXHR.status);
        }
    });
}

//seçerek excel almak için
var excelList = [];
function UpdateExcelList(Id) {
    var secim = document.getElementById("excel-" + Id).checked;
    if (secim) {
        excelList.push(Id);
    } else {
        for (var i = 0; i < excelList.length; i++) {
            if (excelList[i] == Id) {
                excelList.splice(i, 1)
            }
        }
    }
}

function ExcelCheckExport(tableName, tabloPrimarySutun) {
    if (excelList.length <= 0) {
        alert(getDil("Lütfen Seçim Yapınız."));
        return false;
    }
    $.ajax({
        type: "POST",
        url: "Pages/" + tableName + "/excelCheckExport.php",
        data: { 'excelList': excelList, 'tableName': tableName, 'tabloPrimarySutun': tabloPrimarySutun },
        success: function (res) {
            window.location.href = "Pages/excel.php";
        },
        error: function (jqXHR, status, errorThrown) {
            alert("Result: " + status + " Status: " + jqXHR.status);
        }
    });
}

//görsel crop işlemleri başlangıç
//ImageCrop('img-crop',"img-preview",150,50);
//CropImageInfo();
var $imageCrop = null;
function ImageCrop(className, cropClassName, cropWidth, cropHeight) {
    $imageCrop = $('.' + className);
    var $dataX = $('.main-demo-dataX');
    var $dataY = $('.main-demo-dataY');
    var $dataHeight = $('.main-demo-dataHeight');
    var $dataWidth = $('.main-demo-dataWidth');
    var $dataRotate = $('.main-demo-dataRotate');
    var $dataScaleX = $('.main-demo-dataScaleX');
    var $dataScaleY = $('.main-demo-dataScaleY');
    var options = {
        viewMode: 1,
        dragMode: 'move',
        autoCropArea: 0.65,
        restore: false,
        guides: false,
        center: false,
        highlight: false,
        cropBoxMovable: true,
        cropBoxResizable: false,
        zoomOnWheel: false,
        toggleDragModeOnDblclick: false,
        data: { //define cropbox size
            width: cropWidth,
            height: cropHeight,
        },
        preview: '.' + cropClassName,
        crop: function (e) {
            $dataX.val(Math.round(e.detail.x));
            $dataY.val(Math.round(e.detail.y));
            $dataHeight.val(Math.round(e.detail.height));
            $dataWidth.val(Math.round(e.detail.width));
            $dataRotate.val(e.detail.rotate);
            $dataScaleX.val(e.detail.scaleX);
            $dataScaleY.val(e.detail.scaleY);
        }
    };
    // Cropper
    $imageCrop.cropper(options);
}

function CropImageInfo() {
    result = $imageCrop.cropper("getData");
    //console.log(result);
    return JSON.stringify(result);
}
//görsel crop işlemleri bitiş

function GeriSayim(Id) {
    // Set the date we're counting down to
    if (document.getElementById(Id) != null) {
        var tarih = document.getElementById(Id).innerHTML;
        var countDownDate = new Date(tarih).getTime();
        // Update the count down every 1 second
        var x = setInterval(function () {
            // Get today's date and time
            var now = new Date().getTime();
            // Find the distance between now and the count down date
            var distance = countDownDate - now;
            // Time calculations for days, hours, minutes and seconds
            var days = Math.floor(distance / (1000 * 60 * 60 * 24));
            var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
            var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
            var seconds = Math.floor((distance % (1000 * 60)) / 1000);
            if (document.getElementById(Id) != null) {
                document.getElementById(Id).innerHTML = days + "g " + hours + "s " + minutes + "d " + seconds + "sn ";
                // If the count down is finished, write some text
                if (distance < 0) {
                    clearInterval(x);
                    document.getElementById(Id).innerHTML = getDil("Süre Tamamlandı.");
                }
            } else {
                clearInterval(x);
            }
        }, 1000);
    } else {
        clearInterval(x);
    }
}

//onclick="SifreUret(Id);"
function SifreUret(Id) {
    let length = 4;
    let charsetAlf = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    let charsetNum = "0123456789";
    let retVal = "";
    for (var i = 0, n = charsetAlf.length; i < length; ++i) {
        retVal += charsetAlf.charAt(Math.floor(Math.random() * n));
    }
    for (var i = 0, n = charsetNum.length; i < length; ++i) {
        retVal += charsetNum.charAt(Math.floor(Math.random() * n));
    }
    retVal += ".";
    document.getElementById(Id).value = retVal;
    navigator.clipboard.writeText(retVal);
    toastr.success(getDil("Kopyalandı"));
}

var oncekiGenislik = parseInt(window.innerWidth);
window.onresize = function (event) {
    if (Math.abs(oncekiGenislik - parseInt(window.innerWidth)) > 50) {
        if ($(".select2") !== null) {
            $(".select2").select2();
        }
    }
};

$(document).ready(function () {
    MenuVideoButtonDurum();
});

$("input[type=text]").keyup(function () {
    if (this.className.toLowerCase().indexOf("close-capitalized") < 0 && this.id.toLowerCase().indexOf("link") < 0 && this.id.toLowerCase().indexOf("slug") < 0) {
        this.value = this.value.charAt(0).toUpperCase() + this.value.slice(1);
    }
});

$("input[type=tel]").keyup(function () {
    this.value = this.value.replace(/ /g, '');
});

$("input[type=email]").keyup(function () {
    this.value = this.value.replace(/ /g, '');
});

$('.passEye').click(function (e) {
    var password = $(this).prev('input')[0];  // Önceki input alanını seçer
    const type = password.getAttribute('type') === 'password' ? 'text' : 'password';
    password.setAttribute('type', type);

    // Sınıf değişimini daha doğru yapacak şekilde güncellendi
    if (type === 'password') {
        $(this).removeClass('fa-eye-slash').addClass('fa-eye');
    } else {
        $(this).removeClass('fa-eye').addClass('fa-eye-slash');
    }
});

$('.passEye2').click(function (e) {
    var password = $(this).prev('input')[0];  // Önceki input alanını seçer
    const type = password.getAttribute('type') === 'password' ? 'text' : 'password';
    password.setAttribute('type', type);

    // Sınıf değişimini daha doğru yapacak şekilde güncellendi
    if (type === 'password') {
        $(this).removeClass('fa-eye-slash').addClass('fa-eye');
    } else {
        $(this).removeClass('fa-eye').addClass('fa-eye-slash');
    }
});

$(document).ready(function () {
    var allInputs = $(":input,select");
    for (let i = 0; i < allInputs.length; i++) {
        if (allInputs[i].required == true) {
            /*
            'beforebegin': Öğenin kendisinden önce
            'afterbegin': Öğenin hemen içinde, ilk çocuğundan önce
            'beforeend': Öğenin hemen içinde, son çocuğundan sonra
            'afterend': Öğenin kendisinden sonra
            */
            if (allInputs[i].type.indexOf("select") != -1) {
                if ($('label[for="' + allInputs[i].id + '"]').find("span").length === 0) {
                    $("<span style='color:red;margin-left:0.5rem;'> *</span>").appendTo($('label[for="' + allInputs[i].id + ''));
                }
            } else {
                if (allInputs[i].parentElement.querySelector("div > label") != null && allInputs[i].parentElement.querySelector("div > span") === null) {
                    allInputs[i].parentElement.querySelector("div > label").insertAdjacentHTML("afterend", "<span style='color:red;margin-left:0.5rem;'> *</span>");
                }
            }
        }
    }
});

//<input type="checkbox" style="width: 15px;height: 15px;float: right;" id="selectTumu-teknikElemanIdF" onchange="SelectTumu(this)">
function SelectTumu(e) {
    var id = e.id.split('-')[1];
    if ($("#" + e.id).is(':checked')) {
        $("#" + id + " > option").prop("selected", true);
        $("#" + id + "").trigger("change");
    } else {
        $("#" + id + " > option").prop("selected", false);
        $("#" + id + "").trigger("change");
    }
}

//mailGonder("1,2","emre1@emre.com,emre2@emre.com");
var emailArray = [];
var dataArray = [];
function mailGonder(datas, emails) {
    if (emails != "") {
        emailArray = emails.split(",");
    }
    if (datas != "") {
        dataArray = datas.split(",");
    }
    if (emailArray[0] != null && emailArray[0] != "" && typeof emailArray[0] !== 'undefined') {
        var data = new data();
        data.append('data', dataArray[0]);
        data.append('email', emailArray[0]);
        $.ajax({
            type: "POST",
            url: "Scripts/mailGonder.php",
            data: data,
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.status == "success") {
                    console.log(res.data);
                } else {
                    console.log(res.message);
                }
                emailArray.shift();
                dataArray.shift();
                if (emailArray.length > 0) {
                    mailGonder("", "");
                } else {
                    //bitis te yapılacak islem
                }
            },
            error: function (jqXHR, status, errorThrown) {
                alert("Result: " + status + " Status: " + jqXHR.status);
            }
        });
    }
}

function selectSelectedChangeText(Id) {
    var x = document.getElementById(Id);
    var selection = $('#' + Id).select2('data');
    if (selection.length > 5) {
        return;
    }
    for (var i = 0; i < x.length; i++) {
        if (x.options[i].selected) {
            //console.log(x.options[i].text);
            //console.log(x.options[i].value);
            //x.options[i].text="* "+x.options[i].text;
            if (!x.options[i].text.includes("*")) {
                $("#" + Id).select2("destroy");
                $('#' + Id + ' option[value="' + x.options[i].value + '"]').text("* " + x.options[i].text);
                $("#" + Id).select2();
            }
        }
    }
}

$(document).ready(function () {
    $('.select2').change(function () {
        let selectId = this.id;
        if (selectId == "") {
            return;
        }
        var selection = $('#' + selectId).select2('data');
        if (selection.length > 5) {
            var textToShow = selection.slice(0, 5).map(function (item) { return item.text; }).join(', ') + '...';
            var $selection = $('#' + selectId).next('.select2').find('.select2-selection__rendered');
            $selection.attr('title', selection.map(function (item) { return item.text; }).join(', '));
            $selection.text(textToShow);
        }
    });
    var allInputs = $(".select2");
    for (let i = 0; i < allInputs.length; i++) {
        let selectId = allInputs[i].id;
        if (selectId == "") {
            continue;
        }
        var selection = $('#' + selectId).select2('data');
        if (selection.length > 5) {
            var textToShow = selection.slice(0, 5).map(function (item) { return item.text; }).join(', ') + '...';
            var $selection = $('#' + selectId).next('.select2').find('.select2-selection__rendered');
            $selection.attr('title', selection.map(function (item) { return item.text; }).join(', '));
            $selection.text(textToShow);
        }
    }
});
//toastr.success(getDil("Başarılı"));

$(document).ready(function () {
    try {
        var flatpickrLocal = {
            weekdays: {
                shorthand: ["Paz", "Pzt", "Sal", "Çar", "Per", "Cum", "Cmt"],
                longhand: [
                    "Pazar",
                    "Pazartesi",
                    "Salı",
                    "Çarşamba",
                    "Perşembe",
                    "Cuma",
                    "Cumartesi",
                ],
            },
            months: {
                shorthand: [
                    "Oca",
                    "Şub",
                    "Mar",
                    "Nis",
                    "May",
                    "Haz",
                    "Tem",
                    "Ağu",
                    "Eyl",
                    "Eki",
                    "Kas",
                    "Ara",
                ],
                longhand: [
                    "Ocak",
                    "Şubat",
                    "Mart",
                    "Nisan",
                    "Mayıs",
                    "Haziran",
                    "Temmuz",
                    "Ağustos",
                    "Eylül",
                    "Ekim",
                    "Kasım",
                    "Aralık",
                ],
            },
            firstDayOfWeek: 1,
            ordinal: function () {
                return ".";
            },
            rangeSeparator: " - ",
            weekAbbreviation: "Hf",
            scrollTitle: "Artırmak için kaydırın",
            toggleTitle: "Aç/Kapa",
            amPM: ["ÖÖ", "ÖS"],
            time_24hr: true,
        };
        flatpickr(".flatpickr-datetime", {
            weekNumbers: true,
            allowInput: true,
            enableTime: true,
            altInput: true,
            dateFormat: "Y-m-d H:i",
            altFormat: "d.m.Y H:i",
            locale: flatpickrLocal,
            plugins: [
                ShortcutButtonsPlugin({
                    button: [
                        {
                            label: getDil("Bugün")
                        },
                        {
                            label: getDil("Temizle")
                        },
                    ],
                    onClick: (index, fp) => {
                        let date;
                        switch (index) {
                            case 0:
                                date = new Date();
                                fp.setDate(date);
                                break;
                            case 1:
                                fp.clear();
                                fp.close();
                                break;
                        }
                    }
                })
            ]
        });
        flatpickr(".flatpickr-date", {
            weekNumbers: true,
            allowInput: true,
            altInput: true,
            dateFormat: "Y-m-d",
            altFormat: "d.m.Y",
            locale: flatpickrLocal,
            plugins: [
                ShortcutButtonsPlugin({
                    button: [
                        {
                            label: getDil("Bugün")
                        },
                        {
                            label: getDil("Temizle")
                        },
                    ],
                    onClick: (index, fp) => {
                        let date;
                        switch (index) {
                            case 0:
                                date = new Date();
                                fp.setDate(date);
                                break;
                            case 1:
                                fp.clear();
                                fp.close();
                                break;
                        }
                    }
                })
            ]
        });
    } catch (e) {

    }
    var genericExamples = document.querySelectorAll('[data-trigger]');
    for (i = 0; i < genericExamples.length; ++i) {
        var element = genericExamples[i];
        new Choices(element, {
            //placeholderValue: 'This is a placeholder set in the config',
            //searchPlaceholderValue: 'This is a search placeholder'
        });
    }
});
/*Emre ARIĞ*/
