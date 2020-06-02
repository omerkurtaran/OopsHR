var OOPSApp = angular.module("OOPSApp", []);
var OOPSGetResult = undefined;

OOPSApp.service("OOPSService", function ($http) {

    this.OOPSPost = function (url, dtoObj) {
        //https://stackoverflow.com/questions/14010851/set-request-header-jquery-ajax
        $.ajax({
            method: "POST",
            url: url,
            type: "json",
            data: dtoObj
        }).done(function (response, statusText, jqXHR, successTitle, successMessage) {

            //console.log(response);
            //console.log(statusText);
            //console.log(jqXHR);

            OOPSModalOK(successTitle, successMessage);
            OOPSServerResponseCodeMessage(jqXHR);

            //if (jqXHR.status === 201) {
            //    alert("olduda bitt");
            //}

            //console.log("status : " + jqXHR.status);
            //console.log("statusText : " + jqXHR.statusText);
            //console.log("location : " + jqXHR.getResponseHeader("location"));


        }).fail(function (response, statusText, jqXHR) {
            var errorMessage = "Hatalı yada geçersiz istek";
            if (response.responseText !== "") {
                errorMessage = response.responseText;
            }
            OOPSModalError("Response Error", errorMessage);
        });

    };

    this.OOPSGet = function (url) {

        $.ajax({
            method: "GET",
            url: url,
            async: false,
            contentType: 'application/json; charset=utf-8',
            success: function (response, statusText, jqXHR) {
                OOPSGetResult = response;
            },
            error: function (response, statusText, jqXHR) {
             
            }
        });

        return OOPSGetResult;
    };

    

    //var queryValue = getParameterByName('test_user_bLzgB');

    function OOPSServerResponseCodeMessage(jqXHR) {
        if (jqXHR.status === 404) {
            OOPSModalError("404 Error", "Sayfa Bulunamadı");
        }
        if (jqXHR.status === 401) {
            OOPSModalError("401 UnAuthorize", "Yetkisiz İşlem");
        }
    };

    function OOPSModalError(title, detail) {
        Swal.fire({
            icon: 'error',
            title: title,
            html: detail,
            footer: '<a href>Sorun mu var !</a>'
        });
    }

    function OOPSModalOK(title, detail) {
        Swal.fire({
            icon: 'success',
            title: title,
            html: detail,
            footer: '<a href>Sorun mu var !</a>'
        });
    };

    function OOPSModalInfo(title, detail) {
        Swal.fire({
            icon: 'info',
            title: title,
            html: detail,
            footer: '<a href>Sorun mu var !</a>'
        });
    };
});

