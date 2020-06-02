OOPSApp.controller('personCtrl', function (OOPSService) {
    var vm = this;

    vm.pageLoad = function () {
        vm.employeeList = OOPSService.OOPSGet("http://localhost:61842/api/Employee/EmployeeList");
    };

    vm.pageLoad();
});
