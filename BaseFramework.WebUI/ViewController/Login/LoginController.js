OOPSApp.controller('personCtrl', function ($http, OOPSService) {
    var vm = this;

    vm.Register = function () {

        var result = OOPSService.OOPSGet("http://localhost:61842/api/Roles/GetRoleDetail?Id=2");

        console.log(OOPSService.tempResponse);
        //var usrDTO = {
        //    "FullName": vm.FullName,
        //    "UserName": vm.UserName,
        //    "Password": vm.Password,
        //    "Mail": vm.Email,
        //    "Phone": vm.Phone,
        //    "Location": null,
        //    "Browser": null,
        //    "IP": null,
        //    "IsActive": true,
        //    "RoleList": [2],
        //    "CompanyName": vm.CompanyName
        //};

        //OOPSService.OOPSPost("http://localhost:61842/api/Users/Add", usrDTO, "Kullanıcı Ekleme", "Kullanıcı Başarı ile eklendi");

    };
});












//angular.module('myApp', []).controller('personCtrl', function ($http) {
//    var vm = this;

//    vm.Login = function () {

//    };

//    vm.Register = function () {
//        var usrDTO = {
//            "FullName": vm.FullName,
//            "UserName": vm.UserName,
//            "Password": vm.Password,
//            "Mail": vm.Email,
//            "Phone": vm.Phone,
//            "Location": null,
//            "Browser": null,
//            "IP": null,
//            "IsActive": true,
//            "RoleList": null,
//            "CompanyName": vm.CompanyName
//        };

//        $.ajax({
//            method: "POST",
//            url: "http://localhost:61842/api/Users/Add",
//            type: "json",
//            data: usrDTO
//        }).done(function (response, statusText, jqXHR) {

//            console.log(response);
//            console.log(statusText);
//            console.log(jqXHR);

//            if (jqXHR.status === 201) {
//                alert("olduda bitt");
//            }

//            console.log("status : " + jqXHR.status);
//            console.log("statusText : " + jqXHR.statusText);
//            console.log("location : " + jqXHR.getResponseHeader("location"));


//        }).fail(function (response, statusText, jqXHR) {
//            console.log(response);
//            console.log(statusText);
//            console.log(jqXHR);
//        });

//    };

//});